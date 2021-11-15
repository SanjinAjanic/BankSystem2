using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem2
{
    public class User : Account
    {
        public bool RemoveSelfFromList(string username, string password)
        {
            if(Username == username && Password == password)
            {
                return true;
            }
            return false;
        }
    }
}
