using System;

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