using BankSystem2;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemTestProject
{
    public class IntegrationTest
    {
        [SetUp]
        public void Setup()
        {
            BankSystem2.SetUpBank.listOfUsers.Add(new User { Username = "TestUsername1", Password = "TestPassword1" });
        }
        [Test]
        [TestCase("admin1", "admin1234")]
        [TestCase("TestUsername1", "TestPassword1")]
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
        [TestCase("TestUsername1", "TestPassword1")]
        [TestCase(null, null)]
        public void Test_IsAccountAdmin_Fail(string username, string password)
        {
            var account = SetUpBank.CanAccountLogIn(username, password);
            var isAccountAdmin = SetUpBank.IsAccountAdmin(account);
            Assert.IsFalse(isAccountAdmin);

        }
        [Test]
        [TestCase("TestUsername1", "TestPassword1")]
        public void Test_DeleteUserAsAdmin(string usernameToDelete, string passwordToDelete)
        {
            var account = SetUpBank.CanAccountLogIn("admin1", "admin1234");
            var admin = account as Admin;
            admin.RemoveUserFromList(usernameToDelete, passwordToDelete);
            var isAccountRemoved = SetUpBank.IsAccountRemovedFromList(usernameToDelete, passwordToDelete);
            Assert.IsTrue(isAccountRemoved);

        }
        [Test]
        [TestCase("TestUsername1", "TestPassword1")]
        public void Test_DeleteUserAsUser(string usernameToDelete, string passwordToDelete)
        {
            var account = SetUpBank.CanAccountLogIn(usernameToDelete, passwordToDelete);
            var user = account as User;
            user.RemoveSelfFromList(usernameToDelete, passwordToDelete);
            var isAccountRemoved = SetUpBank.IsAccountRemovedFromList(usernameToDelete, passwordToDelete);

            Assert.IsTrue(isAccountRemoved);

        }
    }
}
