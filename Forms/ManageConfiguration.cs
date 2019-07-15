using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Generals;
using System.IO;

namespace ManoloSellManager.Forms
{
    public partial class frmManageConfiguration : Form
    {
        dynamic conf = ConfigFile.GetConfig();
        public frmManageConfiguration()
        {
            InitializeComponent();
        }

        private void ManageConfiguration_Load(object sender, EventArgs e)
        {
            txtConfiguration.Text= File.ReadAllText(AppPath.ConfigFile());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(AppPath.ConfigFile(), txtConfiguration.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
