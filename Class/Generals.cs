using System;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
using DatabaseManager;
using Generals;

namespace ManoloSellManager.Class
{
    public sealed class Generals
    {
        #region SingelTone Design Pattern
        private static volatile Generals instance;
        private static object _lock = new object();
        private Generals() { }
        public static Generals CreateGenerals()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Generals();
                    }
                }
            }
            return instance;
        }
        #endregion
        
        public DB db = DB.CreateDBManager();
        public Dialog dialog = Dialog.CreateDialog();
        public DateManager dateManager = DateManager.GetDate();

        public void Backup(string sBackupPath = "", string sBackUpFileName = "",bool beforeUpdate=false)
        {
            if (string.IsNullOrEmpty(sBackupPath))
            {
                string backUpPath = AppPath.dbBackup;
                if (beforeUpdate == true)
                {
                    backUpPath += "\\beforeUpdate";
                }

                if (!Directory.Exists(backUpPath))
                {
                    Directory.CreateDirectory(backUpPath);
                }
                string file = AppPath.dbBackupFileName;
                



                db.Backup(backUpPath, file);
                if(db.QueryMessage== "Unable to connect to any of the specified MySQL hosts.")
                {
                    string messageCaption = "خطای شماره : b001352 در اتصال به بانک اطلاعاتی ";


                    MessageBox.Show("امکان برقراری ارتباط با بانک اطلاعاتی ممکن نیست\n لطفا سرویس Mysql را کنترل کنید و یا کامپیوتر را مجددا راه اندازی کنید.", messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign|MessageBoxOptions.RtlReading);
                    Application.Exit();
                }
            }
            else
            {
                db.Backup(sBackupPath, sBackUpFileName);
            }
        }///// End backup Function

        public string SafeFarsiStr(string input)
        {
            if (string.IsNullOrEmpty(input)||string.IsNullOrWhiteSpace(input))
            {
                return "";
            }

            return input.Replace("ی", "ي");
        }

        public void GoToNextRow(DataGridView dataGridView, Keys keys)
        {
            switch (keys)
            {
                case Keys.Down:
                    int i = dataGridView.CurrentRow.Index;
                    i = i + 1;
                    if (i < 0)
                    {
                        i = 0;
                    }
                    if (i > dataGridView.Rows.Count - 1)
                    {
                        i = dataGridView.Rows.Count - 1;
                    }

                    dataGridView.CurrentCell = dataGridView[1, i];

                    break;
                case Keys.Up:
                    int i2 = dataGridView.CurrentRow.Index;
                    i2 = i2 - 1;
                    if (i2 < 0)
                    {
                        i2 = 0;
                    }
                    if (i2 > dataGridView.Rows.Count - 1)
                    {
                        i2 = dataGridView.Rows.Count - 1;
                    }

                    dataGridView.CurrentCell = dataGridView[1, i2];

                    break;
            }
        }


        public Boolean IsNumber(string Numbers)
        {
            try
            {
                Int64 INV = Convert.ToInt64(Numbers);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Make Thousand separator for Number.
        /// this funtion return string
        /// </summary>
        /// <param name="numbers">Sample 1000000</param>
        /// <returns>sample: 1,000,000</returns>
        public string nf(string numbers)
        {
            NumberFormatInfo nfi = new CultureInfo("fa-IR", false).NumberFormat;
            nfi.NumberDecimalDigits = 0;
            // Displays a value with the default separator (".").
            double myInt;
            if (numbers.Length > 0)
                myInt = Convert.ToDouble(numbers);
            else
                myInt = 0;

            var PP = myInt.ToString("n", nfi);
            return PP.ToString();
            /*
            // Displays the same value with a blank as the separator.
            nfi.NumberDecimalSeparator = " ";
            return myInt.ToString("N", nfi);
              */
        }
       
    }///// End Generals Class
    //public static class AppPath
    //{
    //    public static DateManager dateManager = DateManager.GetDate();
    //    public static string Root
    //    {
    //        get { return Application.StartupPath + "\\"; }
    //    }
    //    public static string dbBackup
    //    {
    //        get { return Application.StartupPath + "\\dbBackup"; }
    //    }
    //    public static string dbBackupFileName
    //    {
    //        get
    //        {
    //            string Min = DateTime.Now.TimeOfDay.Minutes.ToString();
    //            string ch = DateTime.Now.TimeOfDay.Hours.ToString();
    //            return dateManager.GetCurrentPersianDate("-") + "-" + ch + "-" + Min + ".sql";
    //        }
    //    }
    //}
}
