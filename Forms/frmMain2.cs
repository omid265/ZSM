using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ManoloSellManager.Class;
using Microsoft.Reporting.WinForms;
using System.IO;
using Generals;


namespace ManoloSellManager.Forms
{
    public partial class frmMain2 : Form
    {

        Class.Generals GS = Class.Generals.CreateGenerals();
        string DBName = "`" + ConfigFile.GetConfig().DatabaseConfig().DatabaseName + "`.";

        public frmMain2()
        {
            InitializeComponent();
            //// Create a material theme manager and add the form to manage (this)
            //MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            //// Configure color schema
            //materialSkinManager.ColorScheme = new ColorScheme(
            //    Primary.Blue400, Primary.Blue500,
            //    Primary.Blue500, Accent.LightBlue200,
            //    TextShade.WHITE
            //);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GS.Backup();
            this.Close();
        }
        private void manageDBUpdate()
        {
            
            DirectoryInfo dbSchema = new DirectoryInfo(AppPath.ConfigRoot());


            FileInfo[] dbs = dbSchema.GetFiles("DBSchema.sql");
            if (dbs.Count() == 1)
            {
                GS.Backup("", "", true);

                string[] f = File.ReadAllLines(dbs[0].FullName);
                List<string> newSchema = new List<string>();
                foreach (string l in f)
                {
                    GS.db.Query(l.Replace("`[DBNAME]`", ConfigFile.GetConfig().DatabaseConfig().DatabaseName), true);

                    if (GS.db.QueryError != 0)
                    {
                        newSchema.Add(l);
                    }
                }

                string fname = Path.GetFileNameWithoutExtension(dbs[0].FullName);
                fname += "-compiled-" + GS.dateManager.GetCurrentPersianDate("-");
                fname = Path.GetDirectoryName(dbs[0].FullName) + "\\" + fname + Path.GetExtension(dbs[0].FullName);
                dbs[0].MoveTo(fname);


                //if (newSchema.Count > 0)
                //{
                //    string pp = Path.GetDirectoryName(dbs[0].FullName) + "\\DBSchema.sql";
                //    StreamWriter sw = new StreamWriter(pp, true);
                //    foreach (string s in newSchema)
                //    {
                //        sw.WriteLine(s);
                //        sw.Flush();
                //    }
                //    sw.Close();
                //}
            }


            //Process[] cp = Process.GetProcessesByName("mysql.exe");
            //Process[] cp = Process.GetProcessesByName("mysqld");
            //foreach(Process p in cp)
            //{
            //    if (p.ProcessName.Contains("my"))
            //    {
            //        MessageBox.Show(p.ProcessName);
            //    }
            //}

            //DirectoryInfo dbSchema = new DirectoryInfo(AppPath.ConfigRoot());


            //FileInfo[] dbs= dbSchema.GetFiles("DBSchema.sql");
            //if (dbs.Count() == 1)
            //{
            //    GS.Backup("","",true);

            //    string[] f =File.ReadAllLines(dbs[0].FullName);
            //    List<string> newSchema =new List<string>();
            //    foreach(string l in f)
            //    {

            //        GS.db.Query(l.Replace("`[DBNAME]`",ConfigFile.GetConfig().DatabaseConfig().DatabaseName),true);
            //        if (GS.db.QueryError != 0)
            //        {
            //            newSchema.Add(l);
            //        }
            //    }

            //    string fname=Path.GetFileNameWithoutExtension(dbs[0].FullName);
            //    fname += "-compiled-"+GS.dateManager.GetCurrentPersianDate("-");
            //    fname = Path.GetDirectoryName(dbs[0].FullName)+"\\"+fname+Path.GetExtension(dbs[0].FullName);
            //    dbs[0].MoveTo(fname);


            //    if (newSchema.Count > 0)
            //    {
            //        string pp = Path.GetDirectoryName(dbs[0].FullName) + "\\DBSchema.sql";
            //        StreamWriter sw = new StreamWriter(pp, true);
            //        foreach (string s in newSchema)
            //        {
            //            sw.WriteLine(s);
            //            sw.Flush();
            //        }
            //        sw.Close();
            //    }
            //}



            //DataTable dtsm = GS.db.Query("SELECT * FROM `setting` WHERE  `SettingName` LIKE 'itemsell;%'");
            //if (dtsm.Rows.Count == 0)
            //{
            //    GS.db.Query("INSERT INTO `setting` (`id`, `SettingName`, `SettingValue`) VALUES (NULL, 'itemsell;گزارش فروش کالا', 'گزارش فروش کالا');", true);
            //}

            //dtsm = GS.db.Query("SELECT * FROM `setting` WHERE  `SettingName` LIKE 'MonthlyEarnedReport;%'");
            //if (dtsm.Rows.Count == 0)
            //{
            //    GS.db.Query("INSERT INTO `setting` (`id`, `SettingName`, `SettingValue`) VALUES (NULL,'MonthlyEarnedReport;گزارش دریافتی ماهانه','گزارش دریافتی ماهانه %mName');", true);
            //}


            //dtsm = GS.db.Query("SELECT * FROM `setting` WHERE  `SettingName` LIKE 'YearlyEarnedReport;%'");
            //if (dtsm.Rows.Count == 0)
            //{
            //    GS.db.Query("INSERT INTO `setting` (`id`, `SettingName`, `SettingValue`) VALUES (NULL,'YearlyEarnedReport;گزارش دریافتی سالانه','گزارش دریافتی سالانه %y');", true);
            //}

            //dtsm = GS.db.Query("SELECT * FROM `setting` WHERE  `SettingName` LIKE 'yearlyReport;%'");
            //if (dtsm.Rows.Count == 0)
            //{
            //    GS.db.Query("INSERT INTO `setting` (`id`, `SettingName`, `SettingValue`) VALUES (NULL,'yearlyReport;فروش سالانه','گزارش سالانه %y');", true);
            //}

            //dtsm = GS.db.Query("SELECT * FROM `setting` WHERE  `SettingName` LIKE 'monthlyReport;%'");
            //if (dtsm.Rows.Count == 0)
            //{
            //    GS.db.Query("INSERT INTO `setting` (`id`, `SettingName`, `SettingValue`) VALUES (NULL,'monthlyReport;فروش ماهانه','گزارش ماهانه %mName');", true);
            //}


            //dtsm = GS.db.Query("SELECT * FROM `setting` WHERE  `SettingName` LIKE 'monthlyReport;%'");
            //if (dtsm.Rows.Count == 0)
            //{
            //    GS.db.Query("ALTER TABLE `setting` CHANGE `SettingValue` `SettingValue` LONGTEXT CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL;", true);
            //}




        }
        private void frmMain2_Load(object sender, EventArgs e)
        {
            manageDBUpdate();
            GS.Backup();

            string fields = "lenght:*;width:/;func:6.25;";
            string[] fi = fields.Split(':');
            foreach (string words in fi)
            {
                //MessageBox.Show(words.ToString());
            }

            lblCurrentDate.Text = "امروز :" + GS.dateManager.GetCurrentPersianDate();

            lblAppTitle.Text = "سیستم جامع مدیریت فروش مانولو  (نسخه " + Application.ProductVersion.ToString() + ")";
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            chek ChequeSystem = new chek();
            var ChequeDT = new DataTable();

            var newDate = new DateTime();
            newDate = DateTime.Now.AddDays(7);

            string Next7DayDate = GS.dateManager.GetPersianDate(newDate);


            //MessageBox.Show(Next7DayDate + " : " + GS.GetCurrentDate());
            //string PNowDate=
            /////////// بحث تاریخ ها درحال اجرا بود.

            string TypeCheck = "0";////// 1= چک های پرداختی  ------ And ------ 0= چک های دریافتی

            string CQ = "WHERE `t_saresid` BETWEEN  '" + GS.dateManager.GetCurrentPersianDate() + "' AND '" + Next7DayDate + "' AND `typeCheck`='" + TypeCheck + "' ORDER BY `t_saresid`";
            //string CQ = "WHERE `t_saresid` BETWEEN  '" + GS.GetCurrentDate() + "' AND '" + Next7DayDate + "'  ORDER BY `t_saresid`";
            ChequeDT = ChequeSystem.read_chek(CQ);
            if (ChequeDT != null)
            {

                if (ChequeDT.Rows.Count > 0)
                {
                    dgvChequeWekList.AutoGenerateColumns = false;
                    dgvChequeWekList.DataSource = ChequeDT;
                    dgvChequeWekList.Refresh();
                    gbNextWeekCheque.Visible = true;
                }
                else
                {
                    gbNextWeekCheque.Visible = false;
                    //tableLayoutPanel1.Visible = false;
                }
            }////// End ChequeDT Value
        }

