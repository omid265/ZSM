using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace ManoloSellManager.Class
{
    /// <summary>
    /// Invoice manager Class
    /// </summary>
    class InvoiceMGR
    {
        Generals GS=Generals.CreateGenerals();

        public Int16 InvoiceNumber { set; get; }
        private int InvoiceNumberGenerator(string IType)
        {
            string Q = "SELECT * FROM `invoice` WHERE `type`='" + IType + "' ORDER BY `InvoiceId` DESC LIMIT 1";
            DataTable dtIN= GS.db.Query(Q);
            if (dtIN.Rows.Count > 0)
            {
                MySqlConnection msc = new MySqlConnection(GS.db.ConnectionString);
                MySqlCommand msCommand = new MySqlCommand();

                msCommand.Connection = msc;
                
                int ii=Convert.ToInt16(dtIN.Rows[0]["invoiceId"])+1;
                msc.Open();

                msCommand.CommandText = "INSERT INTO  `invoice` "
                    + "(`InvoiceId`,`InvoiceDate`,`type`)"
                    + "VALUES("
                    + "'" + ii + "'"
                    + ",'" + GS.dateManager.GetCurrentPersianDate("-") + "'"
                    + ",'" + IType + "'"
                    + ")";

                //MessageBox.Show(msCommand.CommandText);

                MySqlDataReader msdr = msCommand.ExecuteReader();
                if (msdr.RecordsAffected != null)
                {

                }
                msc.Close();
                return ii;
            }
            return 1;
        }
        public int GetNewInvoiceNumber(string IType)
        {
            return InvoiceNumberGenerator(IType);
        }
        public int Create(Invoice InvoiceDetails)
        {
            return InvoiceNumberGenerator(InvoiceDetails.InvoiceType);

            //return 1;
        }
        public DataTable Load(int InvoiceNo)
        {
            string sqlQueryOrder = string.Format("SELECT * FROM `invoice` WHERE `InvoiceId`='{0}'  ", InvoiceNo.ToString() );
            return GS.db.Query(sqlQueryOrder);
        }
        public DataTable Load_Details(int InvoiceNo,string Itype)
        {

            return GS.db.Query("SELECT * FROM `invoicedetails` WHERE `InvoiceNo`='" + InvoiceNo.ToString() + "' AND `type`='"+Itype+"'");
        }
        public DataTable GetItemFromInvoice(Int64 ID)
        {
            string Query= "SELECT * FROM `invoicedetails` WHERE `id`='"+ID.ToString()+"'";
            return GS.db.Query(Query);
        }
        public class InvoiceType
        {
            public string Sell = "";
            public string pish = "pish";
            public string buy = "buy";
        }
        public class  Invoice
        {
            public int ID { private set; get; }
            public int InvoiceNo { set; get; }
            public int PersonID { set; get; }
            public float Price { set; get; }
            public float Discount { set; get; }
            public string Description { set; get; }
            public string Status { set; get; }
            /// <summary>
            /// Invoice type must have 
            /// </summary>
            public string InvoiceType { set; get; }
        }
    }
    
    public class Orders
    {
        public enum Type : int
        {
            Sell = 1,
            Pre_Order = 2,
            Purchase_Invoice = 3
        }
        Generals GS = Generals.CreateGenerals();
        public class Items
        {
            public int Add(Order O)
            {
                return 0;
            }
            public int Update(Order O)
            {
                return 0;
            }
            public int Delete(Order O)
            {
                return 0;
            }
            public class Order
            {
                public int ID { set;get; }
                public string Person { set;get; }
                public string Date { set;get; }
                public string Time { set; get; }
                public string Price { set; get; }
                public string Discount { set; get; }
                public string Description { set; get; }
                public string Status { set; get; }
                public Type Type { set; get; }
                public int TransactionId { set; get; }
                public string Prop { set; get; }
            }

        }
    }

}
