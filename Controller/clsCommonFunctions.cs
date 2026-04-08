using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using KDSFramWork;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Linq;
using System.IO;

namespace KDS_Thread
{
    class clsCommonFunctions : clsDBConnection
    {
        private ConnectionInfo rptConnection = new ConnectionInfo();
       
        public ToolTip tTip;
        public ErrorProvider errPvdr = new ErrorProvider();
        public DateTime ServerCurrentDateTime;
        public DateTime MaxDateTime;
        //public string DBPrefix = "PMSPOLY_TEST.dbo.";
        //public string DBPrefix = "ProductionCube.dbo.";
        public string DBPrefix = "KdsThreadPMS.dbo.";
        

        public SqlCommand sqlCmd;
        public SqlDataReader sqlDtRdr;

        public void SetReportLogon(ReportDocument rptDoc)
        {
            rptConnection.ServerName = DBHostConnected;
            rptConnection.DatabaseName = DBName;
            rptConnection.UserID = DBUserId;
            rptConnection.Password = DBPassword;

            foreach (ReportDocument subRpt in rptDoc.Subreports)
            {
                foreach (Table crTable in subRpt.Database.Tables)
                {
                    TableLogOnInfo logInfo = crTable.LogOnInfo;
                    logInfo.ConnectionInfo = rptConnection;
                    crTable.ApplyLogOnInfo(logInfo);
                }
            }

            foreach (Table crTable in rptDoc.Database.Tables)
            {
                TableLogOnInfo loi = crTable.LogOnInfo;
                loi.ConnectionInfo = rptConnection;
                crTable.ApplyLogOnInfo(loi);
            }
        }

        public string SingleQuoteHandler(TextBox txt)
        {
            return txt.Text.Trim().Replace("'", "''");
        }

        public bool CheckEmptyOrNull(Control ctrl, string msg)
        {
            if (string.IsNullOrEmpty(ctrl.Text.Trim()))
            {
                errPvdr.SetError(ctrl, msg);
                ctrl.BackColor = Color.Red;
                tTip = new ToolTip();
                tTip.Show(msg, ctrl, 3000);
                ctrl.Focus();
                return true;
            }

            return false;
        }

        public void DisposeChecking(Control ctrl)
        {
            errPvdr.Dispose();            
            ctrl.BackColor = Color.White;
            //tTip.Dispose();
        }

        public bool IsFormOpen(Form frm)
        {
            foreach (Form form in Application.OpenForms)
                if (form.Name == frm.Name)
                    return true;
            return false;
        }

        public void MakeTextUppercase(TextBox txt)
        {
            int start = txt.SelectionStart;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = start;        
        }

        public DateTime GetServerCurrentDateTime()
        {
            SqlDataReader dtRdr;
            dtRdr = DBRetrieveFunction("EXEC prcPL_GetServerDateTime");
            if (dtRdr.Read())
            {
                ServerCurrentDateTime = Convert.ToDateTime(dtRdr["DateTime"].ToString()); 
            }
            dtRdr.Close();
            return ServerCurrentDateTime;
        }        

        public void SelectionTextString(TextBox txt)
        {
            txt.SelectionStart = 0;
            txt.SelectionLength = txt.ToString().Length;
        }

        public void DecimalNumbers(TextBox txt, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                int dotIndex = txt.Text.IndexOf('.');
                if (char.IsDigit(e.KeyChar))
                {
                    if (dotIndex != -1 && dotIndex < txt.SelectionStart && txt.Text.Substring(dotIndex + 1).Length >= 2)
                    {
                        e.Handled = true;
                    }
                }
                else
                    e.Handled = e.KeyChar != '.' ||
                                dotIndex != -1 ||
                                txt.Text.Length == 0 ||
                                txt.SelectionStart + 2 < txt.Text.Length;
            }
        }

