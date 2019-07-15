using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Generals;
namespace DatabaseManager
{
    public sealed class DB
    {
        #region singelTone section
        private static volatile DB DBManager;
        private static object _lock = new object();
        private DB() { }
        public static DB CreateDBManager()
        {
            if (DBManager == null)
            {
                lock (_lock)
                {
                    if (DBManager == null)
                    {
                        DBManager = new DB();
                    }
                }
            }
            return DBManager;
        }
        #endregion


        dynamic conf=ConfigFile.GetConfig().DatabaseConfig();

        string ConnectionStringDefault = string.Format(@"server={0};Uid={1};Pwd={2};database={3};allowuservariables=True;logging=False;persistsecurityinfo=True;Charset=utf8;"
                                                        ,ConfigFile.GetConfig().DatabaseConfig().Server
                                                        , ConfigFile.GetConfig().DatabaseConfig().UserName
                                                        , ConfigFile.GetConfig().DatabaseConfig().Password
                                                        , ConfigFile.GetConfig().DatabaseConfig().DatabaseName);

        string QueryMessageInner = "";
        int QueryErrorCode = 0;

        public int QueryError
        {
            get { return QueryErrorCode; }
        }

        public string ConnectionString
        {
            set { ConnectionStringDefault = value; }
            get { return ConnectionStringDefault; }
        }
        public string QueryMessage
        {
            get { return QueryMessageInner; }
        }
        public DataTable Result = new DataTable();
        public int ResultCount
        {
            get
            {
                return Result.Rows.Count;
            }
        }

        /// <summary>
        /// Run the query to database and return data to datatable
        /// </summary>
        /// <param name="Query">SELECT * FROM Table name WHERE filedName="Value"</param>
        /// <returns>Return data table</returns>
        public DataTable Query(string Query)
        {
            MySqlConnection msc = new MySqlConnection(this.ConnectionString);
            MySqlDataAdapter da = new MySqlDataAdapter(Query, msc);

            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                QueryMessageInner = "success";
                QueryErrorCode = 0;
                Result = dt;
                return dt;

            }
            catch (Exception er)
            {
                QueryMessageInner = er.Message;
                msc.Close();
                return null;
                //throw new Exception(QueryMessageInner + Environment.NewLine + QueryErrorCode.ToString());
            }
            finally
            {
                msc.Close();
            }
        }/// End Query

        /// <summary> this is just run Executeable query like INSERT INTO And DELETE</summary>
        /// <returns>1= job is done!</returns>
        public int Query(string Query, bool Execute, bool throwError = true)
        {
            //Query = "DELETE FROM `invoicedetails` WHERE `InvoiceNo`='" + txtOrderNo.Text + "'";

            MySqlConnection msc = new MySqlConnection(this.ConnectionString);
            MySqlCommand msCommand = new MySqlCommand();
            try
            {
                msCommand.Connection = msc;
                msc.Open();
                msCommand.CommandText = Query;
                MySqlDataReader msdr = msCommand.ExecuteReader();
                long affectedID=msCommand.LastInsertedId;

                if (msdr.RecordsAffected != 0)
                {

                }
                msc.Close();
                return Convert.ToInt16( affectedID);/// job is done successfully
            }
            catch (Exception er)
            {
                QueryMessageInner = er.Message;
                QueryErrorCode = -1;
                msc.Close();
                if (throwError)
                {
                    //throw new Exception(QueryMessageInner + Environment.NewLine + QueryErrorCode.ToString());
                    return 0;/// job done successfullty
                }
                else
                {
                    return -1;// job have an error
                }
            }
            finally
            {
                msc.Close();
            }
        }/// End Query

        public void Backup(string BackupDirectoryPath, string FileName)
        {
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////[ Start Backup System From here ]//////////////////
            //string constring = @"server=localhost;user id=root;database=accounting;allowuservariables=True;logging=False;persistsecurityinfo=True;Charset=utf8;";
            string backUpPath = BackupDirectoryPath;
            if (backUpPath.Substring(backUpPath.Length - 1, 1) == "\\")
            {
                backUpPath += FileName;
            }
            else
            {
                backUpPath += "\\" + FileName;
            }

            //string file = backUpPath + @"\backUP\" + this.PC.GetYear(DateTime.Now).ToString() + "\\" + this.PC.GetMonth(DateTime.Now).ToString() + "\\backup" + this.GetCurrentDate("-") + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + ".sql";
            string Min = DateTime.Now.TimeOfDay.Minutes.ToString();
            string ch = DateTime.Now.TimeOfDay.Hours.ToString();

            string file = backUpPath;
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        try
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                        }catch(Exception e)
                        {
                            QueryMessageInner = e.Message;
                        }
                    }
                }
            }
            //////////////////////////////[ Start Backup System From here ]//////////////////
            //////////////////////////////////////////////////////////////////////////////////

        }///// End backup Function

        public void Restore()
        {

            string file = "C:\\backup.sql";
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(file);
                        conn.Close();
                    }
                }
            }

        }//////// End Restore database function


    }//// End DB Class
}
