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
                    logInSuccesful = true;
                    HandleUser(user);
                }
                Console.WriteLine("Login failed, try again!");
            } while (!logInSuccesful);
        }

        private static void HandleUser(Account logedInAccount)
        {
            if (logedInAccount is Admin)
            {
                var admin = logedInAccount as Admin;
                AdminMenu(admin);
            }
            else
            {
                UserMenu(logedInAccount);
            }



        }

        private static void UserMenu(Account logedInUser)
        {
            int choice = 0;
            bool parseSuccessfull = false;
            do
            {

                Console.WriteLine("USER MENU");
                Console.WriteLine("[1] See salary");
                Console.WriteLine("[2] See Role");
                Console.WriteLine("[3] Delete Account");
                Console.WriteLine("[4] Log out");
                Console.Write("Enter choice: ");
                parseSuccessfull = int.TryParse(Console.ReadLine(), out choice);
                HandleUserChoice(choice, logedInUser);
            } while (!parseSuccessfull || choice == 1 || choice == 2);
        }

        private static void HandleUserChoice(int choice, Account logedInUser)
        {
            switch (choice)
            {
                case 1:
                    logedInUser.ShowSalary();
                    break;
                case 2:
                    logedInUser.ShowRole();
                    break;
                case 3:
                    // Kalla på metod för delete här
                    break;
                case 4:
                    LogIn();
                    break;
                default:
                    break;
            }
        }

        private static void AdminMenu(Admin admin)
        {

        }
    }
}
