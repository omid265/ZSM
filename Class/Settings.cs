using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Generals;

namespace ManoloSellManager.Class
{
    class Settings
    {
        static Generals GS = Generals.CreateGenerals();

        public static decimal GetInchToCentimeter
        {
            set { }
            get
            {
                return readInchToCentimeter();
            }
        }
        static string DBName = "`" + ConfigFile.GetConfig().DatabaseConfig().DatabaseName + "`.";

        private static decimal readInchToCentimeter()
        {
            DataTable dtSettings = new DataTable();
            dtSettings = GS.db.Query("SELECT * FROM " + DBName + "`setting` WHERE `SettingName`='InchToCM' ");
            if (dtSettings == null)
            {
                return 0;
            }
            if (dtSettings.Rows.Count == 1)
            {
                return Convert.ToDecimal(dtSettings.Rows[0]["SettingValue"].ToString());
            }
            else
            {
                return Convert.ToDecimal(6.25);
            }
        }


        public static string GetCompanyPhone
        {
            set { }
            get
            {
                return readCompanyPhone();
            }
        }

        private static string readCompanyPhone()
        {
            DataTable dtSettings = new DataTable();
            dtSettings = GS.db.Query("SELECT * FROM " + DBName + "`setting` WHERE `SettingName` like '%CompanyPhone%' ");
            if (dtSettings.Rows.Count == 1)
            {
                return dtSettings.Rows[0]["SettingValue"].ToString();
            }
            return null;

        }


        public static string GetCompanyName
        {
            set { }
            get
            {
                return readCompanyName();
            }
        }
        public static Boolean GetSendSMSRegisterOrder
        {
            set { }
            get
            {
                return readSendSMSRegisterOrder();
            }
        }
        public static string GetSMSTextRegisterOrder
        {
            set { }
            get
            {
                return readSmsTextRegisterOrder();
            }
        }

        /// <summary>
        /// PWSRAPI = Print WorkShop Report After Print Invoice
        /// </summary>
        public static Boolean GetPWSRAPI
        {
            set { }
            get
            {
                return readPWSRAPI();
            }
        }



        private static string readCompanyName()
        {
            DataTable dtSettings = new DataTable();
            dtSettings = GS.db.Query("SELECT * FROM " + DBName + "`setting` WHERE `SettingName` like '%CompanyName%' ");
            if (dtSettings.Rows.Count == 1)
            {
                return dtSettings.Rows[0]["SettingValue"].ToString();
            }
            return null;

        }
        private static string readSmsTextRegisterOrder()
        {
            DataTable dtSettings = new DataTable();
            dtSettings = GS.db.Query("SELECT * FROM " + DBName + "`setting` WHERE `SettingName` like '%SMSTextRegisterOrder%' ");
            if (dtSettings.Rows.Count == 1)
            {
                return dtSettings.Rows[0]["SettingValue"].ToString();
            }
            return null;

        }

        private static Boolean readSendSMSRegisterOrder()
        {
            DataTable dtSettings = new DataTable();
            dtSettings = GS.db.Query("SELECT * FROM " + DBName + "`setting` WHERE `SettingName` like '%SendSMSRegisterOrder%' ");
            if (dtSettings.Rows.Count == 1)
            {
                return Convert.ToBoolean(dtSettings.Rows[0]["SettingValue"].ToString());
            }
            return false;

        }
        /// <summary>
        /// Print Workshop Report After Print Invoice
        /// </summary>
        /// <returns></returns>
        private static Boolean readPWSRAPI()
        {
            DataTable dtSettings = new DataTable();
            dtSettings = GS.db.Query("SELECT * FROM " + DBName + "`setting` WHERE `SettingName` like '%PWSRAPI%' ");
            if (dtSettings.Rows.Count == 1)
            {
                return Convert.ToBoolean(dtSettings.Rows[0]["SettingValue"].ToString());
            }
            return false;

        }
    }//// end Settings Class
}
