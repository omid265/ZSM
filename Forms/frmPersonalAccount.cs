using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ManoloSellManager.Class;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Collections.Generic;

namespace ManoloSellManager.Forms
{
    public partial class frmPersonalAccount : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();
        Clients c = new Clients();
        Clients.Client cSC = new Clients.Client();

        //DataTable dtPersonalList = new DataTable();
        string CurrentPesonalID = "";
        public frmPersonalAccount()
        {
            InitializeComponent();
            LoadPersonal();

        }
        private void ResetForm()
        {
            cbType.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            btnCalcPersonalAccountStatus.Visible = false;
            CurrentPesonalID = "0";
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadPersonal(string Sort = "ASC")
        {
            //dtPersonalList = GS.db.Query("SELECT * FROM `personals` ORDER BY `id`" + Sort);
            dgvPersonalsList.AutoGenerateColumns = false;
            dgvPersonalsList.DataSource = c.getClientsList("ORDER BY `id`" + Sort);

        }

        private void Validation()
        {
            if (cbType.Text == "" || txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                //btnSave.Enabled = false;
            }
            //else
                //btnSave.Enabled = true;
        }

        private void SelectPersonal()
        {
            txtBestankar.Text = "0";
            if (dgvPersonalsList.CurrentCell != null)
            {
                int rowIndex = dgvPersonalsList.CurrentCell.RowIndex;
                //int cellIndex = dgvSeller.CurrentCell.ColumnIndex;
                int cellIndex = 0;

                if (c.getClientsList("").Rows.Count > 0)
                {
                    string PersonalCode = dgvPersonalsList.Rows[rowIndex].Cells[cellIndex].Value.ToString();
                    string PersonalName = "";

                    //DataTable dtP = new DataTable();
                    //dtP = GS.db.Query("SELECT * FROM `personals` WHERE `id`='" + PersonalCode + "'");

                    cSC= c.getClientByID(Convert.ToInt32(PersonalCode));

                    PersonalName = cSC.name;

                    ////////////////////////////// Start Set Personal Details to windows form ////////////////////////
                    txtName.Text = PersonalName;
                    CurrentPesonalID = cSC.ID.ToString();
                    txtPhone.Text = cSC.phone;
                    txtAddress.Text = cSC.Address;
                    cbType.Text = cSC.type.ToString();
                    ////////////////////////////// End Set Personal Details to windows form ////////////////////////

                    btnCalcPersonalAccountStatus.Visible = true;
                    gbPersonalsList.Visible = false;
                    ToolStripMenuItemPay.Enabled = true;
                    TSMIShowAccountDetails.Enabled = true;
                    tsmiAddDue.Enabled = true;
                    this.AcceptButton = null;
                    
                }
                else
                {
                    ResetForm();
                    MessageBox.Show("مشتری یا فروشنده ای در سیستم تعریف نشده است.");
                }
                //txtStoreItemCode.Focus();

                calcPesonalAccountStatus();
            }
            else
            {
                MessageBox.Show("فروشنده یا مشتری مورد نظر شما در سیستم تعریف نشده است.");
            }////// End control dgvPersonalsList.CurrentCell

        }
        private void calcPesonalAccountStatus()
        {
            
            
            TransactionActivity.TransactionLog TL=new TransactionActivity.TransactionLog();
            //string totDueQuery = "";
            string totDueQuery =TL.GetAllSell(cSC.ID).ToString();// "SELECT SUM(  `ItemPrice` *  `itemCount` ) AS totBuy FROM  `invoicedetails`WHERE  `InvoiceNo`IN (SELECT  `InvoiceId`FROM  `invoice` WHERE  `InvoiceUserId` =  '" + cSC.ID + "')AND  `itemCount` !=  '0'";
            DataTable dtcpas = GS.db.Query(totDueQuery);
           
            decimal CPI=Convert.ToDecimal(cSC.ID);
            txtTotBuy.Text = GS.nf(TL.CalcPersonalPriceOfBuy(CPI).ToString());
            txtTotPay.Text = GS.nf((TL.CalcPersonalPriceOfCashPay(CPI)+TL.CalcPersonalPriceOfChequePay(CPI)).ToString());
            //txtOldDue.Text = GS.nf(TL.CalcPersonalPriceOfOldPay(CPI).ToString());
            txtOldDue.Text = GS.nf(TL.CalcPersonalPriceOfOldRemainAccount(CPI).ToString());
            
            dgvReaminAccountList.AutoGenerateColumns = false;
            dgvReaminAccountList.DataSource = TL.GetOldRemainAccountList(CPI);

            if (dtcpas != null || txtOldDue.Text=="0")
            {
                double TotBuy = Convert.ToDouble(txtTotBuy.Text.ToString());
                double TotOldDue = Convert.ToDouble(txtOldDue.Text.ToString());
                double TotPay = Convert.ToDouble(txtTotPay.Text.ToString());
                double TotSell = Convert.ToDouble(TL.GetAllSell(cSC.ID));
                double pas=(TotBuy+TotOldDue) - TotPay-TotSell;
                if (pas < 0)
                {
                    txtBestankar.Text = GS.nf(Convert.ToString(pas*(-1)));
                    txtDue.Text = "0";
                }
                else
                {
                    txtBestankar.Text = "0";
                    txtDue.Text = GS.nf(Convert.ToString(pas));
                }

                dgvAllInvoiceList.AutoGenerateColumns = false;
                dgvAllInvoiceList.DataSource = GS.db.Query("SELECT * FROM `invoice` WHERE `InvoiceUserId`='" + cSC.ID + "' AND `type`='"+Invoice.InvoiceType.sell+"'");
                dgvAllInvoiceList.Refresh();

                dgvPish.AutoGenerateColumns = false;
                dgvPish.DataSource = GS.db.Query("SELECT * FROM `invoice` WHERE `InvoiceUserId`='" + cSC.ID + "'  AND `type`='"+Invoice.InvoiceType.proforma+"'");
                dgvPish.Refresh();

                dgvAllPay.AutoGenerateColumns = false;
                dgvAllPay.DataSource = GS.db.Query("SELECT * FROM `accounting` WHERE `personalId`='" + cSC.ID + "' AND `payType` ='pay'");

            }
            else
            {
                dgvAllInvoiceList.DataSource = null;
            }
        }
        
        private void dgvPersonalsList_DoubleClick(object sender, EventArgs e)
        {
            SelectPersonal();
        }

        private void btnCalcPersonalAccountStatus_Click(object sender, EventArgs e)
        {
            calcPesonalAccountStatus();
        }

       
        private void ToolStripMenuItemCash_Click(object sender, EventArgs e)
        {
            frmPay fp= new frmPay();
            fp.CurrentPesonalID = Convert.ToDecimal(cSC.ID);
            fp.ShowDialog(this);
        }

        private void txtName_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode.ToString()=="Return")
            {
                gbPersonalsList.Visible = true;
            }
        }

        private void frmPersonalAccount_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            gbPersonalsList.Visible = true;
            LoadPersonal();
            txtSellerName.Focus();
            txtSellerName.Text = string.Empty;
            this.AcceptButton = btnSetSeller;

        }

        private void btnSetSeller_Click(object sender, EventArgs e)
        {
            SelectPersonal();
        }

        private void txtSellerName_TextChanged(object sender, EventArgs e)
        {
            txtTotBuy.Text = null;
            txtAddress.Text = null;
            txtPhone.Text = null;
            cbType.Text = null;

            Validation();
            //dtPersonalList = GS.db.Query("SELECT * FROM `personals` WHERE `name`LIKE '%" + txtSellerName.Text + "%'");
            dgvPersonalsList.DataSource = c.getClientsList("WHERE `name`LIKE '%" + txtSellerName.Text + "%'");
        }

        private void txtSellerPhone_TextChanged(object sender, EventArgs e)
        {

            Validation();

            //dtPersonalList = GS.db.Query("SELECT * FROM `personals` WHERE `phone`LIKE '%" + txtSellerPhone.Text + "%'");
            dgvPersonalsList.DataSource = c.getClientsList("WHERE `phone`LIKE '%" + txtSellerPhone.Text + "%'");
        }

        private void txtSellerCode_TextChanged(object sender, EventArgs e)
        {
            Validation();

            //dtPersonalList = GS.db.Query("SELECT * FROM `personals` WHERE `id`LIKE '" + txtSellerCode.Text + "%'");
            dgvPersonalsList.DataSource = c.getClientsList("WHERE `id`LIKE '%" + txtSellerCode.Text + "%'");
        }

        private void ToolStripMenuItemPay_Click(object sender, EventArgs e)
        {

        }

        private void dgvAllInvoiceList_DoubleClick(object sender, EventArgs e)
        {
            frmOrders fo = new frmOrders();
            Int16 InvoiceNo=Convert.ToInt16(dgvAllInvoiceList.CurrentRow.Cells[0].Value);

            Invoice.Current.Number = InvoiceNo;
            fo.InvoiceType = Invoice.InvoiceType.sell;
            fo.InvoiceNo = InvoiceNo;
            fo.OrderMode=frmOrders.ModeList.JustEdit;
            fo.ShowDialog(this);
        }

        private void ToolStripMenuItemCheck_Click(object sender, EventArgs e)
        {
            frmCheck fc = new frmCheck();
            fc.PersonalId =Convert.ToInt16(cSC.ID);
            fc.ShowDialog(this);
        }

        private void frmPersonalAccount_Activated(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "")
            {
                calcPesonalAccountStatus();
            }
        }

        private void TSMIShowAccountDetails_Click(object sender, EventArgs e)
        {
            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////
            #region Report Parameters
            List<ReportParameter> rp = new List<ReportParameter>();
            rp.Add(new ReportParameter("rpReportDate", GS.dateManager.GetCurrentPersianDate()));
            #endregion

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            rdsList.Add(new ReportDataSource("dsP", cSC.ToDatatable()));

            string q = "SELECT * FROM `accounting` WHERE `personalId`='" + cSC.ID + "'";
            rdsList.Add(new ReportDataSource("dsPA", GS.db.Query(q)));
            #endregion

            #region Set frmReport Properties and show this form
            frmReports frmR = new frmReports();
            frmR.RPList = rp;

            frmR.reportType = ReportType.PeopleAccountDetails;
            frmR.rdsList = rdsList;

            string ReportPath = Path.Combine(Application.StartupPath, @"reports\rPAS.rdlc");
            frmR.ReportPath = ReportPath;
            frmR.CurrentPesonalID = cSC.ID.ToString();
            frmR.ShowDialog(this);
            #endregion
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            //btnBack.Visible = true;
            //btnBack.BringToFront();
            #endregion
            
        }

        private void tsmiAddDue_Click(object sender, EventArgs e)
        {
            if (GS.dialog.InputBox("ثبت پرداخت نقدی", "مبلغ مانده حساب این شخص چقدر است؟", "") == DialogResult.OK)
            {
                if (GS.dialog.InputValue.Length > 3)
                {

                    try
                    {

                        var tl = new TransactionActivity.TransactionLog();

                        //////////// NT= New Transaction
                        TransactionActivity.Transaction NT = new TransactionActivity.Transaction();


                        ////////// TTO= Transaction Type Order
                        TransactionActivity.TransactionType TTO = TransactionActivity.TransactionType.RemainAccount;

                        ///////// TMT= Transaction Method Type
                        TransactionActivity.TransactionMethod TMT = TransactionActivity.TransactionMethod.Old;

                        //////// set transaction Price
                        NT.Amount = Convert.ToDecimal(GS.dialog.InputValue);
                        /////// personal id for this transaction
                        NT.PersonalID = Convert.ToDecimal(CurrentPesonalID);

                        NT.Method = TMT;
                        NT.Description = "ثبت مانده حساب";
                        NT.Time = DateTime.Now.ToShortTimeString();
                        NT.Date = GS.dateManager.GetCurrentPersianDate();
                        NT.Type = TTO;
                        NT.RemainAccount = tl.RemainAccount(Convert.ToDecimal(CurrentPesonalID)) + Convert.ToDecimal(NT.Amount);
                        byte DFF = Convert.ToByte(TransactionActivity.TransactionStatus.Bedehkar);
                        NT.Status = DFF;
                        tl.NewTransaction(NT);

                        MessageBox.Show("ثبت مانده حساب با موفقیت انجام شد.");

                    }
                    catch
                    {
                        //PayAmount = 0;
                        MessageBox.Show("لطفا فقط عدد وارد کنید.");
                    }
                }
            }
        }

        private void tsmiDeletePay_Click(object sender, EventArgs e)
        {
            try
            {
                Int16 PayID = Convert.ToInt16(dgvAllPay.CurrentRow.Cells[0].Value);

                DataTable dtDFPP = new DataTable();///// DFPP= Delete From Person Pay

                dtDFPP = GS.db.Query("SELECT * FROM `accounting` WHERE `id`='" + PayID.ToString() + "'");
                if (dtDFPP != null)
                {
                    string QMessage = "میخواهید پرداختی شخص با مبلغ " + GS.nf(dtDFPP.Rows[0]["payPrice"].ToString()) + " و با شرح ( " + dtDFPP.Rows[0]["payAbout"].ToString() + " )را حذف کنید؟";
                    if (GS.dialog.Question("حذف پرداختی ها", QMessage) == DialogResult.OK)
                    {
                        if(dtDFPP.Rows[0]["payMethod"].ToString()=="doc"){
                            if(GS.dialog.Question("حذف چک پرداختی مشتری","پرداخت از نوع چک می باشد آیا میخواهید آن را حذف کنید؟")==DialogResult.OK){
                                chek ZSMC=new chek();
//                                string CheckSerial = Regex.Match(dtDFPP.Rows[0]["payAbout"].ToString(), @"\d").Value.ToString();
                                string CheckSerial = dtDFPP.Rows[0]["payAbout"].ToString();
                                string CSN = Regex.Replace(CheckSerial, @"\D", "").ToString();
                                //MessageBox.Show(CSN);
                                ZSMC.delet_chek(CSN);
                                TransactionActivity.TransactionLog TL = new TransactionActivity.TransactionLog();
                                TL.delete(PayID);
                                SelectPersonal();
                            }
                        }else{
                            TransactionActivity.TransactionLog TL = new TransactionActivity.TransactionLog();
                            TL.delete(PayID);
                            SelectPersonal();
                        }
                        
                    }
                }//////// End Validate Result of selected row from pay list
            }
            catch { }


        }

        private void tsmiOldRemainaccountDelete_Click(object sender, EventArgs e)
        {

            if (dgvReaminAccountList.Rows.Count > 0)
            {
                TransactionActivity.TransactionLog TL = new TransactionActivity.TransactionLog();
                DataTable dtRemainAccount = TL.Select(Convert.ToDecimal(dgvReaminAccountList.CurrentRow.Cells[0].Value));
                if (dtRemainAccount.Rows.Count == 1)
                {
                    string QMessage = "مانده حساب با مبلغ" + GS.nf(dtRemainAccount.Rows[0]["payPrice"].ToString()) + " و با شرح ( " + dtRemainAccount.Rows[0]["payAbout"].ToString() + " ) حذف شود؟";
                    if (GS.dialog.Question("حذف مانده حساب", QMessage) == DialogResult.OK)
                    {
                        decimal TLId = Convert.ToDecimal(dtRemainAccount.Rows[0]["id"].ToString());
                        TL.delete(TLId);
                        SelectPersonal();
                    }
                }
            }
        }

        private void tsmiPayEdit_Click(object sender, EventArgs e)
        {


            if (dgvAllPay.Rows.Count > 0)
            {
                Int16 PayID = Convert.ToInt16(dgvAllPay.CurrentRow.Cells[0].Value);

                TransactionActivity.TransactionLog TL = new TransactionActivity.TransactionLog();
                DataTable dtDFPP = TL.Select(PayID);///// DFPP= Delete From Person Pay

                if (dtDFPP != null)
                {
                    frmPay fp = new frmPay();

                    if (dtDFPP.Rows[0]["payMethod"].ToString() == "doc")
                    {
                        //frmCheck FC = new frmCheck();
                        //FC.PersonalId = Convert.ToInt16(CurrentPesonalID);
                        //FC.ShowDialog(this);
                        fp.Payis = "cheque";
                    }
                    else if (dtDFPP.Rows[0]["payMethod"].ToString() == "cash")
                    {
                        fp.Payis = "cash";
                    }

                    fp.CurrentPesonalID = Convert.ToDecimal(CurrentPesonalID);
                    fp.mode = "edit";
                    fp.PayId = Convert.ToDecimal(dgvAllPay.CurrentRow.Cells[0].Value);
                    fp.Text = "اصلاح پرداختی";
                    fp.ShowDialog(this);
                }




                
            }
        }

        private void dgvAllPay_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsmiPayEdit_Click(sender, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //reportViewer1.Visible = false;
            btnBack.Visible = false;
        }

        private void tsmiProformaEdit_Click(object sender, EventArgs e)
        {
            frmOrders fo = new frmOrders();
            Int16 InvoiceNo = Convert.ToInt16(dgvPish.CurrentRow.Cells[0].Value);
            fo.InvoiceType = Invoice.InvoiceType.proforma;
            Invoice.Current.Number= InvoiceNo;
            fo.OrderMode = frmOrders.ModeList.JustEdit;
            fo.ShowDialog(this);
        }

        private void tsmiR_Click(object sender, EventArgs e)
        {

        }

        private void تغییرشخصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtSellerName.Text = string.Empty;
            txtName_Enter(sender, e);
        }
    }
}
