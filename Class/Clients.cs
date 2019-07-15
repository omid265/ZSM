using System;
using System.Collections.Generic;
using System.Data;

namespace ManoloSellManager.Class
{
    public class Clients
    {
        static Generals GS = Generals.CreateGenerals();


        public DataTable getClientsList(string Condition)
        {
            string sQ = "SELECT * FROM `personals` " + GS.SafeFarsiStr(Condition);
            DataTable dt = new DataTable();
            dt = GS.db.Query(sQ);
            if (dt == null)
            {
                return null;
            }
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return dt;
        }


        public Client getClientByID(int ID)
        {
            //return ConvertToPerson(getData("`id`='" + ID.ToString() + "'");
            return getpersons("WHERE `id`='" + ID.ToString() + "'")[0];
        }

        public Client ConvertToPerson(DataRow dr)
        {

            Client p = new Client();
            p.ID = Convert.ToInt32(dr["id"].ToString());
            p.mobile = dr["mobile"].ToString();
            p.name = GS.SafeFarsiStr(dr["name"].ToString());
            p.nickName = GS.SafeFarsiStr(dr["nickName"].ToString());
            p.phone = dr["phone"].ToString();
            p.type =Clients.ConvertClientType(dr["type"].ToString());
            p.Address = GS.SafeFarsiStr(dr["address"].ToString());
            p.CompanyAddress = GS.SafeFarsiStr(dr["CompanyAddress"].ToString());
            p.CompanyName = GS.SafeFarsiStr(dr["CompanyName"].ToString());
            p.CompanyPhone = dr["CompanyPhone"].ToString();
            p.Fax = dr["Fax"].ToString();
            return p;

        }
        /// <summary>
        /// Return list off all clients on clients table
        /// </summary>
        /// <returns></returns>
        public List<Client> getClients(string Limit = "")
        {
            if (!string.IsNullOrEmpty(Limit))
            {
                Limit = " LIMIT " + Limit;
            }

            return getpersons(Limit);
        }

        /// <summary>
        /// return list of some client, filter client using filter variable and limit the result count using Limit parameter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="Limit">Limit Result rows e.g 5 - 5,10 - 10,30</param>
        /// <returns></returns>
        public List<Client> getClients(string filter, string Limit = "")
        {
            if (!string.IsNullOrEmpty(Limit))
            {
                Limit = " LIMIT " + Limit;
            }

            string sQ = "WHERE `id` Like '%#%' OR `name` LIKE '%#%' OR `nickName` LIKE '%#%' OR `CompanyName` LIKE '%#%' OR `phone` LIKE '%#%' OR `mobile` LIKE '%#%' OR `CompanyPhone` LIKE '%#%' OR `Fax`  LIKE '%#%' OR `address`  LIKE '%#%' OR `CompanyName` LIKE '%#%' OR `type` LIKE '%#%'".Replace("#", GS.SafeFarsiStr(filter));
            sQ += Limit;
            return getpersons(sQ);
        }
        public DataTable getClients(ClientType type)
        {
            if (type == ClientType.All)
            {
                return getClientsList(" ORDER BY `name`");
            }
            else
            {
                return getClientsList("WHERE `type`='" + (int)type + "'");
            }
        }

        public List<Client> getpersons(string Condition)
        {
            List<Client> pL = new List<Client>();
            foreach (DataRow dr in getClientsList(Condition).Rows)
            {
                pL.Add(ConvertToPerson(dr));
            }
            return pL;
        }

        public enum ClientType:Int32
        {
            Customer=1,
            Seller=2,
            All=3,
            Employee = 4
        }

        public static string ConvertClientType(int Type)
        {
            switch (Type)
            {
                case 1:
                    return "مشتری";

                case 2:
                    return "فروشنده";
                case 3:
                    return "";
                case 4:
                    return "کارمند";
                default:
                    return "مشتری";
            }
        }


        public static string ConvertClientType(ClientType Type)
        {
            switch (Type)
            {
                case ClientType.Customer:
                    return "مشتری";

                case ClientType.Seller:
                    return "فروشنده";
                case ClientType.Employee:
                    return "کارمند";
                case ClientType.All:
                    return "";
                default:
                    return "مشتری";
            }
        }
        public static ClientType ConvertClientType(string Type)
        {
            if (GS.IsNumber(Type))
            {
                Type = ConvertClientType(Convert.ToInt32(Type));
            }
            switch (Type)
            {
                case "مشتری":
                    return ClientType.Customer;
                case "فروشنده":
                    return ClientType.Seller;
                case "کارمند":
                    return ClientType.Employee;
                case "":
                    return ClientType.All;
                default:
                    return ClientType.Customer;
            }
        }



