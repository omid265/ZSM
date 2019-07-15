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


using ManoloSellManager.Class;
using Generals;

namespace ManoloSellManager.Class
{
    class chek
    {
        Generals GS = Generals.CreateGenerals();
        string DBName = "`" + ConfigFile.GetConfig().DatabaseConfig().DatabaseName + "`.";
        private int isert_data(int CustumerNo,string t_saresid,string t_sodor,string dar_vajhe,Double mablagh,string saheb_hesab,string serail_chek,string bank, Boolean chType)
        {

            if (CustumerNo != 0 && t_saresid != "" &&  t_sodor != "" &&  dar_vajhe != "" &&  mablagh != 0 &&  saheb_hesab != "" &&  serail_chek != "" &&  bank != "" )
            {
                MySqlConnection msc = new MySqlConnection(GS.db.ConnectionString);
                MySqlCommand msCommand = new MySqlCommand();
                msCommand.Connection = msc;

                try
                {

                    DataTable VC = new DataTable();///// VC= Validate Check 
                    VC = GS.db.Query("SELECT * FROM " + DBName + "`chek` WHERE `serail_chek`='" + serail_chek+"'");
                    if (VC != null && VC.Rows.Count == 0)
                    {
                        
                            msc.Open();
                            // MessageBox.Show(t_saresid);
                            msCommand.CommandText = "INSERT INTO "+ DBName +"`chek` (`CustumerNo`,`t_saresid`,`t_sodor`,`dar_vajhe`,`mablagh`,`saheb_hesab`,`serail_chek`,`bank`,`typeCheck`) " +
                            "VALUES ('" + CustumerNo + "','" + t_saresid + "','" + t_sodor + "','" + dar_vajhe + "','" + mablagh + "','" + saheb_hesab + "','" + serail_chek + "','" + bank + "'," + chType + ")";
                            MySqlDataReader msdr = msCommand.ExecuteReader();
                            msc.Close();
                            return 1;////// insert data is success;
                        
                    }
                    else
                    {
                        return 2;////// check with this serial is exist;
                    }

                    

                }
                catch (Exception er)
                {
                    msc.Close();
                     MessageBox.Show("OM"+er.Message);
                    return 0;////// insert data to database is failde;
                }
                finally
                {
                    msc.Close();
                }
            }
            else
            {
                return 0;////// insert data is failde;
            }
        }
        private DataTable read_db = new DataTable();
        private void read_data(string query)
        {
            if (query != "" )
            {
                
            try
            {
                read_db = GS.db.Query("SELECT * FROM " + DBName + "`chek` " + query);
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
                MessageBox.Show("اطلاعات کامل وارد نشده - خواندن از جدول چک");
            }
            
        }

        private int delet_data(int chek_id)
        {
            if (chek_id != null )
            {
                
            try
            {
               GS.db.Query("DELETE FROM " + DBName + "`chek` WHERE `id` ='" + chek_id +"'");
               // MessageBox.Show(GS.db.QueryMessage);
               return 1;///// Delete is success
            } 
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                    return 0;////// Delete is failde
                }
                finally
                {
                    
                }
            }
            else
            {
                MessageBox.Show("اطلاعات کامل وارد نشده - پاک کردن از جدول چک");
                return 0;////// Delete is failde
            }
        }
        private int delet_data(string chek_serial)
        {
            if (chek_serial != "" )
            {
                
            try
            {
               GS.db.Query("DELETE FROM " + DBName + "`chek` WHERE `serail_chek` ='" + chek_serial+"'");
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
                MessageBox.Show("اطلاعات کامل وارد نشده - پاک کردن از جدول چک");
                return 0;
            }  
        }
        private int edit_data(string query,string change)
        {
            if (query != "" && change != "")
            {

                try
                {
                    GS.db.Query("UPDATE `chek` SET "+change +" WHERE " + query);
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
                MessageBox.Show("اطلاعات کامل وارد نشده - تصحیح جدول چک");
                return 0;
            }
        }
        DataTable stat = new DataTable();
        private Boolean check_stat_read(int check_id)
        {
            if (check_id != null)
            {

                try
                {
                    stat = GS.db.Query("SELECT * FROM " + DBName + "`chek` WHERE `serail_chek` =  '" + check_id + "'");
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
                MessageBox.Show("اطلاعات کامل وارد نشده - خواندن حالت چک ");
            }

            return Convert.ToBoolean(stat.Rows[0][10]);
        }

        private void check_stat_change(int check_id)
        {
            if (check_id != null)
            {

                try
                {
                    stat = GS.db.Query("SELECT * FROM " + DBName + "`chek` WHERE `serail_chek` =  '" + check_id + "'");
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
                MessageBox.Show("اطلاعات کامل وارد نشده - خواندن حالت چک ");
            }
                if (Convert.ToBoolean(stat.Rows[0][10]))
                {
                    int a = edit_data("`serail_chek`= '" + check_id + "'" , "`status`= '0' ");
                    MessageBox.Show(a.ToString());
                }
                 else
                {
                    int a = edit_data("`serail_chek`= '" + check_id + "'", "`status`= '1' ");
                    MessageBox.Show(a.ToString());
                }


        }
        /// <summary>
        /// search on input value
        /// Query Sample=WHERE t_saresid='2014-15-10'
        /// </summary>
        /// <returns>return an DataTable [`userid`,`description`,`Logtype`,`logdate`,`logtime`]</returns>
        public DataTable read_chek(string query)
        {
            read_data(query);
            return read_db;
        }
        /// <summary>
        /// (string t_saresid, string t_sodor, string dar_vajhe, float mablagh,
        /// int saheb_hesab, string serail_chek, string bank)
        /// </summary>
        /// <param name="user_id">operator user</param>
        /// <param name="description">log description</param>
        /// <param name="Log_type">type of log</param>
        /// <returns></returns>
        public int add_to_chek(int CustumerNo,string t_saresid, string t_sodor, string dar_vajhe, Double mablagh, string saheb_hesab, string serail_chek, string bank, Boolean chType)
        {
            return isert_data(CustumerNo, t_saresid, t_sodor, dar_vajhe, mablagh, saheb_hesab, serail_chek, bank,chType);
        }
        /// <summary>
        /// if done returns 1
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="description"></param>
        /// <param name="Log_type"></param>
        /// <returns></returns>
        public int edit_chek(string query, string change)
        {
            return edit_data( query, change);
        }
        /// <summary>
        /// delet chek if done returns 1
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="description"></param>
        /// <param name="Log_type"></param>
        /// <returns></returns>
        public int delet_chek(string chek_serial)
        {
            return delet_data(chek_serial);
        }
        /// <summary>
        /// delet chek if done returns 1
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="description"></param>
        /// <param name="Log_type"></param>
        /// <returns></returns>
        public int delet_chek(int chek_id)
        {
            return delet_data(chek_id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chek_id"></param>
        /// <returns></returns>
        public Boolean check_status_read(int check_id)
        {
            return check_stat_read(check_id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chek_id"></param>
        public void check_status_change(int check_id)
        {
            check_stat_change(check_id);
        }
    }
}
