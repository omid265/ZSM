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
using ManoloSellManager.Forms;
namespace ManoloSellManager
{
    public partial class frmSettings : Form
    {
        string SelectedInvoiceDescription;
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT * FROM `setting` WHERE `SettingName`<>'users;کاربر'";
                dgvInvoicePrintSettin.AutoGenerateColumns = false;
                dgvInvoicePrintSettin.DataSource = GS.db.Query(Query);
                foreach (DataRow dr in GS.db.Result.Rows)
                {
                    cbTitle.Items.Add(string.Format("{0};{1};{2}"
                        , dr[0]
                        , dr[1].ToString().Split(';')[0]
                        , dr[1].ToString().Split(';')[1]
                        ));
                }
            }catch(Exception ex)
            {
                MessageBox.Show("در نمایش تنظیمات مشکلی به وجود آمده است لطفا."+"\n"+ ex.Message, "",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void btnAddDescription_Click(object sender, EventArgs e)
        {
            string SettingName;
            if (cbTitle.Text.Length < 3 || cbTitle.Text.Split(';').Length<2)
            {
                MessageBox.Show("لطفا عنوان را با فرمت مناسب انتخاب و یا وارد کنید.");
                return;
            }
                if(cbTitle.Text.Split(';').Length>2){
                    SettingName = cbTitle.Text.ToString().Split(';')[1];
                    SettingName += ";"+cbTitle.Text.ToString().Split(';')[2];
                }else{
                    SettingName = cbTitle.Text.ToString().Split(';')[0];
                    SettingName +=";"+ cbTitle.Text.ToString().Split(';')[1];
                }

            string Query = "INSERT INTO  `setting` "
                + "(`id` ,`SettingName` ,`SettingValue`)"
                        + "VALUES "
                        + "("
                        + "NULL ,  '"+SettingName+"',  '"+txtDescription.Text+"'"
                        + ");";
            GS.db.Query(Query);
            frmSettings_Load(sender, e);
            txtDescription.Text = "";
            cbTitle.Text = "";
            btnAddDescription.Enabled = false;
        }

        private void dgvInvoicePrintSettin_DoubleClick(object sender, EventArgs e)
        {

            //DataGridView dgv = ((DataGridView)sender);
            //string settingName = dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            //if (settingName.ToLower().Contains("logo"))
            //{
            //    MessageBox.Show(dgv.Rows[dgv.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            //}



            //// RI=Row Index
            int RI=dgvInvoicePrintSettin.CurrentRow.Index;
            string settingName= dgvInvoicePrintSettin.Rows[RI].Cells[0].Value.ToString();
            string settingValue= dgvInvoicePrintSettin.Rows[RI].Cells[1].Value.ToString();
            bool callTextChange = false;

            if (settingName.ToLower().Contains("logo"))
            {
                ofdLogo.ShowDialog(this);
                if (ofdLogo.FileName != string.Empty)
                {
                    settingValue = ofdLogo.FileName;
                    callTextChange = true;
                }
            }

            cbTitle.Text = settingName;
            txtDescription.Text = settingValue;

            SelectedInvoiceDescription = txtDescription.Text;

            btnDelete.Enabled = true;
            btnCancel.Enabled = true;
            if (callTextChange == true)
            {
                txtDescription_TextChanged(txtDescription, e);
                //btnSaveChanges.Enabled = true;
            }
            else
            {
                btnSaveChanges.Enabled = false;
            }
            btnAddDescription.Enabled = false;
            cbTitle.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GS.dialog.Question("حذف متن توضیحات فاکتور", "از حذف این مورد اطمینان دارید؟") == DialogResult.OK)
            {
                string QueryValue = SelectedInvoiceDescription;
                GS.db.Query("DELETE FROM `setting` WHERE `SettingValue`='" + QueryValue + "'");
                frmSettings_Load(sender, e);

            }//// End Question Control
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription.Text != "" && btnCancel.Enabled == true)
            {
                btnSaveChanges.Enabled = true;
            }
            else if (txtDescription.Text != "" && btnCancel.Enabled == false && cbTitle.Text.Length>0)
            {
                btnAddDescription.Enabled = true;
                cbTitle.Enabled = true;
            }

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (GS.dialog.Question("ویرایش تنظیمات فاکتور", "با ثبت تغییرات موافق هستید؟") == DialogResult.OK)
            {
                string QueryValue = SelectedInvoiceDescription;
                QueryValue = "UPDATE  `setting` SET  `SettingValue` =  '"+txtDescription.Text+"' WHERE  `SettingValue` ='" + QueryValue + "'";
                GS.db.Query(QueryValue);
                frmSettings_Load(sender, e);
                btnCancel_Click(sender, e);

            }//// End Question Control
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSaveChanges.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnAddDescription.Enabled = true;
            cbTitle.Enabled = true;

            txtDescription.Text = "";

        }
    }
}
