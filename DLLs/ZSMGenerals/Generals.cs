using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace ZSMGenerals
{
    class Generals
    {
        /// <summary>
        /// Persian Date Object
        /// </summary>


        string ConnectionStringOrginal = @"server=localhost;user id=root;database=accounting;allowuservariables=True;logging=False;persistsecurityinfo=True;Charset=utf8;";
        public PersianCalendar PC = new PersianCalendar();
        public DateTime CurrentDate = DateTime.Now;
        DataTable DTN = new DataTable();
        string QueryMessageInner = "";
        int QueryErrorCode = 0;

        public string InputValue;
        Form form = new Form();
        TextBox textBox = new TextBox();
        public string QueryMessage
        {
            get { return QueryMessageInner; }
        }
        public int QueryError
        {
            get { return QueryErrorCode; }
        }

        public string ConnectionString
        {
            get { return ConnectionStringOrginal; }
            set { ConnectionStringOrginal = value; }
        }
        /// <summary>
        /// Return persian date
        /// </summary>
        /// <returns></returns>
        public string GetCurrentDate(string DateSeperator = "/")
        {
            string CM = this.PC.GetMonth(this.CurrentDate).ToString();
            string CD = this.PC.GetDayOfMonth(this.CurrentDate).ToString();
            if (CM.Length < 2)
                CM = "0" + CM;

            if (CD.Length < 2)
                CD = "0" + CD;

            return this.PC.GetYear(this.CurrentDate) + DateSeperator + CM + DateSeperator + CD;
        }
        public string GetPersianDate(DateTime YourDate, string DateSeperator = "/")
        {
            string CM = this.PC.GetMonth(YourDate).ToString();
            string CD = this.PC.GetDayOfMonth(YourDate).ToString();
            if (CM.Length < 2)
                CM = "0" + CM;

            if (CD.Length < 2)
                CD = "0" + CD;

            return this.PC.GetYear(YourDate) + DateSeperator + CM + DateSeperator + CD;
        }


        /// <summary>
        /// Make Thousand separator for Number.
        /// this funtion return string
        /// </summary>
        /// <param name="numbers">Sample 1000000</param>
        /// <returns>sample: 1,000,000</returns>
        public string nf(string numbers)
        {
            NumberFormatInfo nfi = new CultureInfo("fa-IR", false).NumberFormat;
            nfi.NumberDecimalDigits = 0;
            // Displays a value with the default separator (".").
            double myInt;
            if (numbers.Length > 0)
                myInt = Convert.ToDouble(numbers);
            else
                myInt = 0;

            var PP = myInt.ToString("n", nfi);
            return PP.ToString();
            /*
            // Displays the same value with a blank as the separator.
            nfi.NumberDecimalSeparator = " ";
            return myInt.ToString("N", nfi);
              */
        }

        /// <summary>
        /// Run the query to database and return data to datatable
        /// </summary>
        /// <param name="Query">SELECT * FROM Table name WHERE filedName="Value"</param>
        /// <returns></returns>
        public DataTable Query(string Query, Boolean ShowMessageOnError = true)
        {
            //Query = "DELETE FROM `invoicedetails` WHERE `InvoiceNo`='" + txtOrderNo.Text + "'";

            MySqlConnection msc = new MySqlConnection(this.ConnectionString);
            MySqlDataAdapter da = new MySqlDataAdapter(Query, msc);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                QueryMessageInner = "success";
                QueryErrorCode = 0;
                DTN = dt;
                return dt;

            }
            catch (Exception er)
            {
                if (ShowMessageOnError == true)
                {
                    QueryMessageInner = "مشکلی به وجود آمده است" + " : " + er.Message;
                    MessageBox.Show(er.Message);
                }
                else
                {
                    QueryMessageInner = er.Message;
                }
                msc.Close();
                return null;

            }
            finally
            {
                msc.Close();
            }
        }
        /// <summary>
        /// Show input box for Give data from user
        /// </summary>
        /// <returns></returns>
        //public string Inputbox()
        //{
        //    try
        //    {
        //        frmInputBox Inputbox = new frmInputBox();

        //        return "";
        //    }
        //    catch (Exception Error)
        //    {
        //        return Error.Message;
        //    }
        //}
        public DialogResult InputBox(string title, string promptText, string value)
        {

            Label label = new Label();

            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "تائید";
            buttonCancel.Text = "انصراف";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 18, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            textBox.Dock = DockStyle.Bottom;
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonOk.Dock = DockStyle.Bottom;
            buttonCancel.SetBounds(309, 72, 75, 23);
            buttonCancel.Dock = DockStyle.Bottom;

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            buttonOk.Click += new EventHandler(inputButtonOk_click);

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;


            form.AcceptButton = buttonCancel;
            form.CancelButton = buttonCancel;

            form.RightToLeft = RightToLeft.Yes;
            form.RightToLeftLayout = true;

            DialogResult dialogResult = form.ShowDialog();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            value = textBox.Text;
            return dialogResult;
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Closed");
            form.Hide();
            form.Controls.Clear();
        }
        private void inputButtonOk_click(object sender, EventArgs e)
        {
            InputValue = textBox.Text;
        }

        /// <summary>
        /// writen by MORI   2014/10/14
        /// </summary>
        /// <returns></returns>
        public string GetCurrentTime()
        {
            return System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
        }
        /// <summary>
        /// asked from user a question, sample: do you wanat to delete this item?
        /// </summary>
        /// <returns></returns>
        public DialogResult Question(string title, string QuestionText)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
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

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonCancel;
            form.CancelButton = buttonCancel;
            form.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            form.RightToLeftLayout = true;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }///// End question Function

        public void Backup()
        {
            //////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////[ Start Backup System From here ]//////////////////
            //string constring = @"server=localhost;user id=root;database=accounting;allowuservariables=True;logging=False;persistsecurityinfo=True;Charset=utf8;";
            string backUpPath = Application.StartupPath;
            //string file = backUpPath + @"\backUP\" + this.PC.GetYear(DateTime.Now).ToString() + "\\" + this.PC.GetMonth(DateTime.Now).ToString() + "\\backup" + this.GetCurrentDate("-") + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + ".sql";
            string Min = DateTime.Now.TimeOfDay.Minutes.ToString();
            string ch = DateTime.Now.TimeOfDay.Hours.ToString();

            string file = backUpPath + @"\dbBackup\" + this.GetCurrentDate("-") + "-" + ch + "-" + Min + ".sql";
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
            //////////////////////////////[ Start Backup System From here ]//////////////////
            //////////////////////////////////////////////////////////////////////////////////

        }///// End backup Function

        public void Restore()
        {

            string file = "C:\\backup.sql";
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(file);
                        conn.Close();
                    }
                }
            }

        }//////// End Restore database function

    }
}
