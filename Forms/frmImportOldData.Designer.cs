namespace ManoloSellManager.Forms
{
    partial class frmImportOldData
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
            this.btnImportStore = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnImportPersonals = new System.Windows.Forms.Button();
            this.btnImportPersonalRemainAccount = new System.Windows.Forms.Button();
            this.RepairClientType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportStore
            // 
            this.btnImportStore.Location = new System.Drawing.Point(564, 324);
            this.btnImportStore.Name = "btnImportStore";
            this.btnImportStore.Size = new System.Drawing.Size(75, 23);
            this.btnImportStore.TabIndex = 0;
            this.btnImportStore.Text = "ImportStore";
            this.btnImportStore.UseVisualStyleBackColor = true;
            this.btnImportStore.Click += new System.EventHandler(this.btnImportStore_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "access file (*.mdb)|*.mdb";
            // 
            // btnImportPersonals
            // 
            this.btnImportPersonals.Location = new System.Drawing.Point(406, 324);
            this.btnImportPersonals.Name = "btnImportPersonals";
            this.btnImportPersonals.Size = new System.Drawing.Size(131, 23);
            this.btnImportPersonals.TabIndex = 0;
            this.btnImportPersonals.Text = "Import Personals";
            this.btnImportPersonals.UseVisualStyleBackColor = true;
            this.btnImportPersonals.Click += new System.EventHandler(this.btnImportPersonals_Click);
            // 
            // btnImportPersonalRemainAccount
            // 
            this.btnImportPersonalRemainAccount.Location = new System.Drawing.Point(192, 324);
            this.btnImportPersonalRemainAccount.Name = "btnImportPersonalRemainAccount";
            this.btnImportPersonalRemainAccount.Size = new System.Drawing.Size(196, 23);
            this.btnImportPersonalRemainAccount.TabIndex = 0;
            this.btnImportPersonalRemainAccount.Text = "Import Personals RemainAccount";
            this.btnImportPersonalRemainAccount.UseVisualStyleBackColor = true;
            this.btnImportPersonalRemainAccount.Click += new System.EventHandler(this.btnImportPersonalRemainAccount_Click);
            // 
            // RepairClientType
            // 
            this.RepairClientType.Location = new System.Drawing.Point(505, 283);
            this.RepairClientType.Name = "RepairClientType";
            this.RepairClientType.Size = new System.Drawing.Size(134, 23);
            this.RepairClientType.TabIndex = 5;
            this.RepairClientType.Text = "&Repair Client Type";
            this.RepairClientType.UseVisualStyleBackColor = true;
            // 
            // frmImportOldData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 359);
            this.Controls.Add(this.RepairClientType);
            this.Controls.Add(this.btnImportPersonalRemainAccount);
            this.Controls.Add(this.btnImportPersonals);
            this.Controls.Add(this.btnImportStore);
            this.Name = "frmImportOldData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImportOldData";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportStore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnImportPersonals;
        private System.Windows.Forms.Button btnImportPersonalRemainAccount;
        private System.Windows.Forms.Button RepairClientType;
    }
}