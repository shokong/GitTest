using NUnit.Framework;
using CreditCard.Controllers;
using CreditCard.Models;

namespace CreditCard.Tests
{
    [TestFixture]
    public class CreditCardControllerTest
    {
        [Test]
        [TestCase("", "")]
        [TestCase("Test", "012018")]
        [TestCase("12345678", "012018")]
        [TestCase("123456789123456789", "012018")]
        [TestCase("1234567890123456", "012018")]
        public void VerifyCreditCard_ReturnUnknown_InvalidCardNumber(string cardNumber, string expiryDate)
        {
            var controller = new CreditCardController();
            var result = controller.Validation(new CreditCardInfo { CardNumber = cardNumber, ExpiryDate = expiryDate });
            Assert.IsFalse(result.Result);
            Assert.AreEqual("Unknown", result.CardType);
        }
    }
}
