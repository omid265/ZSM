using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using Generals.controls;
using System.IO;
using Newtonsoft.Json;
using Kavenegar.Models;
using System.Text.RegularExpressions;

namespace Generals
{

    public sealed class DateManager
    {
        #region Singletone Section
        private static volatile DateManager DateMGR;
        private static object _lock = new object();
        private DateManager() { }

        public static DateManager GetDate()
        {
            if (DateMGR == null)
            {
                lock (_lock)
                {
                    if (DateMGR == null)
                    {
                        DateMGR = new DateManager();
                    }
                }
            }
            return DateMGR;
        }
        #endregion

        /// <summary>
        /// Persian Date Object
        /// </summary>
        public PersianDatePicker pdp = new PersianDatePicker();

        /// <summary>
        /// Persian Calender
        /// </summary>
        public PersianCalendar PC = new PersianCalendar();
        public DateTime CurrentDate = DateTime.Now;

        /// <summary>
        /// Return Current Persian Date
        /// </summary>
        /// <param name="DateSeperator"></param>
        /// <returns></returns>
        public string GetCurrentPersianDate(string DateSeperator = "/")
        {
            string CM = this.PC.GetMonth(this.CurrentDate).ToString();
            string CD = this.PC.GetDayOfMonth(this.CurrentDate).ToString();
            if (CM.Length < 2)
                CM = "0" + CM;

            if (CD.Length < 2)
                CD = "0" + CD;

            return this.PC.GetYear(this.CurrentDate) + DateSeperator + CM + DateSeperator + CD;
        }
        public string OrderDate(DateTime YourDate, string DateSeperator = "/")
        {
            string CM = YourDate.Month.ToString();
            string CD = YourDate.Day.ToString();
            if (CM.Length < 2)
                CM = "0" + CM;

            if (CD.Length < 2)
                CD = "0" + CD;

            return YourDate.Year + DateSeperator + CM + DateSeperator + CD;
        }
        public string GetPersianDate(DateTime YourDate, string DateSeperator = "/")
        {
            string CM = this.PC.GetMonth(YourDate).ToString();
            string CD = this.PC.GetDayOfMonth(YourDate).ToString();
            if (CM.Length < 2)
                CM = "0" + CM;

            if (CD.Length < 2)
                CD = "0" + CD;

            return this.PC.GetYear(YourDate) + DateSeperator + CM + DateSeperator + CD;
        }
        /// <summary>
        /// writen by MORI   2014/10/14
        /// </summary>
        /// <returns></returns>
        public string GetCurrentTime()
        {
            return System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
        }
        public string GetPersianMonthName(int NumberOfMonth)
        {
            string mName = "";
            switch (NumberOfMonth)
            {
                case 1:
                    mName = "فروردین";
                    break;
                case 2:
                    mName = "اردیبهشت";
                    break;
                case 3:
                    mName = "خرداد";
                    break;
                case 4:
                    mName = "تیر";
                    break;
                case 5:
                    mName = "مرداد";
                    break;
                case 6:
                    mName = "شهریور";
                    break;
                case 7:
                    mName = "مهر";
                    break;
                case 8:
                    mName = "آبان";
                    break;
                case 9:
                    mName = "آذر";
                    break;
                case 10:
                    mName = "دی";
                    break;
                case 11:
                    mName = "بهمن";
                    break;
                case 12:
                    mName = "اسفند";
                    break;

            }
            return mName;
        }

    }
    public static class AppPath
    {
        public static DateManager dateManager = DateManager.GetDate();
        public static string Root
        {
            get { return Application.StartupPath + "\\"; }
        }
        public static string dbBackup
        {
            get { return Application.StartupPath + "\\dbBackup"; }
        }
        public static string dbBackupFileName
        {
            get
            {
                string Min = DateTime.Now.TimeOfDay.Minutes.ToString();
                string ch = DateTime.Now.TimeOfDay.Hours.ToString();
                return dateManager.GetCurrentPersianDate("-") + "-" + ch + "-" + Min + ".sql";
            }
        }
        public static string ConfigFile()
        {
            string configFile = ConfigRoot() + "ConfigFile.json";
            if (!File.Exists(configFile))
            {
                string[] BaseOfConfig = new string[1];
                string f = @"{
	                                        ""Database"": {
		                                        ""Server"": ""localhost"",
		                                        ""UserName"": ""root"",
		                                        ""Password"": """",
		                                        ""DataBaseName"": ""msmaccounting""
	                                        }
                                        }";
                BaseOfConfig[0] = f;
                File.WriteAllLines(configFile, BaseOfConfig);
            }
            return ConfigRoot() + "ConfigFile.json";
        }
        public static string ConfigRoot()
        {
            string configRoot = Root + "Config\\";
            if (!Directory.Exists(configRoot)) {
                Directory.CreateDirectory(configRoot);
            }
            return configRoot;
        }
    }
    public sealed class ConfigFile
    {
        #region Singletone Section
        private static volatile ConfigFile ConfigFileManager;
        private static object _lock = new object();
        private ConfigFile() { }
        public string getDBName
        {
            get
            {
                return "`" + ConfigFile.GetConfig().DatabaseConfig().DatabaseName + "`.";
            }
        }

        public static ConfigFile GetConfig()
        {
            if (ConfigFileManager == null)
            {
                lock (_lock)
                {
                    if (ConfigFileManager == null)
                    {
                        ConfigFileManager = new ConfigFile();
                    }
                }
            }
            return ConfigFileManager;
        }
        #endregion
        public Config.Database DatabaseConfig()
        {
            string Config = File.ReadAllText(AppPath.ConfigFile());
            dynamic JSConfig = JsonConvert.DeserializeObject(Config);

            Config.Database thisConfig = new Config.Database
            {
                Server = JSConfig.Database.Server,
                UserName = JSConfig.Database.UserName,
                Password = JSConfig.Database.Password,
                DatabaseName = JSConfig.Database.DataBaseName
            };
            return thisConfig;
        }

        public class Config
        {
            public class Database
            {
                public string Server { set; get; }
                public string UserName { set; get; }
                public string Password { set; get; }
                public string DatabaseName { set; get; }

            }
        }
    }
    public class SendSMS
    {
        public void Send(string Number,string Text)
        {
            
                string pattern = "09[0-9]{9}|\\+98[0-9]{10}";
                Regex r = new Regex(pattern);
                Match m = r.Match(Number);
                if (!m.Success)
                {
                    return;
                }
                try
                {
                    Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi("37583974484552584A594C4F554C49724F554B7845513D3D");
                    SendResult result = api.Send("10000060606066", Number, Text);
                }
                catch (Kavenegar.Exceptions.ApiException ex)
                {
                    // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
                    Console.Write("Message : " + ex.Message);
                }
                catch (Kavenegar.Exceptions.HttpException ex)
                {
                    // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
                    Console.Write("Message : " + ex.Message);
                }
            
        }
    }

    public sealed class Dialog
    {
        #region Singletone Section
        private static volatile Dialog DialogMgr;
        private static object _lock = new object();
        private Dialog() { }
        public static Dialog CreateDialog()
        {
            if (DialogMgr == null)
            {
                lock (_lock)
                {
                    if (DialogMgr == null)
                    {
                        DialogMgr = new Dialog();
                    }
                }
            }
            return DialogMgr;
        }

        public string InputValue;
        Form form = new Form();
        TextBox textBox = new TextBox();

        public DialogResult InputBox(string title, string promptText, string value)
        {

            Label label = new Label();

            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "تائید";
            buttonCancel.Text = "انصراف";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 18, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            textBox.Dock = DockStyle.Bottom;
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonOk.Dock = DockStyle.Bottom;
            buttonCancel.SetBounds(309, 72, 75, 23);
            buttonCancel.Dock = DockStyle.Bottom;

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            buttonOk.Click += new EventHandler(inputButtonOk_click);

            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;


            form.AcceptButton = buttonCancel;
            form.CancelButton = buttonCancel;

            form.RightToLeft = RightToLeft.Yes;
            form.RightToLeftLayout = true;

            DialogResult dialogResult = form.ShowDialog();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            value = textBox.Text;
            return dialogResult;
        }
        public DialogResult Question(string title, string QuestionText)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = QuestionText;

            buttonOk.Text = "تائید";
            buttonCancel.Text = "انصراف";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);

            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;

            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonOk, buttonCancel });
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonCancel;
            form.CancelButton = buttonCancel;
            form.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            form.RightToLeftLayout = true;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }///// End question Function
        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Closed");
            form.Hide();
            form.Controls.Clear();
        }
        private void inputButtonOk_click(object sender, EventArgs e)
        {
            InputValue = textBox.Text;
        }

        #endregion
    }
}
