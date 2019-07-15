using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Generals.controls
{
    /// <summary>
    /// Manage and returned the date to Persian date
    /// </summary>
    public partial class PersianDatePicker : UserControl
    {
        PersianCalendar pc = new PersianCalendar();
        DateTime CurrentDate = DateTime.Now;

        public PersianDatePicker()
        {
            InitializeComponent();
        }

        private void PersianDatePiker_Load(object sender, EventArgs e)
        {
            
            
            int currentYear=pc.GetYear(CurrentDate);
            int currentMonth=pc.GetMonth(CurrentDate);
            int currentDay=pc.GetDayOfMonth(CurrentDate);

            cboMonth.Items.Clear();
            
            cboYears.Items.Clear();
            //////////////////////////////////////////////////////////////////////////////////////
            for (var i = pc.GetYear(CurrentDate)-10; i < currentYear; i++)
            {
                cboYears.Items.Add(i);
            }

            for (var i = pc.GetYear(CurrentDate); i < currentYear + 10; i++)
            {
                cboYears.Items.Add(i);
            }

            cboYears.Text = pc.GetYear(CurrentDate).ToString();

            //////////////////////////////////////////////////////////////////////////////////////

            var monthName = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

            for (var i = 0; i < 12; i++)
            {
                cboMonth.Items.Add(monthName[i]);
            }
            var dayNO = 1;
            cboMonth.Text=monthName[pc.GetMonth(CurrentDate)-1].ToString();

            foreach(Control lblDayList in flpDayList.Controls){
                if (lblDayList is Label)
                {
                    lblDayList.Text = dayNO.ToString();
                    if (pc.GetDayOfMonth(CurrentDate).ToString() == lblDayList.Text)
                        lblDayList.BackColor = ColorTranslator.FromHtml("#f78686");
                    dayNO++;
                }
            }


            string CM = pc.GetMonth(CurrentDate).ToString();
            string CD = pc.GetDayOfMonth(CurrentDate).ToString();
            if (CM.Length < 2)
                CM = "0" + CM;

            if (CD.Length < 2)
                CD = "0" + CD;


            PinTo.Text=pc.GetYear(CurrentDate)+"/"+CM+"/"+CD;
            this.Hide();
        }

        private void lblDay_Click(object sender, EventArgs e)
        {
            foreach (Control allDay in flpDayList.Controls)
            {
                if (allDay is Label)
                    allDay.BackColor = SystemColors.Control;
            }

            Control lblSelectedDay=new Control();

            ((Label)sender).BackColor = ColorTranslator.FromHtml("#f78686");
            lblSelectedDay.Text=((Label)sender).Text;

            if ((cboYears.Text != "") && (cboMonth.Text != ""))
            {
                string SD=lblSelectedDay.Text;
                if (SD.Length < 2)
                    SD = "0" + SD;

                string SM = (cboMonth.SelectedIndex + 1).ToString();
                if (SM.Length < 2)
                    SM = "0" + SM;
                lblChosedDate.Text = cboYears.Text + "/" +SM+ "/" + SD;
            }
            else
                MessageBox.Show("لطفا سال و ماه را انتخاب نمایید");
            this.pinTo();
        }

        /// <summary>
        /// Set controls to show Selected Date
        /// </summary>
        public Control PinTo { get; set; }
        /// <summary>
        /// تاریخ انتخاب شده را در کنترل که به این تابع پاس دادی میزاره 
        /// </summary>
        public void pinTo(){
            this.PinTo.Text=lblChosedDate.Text;
        }

        /// <summary>
        /// close the datepicker controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lblChosedDate.Text == "label1")
            {
                PinTo.Text = this.GetDate();
            }
            else
            {
                pinTo();
            }
            this.Hide();
        }
        public void ShowDatePicker()
        {
            this.Left = PinTo.Left;
            this.Top = PinTo.Top + PinTo.Height;
            this.BringToFront();
            this.Show();
        }
        /// <summary>
        /// Return Current date, this kind is String
        /// </summary>
        /// <returns></returns>
        public string GetDate()
        {
            string currentYear=pc.GetYear(CurrentDate).ToString();
            string currentMonth=pc.GetMonth(CurrentDate).ToString();
            string currentDay=pc.GetDayOfMonth(CurrentDate).ToString();

            
            if (currentMonth.Length < 2)
                currentMonth= "0" + currentMonth;

            if (currentDay.Length < 2)
                currentDay = "0" + currentDay;


            return currentYear + "/" + currentMonth + "/" + currentDay;
        }
        private void lblDay_DoubleClick(object sender, EventArgs e)
        {
            btnSelect_Click(sender,e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
