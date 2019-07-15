using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManoloSellManager.Class;


namespace ManoloSellManager.Forms
{
    public partial class frmPay : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();

        int PayType { set; get; }
        string PayDescription;
        public decimal CurrentPesonalID { set; get; }
        public string mode { set; get; }
        public decimal PayId { set; get; }
        public string Payis { set; get; }

        TransactionActivity.TransactionLog TL = new TransactionActivity.TransactionLog();
        public frmPay()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if ((txtPrice.Text != "") && (GS.IsNumber(txtPrice.Text) == true) && (rbPos.Checked == true || rbCash.Checked == true||rbCheque.Checked==true))
            {
                switch (PayType)
                {
                    case 1:
                        PayDescription = "پرداخت وجه نقد - اسکناس"+" - "+txtDescription.Text;
                        break;
                    case 2:
                        PayDescription = "پرداخت وجه نقد - کارت" + " - " + txtDescription.Text;
                        break;
                }


                try
                {
                    if (mode == "edit")
                    {
                        if (Payis!="cheque")
                            TL.Edit(PayId, Convert.ToDouble(txtPrice.Text), PayDescription, txtDate.Text, CurrentPesonalID);
                        else
                            TL.Edit(PayId,  txtDate.Text);

                    }
                    else
                    {
                        //////////// NT= New Transaction
                        TransactionActivity.Transaction NT = new TransactionActivity.Transaction();


                        ////////// TTO= Transaction Type Order
                        TransactionActivity.TransactionType TTO = TransactionActivity.TransactionType.pay;

                        ///////// TMT= Transaction Method Type
                        TransactionActivity.TransactionMethod TMT = TransactionActivity.TransactionMethod.cash;

                        //////// set transaction Price
                        NT.Amount = Convert.ToDecimal(txtPrice.Text);
                        /////// personal id for this transaction
                        NT.PersonalID = CurrentPesonalID;

                        NT.Method = TMT;
                        NT.Description = PayDescription;
                        NT.Time = DateTime.Now.ToShortTimeString();
                        if (string.IsNullOrEmpty(txtDate.Text))
                        {
                            MessageBox.Show("لطفا تاریخ پرداخت را مشخص کنید.");
                            txtDate.Focus();
                            return;
                        }
                        NT.Date = txtDate.Text;
                        NT.Type = TTO;
                        NT.RemainAccount = TL.RemainAccount(CurrentPesonalID) - Convert.ToDecimal(NT.Amount);
                        byte DFF = Convert.ToByte(TransactionActivity.TransactionStatus.Bestankar);
                        NT.Status = DFF;
                        TL.NewTransaction(NT);
                    }
                    MessageBox.Show("ثبت پرداخت با موفقیت انجام شد.");
                    txtPrice.Text = "";
                    txtDate.Text = "";
                    frmPay_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("لطفا فقط عدد وارد کنید.");
                }

            }
            else
            {
                MessageBox.Show("لطفا مبلغ و سایر اطلاعات را وارد کنید");
            }/////// end price validation
        }

        private void frmPay_Load(object sender, EventArgs e)
        {

            switch (mode)
            {
                case "edit":
                    DataTable dtPayCash = TL.GetPay(CurrentPesonalID,PayId);
                    if (dtPayCash != null)
                    {

                        txtDate.Text = GS.dateManager.OrderDate(Convert.ToDateTime(dtPayCash.Rows[0]["payDate"].ToString()));

                        txtPrice.Text = dtPayCash.Rows[0]["payPrice"].ToString();
                        PayDescription = dtPayCash.Rows[0]["payAbout"].ToString();
                        if (PayDescription.IndexOf("کارت") == -1)
                        {
                            rbCash.Checked = true;
                        }
                        else
                        {
                            rbPos.Checked = true;
                        }
                        if (Payis == "cheque")
                        {
                            rbCash.Enabled = false;
                            rbPos.Enabled = false;
                            rbCheque.Checked = true;
                            rbCheque.Enabled = true;
                            txtPrice.Enabled = false;
                            txtDate.Enabled = false;
                            label1.TabIndex = 14;
                            txtPrice.TabIndex = 15;
                            rbCheque.TabIndex = 0;
                            rbCheque.Focus();
                            txtDate.Enabled = true;

                        }
                    }

                    break;
                default:
                    
                    break;
            }///// End Switch

            GS.dateManager.pdp.PinTo = txtDate;
            this.Controls.Add(GS.dateManager.pdp);

            dgvPayList.AutoGenerateColumns = false;
            dgvPayList.DataSource = TL.GetAllPayList(CurrentPesonalID);
            //txtDate.Text = GS.dateManager.CurrentDate.ToShortDateString().ToString() ;
        }

        private void txtDate_Enter(object sender, EventArgs e)
        {
            GS.dateManager.pdp.ShowDatePicker();
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            PayType = 1;// 1=cash
        }

        private void btPos_CheckedChanged(object sender, EventArgs e)
        {
            PayType = 2;//2=pos
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ذخیرهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdd_Click(sender, e);
        }
    }
}
