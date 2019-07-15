namespace ManoloSellManager.Forms
{
    partial class frmPersonalAccount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dsPA = new ManoloSellManager.reports.dsPA();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCalcPersonalAccountStatus = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemPay = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCash = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIShowAccountDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddDue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOffer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiR = new System.Windows.Forms.ToolStripMenuItem();
            this.gbAccountStatus = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOldDue = new System.Windows.Forms.TextBox();
            this.dgvReaminAccountList = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsOldRemainaccount = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOldRemainaccountDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.txtBestankar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotPay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotBuy = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPish = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsInvoiceEditMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiProformaEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransferProforma = new System.Windows.Forms.ToolStripMenuItem();
            this.label15 = new System.Windows.Forms.Label();
            this.tlpAllInvoiceList = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAllInvoiceList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAllPay = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsPayManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDeletePay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPayEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.نمایشصورتحسابToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تغییرشخصToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dsPA)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbAccountStatus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaminAccountList)).BeginInit();
            this.cmsOldRemainaccount.SuspendLayout();
            this.gbPersonalsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalsList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPish)).BeginInit();
            this.cmsInvoiceEditMode.SuspendLayout();
            this.tlpAllInvoiceList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoiceList)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPay)).BeginInit();
            this.cmsPayManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsPA
            // 
            this.dsPA.DataSetName = "dsPA";
            this.dsPA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCalcPersonalAccountStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات مشتری";
            // 
            // btnCalcPersonalAccountStatus
            // 
            this.btnCalcPersonalAccountStatus.Location = new System.Drawing.Point(12, 39);
            this.btnCalcPersonalAccountStatus.Name = "btnCalcPersonalAccountStatus";
            this.btnCalcPersonalAccountStatus.Size = new System.Drawing.Size(90, 23);
            this.btnCalcPersonalAccountStatus.TabIndex = 2;
            this.btnCalcPersonalAccountStatus.Text = "نمایش اطلاعات حساب";
            this.btnCalcPersonalAccountStatus.UseVisualStyleBackColor = true;
            this.btnCalcPersonalAccountStatus.Visible = false;
            this.btnCalcPersonalAccountStatus.Click += new System.EventHandler(this.btnCalcPersonalAccountStatus_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "آدرس";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtAddress.Location = new System.Drawing.Point(108, 41);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(326, 21);
            this.txtAddress.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.Location = new System.Drawing.Point(712, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "گروه";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbType
            // 
            this.cbType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbType.Enabled = false;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "فروشنده",
            "مشتری"});
            this.cbType.Location = new System.Drawing.Point(654, 41);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(92, 21);
            this.cbType.Sorted = true;
            this.cbType.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "شماره تماس";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPhone.Location = new System.Drawing.Point(440, 41);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(100, 21);
            this.txtPhone.TabIndex = 15;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "نام و نام خانوادگی";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtName.Location = new System.Drawing.Point(546, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 14;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemPay,
            this.TSMIShowAccountDetails,
            this.tsmiAddDue,
            this.tsmiOffer});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(758, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemPay
            // 
            this.ToolStripMenuItemPay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCash,
            this.ToolStripMenuItemCheck});
            this.ToolStripMenuItemPay.Enabled = false;
            this.ToolStripMenuItemPay.Name = "ToolStripMenuItemPay";
            this.ToolStripMenuItemPay.Size = new System.Drawing.Size(135, 20);
            this.ToolStripMenuItemPay.Text = "ثبت پرداخت های شخص";
            this.ToolStripMenuItemPay.Click += new System.EventHandler(this.ToolStripMenuItemPay_Click);
            // 
            // ToolStripMenuItemCash
            // 
            this.ToolStripMenuItemCash.Name = "ToolStripMenuItemCash";
            this.ToolStripMenuItemCash.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.ToolStripMenuItemCash.Size = new System.Drawing.Size(235, 22);
            this.ToolStripMenuItemCash.Text = "ثبت پرداخت نقدی";
            this.ToolStripMenuItemCash.Click += new System.EventHandler(this.ToolStripMenuItemCash_Click);
            // 
            // ToolStripMenuItemCheck
            // 
            this.ToolStripMenuItemCheck.Name = "ToolStripMenuItemCheck";
            this.ToolStripMenuItemCheck.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.ToolStripMenuItemCheck.Size = new System.Drawing.Size(235, 22);
            this.ToolStripMenuItemCheck.Text = "ثبت پرداخت با چک";
            this.ToolStripMenuItemCheck.Click += new System.EventHandler(this.ToolStripMenuItemCheck_Click);
            // 
            // TSMIShowAccountDetails
            // 
            this.TSMIShowAccountDetails.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.نمایشصورتحسابToolStripMenuItem,
            this.تغییرشخصToolStripMenuItem});
            this.TSMIShowAccountDetails.Enabled = false;
            this.TSMIShowAccountDetails.Name = "TSMIShowAccountDetails";
            this.TSMIShowAccountDetails.Size = new System.Drawing.Size(121, 20);
            this.TSMIShowAccountDetails.Text = "نمایش صورت حساب";
            // 
            // tsmiAddDue
            // 
            this.tsmiAddDue.Enabled = false;
            this.tsmiAddDue.Name = "tsmiAddDue";
            this.tsmiAddDue.Size = new System.Drawing.Size(101, 20);
            this.tsmiAddDue.Text = "ثبت مانده حساب";
            this.tsmiAddDue.Click += new System.EventHandler(this.tsmiAddDue_Click);
            // 
            // tsmiOffer
            // 
            this.tsmiOffer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiR});
            this.tsmiOffer.Name = "tsmiOffer";
            this.tsmiOffer.Size = new System.Drawing.Size(66, 20);
            this.tsmiOffer.Text = "تخفیف ها";
            this.tsmiOffer.Visible = false;
            // 
            // tsmiR
            // 
            this.tsmiR.Name = "tsmiR";
            this.tsmiR.Size = new System.Drawing.Size(152, 22);
            this.tsmiR.Text = "کسر از بدهی";
            this.tsmiR.Click += new System.EventHandler(this.tsmiR_Click);
            // 
            // gbAccountStatus
            // 
            this.gbAccountStatus.Controls.Add(this.groupBox2);
            this.gbAccountStatus.Controls.Add(this.txtBestankar);
            this.gbAccountStatus.Controls.Add(this.label9);
            this.gbAccountStatus.Controls.Add(this.txtDue);
            this.gbAccountStatus.Controls.Add(this.label7);
            this.gbAccountStatus.Controls.Add(this.txtTotPay);
            this.gbAccountStatus.Controls.Add(this.label6);
            this.gbAccountStatus.Controls.Add(this.label5);
            this.gbAccountStatus.Controls.Add(this.txtTotBuy);
            this.gbAccountStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAccountStatus.Location = new System.Drawing.Point(0, 95);
            this.gbAccountStatus.Name = "gbAccountStatus";
            this.gbAccountStatus.Size = new System.Drawing.Size(758, 169);
            this.gbAccountStatus.TabIndex = 3;
            this.gbAccountStatus.TabStop = false;
            this.gbAccountStatus.Text = "وضعیت مالی";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtOldDue);
            this.groupBox2.Controls.Add(this.dgvReaminAccountList);
            this.groupBox2.Location = new System.Drawing.Point(6, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 151);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لیست بدهی پیشین";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(199, 125);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "مجموع:";
            // 
            // txtOldDue
            // 
            this.txtOldDue.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldDue.Location = new System.Drawing.Point(6, 120);
            this.txtOldDue.Name = "txtOldDue";
            this.txtOldDue.ReadOnly = true;
            this.txtOldDue.Size = new System.Drawing.Size(189, 24);
            this.txtOldDue.TabIndex = 8;
            this.txtOldDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvReaminAccountList
            // 
            this.dgvReaminAccountList.AllowUserToAddRows = false;
            this.dgvReaminAccountList.AllowUserToDeleteRows = false;
            this.dgvReaminAccountList.AllowUserToOrderColumns = true;
            this.dgvReaminAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReaminAccountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column8,
            this.Column9});
            this.dgvReaminAccountList.ContextMenuStrip = this.cmsOldRemainaccount;
            this.dgvReaminAccountList.Location = new System.Drawing.Point(6, 19);
            this.dgvReaminAccountList.MultiSelect = false;
            this.dgvReaminAccountList.Name = "dgvReaminAccountList";
            this.dgvReaminAccountList.ReadOnly = true;
            this.dgvReaminAccountList.RowHeadersWidth = 31;
            this.dgvReaminAccountList.Size = new System.Drawing.Size(287, 95);
            this.dgvReaminAccountList.TabIndex = 11;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "id";
            this.Column10.HeaderText = "شناسه";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 50;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "payDate";
            dataGridViewCellStyle36.Format = "yyyy/MM/dd";
            this.Column8.DefaultCellStyle = dataGridViewCellStyle36;
            this.Column8.HeaderText = "تاریخ ثبت";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 75;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "payPrice";
            dataGridViewCellStyle37.Format = "C0";
            this.Column9.DefaultCellStyle = dataGridViewCellStyle37;
            this.Column9.HeaderText = "مبلغ";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 115;
            // 
            // cmsOldRemainaccount
            // 
            this.cmsOldRemainaccount.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsOldRemainaccount.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOldRemainaccountDelete});
            this.cmsOldRemainaccount.Name = "cmsOldRemainaccount";
            this.cmsOldRemainaccount.Size = new System.Drawing.Size(100, 26);
            // 
            // tsmiOldRemainaccountDelete
            // 
            this.tsmiOldRemainaccountDelete.Name = "tsmiOldRemainaccountDelete";
            this.tsmiOldRemainaccountDelete.Size = new System.Drawing.Size(99, 22);
            this.tsmiOldRemainaccountDelete.Text = "حذف";
            this.tsmiOldRemainaccountDelete.Click += new System.EventHandler(this.tsmiOldRemainaccountDelete_Click);
            // 
            // txtBestankar
            // 
            this.txtBestankar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBestankar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBestankar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtBestankar.Location = new System.Drawing.Point(348, 80);
            this.txtBestankar.Name = "txtBestankar";
            this.txtBestankar.ReadOnly = true;
            this.txtBestankar.Size = new System.Drawing.Size(192, 27);
            this.txtBestankar.TabIndex = 10;
            this.txtBestankar.Text = "0";
            this.txtBestankar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(465, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "بستان کار - ریال";
            // 
            // txtDue
            // 
            this.txtDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtDue.Location = new System.Drawing.Point(546, 80);
            this.txtDue.Name = "txtDue";
            this.txtDue.ReadOnly = true;
            this.txtDue.Size = new System.Drawing.Size(200, 27);
            this.txtDue.TabIndex = 6;
            this.txtDue.Text = "0";
            this.txtDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(656, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "مانده حساب - ریال";
            // 
            // txtTotPay
            // 
            this.txtTotPay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotPay.Location = new System.Drawing.Point(348, 37);
            this.txtTotPay.Name = "txtTotPay";
            this.txtTotPay.ReadOnly = true;
            this.txtTotPay.Size = new System.Drawing.Size(192, 23);
            this.txtTotPay.TabIndex = 4;
            this.txtTotPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "مجموع پرداخت ها - ریال";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(676, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "کل خرید - ریال";
            // 
            // txtTotBuy
            // 
            this.txtTotBuy.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotBuy.Location = new System.Drawing.Point(546, 37);
            this.txtTotBuy.Name = "txtTotBuy";
            this.txtTotBuy.ReadOnly = true;
            this.txtTotBuy.Size = new System.Drawing.Size(198, 23);
            this.txtTotBuy.TabIndex = 0;
            this.txtTotBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.gbPersonalsList.Location = new System.Drawing.Point(303, 92);
            this.gbPersonalsList.Name = "gbPersonalsList";
            this.gbPersonalsList.Size = new System.Drawing.Size(343, 243);
            this.gbPersonalsList.TabIndex = 6;
            this.gbPersonalsList.TabStop = false;
            this.gbPersonalsList.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "شماره تماس";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSellerPhone
            // 
            this.txtSellerPhone.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtSellerPhone.Location = new System.Drawing.Point(7, 31);
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
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.6907F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.3093F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpAllInvoiceList, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 270);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(758, 205);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dgvPish, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(251, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42604F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.57397F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(153, 199);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // dgvPish
            // 
            this.dgvPish.AllowUserToAddRows = false;
            this.dgvPish.AllowUserToDeleteRows = false;
            this.dgvPish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvPish.ContextMenuStrip = this.cmsInvoiceEditMode;
            this.dgvPish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPish.Location = new System.Drawing.Point(3, 27);
            this.dgvPish.Name = "dgvPish";
            this.dgvPish.ReadOnly = true;
            this.dgvPish.RowHeadersWidth = 30;
            this.dgvPish.Size = new System.Drawing.Size(147, 169);
            this.dgvPish.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "InvoiceId";
            this.dataGridViewTextBoxColumn5.HeaderText = "شماره";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "InvoiceDate";
            dataGridViewCellStyle38.Format = "yyyy/MM/dd";
            dataGridViewCellStyle38.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle38;
            this.dataGridViewTextBoxColumn6.HeaderText = "تاریخ";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // cmsInvoiceEditMode
            // 
            this.cmsInvoiceEditMode.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsInvoiceEditMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProformaEdit,
            this.tsmiTransferProforma});
            this.cmsInvoiceEditMode.Name = "cmsInvoiceEditMode";
            this.cmsInvoiceEditMode.Size = new System.Drawing.Size(159, 48);
            // 
            // tsmiProformaEdit
            // 
            this.tsmiProformaEdit.Name = "tsmiProformaEdit";
            this.tsmiProformaEdit.Size = new System.Drawing.Size(158, 22);
            this.tsmiProformaEdit.Text = "ویرایش";
            this.tsmiProformaEdit.Click += new System.EventHandler(this.tsmiProformaEdit_Click);
            // 
            // tsmiTransferProforma
            // 
            this.tsmiTransferProforma.Name = "tsmiTransferProforma";
            this.tsmiTransferProforma.Size = new System.Drawing.Size(158, 22);
            this.tsmiTransferProforma.Text = "انتقال به فاکتورها";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(50, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "لیست پیش فاکتورها";
            // 
            // tlpAllInvoiceList
            // 
            this.tlpAllInvoiceList.ColumnCount = 1;
            this.tlpAllInvoiceList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAllInvoiceList.Controls.Add(this.dgvAllInvoiceList, 0, 1);
            this.tlpAllInvoiceList.Controls.Add(this.label12, 0, 0);
            this.tlpAllInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAllInvoiceList.Location = new System.Drawing.Point(3, 3);
            this.tlpAllInvoiceList.Name = "tlpAllInvoiceList";
            this.tlpAllInvoiceList.RowCount = 2;
            this.tlpAllInvoiceList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42604F));
            this.tlpAllInvoiceList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.57397F));
            this.tlpAllInvoiceList.Size = new System.Drawing.Size(242, 199);
            this.tlpAllInvoiceList.TabIndex = 4;
            // 
            // dgvAllInvoiceList
            // 
            this.dgvAllInvoiceList.AllowUserToAddRows = false;
            this.dgvAllInvoiceList.AllowUserToDeleteRows = false;
            this.dgvAllInvoiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInvoiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dgvAllInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllInvoiceList.Location = new System.Drawing.Point(3, 27);
            this.dgvAllInvoiceList.Name = "dgvAllInvoiceList";
            this.dgvAllInvoiceList.ReadOnly = true;
            this.dgvAllInvoiceList.RowHeadersWidth = 25;
            this.dgvAllInvoiceList.Size = new System.Drawing.Size(236, 169);
            this.dgvAllInvoiceList.TabIndex = 2;
            this.dgvAllInvoiceList.DoubleClick += new System.EventHandler(this.dgvAllInvoiceList_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "InvoiceId";
            this.Column1.HeaderText = "شماره";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "InvoiceDate";
            dataGridViewCellStyle39.Format = "yyyy/MM/dd";
            dataGridViewCellStyle39.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle39;
            this.Column2.HeaderText = "تاریخ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "InvoicePrice";
            dataGridViewCellStyle40.Format = "C0";
            dataGridViewCellStyle40.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle40;
            this.Column4.HeaderText = "مبلغ فاکتور";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "InvoiceDiscount";
            this.Column5.HeaderText = "تخفیف";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(163, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "لیست فاکتورها";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgvAllPay, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(410, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42604F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.57397F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(345, 199);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dgvAllPay
            // 
            this.dgvAllPay.AllowUserToAddRows = false;
            this.dgvAllPay.AllowUserToDeleteRows = false;
            this.dgvAllPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllPay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3,
            this.Column7});
            this.dgvAllPay.ContextMenuStrip = this.cmsPayManager;
            this.dgvAllPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllPay.Location = new System.Drawing.Point(3, 27);
            this.dgvAllPay.Name = "dgvAllPay";
            this.dgvAllPay.ReadOnly = true;
            this.dgvAllPay.RowHeadersWidth = 25;
            this.dgvAllPay.Size = new System.Drawing.Size(339, 169);
            this.dgvAllPay.TabIndex = 2;
            this.dgvAllPay.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllPay_CellContentDoubleClick);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "id";
            this.Column6.HeaderText = "شناسه پرداخت";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "payDate";
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle41.Format = "yyyy/MM/dd";
            dataGridViewCellStyle41.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle41;
            this.dataGridViewTextBoxColumn4.HeaderText = "تاریخ";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "payPrice";
            dataGridViewCellStyle42.Format = "C0";
            dataGridViewCellStyle42.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle42;
            this.dataGridViewTextBoxColumn3.HeaderText = "مبلغ";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 999999999;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "payAbout";
            this.Column7.HeaderText = "شرح پرداخت";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // cmsPayManager
            // 
            this.cmsPayManager.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsPayManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeletePay,
            this.tsmiPayEdit});
            this.cmsPayManager.Name = "cmsPayManager";
            this.cmsPayManager.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsPayManager.Size = new System.Drawing.Size(111, 48);
            // 
            // tsmiDeletePay
            // 
            this.tsmiDeletePay.Name = "tsmiDeletePay";
            this.tsmiDeletePay.Size = new System.Drawing.Size(110, 22);
            this.tsmiDeletePay.Text = "حذف";
            this.tsmiDeletePay.Click += new System.EventHandler(this.tsmiDeletePay_Click);
            // 
            // tsmiPayEdit
            // 
            this.tsmiPayEdit.Name = "tsmiPayEdit";
            this.tsmiPayEdit.Size = new System.Drawing.Size(110, 22);
            this.tsmiPayEdit.Text = "ویرایش";
            this.tsmiPayEdit.Click += new System.EventHandler(this.tsmiPayEdit_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(256, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "لیست پرداخت ها";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(669, 440);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "بازگشت";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // نمایشصورتحسابToolStripMenuItem
            // 
            this.نمایشصورتحسابToolStripMenuItem.Name = "نمایشصورتحسابToolStripMenuItem";
            this.نمایشصورتحسابToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.نمایشصورتحسابToolStripMenuItem.Text = "نمایش صورت حساب";
            this.نمایشصورتحسابToolStripMenuItem.Click += new System.EventHandler(this.TSMIShowAccountDetails_Click);
            // 
            // تغییرشخصToolStripMenuItem
            // 
            this.تغییرشخصToolStripMenuItem.Name = "تغییرشخصToolStripMenuItem";
            this.تغییرشخصToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.تغییرشخصToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.تغییرشخصToolStripMenuItem.Text = "تغییر شخص";
            this.تغییرشخصToolStripMenuItem.Click += new System.EventHandler(this.تغییرشخصToolStripMenuItem_Click);
            // 
            // frmPersonalAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 475);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbPersonalsList);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gbAccountStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonalAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "وضعیت مالی اشخاص";
            this.Activated += new System.EventHandler(this.frmPersonalAccount_Activated);
            this.Load += new System.EventHandler(this.frmPersonalAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPA)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbAccountStatus.ResumeLayout(false);
            this.gbAccountStatus.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaminAccountList)).EndInit();
            this.cmsOldRemainaccount.ResumeLayout(false);
            this.gbPersonalsList.ResumeLayout(false);
            this.gbPersonalsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalsList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPish)).EndInit();
            this.cmsInvoiceEditMode.ResumeLayout(false);
            this.tlpAllInvoiceList.ResumeLayout(false);
            this.tlpAllInvoiceList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInvoiceList)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPay)).EndInit();
            this.cmsPayManager.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCalcPersonalAccountStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPay;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCash;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCheck;
        private System.Windows.Forms.GroupBox gbAccountStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotBuy;
        private System.Windows.Forms.TextBox txtTotPay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOldDue;
        private System.Windows.Forms.TextBox txtBestankar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbPersonalsList;
        private System.Windows.Forms.DataGridView dgvPersonalsList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnSetSeller;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSellerName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSellerCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSellerPhone;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvAllPay;
        private System.Windows.Forms.Label label14;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private reports.dsPA dsPA;
        private System.Windows.Forms.ToolStripMenuItem TSMIShowAccountDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddDue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvPish;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TableLayoutPanel tlpAllInvoiceList;
        private System.Windows.Forms.DataGridView dgvAllInvoiceList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip cmsPayManager;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeletePay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvReaminAccountList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip cmsOldRemainaccount;
        private System.Windows.Forms.ToolStripMenuItem tsmiOldRemainaccountDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.ToolStripMenuItem tsmiPayEdit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ToolStripMenuItem tsmiOffer;
        private System.Windows.Forms.ToolStripMenuItem tsmiR;
        private System.Windows.Forms.ContextMenuStrip cmsInvoiceEditMode;
        private System.Windows.Forms.ToolStripMenuItem tsmiProformaEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransferProforma;
        private System.Windows.Forms.ToolStripMenuItem نمایشصورتحسابToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem تغییرشخصToolStripMenuItem;
    }
}