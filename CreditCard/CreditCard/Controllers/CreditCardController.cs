using CreditCard.Helpers;
using CreditCard.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
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
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(CreditCardVerificationResult))]
        public CreditCardVerificationResult Validation([FromBody]CreditCardInfo creditCardInfo)
        {
            var cardType = CreditType.Unknown;
            var result = false;
            IBaseValidation bv = new BaseValidation();
            if (bv.IsCardNumberValid(creditCardInfo.CardNumber))
            {
                if (Regex.IsMatch(creditCardInfo.CardNumber, "^(4)"))
                {
                    cardType = CreditType.Visa;
                }
            }
           
            return new CreditCardVerificationResult { Result = result, CardType = cardType.ToString() };
        }
    }
}
