using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
    public class Admin : Account
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
        public void RemoveUserFromList(string username, string password)
        {
            if (!IsAccountAdmin(username, password))
            {
                var user = SetUpBank.listOfUsers.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    Console.WriteLine("User is deleted");
                    SetUpBank.listOfUsers.Remove(user);
                }
                else
                {
                    Console.WriteLine("Account doesnt not exist");
                }
            }
            else
            {
                Console.WriteLine("Admin cant be removed!");
            }
        }
        public bool IsAccountAdmin(string username, string password)
        {
            return Username == username && Password == password;
        }

    }
}
