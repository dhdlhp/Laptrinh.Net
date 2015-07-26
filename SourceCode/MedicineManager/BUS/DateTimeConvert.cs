using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.BUS
{
    class DateTimeConvert
    {
        public DateTimeConvert()
        {  
        }

        public static string FormatVN(DateTime dateTime)
        {
            string returnedString = dateTime.ToString();
            returnedString = returnedString.Replace("N/A", "00/00/0000").Trim();
            DateTime dt = Convert.ToDateTime(returnedString);
            returnedString = dt.ToString("dd/MM/yyyy");
            return returnedString;
        }

        public static string FormatVN(DateTime dateTime, string Format)
        {
            string returnedString = dateTime.ToString();
            returnedString = returnedString.Replace("N/A", "00/00/0000").Trim();
            DateTime dt = Convert.ToDateTime(returnedString);
            returnedString = dt.ToString(Format);
            return returnedString;
        }

        public static string FormatVN(string dateTime)
        {
            string returnedString = dateTime;
            returnedString = returnedString.Replace("N/A", "00/00/0000").Trim();
            DateTime dt = Convert.ToDateTime(returnedString);
            returnedString = dt.ToString("dd/MM/yyyy");
            return returnedString;
        }
    }
}
