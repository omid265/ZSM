using System;
using Generals;
using System.Data;
using DatabaseManager;
namespace ManoloSellManager.Class
{
    public sealed class Invoice
    {
        private static volatile Invoice InvoiceMGR;
        private static object _lock = new object();
        private Invoice() { }
        public static Invoice invoice()
        {
            if (InvoiceMGR == null)
            {
                lock (_lock)
                {
                    if (InvoiceMGR == null)
                    {
                        InvoiceMGR = new Invoice();
                    }
                }
            }
            return InvoiceMGR;
        }
        DB db = DB.CreateDBManager();
        TransactionActivity.TransactionLog tl = new TransactionActivity.TransactionLog();
        string DBName = "`" + ConfigFile.GetConfig().DatabaseConfig().DatabaseName + "`.";

        public enum InvoiceType
        {
            buy = 1
            ,sell = 2
            , proforma = 3
        }


        //public string IinvoiceType 
        //{
        //    public string Buy { get { return "1"; } }
        //    public string Sell { get { return "2"; } }
        //    public string Proforma { get { return "3"; } }
        //}

        
        public static class Current
        {
            public static int Number
            {
                set;get;
            }
            public static InvoiceType Type
            {
                set;
                get;
            }
            public static string Date
            {
                set;get;
            }
            public static int Client
            {
                set;get;
            }
        }


        public int GenerateNewInvoiceNumber(InvoiceType InvoiceType)
        {
            return Create(InvoiceType);
        }

        public int GetTransactionID(InvoiceType IT)
        {
            return Convert.ToInt16(db.Query(string.Format("SELECT `TransactionID` FROM {2} `invoice` WHERE `InvoiceId`='{0}' AND `type`='{1}'", Current.Number, IT, DBName)).Rows[0]["TransactionID"]);
        }
        public decimal GetPrice(InvoiceType IT)
        {
            return Convert.ToDecimal(db.Query(string.Format("SELECT `InvoicePrice` FROM {2}`invoice` WHERE `InvoiceId`='{0}' AND `type`='{1}'", Current.Number, IT, DBName)).Rows[0]["InvoicePrice"]);
        }
        public decimal GetCustomer(InvoiceType IT)
        {
            return Convert.ToDecimal(db.Query(string.Format("SELECT `InvoiceUserId` FROM {2}`invoice` WHERE `InvoiceId`='{0}' AND `type`='{1}'", Current.Number, IT, DBName)).Rows[0]["InvoiceUserId"]);
        }
        public int TransferInvoiceType(InvoiceType CurrentType, int currentInvoiceNumber, InvoiceType NewType)
        {
            //int ni = GenerateNewInvoiceNumber(NewType);
            //db.Query(string.Format(@"UPDATE `invoice` SET `type` = '{0}',`InvoiceId`='{1}' WHERE `InvoiceId`='{2}' AND `type`='{3}'", NewType, ni, currentInvoiceNumber, CurrentType));
            //db.Query(string.Format(@"UPDATE `invoicedetails` SET `type` = '{0}',`InvoiceNo`='{1}' WHERE `InvoiceNo`='{2}' AND `type`='{3}'", NewType, ni, currentInvoiceNumber, CurrentType));


            ////var tl = new TransactionActivity.TransactionLog();

            ////////////// NT= New Transaction
            //TransactionActivity.Transaction NT = new TransactionActivity.Transaction();

            //////////// TTO= Transaction Type Order
            //TransactionActivity.TransactionType TTO = TransactionActivity.TransactionType.Order;

            /////////// TMT= Transaction Method Type
            //TransactionActivity.TransactionMethodType TMT = TransactionActivity.TransactionMethodType.Order;

            ////////// set transaction Price
            //NT.Amount = Convert.ToDouble(txtPayPrice.Text);
            ///////// personal id for this transaction
            //NT.PersonalID = Convert.ToDecimal(txtSellerCodeMain.Text);

            //NT.TranactionMethod = TMT;
            //NT.TransactionDescription = "سفارش فاکتور شماره " + txtOrderNo.Text;
            //NT.TransactionTime = DateTime.Now.ToShortTimeString();
            //NT.TranstionDate = GS.dateManager.GetCurrentDate();
            //NT.TranstionFor = TTO;
            //NT.RemainAccount = tl.RemainAccount(Convert.ToDecimal(txtSellerCodeMain.Text)) + Convert.ToDouble(txtPayPrice.Text);
            //byte DFF = Convert.ToByte(TransactionActivity.TransactionStatus.Bedehkar);
            //NT.Status = DFF;
            //tl.NewTransaction(NT);




            //tl.FillTransaction(NT, GetTransactionID(NewType));
            //return ni;
            return 0;
        }






