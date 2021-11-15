using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
  public static class SetUpBank
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
                Console.Write("Enter Password : ");
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
                    DeleteUser(logedInUser);
                    break;
                case 4:
                    LogIn();
                    break;
                default:
                    break;
            }
        }

        public static void DeleteUser(Account logedInAccount)
        {
            
            Console.Write("Enter Username : ");
            var username = Console.ReadLine();
            Console.Write("Enter Password : ");
            var password = Console.ReadLine();
            if (logedInAccount is User)
            {
                var user = logedInAccount as User;
                if (user.RemoveSelfFromList(username, password))
                {
                    Console.WriteLine("User is deleted");
                    listOfUsers.Remove(user);
                    LogIn();
                }
            }
            else if(logedInAccount is Admin)
            {
                var admin = logedInAccount as Admin;
                admin.RemoveUserFromList(username, password);
            }
        }

        private static void AdminMenu(Admin admin)
        {
            int choice = 0;
            bool parseSuccessfull = false;
            do
            {

                Console.WriteLine("ADMIN MENU");
                Console.WriteLine("[1] See salary");
                Console.WriteLine("[2] See Role");
                Console.WriteLine("[3] See all users");
                Console.WriteLine("[4] Create new users");
                Console.WriteLine("[5] Remove specfied user");
                Console.WriteLine("[6] Log out");
                Console.Write("Enter choice: ");
                parseSuccessfull = int.TryParse(Console.ReadLine(), out choice);
                HandleAdminChoice(choice, admin);
            } while (!parseSuccessfull || choice != 6);

        }

        private static void HandleAdminChoice(int choice, Admin logedInAdmin)
        {
            switch (choice)
            {
                case 1:
                    logedInAdmin.ShowSalary();
                    break;
                case 2:
                    logedInAdmin.ShowRole();
                    break;
                case 3:
                    logedInAdmin.SeeAllUsers(listOfUsers);
                    break;
                case 4:
                    CreateNewUser();
                    break;
                case 5:
                    DeleteUser(logedInAdmin);
                    break;
                case 6:
                    LogIn();
                    break;
                default:
                    break;
            }

        }

        private static void CreateNewUser()
        {
            Console.Write("Enter Username : ");
            var username = Console.ReadLine();
            Console.WriteLine("Enter Password : ");
            var password = Console.ReadLine();
           
            if (VerifyUser(username, password))
            {
                Console.WriteLine("Role : ");
                string role = Console.ReadLine();
                Console.WriteLine("Salary : ");
                int.TryParse(Console.ReadLine(), out int salary);
                User newUser = new User { Username = username, Password = password, Role = role, Salary = salary };
                listOfUsers.Add(newUser);
            }
        }
        public static bool VerifyUser(string username, string password)
        {
            if (listOfUsers.Any(u => u.Username == username))
            {
                return false;
            }
            bool validUserName = username.Any(u => char.IsDigit(u) && username.Any(u => char.IsLetter(u)));
            bool validPassword = password.Any(p => char.IsDigit(p) && password.Any(p => char.IsLetter(p)));
            
            return validUserName && validPassword;
        }
    }
}
