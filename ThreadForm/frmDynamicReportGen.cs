using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KDS_Thread.ThreadForm
{
    /// <summary>
    /// Server-driven report generator.
    ///  - ReportMaster      : which reports exist, their .rpt path and the SP / SQL that feeds them.
    ///  - ReportParameters  : which inputs each report needs and how to render them (UIType).
    /// Adding a new report = insert rows in those two tables + drop the .rpt in \Report. No code change.
    ///
    /// Supported UIType values (case-insensitive):
    ///   Date      -> DateTimePicker   (DefaultValue: day offset from server date, e.g. "0", "-7", or "MonthStart")
    ///   Combo     -> ComboBox         (LookupQuery: SELECT Id, Name ...  first column = value, second = text)
    ///   Unit      -> ComboBox         (built-in lookup on location_info with 'All' = 0)
    ///   Rep       -> ComboBox         (built-in: T_Get_RepresentativeDropdown, 'All' = 0, reloads when Unit changes)
    ///   Text      -> TextBox
    ///   Number    -> NumericUpDown
    ///   Check     -> CheckBox         (passes 1 / 0)
    ///   Hidden    -> no control       (always passes DefaultValue: "0" -> int 0, "" -> empty string)
    /// </summary>
    public partial class frmDynamicReportGen : Form
    {
        private readonly clsCommonFunctions dbConCrUser = new clsCommonFunctions();

        private const string UnitLookupSql =
            "SELECT 0 AS Id, 'All' AS Loc_Name UNION ALL SELECT Id, Loc_Name FROM dbo.location_info";

        private DateTime serverDate = DateTime.Today;
        private bool loadingReports;
        private int paramRowCount;

        // Parameter definitions + the control created for each one, for the selected report
        private readonly List<ReportParamDef> currentParams = new List<ReportParamDef>();

        private class ReportParamDef
        {
            public string ParameterName;   // e.g. @FromDate
            public string UIType;
            public string DisplayLabel;
            public string LookupQuery;
            public string DefaultValue;
            public Control InputControl;
        }

        public frmDynamicReportGen()
        {
            InitializeComponent();
        }

        private void frmDynamicReportGen_Load(object sender, EventArgs e)
        {
            try
            {
                try { serverDate = dbConCrUser.GetServerCurrentDateTime().Date; }
                catch { serverDate = DateTime.Today; }
                if (serverDate == DateTime.MinValue) serverDate = DateTime.Today;

                loadingReports = true;
                DataTable dtReports = dbConCrUser.ExecuteDataTable(
                    "SELECT ReportId, ReportName FROM dbo.ReportMaster WHERE IsActive = 1 ORDER BY ReportName",
                    CommandType.Text);

                DataRow blank = dtReports.NewRow();
                blank["ReportId"] = 0;
                blank["ReportName"] = "-- Select Report --";
                dtReports.Rows.InsertAt(blank, 0);

                cmbReportList.DataSource = dtReports;
                cmbReportList.ValueMember = "ReportId";
                cmbReportList.DisplayMember = "ReportName";
                cmbReportList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingReports = false;
            }
        }

        private int SelectedReportId
        {
            get
            {
                if (cmbReportList.SelectedValue == null) return 0;
                int id;
                return int.TryParse(cmbReportList.SelectedValue.ToString(), out id) ? id : 0;
            }
        }

        private void cmbReportList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingReports) return;
            BuildParameterControls(SelectedReportId);
        }

        // ------------------------------------------------------------------
        // Dynamic parameter UI
        // ------------------------------------------------------------------
        private void BuildParameterControls(int reportId)
        {
            pnlParams.SuspendLayout();
            try
            {
                var old = new Control[pnlParams.Controls.Count];
                pnlParams.Controls.CopyTo(old, 0);
                pnlParams.Controls.Clear();
                foreach (Control c in old) c.Dispose();
                pnlParams.RowStyles.Clear();
                pnlParams.RowCount = 1; // TableLayoutPanel does not allow 0
                paramRowCount = 0;
                currentParams.Clear();

                if (reportId <= 0) return;

                DataTable dtParams = dbConCrUser.ExecuteDataTable(
                    "SELECT * FROM dbo.ReportParameters WHERE ReportId = @ReportId AND IsActive = 1",
                    CommandType.Text,
                    new[] { new SqlParameter("@ReportId", reportId) });

                // Optional columns – the form works with or without them
                bool hasLabel = dtParams.Columns.Contains("DisplayLabel");
                bool hasLookup = dtParams.Columns.Contains("LookupQuery");
                bool hasDefault = dtParams.Columns.Contains("DefaultValue");
                bool hasSort = dtParams.Columns.Contains("SortOrder");

                DataView view = dtParams.DefaultView;
                view.Sort = hasSort ? "SortOrder ASC, ParamId ASC" : "ParamId ASC";

                foreach (DataRowView r in view)
                {
                    var def = new ReportParamDef
                    {
                        ParameterName = NormalizeParamName(Convert.ToString(r["ParameterName"])),
                        UIType = Convert.ToString(r["UIType"]).Trim(),
                        DisplayLabel = hasLabel ? Convert.ToString(r["DisplayLabel"]) : "",
                        LookupQuery = hasLookup ? Convert.ToString(r["LookupQuery"]) : "",
                        DefaultValue = hasDefault ? Convert.ToString(r["DefaultValue"]) : ""
                    };
                    if (string.IsNullOrWhiteSpace(def.DisplayLabel))
                        def.DisplayLabel = def.ParameterName.TrimStart('@');

                    if (IsHiddenType(def))
                    {
                        // No control on screen – value always comes from DefaultValue
                        def.InputControl = null;
                    }
                    else
                    {
                        def.InputControl = CreateInputControl(def);
                        AddParamRow(def);
                    }
                    currentParams.Add(def);
                }

                WireRepresentativeDropdowns();

                if (!currentParams.Exists(p => p.InputControl != null))
                {
                    var lbl = new Label
                    {
                        Text = "This report has no parameters.",
                        AutoSize = true,
                        Font = ParamFont,
                        ForeColor = Color.DimGray,
                        Margin = new Padding(3, 8, 3, 3)
                    };
                    pnlParams.RowCount = 1;
                    if (pnlParams.RowStyles.Count == 0)
                        pnlParams.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    pnlParams.Controls.Add(lbl, 0, 0);
                    pnlParams.SetColumnSpan(lbl, 4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report parameters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pnlParams.ResumeLayout(true);
            }
        }

        // Same look as frmRpt_RepScheduleBalance
        private static readonly Font ParamFont = new Font("Segoe UI", 9F, FontStyle.Bold);

        // Two label/control pairs per row: [label][control]   [label][control]
        private void AddParamRow(ReportParamDef def)
        {
            int index = paramRowCount++;
            int row = index / 2;
            int col = (index % 2) * 2;

            if (row + 1 > pnlParams.RowStyles.Count)
                pnlParams.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pnlParams.RowCount = Math.Max(1, row + 1);

            var lbl = new Label
            {
                Text = def.DisplayLabel.Trim() + " :",
                AutoSize = true,
                Font = ParamFont,
                ForeColor = SystemColors.ControlText,
                Anchor = AnchorStyles.Right,
                Margin = new Padding(2, 8, 4, 8)
            };

            Control c = def.InputControl;
            c.Font = ParamFont;
            c.Anchor = AnchorStyles.Left;
            c.Margin = new Padding(2, 5, 2, 5);
            if (!(c is CheckBox))
            {
                c.BackColor = Color.GhostWhite;
                c.Width = 200;
            }
            var cmb = c as ComboBox;
            if (cmb != null) cmb.FlatStyle = FlatStyle.Popup;

            pnlParams.Controls.Add(lbl, col, row);
            pnlParams.Controls.Add(c, col + 1, row);
        }

        private Control CreateInputControl(ReportParamDef def)
        {
            switch (def.UIType.ToLowerInvariant())
            {
                case "date":
                case "datetime":
                    {
                        var dtp = new DateTimePicker
                        {
                            Format = DateTimePickerFormat.Custom,
                            CustomFormat = "dd-MMM-yyyy",
                            Width = 200,
                            Value = ResolveDefaultDate(def.DefaultValue)
                        };
                        return dtp;
                    }

                case "unit":
                case "combo":
                case "dropdown":
                    {
                        var cmb = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Width = 320
                        };
                        string sql = def.UIType.Equals("unit", StringComparison.OrdinalIgnoreCase) && string.IsNullOrWhiteSpace(def.LookupQuery)
                            ? UnitLookupSql
                            : def.LookupQuery;

                        if (!string.IsNullOrWhiteSpace(sql))
                        {
                            DataTable dt = dbConCrUser.ExecuteDataTable(sql, CommandType.Text);
                            if (dt.Columns.Count > 0)
                            {
                                cmb.DataSource = dt;
                                cmb.ValueMember = dt.Columns[0].ColumnName;
                                cmb.DisplayMember = dt.Columns[dt.Columns.Count > 1 ? 1 : 0].ColumnName;
                                // Must be shown in the form before SelectedValue sticks
                                cmb.HandleCreated += delegate { ApplyComboDefault(cmb, def.DefaultValue); };
                            }
                        }
                        return cmb;
                    }

                case "rep":
                case "representative":
                    {
                        // Filled (and re-filled on Unit change) by WireRepresentativeDropdowns
                        return new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Width = 320
                        };
                    }

                case "number":
                case "int":
                case "decimal":
                    {
                        var num = new NumericUpDown
                        {
                            Width = 120,
                            Minimum = decimal.MinValue,
                            Maximum = decimal.MaxValue,
                            DecimalPlaces = def.UIType.Equals("decimal", StringComparison.OrdinalIgnoreCase) ? 2 : 0
                        };
                        decimal d;
                        if (decimal.TryParse(def.DefaultValue, out d)) num.Value = d;
                        return num;
                    }

                case "check":
                case "checkbox":
                case "bool":
                    {
                        var chk = new CheckBox { AutoSize = true, Text = "" };
                        string dv = (def.DefaultValue ?? "").Trim();
                        chk.Checked = dv == "1" || dv.Equals("true", StringComparison.OrdinalIgnoreCase);
                        return chk;
                    }

                default: // "text" and anything unknown
                    return new TextBox { Width = 320, Text = def.DefaultValue ?? "" };
            }
        }

        private static bool IsHiddenType(ReportParamDef d)
        {
            return d.UIType.Equals("hidden", StringComparison.OrdinalIgnoreCase);
        }

        // Hidden value: whole number -> int, anything else (including '') -> string
        private static object GetHiddenValue(string defaultValue)
        {
            string dv = defaultValue ?? "";
            int i;
            if (int.TryParse(dv.Trim(), out i)) return i;
            return dv;
        }

        private static bool IsRepType(ReportParamDef d)
        {
            return d.UIType.Equals("rep", StringComparison.OrdinalIgnoreCase)
                || d.UIType.Equals("representative", StringComparison.OrdinalIgnoreCase);
        }

        // Representative list depends on Unit: load it now and reload whenever the Unit dropdown changes.
        private void WireRepresentativeDropdowns()
        {
            List<ReportParamDef> repDefs = currentParams.FindAll(IsRepType);
            if (repDefs.Count == 0) return;

            ReportParamDef unitDef = currentParams.Find(d =>
                d.InputControl is ComboBox &&
                (d.UIType.Equals("unit", StringComparison.OrdinalIgnoreCase) ||
                 d.ParameterName.Equals("@Unit", StringComparison.OrdinalIgnoreCase)));
            ComboBox unitCombo = unitDef == null ? null : (ComboBox)unitDef.InputControl;

            Action reload = delegate
            {
                int unit = 0;
                if (unitCombo != null && unitCombo.SelectedValue != null)
                    int.TryParse(unitCombo.SelectedValue.ToString(), out unit);
                foreach (ReportParamDef rd in repDefs)
                    LoadRepresentativeCombo((ComboBox)rd.InputControl, unit, rd.DefaultValue);
            };

            reload();
            if (unitCombo != null)
                unitCombo.SelectedIndexChanged += delegate { reload(); };
        }

        private void LoadRepresentativeCombo(ComboBox cmb, int unit, string defaultValue)
        {
            // Same source as frmRpt_RepScheduleBalance; "All" unit falls back to the user's own location
            int repUnit = unit;
            if (repUnit <= 0) int.TryParse(frmLogin.UserLocation, out repUnit);

            object previous = cmb.SelectedValue;

            DataTable dt = dbConCrUser.ExecuteDataTable(
                "EXEC dbo.T_Get_RepresentativeDropdown @p0",
                CommandType.Text,
                new[] { new SqlParameter("@p0", repUnit.ToString()) });

            var list = new DataTable();
            list.Columns.Add("Id", typeof(int));
            list.Columns.Add("Name", typeof(string));
            list.Rows.Add(0, "All");
            string idCol = dt.Columns.Contains("id") ? "id" : (dt.Columns.Count > 0 ? dt.Columns[0].ColumnName : null);
            string nameCol = dt.Columns.Contains("name_value") ? "name_value" : (dt.Columns.Count > 1 ? dt.Columns[1].ColumnName : idCol);
            if (idCol != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    int id;
                    if (int.TryParse(Convert.ToString(r[idCol]), out id) && id != 0)
                        list.Rows.Add(id, Convert.ToString(r[nameCol]));
                }
            }

            cmb.DataSource = list;
            cmb.ValueMember = "Id";
            cmb.DisplayMember = "Name";

            // keep previous choice if still in the list, else default, else "All"
            string keep = previous != null ? previous.ToString() : defaultValue;
            ApplyComboDefault(cmb, keep);
        }

        private void ApplyComboDefault(ComboBox cmb, string defaultValue)
        {
            if (cmb.Items.Count == 0) return;
            if (!string.IsNullOrWhiteSpace(defaultValue))
            {
                try
                {
                    cmb.SelectedValue = defaultValue.Trim();
                    if (cmb.SelectedIndex >= 0) return;
                }
                catch { }
            }
            cmb.SelectedIndex = 0;
        }

        private DateTime ResolveDefaultDate(string defaultValue)
        {
            string dv = (defaultValue ?? "").Trim();
            if (dv.Equals("MonthStart", StringComparison.OrdinalIgnoreCase))
                return new DateTime(serverDate.Year, serverDate.Month, 1);
            if (dv.Equals("MonthEnd", StringComparison.OrdinalIgnoreCase))
                return new DateTime(serverDate.Year, serverDate.Month, 1).AddMonths(1).AddDays(-1);

            int offset;
            if (int.TryParse(dv, out offset)) return serverDate.AddDays(offset);
            return serverDate;
        }

        private static string NormalizeParamName(string name)
        {
            name = (name ?? "").Trim();
            return name.StartsWith("@") ? name : "@" + name;
        }

        private object GetParamValue(ReportParamDef def)
        {
            Control c = def.InputControl;
            if (c == null) return GetHiddenValue(def.DefaultValue);

            var dtp = c as DateTimePicker;
            if (dtp != null) return dtp.Value.Date;

            var cmb = c as ComboBox;
            if (cmb != null)
                return cmb.SelectedValue ?? (object)DBNull.Value;

            var num = c as NumericUpDown;
            if (num != null)
                return num.DecimalPlaces == 0 ? (object)Convert.ToInt32(num.Value) : num.Value;

            var chk = c as CheckBox;
            if (chk != null) return chk.Checked ? 1 : 0;

            string txt = c.Text.Trim();
            return txt.Length == 0 ? (object)DBNull.Value : txt;
        }

        // ------------------------------------------------------------------
        // Preview
        // ------------------------------------------------------------------
        private void btnPreview_Click(object sender, EventArgs e)
        {
            int reportId = SelectedReportId;
            if (reportId <= 0)
            {
                MessageBox.Show("Please select a report first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbReportList.Focus();
                return;
            }

            // Basic validation: From Date must not be after To Date
            ReportParamDef fromDef = currentParams.Find(p => p.ParameterName.Equals("@FromDate", StringComparison.OrdinalIgnoreCase));
            ReportParamDef toDef = currentParams.Find(p => p.ParameterName.Equals("@ToDate", StringComparison.OrdinalIgnoreCase));
            if (fromDef != null && toDef != null &&
                fromDef.InputControl is DateTimePicker && toDef.InputControl is DateTimePicker &&
                ((DateTimePicker)fromDef.InputControl).Value.Date > ((DateTimePicker)toDef.InputControl).Value.Date)
            {
                MessageBox.Show("From Date cannot be greater than To Date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GenerateDynamicReport(reportId);
        }

        private void GenerateDynamicReport(int reportId)
        {
            frmLoader load = new frmLoader();
            ReportDocument cryReport = null;
            bool shown = false;

            try
            {
                Cursor = Cursors.WaitCursor;
                btnPreview.Enabled = false;
                load.Show();
                load.TopMost = true;
                Application.DoEvents();

                // 1. Report metadata
                DataTable dtMeta = dbConCrUser.ExecuteDataTable(
                    "SELECT ReportName, ReportPath, QueryType, QueryString FROM dbo.ReportMaster WHERE ReportId = @ReportId AND IsActive = 1",
                    CommandType.Text,
                    new[] { new SqlParameter("@ReportId", reportId) });

                if (dtMeta.Rows.Count == 0)
                {
                    load.Close();
                    MessageBox.Show("Report configuration not found or inactive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow meta = dtMeta.Rows[0];
                string reportName = Convert.ToString(meta["ReportName"]);
                string reportPath = Convert.ToString(meta["ReportPath"]).Trim();
                string queryType = Convert.ToString(meta["QueryType"]).Trim();
                string queryString = Convert.ToString(meta["QueryString"]).Trim();

                // "\Report\x.rpt" -> relative to the exe; "C:\..." or "\\server\..." -> used as-is
                bool absolute = reportPath.StartsWith(@"\\") || (reportPath.Length > 1 && reportPath[1] == ':');
                string fullPath = absolute
                    ? reportPath
                    : Path.Combine(Application.StartupPath, reportPath.TrimStart('\\', '/'));

                if (!File.Exists(fullPath))
                {
                    load.Close();
                    MessageBox.Show("Report file not found:\n" + fullPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(queryString))
                {
                    load.Close();
                    MessageBox.Show("No query / stored procedure configured for this report.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Collect values from the dynamic controls
                var values = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
                var sqlParams = new List<SqlParameter>();
                foreach (ReportParamDef def in currentParams)
                {
                    object val = GetParamValue(def);
                    values[def.ParameterName] = val;
                    sqlParams.Add(new SqlParameter(def.ParameterName, val ?? DBNull.Value));
                }

                // 3. Fetch data on the server
                CommandType cmdType = queryType.Equals("StoredProcedure", StringComparison.OrdinalIgnoreCase)
                    ? CommandType.StoredProcedure
                    : CommandType.Text;

                // SP parameters not configured in ReportParameters get a safe default
                if (cmdType == CommandType.StoredProcedure)
                    AddMissingProcedureParameters(queryString, values, sqlParams);
                DataTable dtReportData = dbConCrUser.ExecuteDataTable(queryString, cmdType, sqlParams);

                if (dtReportData.Rows.Count == 0)
                {
                    load.Close();
                    MessageBox.Show("There is no data available to show for this report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Load .rpt and bind
                cryReport = new ReportDocument();
                cryReport.Load(fullPath);
                cryReport.SetDataSource(dtReportData);
                dbConCrUser.SetReportLogon(cryReport);

                // 5. Pass values to Crystal parameter fields that exist in the .rpt
                //    (matches both "@FromDate" and "FromDate" naming in the report)
                foreach (ParameterFieldDefinition pf in cryReport.DataDefinition.ParameterFields)
                {
                    if (!string.IsNullOrEmpty(pf.ReportName)) continue; // sub-report parameter
                    object val;
                    if (values.TryGetValue(NormalizeParamName(pf.Name), out val))
                        cryReport.SetParameterValue(pf.Name, val == DBNull.Value ? null : val);
                }

                // 6. Show the viewer
                frmReportLoader rptForm = new frmReportLoader();
                ReportDocument docToDispose = cryReport;
                rptForm.FormClosed += delegate
                {
                    try { docToDispose.Close(); docToDispose.Dispose(); } catch { }
                };
                rptForm.crViewer.ReportSource = cryReport;
                rptForm.Text = reportName;
                rptForm.crViewer.DisplayGroupTree = false;
                rptForm.UseWaitCursor = false;
                rptForm.crViewer.Refresh();
                load.Close();
                rptForm.Show();
                shown = true;
            }
            catch (Exception ex)
            {
                if (!load.IsDisposed) load.Close();
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!shown && cryReport != null)
                {
                    try { cryReport.Close(); cryReport.Dispose(); } catch { }
                }
                if (!load.IsDisposed) load.Close();
                btnPreview.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Reads the stored procedure's input parameters from SQL Server and adds any that the
        /// screen did not supply: numbers/bit -> 0, text -> '', dates -> server date, others -> NULL.
        /// </summary>
        private void AddMissingProcedureParameters(string procName, Dictionary<string, object> values, List<SqlParameter> sqlParams)
        {
            DataTable dtSpParams = dbConCrUser.ExecuteDataTable(
                @"SELECT p.name AS ParamName, TYPE_NAME(p.user_type_id) AS TypeName
                  FROM sys.parameters p
                  WHERE p.object_id = OBJECT_ID(@ProcName) AND p.is_output = 0 AND p.name <> ''
                  ORDER BY p.parameter_id",
                CommandType.Text,
                new[] { new SqlParameter("@ProcName", procName) });

            foreach (DataRow r in dtSpParams.Rows)
            {
                string name = NormalizeParamName(Convert.ToString(r["ParamName"]));
                if (values.ContainsKey(name)) continue;

                object val;
                switch (Convert.ToString(r["TypeName"]).ToLowerInvariant())
                {
                    case "int": case "bigint": case "smallint": case "tinyint": case "bit":
                        val = 0; break;
                    case "decimal": case "numeric": case "money": case "smallmoney": case "float": case "real":
                        val = 0m; break;
                    case "char": case "varchar": case "nchar": case "nvarchar": case "text": case "ntext":
                        val = ""; break;
                    case "date": case "datetime": case "datetime2": case "smalldatetime": case "datetimeoffset":
                        val = serverDate; break;
                    default:
                        val = DBNull.Value; break;
                }

                values[name] = val;
                sqlParams.Add(new SqlParameter(name, val));
            }
        }

        // Reset all parameter inputs of the selected report to their defaults
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BuildParameterControls(SelectedReportId);
        }
    }
}
