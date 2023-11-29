using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public interface IUser
    {
        public void DisplayMenu();
        public int GetUserChoice();
        public void PerformAction(int choice, IPhoneBook phoneBook);
    }
}
