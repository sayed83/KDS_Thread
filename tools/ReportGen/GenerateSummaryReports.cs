// Regenerates Report\Repres_ScheduleBalance_RepSummary.rpt and Report\Count_ScheduleBalance_Summary.rpt
// from Report\Repres_ScheduleBalance_Summary.rpt (keeps its header/logo/footer) using the Crystal RAS SDK.
// Not part of the app build. Compile with the .NET 4 csc.exe referencing the CrystalDecisions 13.0.4000 assemblies
// (Engine, Shared, ReportAppServer.ClientDoc/Controllers/ReportDefModel/DataDefModel/CommonObjectModel), then run:
//   GenerateSummaryReports.exe "<project>\Report\Repres_ScheduleBalance_Summary.rpt" "<project>\Report"
using System;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer.ClientDoc;
using CrystalDecisions.ReportAppServer.Controllers;
using RD = CrystalDecisions.ReportAppServer.ReportDefModel;
using DD = CrystalDecisions.ReportAppServer.DataDefModel;

class Gen {
  const string TBL = "T_Rpt_Reprs_ScheduleBalance_Proc;1";

  static void Main(string[] a) {
    string src = a[0], outDir = a[1];
    Build(src, System.IO.Path.Combine(outDir, "Repres_ScheduleBalance_RepSummary.rpt"), "RepName",
          "Representative wise - Schedule Balance Summary", "Representative");
    Build(src, System.IO.Path.Combine(outDir, "Count_ScheduleBalance_Summary.rpt"), "ProductName",
          "Count wise - Schedule Balance Summary", "Count");
  }

  static string Fld(string col) { return "{" + TBL + "." + col + "}"; }

  static DD.ISCRField FindField(ISCDReportClientDocument rcd, string col) {
    string ff = Fld(col);
    foreach (DD.ISCRTable t in rcd.Database.Tables)
      foreach (DD.ISCRField f in t.DataFields)
        if (string.Equals(f.FormulaForm, ff, StringComparison.OrdinalIgnoreCase)) return f;
    throw new Exception("Field not found: " + ff);
  }

  static RD.Section Sec(ISCDReportClientDocument rcd, string name) {
    foreach (RD.Area area in rcd.ReportDefinition.Areas)
      foreach (RD.Section s in area.Sections) if (s.Name == name) return s;
    throw new Exception("Section not found: " + name);
  }

  static RD.ISCRReportObject FindObj(RD.Section s, string name) {
    foreach (RD.ISCRReportObject o in s.ReportObjects) if (o.Name == name) return o;
    throw new Exception("Object not found: " + name + " in " + s.Name);
  }

  static void SetText(RD.TextObject t, string text) { SetText(t, text, RD.CrAlignmentEnum.crAlignmentDefault); }
  static void SetText(RD.TextObject t, string text, RD.CrAlignmentEnum align) {
    var p = (RD.Paragraph)t.Paragraphs[0];
    if (align != RD.CrAlignmentEnum.crAlignmentDefault) p.Alignment = align;
    var first = (RD.ParagraphTextElement)p.ParagraphElements[0];
    first.Text = text;
    while (p.ParagraphElements.Count > 1) p.ParagraphElements.Remove(1);
    while (t.Paragraphs.Count > 1) t.Paragraphs.Remove(1);
  }

