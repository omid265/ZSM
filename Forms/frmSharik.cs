using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using MySql.Data.MySqlClient;

using ManoloSellManager.Class;


namespace ManoloSellManager.Forms
{
    public partial class frmSharik : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();

        Sharik sh = new Sharik();
        Sood so = new Sood();
        DataTable sharikDT = new DataTable();
        

        public frmSharik()
        {
            InitializeComponent();
            load_sharik();
            
        }

        private Double all_share = new Double();
        private void cal_all_share ()
        {
            foreach (DataRow a in sharikDT.Rows)
            {
                Double stak = Convert.ToDouble(a[2]);
                all_share = all_share + stak;
            }
         }

        private void set_each_share()
        {
            foreach (DataRow a in sharikDT.Rows)
            {
                Double stak = Convert.ToDouble(a[2]);
                Double s_m = ((stak / all_share) * (so.get_sood_mah()));
                Double s_s = ((stak / all_share) * (so.get_sood_sal()));
                s_m = Math.Round(s_m, 2);
                s_s = Math.Round(s_s, 2);
                int ba = sh.edit_sharik(" `sood_mah`='" + s_m.ToString() + "',`sood_sal`='" + s_s.ToString() + "'", " WHERE `Name_Family` = '" + a[1].ToString() + "'");
            }
        }


        private int a;
        private int b;
        private void load_sharik()
        {
            sharikDT = sh.read_Sharik(" ");
            a = so.set_sood_mah(50000);
            b = so.set_sood_sal(15000000);
            cal_all_share();
            set_each_share();
            dGVSharik.AutoGenerateColumns = false;
            dGVSharik.DataSource = sh.read_Sharik(" ");
            lbl_sood_mah.Text = Convert.ToString(so.get_sood_mah());
            lbl_sood_sal.Text = Convert.ToString(so.get_sood_sal());
            
            lblKoleSahm.Text = all_share.ToString();
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtShare.ReadOnly = false;
            btnOK.Enabled = true;
            btnDeleteSharik.Enabled = false;
            btnEditData.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(check_Double(txtShare.Text))
            {
                int ba = sh.add_to_Sharik(txtName.Text,Convert.ToDouble(txtShare.Text));
                load_sharik();
                txtName.Text = "";
                txtShare.Text = "";
            }
            else
            {
                MessageBox.Show("مقدار سهم صحیح وارد نشده");
            }
        }

        private string strName;
        private int rowIndex;
        private void dGVSharik_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Enabled = false;
            btnDeleteSharik.Enabled = true;
            btnEditData.Enabled = true;
            btnCancel.Enabled = true;
            txtName.ReadOnly = true;
            txtShare.ReadOnly = true;

             rowIndex = dGVSharik.CurrentCell.RowIndex;

             strName = dGVSharik.Rows[rowIndex].Cells[0].Value.ToString();
            string strShare = dGVSharik.Rows[rowIndex].Cells[1].Value.ToString();

            txtName.Text = strName;
            txtShare.Text = strShare;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            load_sharik();
            txtName.Text = "";
            txtShare.Text = "";
            btnAdd.Enabled = true;
            btnDeleteSharik.Enabled = false;
            btnEditData.Enabled = false;
            btnCancel.Enabled = false;
            txtName.ReadOnly = false;
            txtShare.ReadOnly = false;
            btnOK.Enabled = false;
        }

        private void btnDeleteSharik_Click(object sender, EventArgs e)
        {
            if (GS.dialog.Question("حذف شریک", "آیا از حذف این شریک از لیست اطمینان دارید؟") == DialogResult.OK)
            {
               
                txtName.Text = "";
                txtShare.Text = "";
                btnAdd.Enabled = true;
                btnDeleteSharik.Enabled = false;
                btnEditData.Enabled = false;
                btnCancel.Enabled = false;
                txtName.ReadOnly = false;
                txtShare.ReadOnly = false;
                btnOK.Enabled = false;
               int ba = sh.delet_sharik(strName);
                load_sharik();
            }
            else
            {
                load_sharik();
                txtName.Text = "";
                txtShare.Text = "";
                btnAdd.Enabled = true;
                btnDeleteSharik.Enabled = false;
                btnEditData.Enabled = false;
                btnCancel.Enabled = false;
                txtName.ReadOnly = false;
                txtShare.ReadOnly = false;
                btnOK.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (check_Double(txtShare.Text))
            {
                int ba = sh.edit_sharik(" `Name_Family`='" + txtName.Text + "',`Sahme`='" + Convert.ToDouble(txtShare.Text) + "'", " WHERE `Name_Family` = '" + strName + "'");
                load_sharik();
                txtName.Text = "";
                txtShare.Text = "";
                btnOK.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
            }
            else
            {
                MessageBox.Show("مقدار سهم صحیح وارد نشده");
            }
           
        }
    }
}
