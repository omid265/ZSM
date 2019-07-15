using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ManoloSellManager.Class;
using Microsoft.Reporting.WinForms;
using System.IO;
using Generals;
using Newtonsoft;
using Newtonsoft.Json;

namespace ManoloSellManager.Forms
{

    public partial class frmOrders : Form
    {
        Class.Generals GS = Class.Generals.CreateGenerals();
        //Dialog dialog = Dialog.CreateDialog();
        //DateManager dateManager = DateManager.GetDate();
        Invoice cInvoice = Invoice.invoice();

        //InvoiceMGR InvoiceM = new InvoiceMGR();
        Clients c = new Clients();/////// c= Client
        Clients.Client cSC = new Clients.Client();// cSC= Selected Client

        static string DBName = "`" + ConfigFile.GetConfig().DatabaseConfig().DatabaseName + "`.";

        string sqlQuery = string.Format("SELECT `id`,`name`,`phone` FROM {0}`personals` ORDER BY `name`", DBName)
            , sqlQueryStore = string.Format("SELECT * FROM {0}`store` ORDER BY `itemName`", DBName)
            , unitName = ""
            , ItemUnit
            , json = ""
            , SelectQUERY = string.Format("SELECT* FROM {0}`store` WHERE ", DBName);

        Boolean InEdit = false,
        invoiceIsSaved = false;
        /// <summary>
        /// All property in this form declare in here
        /// this property use for more Operation of Order
        /// </summary>
        public decimal MainPersonalID { get; set; }

        public Int16 InvoiceNo { set; get; }
        //public Boolean EditMode { set; get; }
        public enum ModeList
        {
            JustEdit = 1
            , Transfer = 2
            , New = 3
        }
        public ModeList OrderMode { set; get; }

        private string zsmInvoiceDetailsProperties { set; get; }
        private Int32 InvoiceDetailsSelected { set; get; }


        /// <summary>
        /// Set invoice type for control action on invoice
        /// </summary>
        public Invoice.InvoiceType InvoiceType { set; get; }
        ///////////////////////// End Property
        //#########################################################


        /// <summary>
        /// Set All Label Text And Element Position
        /// </summary>
        private void SetUILables()
        {
            switch (InvoiceType)
            {
                case Invoice.InvoiceType.buy:
                    this.Text = "ثبت فاکتور خرید";
                    break;
                case Invoice.InvoiceType.sell:
                    this.Text = "ثبت فاکتور فروش";
                    cbProforma.Checked = false;
                    break;
                case Invoice.InvoiceType.proforma:
                    this.Text = "ثبت پیش فاکتور";
                    cbProforma.Checked = true;
                    break;
            }/// End switch
        }

        public frmOrders()
        {
            InitializeComponent();
            dgvSellerList.AutoGenerateColumns = false;
            dgvStoreList.AutoGenerateColumns = false;
            dgvOrderList.AutoGenerateColumns = false;

            LoadSeller("");
            LoadStore();
        }

        private void txtSellerCode_TextChanged(object sender, EventArgs e)
        {
            string sQ = "WHERE `id` like '" + txtSellerCode.Text + "%'";
            LoadSeller(sQ);

        }
        private void LoadSeller(string Condition)
        {
            dgvSellerList.DataSource = c.getClientsList(Condition);
        }
        private void LoadStore()
        {
            dgvStoreList.DataSource = GS.db.Query(sqlQueryStore);
        }
        private void txtSellerName_TextChanged(object sender, EventArgs e)
        {
            string sQ = "WHERE `name` like N'%#%' OR  `nickName` like N'%#%' OR `CompanyName` like N'%#%'  OR `mobile` like '%#%' OR `phone` like '%#%' ".Replace("#", GS.SafeFarsiStr(txtSellerName.Text));
            LoadSeller(sQ);
        }

        private void txtSellerCodeMain_TextChanged(object sender, EventArgs e)
        {
            string sQ = "WHERE `id` like '" + txtSellerCodeMain.Text + "%'";
            LoadSeller(sQ);
        }

        private void txtSellerCodeMain_Enter(object sender, EventArgs e)
        {
            gbSeller.Visible = true;
            gbStore.Visible = false;
            txtSellerName.Focus();
        }

        private void btnSetSeller_Click(object sender, EventArgs e)
        {
            SelectSeller();
        }
        private void SelectSeller()
        {
            try
            {
                int rowIndex = dgvSellerList.CurrentCell.RowIndex;
                //int cellIndex = dgvSeller.CurrentCell.ColumnIndex;
                int cellIndex = 0;

                string sellerCode = dgvSellerList.Rows[rowIndex].Cells[cellIndex].Value.ToString();
                string sellerName = dgvSellerList.Rows[rowIndex].Cells[1].Value.ToString();

                txtSellerCodeMain.Text = sellerCode;
                txtSellerNameMain.Text = sellerName;

                gbSeller.Visible = false;
                txtStoreItemCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("شخص موردنظر شما تعریف و ثبت نشده است.");
                txtSellerCode.Focus();
            }
        }

        private void dgvSeller_DoubleClick(object sender, EventArgs e)
        {
            SelectSeller();
        }

