using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

using Account;


namespace AccountTest
{
    public class AccountInfoTest
    {
        [SetUp]
        public void Setup() { }

        /*
         * 
         * I renamed RefreshAmount() to GetAccountAmountAsync() so the name reflects new behaviour and refactored into async.
         * 
         * The problem #2 does not specify requirements to deal with slow and unreliable network, therefore I did not add any extra code for error management, retries or caching.
         * 
         */

        [Test]
        public async Task GetAccountAmountAsync_ShouldReturnSuccess()
        {
            // arrange
            int accountId = 11;

            var mock = new Mock<IAccountService>();
            mock.Setup(x => x.GetAccountAmountAsync(It.IsAny<int>() )).Returns(Task.FromResult(new AccountAmount(true, 5999.99)));


            // act
            var accountInfo = new AccountInfo(mock.Object);
            var result = await accountInfo.GetAccountAmountAsync(accountId);

            // assert
            mock.Verify(x => x.GetAccountAmountAsync(accountId));
            Assert.AreEqual(true, result.Success);
            Assert.AreEqual(5999.99, result.Amount);
        }

        [Test]
        public async Task GetAccountAmountAsync_ShouldReturnFailure()
        {
            // arrange
            int accountId = 11;

            var mock = new Mock<IAccountService>();
            mock.Setup(x => x.GetAccountAmountAsync(It.IsAny<int>())).Returns(Task.FromResult(new AccountAmount(false, 0)));

            // act
            AccountInfo accountInfo = new AccountInfo(mock.Object);
            var result = await accountInfo.GetAccountAmountAsync(accountId);
            // assert

            Assert.AreEqual(false, result.Success);
            Assert.AreEqual(0, result.Amount);


        }
    }
}