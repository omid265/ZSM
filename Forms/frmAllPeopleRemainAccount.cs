using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ManoloSellManager.Class;
using System.IO;
namespace ManoloSellManager.Forms
{
    public partial class frmAllPeopleRemainAccount : Form
    {
        ManoloSellManager.Class.Generals GS =ManoloSellManager.Class.Generals.CreateGenerals();
        public frmAllPeopleRemainAccount()
        {
            InitializeComponent();
        }

        private void ReportTest_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'peopleWithRemainAccount.peoplewithremainaccount' table. You can move, or remove it, as needed.
            //this.peoplewithremainaccountTableAdapter.Fill(this.peopleWithRemainAccount.peoplewithremainaccount);
            //string imagePath = new Uri(Application.StartupPath + @"\images\logo.png").AbsoluteUri;

            //ReportParameter rpLogo = new ReportParameter("rpLogoPath", imagePath);
            //ReportParameter rpReportDate = new ReportParameter("rpReportDate", GS.dateManager.GetCurrentDate());

            //reportViewer1.LocalReport.EnableExternalImages = true;
            //reportViewer1.LocalReport.SetParameters(rpLogo);
            //reportViewer1.LocalReport.SetParameters(rpReportDate);


            //this.reportViewer1.RefreshReport();


            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////
            #region Report Parameters
            List<ReportParameter> rp = new List<ReportParameter>();
            rp.Add(new ReportParameter("rpReportDate", GS.dateManager.GetCurrentPersianDate()));
            #endregion

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            string q = "SELECT * FROM `peoplewithremainaccount`";
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


            this.Close();



        }
    }
}