  static void Build(string src, string dst, string groupCol, string title, string caption) {
    var rd = new ReportDocument();
    rd.Load(src);
    ISCDReportClientDocument rcd = rd.ReportClientDocument;
    var objCtl = rcd.ReportDefController.ReportObjectController;
    var secCtl = rcd.ReportDefController.ReportSectionController;

    RD.Section ph = null, gh = null, det = null, rf = null;
    foreach (RD.Area area in rcd.ReportDefinition.Areas)
      foreach (RD.Section s in area.Sections) {
        if (s.Name == "Section2") ph = s;
        else if (s.Name == "GroupHeaderSection1") gh = s;
        else if (s.Name == "Section3") det = s;
        else if (s.Name == "Section4") rf = s;
      }

    // Templates (clones keep fonts / number formats)
    var nameTpl = (RD.FieldObject)FindObj(det, "GroupNameRepName1").Clone(true);
    var sumTpl  = (RD.FieldObject)FindObj(gh, "SumofSchBalance4").Clone(true);
    var textTpl = (RD.TextObject)FindObj(det, "Text8").Clone(true);

    // Title
    var titleOld = (RD.TextObject)FindObj(ph, "Text18");
    var titleNew = (RD.TextObject)titleOld.Clone(true);
    SetText(titleNew, title);
    titleNew.Width = 6600;
    objCtl.Modify(titleOld, titleNew);

    // Clear detail + group header objects, then old summaries
    foreach (RD.Section s in new[] { det, gh }) {
      var list = new List<RD.ISCRReportObject>();
      foreach (RD.ISCRReportObject o in s.ReportObjects) list.Add(o);
      foreach (var o in list) objCtl.Remove(o);
    }
    var sums = new List<object>();
    foreach (object sf in rcd.DataDefinition.SummaryFields) sums.Add(sf);
    foreach (var sf in sums) rcd.DataDefController.SummaryFieldController.Remove(sf);

    // Group on the requested column
    var g = (DD.Group)rcd.DataDefinition.Groups[0];
    if (!string.Equals(g.ConditionField.FormulaForm, Fld(groupCol), StringComparison.OrdinalIgnoreCase)) {
      var ng = (DD.Group)g.Clone(true);
      ng.ConditionField = (DD.Field)FindField(rcd, groupCol);
      rcd.DataDefController.GroupController.Modify(g, ng);
    }
    g = (DD.Group)rcd.DataDefinition.Groups[0];
    ph = Sec(rcd, "Section2"); gh = Sec(rcd, "GroupHeaderSection1"); det = Sec(rcd, "Section3"); rf = Sec(rcd, "Section4");

    // Summaries: per group + grand total
    var bal = FindField(rcd, "SchBalance");
    var sGrp = new DD.SummaryField();
    sGrp.SummarizedField = (DD.Field)bal;
    sGrp.Operation = DD.CrSummaryOperationEnum.crSummaryOperationSum;
    sGrp.Group = g;
    rcd.DataDefController.SummaryFieldController.Add(-1, sGrp);
    var sAll = new DD.SummaryField();
    sAll.SummarizedField = (DD.Field)bal;
    sAll.Operation = DD.CrSummaryOperationEnum.crSummaryOperationSum;
    rcd.DataDefController.SummaryFieldController.Add(-1, sAll);

    // RAS drops a field object for each new summary into footers - remove them
    foreach (string secName in new[] { "GroupFooterSection1", "Section4" }) {
      var s2 = Sec(rcd, secName);
      var junk = new List<RD.ISCRReportObject>();
      foreach (RD.ISCRReportObject o in s2.ReportObjects) junk.Add(o);
      foreach (var o in junk) objCtl.Remove(o);
    }
    ph = Sec(rcd, "Section2"); gh = Sec(rcd, "GroupHeaderSection1"); det = Sec(rcd, "Section3"); rf = Sec(rcd, "Section4");

    string grpSumForm = "Sum (" + Fld("SchBalance") + ", " + Fld(groupCol) + ")";
    string allSumForm = "Sum (" + Fld("SchBalance") + ")";

    // Table grid: [ Name (x=120..8160) ][ Total Balance (x=8160..10920) ]
    // Grid is drawn with line objects; text sits vertically centred inside each cell with a small inset.
    const int x0 = 120, x1 = 8160, x2 = 10920, rowH = 340, txtH = 221, pad = 80, capTop = 1620;
    int txtTop = (rowH - txtH) / 2;
    var lineTpl = (RD.LineObject)FindObj(ph, "Line25").Clone(true);
    const uint Blue = 0xFF0000; // Crystal colours are BGR

    // Page header: caption row (bold)
    secCtl.SetProperty(ph, CrReportSectionPropertyEnum.crReportSectionPropertyHeight, capTop + rowH);
    var cap1 = (RD.TextObject)textTpl.Clone(true); SetText(cap1, caption, RD.CrAlignmentEnum.crAlignmentLeft);
    cap1.Name = "CapName"; Place(cap1, x0 + pad, capTop + txtTop, x1 - x0 - 2 * pad, txtH); TextFont(cap1, true, 0);
    objCtl.Add(cap1, ph, -1);
    var cap2 = (RD.TextObject)textTpl.Clone(true); SetText(cap2, "Total Balance", RD.CrAlignmentEnum.crAlignmentRight);
    cap2.Name = "CapBal"; Place(cap2, x1 + pad, capTop + txtTop, x2 - x1 - 2 * pad, txtH); TextFont(cap2, true, 0);
    objCtl.Add(cap2, ph, -1);
    Grid(objCtl, ph, lineTpl, "Cap", capTop, rowH, x0, x1, x2, true);

    // Group header row: name + balance (regular)
    secCtl.SetProperty(gh, CrReportSectionPropertyEnum.crReportSectionPropertyHeight, rowH);
    var nm = (RD.FieldObject)nameTpl.Clone(true);
    nm.Name = "GrpName"; nm.DataSourceName = "GroupName (" + Fld(groupCol) + ")";
    Place(nm, x0 + pad, txtTop, x1 - x0 - 2 * pad, txtH); FieldFont(nm, false, 0); NoBorder(nm);
    objCtl.Add(nm, gh, -1);
    var gs = (RD.FieldObject)sumTpl.Clone(true);
    gs.Name = "GrpBalance"; gs.DataSourceName = grpSumForm; gs.Format.HorizontalAlignment = RD.CrAlignmentEnum.crAlignmentRight;
    Place(gs, x1 + pad, txtTop, x2 - x1 - 2 * pad, txtH); FieldFont(gs, false, 0); NoBorder(gs);
    objCtl.Add(gs, gh, -1);
    Grid(objCtl, gh, lineTpl, "Row", 0, rowH, x0, x1, x2, false);

    // Detail hidden
    var detFmt = (RD.SectionFormat)det.Format.Clone(true);
    detFmt.EnableSuppress = true;
    secCtl.SetProperty(det, CrReportSectionPropertyEnum.crReportSectionPropertyFormat, detFmt);

    // Report footer: grand total row (bold, blue), directly under the last row
    secCtl.SetProperty(rf, CrReportSectionPropertyEnum.crReportSectionPropertyHeight, rowH + 120);
    var gtl = (RD.TextObject)textTpl.Clone(true); SetText(gtl, "Grand Total", RD.CrAlignmentEnum.crAlignmentRight);
    gtl.Name = "GrandLbl"; Place(gtl, x0 + pad, txtTop, x1 - x0 - 2 * pad, txtH); TextFont(gtl, true, Blue);
    objCtl.Add(gtl, rf, -1);
    var gt = (RD.FieldObject)sumTpl.Clone(true);
    gt.Name = "GrandBalance"; gt.DataSourceName = allSumForm; gt.Format.HorizontalAlignment = RD.CrAlignmentEnum.crAlignmentRight;
    Place(gt, x1 + pad, txtTop, x2 - x1 - 2 * pad, txtH); FieldFont(gt, true, Blue); NoBorder(gt);
    objCtl.Add(gt, rf, -1);
    Grid(objCtl, rf, lineTpl, "Tot", 0, rowH, x0, x1, x2, false);

    if (System.IO.File.Exists(dst)) System.IO.File.Delete(dst);
    rd.SaveAs(dst);
    rd.Close();
    Console.WriteLine("Saved " + dst);
  }

