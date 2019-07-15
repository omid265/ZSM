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
    public partial class frmPayToPersonel : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();

        DataTable dtPersonelList = new DataTable();
        Int32 monthPay = 0;
        public frmPayToPersonel()
        {
            InitializeComponent();
        }

        private void txtSellerCode_TextChanged(object sender, EventArgs e)
        {
            dtPersonelList = GS.db.Query("SELECT * FROM `personels` WHERE `ncode`LIKE '" + txtNCode.Text + "%'");
            dgvPersonalsList.DataSource = dtPersonelList;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dtPersonelList = GS.db.Query("SELECT * FROM `personels` WHERE `name`LIKE '" + txtName.Text + "%'");
            dgvPersonalsList.DataSource = dtPersonelList;
        }

        private void dgvPersonalsList_DoubleClick(object sender, EventArgs e)
        {
            SelectPersonel();
        }

        private void btnSetSeller_Click(object sender, EventArgs e)
        {
            SelectPersonel();
        }

        private void SelectPersonel()
        {
            if (dgvPersonalsList.CurrentCell != null)
            {
                int rowIndex = dgvPersonalsList.CurrentCell.RowIndex;
                //int cellIndex = dgvSeller.CurrentCell.ColumnIndex;
                int cellIndex = 0;

                if (dtPersonelList.Rows.Count > 0)
                {
                    string PersonalCode = dgvPersonalsList.Rows[rowIndex].Cells[cellIndex].Value.ToString();
                    string PersonalName = "";

                    DataTable dtP = new DataTable();
                    DataTable dtPay = new DataTable();
                    dtP = GS.db.Query("SELECT * FROM `personels` WHERE `id`='" + PersonalCode + "'");

                    PersonalName = dtP.Rows[0]["name"].ToString();

                    ////////////////////////////// Start Set Personal Details to windows form ////////////////////////
                    txtNameM.Text = dtP.Rows[0]["name"].ToString();
                    txtNCodeM.Text = dtP.Rows[0]["ncode"].ToString();
                    monthPay = Convert.ToInt32(dtP.Rows[0]["pay"]);
                    txtNCodeM.Enabled = false;
                    txtNameM.Enabled = false;
                    btnAddSalery.Enabled = true;
                    btnDel.Enabled = true;
                    btnPayment.Enabled = true;
                    ////////////////////////////// End Set Personal Details to windows form ////////////////////////
                    gbPersonalsList.Visible = false;
                    dtPay = GS.db.Query("SELECT * FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                    dgvPaytoPersonels.DataSource = dtPay;
                    dgvPaytoPersonels.AutoGenerateColumns = true;
                    dtPay = GS.db.Query("SELECT SUM(payment) FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                    lblBlance.Text = dtPay.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("پرسنل ای در سیستم تعریف نشده است.");
                }
                //txtStoreItemCode.Focus();

                //calcPesonalAccountStatus();
            }
            else
            {
                MessageBox.Show("پرسنل مورد نظر شما در سیستم تعریف نشده است.");
            }////// End control dgvPersonalsList.CurrentCell

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            gbPersonalsList.Visible = false;
            gbPayment.Visible = false;
            gbSalary.Visible = false;
        }

        private void btnChose_Click(object sender, EventArgs e)
        {
            gbPersonalsList.Visible = true;
            txtNCode.Focus();
            dtPersonelList = GS.db.Query("SELECT * FROM `personels` ORDER BY `id`");
            dgvPersonalsList.DataSource = dtPersonelList;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbSalaryPay_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSalaryPay.Checked)
            {
                lbl1.Visible = false;
                lbl2.Visible = true;
                lbl3.Visible = true;
                cbMonthPay.Visible = true;
                cbYearPay.Visible = true;
                txtDescPay.Visible = false;
            }
            else
            {
                lbl1.Visible = true;
                lbl2.Visible = false;
                lbl3.Visible = false;
                cbMonthPay.Visible = false;
                cbYearPay.Visible = false;
                txtDescPay.Visible = true;
            }
        }

        private void btnAddSalery_Click(object sender, EventArgs e)
        {
            gbSalary.Visible = true;
            cbMonthSalary.Focus();
            txtSalary.Text = monthPay.ToString();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            gbPayment.Visible = true;
            txtPayValue.Focus();
        }

        private void btnSavePay_Click(object sender, EventArgs e)
        {
            if (txtSalary.Text != "" && txtSalaryOver.Text != "" && cbMonthSalary.Text != "" && cbYearSalary.Text != "")
            {
                Int32 p1 = Convert.ToInt32(txtSalary.Text);
                Int32 p2 = Convert.ToInt32(txtSalaryOver.Text);
                Int32 p3 = p1 + p2;
                DataTable dtNew = GS.db.Query("INSERT INTO `paypersonels"
                    + "`(`ncode`,`desc`,`payment`)"
                    + "VALUE("
                    + "'" + txtNCodeM.Text + "'"
                    + ",'حقوق ماه " + cbMonthSalary.Text + " سال " + cbYearSalary.Text + "'"
                    + ",'" + p3 + "'"
                    + ")");
                DataTable dtPay = GS.db.Query("SELECT * FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                dgvPaytoPersonels.DataSource = dtPay;
                dgvPaytoPersonels.AutoGenerateColumns = true;
                gbSalary.Visible = false;
                dtPay = GS.db.Query("SELECT SUM(payment) FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                lblBlance.Text = dtPay.Rows[0][0].ToString();
            }
        }

        private void btnAddPaymnt_Click(object sender, EventArgs e)
        {
            string a = "";
            Int32 p1 = 0;
            if (rbSalaryPay.Checked)
            {
                if (txtPayValue.Text != "" && cbMonthPay.Text != "" && cbYearPay.Text != "")
                {
                    p1 = Convert.ToInt32(txtPayValue.Text);
                    a = "پرداخت حقوق ماه " + cbMonthPay.Text + " سال " + cbYearPay.Text;
                    DataTable dtNew2 = GS.db.Query("INSERT INTO `allpayment`(`desc`, `payment`) VALUES ("
                    + "' " + a+" "+txtNameM.Text + "'"
                    + ",'" + p1 + "'"
                    + ")");
                    dtNew2 = GS.db.Query("SELECT `id` FROM `allpayment` ORDER BY `id` DESC LIMIT 1");
                    string idSetInAllPayment = dtNew2.Rows[0]["id"].ToString();
                    DataTable dtNew = GS.db.Query("INSERT INTO `paypersonels"
                    + "`(`ncode`,`desc`,`payment`,`idAllPayment`)"
                    + "VALUE("
                    + "'" + txtNCodeM.Text + "'"
                    + ",' " + a + "'"
                    + ",'" + -p1 + "'"
                    + ",'" + idSetInAllPayment + "'"
                    + ")");
                    DataTable dtPay = GS.db.Query("SELECT * FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                    dgvPaytoPersonels.DataSource = dtPay;
                    dgvPaytoPersonels.AutoGenerateColumns = true;
                    gbPayment.Visible = false;
                    dtPay = GS.db.Query("SELECT SUM(payment) FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                    lblBlance.Text = dtPay.Rows[0][0].ToString();
                }

            }
            else
            {
                if (txtPayValue.Text != "" && txtDescPay.Text != "")
                {
                    p1 = Convert.ToInt32(txtPayValue.Text);
                    a = txtDescPay.Text;
                    DataTable dtNew2 = GS.db.Query("INSERT INTO `allpayment`(`desc`, `payment`) VALUES ("
                    + "' " + a + " " + txtNameM.Text + "'"
                    + ",'" + p1 + "'"
                    + ")");
                    dtNew2 = GS.db.Query("SELECT `id` FROM `allpayment` ORDER BY `id` DESC LIMIT 1");
                    string idSetInAllPayment = dtNew2.Rows[0]["id"].ToString();
                    DataTable dtNew = GS.db.Query("INSERT INTO `paypersonels"
                    + "`(`ncode`,`desc`,`payment`,`idAllPayment`)"
                    + "VALUE("
                    + "'" + txtNCodeM.Text + "'"
                    + ",'" + a + "'"
                    + ",'" + -p1 + "'"
                    + ",'" + idSetInAllPayment + "'"
                    + ")");
                    DataTable dtPay = GS.db.Query("SELECT * FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                    dgvPaytoPersonels.DataSource = dtPay;
                    dgvPaytoPersonels.AutoGenerateColumns = true;
                    gbPayment.Visible = false;
                    dtPay = GS.db.Query("SELECT SUM(payment) FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                    lblBlance.Text = dtPay.Rows[0][0].ToString();
                }
            }
        }

        private void txtPayValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataTable dtPay = GS.db.Query("SELECT * FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
            if (dgvPaytoPersonels.CurrentCell != null)
            {
                int rowIndex = dgvPaytoPersonels.CurrentCell.RowIndex;
                //int cellIndex = dgvSeller.CurrentCell.ColumnIndex;
                int cellIndex = 0;

                if (dtPay.Rows.Count > 0)
                {
                    string PersonalCode = dgvPaytoPersonels.Rows[rowIndex].Cells[cellIndex].Value.ToString();
                    string idAllPayment = dgvPaytoPersonels.Rows[rowIndex].Cells[4].Value.ToString();
                    DataTable dtP = new DataTable();
                    dtP = GS.db.Query("DELETE FROM `paypersonels` WHERE `id`='" + PersonalCode + "'");
                    dtP = GS.db.Query("DELETE FROM `allpayment` WHERE `id`='" + idAllPayment + "'");

                    dtPay = GS.db.Query("SELECT * FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                    dgvPaytoPersonels.DataSource = dtPay;
                    dgvPaytoPersonels.AutoGenerateColumns = true;
                    dtPay = GS.db.Query("SELECT SUM(payment) FROM `paypersonels` WHERE `ncode`= '" + txtNCodeM.Text + "'");
                    lblBlance.Text = dtPay.Rows[0][0].ToString();
                }
            }
        }
    }
}
