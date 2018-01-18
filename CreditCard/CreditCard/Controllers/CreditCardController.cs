using CreditCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CreditCard.Controllers
{
    public class CreditCardController : ApiController
    {
        /// <summary>
        /// POST: api/CreditCard/Validation to validate credit card type
        /// </summary>
        /// <param name="creditCardInfo">Information of credit card</param>
        /// <returns>Validation result of credit card</returns>
        [HttpPost]
        [ResponseType(typeof(CreditCardVerificationResult))]
        public CreditCardVerificationResult Validation([FromBody]CreditCardInfo creditCardInfo)
        {
            return new CreditCardVerificationResult { Result = false, CardType = CreditType.Unknown.ToString() };
        }
    }
}