        public int TransferInvoiceToSellType(bool current)
        {

            int ni = Current.Number;
            InvoiceType it = InvoiceType.sell;
            if (!current)
            {
                GenerateNewInvoiceNumber(InvoiceType.sell);
                it = InvoiceType.proforma;
                db.Query(string.Format(@"UPDATE {4}`invoice` SET `type` = '{0}',`InvoiceId`='{1}' WHERE `InvoiceId`='{2}' AND `type`='{3}'", InvoiceType.sell, ni, Current.Number, it, DBName));
                db.Query(string.Format(@"UPDATE {4}`invoicedetails` SET `type` = '{0}',`InvoiceNo`='{1}' WHERE `InvoiceNo`='{2}' AND `type`='{3}'", InvoiceType.sell, ni, Current.Number, it, DBName));

            }


            decimal customer = GetCustomer(InvoiceType.sell);
            decimal amount = GetPrice(InvoiceType.sell);

            //////////// NT= New Transaction
            TransactionActivity.Transaction NT = new TransactionActivity.Transaction();

            ////////// TTO= Transaction Type Order
            TransactionActivity.TransactionType TTO = TransactionActivity.TransactionType.Order;

            ///////// TMT= Transaction Method Type
            TransactionActivity.TransactionMethod TMT = TransactionActivity.TransactionMethod.Order;

            //////// set transaction Price
            NT.Amount = amount;
            /////// personal id for this transaction
            NT.PersonalID = customer;

            NT.Method = TMT;
            NT.Description = "سفارش فاکتور شماره " + ni.ToString();
            NT.Time = DateTime.Now.ToShortTimeString();
            NT.Date = Generals.CreateGenerals().dateManager.GetCurrentPersianDate();
            NT.Type = TTO;
            NT.RemainAccount = tl.RemainAccount(customer) + amount;
            byte DFF = Convert.ToByte(TransactionActivity.TransactionStatus.Bedehkar);
            NT.Status = DFF;
            //tl.NewTransaction(NT);




            tl.FillTransaction(NT, GetTransactionID(InvoiceType.sell));
            return ni;
        }
        
