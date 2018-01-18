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

        [Test]
        [TestCase("4234567890123456", "012018")]
        [TestCase("4234567890123456", "012017")]
        public void VerifyCreditCard_ReturnVisaCard_ResultFalse(string cardNumber, string expiryDate)
        {
            var controller = new CreditCardController();
            var result = controller.Validation(new CreditCardInfo { CardNumber = cardNumber, ExpiryDate = expiryDate });
            Assert.IsFalse(result.Result);
            Assert.AreEqual("Visa", result.CardType);
        }

        [Test]
        [TestCase("4234567890123456", "012020")]
        public void VerifyCreditCard_ReturnVisaCard_ResultTrue(string cardNumber, string expiryDate)
        {
            var controller = new CreditCardController();
            var result = controller.Validation(new CreditCardInfo { CardNumber = cardNumber, ExpiryDate = expiryDate });
            Assert.IsTrue(result.Result);
            Assert.AreEqual("Visa", result.CardType);
        }

        [Test]
        [TestCase("5234567890123456", "012020")]
        public void VerifyCreditCard_ReturnMasterCard_ResultFalse(string cardNumber, string expiryDate)
        {
            var controller = new CreditCardController();
            var result = controller.Validation(new CreditCardInfo { CardNumber = cardNumber, ExpiryDate = expiryDate });
            Assert.IsFalse(result.Result);
            Assert.AreEqual("MasterCard", result.CardType);
        }

        [Test]
        [TestCase("5234567890123456", "012221")]
        public void VerifyCreditCard_ReturnMasterCard_ResultTrue(string cardNumber, string expiryDate)
        {
            var controller = new CreditCardController();
            var result = controller.Validation(new CreditCardInfo { CardNumber = cardNumber, ExpiryDate = expiryDate });
            Assert.IsTrue(result.Result);
            Assert.AreEqual("MasterCard", result.CardType);
        }
    }
}
