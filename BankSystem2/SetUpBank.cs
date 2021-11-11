using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
    class SetUpBank
    {
        public static List<Account> listOfUsers = new List<Account> { new Admin() };

        public static void LogIn()
        {
            bool logInSuccesful = false;
            do
            {
                Console.WriteLine("\n Login");
                Console.Write("Enter Username : ");
                var username = Console.ReadLine();
                Console.WriteLine("Enter Password : ");
                var password = Console.ReadLine();

                var user = listOfUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    HandleUser(user);
                }
            } while (!logInSuccesful);
        }

        private static void HandleUser(Account logedInAccount)
        {
            if (logedInAccount is Admin)
            {
                var admin = logedInAccount as Admin;
               
            }


        }
    }
}
