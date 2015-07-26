using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MedicineManager.BUS
{
    class ValidateFrom
    {
        public ValidateFrom()
        { }

        public static bool CheckNumber(string str)
        {
            Regex re = new Regex("[0-9]");
            if (re.IsMatch(str) && str.Length > 0)
                return true;
            else
                return false;
        }

        public static bool CheckName(string str)
        {
            Regex re = new Regex(@"^[a-zA-Z]");
            if (re.IsMatch(str))
                return true;
            else
                return false;
        }

        public static bool CheckEmty(string str)
        {
            Regex re = new Regex("[^ ]");
            if (re.IsMatch(str))
                return true;
            else
                return false;
        }

        public static bool CheckPhoneNumber(string str)
        {
            Regex re = new Regex(@"^\(\d{3}\) \d{4}-\d{4}$");
            if (re.IsMatch(str))
                return true;
            else
                return false;
        }

        public static bool CheckEmail(string str)
        {
            Regex re = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (re.IsMatch(str))
                return true;
            else
                return false;
        }
    }
}
