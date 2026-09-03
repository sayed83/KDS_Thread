using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections;
using Dapper;

namespace KDS_Thread
{


    class clsDBConnection
    {


        //Testing server

        //public static string TestDBHostLocal = "Alihasan-IT";
        //public static string TestDBName = "KDSThreadPMS";

        //public static string DBHost, DBName, DBUserId, DBPassword;
        //public static string ConnectionServer = "203.82.207.162";
        ////public static string ConnectionServer = "192.168.0.6";


        public static string DBHostLocal = "192.168.0.181";

        public static string DBHostReal = "203.82.207.170";
        //public static string DBHostLocal = "localhost";
        //public static string DBHostReal = "localhost";
        public static string DBHostConnected = "";

        public static string DBName = "KDSThreadPMS";
        public static string DBUserId = "sa";
        //public static string DBPassword = "sys";
        public static string DBPassword = "dbsrv170@sdk";


        public SqlConnection DBCon = new SqlConnection(getConnectionString());
        private SqlCommand sqlCmd;
        private SqlDataReader sqlDtRdr;

        //Real connection 


        // Private to public 
        private static string getConnectionString()
        {
            //WebClient wc = new WebClient();
            //string strValue, strAddress = "http://" + ConnectionServer + "/NSD/btn_pms.dat";
            string ConnectionString = "";
            //string[] arrValue = new string[3];

            try
            {
                //strValue = wc.DownloadString(strAddress);
                //wc.Dispose();
                //arrValue = strValue.Split(',');

                //DBHost = CryptorEngine.Decrypt(arrValue[0], true);
                //DBName = CryptorEngine.Decrypt(arrValue[1], true);
                //DBUserId = CryptorEngine.Decrypt(arrValue[2], true);
                //DBPassword = CryptorEngine.Decrypt(arrValue[3], true);

                //ConnectionString = @"Server=" + DBHost +
                //                           ";Database=" + DBName +
                //                           ";User ID=" + DBUserId +
                //                           ";Password=" + DBPassword + ";";

                if (PingHost(DBHostLocal))
                {
                    DBHostConnected = DBHostLocal;

                    return @"Server = " + DBHostLocal +
                            ";Database = " + DBName +
                            ";User Id = " + DBUserId +
                            ";Password = " + DBPassword + ";";
                }
                else if (PingHost(DBHostReal))
                {
                    DBHostConnected = DBHostReal;

                    return @"Server = " + DBHostReal +
                           ";Database = " + DBName +
                           ";User Id = " + DBUserId +
                           ";Password = " + DBPassword + ";";
                }
                else
                    return "Server is Unreachable [A Kind of Network Problem], Please try after some times.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Connecting Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ConnectionString;
        }


        // Local_connection

        //private static string getConnectionString()
        //{
        //    string ConnectionString = "";

        //    try
        //    {
        //        ConnectionString = @"Server=" + TestDBHostLocal +
        //                           ";Database=" + TestDBName +
        //                           ";Integrated Security=SSPI;";

        //        return ConnectionString;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error Connecting Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    return ConnectionString;
        //}



        public static bool PingHost(string nameOrAddress)
        {
            bool isConnected = false;
            Ping pinger = new Ping();

            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                isConnected = reply.Status == IPStatus.Success;
            }
            catch (PingException e)
            {
                MessageBox.Show(e.Message, "Host Error");
            }

            return isConnected;
        }

        public SqlDataReader DBRetrieveFunction(string sql)
        {
            if (DBCon.State.Equals(ConnectionState.Open))
                DBCon.Close();

            try
            {
                DBCon.Open();
                sqlCmd = new SqlCommand(sql, DBCon);
                sqlCmd.CommandTimeout = 300;
                sqlDtRdr = sqlCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                DBCon.Close();
                MessageBox.Show(ex.Message, "Error");
            }

            return sqlDtRdr;
        }

        //For return single value 

        public object DBExecuteScalar(string storedProcedureName, SqlParameter[] parameters)
        {
            object result = null;

            if (DBCon.State.Equals(ConnectionState.Open))
                DBCon.Close();

            try
            {
                DBCon.Open();

                SqlCommand command = new SqlCommand(storedProcedureName, DBCon);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                result = command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                //DBCon.Close();
            }