        private void btnSelectStore_Click(object sender, EventArgs e)
        {
            SelectStore();
            txtWidth.Focus();
            //SendKeys.Send("{TAB}");
        }
        private void SelectStore()
        {
            try
            {
                int rowIndex = dgvStoreList.CurrentCell.RowIndex;
                //int cellIndex = dgvSeller.CurrentCell.ColumnIndex;
                int cellIndex = 0;

                string storeCode = dgvStoreList.Rows[rowIndex].Cells[cellIndex].Value.ToString();
                string storeName = dgvStoreList.Rows[rowIndex].Cells[1].Value.ToString();
                DataTable dtStore = new DataTable();
                dtStore = GS.db.Query("SELECT * FROM `store` WHERE `itemCode`='" + storeCode + "'");
                if (dtStore != null)
                {
                    unitName = dtStore.Rows[0]["itemUnit"].ToString();

                    //unitName
                    txtStoreItemCode.Text = storeCode;
                    txtStoreItemName.Text = storeName;

                    gbStore.Visible = false;

                    if (dtStore.Rows.Count > 0)
                    {

                        ItemUnit = dtStore.Rows[0]["itemUnit"].ToString();
                        string itemLimiter = dtStore.Rows[0]["itemLimiter"].ToString();
                        string itemStoreControler = dtStore.Rows[0]["itemStoreControler"].ToString();
                        string itemStorePrice = dtStore.Rows[0]["itemPrice"].ToString();

                        txtLimiter.Text = itemLimiter;
                        txtPrice.Text = itemStorePrice;

                        Boolean status = false;
                        Boolean status2 = true;

                        switch (unitName)
                        {
                            case "کیلوگرم":
                                lblWeightUnit.Visible = status2;

                                txtCount.Enabled = status2;
                                lblCount.Text = "وزن";
                                lblWeightUnit.Text = unitName;
                                lblCount.Enabled = status2;

                                txtHeight.Enabled = status;
                                lblheight.Enabled = status;

                                txtWidth.Enabled = status;
                                lblWidth.Enabled = status;
                                txtCount.Focus();
                                break;
                            case "گرم":
                                lblWeightUnit.Visible = status2;

                                txtCount.Enabled = status2;
                                lblCount.Text = "وزن";
                                lblWeightUnit.Text = unitName;
                                lblCount.Enabled = status2;

                                txtHeight.Enabled = status;
                                lblheight.Enabled = status;

                                txtWidth.Enabled = status;
                                lblWidth.Enabled = status;
                                txtCount.Focus();
                                break;
                            case "اینچ":


                                json = @"{'units': [
                                    {
                                      'unit':'طول',
                                      'value': '*'
                                    },
                                    {
                                      'unit':'عرض',
                                      'value': '/'
                                    },
                                    {
                                        'unit':'static',
                                        'value':'6.25'
                                    }

                                  ]
                                }";



                                lblWeightUnit.Visible = status;

                                txtCount.Enabled = status2;
                                lblCount.Enabled = status2;
                                lblCount.Text = "تعداد";

                                txtHeight.Enabled = status2;
                                lblheight.Enabled = status2;

                                txtWidth.Enabled = status2;
                                lblWidth.Enabled = status2;
                                txtWidth.Focus();
                                break;
                            case "متر مربع":
                                #region Make Input with Type from Json
                                json = @"{'units': [
                                {
                                  'unit':'طول',
                                  'value': '+'
                                },
                                {
                                  'unit':'عرض',
                                  'value': '*'
                                },
                                {
                                    'unit':'static',
                                    'value':'2'
                                },
                                {
                                    'unit':'static',
                                    'value':'/100'
                                }

                              ]
                            }";
                                #endregion

                                lblWeightUnit.Visible = status;

                                txtCount.Enabled = status2;
                                lblCount.Enabled = status2;
                                lblCount.Text = "تعداد";

                                txtHeight.Enabled = status2;
                                lblheight.Enabled = status2;

                                txtWidth.Enabled = status2;
                                lblWidth.Enabled = status2;
                                txtWidth.Focus();
                                break;
                            case "عدد":
                                txtWidth.Enabled = status;
                                lblheight.Enabled = status;

                                lblCount.Text = "تعداد";
                                lblWeightUnit.Visible = status;

                                txtHeight.Enabled = status;
                                lblheight.Enabled = status;
                                txtCount.Focus();
                                break;
                            case "متر":
                                txtWidth.Enabled = status;
                                lblheight.Enabled = status;

                                lblCount.Text = "متراژ";
                                lblWeightUnit.Text = "متر";

                                txtHeight.Enabled = status;
                                lblheight.Enabled = status;
                                txtCount.Focus();
                                break;

                            default:

                                lblWeightUnit.Visible = status2;

                                txtCount.Enabled = status2;
                                lblCount.Enabled = status2;

                                txtHeight.Enabled = status2;
                                lblheight.Enabled = status2;

                                txtWidth.Enabled = status2;
                                lblWidth.Enabled = status2;
                                txtWidth.Focus();
                                break;
                        }/////// End Switch
                    }///////// End Control dt contex

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("کالای موردنظر شما ثبت نشده است.");
                txtSIC.Focus();
            }





        }

        private void txtStoreItemCode_Enter(object sender, EventArgs e)
        {
            gbStore.Visible = true;
            gbSeller.Visible = false;
            txtSIC.Focus();
        }

        private void dgvSellerList_DoubleClick(object sender, EventArgs e)
        {
            SelectSeller();
        }

        private void dgvStoreList_DoubleClick(object sender, EventArgs e)
        {
            //SelectStore();
            btnSelectStore_Click(sender, e);

        }

        private void txtSIC_TextChanged(object sender, EventArgs e)
        {
            sqlQueryStore = SelectQUERY + "`itemCode` LIKE '" + txtSIC.Text + "%'";
            LoadStore();
        }

        private void txtSIN_TextChanged(object sender, EventArgs e)
        {
            sqlQueryStore = string.Format("SELECT * FROM {0}`store` WHERE `itemName` LIKE '%{1}%'", DBName, GS.SafeFarsiStr(txtSIN.Text));
            LoadStore();
        }



        private void txtSellerCodeMain_Enter_1(object sender, EventArgs e)
        {
            gbStore.Visible = false;
            gbSeller.Visible = true;
            txtSellerName.Focus();
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            CalcProp();
            decimal dUnitAmount;
            string ItemSize;

            if (txtCount.Text == "0" || txtCount.Text == "")
            {
                MessageBox.Show("لطفا مقدار/تعداد را وارد کنید.");
                txtCount.Focus();
            }
            else
            {
                #region Calc Item
                decimal fn;
                decimal Width;
                decimal Height;

                switch (unitName)
                {
                    case "کیلوگرم":
                        dUnitAmount = 0;
                        ItemSize = dUnitAmount.ToString();

                        break;
                    case "گرم":
                        dUnitAmount = 0;
                        ItemSize = dUnitAmount.ToString();

                        break;
                    case "اینچ":
                        if (cbLabBeLab.Checked == true)
                        {
                            Width = ConvertAndValidateDecimal(txtWidth.Text) - 4;
                            Height = ConvertAndValidateDecimal(txtHeight.Text) - 4;
                        }
                        else
                        {
                            Width = ConvertAndValidateDecimal(txtWidth.Text);
                            Height = ConvertAndValidateDecimal(txtHeight.Text);
                        }
                        if (cbInch.Checked == false)
                        {
                            if (Width < 15) { Width = 15; }
                            if (Height < 15) { Height = 15; }
                        }
                        dUnitAmount = Width * Height;
                        ItemSize = ConvertAndValidateDecimal(txtHeight.Text).ToString() + "*" + ConvertAndValidateDecimal(txtWidth.Text).ToString();

                        if (cbInch.Checked == false)
                        {
                            fn = Convert.ToDecimal(txtInchCalc.Text);
                            dUnitAmount = (Decimal)dUnitAmount / (Decimal)fn;
                        }

                        break;
                    case "اینچ مربع":
                        if (cbLabBeLab.Checked == true)
                        {
                            Width = ConvertAndValidateDecimal(txtWidth.Text) - 4;
                            Height = ConvertAndValidateDecimal(txtHeight.Text) - 4;
                        }
                        else
                        {
                            Width = ConvertAndValidateDecimal(txtWidth.Text);
                            Height = ConvertAndValidateDecimal(txtHeight.Text);
                        }

                        if (cbInch.Checked == false)
                        {
                            if (Width < 15) { Width = 15; }
                            if (Height < 15) { Height = 15; }
                        }
                        dUnitAmount = Width * Height;
                        ItemSize = ConvertAndValidateDecimal(txtHeight.Text).ToString() + "*" + ConvertAndValidateDecimal(txtWidth.Text).ToString();
                        if (cbInch.Checked == false)
                        {
                            fn = ConvertAndValidateDecimal(txtInchCalc.Text);
                            dUnitAmount = (Decimal)dUnitAmount / (Decimal)fn;
                        }

                        break;
                    case "متر مربع":
                        if (cbLabBeLab.Checked == true)
                        {
                            Width = ConvertAndValidateDecimal(txtWidth.Text) - 4;
                            Height = ConvertAndValidateDecimal(txtHeight.Text) - 4;
                        }
                        else
                        {
                            Width = ConvertAndValidateDecimal(txtWidth.Text);
                            Height = ConvertAndValidateDecimal(txtHeight.Text);
                        }
                        if (cbInch.Checked == false)
                        {
                            if (Width < 15) { Width = 15; }
                            if (Height < 15) { Height = 15; }
                        }
                        dUnitAmount = (Width / 100) + (Height / 100);

                        ItemSize = ConvertAndValidateDecimal(txtHeight.Text).ToString() + "*" + ConvertAndValidateDecimal(txtWidth.Text).ToString();
                        dUnitAmount *= 2;
                        //ItemUnitfi /= 100;

                        break;
                    case "عدد":
                        ItemSize = "0";
                        dUnitAmount = 0;//Convert.ToDecimal(txtPrice.Text);//*Convert.ToDecimal(txtCount.Text);
                        break;
                    case "متر":
                        ItemSize = "0";
                        dUnitAmount = 0;//Convert.ToDecimal(txtPrice.Text);//*Convert.ToDecimal(txtCount.Text);
                        break;
                    case "متر و ابعاد بدون تاثیر ابعاد":
                        Width = ConvertAndValidateDecimal(txtWidth.Text);
                        Height = ConvertAndValidateDecimal(txtHeight.Text);
                        //ItemUnitfi = (Width / 100) + (Height / 100);

                        ItemSize = txtHeight.Text + "*" + txtWidth.Text;
                        dUnitAmount = 0;
                        //ItemUnitfi /= 100;
                        break;
                    default:
                        if (cbLabBeLab.Checked == true)
                        {
                            Width = ConvertAndValidateDecimal(txtWidth.Text) - 4;
                            Height = ConvertAndValidateDecimal(txtHeight.Text) - 4;
                        }
                        else
                        {
                            Width = ConvertAndValidateDecimal(txtWidth.Text);
                            Height = ConvertAndValidateDecimal(txtHeight.Text);
                        }

                        if (cbInch.Checked == false)
                        {
                            if (Width < 15) { Width = 15; }
                            if (Height < 15) { Height = 15; }
                        }

                        dUnitAmount = Width * Height;
                        ItemSize = ConvertAndValidateDecimal(txtHeight.Text).ToString() + "*" + ConvertAndValidateDecimal(txtWidth.Text).ToString();
                        if (cbInch.Checked == false)
                        {
                            fn = ConvertAndValidateDecimal(txtInchCalc.Text);
                            dUnitAmount = (Decimal)dUnitAmount / (Decimal)fn;
                        }
                        break;
                }/// End switch unit name
                #endregion


                //MessageBox.Show(dtCU.Compute(gf, null).ToString());
                //ItemUnitfi = dtCU.Compute(gf, null).ToString();

                #region Calc Limit Controller
                decimal Limiter;

                if (txtLimiter.Text != "")
                    Limiter = Convert.ToDecimal(txtLimiter.Text);
                else
                    Limiter = 0;

                if (dUnitAmount == 0)
                {
                    if (Convert.ToDecimal(txtCount.Text) < Limiter)
                    {
                        txtCount.Text = txtLimiter.Text;
                    }
                }
                else
                {
                    if (dUnitAmount < Limiter)
                    {
                        dUnitAmount = Convert.ToDecimal(txtLimiter.Text);
                    }
                }
                #endregion

                decimal PricePerItem = 0;
                if (dUnitAmount == 0)
                    PricePerItem = Convert.ToDecimal(txtPrice.Text);
                else
                    PricePerItem = Convert.ToDecimal(txtPrice.Text) * Convert.ToDecimal(dUnitAmount);

                //ItemUnitfi = string.Format("{0:0.##}", ItemUnitfi); ;

                //}

                try
                {
                    if (cbLabBeLab.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(txtDescription.Text))
                        {
                            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
                            {
                                txtDescription.Text += " | ";
                            }
                        }
                        txtDescription.Text += "ابعاد لب به لب وارد شده است.";
                    }
                    if (cbInch.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(txtDescription.Text))
                        {
                            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
                            {
                                txtDescription.Text += " | ";
                            }
                        }
                        txtDescription.Text += "ابعاد به اینچ وارد شده است.";
                    }

                    Invoice.DetailItem item = new Invoice.DetailItem();
                    item.Code = txtStoreItemCode.Text;
                    item.Name = txtStoreItemName.Text;
                    item.Price = PricePerItem;
                    item.Unit = ItemUnit;
                    item.UnitAmount = dUnitAmount;
                    item.Size = ItemSize.ToString();
                    item.QTY = txtCount.Text;
                    item.Limiter = txtLimiter.Text;
                    item.Description = txtDescription.Text;
                    item.UnitPrice = txtPrice.Text;
                    item.Props = zsmInvoiceDetailsProperties;

                    //msc.Open();
                    if (InvoiceDetailsSelected > 0)
                    {
                        if (cInvoice.UpdateItem(InvoiceDetailsSelected, item) == -1)
                        {
                            MessageBox.Show("بروز رسانی کالای موردنظر با مشکل مواجه شده است.");
                        }
                    }
                    else
                    {
                        if (cInvoice.AddItem(item) == -1)
                        {
                            MessageBox.Show("ثبت کالای جدید با مشکل مواجه شده است.");
                        }
                    }

                    LoadOrderDetail();
                    EmptyItemDetails();
                    txtOrderPrice.Text = GS.nf(OrderPrice().ToString());
                    double PayPrice = 0;
                    PayPrice = OrderPrice();
                    btnWorkShopPrinting.Enabled = true;

                    if (txtDiscount.Text != "")
                        PayPrice -= Convert.ToDouble(txtDiscount.Text);


                    txtPayPrice.Text = GS.nf(PayPrice.ToString());

                    InvoiceDetailsSelected = 0;
                    zsmInvoiceDetailsProperties = "";
                }
                catch (Exception er)
                {
                    MessageBox.Show("مشکلی به وجود آمده است" + " : " + er.Message, "کد 1");
                }
                finally
                {
                    //MessageBox.Show("Finally");
                }
            }/////// End control count value


        }
        private decimal ConvertAndValidateDecimal(string size)
        {
            try
            {
                if (string.IsNullOrEmpty(size))
                {
                    return 0;
                }
                size = size.Replace('/', '.');
                size = size.Replace('\\', '.');
                return Convert.ToDecimal(size);
            }
            catch
            {
                return 0;
            }
        }
        private void LoadOrderDetail()
        {
            dgvOrderList.DataSource = cInvoice.Load_Details(Invoice.Current.Number, InvoiceType);
            dgvOrderList.Refresh();
        }
        private int LoadOrder(int OrderNo)
        {
            if (OrderNo > 0)
            {
                DataTable dtOrderList, dtOrderContentList = new DataTable();

                dtOrderList = cInvoice.Load(InvoiceType);

                dtOrderContentList = cInvoice.Load_Details(InvoiceType);

                if (dtOrderList.Rows.Count == 0)
                {
                    MessageBox.Show("صورت حسابی با این شماره ثبت نشده است.");
                    return 7;/// this invoice number is not exist
                }

                if (dtOrderList.Rows.Count > 0 || dtOrderContentList.Rows.Count > 0)
                {
                    Fixed(true);
                    txtSellerCodeMain.Text = dtOrderList.Rows[0]["InvoiceUserId"].ToString();

                    MainPersonalID = Convert.ToDecimal(dtOrderList.Rows[0]["InvoiceUserId"].ToString());


                    //DataTable dtPersonalsDetails = new DataTable();
                    cSC = c.getClientByID(Convert.ToInt16(txtSellerCodeMain.Text));

                    if (cSC == null)
                    {
                        MessageBox.Show("مشتریی با این مشخصات در سیستم وجود ندارد لطفا مجددا مشتری را انتخاب نمایید.");
                        txtSellerCodeMain.Focus();/// set focus to select client
                        //return;
                    }
                    txtSellerNameMain.Text = cSC.name;

                    var drOD = dtOrderList.Rows;// new DataRow();
                    drOD = dtOrderList.Rows;
                    foreach (DataRow dr in dtOrderList.Rows)
                    {
                        txtDiscount.Text = dr["InvoiceDiscount"].ToString();
                        if (dr["type"].ToString() == Invoice.InvoiceType.proforma.ToString())
                        {
                            cbProforma.Enabled = true;
                            cbProforma.Checked = true;
                        }
                        else
                        {
                            cbProforma.Enabled = false;
                            cbProforma.Checked = false;
                        }
                    }

                    dtOrderList = cInvoice.Load_Details(OrderNo, InvoiceType);

                    dgvOrderList.DataSource = dtOrderList;
                    txtOrderPrice.Text = GS.nf(OrderPrice().ToString());

                    CalcPayPrice();
                    return 0;//// the process success
                }
                else
                {
                    ResetForm();
                    return 6;//// this invoice number dont have any items
                    //MessageBox.Show("شماره فاکتوری مورد نظر ثبت نشده است.", "بارگذاری فاکتور");
                }
                //return 1;
            }
            else
            {
                MessageBox.Show("لطفا شماره فاکتور را وارد کنید.", "بارگذاری فاکتور");
                return 2;
            }
        }

        private void btnOrderNew_Click(object sender, EventArgs e)
        {
            InEdit = false;
            btnShowInvoice.Enabled = false;
            txtOrderNo.ReadOnly = true;

            OrderMode = ModeList.New;

            if (InvoiceType == Invoice.InvoiceType.proforma)
                cbProforma.Enabled = true;
            else
                cbProforma.Enabled = false;

            DataTable dt = new DataTable();
            int NewInvoiceNo = 0;



            NewInvoiceNo = cInvoice.Create(InvoiceType);

            try
            {
                //if (dt.Rows.Count>0)
                //{
                string OrderNo = NewInvoiceNo.ToString();//dt.Rows[0]["InvoiceId"].ToString();
                txtOrderNo.Text = Invoice.Current.Number.ToString();
                //}
                //else
                //{
                //txtOrderNo.Text = "1";
                //}

                gbOrderDetails.Enabled = true;
                gbOrderList.Enabled = true;
                gbPricing.Enabled = true;
                gbSellerDetails.Enabled = true;
                gbStoreDetails.Enabled = true;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnOrderNew.Enabled = false;
                dgvOrderList.Enabled = true;

                txtSellerCodeMain.Focus();
                LoadOrderDetail();
                txtSellerName.Text = string.Empty;
                txtStoreItemName.Text = string.Empty;

            }
            catch (Exception er)
            {
                MessageBox.Show("مشکلی به وجود آمده است" + " : " + er.Message, "کد2");
                //msc.Close();
            }
            finally
            {
                //MessageBox.Show("Finally");
                //msc.Close();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSellerCodeMain.Text != "" && txtSellerNameMain.Text != "")
            {
                try
                {
                    /// Control this Event for new invoice or edit invoice.
                    if (OrderMode == ModeList.New)
                    {
                        #region Create Query for Update Invoice details and run it
                        /// fill invoice details in Invoice Table
                        string q = string.Format(@"UPDATE  `invoice` SET `InvoiceDate`='{1}',`InvoiceUserId`='{2}',`InvoicePrice`='{3}',`InvoiceDiscount`='{4}',`InvoiceDescription`='{5}',`type`='{6}' WHERE  `InvoiceId`='{0}' AND `type`='{6}'"
                                                  , Invoice.Current.Number
                                                  , GS.dateManager.GetCurrentPersianDate("-")
                                                  , txtSellerCodeMain.Text
                                                  , OrderPrice()
                                                  , txtDiscount.Text
                                                  , txtDescription.Text
                                                  , InvoiceType);
                        if (GS.db.Query(q) == null)
                        {
                            /// if this has error show message
                            MessageBox.Show(GS.db.QueryMessage);
                            return;
                        }
                        #endregion

                        #region Create Personal Transaction Details for sell invoice
                        if (InvoiceType == Invoice.InvoiceType.sell)
                        {
                            var tl = new TransactionActivity.TransactionLog();

                            //////////// NT= New Transaction
                            TransactionActivity.Transaction NT = new TransactionActivity.Transaction();

                            ////////// TTO= Transaction Type Order
                            TransactionActivity.TransactionType TTO = TransactionActivity.TransactionType.Order;

                            ///////// TMT= Transaction Method Type
                            TransactionActivity.TransactionMethod TMT = TransactionActivity.TransactionMethod.Order;

                            //////// set transaction Price
                            NT.Amount = Convert.ToDecimal(txtPayPrice.Text);
                            /////// personal id for this transaction
                            NT.PersonalID = Convert.ToDecimal(txtSellerCodeMain.Text);

                            NT.Method = TMT;
                            NT.Description = "سفارش فاکتور شماره " + txtOrderNo.Text;
                            NT.Time = DateTime.Now.ToShortTimeString();
                            NT.Date = GS.dateManager.GetCurrentPersianDate();
                            NT.Type = TTO;
                            NT.RemainAccount = tl.RemainAccount(Convert.ToDecimal(txtSellerCodeMain.Text)) + Convert.ToDecimal(txtPayPrice.Text);
                            byte DFF = Convert.ToByte(TransactionActivity.TransactionStatus.Bedehkar);
                            NT.Status = DFF;
                            //tl.NewTransaction(NT);
                            cInvoice.TransferInvoiceToSellType(true);

                            /// Show invoice on Report
                            ShowInvoice(Invoice.Current.Number.ToString());

                            #region Send SMS
                            if (Settings.GetSendSMSRegisterOrder)
                            {
                                Clients.Client currentClient = new Clients.Client();
                                decimal pc = 0;
                                if (MainPersonalID == 0)
                                {
                                    pc = Convert.ToDecimal(txtSellerCodeMain.Text);
                                }
                                else
                                {
                                    pc = MainPersonalID;
                                }

                                currentClient = c.getClientByID(Convert.ToInt32(pc));

                                string smsText = Settings.GetSMSTextRegisterOrder;
                                smsText = smsText.Replace("%ClientName%", currentClient.name);
                                smsText = smsText.Replace("%InvoiceNumber%", Invoice.Current.Number.ToString());
                                smsText = smsText.Replace("%CompanyName%", Settings.GetCompanyName);
                                smsText = smsText.Replace("%InvoicePrice%", GS.nf(cInvoice.InvoicePrice(InvoiceType).ToString()));
                                smsText = smsText.Replace("%CompanyPhone%", Settings.GetCompanyPhone);
                                try
                                {
                                    Generals.SendSMS sms = new Generals.SendSMS();
                                    sms.Send(currentClient.mobile, smsText);
                                }
                                catch { }
                            }
                            #endregion

                        }
                        else if (InvoiceType == Invoice.InvoiceType.buy)
                        {
                            var tl = new TransactionActivity.TransactionLog();

                            //////////// NT= New Transaction
                            TransactionActivity.Transaction NT = new TransactionActivity.Transaction();

                            ////////// TTO= Transaction Type Order
                            TransactionActivity.TransactionType TTO = TransactionActivity.TransactionType.Buy;

                            ///////// TMT= Transaction Method Type
                            TransactionActivity.TransactionMethod TMT = TransactionActivity.TransactionMethod.Order;

                            //////// set transaction Price
                            NT.Amount = Convert.ToDecimal(txtPayPrice.Text);
                            /////// personal id for this transaction
                            NT.PersonalID = Convert.ToDecimal(txtSellerCodeMain.Text);

                            NT.Method = TMT;
                            NT.Description = "ثبت فاکتور خرید شماره " + txtOrderNo.Text;
                            NT.Time = DateTime.Now.ToShortTimeString();
                            NT.Date = GS.dateManager.GetCurrentPersianDate();
                            NT.Type = TTO;
                            NT.RemainAccount = tl.RemainAccount(Convert.ToDecimal(txtSellerCodeMain.Text)) - Convert.ToDecimal(txtPayPrice.Text);
                            byte DFF = Convert.ToByte(TransactionActivity.TransactionStatus.Bestankar);
                            NT.Status = DFF;
                            tl.NewTransaction(NT);
                            //cInvoice.TransferInvoiceToSellType(true);
                            DataTable dtL = GS.db.Query("SELECT * FROM `invoicedetails` WHERE `InvoiceNo`='" + Invoice.Current.Number + "'AND `type`='" + Invoice.Current.Type + "'");
                            foreach (DataRow dr in dtL.Rows)
                            {
                                string itemId = dr["ItemId"].ToString();
                                string itemPrice = dr["ItemPrice"].ToString();
                                string itemCount = dr["ItemCount"].ToString();

                                Products.Product p = new Products.Product();
                                p.Code = (itemId);
                                List<Products.Product> p2 = Products.Items.getItems(p);

                                p2[0].Price = itemPrice;
                                int newCount= Convert.ToInt32(itemCount)+Convert.ToInt32(p2[0].StoreControl);
                                p2[0].StoreControl = newCount.ToString();

                                Products.Items.Update(Convert.ToInt32(p2[0].Code), Convert.ToInt32(p2[0].StoreControl),p2[0].Price);
                                //p2[0].Price

                            }
                            ShowInvoice(Invoice.Current.Number.ToString());

                        }
                        else
                        {
                            ShowInvoice(Invoice.Current.Number.ToString());
                        }
                        #endregion


                        //ShowInvoice(Invoice.Current.Number.ToString());

                        ResetForm();
                        invoiceIsSaved = true;

                    }
                    else if (OrderMode == ModeList.JustEdit)
                    {
                        TransactionActivity.TransactionLog TL = new TransactionActivity.TransactionLog();
                        if (Convert.ToDecimal(txtSellerCodeMain.Text) == MainPersonalID)
                        {

                            #region Create Query for update Invoice buery and price details, and run
                            string Q = "UPDATE  `invoice` SET  "
                                + "`InvoiceUserId` =  '" + txtSellerCodeMain.Text + "'"
                                + ",`InvoicePrice`='" + OrderPrice().ToString() + "'"
                                + ",`InvoiceDiscount` =  '" + txtDiscount.Text + "'"
                            + "WHERE  `InvoiceId` =" + Invoice.Current.Number + " AND `type`='" + InvoiceType + "';";

                            GS.db.Query(Q);
                            #endregion

                            int TI = Convert.ToInt16(cInvoice.GetTransactionID(InvoiceType).ToString());

                            TL.Edit(TI, Convert.ToDecimal(txtSellerCodeMain.Text), (OrderPrice() - Convert.ToDouble(txtDiscount.Text)));

                            //TL.Edit("سفارش فاکتور شماره " + txtOrderNo.Text, Convert.ToDecimal(txtSellerCodeMain.Text), (OrderPrice() - Convert.ToDouble(txtDiscount.Text)));

                        }
                        else
                        {
                            if (GS.dialog.Question("تغییر فاکتور", "نام سفارش دهنده تغییر کرده است! آیا شما تصمیم دارید که این فاکتور را به شخصی دیگر منتقل کنید؟") == DialogResult.OK)
                            {
                                string Q = "UPDATE  `invoice` SET  "
                                + "`InvoiceUserId` =  '" + txtSellerCodeMain.Text + "'"
                                + ",`InvoicePrice`='" + OrderPrice().ToString() + "'"
                                + ",`InvoiceDiscount` =  '" + txtDiscount.Text + "'"
                                + "WHERE  `InvoiceId` =" + Invoice.Current.Number + " AND `type`='" + InvoiceType + "';";

                                GS.db.Query(Q);
                                TL.Edit("سفارش فاکتور شماره " + txtOrderNo.Text, MainPersonalID, Convert.ToDecimal(txtSellerCodeMain.Text), (OrderPrice() - Convert.ToDouble(txtDiscount.Text)));
                            }
                            else
                            {
                                MessageBox.Show("لطفا سفارش دهنده را اصلاح کنید!");
                                txtSellerCodeMain.Focus();
                            }
                        }

                        ShowInvoice(Invoice.Current.Number.ToString());

                        ResetForm();
                        invoiceIsSaved = true;
                    }
                    else if (OrderMode == ModeList.Transfer)
                    {

                    }

                }
                catch (Exception er)
                {
                    MessageBox.Show("مشکلی به وجود آمده است" + " : " + er.Message, "کد 3");
                    //msc.Close();
                }
                finally
                {
                    //MessageBox.Show("Finally");
                    //msc.Close();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک شخص را انتخاب نمایید.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (OrderMode != ModeList.JustEdit)
            {
                if (invoiceIsSaved)
                {
                    ResetForm();
                    return;
                }
                try
                {
                    cInvoice.Delete(InvoiceType);
                    //Invoice.Current.Number = 0;

                }
                catch (Exception er)
                {
                    MessageBox.Show("مشکلی به وجود آمده است" + " : " + er.Message, "کد2");
                }
            }
            else
            {
                InEdit = false;
                Invoice.Current.Number = 0;
            }
            ResetForm();
        }

        private void ResetForm()
        {
            Fixed(false);
            dgvOrderList.DataSource = null;
            //// Empty Object
            txtSellerCodeMain.Text = "";
            txtSellerCode.Text = "";
            txtSellerNameMain.Text = "";
            txtStoreItemCode.Text = "";
            txtStoreItemName.Text = "";

            txtOrderPrice.Text = "";
            txtPrice.Text = "";
            txtLimiter.Text = "";

            txtPayPrice.Text = "0";
            txtDiscount.Text = "0";

            txtOrderNo.Text = "";
            ///////////////////////////////////

            //// Disable Object
            gbSeller.Visible = false;
            gbStore.Visible = false;

            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
            btnPrint.Enabled = false;
            btnShowInvoice.Enabled = false;
            btnWorkShopPrinting.Enabled = false;
            gbOrderList.Enabled = false;
            gbPricing.Enabled = false;
            gbSellerDetails.Enabled = false;
            gbStoreDetails.Enabled = false;
            dgvOrderList.Enabled = false;
            ///////////////////////////////////


            ///// Active Object
            btnOrderNew.Enabled = true;
            btnEdit.Enabled = true;
            gbOrderDetails.Enabled = false;

            ///////////////////////////////////

        }

        private void Fixed(bool Status)
        {
            //DisableAll
            gbOrderDetails.Enabled = Status;
            gbOrderList.Enabled = Status;
            gbPricing.Enabled = Status;
            gbSellerDetails.Enabled = Status;
            gbStoreDetails.Enabled = Status;

            btnCancel.Enabled = Status;
            btnSave.Enabled = Status;
            btnEdit.Enabled = Status ? false : true;
            btnOrderNew.Enabled = Status ? false : true;
            btnDelete.Enabled = Status;
            btnPrint.Enabled = Status;
            btnWorkShopPrinting.Enabled = Status;
            dgvOrderList.Enabled = Status;

        }////////////////// End Fixed Function
        public void CalcProp()
        {
            string j = @"[{";

            j += "calcinch:\"" + cbInch.Checked + "\",";
            j += "calclabbelab:\"" + cbInch.Checked + "\",";
            j += "inchCalc:\"" + txtInchCalc.Text + "\"";

            j += "}]";

            zsmInvoiceDetailsProperties = JsonConvert.DeserializeObject(j).ToString();
        }
        private void EmptyItemDetails()
        {
            txtWidth.Text = "";
            txtHeight.Text = "";
            txtCount.Text = "";
            txtDescription.Text = "";
            txtWidth.Focus();
            //txtLimiter.Text = "";
        }////////////////// End EmptyForm Function
        private double OrderPrice()
        {
            return cInvoice.InvoicePrice(InvoiceType);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnOrderNew.Enabled = false;
            btnCancel.Enabled = true;
            txtOrderNo.ReadOnly = false;
            txtOrderNo.Text = "";
            gbOrderDetails.Enabled = true;
            btnShowInvoice.Enabled = true;
            btnWorkShopPrinting.Enabled = true;
            txtOrderNo.Focus();

            cbProforma.Enabled = false;

            //MessageBox.Show("لطفا شماره فاکتور مورد نظر را وارد نمایید.");

        }


        //ItemUnit = dt.Rows[0]["itemUnit"].ToString();
        private void txtSellerCode_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyValue.ToString());
            //txtSellerCode.Text = e.KeyValue.ToString();
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (dgvSellerList.Rows.Count == 0)
                    {
                        MessageBox.Show("شخص موردنظر ثبت نشده است.");
                    }
                    else
                    {
                        dgvSeller_DoubleClick(dgvSellerList, e);
                    }
                    break;
                    //case Keys.Down:
                    //    GoToNextRow(dgvSellerList, Keys.Down);
                    //    break;
                    //case Keys.Up:
                    //    GoToNextRow(dgvSellerList, Keys.Up);
                    //    break;
                    //dgvStoreList.SelectedRows.
                    //int rowIndex = dgvSellerList.CurrentCell.RowIndex;
                    //dgvSellerList.CurrentRow.
            }
        }

        private void txtSIC_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (dgvStoreList.Rows.Count == 0)
                    {
                        MessageBox.Show("کالای مورد نظر ثبت نشده است.");
                        return;
                    }

                    dgvStoreList_DoubleClick(dgvStoreList, e);
                    txtSIC.Text = "";

                    break;
                    //case Keys.Down:
                    //    GoToNextRow(dgvStoreList, Keys.Down);
                    //break;
                    //case Keys.Up:
                    //    GoToNextRow(dgvStoreList, Keys.Up);
                    //    break;

            }
        }
        private void frmOrders_Load(object sender, EventArgs e)
        {

            txtInchCalc.Text = Settings.GetInchToCentimeter.ToString();

            SetUILables();

            if (OrderMode == ModeList.JustEdit)
            {
                btnEdit_Click(sender, e);
                txtOrderNo.Text = Invoice.Current.Number.ToString();
                txtOrderNo.ReadOnly = true;
                btnShowInvoice_Click(sender, e);
            }



        }

        private void btnNextFocus_Click(object sender, EventArgs e)
        {
            //ReportDocument rd = new ReportDocument();
            //rd.Load(@"F:\Omid\Me Project\Windows\Koleh Lid\New Version\ManoloSellManager\ManoloSellManager\CR1.rpt");
            ////rd.SetDataSource(q);
            //MySqlConnection msc = new MySqlConnection(GS.ConnectionString);
            //MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `invoice`", msc);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            //rd.SetDataSource(ds.Tables[0]);
            //crystalReportViewer2.ReportSource = rd;
            //crystalReportViewer2.RefreshReport();
            //crystalReportViewer2.Refresh();
            //SendKeys.Send("{TAB}");

        }


        private void btnRemoveFromOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int intCurrentRow = dgvOrderList.CurrentCell.RowIndex;
                var rowId = dgvOrderList.Rows[intCurrentRow].Cells[0].Value.ToString();
                dgvOrderList.DataSource = GS.db.Query("DELETE FROM `invoicedetails` WHERE `id`='" + rowId + "'AND `type`='" + InvoiceType + "'");

                //LoadOrder(Convert.ToInt16(txtOrderNo.Text));

                dgvOrderList.DataSource = GS.db.Query("SELECT * FROM `invoicedetails` WHERE `InvoiceNo`='" + Invoice.Current.Number + "'AND `type`='" + Invoice.Current.Type + "'");
                txtOrderPrice.Text = GS.nf(OrderPrice().ToString());
                //txtPayPrice.Text = (OrderPrice()-Convert.ToDouble(txtDiscount.Text)).ToString();

                CalcPayPrice();
            }
            catch
            {

            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
                txtDiscount.Text = "0";
            CalcPayPrice();
        }

        private void CalcPayPrice()
        {
            //txtDiscount.Text = GS.nf(txtDiscount.Text);
            try
            {
                decimal discount, OrderPrice, result;

                if (txtDiscount.Text == "")
                    discount = 0;
                else
                    discount = Convert.ToDecimal(txtDiscount.Text);

                if (txtOrderPrice.Text == "")
                    OrderPrice = 0;
                else
                    OrderPrice = Convert.ToDecimal(txtOrderPrice.Text);

                result = OrderPrice - discount;

                txtPayPrice.Text = GS.nf(result.ToString());
            }
            catch (Exception er)
            {
                if (er.Message == "Input string was not in a correct format.")
                {
                    MessageBox.Show(" لطفا فقط عدد وارد کنید. ", "خطایی رخ داده است.");
                }
                else
                {
                    MessageBox.Show(er.Message, "خطایی رخ داده است.");
                }
            }
        }

        /// <summary>
        /// this functoin open the invoice report print Form
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        private void ShowInvoice(string InvoiceNumber)
        {
            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////
            #region Report Parameters
            List<ReportParameter> rp = new List<ReportParameter>();
            rp.Add(new ReportParameter("rpPayment", txtPayPrice.Text));
            rp.Add(new ReportParameter("rpInvoicePrice", txtOrderPrice.Text));
            #endregion

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            string q = "SELECT * FROM `Invoice` WHERE `invoiceId`='" + Invoice.Current.Number + "' AND `type`='" + InvoiceType + "'";
            rdsList.Add(new ReportDataSource("dsInvoice", GS.db.Query(q)));
            q = "SELECT * FROM `invoicedetails` WHERE `invoiceNo`='" + Invoice.Current.Number + "' AND `type`='" + InvoiceType + "'";
            rdsList.Add(new ReportDataSource("dsInvoiceDetails", GS.db.Query(q)));
            q = string.Format("SELECT * FROM `personals` WHERE `id`='{0}'", cInvoice.GetCustomer(InvoiceType).ToString());
            rdsList.Add(new ReportDataSource("dsPersonals", GS.db.Query(q)));
            #endregion

            #region Set frmReport Properties and show this form
            frmReports frmR = new frmReports();
            frmR.RPList = rp;
            switch (InvoiceType)
            {
                case Invoice.InvoiceType.proforma:
                    frmR.reportType = ReportType.InvoiceProforma;
                    break;
                case Invoice.InvoiceType.sell:
                    frmR.reportType = ReportType.InvoiceSell;
                    break;
                case Invoice.InvoiceType.buy:
                    frmR.reportType = ReportType.InvoiceBuy;
                    break;
                default:
                    MessageBox.Show("نوع فاکتور مضخص نیست.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            frmR.rdsList = rdsList;

            string ReportPath = Path.Combine(Application.StartupPath, @"reports\rptInvoice.rdlc");
            frmR.ReportPath = ReportPath;
            frmR.CurrentPesonalID = txtSellerCodeMain.Text;
            frmR.ShowDialog(this);
            #endregion
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            #endregion

            if (Settings.GetPWSRAPI == true)
            {
                btnWorkShopPrinting_Click(null, null);
            }
            gbOrderDetails.Enabled = true;
            btnBack.Visible = true;

        }

        private void PrintWorkshopPrinting(string InvoiceNumber)
        {
            #region Set Report Needs and show report
            ///////////////////////// Start Set value to Parameter of Report /////////////////////////

            #region Report datasource
            List<ReportDataSource> rdsList = new List<ReportDataSource>();
            string q = "SELECT * FROM `Invoice` WHERE `invoiceId`='" + Invoice.Current.Number + "' AND `type`='" + InvoiceType + "'";
            rdsList.Add(new ReportDataSource("dsInvoice", GS.db.Query(q)));
            q = "SELECT * FROM `invoicedetails` WHERE `invoiceNo`='" + Invoice.Current.Number + "' AND `type`='" + InvoiceType + "'";
            rdsList.Add(new ReportDataSource("dsInvoiceDetails", GS.db.Query(q)));
            q = string.Format("SELECT * FROM `personals` WHERE `id`='{0}'", cInvoice.GetCustomer(InvoiceType).ToString());
            rdsList.Add(new ReportDataSource("dsPersonals", GS.db.Query(q)));
            #endregion

            #region Set frmReport Properties and show this form
            frmReports frmR = new frmReports();
            frmR.reportType = ReportType.WorkshopPrinting;
            frmR.rdsList = rdsList;

            string ReportPath = Path.Combine(Application.StartupPath, @"reports\WorkshopPrinting.rdlc");
            frmR.ReportPath = ReportPath;
            frmR.CurrentPesonalID = txtSellerCodeMain.Text;
            frmR.ShowDialog(this);
            #endregion
            ///////////////////////// End Set value to Parameter of Report /////////////////////////
            #endregion


            gbOrderDetails.Enabled = true;
            btnBack.Visible = true;

        }

        private void btnShowInvoice_Click(object sender, EventArgs e)
        {
            InEdit = true;
            OrderMode = ModeList.JustEdit;

            //MessageBox.Show("جهت ویرایش صورت حساب لطفا از صفحه وضعیت مالی اشخاص اقدام کنید.");
            //return;
            if (txtOrderNo.Text != "")
            {
                if (LoadOrder(Convert.ToInt32(txtOrderNo.Text)) != 6)
                {

                    gbSeller.Visible = false;
                    gbStore.Visible = false;
                    btnPrint.Enabled = true;
                    btnWorkShopPrinting.Enabled = true;
                    btnDelete.Enabled = true;
                    InEdit = true;
                    txtOrderNo.Focus();
                }
                else
                {
                    ResetForm();
                    MessageBox.Show("فاکتوری با این شماره ثبت نشده است.");
                }
            }
            else
                MessageBox.Show("لطفا شماره فاکتور مورد نظر را وارد کنید.");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ShowInvoice(txtOrderNo.Text);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //reportViewer1.Visible = false;
            btnBack.Visible = false;
            gbSeller.Visible = false;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GS.dialog.Question("حذف فاکتور", "میخواهید این فاکتور را حذف کنید؟") == DialogResult.OK)
            {
                //DELETE FROM `invoicedetails` WHERE `invoicedetails`.`id` = 1;
                string Q = "DELETE FROM `invoicedetails` WHERE `invoicedetails`.`InvoiceNo`='" + Invoice.Current.Number + "'AND `type`='" + InvoiceType + "'";

                dgvOrderList.DataSource = GS.db.Query(Q);
                Q = "DELETE FROM `invoice` WHERE `InvoiceId` = '" + Invoice.Current.Number + "'AND `type`='" + InvoiceType + "'";
                dgvOrderList.DataSource = GS.db.Query(Q);

                TransactionActivity.TransactionLog TL = new TransactionActivity.TransactionLog();
                TL.delete("سفارش فاکتور شماره " + txtOrderNo.Text);
                MessageBox.Show("فاکتور با موفقیت حذف شد.");
                ResetForm();
            }////// End Control Question
        }

        private void dgvOrderList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            resetProductDetails();


            InvoiceDetailsSelected = Convert.ToInt32(dgvOrderList.CurrentRow.Cells[0].Value.ToString());
            //string Query = "SELECT * FROM `invoicedetails` WHERE `id`='" + InvoiceDetailsSelected.ToString() + "'";


            //DataTable dtO = GS.db.Query(Query);
            DataTable dtO = cInvoice.GetItem(InvoiceDetailsSelected);
            if (dtO.Rows.Count > 0)
            {
                txtStoreItemCode.Text = dtO.Rows[0]["ItemId"].ToString();
                txtStoreItemName.Text = dtO.Rows[0]["ItemName"].ToString();

                string[] size;

                string Size_ = dtO.Rows[0]["itemSize"].ToString();
                size = Size_.Split('*');

                int Counter = 0;
                foreach (var ssp in size)
                {
                    if (Convert.ToInt64(ssp) != 0)
                    {
                        if (Counter == 0)
                        {
                            txtWidth.Enabled = true;
                            txtWidth.Text = ssp;
                        }
                        else if (Counter == 1)
                        {
                            txtHeight.Enabled = true;
                            txtHeight.Text = ssp;
                        }
                        Counter++;
                    }
                }

                txtCount.Text = dtO.Rows[0]["itemCount"].ToString();
                txtPrice.Text = dtO.Rows[0]["PricePerAny"].ToString();
                txtLimiter.Text = dtO.Rows[0]["limiter"].ToString();


                ////////////////////////////////////////////////////
                /*
                 * Start Invoice Details Properties Prossesing 
                 */
                string Prop = dtO.Rows[0]["prop"].ToString();
                string[] Property = Prop.Split(';');

                foreach (var ssp2 in Property)
                {

                    if (ssp2 != "")
                    {
                        string[] PropSEP;

                        PropSEP = ssp2.Split(':');
                        try
                        {
                            switch (PropSEP[0])
                            {
                                case "calcinch":
                                    cbInch.Checked = Convert.ToBoolean(PropSEP[1]);

                                    break;
                            }
                        }
                        catch { }


                    }
                }

                /*
                 * End Invoice Details Properties Prossesing 
                 */
                ////////////////////////////////////////////////////


                btnEditInvoiceDetails.Visible = true;
            }

        }

        private void cbInch_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnEditInvoiceDetails_Click(object sender, EventArgs e)
        {
            resetProductDetails();
        }

        private void btnWorkShopPrinting_Click(object sender, EventArgs e)
        {
            PrintWorkshopPrinting(txtOrderNo.Text);
        }

        private void txtSIC_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    GS.GoToNextRow(dgvStoreList, Keys.Down);
                    break;
                case Keys.Up:
                    GS.GoToNextRow(dgvStoreList, Keys.Up);
                    break;
            }
        }

        private void txtSellerCode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    GS.GoToNextRow(dgvSellerList, Keys.Down);
                    break;
                case Keys.Up:
                    GS.GoToNextRow(dgvSellerList, Keys.Up);
                    break;
            }
        }

        private void frmOrders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnCancel.Enabled)
            {
                e.Cancel = true;
                MessageBox.Show("لطفا وضعیت صورتحساب جاری را مشخص کنید سپس برای خروج مجددا اقدام کنید.\n"+"آن را ثبت کنید و یا انصراف دهید.", "", MessageBoxButtons.OK,MessageBoxIcon.None,MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {
                //btnCancel_Click(sender, e);
            }
        }

        private void resetProductDetails()
        {
            txtCount.Text = "";
            txtStoreItemCode.Text = "";
            txtStoreItemName.Text = "";

            txtHeight.Text = "";
            txtHeight.Enabled = false;

            txtWidth.Text = "";
            txtWidth.Enabled = false;

            cbInch.Checked = false;

            txtPrice.Text = "";
            txtLimiter.Text = "";

            btnEditInvoiceDetails.Visible = false;

            zsmInvoiceDetailsProperties = "";
            InvoiceDetailsSelected = 0;

        }

        private void txtWidth_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtHeight.Focus();
                    break;

            }
        }

        private void txtHeight_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtCount.Focus();
                    break;

            }
        }

        private void txtCount_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtPrice.Focus();
                    break;
            }
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnAddToOrder_Click(sender, e);
                    break;
            }
        }
    }
}