  static void Place(RD.ISCRReportObject o, int left, int top, int width, int height) {
    o.Left = left; o.Top = top; o.Width = width; o.Height = height;
  }

  // One table row = two box objects (name cell, balance cell). Shared edges sit on the same
  // coordinates, so they print as a single line.
  static void Grid(ReportObjectController ctl, RD.Section s, RD.LineObject tpl, string prefix,
                   int top, int h, int x0, int x1, int x2, bool withTop) {
    AddBox(ctl, s, tpl, prefix + "BoxName", x0, top, x1, top + h);
    AddBox(ctl, s, tpl, prefix + "BoxBal", x1, top, x2, top + h);
  }

  static void AddBox(ReportObjectController ctl, RD.Section s, RD.LineObject tpl, string name,
                     int left, int top, int right, int bottom) {
    var b = new RD.BoxObject();
    b.Name = name; b.SectionName = s.Name; b.EndSectionName = s.Name;
    b.Left = left; b.Right = right; b.Top = top; b.Bottom = bottom;
    b.LineStyle = RD.CrLineStyleEnum.crLineStyleSingle;
    b.LineThickness = tpl.LineThickness;
    b.LineColor = tpl.LineColor;
    b.FillColor = 0xFFFFFF;
    ctl.Add(b, s, -1);
  }

  static void NoBorder(RD.ISCRReportObject o) {
    RD.Border b = o.Border;
    var none = RD.CrLineStyleEnum.crLineStyleNoLine;
    b.LeftLineStyle = none; b.RightLineStyle = none; b.TopLineStyle = none; b.BottomLineStyle = none;
  }

  static void ApplyFont(CrystalDecisions.ReportAppServer.ReportDefModel.FontColor fc, bool bold, uint color) {
    fc.Font.Name = "Arial";
    fc.Font.Size = 9;
    fc.Font.Bold = bold;
    fc.Color = color;
  }

  static void FieldFont(RD.FieldObject o, bool bold, uint color) { ApplyFont(o.FontColor, bold, color); }

  static void TextFont(RD.TextObject t, bool bold, uint color) {
    foreach (RD.Paragraph p in t.Paragraphs)
      foreach (object e in p.ParagraphElements) {
        var te = e as RD.ParagraphTextElement;
        if (te != null) ApplyFont(te.FontColor, bold, color);
      }
  }
}
