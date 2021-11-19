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
            BankSystem2.SetUpBank.listOfUsers.Add(new User { Username = "testUsername", Password = "testPassword" });
        }
       
        [Test]
        [TestCase("admin1", "admin1234")]
        public void IntegrationTest_AdminLoginAndDeleteUser(string adminUsername, string adminPassword)
        {
            var account = SetUpBank.CanAccountLogIn(adminUsername, adminPassword);
            var isAccountAdmin = SetUpBank.IsAccountAdmin(account);
            var admin = account as Admin;
            admin.RemoveUserFromList("testUsername", "testPassword");
            var isAccountRemoved = SetUpBank.IsAccountRemovedFromList("testUsername", "testPassword");

            Assert.IsTrue(isAccountAdmin);
            Assert.IsTrue(isAccountRemoved);

        }
        [Test]
        [TestCase("testUsername", "testPassword")]
        public void IntegrationTest_UserLoginAndDeleteSelf(string usernameToDelete, string passwordToDelete)
        {
            var account = SetUpBank.CanAccountLogIn(usernameToDelete, passwordToDelete);
            var user = account as User;
            user.RemoveSelfFromList(usernameToDelete, passwordToDelete);
            var isAccountRemoved = SetUpBank.IsAccountRemovedFromList(usernameToDelete, passwordToDelete);

            Assert.IsNotNull(user);
            Assert.IsTrue(isAccountRemoved);

        }

    }
}