            return result;
        }


        public int DBExecuteScalarWithSQL(string sqlQuery)
        {
            int result = 0;

            if (DBCon.State.Equals(ConnectionState.Open))
                DBCon.Close();

            try
            {
                DBCon.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, DBCon);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                // DBCon.Close();  // You can choose to close the connection here or leave it open based on your needs.
            }

            return result;
        }




        public bool DBInsertUpdateDeleteFunction(string sql)
        {
            if (DBCon.State.Equals(ConnectionState.Open))
                DBCon.Close();

            //SqlTransaction transaction;
            //transaction = DBCon.BeginTransaction();

            try
            {
                DBCon.Open();
                sqlCmd = new SqlCommand(sql, DBCon);
                sqlCmd.ExecuteNonQuery();
                //transaction.Commit();
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                DBCon.Close();
                MessageBox.Show(ex.Message, "Error");
                return false;
            }

            return true;
        }

        // For testing 
        // For testing 

        //public void FillComboBox(ComboBox cmb, string sql, int chunkSize)
        //{
        //    SqlDataReader cmbDtRdr;
        //    cmbDtRdr = DBRetrieveFunction(sql);

        //    DataTable cmbDtTbl = new DataTable();
        //    cmbDtTbl.Load(cmbDtRdr);

        //    // Load the initial chunk of data
        //    var initialData = cmbDtTbl.AsEnumerable().Take(chunkSize).CopyToDataTable();

        //    cmb.DataSource = initialData;
        //    cmb.ValueMember = initialData.Columns[0].ToString();
        //    cmb.DisplayMember = initialData.Columns[1].ToString();

        //    // Store the remaining data in the ComboBox's Tag property
        //    cmb.Tag = cmbDtTbl.AsEnumerable().Skip(chunkSize).CopyToDataTable();

        //    cmbDtRdr.Close();
        //}


        public DataTable GetDataTable1(string query)
        {
            DataTable dataSourceTable = new DataTable();

            // Execute the query and populate the DataTable
            using (SqlCommand command = new SqlCommand(query, DBCon))
            {
                command.CommandTimeout = 3000;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSourceTable);
                }
            }
            return dataSourceTable;
        }

        public DataTable GetDataTable(string query)
        {
            DataTable dataSourceTable = new DataTable();

            if (DBCon.State.Equals(ConnectionState.Open))
                DBCon.Close();

            try
            {
                DBCon.Open();
                using (SqlCommand command = new SqlCommand(query, DBCon))
                {
                    command.CommandTimeout = 3000; // 5 minutes timeout
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataSourceTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                if (DBCon.State.Equals(ConnectionState.Open))
                    DBCon.Close();
            }

            return dataSourceTable;
        }

        // 1. Method to query data into a strongly-typed list using Dapper
        public List<T> QueryData<T>(string sqlOrProcedure, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            // Do NOT use the global DBCon. Create a fresh, healthy connection from the pool.
            using (var freshConnection = new SqlConnection(getConnectionString()))
            {
                freshConnection.Open();
                try
                {
                    // Dapper will automatically open and safely close this connection
                    return freshConnection.Query<T>(
                        sqlOrProcedure,
                        parameters,
                        commandType: commandType,
                        commandTimeout: 300
                    ).ToList();
                }
                catch (Exception ex)
                {
                    freshConnection.Close();
                    MessageBox.Show(ex.Message, "Dapper Error");
                    return new List<T>(); // Return an empty list rather than null on failure
                }
            }
        }

        // 2. Method to execute non-query commands (Insert, Update, Delete) with Dapper
        public int ExecuteDapper(string sqlOrProcedure, object parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            int affectedRows = 0;

            if (DBCon.State.Equals(ConnectionState.Open))
                DBCon.Close();

            try
            {
                DBCon.Open();
                affectedRows = DBCon.Execute(sqlOrProcedure, parameters, commandType: commandType, commandTimeout: 300);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dapper Error");
            }
            finally
            {
                if (DBCon.State.Equals(ConnectionState.Open))
                    DBCon.Close();
            }

            return affectedRows;
        }
    }



}
