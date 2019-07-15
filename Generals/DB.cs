using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DatabaseManager
{
    public class DB
    {
        string ConnectionStringOrginal = @"server=localhost;user id=root;database=accounting;allowuservariables=True;logging=False;persistsecurityinfo=True;Charset=utf8;";
        DataTable DTN = new DataTable();
        string QueryMessageInner = "";

        public string ConnectionString
        {
            get { return ConnectionStringOrginal; }
            set { ConnectionStringOrginal = value; }
        }
        public string DBMessage
        {
            get { return QueryMessageInner; }
        }

        /// <summary>
        /// Run the query to database and return data to datatable
        /// </summary>
        /// <param name="Query">SELECT * FROM Table name WHERE filedName="Value"</param>
        /// <returns></returns>
        public DataTable Query(string Query)
        {
            //Query = "DELETE FROM `invoicedetails` WHERE `InvoiceNo`='" + txtOrderNo.Text + "'";

            MySqlConnection msc = new MySqlConnection(this.ConnectionString);
            MySqlDataAdapter da = new MySqlDataAdapter(Query, msc);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                QueryMessageInner = "success";
                DTN = dt;
                return dt;

            }
            catch (Exception er)
            {
                QueryMessageInner = "مشکلی به وجود آمده است" + " : " + er.Message;
                msc.Close();
                //MessageBox.Show(er.Message);
                return null;

            }
            finally
            {
                msc.Close();
            }
        }

    }
}
