namespace ManoloSellManager
{
    partial class frmSettings
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
            this.tlpInvoiceSettings = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbInvoiceSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInvoicePrintSettin = new System.Windows.Forms.DataGridView();
            this.cTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpAddDescription = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddDescription = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTitle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tpOtherSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.ofdLogo = new System.Windows.Forms.OpenFileDialog();
            this.tlpInvoiceSettings.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbInvoiceSettings.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicePrintSettin)).BeginInit();
            this.tlpAddDescription.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpInvoiceSettings
            // 
            this.tlpInvoiceSettings.ColumnCount = 1;
            this.tlpInvoiceSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.28859F));
            this.tlpInvoiceSettings.Controls.Add(this.tabControl1, 0, 0);
            this.tlpInvoiceSettings.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tlpInvoiceSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInvoiceSettings.Location = new System.Drawing.Point(0, 0);
            this.tlpInvoiceSettings.Name = "tlpInvoiceSettings";
            this.tlpInvoiceSettings.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.tlpInvoiceSettings.RowCount = 2;
            this.tlpInvoiceSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.92873F));
            this.tlpInvoiceSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.071275F));
            this.tlpInvoiceSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpInvoiceSettings.Size = new System.Drawing.Size(926, 563);
            this.tlpInvoiceSettings.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpOtherSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(910, 501);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbInvoiceSettings);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(902, 475);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "تنظیمات فاکتور";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbInvoiceSettings
            // 
            this.gbInvoiceSettings.BackColor = System.Drawing.SystemColors.Control;
            this.gbInvoiceSettings.Controls.Add(this.tableLayoutPanel4);
            this.gbInvoiceSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInvoiceSettings.Location = new System.Drawing.Point(3, 3);
            this.gbInvoiceSettings.Name = "gbInvoiceSettings";
            this.gbInvoiceSettings.Size = new System.Drawing.Size(896, 469);
            this.gbInvoiceSettings.TabIndex = 0;
            this.gbInvoiceSettings.TabStop = false;
            this.gbInvoiceSettings.Text = "توضیحات فاکتور";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.dgvInvoicePrintSettin, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tlpAddDescription, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.28062F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.71938F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(890, 449);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // dgvInvoicePrintSettin
            // 
            this.dgvInvoicePrintSettin.AllowUserToAddRows = false;
            this.dgvInvoicePrintSettin.AllowUserToDeleteRows = false;
            this.dgvInvoicePrintSettin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoicePrintSettin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTitle,
            this.cValue});
            this.dgvInvoicePrintSettin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoicePrintSettin.Location = new System.Drawing.Point(3, 121);
            this.dgvInvoicePrintSettin.Name = "dgvInvoicePrintSettin";
            this.dgvInvoicePrintSettin.ReadOnly = true;
            this.dgvInvoicePrintSettin.Size = new System.Drawing.Size(884, 325);
            this.dgvInvoicePrintSettin.TabIndex = 2;
            this.dgvInvoicePrintSettin.DoubleClick += new System.EventHandler(this.dgvInvoicePrintSettin_DoubleClick);
            // 
            // cTitle
            // 
            this.cTitle.DataPropertyName = "SettingName";
            this.cTitle.HeaderText = "عنوان";
            this.cTitle.Name = "cTitle";
            this.cTitle.ReadOnly = true;
            this.cTitle.Width = 200;
            // 
            // cValue
            // 
            this.cValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cValue.DataPropertyName = "SettingValue";
            this.cValue.HeaderText = "مقدار";
            this.cValue.Name = "cValue";
            this.cValue.ReadOnly = true;
            // 
            // tlpAddDescription
            // 
            this.tlpAddDescription.ColumnCount = 7;
            this.tlpAddDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.69231F));
            this.tlpAddDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.30769F));
            this.tlpAddDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpAddDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 435F));
            this.tlpAddDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpAddDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpAddDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpAddDescription.Controls.Add(this.btnAddDescription, 4, 0);
            this.tlpAddDescription.Controls.Add(this.txtDescription, 3, 0);
            this.tlpAddDescription.Controls.Add(this.label1, 0, 0);
            this.tlpAddDescription.Controls.Add(this.cbTitle, 1, 0);
            this.tlpAddDescription.Controls.Add(this.label2, 2, 0);
            this.tlpAddDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAddDescription.Location = new System.Drawing.Point(3, 3);
            this.tlpAddDescription.Name = "tlpAddDescription";
            this.tlpAddDescription.RowCount = 1;
            this.tlpAddDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAddDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpAddDescription.Size = new System.Drawing.Size(884, 112);
            this.tlpAddDescription.TabIndex = 1;
            // 
            // btnAddDescription
            // 
            this.btnAddDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddDescription.Enabled = false;
            this.btnAddDescription.Location = new System.Drawing.Point(54, 3);
            this.btnAddDescription.Name = "btnAddDescription";
            this.btnAddDescription.Size = new System.Drawing.Size(31, 30);
            this.btnAddDescription.TabIndex = 14;
            this.btnAddDescription.Text = "+";
            this.btnAddDescription.UseVisualStyleBackColor = true;
            this.btnAddDescription.Click += new System.EventHandler(this.btnAddDescription_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(91, 3);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(429, 106);
            this.txtDescription.TabIndex = 13;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(831, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "نوع:";
            // 
            // cbTitle
            // 
            this.cbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTitle.FormattingEnabled = true;
            this.cbTitle.Location = new System.Drawing.Point(571, 3);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(254, 21);
            this.cbTitle.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(526, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 112);
            this.label2.TabIndex = 6;
            this.label2.Text = "مقدار:";
            // 
            // tpOtherSettings
            // 
            this.tpOtherSettings.Location = new System.Drawing.Point(4, 22);
            this.tpOtherSettings.Name = "tpOtherSettings";
            this.tpOtherSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpOtherSettings.Size = new System.Drawing.Size(783, 379);
            this.tpOtherSettings.TabIndex = 1;
            this.tpOtherSettings.Text = "سایر تنظیمات";
            this.tpOtherSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnSaveChanges, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 515);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(910, 45);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(247, 3);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(216, 39);
            this.btnSaveChanges.TabIndex = 7;
            this.btnSaveChanges.Text = "ثبت تغییرات";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(469, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(216, 39);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(691, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(216, 39);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ofdLogo
            // 
            this.ofdLogo.Filter = "Image Files(*.PNG;*.JPG;)|*.PNG;*.JPG;";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 563);
            this.Controls.Add(this.tlpInvoiceSettings);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "frmSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tlpInvoiceSettings.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbInvoiceSettings.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoicePrintSettin)).EndInit();
            this.tlpAddDescription.ResumeLayout(false);
            this.tlpAddDescription.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpInvoiceSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbInvoiceSettings;
        private System.Windows.Forms.TableLayoutPanel tlpAddDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView dgvInvoicePrintSettin;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnAddDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn cValue;
        protected internal System.Windows.Forms.ComboBox cbTitle;
        private System.Windows.Forms.TabPage tpOtherSettings;
        private System.Windows.Forms.OpenFileDialog ofdLogo;
    }
}

