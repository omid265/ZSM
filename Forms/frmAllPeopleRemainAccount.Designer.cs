namespace ManoloSellManager.Forms
{
    partial class frmAllPeopleRemainAccount
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.peoplewithremainaccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.peopleWithRemainAccount = new ManoloSellManager.PeopleWithRemainAccount();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.peoplewithremainaccountTableAdapter = new ManoloSellManager.PeopleWithRemainAccountTableAdapters.peoplewithremainaccountTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.peoplewithremainaccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleWithRemainAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // peoplewithremainaccountBindingSource
            // 
            this.peoplewithremainaccountBindingSource.DataMember = "peoplewithremainaccount";
            this.peoplewithremainaccountBindingSource.DataSource = this.peopleWithRemainAccount;
            // 
            // peopleWithRemainAccount
            // 
            this.peopleWithRemainAccount.DataSetName = "PeopleWithRemainAccount";
            this.peopleWithRemainAccount.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DSPeopleWithRemainaccount";
            reportDataSource1.Value = this.peoplewithremainaccountBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ManoloSellManager.reports.PeopleWithRemainAccount.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(698, 430);
            this.reportViewer1.TabIndex = 0;
            // 
            // peoplewithremainaccountTableAdapter
            // 
            this.peoplewithremainaccountTableAdapter.ClearBeforeFill = true;
            // 
            // frmAllPeopleRemainAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 454);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmAllPeopleRemainAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست بدهکارها";
            this.Load += new System.EventHandler(this.ReportTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.peoplewithremainaccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleWithRemainAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private PeopleWithRemainAccount peopleWithRemainAccount;
        private System.Windows.Forms.BindingSource peoplewithremainaccountBindingSource;
        private PeopleWithRemainAccountTableAdapters.peoplewithremainaccountTableAdapter peoplewithremainaccountTableAdapter;
    }
}