using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ManoloSellManager.Class;
namespace ManoloSellManager.Forms
{
    public partial class frmMain : Form
    {
        
        Class.Generals GS = Class.Generals.CreateGenerals();

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPersonals_Click(object sender, EventArgs e)
        {
            new frmPersonal().ShowDialog(this);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            new frmStore().ShowDialog(this);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrders fo = new frmOrders();
            fo.InvoiceType = Invoice.InvoiceType.sell;
            fo.ShowDialog(this);
        }

        private void btnPersonalAccounts_Click(object sender, EventArgs e)
        {
            new frmPersonalAccount().ShowDialog(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //////////////////////////[ Start Sample of Using TransactionLog system ]///////////////
            //TransactionActivity.TransactionLog TL = new TransactionActivity.TransactionLog();
            //var tt=new TransactionActivity.Transaction();
            //tt.PersonalID = 1;
            //TransactionActivity.TransactionMethodType ttm =  TransactionActivity.TransactionMethodType.Order;
            //tt.TranactionMethod = ttm;
            //tt.TransactionDescription = "Test New Record in Here";
            //tt.TransactionTime = DateTime.Now.TimeOfDay.ToString();
            //tt.TranstionDate = GS.GetCurrentDate();
            //TransactionActivity.TransactionType ttp = TransactionActivity.TransactionType.Order;
            //tt.TranstionFor = ttp;
            //MessageBox.Show(TL.NewTransaction(tt).ToString());
            //MessageBox.Show(TL.CalcPersonalPriceOfCashPay(1).ToString());
            //////////////////////////[ End Sample of Using TransactionLog system ]///////////////
            /////////////////////////////////////////////////////////////////////////////////////


            /////////// Fix it
            //ALTER TABLE  `invoice` CHANGE  `InvoiceId`  `InvoiceId` INT( 11 ) NOT NULL



            GS.db.Query("ALTER TABLE  `accounting` ADD  `status` INT( 1 ) NOT NULL", false);
            switch (GS.db.QueryMessage)
            {
                case "Duplicate column name 'status'":
                    //MessageBox.Show("این فیلد ساخته شده است.");
                    break;
                default:
                    GS.db.Query("UPDATE  `accounting` SET  `status` =  '2' WHERE  `payType` ='pay' ;", false);
                    GS.db.Query("UPDATE  `accounting` SET  `status` =  '1' WHERE  `payType` ='get' OR `payType` ='Order';", false);

                    break;
            }
            GS.db.Query("ALTER TABLE  `accounting` ADD  `remainaccount` FLOAT NOT NULL ;", false);
            switch (GS.db.QueryMessage)
            {
                case "Duplicate column name 'remainaccount'":
                    //MessageBox.Show("این فیلد ساخته شده است.");
                    break;
                default:
                    //GS.db.Query("UPDATE  `accounting` SET  `status` =  '2' WHERE  `payType` ='pay' ;", false);
                    //GS.db.Query("UPDATE  `accounting` SET  `status` =  '1' WHERE  `payType` ='get' OR `payType` ='Order';", false);

                    break;
            }
            GS.db.Query("ALTER TABLE  `invoice` ADD  `InvoicePrice` FLOAT NOT NULL AFTER  `InvoiceTime`", false);
            switch (GS.db.QueryMessage)
            {
                case "Duplicate column name 'remainaccount'":
                    //MessageBox.Show("این فیلد ساخته شده است.");
                    break;
                default:
                    //GS.db.Query("UPDATE  `accounting` SET  `status` =  '2' WHERE  `payType` ='pay' ;", false);
                    //GS.db.Query("UPDATE  `accounting` SET  `status` =  '1' WHERE  `payType` ='get' OR `payType` ='Order';", false);

                    break;
            }
            GS.db.Query("ALTER TABLE  `invoicedetails` ADD  `PricePerAny` FLOAT NOT NULL", false);
            switch (GS.db.QueryMessage)
            {
                case "Duplicate column name 'PricePerAny'":
                    //MessageBox.Show("این فیلد ساخته شده است.");
                    break;
                default:
                    DataTable dtT = new DataTable();
                    dtT = GS.db.Query("SELECT (`ItemPrice`/`itemUnitfi`) AS `EE`,`id` FROM `invoicedetails` WHERE `itemUnitfi`>0 ORDER BY `id` ASC");
                    foreach (DataRow drR in dtT.Rows)
                    {
                        GS.db.Query("UPDATE `invoicedetails` SET `PricePerAny`='" + drR["EE"] + "' WHERE `id`='" + drR["id"] + "'", false);
                    }



                    DataTable dtT2 = new DataTable();
                    dtT2 = GS.db.Query("SELECT (`ItemPrice`/`itemCount`) AS `EE`,`id` FROM `invoicedetails` WHERE `itemUnitfi`=0 ORDER BY `id` ASC");
                    foreach (DataRow drR in dtT2.Rows)
                    {
                        GS.db.Query("UPDATE `invoicedetails` SET `PricePerAny`='" + drR["EE"] + "' WHERE `id`='" + drR["id"] + "'", false);
                    }


                    //GS.db.Query("UPDATE  `accounting` SET  `status` =  '1' WHERE  `payType` ='get' OR `payType` ='Order';", false);

                    break;
            }


            //GS.Backup();


            /////////////////////   who to use from pdp //////////////////////
            //pdp.PinTo = txtDate;

            //this.Controls.Add(pdp);
            /////////////////////////////////////////////////////////////////




            //string mn = "Omid";
            //MessageBox.Show(mn.Remove(2));

            //string Values = "RefValue";
            //if (InputBox("TitleText", "PrompetText", ref Values) == DialogResult.OK)
            //{
            //    MessageBox.Show("");
            //}
            string fields = "lenght:*;width:/;func:6.25;";
            string[] fi = fields.Split(':');
            foreach (string words in fi)
            {
                //MessageBox.Show(words.ToString());
            }

            lblCurrentDate.Text = "امروز :" + GS.dateManager.GetCurrentPersianDate();


            GS.Backup();



        }///// End frmMain_Load Void

        private void btnChek_Click(object sender, EventArgs e)
        {
            new frmCheck().ShowDialog(this);
        }

        private void btnShoraka_Click(object sender, EventArgs e)
        {
            new frmSharik().ShowDialog(this);
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            try
            {
                new frmSettings().ShowDialog(this);
            }
            catch { }
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

        private void tsmiItemSell_Click(object sender, EventArgs e)
        {
            new frmReports().ShowDialog(this);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GS.Backup();

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form ff in Application.OpenForms)
            {
                ff.Close();
            }
        }

        private void tsmiDueList_Click(object sender, EventArgs e)
        {
            new frmAllPeopleRemainAccount().ShowDialog(this);
        }

        private void btnBuyInvoice_Click(object sender, EventArgs e)
        {
            frmOrders fo = new frmOrders();
            fo.InvoiceType = Invoice.InvoiceType.sell;
            fo.ShowDialog(this);
        }
    }
}