        public void FillComboBox(ComboBox cmb, string sql)
        {
            SqlDataReader cmbDtRdr;
            cmbDtRdr = DBRetrieveFunction(sql);

            DataTable cmbDtTbl = new DataTable();
            cmbDtTbl.Load(cmbDtRdr);

            cmb.DataSource = cmbDtTbl;
            cmb.ValueMember = cmbDtTbl.Columns[0].ToString();
            cmb.DisplayMember = cmbDtTbl.Columns[1].ToString();
            //cmb.Invalidate();
            cmbDtRdr.Close();
        }
        public void FillComboBox_SingleColumn(ComboBox cmb, string sql)
        {
            SqlDataReader cmbDtRdr;
            cmbDtRdr = DBRetrieveFunction(sql);

            DataTable cmbDtTbl = new DataTable();
            cmbDtTbl.Load(cmbDtRdr);

            cmb.DataSource = cmbDtTbl;
            cmb.ValueMember = cmbDtTbl.Columns[0].ToString();
            cmb.DisplayMember = cmbDtTbl.Columns[0].ToString();
            //cmb.Invalidate();
            cmbDtRdr.Close();
        }

        public DataTable FillComboBrowser(CmbBrowser cmb, string sql)
        {
            SqlDataReader cmbDtRdr;
            cmbDtRdr = DBRetrieveFunction(sql);

            DataTable cmbDtTbl = new DataTable();
            cmbDtTbl.Load(cmbDtRdr);

            cmb.DataSource = cmbDtTbl;
            
            //cmb.Textvalue = cmbDtTbl.Columns[0].ToString();
            //cmb.Text = cmbDtTbl.Columns[1].ToString();
            //cmb.Invalidate();
            cmbDtRdr.Close();

            return cmbDtTbl;
        }

        public void ClearAll(Form frm)
        {
 
        }

        public bool DBInsertUsingSP(string procedureName, string[] paramName, string[] paramValue)
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand(procedureName, DBCon);
                insertCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = null;

                for (int i = 0; i < paramName.Count(); i++)
                {
                    param = insertCmd.Parameters.AddWithValue(paramName[i], paramValue[i]);
                }

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool DBInsertUsingSP(string procedureName, string[] paramName, string[] paramValue, string dtTblParam, DataTable dtTbl)
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand(procedureName, DBCon);
                insertCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = null;

                for (int i = 0; i <= paramName.Count(); i++)
                {
                    if (i == paramName.Count())
                        param = insertCmd.Parameters.AddWithValue(dtTblParam, dtTbl);
                    else
                        param = insertCmd.Parameters.AddWithValue(paramName[i], paramValue[i]);
                }

