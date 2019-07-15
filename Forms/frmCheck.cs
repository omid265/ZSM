using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Generals;

using ManoloSellManager.Class;


namespace ManoloSellManager
{

    public partial class frmCheck : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();
        
        chek ch = new chek();
        DataTable dtPersonalList = new DataTable();
        string OldSN;
        decimal OldCustomerNo;
        public Int16 PersonalId { set; get; }

        public frmCheck()
        {
            InitializeComponent();
        }

        private Boolean check_int(string a)
        {
            try
            {
                Convert.ToInt32(a);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Boolean check_Double(string a)
        {
            try
            {
                Convert.ToDouble(a);
                return true;
            }
            catch
            {
                return false;
            }
        }

        Boolean chType = new Boolean();
        private void btnAddchek_Click(object sender, EventArgs e)
        {
            //if (CustomerNo.Text != "" && dateTimeSaresid.Value.ToString() != "" && dateTimeDaryaft.Value.ToString() != "" && txtCHvajhe.Text != "" && txtCHcost.Text != "" && txtCHowner.Text != "" && txtCHnumber.Text != "" && txtCHbank.Text != "")
            if (CustomerNo.Text != "" && txtChequeDate.Text != "" && GS.dateManager.pdp.GetDate() != "" && txtCHvajhe.Text != "" && txtCHcost.Text != "" && txtCHowner.Text != "" && txtCHnumber.Text != "" && txtCHbank.Text != "")
            {
                if (check_int(CustomerNo.Text))
                {
                    if (check_Double(txtCHcost.Text))
                    {
                        string payType = "";
                        ////////// TTP= Transaction Type Pay
                        TransactionActivity.TransactionType TTP;
                        byte TS;


                        var tl = new TransactionActivity.TransactionLog();

                        //////////// NT= New Transaction
                        TransactionActivity.Transaction NT = new TransactionActivity.Transaction();

                        string Description = "";
                        byte Dff = 0;
                        //MessageBox.Show("BB: " + Dff);

                        if (rdbGet.Checked == true)
                        {
                            Dff = Convert.ToByte(TransactionActivity.TransactionStatus.Bestankar);
                            TTP = TransactionActivity.TransactionType.pay;
                            TS = Dff;//TransactionActivity.TransactionStatus.Bestankar;
                            payType = "get";
                            chType = false;
                            Description ="پرداخت چک با شماره:" + txtCHnumber.Text + "و تاریخ :"+ txtChequeDate.Text;
                            NT.RemainAccount = tl.RemainAccount(Convert.ToDecimal(CustomerNo.Text)) - Convert.ToDecimal(txtCHcost.Text);


                        }
                        else
                        {
                            Dff = Convert.ToByte(TransactionActivity.TransactionStatus.Bedehkar);

                            TTP = TransactionActivity.TransactionType.get;
                            TS = Dff;//TransactionActivity.TransactionStatus.Bedehkar;
                            payType = "pay";
                            chType = true;
                            Description =   "دریافت چک با شماره سریال:"+ txtCHnumber.Text + " ";
                            NT.RemainAccount = tl.RemainAccount(Convert.ToDecimal(CustomerNo.Text)) + Convert.ToDecimal(txtCHcost.Text);


                        }
                        int AddCheck=ch.add_to_chek(Convert.ToInt32(CustomerNo.Text), txtChequeDate.Text, GS.dateManager.pdp.GetDate(), txtCHvajhe.Text, Convert.ToDouble(txtCHcost.Text), txtCHowner.Text, txtCHnumber.Text, txtCHbank.Text, chType);
                        switch ( AddCheck)
                        {

                            case 1:
                            //if (PersonalId > 0)
                            //    Description = "پرداخت چک با شماره سریال:"+txtCHnumber.Text;
                            //else
                            //    Description = "";

                            //PayAmount = Convert.ToDecimal(GS.dialog.InputValue);




                            ///////// TMT= Transaction Method Type
                            TransactionActivity.TransactionMethod TMT = TransactionActivity.TransactionMethod.doc;

                            NT.Amount = Convert.ToDecimal(txtCHcost.Text);
                            NT.PersonalID = Convert.ToDecimal(CustomerNo.Text);
                            NT.Method = TMT;
                            NT.Description = Description;
                            NT.Time = DateTime.Now.ToShortTimeString();
                            NT.Date = GS.dateManager.GetCurrentPersianDate();
                            NT.Type = TTP;
                            NT.Status = TS;


                            tl.NewTransaction(NT);

                            //string payQuery = "INSERT INTO `accounting` (`personalId`,`payPrice`,`payAbout`,`payMethod`,`payType`,`payTime`,`payDate`) " +
                            //"VALUES(" +
                            //"'" + CustomerNo.Text + "'" +
                            //",'" + txtCHcost.Text + "'" +
                            //",'"+Description+"'" +
                            //",'doc'" +
                            //",'"+payType+"'" +
                            //",'" + DateTime.Now.ToShortTimeString() + "'" +
                            //",'" + GS.GetCurrentDate() + "'" +
                            //")";
                            //GS.db.Query(payQuery);

                            refresh_page();
                            if (PersonalId > 0)
                            {
                                this.Close();
                            }
                        break;
                            case 2:
                        
                                MessageBox.Show("شماره سریال چک تکراری می باشد. چکی با این شماره سریال در سیستم ثبت شده است.");
                            break;
                            case 0:
                                MessageBox.Show("ثبت چک با مشکل مواجه شده است! لطفا مجددا تلاش کنید.");
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("مبلغ صحیح وارد نشده");
                    }
                }
                else
                {
                    MessageBox.Show("شماره مشتری صحیح وارد نشده");
                }
            }
            else
            {
                MessageBox.Show("تمام فیلد ها را پر کنید");
            }
        }

        private void txtCHcost_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.NumPad0 || e.KeyCode != Keys.NumPad1 || e.KeyCode != Keys.NumPad2 || e.KeyCode != Keys.NumPad3 || e.KeyCode != Keys.NumPad4 || e.KeyCode != Keys.NumPad5 || e.KeyCode != Keys.NumPad6 || e.KeyCode != Keys.NumPad7 || e.KeyCode != Keys.NumPad8 || e.KeyCode != Keys.NumPad9) 
            {
            }
        }
        double RecivedChequePrice()
        {
            DataTable CS = new DataTable();
            if (PersonalId > 0)
                CS = GS.db.Query("SELECT SUM(`mablagh`) FROM `chek` WHERE `typeCheck`='1' AND `CustumerNo`='" + PersonalId + "'");
            else
                CS = GS.db.Query("SELECT SUM(`mablagh`) FROM `chek` WHERE `typeCheck`='1'");

            txtTotRecived.Text =GS.nf(CS.Rows[0][0].ToString());
            return Convert.ToDouble(CS.Rows[0][0].ToString());
        }

        double PayedChequePrice()
        {
            DataTable CS = new DataTable();
            if (PersonalId > 0)
                CS = GS.db.Query("SELECT SUM(`mablagh`) FROM `chek` WHERE `typeCheck`='0' AND `CustumerNo`='" + PersonalId + "'");
            else
                CS = GS.db.Query("SELECT SUM(`mablagh`) FROM `chek` WHERE `typeCheck`='0'");

            txtTotPayed.Text = GS.nf(CS.Rows[0][0].ToString());
            return Convert.ToDouble(CS.Rows[0][0].ToString());
        }

        private void load()
        {
            dGv_ch.DataSource = ch.read_chek(" ");
            //RecivedChequePrice();
            //PayedChequePrice();
            GS.dateManager.pdp.PinTo = txtChequeDate;
            this.Controls.Add(GS.dateManager.pdp);


        }

        private void frmCheck_Load(object sender, EventArgs e)
        {
            load();
            if (PersonalId > 0)
            {
                dtPersonalList = GS.db.Query("SELECT * FROM `personals` WHERE  `id`='"+PersonalId.ToString()+"'");
                if(dtPersonalList.Rows.Count>0){
                    txtCustomerName.Text=dtPersonalList.Rows[0]["name"].ToString();
                    txtCHowner.Text=dtPersonalList.Rows[0]["name"].ToString();
                    CustomerNo.Text=PersonalId.ToString();
                    CustomerNo.Enabled = false;
                    txtCHowner.Enabled = false;
                    GboxType.Enabled = false;
                    btnReload.Enabled = false;
                    //btnSearch.Enabled = false;
                    btnSearch_Click(sender, e);
                    btnAddchek.Enabled = true;
                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //btnAddchek.Enabled = false;
            string query = " id<>'' ";
            if (CustomerNo.Text != "")
            {
                query += " AND CustumerNo = '" + Convert.ToInt32(CustomerNo.Text) + "'";
            }
            //if (dateTimeSaresid.Value.ToString != ""){
            //    query += " AND t_saresid = '" + dateTimeSaresid.Value.ToString + "'";
            //}
            //if (dateTimeDaryaf.Value.ToString != ""){
            //    query += " AND t_sodor = '" + dateTimeDaryaf.Value.ToString + "'";
            //}
            if (txtCHvajhe.Text != "")
            {
                query += " AND dar_vajhe = '" + txtCHvajhe.Text + "'";
            }
            if (txtCHcost.Text != "")
            {
                query += " AND mablagh = '" + Convert.ToDouble(txtCHcost.Text) + "'";
            }
            if (txtCHowner.Text != "")
            {
                query += " AND saheb_hesab = '" + txtCHowner.Text + "'";
            }
            if (txtCHnumber.Text != "")
            {
                query += " AND serail_chek = '" + txtCHnumber.Text + "'";
            }
            if (txtCHbank.Text != "")
            {
                query += " AND bank = '" + txtCHbank.Text + "'";
            }
            if (CustomerNo.Text != "")
            {
                query += " AND CustumerNo = '" + CustomerNo.Text + "'";
            }

            dGv_ch.DataSource = ch.read_chek("where" + query);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnAddchek.Enabled = true;
            refresh_page();
        }

        private void refresh_page()
        {
            load();
            CustomerNo.Text = "";
            txtCustomerName.Text = "";
            //dateTimeSaresid.Value = System.DateTime.Now;
            
            txtCHvajhe.Text = "";
            txtCHcost.Text = "";
            txtCHowner.Text = "";
            txtCHnumber.Text = "";
            txtCHbank.Text = "";
            OldCustomerNo = 0;
            OldSN = "";
            rdbGet.Checked = true;
        }
        private void change_status(Boolean bo)
        {
            Boolean boo = false;
            if (bo == true) { boo = false; } else { boo = true; };
            CustomerNo.Enabled = boo;
            txtCustomerName.Enabled = boo;
            //dateTimeSaresid.Enabled = bo;
            txtChequeDate.Enabled = bo;
            txtCHvajhe.Enabled = boo;
            txtCHcost.ReadOnly = boo;
            txtCHowner.Enabled = boo;
            txtCHnumber.ReadOnly = boo;
            txtCHbank.ReadOnly = boo;
            rdbGet.Enabled = bo;
            rdbPay.Enabled = bo;
        }

        private void dGv_ch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAddchek.Enabled = false;
            btnReload.Enabled = false;
            btnSearch.Enabled = false;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnCancelEdit.Enabled = true;
            SelectChek();
            change_status(false);
            select = true;
        }

        private string strid = "";
        private Boolean select = false;






        private void SelectChek()
        {
            int rowIndex = dGv_ch.CurrentCell.RowIndex;
            //int cellIndex = dgvSeller.CurrentCell.ColumnIndex;
            //int cellIndex = 0;

            strid                     = dGv_ch.Rows[rowIndex].Cells[0].Value.ToString();
            string strCustomerNo      = dGv_ch.Rows[rowIndex].Cells[1].Value.ToString();
            string strdateTimeSaresid = dGv_ch.Rows[rowIndex].Cells[2].Value.ToString();
            string strdateTimeDaryaft = dGv_ch.Rows[rowIndex].Cells[3].Value.ToString();
            string strCHvajhe         = dGv_ch.Rows[rowIndex].Cells[4].Value.ToString();
            string doutxtCHcost       = dGv_ch.Rows[rowIndex].Cells[5].Value.ToString();
            string strCHowner         = dGv_ch.Rows[rowIndex].Cells[6].Value.ToString();
            string strCHnumber        = dGv_ch.Rows[rowIndex].Cells[7].Value.ToString();
            string strCHbank          = dGv_ch.Rows[rowIndex].Cells[8].Value.ToString();
            Boolean ChequeType        =Convert.ToBoolean(dGv_ch.Rows[rowIndex].Cells[9].Value);

            OldSN = strCHnumber;
            OldCustomerNo = Convert.ToDecimal(strCustomerNo);

            CustomerNo.Text = strCustomerNo;
            txtChequeDate.Text = strdateTimeSaresid;
            //dateTimeDaryaft.Value = Convert.ToDateTime(strdateTimeDaryaft) ;
            txtCHvajhe.Text = strCHvajhe;
            txtCHcost.Text = doutxtCHcost;
            txtCHowner.Text = strCHowner;
            txtCHnumber.Text = strCHnumber;
            txtCHbank.Text = strCHbank;

            if (ChequeType)
                rdbPay.Checked = true;
            else
                rdbGet.Checked = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {   
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            if (GS.dialog.Question("حذف چک", "آیا از حذف این چک اطمینان دارید؟") == DialogResult.OK)
            {
                change_status(true);
                btnAddchek.Enabled = true;
                btnReload.Enabled = true;
                btnSearch.Enabled = true;
                ch.delet_chek(Convert.ToInt16(strid));
                refresh_page();
            }
            else
            {
                change_status(true);
                btnAddchek.Enabled = true;
                btnReload.Enabled = true;
                btnSearch.Enabled = true;
                refresh_page();
            }
            
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnCancelEdit.Enabled = true;
            btnOKEdit.Enabled = true;
            change_status(true);
             dateTimeSaresid_change = false;
             dateTimeDaryaft_change = false;
             txtCHvajhe_change = false;
             txtCHcost_change = false;
             txtCHowner_change = false;
             txtCHnumber_change = false;
             txtCHbank_change = false;
             CustomerNo_change = false;
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            btnAddchek.Enabled = true;
            btnReload.Enabled = true;
            btnSearch.Enabled = true;
            btnCancelEdit.Enabled = false;
            btnOKEdit.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            change_status(true);
            refresh_page();
        } 

        private void btnOKEdit_Click(object sender, EventArgs e)
        {
            string query = " `id` ='" + Convert.ToInt16(strid)+"'";
            string change = "`id` = '" + Convert.ToInt16(strid) + "'";
            if (CustomerNo_change)
            {
                change += " , `CustumerNo` = '" + Convert.ToInt32(CustomerNo.Text) + "'";
            }
            if (dateTimeSaresid_change)
            {
                change += " , `t_saresid` = '" + txtChequeDate.Text + "'";
            }
            //if (dateTimeDaryaft_change)
            //{
            //    change += " , `t_sodor` = '" + dateTimeDaryaft.Value.ToString() + "'";
            //}
            if (txtCHvajhe_change)
            {
                change += " , `dar_vajhe` = '" + txtCHvajhe.Text + "'";
            }
            if (txtCHcost_change)
            {
                change += " , `mablagh` = '" + Convert.ToDouble(txtCHcost.Text) + "'";
            }
            if (txtCHowner_change)
            {
                change += " , `saheb_hesab` = '" + txtCHowner.Text + "'";
            }
            if (txtCHnumber_change)
            {
                change += " , `serail_chek` = '" + txtCHnumber.Text + "'";
            }
            if (txtCHbank_change)
            {
                change += " , `bank` = '" + txtCHbank.Text + "'";
            }

            TransactionActivity.TransactionLog TL = new TransactionActivity.TransactionLog();
            TL.Edit("پرداخت چک با شماره سریال:" + OldSN + " ", "پرداخت چک با شماره سریال:" + txtCHnumber.Text + " ", OldCustomerNo,Convert.ToDecimal(CustomerNo.Text), Convert.ToDouble(txtCHcost.Text));

            //MessageBox.Show(change+"::::"+query);
            change += " , `typeCheck` = '" + (Convert.ToInt16(rdbGet.Checked ? false : rdbPay.Checked)).ToString() + "'";
            //change += ;
            ch.edit_chek(query, change);
            btnAddchek.Enabled = true;
            btnReload.Enabled = true;
            btnSearch.Enabled = true;
            btnCancelEdit.Enabled = false;
            btnOKEdit.Enabled = false;
            refresh_page();
        }

        private Boolean dateTimeSaresid_change = false;
        private Boolean dateTimeDaryaft_change = false;
        private Boolean txtCHvajhe_change = false;
        private Boolean txtCHcost_change = false;
        private Boolean txtCHowner_change = false;
        private Boolean txtCHnumber_change = false;
        private Boolean txtCHbank_change = false;
        private Boolean CustomerNo_change = false;

        private void txtCHvajhe_TextChanged(object sender, EventArgs e)
        {
            txtCHvajhe_change = true;
        }

        private void txtCHcost_TextChanged(object sender, EventArgs e)
        {
            txtCHcost_change = true;
        }

        private void txtCHowner_TextChanged(object sender, EventArgs e)
        {
            txtCHowner_change = true;
        }

        private void txtCHnumber_TextChanged(object sender, EventArgs e)
        {
            txtCHnumber_change = true;
        }

        private void txtCHbank_TextChanged(object sender, EventArgs e)
        {
            txtCHbank_change = true;
        }

        private void CustomerNo_TextChanged(object sender, EventArgs e)
        {
            CustomerNo_change = true;
        }

        private void txtChequeDate_Enter(object sender, EventArgs e)
        {
            //GS.pdp.PinTo = txtChequeDate;
            GS.dateManager.pdp.ShowDatePicker();
        }

        private void txtChequeDate_TextChanged(object sender, EventArgs e)
        {
            dateTimeSaresid_change = true;
        }

        private void CustomerNo_Enter(object sender, EventArgs e)
        {
            gbPersonalsList.Visible = true;
            txtSellerCode.Focus();
            dtPersonalList= GS.db.Query("SELECT * FROM `personals` ORDER BY `id`");
            dgvPersonalsList.DataSource = dtPersonalList;
             
        }
        private void txtSellerName_TextChanged(object sender, EventArgs e)
        {
            dtPersonalList = GS.db.Query("SELECT * FROM `personals` WHERE `name`LIKE '%" + txtSellerName.Text + "%'");
            dgvPersonalsList.DataSource = dtPersonalList;
        }

        private void txtSellerPhone_TextChanged(object sender, EventArgs e)
        {
            dtPersonalList = GS.db.Query("SELECT * FROM `personals` WHERE `phone`LIKE '%" + txtSellerPhone.Text + "%'");
            dgvPersonalsList.DataSource = dtPersonalList;
        }

        private void txtSellerCode_TextChanged(object sender, EventArgs e)
        {
            dtPersonalList = GS.db.Query("SELECT * FROM `personals` WHERE `id`LIKE '" + txtSellerCode.Text + "%'");
            dgvPersonalsList.DataSource = dtPersonalList;
        }

        private void btnSetSeller_Click(object sender, EventArgs e)
        {
            SelectPersonal();
        }
        private void dgvPersonalsList_DoubleClick(object sender, EventArgs e)
        {
            SelectPersonal();
        }
        private void SelectPersonal()
        {
            if (dgvPersonalsList.CurrentCell != null)
            {
                int rowIndex = dgvPersonalsList.CurrentCell.RowIndex;
                //int cellIndex = dgvSeller.CurrentCell.ColumnIndex;
                int cellIndex = 0;

                if (dtPersonalList.Rows.Count > 0)
                {
                    string PersonalCode = dgvPersonalsList.Rows[rowIndex].Cells[cellIndex].Value.ToString();
                    string PersonalName = "";

                    DataTable dtP = new DataTable();
                    dtP = GS.db.Query("SELECT * FROM `personals` WHERE `id`='" + PersonalCode + "'");

                    PersonalName = dtP.Rows[0]["name"].ToString();

                    ////////////////////////////// Start Set Personal Details to windows form ////////////////////////
                    txtCustomerName.Text = dtP.Rows[0]["name"].ToString();
                    CustomerNo.Text = dtP.Rows[0]["id"].ToString();
                    txtCHowner.Text = dtP.Rows[0]["name"].ToString();
                    rdbGet.Checked = true;
                    ////////////////////////////// End Set Personal Details to windows form ////////////////////////
                    gbPersonalsList.Visible = false;
                }
                else
                {
                    ResetForm();
                    MessageBox.Show("مشتری یا فروشنده ای در سیستم تعریف نشده است.");
                }
                //txtStoreItemCode.Focus();

                //calcPesonalAccountStatus();
            }
            else
            {
                MessageBox.Show("فروشنده یا مشتری مورد نظر شما در سیستم تعریف نشده است.");
            }////// End control dgvPersonalsList.CurrentCell

        }

        private void ResetForm()
        {
            txtCustomerName.Text = "";
            CustomerNo.Text = "";
        }

        private void ttChequeType_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
