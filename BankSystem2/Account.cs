using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
    public abstract class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }

        public void ShowSalary()
        {
            Console.WriteLine($"{Salary}");
        }
        public void ShowRole()
        {
            Console.WriteLine($"{Role}");
        }
    }
}