        public static class Items
        {
            public static int Add(Client c)
            {
                DataTable dtNew = GS.db.Query("INSERT INTO `personals"
               + "`(`name`,`nickName`,`CompanyName`,`phone`,`mobile`,`CompanyPhone`,`Fax`,`address`,`CompanyAddress`,`type`)"
               + "VALUE("
               + "'" + GS.SafeFarsiStr(c.name) + "'"
               + ",'" + GS.SafeFarsiStr(c.nickName) + "'"
               + ",'" + GS.SafeFarsiStr(c.CompanyName) + "'"
               + ",'" + c.phone + "'"
               + ",'" + c.mobile + "'"
               + ",'" + c.CompanyPhone + "'"
               + ",'" + c.Fax + "'"
               + ",'" + GS.SafeFarsiStr(c.Address) + "'"
               + ",'" + GS.SafeFarsiStr(c.CompanyAddress) + "'"
               + ",'" + (int)c.type + "'"
               + ")");

                return 0;
            }
            public static int Update(Client c)
            {
                if (c.ID == 0)
                {
                    return 1;//// 1= Client Id Is not set
                }
                string q = string.Format(@"UPDATE `personals` SET 
                                            `name` = '{0}',
                                            `nickName` = '{1}',
                                            `CompanyName` = '{2}',
                                            `phone` = '{3}',
                                            `mobile` = '{4}',
                                            `CompanyPhone` = '{5}',
                                            `Fax` = '{6}',
                                            `address` = '{7}',
                                            `type` = '{8}',
                                            `CompanyAddress` = '{9}'
                                            WHERE `personals`.`id` = '{10}';",
                                            GS.SafeFarsiStr(c.name),
                                            GS.SafeFarsiStr(c.nickName),
                                            GS.SafeFarsiStr(c.CompanyName),
                                            c.phone, c.mobile,
                                            c.CompanyPhone, c.Fax,
                                            GS.SafeFarsiStr(c.Address),
                                            (int)c.type,
                                            GS.SafeFarsiStr(c.CompanyAddress),
                                            c.ID);
                DataTable dtUpdate = GS.db.Query(q);
                return 0;//// All Job is completed successfuly
            }
            public static int Delete(Client c)
            {
                string q = string.Format(@"DELETE FROM `personals` WHERE `personals`.`id` = '{0}'", c.ID);
                return GS.db.Query(q, true);
            }
            public static int Delete(int ClientID)
            {
                if (ClientID == 0)
                {
                    string q = string.Format(@"DELETE FROM `personals` WHERE `personals`.`id` = '{0}'", ClientID);
                    return GS.db.Query(q, true);
                }
                else
                {
                    return -1;
                }
            }
        }
        public class Client
        {
            public int ID { set; get; }
            public string name { set; get; }
            public string nickName { set; get; }
            public string CompanyName { set; get; }
            public string phone { set; get; }
            public string mobile { set; get; }
            public string CompanyPhone { set; get; }
            public string Fax { set; get; }
            public string Address { set; get; }
            public string CompanyAddress { set; get; }
            public ClientType type { set; get; }

            public string TypeToString()
            {
                return ConvertClientType(this.type);
            }

            public DataTable ToDatatable()
            {
                if (string.IsNullOrEmpty(ID.ToString()))
                {
                    return null;
                }

                try
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.TableName = "personals";
                    dt.Columns.Add("ID");
                    dt.Columns.Add("name");
                    dt.Columns.Add("nickName");
                    dt.Columns.Add("CompanyName");
                    dt.Columns.Add("phone");
                    dt.Columns.Add("mobile");
                    dt.Columns.Add("CompanyPhone");
                    dt.Columns.Add("Fax");
                    dt.Columns.Add("address");
                    dt.Columns.Add("CompanyAddress");
                    dt.Columns.Add("type");
                    dt.Rows.Add(ID, name, nickName, CompanyName, phone, mobile, CompanyPhone, Fax, Address, CompanyAddress, type);
                    return dt;
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
