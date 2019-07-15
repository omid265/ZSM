using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ManoloSellManager.Class
{

    class TransactionActivity
    {
        public enum TransactionMethod
        {
            cash,
            doc,
            Order,
            Old
        };////// End TransactionMethodType Enum
        public enum TransactionType
        {
            pay,
            get,
            Order,
            RemainAccount,
            Buy
        }
        public enum TransactionStatus : byte
        {
            Bedehkar = 1,
            Bestankar = 2
        }

        public class TransactionLog
        {

            Generals GS = Generals.CreateGenerals();

            string TransactionTableName = "`accounting`";
            public int TransactionID
            {
                internal set;
                get;
            }

            public int Normalization(decimal PersonalID)
            {
                string Q = "SELECT * FROM " + TransactionTableName
                    + " WHERE `personalId`='" + PersonalID + "'"
                    + " ORDER BY `id` ASC";

                DataTable ATL = new DataTable();
                ATL = GS.db.Query(Q);
                try
                {
                    if (ATL.Rows.Count > 0)
                    {
                        int Counter = 0;
                        for (int i = 0; ATL.Rows.Count > i; i++)
                        {
                            int rc = ATL.Rows.Count;
                            string NewR = "";
                            if (i == 0)
                            {
                                //Counter++;
                                NewR = ATL.Rows[0]["payPrice"].ToString();
                            }
                            else
                            {
                                if (ATL.Rows.Count == i + 1)
                                {

                                }
                                NewR = RemainAccount(PersonalID, Convert.ToDecimal(ATL.Rows[i]["id"].ToString())).ToString();

                            }
                            Counter++;

                            string Query = "UPDATE  " + TransactionTableName + "  SET "
                                + "`remainaccount` =  '" + NewR + "'"
                                + "WHERE  `id` ='" + ATL.Rows[i]["id"].ToString() + "' AND `personalId`='" + PersonalID + "';";
                            GS.db.Query(Query);

                            //Counter++;
                        }
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }
            public int Edit(string payAbout, decimal PersonalID, decimal NewPersonalID, double NewPrice)
            {
                try
                {

                    string Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`payPrice` =  '" + NewPrice.ToString() + "'"
                        + ",`personalId` =  '" + NewPersonalID + "'"
                        + "WHERE  `payAbout` ='" + payAbout + "' AND `personalId`='" + PersonalID + "';";
                    GS.db.Query(Query);


                    #region New TL In Comment
                    //string Query = "DELETE FROM  " + TransactionTableName
                    //    + "WHERE  `payAbout` ='" + payAbout + "' AND `personalId`='" + PersonalID + "';";
                    //GS.db.Query(Query);
                    //var tl = new TransactionActivity.TransactionLog();

                    ////////////// NT= New Transaction
                    //TransactionActivity.Transaction NT = new TransactionActivity.Transaction();


                    //////////// TTO= Transaction Type Order
                    //TransactionActivity.TransactionType TTO = TransactionActivity.TransactionType.Order;

                    /////////// TMT= Transaction Method Type
                    //TransactionActivity.TransactionMethodType TMT = TransactionActivity.TransactionMethodType.Order;

                    ////////// set transaction Price
                    //NT.Amount = NewPrice;
                    ///////// personal id for this transaction
                    //NT.PersonalID = NewPersonalID;

                    //NT.TranactionMethod = TMT;
                    //NT.TransactionDescription = payAbout;
                    //NT.TransactionTime = DateTime.Now.ToShortTimeString();
                    //NT.TranstionDate = GS.GetCurrentDate();
                    //NT.TranstionFor = TTO;
                    //NT.RemainAccount = tl.RemainAccount(NewPersonalID) + NewPrice;
                    //byte DFF = Convert.ToByte(TransactionActivity.TransactionStatus.Bedehkar);
                    //NT.Status = DFF;
                    //tl.NewTransaction(NT);

                    #endregion

                    //Query = "UPDATE  " + TransactionTableName + "  SET "
                    //    + "`remainaccount` =  '" + RemainAccount(PersonalID).ToString() + "'"
                    //    + "`personalId` =  '" + NewPersonalID + "'"
                    //    + "WHERE  `payAbout` ='" + payAbout + "' AND `personalId`='" + PersonalID + "';";
                    //GS.db.Query(Query);

                    Normalization(PersonalID);
                    Normalization(NewPersonalID);

                    return 0;

                }
                catch
                {
                    return 1;
                }
            }
            public int Edit(int TransactionID, decimal PersonalID, double NewPrice)
            {
                try
                {
                    string Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`payPrice` =  '" + NewPrice.ToString() + "'"
                        + "WHERE  `id` ='" + TransactionID + "';";
                    GS.db.Query(Query);


                    Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`remainaccount` =  '" + RemainAccount(PersonalID).ToString() + "'"
                        + "WHERE  `id` ='" + TransactionID + "';";
                    GS.db.Query(Query);

                    Normalization(PersonalID);

                    return 0;

                }
                catch
                {
                    return 1;
                }
            }

            public int Edit(string payAbout, decimal PersonalID, double NewPrice)
            {
                try
                {
                    string Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`payPrice` =  '" + NewPrice.ToString() + "'"
                        + "WHERE  `payAbout` ='" + payAbout + "' AND `personalId`='" + PersonalID + "';";
                    GS.db.Query(Query);


                    Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`remainaccount` =  '" + RemainAccount(PersonalID).ToString() + "'"
                        + "WHERE  `payAbout` ='" + payAbout + "' AND `personalId`='" + PersonalID + "';";
                    GS.db.Query(Query);

                    Normalization(PersonalID);

                    return 0;

                }
                catch
                {
                    return 1;
                }
            }
            public int Edit(string OldpayAbout, string NewPayAbout, decimal OldPersonalID, decimal NewPersonalID, double NewPrice)
            {
                try
                {
                    string Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`payPrice` =  '" + NewPrice.ToString() + "'"
                        + ",`payAbout` =  '" + NewPayAbout + "'"
                        + ",`personalId` =  '" + NewPersonalID + "'"
                        + "WHERE  `payAbout` ='" + OldpayAbout + "' AND `personalId`='" + OldPersonalID + "';";
                    GS.db.Query(Query);


                    Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`remainaccount` =  '" + RemainAccount(NewPersonalID).ToString() + "'"
                        + "WHERE  `payAbout` ='" + NewPayAbout + "' AND `personalId`='" + NewPersonalID + "';";
                    GS.db.Query(Query);
                    Normalization(NewPersonalID);
                    Normalization(OldPersonalID);
                    return 0;

                }
                catch
                {
                    return 1;
                }
            }
            public int Edit(decimal payId, double NewPrice, string Description, string NewDate, decimal PersonalID)
            {
                try
                {
                    string Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`payPrice` =  '" + NewPrice.ToString() + "'"
                        + ",`payDate` =  '" + NewDate + "'"
                        + ",`payAbout` =  '" + Description + "'"
                        + "WHERE  `id` ='" + payId + "';";
                    GS.db.Query(Query);


                    Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`remainaccount` =  '" + this.RemainAccount(PersonalID).ToString() + "'"
                        + "WHERE  `id` ='" + payId + "' AND `personalId`='" + PersonalID + "';";
                    GS.db.Query(Query);
                    Normalization(PersonalID);
                    return 0;

                }
                catch
                {
                    return 1;
                }
            }
            public int Edit(decimal payId, string NewDate)
            {
                try
                {
                    string Query = "UPDATE  " + TransactionTableName + "  SET "
                        + "`payDate` =  '" + NewDate + "'"
                        + "WHERE  `id` ='" + payId + "';";
                    GS.db.Query(Query);
                    return 0;

                }
                catch
                {
                    return 1;
                }
            }


            public int FillTransaction(Transaction T, int Tid)
            {
                try
                {
                    GS.db.Query(string.Format(@"UPDATE `accounting` SET `personalId` = '{0}', `payPrice` = '{1}', `payAbout` = '{2} ', `payMethod` = '{3}', `payType` = '{4}', `payDate` = '{5}', `remainaccount` = '{6}', `status`='{8}' WHERE `accounting`.`id` = {7};"
                    , T.PersonalID, T.Amount, T.Description, T.Method, T.Type, T.Date, T.RemainAccount, Tid,T.Status));
                }
                catch
                {
                    return -1;/// Have an error
                }
                return 0;/// Sucssessfully
            }

            public int NewTransaction()
            {
                try
                {
                    string Q = "INSERT INTO `accounting` (`id`, `personalId`, `payPrice`, `payAbout`, `payMethod`, `payType`, `payTime`, `payDate`, `status`, `remainaccount`) VALUES (NULL, '', '', '', '', '', '', '', '', '');";
                    TransactionID = GS.db.Query(Q, true);

                    if (GS.db.QueryMessage == "success")
                        return TransactionID;
                    else
                        return TransactionID;
                }
                catch { }
                return -1;/// Cant create new transactin
            }/////// End NewTransaction

            public Boolean NewTransaction(Transaction T)
            {
                try
                {
                    string Q = "INSERT INTO " + TransactionTableName
                        + "(`personalId`,`payPrice`,`payAbout`,`payMethod`,`payType`,`payTime`,`payDate`,`status`,`remainaccount`)"
                        + "VALUE("
                        + "'" + T.PersonalID.ToString() + "'"
                        + ",'" + T.Amount.ToString() + "'"
                        + ",'" + T.Description + "'"
                        + ",'" + T.Method.ToString() + "'"
                        + ",'" + T.Type.ToString() + "'"
                        + ",'" + T.Time + "'"
                        + ",'" + T.Date + "'"
                        + ",'" + T.Status.ToString() + "'"
                        + ",'" + T.RemainAccount + "'"
                        + ")";
                    TransactionID = GS.db.Query(Q, true);

                    if (GS.db.QueryMessage == "success")
                        return true;
                    else
                        return false;
                }
                catch { }
                return false;
            }/////// End NewTransaction
            public Boolean UpdateTransaction(Transaction TransactionValue)
            {
                try
                {
                    string Q = "INSERT INTO " + TransactionTableName
                        + "`personalId`='" + TransactionValue.PersonalID + "'"
                        + "`payPrice`='" + TransactionValue.Amount + "'"
                        + "`payAbout`='" + TransactionValue.Description + "'"
                        + "`payMethod`='" + TransactionValue.Method + "'"
                        + "`payType`='" + TransactionValue.Type + "'"
                        + "`payTime`='" + TransactionValue.Time + "'"
                        + "`payDate`='" + TransactionValue.Date + "'"
                        + "`remainaccount`='" + TransactionValue.RemainAccount + "'"
                        ;

                    GS.db.Query(Q);
                    Normalization(TransactionValue.PersonalID);
                    return true;
                }
                catch { }
                return false;
            }
            public Boolean ValidateTransaction(Transaction TransactionValue)
            {
                //string Q = "SELECT * FROM " + TransactionTableName + " WHERE ``='" + TransactionValue.PersonalID.ToString() + "' AND  ``='" + TransactionValue. + "' AND  ``='" + TransactionValue + "' AND ";

                //GS.db.Query();
                return true;
            }

            public double CalcPersonalPriceOfBuy(decimal PersonalID)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.Order + "'"
                + "AND `payType`='" + TransactionType.Order + "'";


                // Q = "SELECT * FROM " + TransactionTableName
                //    + "WHERE `personalId`='" + PersonalID + "' "
                //+ "AND `payMethod`='" + TransactionMethod.Order + "'"
                //+ "AND `payType`='" + TransactionType.Order + "'";


                //DataRowCollection drs = GS.db.Query(Q).Rows;

                //decimal f = 0;
                //foreach(DataRow dr in drs)
                //{
                //    f += Convert.ToDecimal(dr["payPrice"].ToString());
                //}

                try
                {
                    return Convert.ToDouble(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function
            public decimal CalcPersonalPriceOfChequePay(decimal PersonalID)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.doc + "'"
                + "AND `payType`='" + TransactionType.pay + "'";
                try
                {
                    return Convert.ToDecimal(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function
            public double CalcPersonalPriceOfChequePay(decimal PersonalID, decimal NormalazationFor)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                    + "AND `id`<='" + NormalazationFor + "'"
                    + "AND `payMethod`='" + TransactionMethod.doc + "'"
                    + "AND `payType`='" + TransactionType.pay + "'";
                try
                {
                    return Convert.ToDouble(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function
            public decimal CalcPersonalPriceOfCashPay(decimal PersonalID)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.cash + "'"
                + "AND `payType`='" + TransactionType.pay + "'";
                DataTable dt = new DataTable();
                dt = GS.db.Query(Q);
                try
                {
                    if (dt.Rows.Count > 0)
                        return Convert.ToDecimal(dt.Rows[0]["TotPrice"]);
                    else
                        return 0;
                }
                catch
                {
                    return 0;
                }

            }/////// End CalcPersonalAccount Function
            public double CalcPersonalPriceOfCashPay(decimal PersonalID, decimal NormalazationFor)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                    + "AND `id`<='" + NormalazationFor + "'"
                    + "AND `payMethod`='" + TransactionMethod.cash + "'"
                    + "AND `payType`='" + TransactionType.pay + "'";
                DataTable dt = new DataTable();
                dt = GS.db.Query(Q);
                try
                {
                    if (dt.Rows.Count > 0)
                        return Convert.ToDouble(dt.Rows[0]["TotPrice"]);
                    else
                        return 0;
                }
                catch
                {
                    return 0;
                }

            }/////// End CalcPersonalAccount Function
            public decimal CalcPersonalPriceOfCashGet(decimal PersonalID)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.cash + "'"
                + "AND `payType`='" + TransactionType.get + "'";
                try
                {
                    return Convert.ToDecimal(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function
            public double CalcPersonalPriceOfCashGet(decimal PersonalID, decimal NormalazationFor)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                    + "AND `id`<='" + NormalazationFor + "'"
                    + "AND `payMethod`='" + TransactionMethod.cash + "'"
                    + "AND `payType`='" + TransactionType.get + "'";
                try
                {
                    return Convert.ToDouble(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function
            public decimal CalcPersonalPriceOfChequeGet(decimal PersonalID)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.doc + "'"
                + "AND `payType`='" + TransactionType.get + "'";
                try
                {
                    return Convert.ToDecimal(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function
            public double CalcPersonalPriceOfChequeGet(decimal PersonalID, decimal NormalazationFor)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                    + "AND `id`<='" + NormalazationFor + "'"
                + "AND `payMethod`='" + TransactionMethod.doc + "'"
                + "AND `payType`='" + TransactionType.get + "'";
                try
                {
                    return Convert.ToDouble(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function
            public double CalcPersonalPriceOfOldPay(decimal PersonalID)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.Old + "'"
                + "AND `payType`='" + TransactionType.pay + "'";
                try
                {
                    return Convert.ToDouble(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function
            public decimal CalcPersonalPriceOfOldRemainAccount(decimal PersonalID)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.Old + "'"
                + "AND `payType`='" + TransactionType.RemainAccount + "'";
                try
                {
                    DataTable dtORA = GS.db.Query(Q);
                    if (dtORA != null && dtORA.Rows.Count > 0)
                        return Convert.ToDecimal(dtORA.Rows[0]["TotPrice"].ToString());
                    else
                        return 0;
                }
                catch (Exception e)
                {

                    return 0;
                }
            }/////// End CalcPersonalAccount Function
            public double CalcPersonalPriceOfOldRemainAccount(decimal PersonalID, decimal NormalazationFor)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                    + "AND `id`<='" + NormalazationFor + "'"
                    + "AND `payMethod`='" + TransactionMethod.Old + "'"
                    + "AND `payType`='" + TransactionType.RemainAccount + "'";
                try
                {
                    DataTable dtORA = GS.db.Query(Q);
                    if (dtORA != null && dtORA.Rows.Count > 0)
                        return Convert.ToDouble(dtORA.Rows[0]["TotPrice"].ToString());
                    else
                        return 0;
                }
                catch (Exception e)
                {

                    return 0;
                }
            }/////// End CalcPersonalAccount Function

            public decimal GetAllBuy(decimal PersonalID)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.Order + "'"
                + "AND `payType`='" + TransactionType.Order + "'";
                try
                {
                    return Convert.ToDecimal(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function

            public double GetAllBuy(decimal PersonalID, decimal NormalazationFor)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                    + "AND `id`<='" + NormalazationFor + "'"
                    + "AND `payMethod`='" + TransactionMethod.Order + "'"
                    + "AND `payType`='" + TransactionType.Order + "'"
                    + "ORDER BY `id` ASC";

                try
                {
                    return Convert.ToDouble(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function


            public double GetAllSell(decimal PersonalID, decimal NormalazationFor)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                    + "AND `id`<='" + NormalazationFor + "'"
                    + "AND `payMethod`='" + TransactionMethod.Order + "'"
                    + "AND `payType`='" + TransactionType.Buy + "'"
                    + "ORDER BY `id` ASC";

                try
                {
                    return Convert.ToDouble(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function

            public decimal GetAllSell(decimal PersonalID)
            {
                string Q = "SELECT SUM(`payPrice`) as TotPrice FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.Order + "'"
                + "AND `payType`='" + TransactionType.Buy + "'";
                try
                {
                    return Convert.ToDecimal(GS.db.Query(Q).Rows[0]["TotPrice"]);
                }
                catch
                {
                    return 0;
                }
            }/////// End CalcPersonalAccount Function


            public decimal GetAllPay(decimal PersonalID)
            {
                return this.CalcPersonalPriceOfCashPay(PersonalID) + this.CalcPersonalPriceOfChequePay(PersonalID);
            }
            public double GetAllPay(decimal PersonalID, decimal NormalazationFor)
            {
                return this.CalcPersonalPriceOfCashPay(PersonalID, NormalazationFor) + this.CalcPersonalPriceOfChequePay(PersonalID, NormalazationFor);
            }
            public DataTable GetPay(decimal PersonalID, decimal PayId)
            {
                string Q = "SELECT * FROM " + TransactionTableName
                + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `id`='" + PayId + "'";

                return GS.db.Query(Q);
            }
            public DataTable GetAllPayList(decimal PersonalID)
            {
                string Q = "SELECT * FROM " + TransactionTableName
                + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payType`='" + TransactionType.pay + "'";

                return GS.db.Query(Q);
            }
            public DataTable GetAllPayListOfCash(decimal PersonalID)
            {
                string Q = "SELECT * FROM " + TransactionTableName
                + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payType`='" + TransactionType.pay + "'"
                + "AND `payMethod`='" + TransactionMethod.cash + "'";

                return GS.db.Query(Q);
            }
            public decimal GetAllGet(decimal PersonalID)
            {
                return this.CalcPersonalPriceOfCashGet(PersonalID) + this.CalcPersonalPriceOfChequeGet(PersonalID);
            }
            public double GetAllGet(decimal PersonalID, decimal NormalazationFor)
            {
                return this.CalcPersonalPriceOfCashGet(PersonalID, NormalazationFor) + this.CalcPersonalPriceOfChequeGet(PersonalID, NormalazationFor);
            }
            public decimal RemainAccount(decimal PersonalID)
            {
                decimal RemainAccountT = (this.GetAllBuy(PersonalID) - this.GetAllSell(PersonalID) + this.GetAllGet(PersonalID) + CalcPersonalPriceOfOldRemainAccount(PersonalID)) - (this.GetAllPay(PersonalID));
                return RemainAccountT;
            }

            public double RemainAccount(decimal PersonalID, decimal NormalazationFor)
            {

                double RemainAccountT = (this.GetAllBuy(PersonalID, NormalazationFor) - (this.GetAllSell(PersonalID, NormalazationFor) )+ this.GetAllGet(PersonalID, NormalazationFor) + CalcPersonalPriceOfOldRemainAccount(PersonalID, NormalazationFor)) - (this.GetAllPay(PersonalID, NormalazationFor));
                return RemainAccountT;
            }

            public Boolean delete(decimal TransactionID)
            {
                try
                {
                    GS.db.Query("DELETE FROM `accounting` WHERE `id`='" + TransactionID.ToString() + "'");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            public int delete(string TransactionDescription)
            {
                try
                {
                    GS.db.Query("DELETE FROM `accounting` WHERE `payAbout`='" + TransactionDescription + "'");
                    return 1;//// Delete Success
                }
                catch
                {
                    return 0;/// Delete Failde
                }
            }

            public DataTable GetOldRemainAccountList(decimal PersonalID)
            {

                string Q = "SELECT * FROM " + TransactionTableName
                    + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `payMethod`='" + TransactionMethod.Old + "'"
                + "AND `payType`='" + TransactionType.RemainAccount + "'";

                return GS.db.Query(Q);
            }

            public DataTable Select(decimal TransactionID, decimal PersonalID)
            {
                string Q = "SELECT * FROM " + TransactionTableName
                + "WHERE `personalId`='" + PersonalID + "' "
                + "AND `id`='" + TransactionID + "'";

                return GS.db.Query(Q);
            }
            public DataTable Select(decimal TransactionID)
            {
                string Q = "SELECT * FROM " + TransactionTableName
                + "WHERE `id`='" + TransactionID + "'";

                return GS.db.Query(Q);
            }
        } //// End Transaction Class

        public class Transaction
        {
            //int transactionID { set; get; }

            public decimal PersonalID { set; get; }
            public decimal Amount { set; get; }
            public string Description { set; get; }
            public TransactionMethod Method { set; get; }
            public TransactionType Type { set; get; }
            public string Time { set; get; }
            public string Date { set; get; }
            /// <summary>
            /// status:Specifies personal creditor or debtor
            /// </summary>
            public byte Status { get; set; }
            public decimal RemainAccount { set; get; }

        }//////// End TransactionType Class

    }///// End ITransaction Interface
}
