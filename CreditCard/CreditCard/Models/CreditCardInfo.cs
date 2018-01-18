using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCard.Models
{
    public class CreditCardInfo
    {
        /// <summary>
        /// Credit card number must be 16 digit
        /// </summary>
        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }
        /// <summary>
        /// Expiry date for credit card, the format must be MMYYYY
        /// </summary>
        [JsonProperty("expiryDate")]
        public string ExpiryDate { get; set; }
    }

    public class CreditCardVerificationResult
    {
        /// <summary>
        /// This field is to identify credit card type
        /// </summary>
        [JsonProperty("cardType")]
        public string CardType { get; set; }
        /// <summary>
        /// This field is showing result of credit card
        /// </summary>
        [JsonProperty("result")]
        public bool Result { get; set; }
    }

    /// <summary>
    /// Credit card type
    /// </summary>
    public enum CreditType
    {
        /// <summary>
        /// Credit card is unclassify
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Credit card is Visa type
        /// </summary>
        Visa = 1,
        /// <summary>
        /// Credit card is MasterCard type
        /// </summary>
        MasterCard = 2,
        /// <summary>
        /// Credit card is JCB type
        /// </summary>
        JCB = 3
    }
}