using BankSystem2;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemTestProject
{
    class IntegrationTest
    {
        public void Test()
        {
            User testUser = new User { Username = "testUser1", Password = "testUser1", Role = "Städare", Salary = 1000 };
            BankSystem2.SetUpBank.listOfUsers.Add(testUser);

        }
        [Test]

        public void Test_SalaryCheck_ShowSalary()
        {

            var testUser = new User { Salary = 1000 };
            var salary = testUser.Salary;

            var expected = 1000;
            var actual = salary;

            Assert.AreEqual(actual, expected);
        }
        //public void Test_SalaryCheck_ShowSalary()
        //{
        //    var testUser = new User { Salary = -1 };
        //    var salary = testUser.Salary;

        //    var expected = 1000;
        //    var actual = salary;

        //    Assert.AreEqual(actual, expected);
        //}
        [Test]
        public void Test_Login()
        {
            string username = "kalle1";
            string password = "kalle1234";
            User user = new User { Username = "kalle1", Password = "kalle1234" };
            SetUpBank.listOfUsers.Add(user);
            var account = SetUpBank.CanAccountLogIn(username, password);
            var actual = SetUpBank.IsAccountAdmin(account);

            Assert.IsTrue(actual);
        }
    }
}
