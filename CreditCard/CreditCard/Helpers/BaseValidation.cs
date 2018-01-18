using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CreditCard.Helpers
{
    public class BaseValidation : IBaseValidation
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public bool IsCardNumberValid(string cardNumber, int fixLength = 16)
        {
            try
            {
                if (fixLength != cardNumber.Length)
                    return false;

                foreach (char c in cardNumber)
                {
                    if (!Char.IsDigit(c))
                        return false;
                }

                return true;

            }
            catch
            {
                return false;
            }
        }

        public virtual bool IsCardExpiry(string expiryDate)
        {
            return false;
        }

        protected bool IsExpiryDateValid(string expiryDate)
        {
            if (Regex.Match(expiryDate, @"^\d{2}\d{4}$").Success)
            {
                string month = expiryDate.Substring(0, 2);
                string year = expiryDate.Substring(2, 4);
                string[] currentDate = Regex.Split(DateTime.Now.ToString("MM/yyyy"), "/");
                int compareYears = string.Compare(year, currentDate[1]);
                int compareMonths = string.Compare(month, currentDate[0]);

                if (Regex.Match(month, @"^[0][1-9]|[1][0-2]$").Success)
                {
                    if ((compareYears == 1) || (compareYears == 0 && (compareMonths >= 0)))
                    {
                        Month = Convert.ToInt32(month);
                        Year = Convert.ToInt32(year);

                        return true;
                    }
                }
            }
            return false;
        }
    }

    public interface IBaseValidation
    {
        bool IsCardNumberValid(string cardNumber, int fixLength = 16);
    }
}