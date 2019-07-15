using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManoloSellManager.Class;
using Generals;

namespace ManoloSellManager.Forms
{
    public partial class frmImportOldData : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();
        public frmImportOldData()
        {
            InitializeComponent();
        }

        private void btnImportStore_Click(object sender, EventArgs e)
        {
            Products.Product item = new Products.Product();
            var myDataTable = new DataTable();
            openFileDialog1.ShowDialog(this);
            if (string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                MessageBox.Show("هیچ فایلی انتخاب نشده است.");
                return;
            }
            string dbFile = openFileDialog1.FileName;
            using (var conection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;" + "data source=" + dbFile + ";"))
            using (DataTable dt = new DataTable())
            {
                string query = "Select * From `tblstoreitem`";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conection))
                {
                    adapter.Fill(dt);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    item.Name = dr["Iname"].ToString();
                    item.Code = dr["code"].ToString();
                    item.Price = dr["Price"].ToString();
                    item.Unit = dr["UnitName"].ToString();
                    item.Limiter = dr["Inclimited"].ToString();
                    item.StoreControl = "0";
                    Products.Items.Add(item);
                }
                MessageBox.Show(dt.Rows.Count.ToString());
            }
        }

        private void btnImportPersonals_Click(object sender, EventArgs e)
        {
            var myDataTable = new DataTable();
            openFileDialog1.ShowDialog(this);
            if (string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                MessageBox.Show("هیچ فایلی انتخاب نشده است.");
                return;
            }
            string dbFile = openFileDialog1.FileName;
            using (var conection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;" + "data source=" + dbFile + ";"))
            using (DataTable dt = new DataTable())
            {
                string query = "Select * From `tblmembers`";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conection))
                {
                    adapter.Fill(dt);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    Clients.Client newClient = new Clients.Client();
                    newClient.Address = dr["address"].ToString();
                    newClient.CompanyAddress = "";
                    newClient.CompanyName = "";
                    newClient.CompanyPhone = "";
                    newClient.Fax = "";
                    newClient.mobile = dr["phone"].ToString();
                    newClient.name = dr["mname"].ToString() + (!string.IsNullOrEmpty(dr["fathername"].ToString()) ? " - " + dr["fathername"].ToString() : "");
                    newClient.nickName = "";
                    newClient.phone = dr["phone"].ToString();
                    newClient.type =Clients.ClientType.Customer;

                    Clients.Items.Add(newClient);
                }
                MessageBox.Show(dt.Rows.Count.ToString());
            }
        }

        private void btnImportPersonalRemainAccount_Click(object sender, EventArgs e)
        {
            Clients m = new Clients();
            List<Clients.Client> mm = m.getClients("");



            foreach(Clients.Client c in mm)
            {

            }

            return ;
            var myDataTable = new DataTable();
            openFileDialog1.ShowDialog(this);
            if (string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                MessageBox.Show("هیچ فایلی انتخاب نشده است.");
                return;
            }
            string dbFile = openFileDialog1.FileName;
            using (var conection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;" + "data source=" + dbFile + ";"))
            using (DataTable dt = new DataTable())
            {
                string query = "Select * From `tblmembers`";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conection))
                {
                    adapter.Fill(dt);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    string AllDue = dr["Alldue"].ToString();
                    string AllPay = dr["TotPayment"].ToString();
                    decimal Result = Convert.ToDecimal(AllDue) - Convert.ToDecimal(AllPay);
                    if (Result > 0)
                    {
                        MessageBox.Show(dr["mname"].ToString() + " | " + Result.ToString());
                    }
                    //}
                    //    return;
                    var tl = new TransactionActivity.TransactionLog();

                    //////////// NT= New Transaction
                    TransactionActivity.Transaction NT = new TransactionActivity.Transaction();
                    ////////// TTO= Transaction Type Order
                    TransactionActivity.TransactionType TTO = TransactionActivity.TransactionType.RemainAccount;
                    ///////// TMT= Transaction Method Type
                    TransactionActivity.TransactionMethod TMT = TransactionActivity.TransactionMethod.Old;

                    //////// set transaction Price
                    NT.Amount = Convert.ToDecimal("");
                    /////// personal id for this transaction
                    NT.PersonalID = Convert.ToDecimal("");

                    NT.Method = TMT;
                    NT.Description = "مانده حساب از سال مالی گذشته";
                    NT.Time = DateTime.Now.ToShortTimeString();
                    NT.Date = GS.dateManager.GetCurrentPersianDate();
                    NT.Type = TTO;
                    NT.RemainAccount = tl.RemainAccount(Convert.ToDecimal("")) + Convert.ToDecimal(NT.Amount);
                    byte DFF = Convert.ToByte(TransactionActivity.TransactionStatus.Bedehkar);
                    NT.Status = DFF;
                    tl.NewTransaction(NT);
                }
            }
        }
    }

}
