using BankSystem2;
using NUnit.Framework;

namespace BankSystemTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            BankSystem2.SetUpBank.listOfUsers.Add(new User { Username = "testUsername", Password = "testPassword" });
        }

        [Test]
        [TestCase("username1", "password1")]
        public void Test_VerifyUserCredentials_Success(string username, string password)
        {
            var actual = BankSystem2.SetUpBank.VerifyUser(username, password);
            Assert.IsTrue(actual);
        }
        [Test]
        [TestCase("username", "password")]
        [TestCase("1", "1")]
        [TestCase("användarnamn1", "lösenord")]
        [TestCase("användarnamn", "lösenord1")]
        [TestCase(null, null)]
        public void Test_VerifyUserCredentials_Fail(string username, string password)
        {
            var actual = BankSystem2.SetUpBank.VerifyUser(username, password);
            Assert.IsFalse(actual);
        }

        [Test]
        [TestCase("admin1", "admin1234")]
        [TestCase("testUsername", "testPassword")]
        public void Test_Login_Success(string username, string password)
        {
            var account = SetUpBank.CanAccountLogIn(username, password);
            Assert.IsNotNull(account);

        }

        [Test]
        [TestCase("notExistingAccount", "notExistingAccount")]
        [TestCase(null, null)]
        public void Test_Login_Fail(string username, string password)
        {
            var account = SetUpBank.CanAccountLogIn(username, password);
            Assert.IsNull(account);

        }

        [Test]
        [TestCase("admin1", "admin1234")]
        public void Test_IsAccountAdmin_Success(string username, string password)
        {
            var account = SetUpBank.CanAccountLogIn(username, password);
            var isAccountAdmin = SetUpBank.IsAccountAdmin(account);
            Assert.IsTrue(isAccountAdmin);

        }

        [Test]
        [TestCase("testUsername", "testPassword")]
        [TestCase(null, null)]
        public void Test_IsAccountAdmin_Fail(string username, string password)
        {
            var account = SetUpBank.CanAccountLogIn(username, password);
            var isAccountAdmin = SetUpBank.IsAccountAdmin(account);
            Assert.IsFalse(isAccountAdmin);

        }
    }
}