using System;
using Moq;
using NUnit.Framework;

using Account;


namespace AccountTest
{
    public class Tests
    {
        [SetUp]
        public void Setup() { }

        /*
         *  Hi eVision devs :)
         *  
         *  Thanks for reviewing the code.
         *  
         *  I wrote a test for the RefreshAmount() using Moq for mocking the service. 
         *  
         *  It is hard not to test implementation details of the class, because AccountInfo class has mutable state 'Amount'.
         *  Generally I prefer immutable objects, as it simplifies testing and reduces complexity. I think, problem #2 is about that.
         *  
         */


        [Test]
        public void RefreshAmountShouldReturnCorrectValue()
        {
            // arrange
            int accountId = 11;

            var mock = new Mock<IAccountService>();
            mock.Setup(x => x.GetAccountAmount(It.IsAny<int>())).Returns(5000);

            // act
            AccountInfo accountInfo = new AccountInfo(accountId, mock.Object);
            accountInfo.RefreshAmount();

            // assert
            mock.Verify(x => x.GetAccountAmount(accountId));
            Assert.AreEqual(5000, accountInfo.Amount);
        }

        [Test]
        public void RefreshAmountShouldThrowIfAccountServiceFails()
        {
            // arrange
            int accountId = 11;

            var mock = new Mock<IAccountService>();
            mock.Setup(x => x.GetAccountAmount(It.IsAny<int>())).Throws(new Exception("service exception"));

            // act
            AccountInfo accountInfo = new AccountInfo(accountId, mock.Object);

            // assert
            var exception = Assert.Throws<Exception>(() => accountInfo.RefreshAmount());
            Assert.AreEqual("service exception", exception.Message);
        }
    }
}