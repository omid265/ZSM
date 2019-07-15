using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoloSellManager.Class
{
    class Sood
    {
        private int sood_sal = new int();
        private int sood_mah = new int();

        private void get_sood_mah_db()
        {

        }

        private void get_sood_sal_db()
        {

        }

        private int set_sood_mah_db(int sod_mah)
        {
            sood_mah = sod_mah;
            return 1;
        }

        private int set_sood_sal_db(int sod_sal)
        {
            sood_sal = sod_sal;
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sod_sal"></param>
        /// <returns></returns>
        public int set_sood_sal(int sod_sal)
        {
            return set_sood_sal_db(sod_sal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sod_sal"></param>
        /// <returns></returns>
        public int set_sood_mah(int sod_mah)
        {
            return set_sood_mah_db(sod_mah);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int get_sood_sal()
        {
            get_sood_sal_db();
            return sood_sal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int get_sood_mah()
        {
            get_sood_mah_db();
            return sood_mah;
        }
    }
}
