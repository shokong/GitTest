namespace CreditCard.Helpers
{
    public class JCBCardValidation : BaseValidation, IJCBCardValidation
    {
        public override bool IsCardExpiry(string expiryDate)
        {
            return base.IsExpiryDateValid(expiryDate);
        }
    }

    public interface IJCBCardValidation
    {
        bool IsCardExpiry(string expiryDate);
    }
}