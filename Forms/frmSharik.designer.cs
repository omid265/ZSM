namespace ManoloSellManager.Forms
{
    partial class frmSharik
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
            this.label1 = new System.Windows.Forms.Label();
            this.dGVSharik = new System.Windows.Forms.DataGridView();
            this.clm_name_family = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_sahm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_sood_mah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_sood_sal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditData = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShare = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblShomaresahamDar = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeleteSharik = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_sood_mah = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_sood_sal = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.lblKoleSahm = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSharik)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(767, 24);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "کل سهام            :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dGVSharik
            // 
            this.dGVSharik.AllowUserToDeleteRows = false;
            this.dGVSharik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSharik.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clm_name_family,
            this.clm_sahm,
            this.clm_sood_mah,
            this.clm_sood_sal});
            this.dGVSharik.Location = new System.Drawing.Point(38, 19);
            this.dGVSharik.Name = "dGVSharik";
            this.dGVSharik.ReadOnly = true;
            this.dGVSharik.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dGVSharik.Size = new System.Drawing.Size(461, 254);
            this.dGVSharik.TabIndex = 7;
            this.dGVSharik.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVSharik_CellContentClick);
            // 
            // clm_name_family
            // 
            this.clm_name_family.DataPropertyName = "Name_Family";
            this.clm_name_family.HeaderText = "نام و نام خانوادگی";
            this.clm_name_family.Name = "clm_name_family";
            this.clm_name_family.ReadOnly = true;
            // 
            // clm_sahm
            // 
            this.clm_sahm.DataPropertyName = "Sahme";
            this.clm_sahm.HeaderText = "مقدار سهم ";
            this.clm_sahm.Name = "clm_sahm";
            this.clm_sahm.ReadOnly = true;
            // 
            // clm_sood_mah
            // 
            this.clm_sood_mah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clm_sood_mah.DataPropertyName = "sood_mah";
            this.clm_sood_mah.HeaderText = "سود ماه";
            this.clm_sood_mah.Name = "clm_sood_mah";
            this.clm_sood_mah.ReadOnly = true;
            // 
            // clm_sood_sal
            // 
            this.clm_sood_sal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clm_sood_sal.DataPropertyName = "sood_sal";
            this.clm_sood_sal.HeaderText = "سود سال";
            this.clm_sood_sal.Name = "clm_sood_sal";
            this.clm_sood_sal.ReadOnly = true;
            // 
            // btnEditData
            // 
            this.btnEditData.Enabled = false;
            this.btnEditData.Location = new System.Drawing.Point(514, 196);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(75, 23);
            this.btnEditData.TabIndex = 8;
            this.btnEditData.Text = "ویرایش";
            this.btnEditData.UseVisualStyleBackColor = true;
            this.btnEditData.Click += new System.EventHandler(this.btnEditData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(765, 167);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "تعداد سهام     :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtShare
            // 
            this.txtShare.Location = new System.Drawing.Point(642, 166);
            this.txtShare.Name = "txtShare";
            this.txtShare.Size = new System.Drawing.Size(100, 20);
            this.txtShare.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(747, 143);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "نام و نام خانوادگی   :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(642, 140);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 9;
            // 
            // lblShomaresahamDar
            // 
            this.lblShomaresahamDar.AutoSize = true;
            this.lblShomaresahamDar.Location = new System.Drawing.Point(791, 114);
            this.lblShomaresahamDar.Name = "lblShomaresahamDar";
            this.lblShomaresahamDar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblShomaresahamDar.Size = new System.Drawing.Size(53, 13);
            this.lblShomaresahamDar.TabIndex = 14;
            this.lblShomaresahamDar.Text = "سهام دار :";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(514, 138);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "اضافه کن";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteSharik
            // 
            this.btnDeleteSharik.Enabled = false;
            this.btnDeleteSharik.Location = new System.Drawing.Point(514, 167);
            this.btnDeleteSharik.Name = "btnDeleteSharik";
            this.btnDeleteSharik.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSharik.TabIndex = 17;
            this.btnDeleteSharik.Text = "حذف";
            this.btnDeleteSharik.UseVisualStyleBackColor = true;
            this.btnDeleteSharik.Click += new System.EventHandler(this.btnDeleteSharik_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(751, 242);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "کل سود ماه :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_sood_mah
            // 
            this.lbl_sood_mah.AutoSize = true;
            this.lbl_sood_mah.Location = new System.Drawing.Point(671, 242);
            this.lbl_sood_mah.Name = "lbl_sood_mah";
            this.lbl_sood_mah.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_sood_mah.Size = new System.Drawing.Size(25, 13);
            this.lbl_sood_mah.TabIndex = 19;
            this.lbl_sood_mah.Text = "123";
            this.lbl_sood_mah.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(751, 270);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "کل سود سال :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_sood_sal
            // 
            this.lbl_sood_sal.AutoSize = true;
            this.lbl_sood_sal.Location = new System.Drawing.Point(671, 270);
            this.lbl_sood_sal.Name = "lbl_sood_sal";
            this.lbl_sood_sal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_sood_sal.Size = new System.Drawing.Size(25, 13);
            this.lbl_sood_sal.TabIndex = 21;
            this.lbl_sood_sal.Text = "456";
            this.lbl_sood_sal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(38, 280);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 22;
            this.close.Text = "بستن";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // lblKoleSahm
            // 
            this.lblKoleSahm.AutoSize = true;
            this.lblKoleSahm.Location = new System.Drawing.Point(668, 24);
            this.lblKoleSahm.Name = "lblKoleSahm";
            this.lblKoleSahm.Size = new System.Drawing.Size(35, 13);
            this.lblKoleSahm.TabIndex = 23;
            this.lblKoleSahm.Text = "label3";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(514, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(514, 251);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "ذخیره";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmSharik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 315);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblKoleSahm);
            this.Controls.Add(this.close);
            this.Controls.Add(this.lbl_sood_sal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_sood_mah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteSharik);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblShomaresahamDar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtShare);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnEditData);
            this.Controls.Add(this.dGVSharik);
            this.Controls.Add(this.label1);
            this.Name = "frmSharik";
            this.Text = "frmSharik";
            ((System.ComponentModel.ISupportInitialize)(this.dGVSharik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGVSharik;
        private System.Windows.Forms.Button btnEditData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShare;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblShomaresahamDar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeleteSharik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_sood_mah;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_sood_sal;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label lblKoleSahm;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_name_family;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_sahm;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_sood_mah;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_sood_sal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}