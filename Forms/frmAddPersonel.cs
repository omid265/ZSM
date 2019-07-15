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
    public partial class frmAddPersonel : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();


        DataTable dtPersonelList = new DataTable();
        public frmAddPersonel()
        {
            InitializeComponent();
            //loadDt();
        }

        //private void loadDt(string Sort = "ASC")
        //{
        //    dtPersonelList = GS.db.Query("SELECT * FROM `personels` ORDER BY `id`" + Sort);
        //}

        private void txtPay_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        private void Validation()
        {
            if (txtAddress.Text == "" || txtName.Text == "" || txtHireDate.Text == "" || txtJob.Text == "" || txtNCode.Text == "" || txtPay.Text == "")
            {
                btnSave.Enabled = false;
            }
            else
                btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkNcode())
            {
                addPersonel();
                MessageBox.Show("با موفقیت ثبت شد");
                this.Close();
            }
            else
            {
                MessageBox.Show("این شماره ملی قبلا ثبت شده است");
            }
        }

        private bool checkNcode()
        {
            dtPersonelList = GS.db.Query("SELECT * FROM `personels` WHERE `ncode` = '" + txtNCode.Text + "'");
            if (dtPersonelList.Rows.Count == 0)
            {
                return true;
            }else
            {
                return false;
            }
        }

        private void addPersonel()
        {
            try
            {
                DataTable dtNew = GS.db.Query("INSERT INTO `personels"
                    + "`(`name`,`hireDate`,`ncode`,`job`,`pay`,`address`)"
                    + "VALUE("
                    + "'" + txtName.Text + "'"
                    + ",'" + txtHireDate.Text + "'"
                    + ",'" + txtNCode.Text + "'"
                    + ",'" + txtJob.Text + "'"
                    + ",'" + txtPay.Text + "'"
                    + ",'" + txtAddress.Text + "'"
                    + ")");
            }
            catch
            {
                MessageBox.Show("خطا در ثبت");
                this.Close();
            }
        }

        private void txtHireDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        private void txtHireDate_Enter(object sender, EventArgs e)
        {
            GS.dateManager.pdp.ShowDatePicker();
        }

        private void frmAddPersonel_Load(object sender, EventArgs e)
        {
            GS.dateManager.pdp.PinTo = txtHireDate;
            this.Controls.Add(GS.dateManager.pdp);
        }
    }
}
