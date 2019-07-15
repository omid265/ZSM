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
using ManoloSellManager.Forms;

namespace ManoloSellManager
{
    public partial class frmStore : Form
    {
        ManoloSellManager.Class.Generals GS = ManoloSellManager.Class.Generals.CreateGenerals();

        DataTable dtStore = new DataTable();
        Products Pmgr = Products.products();
        bool edit = false;
        int newItemCode = 0;
        public frmStore()
        {
            InitializeComponent();
            LoadStore();
        }

        private void ResetForm()
        {
            setProductCode();
            txtPrice.Text = "";
            txtItemName.Text = "";
            cbUnitType.Text = "";
            txtLimit.Text = "";
            chbExist.Checked = false;
            txtCount.Text = "";

            btnNew.Text = "جدید";
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
            btnAddNew.Enabled = false;
            setProductCode();
            edit = false;
        }
        private void setProductCode()
        {
            txtItemCode.Text = Pmgr.GetLastProductCode.ToString();
        }
        private void frmStore_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                decimal a = Convert.ToDecimal(txtPrice.Text);

                if (txtItemCode.Text == "" || txtItemName.Text == "" || txtPrice.Text == "" || cbUnitType.Text == "")
                {
                    MessageBox.Show("لطفا اطلاعات را کامل وارد کنید.");
                    return;
                }


                if (edit)
                {
                    string count = "0";
                    if (chbExist.Checked)
                    {
                        if (!string.IsNullOrEmpty(txtCount.Text))
                            count = txtCount.Text;
                        else
                        {
                            MessageBox.Show("لطفا کنترل موجودی را غیرفعال کنید و یا تعداد موجودی را وارد کنید.");
                            return;
                        }
                    }

                    UpdateItem(txtItemCode.Text, txtItemCode.Text, txtItemName.Text, txtPrice.Text, cbUnitType.Text, txtLimit.Text, count);
                    MessageBox.Show("به روز شد.");
                    ResetForm();
                    LoadStore();
                    return;
                }
                else
                {
                    Products.Product newItem = new Products.Product();
                    newItem.Code = txtItemCode.Text;
                    newItem.Name = txtItemName.Text;
                    newItem.Unit = cbUnitType.Text;
                    newItem.Price = txtPrice.Text;
                    newItem.Limiter = txtLimit.Text;
                    if (chbExist.Checked == true)
                    {
                        newItem.StoreControl = txtCount.Text;
                    }
                    else
                    {
                        newItem.StoreControl = "0";
                    }
                    newItem.Status = "";
                    int addNewResutl = Products.Items.Add(newItem);
                    if (addNewResutl == 0)
                    {
                        LoadStore();
                    }
                    else if (addNewResutl == -1)
                    {
                        MessageBox.Show("ثبت کالای جدید بامشکل مواجه شده است.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (addNewResutl == 2)
                    {
                        MessageBox.Show("نام یا کد کالا تکراری است.");
                    }

                    //GS.db.Query("SELECT * FROM `store` WHERE `itemName`='" + txtItemName.Text + "' OR `itemCode`='" + txtItemCode.Text + "'");
                }

                //try
                //{

                //    if (GS.db.ResultCount == 0)
                //    {
                //        //string CommandText = "INSERT INTO `store` (`itemName`,`itemUnit`,`itemPrice`,`itemLimiter`,`itemStoreControler`,`itemCode`,`itemStatus`) " +
                //        //"VALUES ('" + txtItemName.Text + "','" + cbUnitType.Text + "','" + txtPrice.Text + "','" + txtLimit.Text + "','" + txtCount.Text + "','" + txtItemCode.Text + "','')";
                //        //GS.db.Query(CommandText);
                //        //LoadStore();
                //    }
                //    else
                //    {
                //        //MessageBox.Show("این کالا قبلا در بانک اطلاعاتی به ثبت رسیده است.");
                //    }
                //}
                //catch (Exception er)
                //{
                //    MessageBox.Show("مشکلی به وجود آمده است" + " : " + er.Message);
                //    //msc.Close();
                //}
                //finally
                //{
                //    //MessageBox.Show("Finally");
                //    //msc.Close();
                //}

            }
            catch
            {
                MessageBox.Show("لطفا جهت قیمت گذاری کالا فقط از اعداد استفاده کنید.");
                txtPrice.Text = "";
                txtPrice.Focus();
            }



        }