        /// <summary>
        /// Create new invoice and return new invoice number
        /// </summary>
        /// <param name="InvoiceType"></param>
        /// <returns>new invoice number</returns>
        public int Create(InvoiceType InvoiceType)
        {
            int ii = 0;
            try
            {
                string Q = string.Format("SELECT * FROM {0}`invoice` WHERE `type`='{1}' ORDER BY `InvoiceId` DESC LIMIT 1",DBName, InvoiceType);
                DataTable dtIN = db.Query(Q);
                if (dtIN == null)
                {
                    return 0;
                }
                if (dtIN.Rows.Count > 0)
                {
                    ii = Convert.ToInt16(dtIN.Rows[0]["invoiceId"]) + 1;

                    Current.Number = ii;
                    Current.Type = InvoiceType;
                }
                else
                {
                    ii++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Current.Number = ii;
            Current.Type = InvoiceType;
            Current.Date = DateManager.GetDate().GetCurrentPersianDate("-");

            string q = string.Format(@"INSERT INTO  {4}`invoice`(`InvoiceId`,`InvoiceDate`,`type`,`TransactionID`)VALUES('{0}','{1}','{2}','{3}')"
            , Current.Number,Current.Date , Current.Type, tl.NewTransaction(), DBName);
            db.Query(q, true);
            return ii;
        }

        public DataTable Load(int InvoiceNo, InvoiceType iType)
        {
            string sqlQueryOrder = string.Format("SELECT * FROM {2}`invoice` WHERE `InvoiceId`='{0}' AND `type`='{1}' ", InvoiceNo, iType, DBName);
            return db.Query(sqlQueryOrder);
        }

        /// <summary>
        /// Return invoice using Current.Number
        /// </summary>
        /// <returns>data table</returns>
        public DataTable Load(InvoiceType iType)
        {
            Current.Type = iType;

            string sqlQueryOrder = string.Format("SELECT * FROM {2}`invoice` WHERE `InvoiceId`='{0}' AND `type`='{1}' ", Current.Number, iType, DBName);
            return db.Query(sqlQueryOrder);
        }

        /// <summary>
        /// Return invoice details from invoiceDetails table
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <param name="Itype"></param>
        /// <returns>data table</returns>
        public DataTable Load_Details(int InvoiceNo, InvoiceType Itype)
        {
            Current.Type = Itype;

            return db.Query(string.Format("SELECT * FROM {2}`invoicedetails` WHERE `InvoiceNo`='{0}' AND `type`='{1}'", InvoiceNo, Itype, DBName));
        }
        /// <summary>
        /// Return Current invoice details using Current.Number properties from invoiceDetails table
        /// </summary>
        /// <param name="Itype"></param>
        /// <returns>Data table</returns>
        public DataTable Load_Details(InvoiceType Itype)
        {
            Current.Type = Itype;
            return db.Query(string.Format("SELECT * FROM {2}`invoicedetails` WHERE `InvoiceNo`='{0}' AND `type`='{1}'"
                , Current.Number, Itype, DBName));
        }

        public Double InvoicePrice(InvoiceType Itype)
        {
            string q = string.Format("SELECT (SUM(`ItemPrice`*`itemCount`)) as `InvoicePrice` FROM {2}`invoicedetails` WHERE `InvoiceNo`='{0}' AND `type`='{1}'"
                , Current.Number, Itype, DBName);
            double OrderPrice;
            try
            {
                OrderPrice = Convert.ToDouble(db.Query(q).Rows[0]["InvoicePrice"].ToString());
            }
            catch
            {
                OrderPrice = 0;
            }
            return OrderPrice;
        }
        public DataTable GetItem(int ID)
        {
            string Query = string.Format("SELECT * FROM {1}`invoicedetails` WHERE `id`='{0}'", ID, DBName);
            return db.Query(Query);
        }
        public InvoiceItem GetInvoice(int InvoiceNumber,InvoiceType iType)
        {
            DataTable dt= Load(InvoiceNumber, iType);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                InvoiceItem ii = new InvoiceItem
                {
                    ClientCode = dt.Rows[0]["InvoiceUserId"].ToString(),
                    Date = dt.Rows[0]["InvoiceDate"].ToString(),
                    Description = dt.Rows[0]["InvoiceDescription"].ToString(),
                    Discount = Convert.ToDecimal(dt.Rows[0]["InvoiceDiscount"].ToString()),
                    Number = dt.Rows[0]["InvoiceId"].ToString(),
                    Price = Convert.ToDecimal(dt.Rows[0]["InvoicePrice"].ToString()),
                    Props = dt.Rows[0]["prop"].ToString(),
                    Status = dt.Rows[0]["status"].ToString(),
                    Time = dt.Rows[0]["InvoiceTime"].ToString(),
                    TransactionID = dt.Rows[0]["TransactionID"].ToString(),
                };

                if (!string.IsNullOrEmpty(dt.Rows[0]["type"].ToString()) || !string.IsNullOrWhiteSpace(dt.Rows[0]["type"].ToString())) {
                    int IT = Convert.ToInt32(dt.Rows[0]["type"].ToString());
                    switch (IT) {
                        case 1:
                        ii.type = InvoiceType.buy;
                            break;
                        case 2:
                            ii.type = InvoiceType.sell;
                            break;
                        case 3:
                            ii.type = InvoiceType.proforma;
                            break;
                    }
                }
                else
                {
                    ii.type = InvoiceType.sell;
                }
                return ii;
            }/// end close condition for validate row count
        }/// end function


        public void Edit()
        {

        }




        /// <summary>
        /// Delete current invoice using Current.Number
        /// </summary>
        /// <param name="iType"></param>
        public int Delete(InvoiceType iType)
        {
            if (Current.Number != 0)
            {
                string q = string.Format("DELETE FROM {2}`invoicedetails` WHERE `InvoiceNo`='{0}' And `type`='{1}'", Current.Number, iType, DBName);
                db.Query(q, true);
                q = string.Format("DELETE FROM {2}`invoice` WHERE `InvoiceId`='{0}' AND `type`='{1}'", Current.Number, iType, DBName);
                db.Query(q, true);
            }
            return 1;/// 1= Job is done.
        }
        public int Delete(InvoiceType iType, string invoiceNumber)
        {
            string q = string.Format("DELETE FROM {2}`invoicedetails` WHERE `InvoiceNo`='{0}' And `type`='{1}'", invoiceNumber, iType, DBName);
            db.Query(q, true);
            q = string.Format("DELETE FROM {2}`invoice` WHERE `InvoiceId`='{0}' AND `type`='{1}'", invoiceNumber, iType, DBName);
            db.Query(q, true);
            return 1;/// 1= Job is done.
        }

        //public int SendToWorkShop(int InvoiceNumber)
        //{

        //}


        public class DetailItem
        {
            public string Code { set; get; }
            public string Name { set; get; }
            public decimal Price { set; get; }
            public string Unit { set; get; }
            public string QTY { set; get; }
            public decimal UnitAmount { set; get; }
            public string Limiter { set; get; }
            public string Size { set; get; }
            public string Description { set; get; }
            public string UnitPrice { set; get; }
            public string Props { set; get; }
        }
        public class InvoiceItem
        {
            public string Number { set; get; }
            public string ClientCode { set; get; }
            public string Date { set; get; }
            public string Time { set; get; }
            public decimal Price { set; get; }
            public decimal Discount { set; get; }
            public string Description { set; get; }
            public string Status { set; get; }
            public InvoiceType type { set; get; }
            public string TransactionID { set; get; }
            public string Props { set; get; }

        }
        public int AddItem(DetailItem item)
        {
            int QueryResutl=db.Query("INSERT INTO "+ DBName + "`invoicedetails` (`InvoiceNo`,`ItemId`,`ItemName`,`ItemPrice`,`itemUnit`,`itemUnitfi`,`limiter`,`itemSize`,`description`" +
                ",`itemCount`,`PricePerAny`,`prop`,`type`) " +
                         "VALUES ('" 
                         + Current.Number + "','" + item.Code + "','" + item.Name 
                         + "','" + item.Price + "','" + item.Unit + "','" + item.UnitAmount
                         + "','" + item.Limiter+ "','" + item.Size + "','" + item.Description+ "','" 
                         + item.QTY+ "','" + item.UnitPrice + "','" + item.Props + "'" + ",'" + Current.Type + "')", true,false);
            if (QueryResutl > -1)
            {
                return 0;//0= successfully
            }
            else
            {
                return QueryResutl;
            }
        }
        public int UpdateItem(int RecordID,DetailItem item)
        {
            string q = string.Format(@"UPDATE  `invoicedetails` SET  
                            `ItemId` =  '{0}',
                            `ItemName` =  '{1}',
                            `ItemPrice` =  '{2}',
                            `itemUnit` =  '{3}',
                            `itemCount` =  '{4}',
                            `itemSize` =  '{5}',
                            `description` =  '{6}',
                            `limiter` =  '{7}',
                            `itemUnitfi` =  '{8}',
                            `PricePerAny` =  '{9}',
                            `prop` =  '{10}' 
                            `type` =  '{11}' 
                        WHERE  `invoicedetails`.`id` ='{12}';"
                            , item.Code
                            , item.Name
                            , item.Price
                            , item.Unit
                            , item.QTY
                            , item.Size
                            , item.Description
                            , item.Limiter
                            , item.UnitAmount
                            , item.UnitPrice
                            , item.Props, Current.Type
                            , RecordID);
            int iQR=db.Query(q,true,false);

            return iQR;
        }
    }
}
