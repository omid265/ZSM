using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using MySql.Data.MySqlClient;

namespace ManoloSellManager.Class
{
    class Sharik
    {
        Generals GS = Generals.CreateGenerals();

        private int isert_data(string Name_Family, Double Sahme)
        {

            if (Name_Family != "" && Sahme != 0 )
            {
                MySqlConnection msc = new MySqlConnection(GS.db.ConnectionString);
                MySqlCommand msCommand = new MySqlCommand();
                msCommand.Connection = msc;

                try
                {
                    msc.Open();
                    // MessageBox.Show(t_saresid);
                    msCommand.CommandText = "INSERT INTO `sharik` (`Name_Family`,`Sahme`) " +
                    "VALUES ('" + Name_Family + "','" + Sahme + "')";
                    MySqlDataReader msdr = msCommand.ExecuteReader();
                    msc.Close();
                    return 1;

                }
                catch (Exception er)
                {
                    msc.Close();
                    MessageBox.Show("OM" + er.Message);
                    return 0;
                }
                finally
                {
                    msc.Close();
                }
            }
            else
            {
                return 0;
            }
        }

        private DataTable read_db = new DataTable();
        private void read_data(string query)
        {
            if (query != "")
            {

                try
                {
                    read_db = GS.db.Query("SELECT * FROM `sharik` " + query);
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("اطلاعات کامل وارد نشده - خواندن از جدول شرکا");
            }

        }

        private int delet_data(string Name_Family)
        {
            if (Name_Family != "")
            {

                try
                {
                    GS.db.Query("DELETE FROM `sharik` WHERE `Name_Family` = '" + Name_Family + "'");
                    return 1;
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    return 0;
                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("اطلاعات کامل وارد نشده - پاک کردن از جدول شرکا");
                return 0;
            }
        }
        private int edit_data(string change, string query)
        {
            if (query != "" && change != "")
            {

                try
                {
                    GS.db.Query("UPDATE `sharik` SET " + change + query);
                    return 1;
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    return 0;
                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("اطلاعات کامل وارد نشده - تصحیح جدول شرکا");
                return 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name_Family"></param>
        /// <param name="Sahme"></param>
        /// <returns></returns>
        public int add_to_Sharik(string Name_Family, Double Sahme)
        {
            return isert_data(Name_Family,Sahme);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable read_Sharik(string query)
        {
            read_data(query);
            return read_db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="change"></param>
        /// <returns></returns>
        public int edit_sharik(string query, string change)
        {
            return edit_data(query, change);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="chek_serial"></param>
        /// <returns></returns>
        public int delet_sharik(string Name_Family)
        {
            return delet_data(Name_Family);
        }

    }
}
