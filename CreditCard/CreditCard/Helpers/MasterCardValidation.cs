namespace CreditCard.Helpers
{
    public class MasterCardValidation : BaseValidation, IMasterCardValidation
    {
        public override bool IsCardExpiry(string expiryDate)
        {
            if (base.IsExpiryDateValid(expiryDate))
            {
                var year = base.Year;
                if ((year & 1) == 0)
                {
                    if (year == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                for (int i = 3; (i * i) <= year; i += 2)
                {
                    if ((year % i) == 0)
                    {
                        return false;
                    }
                }
                return year != 1;
            }
            else
                return false;
        }
    }

    public interface IMasterCardValidation
    {
        bool IsCardExpiry(string expiryDate);
    }
}