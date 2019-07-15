using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DatabaseManager;
namespace ManoloSellManager.Class
{
    public sealed class Products
    {
        #region SingleTon
        private static volatile Products ProductManager;
        private static object _lock = new object();
        private Products() { }
        public static Products products()
        {
            if (ProductManager == null)
            {
                lock (_lock)
                {
                    if (ProductManager == null)
                    {
                        ProductManager = new Products();
                    }
                }
            }
            return ProductManager;
        }
        #endregion

        static Generals GS = Generals.CreateGenerals();
        static DB db = DB.CreateDBManager();
        public int GetLastProductCode
        {
            private set { }
            get
            {
                return Convert.ToInt16(ReadLastProductCode());
            }
        }

        private String ReadLastProductCode()
        {
            //// dtGLP=Data Table Get Last Product Code
            DataTable dtGLPC = new DataTable();

            string Query = "SELECT `itemCode` FROM `store` ORDER BY `itemCode` DESC";
            dtGLPC = GS.db.Query(Query);
            //GetLastProductCode = 0;
            string C = "";
            int C2 = 0;

            if (dtGLPC.Rows.Count > 0)
            {
                C = dtGLPC.Rows[0]["itemCode"].ToString();
                C2 = Convert.ToInt16(C);
                C2++;
            }
            else
            {
                C2 = 100;
            }

            return C2.ToString();

        }


        public static class Items
        {

            /// <summary>
            /// Add new item at Store Table.
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            public static int Add(Product item)
            {
                var c = getItems(item);
                if ( c != null)
                {
                    if (c.Count > 0)
                    {
                        return 2;/// 2 = Item Exist
                    }
                    else if(c.Count!=0)
                    {
                        return -1;/// undefiend result
                    }
                    else
                    {
                        string q = string.Format(@"INSERT INTO `store` (`itemName`,`itemUnit`,`itemPrice`,`itemLimiter`,`itemStoreControler`,`itemCode`,`itemStatus`) " +
                      "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','')", item.Name, item.Unit, item.Price, item.Limiter, item.StoreControl,item.Code, item.Status);

                        db.Query(q, true);

                        return 0;/// job is done
                    }
                }
                else
                {
                    string q = string.Format(@"INSERT INTO `store` (`itemName`,`itemUnit`,`itemPrice`,`itemLimiter`,`itemStoreControler`,`itemCode`,`itemStatus`) " +
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','')", item.Name, item.Unit, item.Price, item.Limiter, item.StoreControl, item.Status);
                    db.Query(q, true);
                    return 0;/// job is done
                }


            }//End AddNew function
            public static int Update(Product item)
            {
                ///UPDATE `store` SET `itemName` = 'سقف کاذب آلمينيومی', `itemUnit` = '1', `itemPrice` = '1000' WHERE `store`.`id` = 1;
                GS.db.Query(string.Format(@"UPDATE `store` SET 
                                        `itemName` = '{0}'
                                        , `itemUnit` = '{1}'
                                        , `itemPrice` = '{2}' 
                                        , `itemLimiter` = '{3}' 
                                        , `itemStoreControler` = '{4}' 
                                        , `itemCode` = '{5}' 
                                        WHERE `store`.`itemCode` = {6};", item.Name, item.Unit, item.Price, item.Limiter, item.StoreControl, item.Code, item.Code));
                return 0;
            }
            public static int Update(int ItemCode,int ItemCount,string ItemPrice)
            {
                ///UPDATE `store` SET `itemName` = 'سقف کاذب آلمينيومی', `itemUnit` = '1', `itemPrice` = '1000' WHERE `store`.`id` = 1;
                GS.db.Query(string.Format(@"UPDATE `store` SET 
                                        `itemPrice` = '{0}'  
                                        , `itemStoreControler` = '{1}' 
                                        WHERE `store`.`itemCode` = {2};", ItemPrice, ItemCount, ItemCode));
                return 0;
            }
            public static int Update(int ID,Product item)
            {
                ///UPDATE `store` SET `itemName` = 'سقف کاذب آلمينيومی', `itemUnit` = '1', `itemPrice` = '1000' WHERE `store`.`id` = 1;
                GS.db.Query(string.Format(@"UPDATE `store` SET 
                                        `itemName` = '{0}'
                                        , `itemUnit` = '{1}'
                                        , `itemPrice` = '{2}' 
                                        , `itemLimiter` = '{3}' 
                                        , `itemStoreControler` = '{4}' 
                                        , `itemCode` = '{5}' 
                                        WHERE `store`.`id` = {6};", item.Name, item.Unit, item.Price, item.Limiter, item.StoreControl, item.Code, ID.ToString()));
                return 0;
            }
            public static int Delete()
            {
                return 0;
            }
            public static List<Product> getItems(Product item)
            {

                DataTable result = db.Query(string.Format("SELECT * FROM `store` WHERE `itemName`='{0}' OR `itemCode`='{1}'", item.Name, item.Code));
                int ResultCount = DB.CreateDBManager().ResultCount;
                if (result == null)
                {
                    return null;
                }
                List<Product> p = new List<Product>();

                foreach (DataRow r in result.Rows)
                {
                    Product pt = new Product();
                    pt.Code = r["itemCode"].ToString();
                    pt.Name = r["itemName"].ToString();
                    pt.ID = Convert.ToInt32(r["id"]);
                    pt.Limiter = r["itemLimiter"].ToString();
                    pt.Limiter = r["itemPrice"].ToString();
                    pt.Limiter = r["itemStoreControler"].ToString();
                    p.Add(pt);
                }
                //if (==0)
                return p;
            }
        }/// End Items Class
        public class Product
        {
            public int? ID { set; get; }
            public string Code { set; get; }
            public string Name { set; get; }
            public string Price { set; get; }
            public string Unit { set; get; }
            public string Limiter { set; get; }
            public string StoreControl { set; get; }
            public string Status { set; get; }
        }//// End Product Class
    }//// end main class
}
