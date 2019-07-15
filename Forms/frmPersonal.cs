using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using ManoloSellManager.Class;

namespace ManoloSellManager.Forms
{
    public partial class frmPersonal : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();
        Clients c = new Clients();
        DataTable dtPersonalList = new DataTable();
        string SPI = "";//// SPI= Selected Personal Id
        bool InEdit = false,
            InNew=false;
        public frmPersonal()
        {
            InitializeComponent();
            LoadPersonal();
        }

        private void fixedElement(Boolean status)
        {
            btnCancel.Enabled = status;
            btnEdit.Enabled = !status;
            btnRemove.Enabled = status;
            btnSave.Enabled = status;
            btnNew.Enabled = !status;
        }
        private void LoadPersonal(string Sort = "ASC")
        {
            
            
            dtPersonalList = c.getClientsList("ORDER By `id` " + Sort);
            dgvPersonalsList.AutoGenerateColumns = false;
            dgvPersonalsList.DataSource = dtPersonalList;
        }
        private void Validation()
        {
            //if (cbType.Text == "" || txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            //if (cbType.Text == "" || txtName.Text == "" || txtPhone.Text == "")
            //{
            //    //btnSave.Enabled = false;
            //}
            //else
            //    btnSave.Enabled = true;
        }


        private void cbType_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Validation();
            dtPersonalList = GS.db.Query("SELECT * FROM `personals` WHERE `name`LIKE '%" + GS.SafeFarsiStr(txtName.Text) + "%'");
            dgvPersonalsList.DataSource = dtPersonalList;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            Validation();
            dtPersonalList = GS.db.Query("SELECT * FROM `personals` WHERE `phone`LIKE '" + txtPhone.Text + "%'");
            dgvPersonalsList.DataSource = dtPersonalList;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            Validation();
        }

        private void ResetForm()
        {
            SPI = "";
            cbType.Text = "";
            txtName.Text = "";
            txtNikname.Text = "";
            txtCompanyName.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtCompanyPhone.Text = "";
            txtFax.Text = "";
            txtAddress.Text = "";
            txtCompanyAddress.Text = "";
            InEdit = false;
            InNew = false;
            fixedElement(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Clients.Client newClient = ViewToModel();
            if (InEdit == true)
            {
                if (newClient.ID == 0)
                {
                    MessageBox.Show("مشتری به درستی انتخاب نشده است.");
                    return;
                }
                Clients.Items.Update(newClient);
            }
            else if(InNew==true)
            {
                Clients.Items.Add(newClient);
            }

            LoadPersonal("DESC");
            ResetForm();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvPersonalsList.CurrentCell.RowIndex;

                int cellIndex = 0;

                string PersonalCode = dgvPersonalsList.Rows[rowIndex].Cells[cellIndex].Value.ToString();
                string PersonalName = dgvPersonalsList.Rows[rowIndex].Cells[1].Value.ToString();


                DataTable dtThisInvoice = GS.db.Query("SELECT * FROM `invoice` WHERE `InvoiceUserId`='" + PersonalCode + "'");
                if (dtThisInvoice.Rows.Count > 0)
                {
                    MessageBox.Show(PersonalName + " " + "دارای صورت حساب می باشد و به همین دلیل امکان حذف وجود ندارد." + "\nلطفا ابتدا صورت حساب های شخص را حذف نمایید");
                }
                else
                {

                    if (MessageBox.Show('"' + PersonalName + '"' + "حذف شود؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //DataTable dtRemove = GS.db.Query("DELETE FROM `personals` WHERE `id`='" + PersonalCode + "' LIMIT 1");

                        Clients.Items.Delete(Convert.ToInt32(PersonalCode));
                        LoadPersonal();
                        ResetForm();
                    }
                }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadPersonal();
            ResetForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SearchQuery = "WHERE ";

            if (txtName.Text != "")
            {
                SearchQuery += "`name` LIKE '%" + GS.SafeFarsiStr(txtName.Text) + "%'";
            }

            dtPersonalList = c.getClientsList(SearchQuery);
            dgvPersonalsList.DataSource = dtPersonalList;
            btnReload.Visible = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            btnReload.Visible = false;
            LoadPersonal();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            fixedElement(true);
            InEdit = true;
            int rowIndex = dgvPersonalsList.CurrentCell.RowIndex;
            //int cellIndex = dgvSeller.CurrentCell.ColumnIndex;
            int cellIndex = 0;

            SPI = dgvPersonalsList.Rows[rowIndex].Cells[cellIndex].Value.ToString();

            DataTable dtP = new DataTable();
            dtP = GS.db.Query("SELECT * FROM `personals` WHERE `id`='" + SPI + "'");

            ModelToView(dtP.Rows[0]);
        }
        public void ModelToView(Clients.Client client)
        {
            ////////////////////////////// Start Set Personal Details to windows form ////////////////////////
            txtName.Text = client.name;
            //CurrentPesonalID = dtP.Rows[0]["id"].ToString();
            txtPhone.Text = client.phone;
            txtFax.Text = client.Fax;
            txtMobile.Text = client.mobile;
            txtAddress.Text = client.Address;
            //cbType.Text = Clients.ConvertClientType(client.type);
            cbType.Text = client.TypeToString();
            txtNikname.Text = client.nickName;

            txtCompanyAddress.Text = client.CompanyAddress;
            txtCompanyName.Text = client.CompanyName;
            txtCompanyPhone.Text = client.CompanyPhone;
        }

        public void ModelToView(DataRow Row)
        {
            ////////////////////////////// Start Set Personal Details to windows form ////////////////////////
            txtName.Text = Row["name"].ToString();
            //CurrentPesonalID = Row["id"].ToString();
            txtPhone.Text = Row["phone"].ToString();
            txtFax.Text = Row["fax"].ToString();
            txtMobile.Text = Row["mobile"].ToString();
            txtAddress.Text = Row["address"].ToString();
            cbType.Text = Clients.ConvertClientType(Convert.ToInt32(Row["type"].ToString()));
            txtNikname.Text = Row["nickName"].ToString();

            txtCompanyAddress.Text = Row["CompanyAddress"].ToString();
            txtCompanyName.Text = Row["CompanyName"].ToString();
            txtCompanyPhone.Text = Row["CompanyPhone"].ToString();
        }

        public Clients.Client ViewToModel()
        {
            Clients.Client c= new Clients.Client
            {
                Address = txtAddress.Text,
                CompanyAddress = txtCompanyAddress.Text,
                CompanyName = txtCompanyName.Text,
                CompanyPhone = txtCompanyPhone.Text,
                Fax = txtFax.Text,
                mobile = txtMobile.Text,
                name = txtName.Text,
                nickName = txtNikname.Text,
                phone = txtPhone.Text,
                type = Clients.ConvertClientType(cbType.Text)
            };
            if (string.IsNullOrEmpty(SPI) || string.IsNullOrWhiteSpace(SPI))
            {
                c.ID=0;
            }
            else
            {
                c.ID = Convert.ToInt32(SPI);
            }
            return c;
        }
       private void dgvPersonalsList_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void جدیدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRemove_Click(sender, e);
        }

        private void ثبتذخیرهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            InNew = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
            btnNew.Enabled = false;
            btnCancel.Enabled = true;
            cbType.Text = Clients.ConvertClientType(Clients.ClientType.Customer);
            txtName.Focus();
        }
    }
}
