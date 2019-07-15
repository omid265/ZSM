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
using System.IO;

namespace ManoloSellManager.Forms
{
    public partial class frmLogin : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPassword.Text=="")
            {
                txtPassword.Focus();

            }
            else if (txtPassword.Text != "" && txtUserName.Text != "")
            {
                string UserPass = txtPassword.Text;
                UserPass = UserPass.GetHashCode().ToString();
                string UserName = txtUserName.Text.ToLower();

                if (btnLogin.Text == "ورود")
                {


                    string LoginQuery = "SELECT * FROM `setting` WHERE `SettingName` like 'users%' AND `SettingValue`='" + UserName + ":" + UserPass + "'";
                    if (GS.db.Query(LoginQuery).Rows.Count != 0)
                    {
                        this.Hide();
                        new frmMain2().Show();
                        //MessageBox.Show("Login");
                    }
                    else
                    {
                        MessageBox.Show("نام کاربری یا کلمه عبور اشتباه است.");
                    }
                }
                else
                {
                    string makeAdminQuery = "INSERT INTO  `setting` (`id` ,`SettingName` ,`SettingValue`)";
                    makeAdminQuery += "VALUES (NULL ,  'users',  '" + UserName + ":" + UserPass + "');";

                    GS.db.Query(makeAdminQuery);
                    //Application.Run(new frmMain());
                    this.Hide();
                    new frmMain2().Show();
                }
            }
            else///// End Control User Entry
                MessageBox.Show("لطفا مشخصات کاربری خود را وارد کنید.");

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //string validatePath = @"C:\Windows\System32\ZSM.zsm";
            //MessageBox.Show(File.Exists(validatePath).ToString());

            string LoginQuery = "SELECT * FROM `setting` WHERE `SettingName` LIKE 'users%'";
            if (GS.db.Query(LoginQuery).Rows.Count == 0)
            {
                string UserPass = "1020";
                UserPass = UserPass.GetHashCode().ToString();
                string makeAdminQuery = "INSERT INTO  `setting` (`id` ,`SettingName` ,`SettingValue`)";
                makeAdminQuery += "VALUES (NULL ,  'users',  'admin:" + UserPass + "');";

                GS.db.Query(makeAdminQuery);
                //btnLogin.Text = "معرفی مدیر";

            }
        }
    }
}
