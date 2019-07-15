namespace ManoloSellManager.Forms
{
    partial class frmPayToPersonel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbPayment = new System.Windows.Forms.GroupBox();
            this.cbYearPay = new System.Windows.Forms.ComboBox();
            this.rbOtherPay = new System.Windows.Forms.RadioButton();
            this.lbl3 = new System.Windows.Forms.Label();
            this.rbSalaryPay = new System.Windows.Forms.RadioButton();
            this.cbMonthPay = new System.Windows.Forms.ComboBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtDescPay = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnAddPaymnt = new System.Windows.Forms.Button();
            this.txtPayValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbSalary = new System.Windows.Forms.GroupBox();
            this.btnSavePay = new System.Windows.Forms.Button();
            this.txtSalaryOver = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbYearSalary = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMonthSalary = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbPersonalsList = new System.Windows.Forms.GroupBox();
            this.dgvPersonalsList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSetSeller = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNCode = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblBlance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnChose = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnAddSalery = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.dgvPaytoPersonels = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNCodeM = new System.Windows.Forms.TextBox();
            this.txtNameM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allPaymentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.gbPayment.SuspendLayout();
            this.gbSalary.SuspendLayout();
            this.gbPersonalsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaytoPersonels)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbPayment);
            this.panel1.Controls.Add(this.gbSalary);
            this.panel1.Controls.Add(this.gbPersonalsList);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lblBlance);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnChose);
            this.panel1.Controls.Add(this.btnPayment);
            this.panel1.Controls.Add(this.btnAddSalery);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.dgvPaytoPersonels);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNCodeM);
            this.panel1.Controls.Add(this.txtNameM);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(407, 266);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // gbPayment
            // 
            this.gbPayment.Controls.Add(this.cbYearPay);
            this.gbPayment.Controls.Add(this.rbOtherPay);
            this.gbPayment.Controls.Add(this.lbl3);
            this.gbPayment.Controls.Add(this.rbSalaryPay);
            this.gbPayment.Controls.Add(this.cbMonthPay);
            this.gbPayment.Controls.Add(this.lbl2);
            this.gbPayment.Controls.Add(this.txtDescPay);
            this.gbPayment.Controls.Add(this.lbl1);
            this.gbPayment.Controls.Add(this.btnAddPaymnt);
            this.gbPayment.Controls.Add(this.txtPayValue);
            this.gbPayment.Controls.Add(this.label8);
            this.gbPayment.Location = new System.Drawing.Point(12, 38);
            this.gbPayment.Name = "gbPayment";
            this.gbPayment.Size = new System.Drawing.Size(305, 95);
            this.gbPayment.TabIndex = 36;
            this.gbPayment.TabStop = false;
            this.gbPayment.Visible = false;
            // 
            // cbYearPay
            // 
            this.cbYearPay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYearPay.FormattingEnabled = true;
            this.cbYearPay.Items.AddRange(new object[] {
            "1393",
            "1394",
            "1395",
            "1396",
            "1397",
            "1398",
            "1399",
            "1400"});
            this.cbYearPay.Location = new System.Drawing.Point(6, 36);
            this.cbYearPay.Name = "cbYearPay";
            this.cbYearPay.Size = new System.Drawing.Size(86, 21);
            this.cbYearPay.TabIndex = 12;
            // 
            // rbOtherPay
            // 
            this.rbOtherPay.AutoSize = true;
            this.rbOtherPay.Location = new System.Drawing.Point(140, 65);
            this.rbOtherPay.Name = "rbOtherPay";
            this.rbOtherPay.Size = new System.Drawing.Size(55, 17);
            this.rbOtherPay.TabIndex = 12;
            this.rbOtherPay.Text = "متفرقه";
            this.rbOtherPay.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(107, 39);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(27, 13);
            this.lbl3.TabIndex = 11;
            this.lbl3.Text = "سال";
            // 
            // rbSalaryPay
            // 
            this.rbSalaryPay.AutoSize = true;
            this.rbSalaryPay.Checked = true;
            this.rbSalaryPay.Location = new System.Drawing.Point(196, 65);
            this.rbSalaryPay.Name = "rbSalaryPay";
            this.rbSalaryPay.Size = new System.Drawing.Size(51, 17);
            this.rbSalaryPay.TabIndex = 11;
            this.rbSalaryPay.TabStop = true;
            this.rbSalaryPay.Text = "حقوق";
            this.rbSalaryPay.UseVisualStyleBackColor = true;
            this.rbSalaryPay.CheckedChanged += new System.EventHandler(this.rbSalaryPay_CheckedChanged);
            // 
            // cbMonthPay
            // 
            this.cbMonthPay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonthPay.FormattingEnabled = true;
            this.cbMonthPay.Items.AddRange(new object[] {
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان ",
            "آذر",
            "دی",
            "بهمن",
            "اسفند"});
            this.cbMonthPay.Location = new System.Drawing.Point(151, 36);
            this.cbMonthPay.Name = "cbMonthPay";
            this.cbMonthPay.Size = new System.Drawing.Size(86, 21);
            this.cbMonthPay.TabIndex = 10;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(244, 40);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(54, 13);
            this.lbl2.TabIndex = 9;
            this.lbl2.Text = "حقوق ماه ";
            // 
            // txtDescPay
            // 
            this.txtDescPay.Location = new System.Drawing.Point(6, 37);
            this.txtDescPay.Name = "txtDescPay";
            this.txtDescPay.Size = new System.Drawing.Size(231, 20);
            this.txtDescPay.TabIndex = 10;
            this.txtDescPay.Visible = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(243, 40);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(55, 13);
            this.lbl1.TabIndex = 9;
            this.lbl1.Text = "توضیحات :";
            this.lbl1.Visible = false;
            // 
            // btnAddPaymnt
            // 
            this.btnAddPaymnt.Location = new System.Drawing.Point(6, 62);
            this.btnAddPaymnt.Name = "btnAddPaymnt";
            this.btnAddPaymnt.Size = new System.Drawing.Size(75, 23);
            this.btnAddPaymnt.TabIndex = 8;
            this.btnAddPaymnt.Text = "ثبت";
            this.btnAddPaymnt.UseVisualStyleBackColor = true;
            this.btnAddPaymnt.Click += new System.EventHandler(this.btnAddPaymnt_Click);
            // 
            // txtPayValue
            // 
            this.txtPayValue.Location = new System.Drawing.Point(6, 13);
            this.txtPayValue.Name = "txtPayValue";
            this.txtPayValue.Size = new System.Drawing.Size(231, 20);
            this.txtPayValue.TabIndex = 5;
            this.txtPayValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayValue_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(243, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "مبلغ :";
            // 
            // gbSalary
            // 
            this.gbSalary.Controls.Add(this.btnSavePay);
            this.gbSalary.Controls.Add(this.txtSalaryOver);
            this.gbSalary.Controls.Add(this.label6);
            this.gbSalary.Controls.Add(this.txtSalary);
            this.gbSalary.Controls.Add(this.label5);
            this.gbSalary.Controls.Add(this.cbYearSalary);
            this.gbSalary.Controls.Add(this.label4);
            this.gbSalary.Controls.Add(this.cbMonthSalary);
            this.gbSalary.Controls.Add(this.label3);
            this.gbSalary.Location = new System.Drawing.Point(12, 38);
            this.gbSalary.Name = "gbSalary";
            this.gbSalary.Size = new System.Drawing.Size(292, 91);
            this.gbSalary.TabIndex = 35;
            this.gbSalary.TabStop = false;
            this.gbSalary.Visible = false;
            // 
            // btnSavePay
            // 
            this.btnSavePay.Location = new System.Drawing.Point(6, 63);
            this.btnSavePay.Name = "btnSavePay";
            this.btnSavePay.Size = new System.Drawing.Size(75, 23);
            this.btnSavePay.TabIndex = 8;
            this.btnSavePay.Text = "ثبت";
            this.btnSavePay.UseVisualStyleBackColor = true;
            this.btnSavePay.Click += new System.EventHandler(this.btnSavePay_Click);
            // 
            // txtSalaryOver
            // 
            this.txtSalaryOver.Location = new System.Drawing.Point(6, 37);
            this.txtSalaryOver.Name = "txtSalaryOver";
            this.txtSalaryOver.Size = new System.Drawing.Size(86, 20);
            this.txtSalaryOver.TabIndex = 7;
            this.txtSalaryOver.Text = "0";
            this.txtSalaryOver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayValue_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "+ اضافه کار";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(166, 37);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(86, 20);
            this.txtSalary.TabIndex = 5;
            this.txtSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayValue_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "مبلغ :";
            // 
            // cbYearSalary
            // 
            this.cbYearSalary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYearSalary.FormattingEnabled = true;
            this.cbYearSalary.Items.AddRange(new object[] {
            "1393",
            "1394",
            "1395",
            "1396",
            "1397",
            "1398",
            "1399",
            "1400"});
            this.cbYearSalary.Location = new System.Drawing.Point(6, 10);
            this.cbYearSalary.Name = "cbYearSalary";
            this.cbYearSalary.Size = new System.Drawing.Size(86, 21);
            this.cbYearSalary.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "سال";
            // 
            // cbMonthSalary
            // 
            this.cbMonthSalary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonthSalary.FormattingEnabled = true;
            this.cbMonthSalary.Items.AddRange(new object[] {
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان ",
            "آذر",
            "دی",
            "بهمن",
            "اسفند"});
            this.cbMonthSalary.Location = new System.Drawing.Point(140, 10);
            this.cbMonthSalary.Name = "cbMonthSalary";
            this.cbMonthSalary.Size = new System.Drawing.Size(86, 21);
            this.cbMonthSalary.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "حقوق ماه ";
            // 
            // gbPersonalsList
            // 
            this.gbPersonalsList.Controls.Add(this.dgvPersonalsList);
            this.gbPersonalsList.Controls.Add(this.btnSetSeller);
            this.gbPersonalsList.Controls.Add(this.label10);
            this.gbPersonalsList.Controls.Add(this.txtName);
            this.gbPersonalsList.Controls.Add(this.label11);
            this.gbPersonalsList.Controls.Add(this.txtNCode);
            this.gbPersonalsList.Location = new System.Drawing.Point(75, 9);
            this.gbPersonalsList.Name = "gbPersonalsList";
            this.gbPersonalsList.Size = new System.Drawing.Size(324, 243);
            this.gbPersonalsList.TabIndex = 28;
            this.gbPersonalsList.TabStop = false;
            this.gbPersonalsList.Visible = false;
            // 
            // dgvPersonalsList
            // 
            this.dgvPersonalsList.AllowUserToAddRows = false;
            this.dgvPersonalsList.AllowUserToDeleteRows = false;
            this.dgvPersonalsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonalsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column3,
            this.hireDate,
            this.job,
            this.pay,
            this.address});
            this.dgvPersonalsList.Location = new System.Drawing.Point(6, 58);
            this.dgvPersonalsList.MultiSelect = false;
            this.dgvPersonalsList.Name = "dgvPersonalsList";
            this.dgvPersonalsList.ReadOnly = true;
            this.dgvPersonalsList.Size = new System.Drawing.Size(310, 150);
            this.dgvPersonalsList.TabIndex = 10;
            this.dgvPersonalsList.DoubleClick += new System.EventHandler(this.dgvPersonalsList_DoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "کد ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
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
            this.Column3.DataPropertyName = "ncode";
            this.Column3.HeaderText = "شماره ملی";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // hireDate
            // 
            this.hireDate.DataPropertyName = "hireDate";
            this.hireDate.HeaderText = "تاریخ استخدام";
            this.hireDate.Name = "hireDate";
            this.hireDate.ReadOnly = true;
            this.hireDate.Visible = false;
            // 
            // job
            // 
            this.job.DataPropertyName = "job";
            this.job.HeaderText = "شغل";
            this.job.Name = "job";
            this.job.ReadOnly = true;
            this.job.Visible = false;
            // 
            // pay
            // 
            this.pay.DataPropertyName = "pay";
            this.pay.HeaderText = "حقوق";
            this.pay.Name = "pay";
            this.pay.ReadOnly = true;
            this.pay.Visible = false;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "آدرس";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Visible = false;
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
            this.label10.Location = new System.Drawing.Point(103, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "نام پرسنل :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(19, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(139, 20);
            this.txtName.TabIndex = 8;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "شماره ملی :";
            // 
            // txtNCode
            // 
            this.txtNCode.Location = new System.Drawing.Point(197, 32);
            this.txtNCode.Name = "txtNCode";
            this.txtNCode.Size = new System.Drawing.Size(113, 20);
            this.txtNCode.TabIndex = 7;
            this.txtNCode.TextChanged += new System.EventHandler(this.txtSellerCode_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 229);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 39;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblBlance
            // 
            this.lblBlance.AutoSize = true;
            this.lblBlance.Location = new System.Drawing.Point(247, 234);
            this.lblBlance.Name = "lblBlance";
            this.lblBlance.Size = new System.Drawing.Size(13, 13);
            this.lblBlance.TabIndex = 38;
            this.lblBlance.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "مانده حساب :";
            // 
            // btnChose
            // 
            this.btnChose.Location = new System.Drawing.Point(302, 38);
            this.btnChose.Name = "btnChose";
            this.btnChose.Size = new System.Drawing.Size(97, 23);
            this.btnChose.TabIndex = 34;
            this.btnChose.Text = "انتخاب پرسنل";
            this.btnChose.UseVisualStyleBackColor = true;
            this.btnChose.Click += new System.EventHandler(this.btnChose_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Enabled = false;
            this.btnPayment.Location = new System.Drawing.Point(93, 38);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(75, 23);
            this.btnPayment.TabIndex = 33;
            this.btnPayment.Text = "پرداختی";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnAddSalery
            // 
            this.btnAddSalery.Enabled = false;
            this.btnAddSalery.Location = new System.Drawing.Point(174, 38);
            this.btnAddSalery.Name = "btnAddSalery";
            this.btnAddSalery.Size = new System.Drawing.Size(75, 23);
            this.btnAddSalery.TabIndex = 32;
            this.btnAddSalery.Text = "درچ حقوق";
            this.btnAddSalery.UseVisualStyleBackColor = true;
            this.btnAddSalery.Click += new System.EventHandler(this.btnAddSalery_Click);
            // 
            // btnDel
            // 
            this.btnDel.Enabled = false;
            this.btnDel.Location = new System.Drawing.Point(12, 38);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 31;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // dgvPaytoPersonels
            // 
            this.dgvPaytoPersonels.AllowUserToAddRows = false;
            this.dgvPaytoPersonels.AllowUserToDeleteRows = false;
            this.dgvPaytoPersonels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaytoPersonels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.allPaymentId,
            this.ncode,
            this.desc,
            this.payment});
            this.dgvPaytoPersonels.Location = new System.Drawing.Point(12, 67);
            this.dgvPaytoPersonels.Name = "dgvPaytoPersonels";
            this.dgvPaytoPersonels.ReadOnly = true;
            this.dgvPaytoPersonels.RowHeadersVisible = false;
            this.dgvPaytoPersonels.Size = new System.Drawing.Size(387, 156);
            this.dgvPaytoPersonels.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "شماره ملی :";
            // 
            // txtNCodeM
            // 
            this.txtNCodeM.Location = new System.Drawing.Point(12, 12);
            this.txtNCodeM.Name = "txtNCodeM";
            this.txtNCodeM.Size = new System.Drawing.Size(100, 20);
            this.txtNCodeM.TabIndex = 1;
            this.txtNCodeM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayValue_KeyPress);
            // 
            // txtNameM
            // 
            this.txtNameM.Location = new System.Drawing.Point(187, 12);
            this.txtNameM.Name = "txtNameM";
            this.txtNameM.Size = new System.Drawing.Size(109, 20);
            this.txtNameM.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام و نام خانوادگی :";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // allPaymentId
            // 
            this.allPaymentId.DataPropertyName = "idAllPayment";
            this.allPaymentId.HeaderText = "allPaymentId";
            this.allPaymentId.Name = "allPaymentId";
            this.allPaymentId.ReadOnly = true;
            this.allPaymentId.Visible = false;
            // 
            // ncode
            // 
            this.ncode.DataPropertyName = "ncode";
            this.ncode.HeaderText = "ncode";
            this.ncode.Name = "ncode";
            this.ncode.ReadOnly = true;
            this.ncode.Visible = false;
            // 
            // desc
            // 
            this.desc.DataPropertyName = "desc";
            this.desc.HeaderText = "توضیحات";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 250;
            // 
            // payment
            // 
            this.payment.DataPropertyName = "payment";
            this.payment.HeaderText = "پرداختی";
            this.payment.Name = "payment";
            this.payment.ReadOnly = true;
            // 
            // frmPayToPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 266);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPayToPersonel";
            this.Text = "پرداخت به پرسنل";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbPayment.ResumeLayout(false);
            this.gbPayment.PerformLayout();
            this.gbSalary.ResumeLayout(false);
            this.gbSalary.PerformLayout();
            this.gbPersonalsList.ResumeLayout(false);
            this.gbPersonalsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaytoPersonels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNameM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbPersonalsList;
        private System.Windows.Forms.DataGridView dgvPersonalsList;
        private System.Windows.Forms.Button btnSetSeller;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNCode;
        private System.Windows.Forms.TextBox txtNCodeM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn hireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn job;
        private System.Windows.Forms.DataGridViewTextBoxColumn pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPaytoPersonels;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnAddSalery;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnChose;
        private System.Windows.Forms.GroupBox gbSalary;
        private System.Windows.Forms.ComboBox cbMonthSalary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbYearSalary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSavePay;
        private System.Windows.Forms.TextBox txtSalaryOver;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbPayment;
        private System.Windows.Forms.TextBox txtDescPay;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnAddPaymnt;
        private System.Windows.Forms.TextBox txtPayValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblBlance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbYearPay;
        private System.Windows.Forms.RadioButton rbOtherPay;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.RadioButton rbSalaryPay;
        private System.Windows.Forms.ComboBox cbMonthPay;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn allPaymentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncode;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn payment;
    }
}