        private void chbExist_CheckedChanged(object sender, EventArgs e)
        {

            txtCount.Enabled = chbExist.Checked;
            txtCount.Focus();
        }
        private void LoadStore()
        {
            dtStore = GS.db.Query("SELECT `itemCode`,`itemName`,`itemPrice`,`itemUnit`,`itemLimiter` FROM `store` ORDER by id DESC");
            dgvStoreList.DataSource = dtStore;
            dgvStoreList.Refresh();
            ResetForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowindex = dgvStoreList.CurrentCell.RowIndex;
            int columnindex = dgvStoreList.CurrentCell.ColumnIndex;

            string si = dgvStoreList.Rows[rowindex].Cells[0].Value.ToString();
            // MessageBox.Show(si);
            if (Question("", "آیا مایل به حذف این مورد می باشید؟") == DialogResult.OK)
            {
                dtStore = GS.db.Query("DELETE FROM `store` WHERE `itemCode`='" + si + "' LIMIT 1");
                LoadStore();

            }

        }
        public static DialogResult Question(string title, string QuestionText)
        {
            Form form = new Form();
            Label label = new Label();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            form.RightToLeft = RightToLeft.Yes;
            label.Text = QuestionText;

            buttonOk.Text = "تائید";
            buttonCancel.Text = "انصراف";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);

            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;

            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

        public void UpdateItem(string code, string NewItemCode, string Title, string price, string unit, string limiter, string countControl)
        {
            ///UPDATE `store` SET `itemName` = 'سقف کاذب آلمينيومی', `itemUnit` = '1', `itemPrice` = '1000' WHERE `store`.`id` = 1;
            GS.db.Query(string.Format(@"UPDATE `store` SET 
                                        `itemName` = '{0}'
                                        , `itemUnit` = '{1}'
                                        , `itemPrice` = '{2}' 
                                        , `itemLimiter` = '{3}' 
                                        , `itemStoreControler` = '{4}' 
                                        , `itemCode` = '{5}' 
                                        WHERE `store`.`itemCode` = {6};", Title, unit, price, limiter, countControl, NewItemCode, code));
        }
        public void LoadItemToForm(string Code)
        {
            GS.db.Query("SELECT * FROM `store` WHERE `itemCode`='" + Code + "'");
            if (GS.db.Result.Rows.Count >= 1)
            {
                txtItemCode.Text = GS.db.Result.Rows[0]["itemCode"].ToString();
                txtItemName.Text = GS.db.Result.Rows[0]["itemName"].ToString();
                txtLimit.Text = GS.db.Result.Rows[0]["itemLimiter"].ToString();
                txtPrice.Text = GS.db.Result.Rows[0]["itemPrice"].ToString();
                cbUnitType.Text = GS.db.Result.Rows[0]["itemUnit"].ToString();
                txtCount.Text= GS.db.Result.Rows[0]["itemStoreControler"].ToString();
                txtCount.Enabled = true;
                chbExist.Checked = true;
                edit = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                txtItemCode.Enabled = true;
                btnAddNew.Enabled = true;
                btnNew.Text = "لغو";

            }
        }
        private void dgvStoreList_DoubleClick(object sender, EventArgs e)
        {
            int rowindex = dgvStoreList.CurrentCell.RowIndex;
            int columnindex = dgvStoreList.CurrentCell.ColumnIndex;

            string si = dgvStoreList.Rows[rowindex].Cells[0].Value.ToString();
            LoadItemToForm(si);

        }


        private void cbUnitType_KeyUp(object sender, KeyEventArgs e)
        {
            cbUnitType.Text = "";
            MessageBox.Show("لطفا واحد مورد نظر را از لیست موجود انتخاب کنید");
        }



        private void txtLimit_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Int64 a = Convert.ToInt64(txtLimit.Text);
            }
            catch
            {
                MessageBox.Show("لطفا عدد وارد کنید");
                txtLimit.Text = "";
            }
        }

        private void txtCount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Int64 a = Convert.ToInt64(txtCount.Text);
            }
            catch
            {
                MessageBox.Show("لطفا عدد وارد کنید");
                txtCount.Text = "";
            }
        }

        private void btnNextFocus_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{TAB}");
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            txtItemName.Focus();
            if (txtItemCode.Enabled)
            {
                newItemCode = Convert.ToInt16(txtItemCode.Text);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dgvStoreList_DoubleClick(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "جدید")
            {
                ResetForm();
                btnNew.Text = "لغو";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnAddNew.Enabled = true;
                txtItemName.Focus();
            }
            else
            {
                ResetForm();
            }

        }
    }
}
