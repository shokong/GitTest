using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCard.Helpers
{
    public class BaseValidation : IBaseValidation
    {
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
    }

    public interface IBaseValidation
    {
        bool IsCardNumberValid(string cardNumber, int fixLength = 16);
    }
}