using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENU.EJM.Core.Converter
{
    public static class DateConevrter
    {
        private static string _dateInString;

        /// <summary>
        /// Acccept Datetime in "DD/MM/YYYY HH:MM"
        /// </summary>
        /// <param name="_datetime"></param>
        /// <returns></returns>
        public static DateTime StringToDatetime(string _datetime)
        {
            DateTime dt = DateTime.Now;


            return dt;
        }
    }
}