        private void dgvChequeWekList_DoubleClick(object sender, EventArgs e)
        {
            int CurrentRow = dgvChequeWekList.CurrentCell.RowIndex;
            string personalId = dgvChequeWekList.Rows[CurrentRow].Cells[3].Value.ToString();
            frmCheck FC = new frmCheck();
            FC.PersonalId = Convert.ToInt16(personalId);
            FC.ShowDialog(this);
        }

        private void frmMain2_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                foreach (Form ff in Application.OpenForms)
                {
                    ff.Close();
                }
                Application.Exit();
            }
            catch
            {
                Application.Exit();
            }
        }

        private void btnChek_Click(object sender, EventArgs e)
        {
            new frmCheck().ShowDialog(this);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrders fo = new frmOrders();
            fo.InvoiceType = Invoice.InvoiceType.sell;
            fo.OrderMode = frmOrders.ModeList.New;
            fo.ShowDialog(this);
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            frmOrders fo = new frmOrders();
            fo.InvoiceType = Invoice.InvoiceType.buy;
            fo.OrderMode = frmOrders.ModeList.New;
            fo.ShowDialog(this);            
        }

        private void btnCheckPerson_Click(object sender, EventArgs e)
        {
            new frmPersonalAccount().ShowDialog(this);
        }

        private void btnSpend_Click(object sender, EventArgs e)
        {
            //new frmOtherPay().ShowDialog(this);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            new frmPersonal().ShowDialog(this);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            new frmStore().ShowDialog(this);
        }

        private void btnSharik_Click(object sender, EventArgs e)
        {
            //new frmSharik().ShowDialog(this);
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            new frmAddPersonel().ShowDialog(this);
        }

        private void btnRepBedehkaran_Click(object sender, EventArgs e)
        {
            //new frmAllPeopleRemainAccount().ShowDialog(this);

            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////
            #region Report Parameters
            List<ReportParameter> rp = new List<ReportParameter>();
            rp.Add(new ReportParameter("rpReportDate", GS.dateManager.GetCurrentPersianDate()));
            #endregion

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            string q = string.Format("SELECT * FROM {0}`peoplewithremainaccount`", DBName);
            rdsList.Add(new ReportDataSource("DSPeopleWithRemainaccount", GS.db.Query(q)));
            #endregion

            #region Set frmReport Properties and show this form
            frmReports frmR = new frmReports();
            frmR.RPList = rp;

            frmR.reportType = ReportType.PeopleRemainAccount;
            frmR.rdsList = rdsList;

            string ReportPath = Path.Combine(Application.StartupPath, @"reports\PeopleWithRemainAccount.rdlc");
            frmR.ReportPath = ReportPath;
            frmR.ShowDialog(this);
            #endregion
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            #endregion


        }

        private void btnRepSelNum_Click(object sender, EventArgs e)
        {
            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            string d = GS.dateManager.GetCurrentPersianDate();
            d = d.Substring(0, 7);
            string q = string.Format("SELECT * FROM {0}`invoicedetails` WHERE `type` = '{1}'  ORDER BY `id` ASC", DBName,Invoice.InvoiceType.sell);
            DataTable dtDSMonthlyReport = GS.db.Query(q);
            if (dtDSMonthlyReport.Rows.Count == 0)
            {
                MessageBox.Show("در ماه جاری هیچ تراکنشی ثبت نشده است.");
                return;
            }
            rdsList.Add(new ReportDataSource("dsInvoiceDetails", dtDSMonthlyReport));
            #endregion

            #region ReportParameter
            List<ReportParameter> rpList = new List<ReportParameter>();
            //rpList.Add(new ReportParameter("rpReportDate",GS.dateManager.GetCurrentPersianDate() ));
            #endregion

            #region Set frmReport Properties and show this form
            frmReports frmR = new frmReports();
            //frmR.RPList = null;

            frmR.reportType = ReportType.ItemSell;
            frmR.rdsList = rdsList;
            foreach (ReportParameter rp in rpList)
            {
                frmR.RPList.Add(rp);
            }
            string ReportPath = Path.Combine(Application.StartupPath, @"reports\ItemSell.rdlc");
            frmR.ReportPath = ReportPath;
            frmR.ShowDialog(this);
            #endregion
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            #endregion

        }

        private void btnEditInvoiceH_Click(object sender, EventArgs e)
        {
            try
            {
                new frmSettings().ShowDialog(this);
            }
            catch { }
        }

        private void btnPayPersonel_Click(object sender, EventArgs e)
        {
            new frmPayToPersonel().ShowDialog(this);
        }

        private void btnPreInvoice_Click(object sender, EventArgs e)
        {
            frmOrders fo = new frmOrders();
            fo.InvoiceType = Invoice.InvoiceType.proforma;
            fo.OrderMode = frmOrders.ModeList.New;
            fo.ShowDialog(this);
        }

        private void btnRepMmounth_Click(object sender, EventArgs e)
        {
            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            string d = GS.dateManager.GetCurrentPersianDate();
            d = d.Substring(0, 7);
            string q = string.Format("SELECT * FROM {0}`accounting` WHERE `payDate` LIKE '{1}%'  ORDER BY `id` ASC", DBName,d);
            DataTable dtDSMonthlyReport = GS.db.Query(q);
            if (dtDSMonthlyReport == null)
            {
                MessageBox.Show("در ماه جاری هیچ تراکنشی ثبت نشده است.");
                return;
            }
            if (dtDSMonthlyReport.Rows.Count == 0)
            {
                MessageBox.Show("در ماه جاری هیچ تراکنشی ثبت نشده است.");
                return;
            }
            rdsList.Add(new ReportDataSource("dsMonthlyReport", dtDSMonthlyReport));
            #endregion

            #region Set frmReport Properties and show this form
            frmReports frmR = new frmReports();
            //frmR.RPList = null;

            frmR.reportType = ReportType.MonthlyReport;
            frmR.rdsList = rdsList;

            string ReportPath = Path.Combine(Application.StartupPath, @"reports\monthlyReport.rdlc");
            frmR.ReportPath = ReportPath;
            frmR.ShowDialog(this);
            #endregion
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            #endregion

        }

        private void btnRepMyear_Click(object sender, EventArgs e)
        {
            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            string d = GS.dateManager.GetCurrentPersianDate();
            d = d.Substring(0, 4);
            string q = string.Format("SELECT * FROM {0}`accounting` WHERE `payDate` LIKE '{1}%'  ORDER BY `id` ASC", DBName,d);
            DataTable dtDSMonthlyReport = GS.db.Query(q);
            if (dtDSMonthlyReport.Rows.Count == 0)
            {
                MessageBox.Show("در سال جاری هیچ تراکنشی ثبت نشده است.");
                return;
            }
            rdsList.Add(new ReportDataSource("dsMonthlyReport", dtDSMonthlyReport));
            #endregion

            #region Set frmReport Properties and show this form
            frmReports frmR = new frmReports();
            //frmR.RPList = null;

            frmR.reportType = ReportType.YearlyReport;
            frmR.rdsList = rdsList;

            string ReportPath = Path.Combine(Application.StartupPath, @"reports\monthlyReport.rdlc");
            frmR.ReportPath = ReportPath;
            frmR.ShowDialog(this);
            #endregion
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            #endregion
        }

        private void btnRepMperson_Click(object sender, EventArgs e)
        {

        }

        private void btnRepEarn_Click(object sender, EventArgs e)
        {
            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            string d = GS.dateManager.GetCurrentPersianDate();
            d = d.Substring(0, 4);
            string q = string.Format("SELECT * FROM {0}`accounting` WHERE `payDate` LIKE '{1}%' AND `payType`='pay' ORDER BY `id` ASC", DBName,d);
            DataTable dtDSMonthlyReport = GS.db.Query(q);
            if (dtDSMonthlyReport.Rows.Count == 0)
            {
                MessageBox.Show("در سال جاری هیچ مبلغی دریافت نشده است.");
                return;
            }
            rdsList.Add(new ReportDataSource("dsMonthlyReport", dtDSMonthlyReport));
            #endregion

            #region Set frmReport Properties and show this form
            frmReports frmR = new frmReports();
            //frmR.RPList = null;

            frmR.reportType = ReportType.YearlyEarnedReport;
            frmR.rdsList = rdsList;

            string ReportPath = Path.Combine(Application.StartupPath, @"reports\monthlyReport.rdlc");
            frmR.ReportPath = ReportPath;
            frmR.ShowDialog(this);
            #endregion
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            #endregion
        }

        private void btnRepStore_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonelDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnEditSaleMali_Click(object sender, EventArgs e)
        {

        }

        private void btnEditUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            saveFileDialogBackup.InitialDirectory = AppPath.dbBackup;
            saveFileDialogBackup.FileName = AppPath.dbBackupFileName;
            //saveFileDialogBackup.ShowDialog(this);
            if (saveFileDialogBackup.ShowDialog(this) == DialogResult.OK)
            {
                string backuppath = saveFileDialogBackup.FileName;
                string fName = Path.GetFileName(backuppath);
                backuppath = backuppath.Replace(fName, "");
                GS.Backup(backuppath, fName);

            }

        }

        private void btnMonthlyEarnedReport_Click(object sender, EventArgs e)
        {
            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            string d = GS.dateManager.GetCurrentPersianDate();
            d = d.Substring(0, 7);
            string q = string.Format("SELECT * FROM {0}`accounting` WHERE `payDate` LIKE '{1}%' AND `payType`='pay' ORDER BY `id` ASC", DBName,d);
            DataTable dtDSMonthlyReport = GS.db.Query(q);
            if (dtDSMonthlyReport.Rows.Count == 0)
            {
                MessageBox.Show("در ماه جاری هیچ مبلغی دریافت نشده است.");
                return;
            }
            rdsList.Add(new ReportDataSource("dsMonthlyReport", dtDSMonthlyReport));
            #endregion

            #region Set frmReport Properties and show this form
            frmReports frmR = new frmReports();
            //frmR.RPList = null;

            frmR.reportType = ReportType.MonthlyEarnedReport;
            frmR.rdsList = rdsList;

            string ReportPath = Path.Combine(Application.StartupPath, @"reports\monthlyReport.rdlc");
            frmR.ReportPath = ReportPath;
            frmR.ShowDialog(this);
            #endregion
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            #endregion
        }

        private void btnOpenConfiguration_Click(object sender, EventArgs e)
        {
            new frmManageConfiguration().ShowDialog(this);
        }

        private void btnImportOldData_Click(object sender, EventArgs e)
        {
            frmImportOldData frmImport = new frmImportOldData();
            frmImport.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cheques.Cheque cn = new Cheques.Cheque();
            cn.PayDate = GS.dateManager.CurrentDate.ToShortDateString() ;
            cn.DueDate= GS.dateManager.CurrentDate.ToShortDateString();
            cn.PayTo = new Clients().getClientByID(5).ID;
            cn.Payer = new Clients().getClientByID(9).ID;
            cn.Price = 500000;
            cn.Serial = "654913156489";
            cn.BankName = "ملت";
            cn.Type = Cheques.ChequeType.Pay;
            Cheques.Items.Add(cn);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Customer:"+((int)Clients.ClientType.Customer).ToString());
            MessageBox.Show("Seller:" + ((int)Clients.ClientType.Seller).ToString());
            MessageBox.Show("Employee:" + ((int)Clients.ClientType.Employee).ToString());
            MessageBox.Show("All:" + ((int)Clients.ClientType.All).ToString());
        }

        private void ثبتفاکتورفروشToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnOrder_Click(sender, e);
        }

        private void تعریفمشتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddPerson_Click(sender, e);
        }

        private void مشاهدهوضعیتافرادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckPerson_Click(sender, e);
        }
    }
}
