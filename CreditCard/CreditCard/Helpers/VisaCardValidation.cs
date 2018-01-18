using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCard.Helpers
{
    public class VisaCardValidation : BaseValidation, IVisaCardValidation
    {
        public override bool IsCardExpiry(string expiryDate)
        {
            if (base.IsExpiryDateValid(expiryDate) && DateTime.IsLeapYear(base.Year))
                return true;
            return false;
        }
    }

    public interface IVisaCardValidation
    {
        bool IsCardExpiry(string expiryDate);
    }
}