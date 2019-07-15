namespace ManoloSellManager
{
    partial class frmCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCHvajhe = new System.Windows.Forms.TextBox();
            this.txtCHcost = new System.Windows.Forms.TextBox();
            this.txtCHowner = new System.Windows.Forms.TextBox();
            this.txtCHnumber = new System.Windows.Forms.TextBox();
            this.txtCHbank = new System.Windows.Forms.TextBox();
            this.dGv_ch = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddchek = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CustomerNo = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnOKEdit = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.rdbGet = new System.Windows.Forms.RadioButton();
            this.rdbPay = new System.Windows.Forms.RadioButton();
            this.GboxType = new System.Windows.Forms.GroupBox();
            this.txtChequeDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.gbPersonalsList = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSellerPhone = new System.Windows.Forms.TextBox();
            this.dgvPersonalsList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSetSeller = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSellerName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSellerCode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTotPayed = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotPayed = new System.Windows.Forms.TextBox();
            this.tlpTotPay = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotRecived = new System.Windows.Forms.TextBox();
            this.ttChequeType = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dGv_ch)).BeginInit();
            this.GboxType.SuspendLayout();
            this.gbPersonalsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalsList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpTotPayed.SuspendLayout();
            this.tlpTotPay.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ سررسید";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(573, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "در وجه";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(463, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "مبلغ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(548, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "صاحب حساب";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "سریال چک";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "بانک";
            // 
            // txtCHvajhe
            // 
            this.txtCHvajhe.Location = new System.Drawing.Point(495, 35);
            this.txtCHvajhe.Name = "txtCHvajhe";
            this.txtCHvajhe.Size = new System.Drawing.Size(113, 21);
            this.txtCHvajhe.TabIndex = 2;
            this.txtCHvajhe.TextChanged += new System.EventHandler(this.txtCHvajhe_TextChanged);
            // 
            // txtCHcost
            // 
            this.txtCHcost.Location = new System.Drawing.Point(374, 35);
            this.txtCHcost.Name = "txtCHcost";
            this.txtCHcost.Size = new System.Drawing.Size(113, 21);
            this.txtCHcost.TabIndex = 3;
            this.txtCHcost.TextChanged += new System.EventHandler(this.txtCHcost_TextChanged);
            this.txtCHcost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCHcost_KeyUp);
            // 
            // txtCHowner
            // 
            this.txtCHowner.Location = new System.Drawing.Point(495, 83);
            this.txtCHowner.Name = "txtCHowner";
            this.txtCHowner.Size = new System.Drawing.Size(113, 21);
            this.txtCHowner.TabIndex = 4;
            this.txtCHowner.TextChanged += new System.EventHandler(this.txtCHowner_TextChanged);
            // 
            // txtCHnumber
            // 
            this.txtCHnumber.Location = new System.Drawing.Point(374, 83);
            this.txtCHnumber.Name = "txtCHnumber";
            this.txtCHnumber.Size = new System.Drawing.Size(113, 21);
            this.txtCHnumber.TabIndex = 5;
            this.txtCHnumber.TextChanged += new System.EventHandler(this.txtCHnumber_TextChanged);
            // 
            // txtCHbank
            // 
            this.txtCHbank.Location = new System.Drawing.Point(253, 83);
            this.txtCHbank.Name = "txtCHbank";
            this.txtCHbank.Size = new System.Drawing.Size(113, 21);
            this.txtCHbank.TabIndex = 6;
            this.txtCHbank.TextChanged += new System.EventHandler(this.txtCHbank_TextChanged);
            // 
            // dGv_ch
            // 
            this.dGv_ch.AllowUserToAddRows = false;
            this.dGv_ch.AllowUserToDeleteRows = false;
            this.dGv_ch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGv_ch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dGv_ch.Location = new System.Drawing.Point(4, 154);
            this.dGv_ch.Name = "dGv_ch";
            this.dGv_ch.ReadOnly = true;
            this.dGv_ch.Size = new System.Drawing.Size(607, 232);
            this.dGv_ch.TabIndex = 14;
            this.dGv_ch.TabStop = false;
            this.dGv_ch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dGv_ch_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "شناسه ثبت";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "t_saresid";
            this.Column2.HeaderText = "تاریخ سررسید";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "mablagh";
            dataGridViewCellStyle1.Format = "C0";
            dataGridViewCellStyle1.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "مبلغ";
            this.Column4.MaxInputLength = 999999999;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "serail_chek";
            this.Column5.HeaderText = "سریال چک";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "saheb_hesab";
            this.Column6.HeaderText = "صاحب حساب";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 130;
            // 
            // btnAddchek
            // 
            this.btnAddchek.Location = new System.Drawing.Point(453, 115);
            this.btnAddchek.Name = "btnAddchek";
            this.btnAddchek.Size = new System.Drawing.Size(75, 23);
            this.btnAddchek.TabIndex = 8;
            this.btnAddchek.Text = "اضافه کردن";
            this.btnAddchek.UseVisualStyleBackColor = true;
            this.btnAddchek.Click += new System.EventHandler(this.btnAddchek_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "شماره مشتری";
            // 
            // CustomerNo
            // 
            this.CustomerNo.Location = new System.Drawing.Point(125, 35);
            this.CustomerNo.Name = "CustomerNo";
            this.CustomerNo.Size = new System.Drawing.Size(120, 21);
            this.CustomerNo.TabIndex = 7;
            this.CustomerNo.TextChanged += new System.EventHandler(this.CustomerNo_TextChanged);
            this.CustomerNo.Enter += new System.EventHandler(this.CustomerNo_Enter);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(287, 115);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(370, 115);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(536, 115);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnOKEdit
            // 
            this.btnOKEdit.Enabled = false;
            this.btnOKEdit.Location = new System.Drawing.Point(18, 115);
            this.btnOKEdit.Name = "btnOKEdit";
            this.btnOKEdit.Size = new System.Drawing.Size(75, 23);
            this.btnOKEdit.TabIndex = 14;
            this.btnOKEdit.Text = "ذخیره";
            this.btnOKEdit.UseVisualStyleBackColor = true;
            this.btnOKEdit.Click += new System.EventHandler(this.btnOKEdit_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Enabled = false;
            this.btnCancelEdit.Location = new System.Drawing.Point(99, 115);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(75, 23);
            this.btnCancelEdit.TabIndex = 13;
            this.btnCancelEdit.Text = "لغو";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(180, 115);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(105, 23);
            this.btnReload.TabIndex = 10;
            this.btnReload.Text = "بارگزاری مجدد";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.button2_Click);
            // 
            // rdbGet
            // 
            this.rdbGet.AutoSize = true;
            this.rdbGet.Checked = true;
            this.rdbGet.Location = new System.Drawing.Point(164, 22);
            this.rdbGet.Name = "rdbGet";
            this.rdbGet.Size = new System.Drawing.Size(60, 17);
            this.rdbGet.TabIndex = 19;
            this.rdbGet.TabStop = true;
            this.rdbGet.Text = "دریافتی";
            this.rdbGet.UseVisualStyleBackColor = true;
            // 
            // rdbPay
            // 
            this.rdbPay.AutoSize = true;
            this.rdbPay.Location = new System.Drawing.Point(76, 22);
            this.rdbPay.Name = "rdbPay";
            this.rdbPay.Size = new System.Drawing.Size(63, 17);
            this.rdbPay.TabIndex = 20;
            this.rdbPay.TabStop = true;
            this.rdbPay.Text = "پرداختی";
            this.rdbPay.UseVisualStyleBackColor = true;
            // 
            // GboxType
            // 
            this.GboxType.Controls.Add(this.rdbGet);
            this.GboxType.Controls.Add(this.rdbPay);
            this.GboxType.Location = new System.Drawing.Point(12, 61);
            this.GboxType.Name = "GboxType";
            this.GboxType.Size = new System.Drawing.Size(233, 48);
            this.GboxType.TabIndex = 21;
            this.GboxType.TabStop = false;
            this.GboxType.Text = "وضعیت چک(در سیستم)";
            this.ttChequeType.SetToolTip(this.GboxType, "زمانی که از مشتری یا اشخاص تعریف شده در سیستم چک دریافت میشود در این بخش نوع چک ر" +
        "ا \"دریافتی\" انتخاب میکنیم.\r\nدر مواقعی که چکی را به مشتری یا اشخاص پرداخت میکنید " +
        "گزینه \"پرداختی\" را انتخاب میکنیم.");
            // 
            // txtChequeDate
            // 
            this.txtChequeDate.Location = new System.Drawing.Point(253, 35);
            this.txtChequeDate.Name = "txtChequeDate";
            this.txtChequeDate.Size = new System.Drawing.Size(113, 21);
            this.txtChequeDate.TabIndex = 23;
            this.txtChequeDate.TextChanged += new System.EventHandler(this.txtChequeDate_TextChanged);
            this.txtChequeDate.Enter += new System.EventHandler(this.txtChequeDate_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "نام مشتری";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(12, 35);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(107, 21);
            this.txtCustomerName.TabIndex = 26;
            // 
            // gbPersonalsList
            // 
            this.gbPersonalsList.Controls.Add(this.label13);
            this.gbPersonalsList.Controls.Add(this.txtSellerPhone);
            this.gbPersonalsList.Controls.Add(this.dgvPersonalsList);
            this.gbPersonalsList.Controls.Add(this.btnSetSeller);
            this.gbPersonalsList.Controls.Add(this.label10);
            this.gbPersonalsList.Controls.Add(this.txtSellerName);
            this.gbPersonalsList.Controls.Add(this.label11);
            this.gbPersonalsList.Controls.Add(this.txtSellerCode);
            this.gbPersonalsList.Location = new System.Drawing.Point(12, 61);
            this.gbPersonalsList.Name = "gbPersonalsList";
            this.gbPersonalsList.Size = new System.Drawing.Size(343, 243);
            this.gbPersonalsList.TabIndex = 27;
            this.gbPersonalsList.TabStop = false;
            this.gbPersonalsList.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(43, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "شماره تماس";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSellerPhone
            // 
            this.txtSellerPhone.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtSellerPhone.Location = new System.Drawing.Point(6, 31);
            this.txtSellerPhone.Name = "txtSellerPhone";
            this.txtSellerPhone.Size = new System.Drawing.Size(100, 21);
            this.txtSellerPhone.TabIndex = 9;
            this.txtSellerPhone.TextChanged += new System.EventHandler(this.txtSellerPhone_TextChanged);
            // 
            // dgvPersonalsList
            // 
            this.dgvPersonalsList.AllowUserToAddRows = false;
            this.dgvPersonalsList.AllowUserToDeleteRows = false;
            this.dgvPersonalsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonalsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column3});
            this.dgvPersonalsList.Location = new System.Drawing.Point(7, 58);
            this.dgvPersonalsList.MultiSelect = false;
            this.dgvPersonalsList.Name = "dgvPersonalsList";
            this.dgvPersonalsList.ReadOnly = true;
            this.dgvPersonalsList.Size = new System.Drawing.Size(328, 150);
            this.dgvPersonalsList.TabIndex = 10;
            this.dgvPersonalsList.DoubleClick += new System.EventHandler(this.dgvPersonalsList_DoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "کد ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 35;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "نام و نام خانوادگی";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "phone";
            this.Column3.HeaderText = "تلفن";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnSetSeller
            // 
            this.btnSetSeller.Location = new System.Drawing.Point(7, 214);
            this.btnSetSeller.Name = "btnSetSeller";
            this.btnSetSeller.Size = new System.Drawing.Size(75, 23);
            this.btnSetSeller.TabIndex = 11;
            this.btnSetSeller.Text = "انتخاب";
            this.btnSetSeller.UseVisualStyleBackColor = true;
            this.btnSetSeller.Click += new System.EventHandler(this.btnSetSeller_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "نام مشتری:";
            // 
            // txtSellerName
            // 
            this.txtSellerName.Location = new System.Drawing.Point(113, 31);
            this.txtSellerName.Name = "txtSellerName";
            this.txtSellerName.Size = new System.Drawing.Size(139, 21);
            this.txtSellerName.TabIndex = 8;
            this.txtSellerName.TextChanged += new System.EventHandler(this.txtSellerName_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(272, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "کد مشتری:";
            // 
            // txtSellerCode
            // 
            this.txtSellerCode.Location = new System.Drawing.Point(258, 31);
            this.txtSellerCode.Name = "txtSellerCode";
            this.txtSellerCode.Size = new System.Drawing.Size(77, 21);
            this.txtSellerCode.TabIndex = 7;
            this.txtSellerCode.TextChanged += new System.EventHandler(this.txtSellerCode_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tlpTotPayed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpTotPay, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 392);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 50);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // tlpTotPayed
            // 
            this.tlpTotPayed.ColumnCount = 2;
            this.tlpTotPayed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.52632F));
            this.tlpTotPayed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.47369F));
            this.tlpTotPayed.Controls.Add(this.label12, 0, 0);
            this.tlpTotPayed.Controls.Add(this.txtTotPayed, 1, 0);
            this.tlpTotPayed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTotPayed.Location = new System.Drawing.Point(3, 3);
            this.tlpTotPayed.Name = "tlpTotPayed";
            this.tlpTotPayed.RowCount = 1;
            this.tlpTotPayed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTotPayed.Size = new System.Drawing.Size(304, 44);
            this.tlpTotPayed.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(199, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 44);
            this.label12.TabIndex = 0;
            this.label12.Text = "مجموع پرداخت ها:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotPayed
            // 
            this.txtTotPayed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotPayed.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTotPayed.Location = new System.Drawing.Point(3, 3);
            this.txtTotPayed.Multiline = true;
            this.txtTotPayed.Name = "txtTotPayed";
            this.txtTotPayed.ReadOnly = true;
            this.txtTotPayed.Size = new System.Drawing.Size(190, 38);
            this.txtTotPayed.TabIndex = 1;
            this.txtTotPayed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlpTotPay
            // 
            this.tlpTotPay.ColumnCount = 2;
            this.tlpTotPay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.52632F));
            this.tlpTotPay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.47369F));
            this.tlpTotPay.Controls.Add(this.label9, 0, 0);
            this.tlpTotPay.Controls.Add(this.txtTotRecived, 1, 0);
            this.tlpTotPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTotPay.Location = new System.Drawing.Point(313, 3);
            this.tlpTotPay.Name = "tlpTotPay";
            this.tlpTotPay.RowCount = 1;
            this.tlpTotPay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTotPay.Size = new System.Drawing.Size(304, 44);
            this.tlpTotPay.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(199, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 44);
            this.label9.TabIndex = 0;
            this.label9.Text = "مجموع دریافتی ها:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotRecived
            // 
            this.txtTotRecived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotRecived.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTotRecived.Location = new System.Drawing.Point(3, 3);
            this.txtTotRecived.Multiline = true;
            this.txtTotRecived.Name = "txtTotRecived";
            this.txtTotRecived.ReadOnly = true;
            this.txtTotRecived.Size = new System.Drawing.Size(190, 38);
            this.txtTotRecived.TabIndex = 1;
            this.txtTotRecived.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ttChequeType
            // 
            this.ttChequeType.AutomaticDelay = 1000;
            this.ttChequeType.AutoPopDelay = 10000;
            this.ttChequeType.InitialDelay = 1000;
            this.ttChequeType.IsBalloon = true;
            this.ttChequeType.ReshowDelay = 100;
            this.ttChequeType.Tag = "";
            this.ttChequeType.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttChequeType.ToolTipTitle = "وضعیت چک (در سیستم)";
            this.ttChequeType.Popup += new System.Windows.Forms.PopupEventHandler(this.ttChequeType_Popup);
            // 
            // frmCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 442);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gbPersonalsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtChequeDate);
            this.Controls.Add(this.GboxType);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnCancelEdit);
            this.Controls.Add(this.btnOKEdit);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.CustomerNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAddchek);
            this.Controls.Add(this.txtCHbank);
            this.Controls.Add(this.txtCHnumber);
            this.Controls.Add(this.txtCHowner);
            this.Controls.Add(this.txtCHcost);
            this.Controls.Add(this.txtCHvajhe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGv_ch);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheck";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت چک";
            this.Load += new System.EventHandler(this.frmCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGv_ch)).EndInit();
            this.GboxType.ResumeLayout(false);
            this.GboxType.PerformLayout();
            this.gbPersonalsList.ResumeLayout(false);
            this.gbPersonalsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalsList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpTotPayed.ResumeLayout(false);
            this.tlpTotPayed.PerformLayout();
            this.tlpTotPay.ResumeLayout(false);
            this.tlpTotPay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCHvajhe;
        private System.Windows.Forms.TextBox txtCHcost;
        private System.Windows.Forms.TextBox txtCHowner;
        private System.Windows.Forms.TextBox txtCHnumber;
        private System.Windows.Forms.TextBox txtCHbank;
        private System.Windows.Forms.DataGridView dGv_ch;
        private System.Windows.Forms.Button btnAddchek;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CustomerNo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnOKEdit;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.RadioButton rdbGet;
        private System.Windows.Forms.RadioButton rdbPay;
        private System.Windows.Forms.GroupBox GboxType;
        private System.Windows.Forms.TextBox txtChequeDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.GroupBox gbPersonalsList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSellerPhone;
        private System.Windows.Forms.DataGridView dgvPersonalsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnSetSeller;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSellerName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSellerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpTotPay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotRecived;
        private System.Windows.Forms.TableLayoutPanel tlpTotPayed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotPayed;
        private System.Windows.Forms.ToolTip ttChequeType;
    }
}