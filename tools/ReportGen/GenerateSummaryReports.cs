// Regenerates Report\Repres_ScheduleBalance_RepSummary.rpt and Report\Count_ScheduleBalance_Summary.rpt
// from Report\Repres_ScheduleBalance_Summary.rpt (keeps its logo/title/footer) using the Crystal RAS SDK.
// Each report is bound to the exact result columns of its own stored procedure:
//   RepSummary -> T_Rpt_Reprs_ScheduleBalance_RepWiseSummary_Proc  (grouped on RepName)
//   Count      -> T_Rpt_Reprs_ScheduleBalance_CountSummary_Proc    (grouped on CountName)
// If a procedure's output columns change, update RepSchema()/CountSchema() below and re-run.
// Not part of the app build. Compile with the .NET 4 csc.exe referencing the CrystalDecisions 13.0.4000 assemblies
// (Engine, Shared, ReportAppServer.ClientDoc/Controllers/ReportDefModel/DataDefModel/CommonObjectModel/DataSetConversion), then run:
//   GenerateSummaryReports.exe "<project>\Report\Repres_ScheduleBalance_Summary.rpt" "<project>\Report"
using System;
using System.Collections.Generic;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer.ClientDoc;
using CrystalDecisions.ReportAppServer.Controllers;
using RD = CrystalDecisions.ReportAppServer.ReportDefModel;
using DD = CrystalDecisions.ReportAppServer.DataDefModel;

class Gen {
  static string tbl; // table name of the report being built

  static void Main(string[] a) {
    string src = a[0], outDir = a[1];
    Build(src, System.IO.Path.Combine(outDir, "Repres_ScheduleBalance_RepSummary.rpt"), RepSchema(), "RepName",
          "Representative wise - Schedule Balance Summary", "Representative");
    Build(src, System.IO.Path.Combine(outDir, "Count_ScheduleBalance_Summary.rpt"), CountSchema(), "CountName",
          "Count wise - Schedule Balance Summary", "Count");
  }

  // Result columns of T_Rpt_Reprs_ScheduleBalance_RepWiseSummary_Proc
  static DataTable RepSchema() {
    var t = new DataTable("RepWiseSummary");
    t.Columns.Add("RepresentativeId", typeof(int));
    t.Columns.Add("RepName", typeof(string));
    t.Columns.Add("TeamName", typeof(string));
    t.Columns.Add("TotalOrders", typeof(int));
    t.Columns.Add("TotalBookingItems", typeof(int));
    t.Columns.Add("TotalCustomers", typeof(int));
    AddQtyColumns(t);
    return t;
  }

  // Result columns of T_Rpt_Reprs_ScheduleBalance_CountSummary_Proc
  static DataTable CountSchema() {
    var t = new DataTable("CountSummary");
    t.Columns.Add("ProductId", typeof(int));
    t.Columns.Add("CountName", typeof(string));
    t.Columns.Add("TotalOrders", typeof(int));
    t.Columns.Add("TotalBookingItems", typeof(int));
    AddQtyColumns(t);
    return t;
  }

  static void AddQtyColumns(DataTable t) {
    foreach (var c in new[] { "OrderQty", "SchQty", "CancelQty", "ReturnQty", "SchBalance", "DeliveryBalance" })
      t.Columns.Add(c, typeof(int));
    t.Columns.Add("Unit", typeof(string));
  }

  static string Fld(string col) { return "{" + tbl + "." + col + "}"; }

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

  static void RemoveObjects(ReportObjectController ctl, RD.Section s, Predicate<RD.ISCRReportObject> which) {
    var list = new List<RD.ISCRReportObject>();
    foreach (RD.ISCRReportObject o in s.ReportObjects) if (which(o)) list.Add(o);
    foreach (var o in list) ctl.Remove(o);
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

  static void Build(string src, string dst, DataTable schema, string groupCol, string title, string caption) {
    var rd = new ReportDocument();
    rd.Load(src);
    ISCDReportClientDocument rcd = rd.ReportClientDocument;
    var objCtl = rcd.ReportDefController.ReportObjectController;
    var secCtl = rcd.ReportDefController.ReportSectionController;

    RD.Section ph = Sec(rcd, "Section2"), gh = Sec(rcd, "GroupHeaderSection1"),
               det = Sec(rcd, "Section3"), rf = Sec(rcd, "Section4");

    // Templates (clones keep fonts / number formats)
    var nameTpl = (RD.FieldObject)FindObj(det, "GroupNameRepName1").Clone(true);
    var sumTpl  = (RD.FieldObject)FindObj(gh, "SumofSchBalance4").Clone(true);
    var textTpl = (RD.TextObject)FindObj(det, "Text8").Clone(true);
    var unitTpl = (RD.FieldObject)FindObj(ph, "Unit1").Clone(true);

    // Title
    var titleOld = (RD.TextObject)FindObj(ph, "Text18");
    var titleNew = (RD.TextObject)titleOld.Clone(true);
    SetText(titleNew, title);
    titleNew.Width = 6600;
    objCtl.Modify(titleOld, titleNew);

    // Drop everything bound to the old table: body objects, header filter fields (+ their labels), summaries
    foreach (var s in new[] { det, gh, Sec(rcd, "GroupFooterSection1"), rf })
      RemoveObjects(objCtl, s, o => true);
    var oldLabels = new HashSet<string> { "Text17", "Text1", "Text2", "Text12", "Text13" }; // Zone/Shade/Retailer/Cus/Product
    RemoveObjects(objCtl, Sec(rcd, "Section2"), o => o is RD.FieldObject || oldLabels.Contains(o.Name));
    var sums = new List<object>();
    foreach (object sf in rcd.DataDefinition.SummaryFields) sums.Add(sf);
    foreach (var sf in sums) rcd.DataDefController.SummaryFieldController.Remove(sf);

    // Swap the data source: add the procedure's column layout, regroup on it, remove the old table
    string oldAlias = ((DD.ISCRTable)rcd.Database.Tables[0]).Alias;
    var ds = new DataSet();
    ds.Tables.Add(schema);
    rcd.DatabaseController.AddDataSource(CrystalDecisions.ReportAppServer.DataSetConversion.DataSetConverter.Convert(ds));
    tbl = schema.TableName;

    var g = (DD.Group)rcd.DataDefinition.Groups[0];
    var ng = (DD.Group)g.Clone(true);
    ng.ConditionField = (DD.Field)FindField(rcd, groupCol);
    rcd.DataDefController.GroupController.Modify(g, ng);
    rcd.DatabaseController.RemoveTable(oldAlias);
    g = (DD.Group)rcd.DataDefinition.Groups[0];

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
    foreach (string secName in new[] { "GroupFooterSection1", "Section4" })
      RemoveObjects(objCtl, Sec(rcd, secName), o => true);
    ph = Sec(rcd, "Section2"); gh = Sec(rcd, "GroupHeaderSection1"); det = Sec(rcd, "Section3"); rf = Sec(rcd, "Section4");

    // Header: Unit value next to the existing "Unit:" label
    var unit = (RD.FieldObject)unitTpl.Clone(true);
    unit.Name = "UnitValue"; unit.DataSourceName = Fld("Unit");
    objCtl.Add(unit, ph, -1);

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
