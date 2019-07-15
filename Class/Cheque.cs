using System;
using System.Collections.Generic;
using System.Data;

namespace ManoloSellManager.Class
{
    public class Cheques
    {
       static Generals  GS = Generals.CreateGenerals();


        public DataTable getChequesList(string Condition)
        {
            string sQ = "SELECT * FROM `personals` " + Condition;
            DataTable dt = new DataTable();
            dt = GS.db.Query(sQ);
            if(dt == null)
            {
                return null;
            }
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return dt;
        }

        public Cheque getCheque(int ID)
        {
            //return ConvertToPerson(getData("`id`='" + ID.ToString() + "'");
            return getChequeByCondition("WHERE `id`='" + ID.ToString() + "'")[0];
        }

        public Cheque ConvertToCheque(DataRow dr)
        {
           
            Cheque p = new Cheque();
            //p.ID = Convert.ToInt32(dr["id"].ToString());
            //p.mobile = dr["mobile"].ToString();
            //p.name = dr["name"].ToString();
            //p.nickName = dr["nickName"].ToString();
            //p.phone = dr["phone"].ToString();
            //p.type = dr["type"].ToString();
            //p.Address = dr["address"].ToString();
            //p.CompanyAddress = dr["CompanyAddress"].ToString();
            //p.CompanyName = dr["CompanyName"].ToString();
            //p.CompanyPhone = dr["CompanyPhone"].ToString();
            //p.Fax = dr["Fax"].ToString();
            return p;

        }
        /// <summary>
        /// Return list off all Cheques on Cheques table
        /// </summary>
        /// <returns></returns>
        public List<Cheque> getCheques(string Limit="")
        {
            if (!string.IsNullOrEmpty(Limit))
            {
                Limit = " LIMIT " + Limit;
            }

            return getChequeByCondition(Limit);
        }

        /// <summary>
        /// return list of some Cheque, filter Cheque using filter variable and limit the result count using Limit parameter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="Limit">Limit Result rows e.g 5 - 5,10 - 10,30</param>
        /// <returns></returns>
        public List<Cheque> getCheques(string filter, string Limit="")
        {
            if (!string.IsNullOrEmpty(Limit))
            {
                Limit = " LIMIT " + Limit;
            }

            string sQ = "WHERE `id` Like '%#%' OR `name` LIKE '%#%' OR `nickName` LIKE '%#%' OR `CompanyName` LIKE '%#%' OR `phone` LIKE '%#%' OR `mobile` LIKE '%#%' OR `CompanyPhone` LIKE '%#%' OR `Fax`  LIKE '%#%' OR `address`  LIKE '%#%' OR `CompanyName` LIKE '%#%' OR `type` LIKE '%#%'".Replace("#",filter);
            sQ += Limit;
            return getChequeByCondition(sQ);
        }
        public DataTable getCheques(int type)
        {
            if (type == ChequeType.All)
            {
                return getChequesList(" ORDER BY `name`");
            }
            else
            {
                return getChequesList("WHERE `type`='" + type + "'");
            }
        }
        public DataTable getCheques(Clients.Client C)
        {
            if (C.type == Clients.ClientType.All)
            {
                return getChequesList(" ORDER BY `name`");
            }
            else
            {
                return getChequesList("WHERE `payer`='" + C.ID + "'");
            }
        }

        public List<Cheque> getChequeByCondition(string Condition)
        {
            List<Cheque> pL = new List<Cheque>();
            foreach (DataRow dr in getChequesList(Condition).Rows)
            {
                pL.Add(ConvertToCheque(dr));
            }
            return pL;
        }
        

        public class ChequeType
        {
            public static int Recive = 1;
            public static int Pay =2;
            public static int All = 3;
        }
        public static class Items
        {
            public static int Add(Cheque c)
            {
                string q = string.Format(@"INSERT INTO `cheque` (`id`, `serial`, `price`, `bankname`, `duedate`, `paydate`, `payto`, `type`,`description`,`payer`) VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}','{8}');",
                    c.Serial,
                    c.Price,
                    c.BankName,
                    c.DueDate,
                    c.PayDate,
                    c.PayTo,
                    c.Type,
                    c.Description,
                    c.Payer);
                //DataTable dtNew = GS.db.Query(q);
                return GS.db.Query(q,true);
            }
            public static int Update(Cheque c)
            {
                string q = string.Format(@"UPDATE `cheque` SET 
                                        `serial` = '{0}',
                                        `price` = '{1}',
                                        `bankname` = '{2}',
                                        `duedate` = '{3}',
                                        `paydate` = '{4}',
                                        `payto` = '{5}',
                                        `type` = '{6}', 
                                        `description` = '{7}',
                                        `description` = '{8}'
                                        WHERE `cheque`.`id` = '{9}';",
                                        c.Serial,c.Price,c.BankName,c.DueDate,c.PayDate,c.PayTo,c.Type,c.Description,c.Payer,c.ID);

                DataTable dtUpdate= GS.db.Query(q);
                return 0;
            }
            public static int Delete(Cheque c)
            {
                string q = string.Format(@"DELETE FROM `cheque` WHERE `cheque`.`id` = '{0}'",c.ID);
                return GS.db.Query(q, true);
            }
        }
        public class Cheque
        {
            public int ID { set; get; }
            public string Serial{ set; get; }
            public Decimal Price { set; get; }
            public string BankName { set; get; }
            public string DueDate { set; get; }
            public string PayDate { set; get; }
            public int PayTo { set; get; }
            public int Payer { set; get; }
            public int Type{ set; get; }
            public string Description { set; get; }
            public DataTable ToDatatable()
            {
                //if (string.IsNullOrEmpty(ID.ToString()))
                //{
                //    return null;
                //}

                //try
                //{
                //    DataTable dt = new DataTable();
                //    dt.Clear();
                //    dt.TableName = "personals";
                //    dt.Columns.Add("ID");
                //    dt.Columns.Add("name");
                //    dt.Columns.Add("nickName");
                //    dt.Columns.Add("CompanyName");
                //    dt.Columns.Add("phone");
                //    dt.Columns.Add("mobile");
                //    dt.Columns.Add("CompanyPhone");
                //    dt.Columns.Add("Fax");
                //    dt.Columns.Add("address");
                //    dt.Columns.Add("CompanyAddress");
                //    dt.Columns.Add("type");
                //    dt.Rows.Add(ID, name, nickName, CompanyName, phone, mobile, CompanyPhone, Fax, Address, CompanyAddress, type);
                //    return dt;
                //}
                //catch
                //{
                //    return null;
                //}
                return null;
            }
        }

    }
}
