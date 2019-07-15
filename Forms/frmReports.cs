using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Text.RegularExpressions;

namespace ManoloSellManager.Forms
{
    public partial class frmReports : Form
    {
        public string reportType
        {
            set; get;
        }



        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();

        public List<ReportParameter> RPList = new List<ReportParameter>();
        public List<ReportDataSource> rdsList = new List<Microsoft.Reporting.WinForms.ReportDataSource>();
        public string ReportPath { set; get; }
        public string CurrentPesonalID { set; get; }
        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            #region Read Report setting from Setting table and create for each setting new variable
            DataTable dtSetting = GS.db.Query("SELECT * FROM `setting`");
            string reportDescription = ""
                , reportCompanyLogo = ""
                , reportCompanyPhone = ""
                , reportCompanyAddress = ""
                , reportCompanyName = ""
                , reportTitle = "";

            #region Report Setting Set and read
            if (dtSetting.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSetting.Rows)
                {
                    string settingName = dr[1].ToString().Split(';')[0];
                    string settingValue = dr[2].ToString();
                    switch (settingName.ToLower())
                    {
                        case "invoiceprintdescript":
                            reportDescription += settingValue + Environment.NewLine;
                            break;
                        case "proformainvoiceprintdescript":
                            if (reportType == ReportType.InvoiceProforma)
                            {
                                reportDescription += settingValue + Environment.NewLine;
                            }
                            break;
                        case "logo":
                            reportCompanyLogo = settingValue;
                            break;
                        case "companyname":
                            reportCompanyName = settingValue;
                            break;
                        case "companyphone":
                            reportCompanyPhone = settingValue;
                            break;
                        case "companyaddress":
                            reportCompanyAddress = settingValue;
                            break;
                        case "invoiceselltitle":
                            if (reportType == ReportType.InvoiceSell)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "invoicebuytitle":
                            if (reportType == ReportType.InvoiceBuy)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "invoiceproformatitle":
                            if (reportType == ReportType.InvoiceProforma)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "peopleaccountreport":
                            if (reportType == ReportType.PeopleAccountDetails)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "peopleremainaccount":
                            if (reportType == ReportType.PeopleRemainAccount)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "monthlyreport":
                            if (reportType == ReportType.MonthlyReport)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "yearlyreport":
                            if (reportType == ReportType.YearlyReport)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "yearlyearnedreport":
                            if (reportType == ReportType.YearlyEarnedReport)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "monthlyearnedreport":
                            if (reportType == ReportType.MonthlyEarnedReport)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "itemsell":
                            if (reportType == ReportType.ItemSell)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                        case "workshopprinting":
                            if (reportType == ReportType.WorkshopPrinting)
                            {
                                reportTitle = settingValue;
                            }
                            break;
                    }
                }
            }
            #endregion


            Regex r = new Regex("(%mName)|(%mNumber)|(%yNumber)|(%y)");
            Match m = r.Match(reportTitle);
            string mv = "";
            if (m.Success)
            {
                string dp = GS.dateManager.GetCurrentPersianDate();
                switch (m.Value)
                {
                    case "%mName":
                        dp = dp.Substring(0, 7);
                        mv = GS.dateManager.GetPersianMonthName(Convert.ToInt32(dp.Substring(dp.Length - 2, 2))) + " ماه";
                        break;
                    case "%mNumber":
                        mv = dp = dp.Substring(0, 7);
                        mv = " برج" + dp.Substring(dp.Length, 2);
                        break;
                    case "%y":
                        dp = dp.Substring(0, 4);
                        mv = dp;
                        break;
                }

                reportTitle = reportTitle.Replace(m.Value, mv);
            }

            if (reportCompanyLogo.Length < 5)
            {
                MessageBox.Show("لطفا در بخش تنظیمات لوگو را مشخص کنید.");
                return;
            }
            #endregion

            #region Set value to Parameter of Report

            #region Start Set Company details to Parameter of Report /////////////////////////
            string imagePath = new Uri(Application.StartupPath + "\\" + reportCompanyLogo).AbsoluteUri;
            ReportParameter rpCompanyName = new ReportParameter("rpCompanyName", reportCompanyName);
            ReportParameter rpCompanyPhone = new ReportParameter("rpCompanyPhone", reportCompanyPhone);
            ReportParameter rpCompayAddress = new ReportParameter("rpCompanyAddress", reportCompanyAddress);
            ReportParameter rpDescription = new ReportParameter("rpDescription", reportDescription);

            ReportParameter rpReportTitle = new ReportParameter("rpReportTitle", reportTitle);

            ReportParameter rpLogo = new ReportParameter("rpLogoPath", imagePath);
            #endregion

            RPList.Add(rpCompanyName);
            RPList.Add(rpCompanyPhone);
            RPList.Add(rpCompayAddress);
            if (ReportType.PeopleAccountDetails != reportType && ReportType.PeopleRemainAccount != reportType)
            {
                if (reportType != ReportType.MonthlyReport)
                {
                    RPList.Add(rpDescription);
                }
            }
            RPList.Add(rpReportTitle);
            RPList.Add(rpLogo);

            reportViewer1.LocalReport.ReportPath = ReportPath;
            StreamReader sr = new StreamReader(ReportPath);

            reportViewer1.LocalReport.LoadReportDefinition(sr);
            reportViewer1.LocalReport.DataSources.Clear();

            foreach (ReportDataSource rds in rdsList)
            {
                reportViewer1.LocalReport.DataSources.Add(rds);
            }
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
            reportViewer1.LocalReport.EnableExternalImages = true;
            //reportViewer1.LocalReport.SetParameters(rpLogo);
            foreach (ReportParameter rp in RPList)
            {
                try
                {
                    reportViewer1.LocalReport.SetParameters(rp);
                }
                catch { }
            }
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            #endregion

            reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            reportViewer1.PrintDialog();
        }

        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            btnPrint_Click(sender, e);
        }
    }
    public static class ReportType
    {
        public static string InvoiceSell
        {
            get { return "sell"; }
        }
        public static string InvoiceBuy
        {
            get { return "buy"; }
        }
        public static string InvoiceProforma
        {
            get { return "proforma"; }
        }
        public static string PeopleAccountDetails
        {
            get { return "peopleaccountreport"; }
        }
        public static string PeopleRemainAccount
        {
            get { return "peopleremainaccount"; }
        }
        public static string MonthlyReport
        {
            get { return "monthlyReport"; }
        }
        public static string YearlyReport
        {
            get { return "yearlyReport"; }
        }
        public static string YearlyEarnedReport
        {
            get { return "yearlyearnedreport"; }
        }
        public static string MonthlyEarnedReport
        {
            get { return "monthlyearnedreport"; }
        }
        public static string ItemSell
        {
            get { return "itemsell"; }
        }
        public static string WorkshopPrinting
        {
            get { return "workshopprinting"; }
        }
    }

}
