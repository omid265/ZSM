using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseManager;

namespace CalculationProductUnit
{
    public class Formulas
    {

        DB db = DB.CreateDBManager();

        /// <summary>
        /// Add new formula in to the formula Database
        /// </summary>
        public void Add()
        {
            db.Query("");
        }
    }
}
