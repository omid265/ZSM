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

    public class LogMGR
    {
        Generals GS =Generals.CreateGenerals();


        private int isert_data(string user_id, string description, string Log_type)
        {

             if (user_id != "" && description !="" && Log_type !="" )
            {
                MySqlConnection msc = new MySqlConnection(GS.db.ConnectionString);
                MySqlCommand msCommand = new MySqlCommand();
                msCommand.Connection = msc;


                try
                {
                    msc.Open();

                        msCommand.CommandText = "INSERT INTO `LogSystem` (`userid`,`description`,`Logtype`,`logdate`,`logtime`) " +
                        "VALUES ('" + user_id + "','" + description + "','" + Log_type + "','" + GS.dateManager.GetCurrentPersianDate() +  "','" + GS.dateManager.GetCurrentTime() + "')";
                        MySqlDataReader msdr = msCommand.ExecuteReader();
                        msc.Close();
                    return 1;

                }
                catch (Exception er)
                {
                    msc.Close();
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
            read_db = GS.db.Query("SELECT * FROM `LogSystem` where " + query);
        }
        /// <summary>
        /// search on input value
        /// return an DataTable [`userid`,`description`,`Logtype`,`logdate`,`logtime`]
        /// </summary>
        /// <returns></returns>
        public DataTable read_log(string query)
        {
            read_data(query);
            return read_db; 
        }
        /// <summary>
        /// if done return 1 else return 0
        /// </summary>
        /// <param name="user_id">operator user</param>
        /// <param name="description">log description</param>
        /// <param name="Log_type">type of log</param>
        /// <returns></returns>
        public int add_to_log(string user_id, string description, string Log_type)
        {
            return isert_data( user_id,  description,  Log_type);
        }
    }
}
