using NUnit.Framework;

namespace BankSystemTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase("username", "password")]
        [TestCase("1", "1")]
        [TestCase("användarnamn1", "lösenord")]
        [TestCase("användarnamn", "lösenord1")]
        public void Test_VerifyUserFail(string username, string password)
        {
            var actual = BankSystem2.SetUpBank.VerifyUser(username, password);
            Assert.IsFalse(actual);
        }

        [Test]
        [TestCase("username1", "password1")]
       
        
        public void Test_VerifyUserSucces(string username, string password)
        {
            var actual = BankSystem2.SetUpBank.VerifyUser(username, password);
            Assert.IsTrue(actual);
        }
    }
}