                insertCmd.ExecuteNonQuery();                
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message, "DB Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return false; 
            }

            return true;
        }

        public bool DBInsertUsingSP(string procedureName, string dtTblParam, DataTable dtTbl)
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand(procedureName, DBCon);
                insertCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = null;

               param = insertCmd.Parameters.AddWithValue(dtTblParam, dtTbl);
               
               insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public SqlDataReader DBInsertUsingSPBOM(string procedureName, string[] paramName, string[] paramValue, string dtTblParam, DataTable dtTbl)
        {
            SqlDataReader dr = null;

            try
            {
                SqlCommand insertCmd = new SqlCommand(procedureName, DBCon);
                insertCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = null;

                for (int i = 0; i <= paramName.Count(); i++)
                {
                    if (i == paramName.Count())
                        param = insertCmd.Parameters.AddWithValue(dtTblParam, dtTbl);
                    else
                        param = insertCmd.Parameters.AddWithValue(paramName[i], paramValue[i]);
                }

                dr = insertCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

            return dr;
        }

        public DataTable GetContentAsDataTable(DataGridView dgv)
        {
            try
            {
                var dt = new DataTable();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    dt.Columns.Add();
                }

                object[] cellValues = new object[dgv.Columns.Count];
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        cellValues[i] = row.Cells[i].Value;
                    }
                    dt.Rows.Add(cellValues);
                }

                return dt;
            }
            catch { return null; }
        }

        public DataTable GetContentAsDataTable(DataGridView dgv, string[] columns)
        {
            try
            {
                var dt = new DataTable();

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (IsColMatched(dgv.Columns[i].Name, columns))
                    {
                        dt.Columns.Add();
                    }
                }

                object[] cellValues = new object[dt.Columns.Count];
                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if (Convert.ToBoolean(dr.Cells["chkBox"].Value) == true)
                    {
                        for (int i = 0, j = 0; i < dr.Cells.Count; i++)
                        { 
                            if (j < dt.Columns.Count)
                            {
                                if (dgv.Columns[i].Name == columns[j])
                                {
                                    if (dr.Cells[i].Value.GetType() == typeof(string) || dr.Cells[i].Value.GetType() == typeof(DateTime) ||
                                        dr.Cells[i].Value.GetType() == typeof(int) || dr.Cells[i].Value.GetType() == typeof(double))
                                    {
                                        int num; double dbl;
                                        if (int.TryParse(dr.Cells[i].Value.ToString(), out num))
                                        {
                                            cellValues[j] = (dr.Cells[i].Value == null) ? 0 : Convert.ToInt32(dr.Cells[i].Value);
                                            j++;
                                        }
                                        else if (double.TryParse(dr.Cells[i].Value.ToString(), out dbl))
                                        {
                                            cellValues[j] = (dr.Cells[i].Value == null) ? 0 : Convert.ToDouble(dr.Cells[i].Value);
                                            j++;
                                        }
                                        else
                                        {
                                            cellValues[j] = (dr.Cells[i].Value == null) ? "" : dr.Cells[i].Value;
                                            j++;
                                        }
                                    }
                                }
                            }                            
                        }

                        dt.Rows.Add(cellValues);
                    }                    
                }

                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        private bool IsColMatched(string dgvCol, string[] col)
        {
            for (int i = 0; i < col.Count(); i++)
            {
                if (col[i] == dgvCol && col[i] != "chkBox")
                    return true;
            }
            
            return false;
        }

        public object DBCRUDFunction(string sql, bool isRetrieval)
        {
            if (DBCon.State.Equals(ConnectionState.Open))
                DBCon.Close();

            try
            {
                DBCon.Open();
                sqlCmd = new SqlCommand(sql, DBCon);
                if (isRetrieval)
                {
                    sqlDtRdr = sqlCmd.ExecuteReader();
                    return sqlDtRdr;
                }
                else
                {
                    sqlCmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "DB CRUD FUNCTION ERROR");
                return false;
            }
        }

        public void FillDataGridView(DataGridView dgv, string sql)
        {
            SqlDataReader dgvDtRdr;
            dgvDtRdr = DBRetrieveFunction(sql);

            DataTable dgbDtTbl = new DataTable();
            dgbDtTbl.Load(dgvDtRdr);

            dgv.DataSource = dgbDtTbl;
            dgvDtRdr.Close();
           
        }
       

        public void SentEmail(string frmEmail, string toEmail, string emailSubject, string emailBody, string ccEmail, string bccEmail)
        {
            //string sql = "";

            try
            {
                SmtpClient SMTPServer = new SmtpClient();
                MailMessage Mail = new MailMessage();
                SMTPServer.Credentials = new NetworkCredential("amithchowdhury@kdsgroup.net", "amith123");
                SMTPServer.Port = 25;
                SMTPServer.Host = "203.82.207.6";
                Mail.From = new MailAddress(frmEmail);
                Mail.To.Add(toEmail);
                if (!string.IsNullOrEmpty(ccEmail))
                {
                    Mail.CC.Add(ccEmail);
                }
                if (!string.IsNullOrEmpty(bccEmail))
                {
                    Mail.Bcc.Add(bccEmail);
                }
                Mail.Subject = emailSubject;
                Mail.IsBodyHtml = true;
                Mail.Body = emailBody;
                Mail.Priority = MailPriority.Normal;
                SMTPServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SMTPServer.Send(Mail);

//                sql = @"INSERT INTO NSDMailQ (FrmMail,ToMail,CCMail,BCCMail,Subject,Body,SentTime,Status) 
//                        VALUES('" + frmEmail + "','" + toEmail + "','" + ccEmail + "','" + bccEmail
//                        + "','" + emailSubject + "','" + AddSlashes(emailBody) + "','" + DateTime.Today + " "
//                        + DateTime.Now + "',1)";

//                DBInsertUpdateDeleteFunctin(sql);
            }
            catch (Exception ex)
            {
//                sql = @sql = @"INSERT INTO NSDMailQ (FrmMail,ToMail,CCMail,BCCMail,Subject,Body,SentTime,Status) 
//                            VALUES('" + frmEmail + "','" + toEmail + "','" + ccEmail + "','" + bccEmail
//                            + "','" + emailSubject + "','" + AddSlashes(emailBody) + "','" + DateTime.Today + " "
//                            + DateTime.Now + "',0)";

//                DBInsertUpdateDeleteFunctin(sql);
                MessageBox.Show(ex.Message, "Mail Server Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string AddSlashes(string inputString)
        {
            string outputString = inputString;
            outputString = Regex.Replace(inputString, "[\\000\\010\\011\\012\\015\\032\\042\\047\\134\\140]", "$0$0");
            return outputString;
        }

        public string StripSlashes(string inputString)
        {
            string outputString = inputString;
            outputString = Regex.Replace(inputString, "(\\\\)([\\000\\010\\011\\012\\015\\032\\042\\047\\134\\140])", "$2");
            return outputString;
        }

        public bool checkNullorEmptyDGV(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (j != 0)
                    {
                        if (dgv.Rows[i].Cells[j].Value == null)
                            return true;
                    }
                }
            }

            return false;
        }

        public bool isAvail(DataGridView dgv, string item)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[1].Value.ToString() == item)
                    return true;
            }
            return false;
        }

        public bool InsertSentEmail(string frmEmail, string tEmail, string ccEmail, string bccEmail, string subject, 
            string body, string emailType, string projectName, string tempFileName, string eFormat, Stream attachmentStream)
        {
            if (attachmentStream == null)
            {
                string sql = @"INSERT INTO [EmailCube].[dbo].[EMailCollection] ([EmailType],[ModuleName],[EmailFrom],[EmailTo],[EmailCC],[EmailBCC] "
                               + "           ,[EmailSubject],[EmailBody],[EmailAttachmentLink],[HasAttachment],[CreateAttachment],[AllatchmentFileName] "
                               + "           ,[ReportName],[ParameterList],[ParameterValueList],[RelationType],[RelationId],[RelationSubId] "
                               + "           ,[EntryDate],[CreatedBy],[SendingStatus]) "
                               + "     VALUES "
                               + "           ('" + emailType + "' "
                               + "           ,'" + projectName + "' "
                               + "           ,'" + frmEmail + "' "
                               + "           ,'" + tEmail + "' "
                               + "           ,'" + ccEmail + "' "
                               + "           ,'" + bccEmail + "' "
                               + "           ,'" + subject + "' "
                               + "           ,'" + body + "' "
                               + "           ,'' "
                               + "           ,0 "
                               + "           ,0 "
                               + "           ,'" + tempFileName + "." + eFormat + "' "
                               + "           ,'' "
                               + "           ,'' "
                               + "           ,'' "
                               + "           ,'' "
                               + "           ,0 "
                               + "           ,0 "
                               + "           ,GETDATE() "
                               + "           ,1 "
                               + "           ,0 )";

                if (DBInsertUpdateDeleteFunction(sql))
                    return true;
            }
            else
            {
                string sql = "INSERT INTO [EmailCube].[dbo].[EMailCollection] ([EmailType],[ModuleName],[EmailFrom],[EmailTo],[EmailCC],[EmailBCC] "
                           + "           ,[EmailSubject],[EmailBody],[EmailAttachmentLink],[HasAttachment],[CreateAttachment],[AllatchmentFileName] "
                           + "           ,[Attachment],[ReportName],[ParameterList],[ParameterValueList],[RelationType],[RelationId],[RelationSubId] "
                           + "           ,[EntryDate],[CreatedBy],[SendingStatus]) "
                           + "     VALUES "
                           + "           ('" + emailType + "' "
                           + "           ,'" + projectName + "' "
                           + "           ,'" + frmEmail + "' "
                           + "           ,'" + tEmail + "' "
                           + "           ,'" + ccEmail + "' "
                           + "           ,'" + bccEmail + "' "
                           + "           ,'" + subject + "' "
                           + "           ,'" + body + "' "
                           + "           ,'' "
                           + "           ,1 "
                           + "           ,0 "
                           + "           ,'" + tempFileName + "." + eFormat + "' "
                           + "           ,@binaryValue"
                           + "           ,'' "
                           + "           ,'' "
                           + "           ,'' "
                           + "           ,'' "
                           + "           ,0 "
                           + "           ,0 "
                           + "           ,getdate() "
                           + "           ,1 "
                           + "           ,0 )";
                byte[] bytesInStream = new byte[attachmentStream.Length];
                attachmentStream.Read(bytesInStream, 0, (int)bytesInStream.Length);
                if (DBCon.State.Equals(ConnectionState.Open))
                    DBCon.Close();
                DBCon.Open();
                using (SqlCommand cmd = new SqlCommand(sql, DBCon))
                {
                    // Replace 8000, below, with the correct size of the field
                    cmd.Parameters.Add("@binaryValue", SqlDbType.VarBinary, 2000000).Value = bytesInStream;
                    cmd.ExecuteNonQuery();
                    return true;
                    //MessageBox.Show("sENT");
                    // MyLogEvent.WriteEntry("Successfully sent file " + tempFileName + " on " + DateTime.Now.ToString());                                
                }

                //if (DBInsertUpdateDeleteFunction(sql))
                //    return true;
            }

            return false;
        }

        public void LoadBookingBasicInfo(int BookingId, Label[] lbl)
        {
            SqlDataReader dtRdr;

            dtRdr = DBRetrieveFunction("EXEC " + DBPrefix + "prcLoadBookingBasicInfo " + BookingId);

            try
            {
                if (dtRdr.Read())
                {
                    lbl[0].Text = dtRdr["CustomerName"].ToString();
                    lbl[1].Text = Convert.ToDateTime(dtRdr["BookingDate"].ToString()).ToString("dd-MMM-yyyy hh:mm:ss tt");
                    lbl[2].Text = Regex.Replace(Regex.Replace(dtRdr["CustomerRef"].ToString(), @"\t|\n|\r", String.Empty), @"&", "&&");
                    lbl[3].Text = dtRdr["RepresentativeName"].ToString();
                    lbl[4].Text = dtRdr["Remarks"].ToString();
                    lbl[5].Text = Convert.ToDateTime(dtRdr["DeliveryDate1"].ToString()).ToString("dd-MMM-yyyy");
                    lbl[6].Text = Convert.ToDateTime(dtRdr["DeliveryDate2"].ToString()).ToString("dd-MMM-yyyy");
                    lbl[7].Text = dtRdr["RetailerName"].ToString();
                }
                else
                {
                    lbl[0].Text = "";
                    lbl[1].Text = "";
                    lbl[2].Text = "";
                    lbl[3].Text = "";
                    lbl[4].Text = "";
                    lbl[5].Text = "";
                    lbl[6].Text = "";
                    lbl[7].Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearLabels(Label[] lbl)
        {
            lbl[0].Text = "";
            lbl[1].Text = "";
            lbl[2].Text = "";
            lbl[3].Text = "";
            lbl[4].Text = "";
            lbl[5].Text = "";
            lbl[6].Text = "";
            lbl[7].Text = "";
        }

        public DateTime CreateDateFormat(string strDate)
        {
            DateTime dtMakeDate;

            dtMakeDate =Convert.ToDateTime(Convert.ToString(strDate.Substring(3, 2) + "-" + strDate.Substring(0, 2) + "-" + strDate.Substring(6, 2)));

            return dtMakeDate;
        }

        public string CreateSQLStatement(string table, string[] column, string[] values,
            string operation, string[] whCols, string[] whVals)
        {
            string SQL = "";
            string comma = "";

            if (operation == "INSERT")
            {
                SQL = operation + " INTO " + table + " (";

                for (int i = 0; i < column.Count(); i++)
                {
                    SQL = SQL + comma + column[i];
                    comma = ",";
                }

                SQL += ") VALUES (";

                comma = "";

                for (int j = 0; j < values.Count(); j++)
                {
                    if (IsNumeric(values[j]))
                    {
                        SQL += comma + values[j];
                    }
                    else
                    {
                        SQL += comma + "'" + values[j] + "'";
                    }

                    comma = ",";
                }

                SQL += ");";
            }
            else if (operation == "UPDATE")
            {
                SQL = operation + " " + table + " SET ";

                for (int i = 0; i < column.Count(); i++)
                {
                    if (IsNumeric(values[i]))
                    {
                        SQL = SQL + comma + column[i] + " = " + values[i];
                    }
                    else
                    {
                        SQL = SQL + comma + column[i] + " = '" + values[i] + "'";
                    }

                    comma = ",";
                }

                comma = " WHERE ";

                for (int i = 0; i < whCols.Count(); i++)
                {
                    if (IsNumeric(whVals[i]))
                    {
                        SQL = SQL + comma + whCols[i] + " = " + whVals[i];
                    }
                    else
                    {
                        SQL = SQL + comma + whCols[i] + " = '" + whVals[i] + "'";
                    }

                    comma = " AND ";
                }

                SQL += ";";
            }
            else if (operation == "DELETE")
            {
                SQL = operation + " " + table;
                comma = " WHERE ";
                for (int i = 0; i < whCols.Count(); i++)
                {
                    if (IsNumeric(whVals[i]))
                    {
                        SQL = SQL + comma + whCols[i] + " = " + whVals[i];
                    }
                    else
                    {
                        SQL = SQL + comma + whCols[i] + " = '" + whVals[i] + "'";
                    }

                    comma = " AND ";
                }

                SQL += ";";
            }

            return SQL;
        }

        public bool IsNumeric(object obj)
        {
            if (Equals(obj, null))
            {
                return false;
            }

            Type objType = obj.GetType();
            objType = Nullable.GetUnderlyingType(objType) ?? objType;

            if (objType.IsPrimitive)
            {
                return objType != typeof(bool) &&
                    objType != typeof(char) &&
                    objType != typeof(IntPtr) &&
                    objType != typeof(UIntPtr);
            }

            return objType == typeof(decimal);
        }

        //public void InstallUpdateSyncWithInfo()
        //{
        //    UpdateCheckInfo info = null;

        //    if (ApplicationDeployment.IsNetworkDeployed)
        //    {
        //        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

        //        try
        //        {
        //            info = ad.CheckForDetailedUpdate();
        //        }
        //        catch (DeploymentDownloadException dde)
        //        {
        //            MessageBox.Show(@"The new version of the application cannot be downloaded at this time. 
        //                        \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
        //            return;
        //        }
        //        catch (InvalidDeploymentException ide)
        //        {
        //            MessageBox.Show(@"Cannot check for a new version of the application. 
        //                The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
        //            return;
        //        }
        //        catch (InvalidOperationException ioe)
        //        {
        //            MessageBox.Show(@"This application cannot be updated. It is likely not a ClickOnce application. 
        //                                Error: " + ioe.Message);
        //            return;
        //        }

        //        if (info.UpdateAvailable)
        //        {
        //            Boolean doUpdate = true;

        //            if (!info.IsUpdateRequired)
        //            {
        //                DialogResult dr = MessageBox.Show(@"An update is available. 
        //                    Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
        //                if (!(DialogResult.OK == dr))
        //                {
        //                    doUpdate = false;
        //                }
        //            }
        //            else
        //            {
        //                // Display a message that the app MUST reboot. Display the minimum required version.
        //                MessageBox.Show("This application has detected a mandatory update from your current " +
        //                    "version to version " + info.MinimumRequiredVersion.ToString() +
        //                    ". The application will now install the update and restart.",
        //                    "Update Available", MessageBoxButtons.OK,
        //                    MessageBoxIcon.Information);
        //            }

        //            if (doUpdate)
        //            {
        //                try
        //                {
        //                    ad.Update();
        //                    MessageBox.Show("The application has been upgraded, and will now restart.");
        //                    Application.Restart();
        //                }
        //                catch (DeploymentDownloadException dde)
        //                {
        //                    MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //}

    }
}
