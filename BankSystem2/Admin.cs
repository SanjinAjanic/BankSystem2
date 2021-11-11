using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
    class Admin : Account
    {
        public Admin()
        {
            Username = "admin1";
            Password = "admin1234";
            Role = "Admin";
            Salary = 55000;
        }
        public void SeeAllUsers(List<Account> listOfUsers)
        {
            foreach (var user in listOfUsers)
            {
                Console.WriteLine($"{user.Username} | {user.Password}");
            }
        }
    }
}
