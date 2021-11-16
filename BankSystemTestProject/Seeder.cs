using BankSystem2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemTestProject
{
    public static class Seeder
    {
        public static List<Account> FillListWithAccounts()
        {
            Admin testAdmin = new Admin();
            User firstTestUser = new User { Username = "Kalle1", Password = "kalle1234", Role = "Städare", Salary = 10000 };
            User secondTestUser = new User { Username = "Kalle2", Password = "kalle1234", Role = "Vaktmästare", Salary = 12000 };
            User thirdTestUser = new User { Username = "Kalle3", Password = "kalle1234", Role = "Chef", Salary = 500000000 };

            var listOfTestAccounts = new List<Account>() { firstTestUser, secondTestUser, thirdTestUser };
            return listOfTestAccounts;

        }
    }
}
