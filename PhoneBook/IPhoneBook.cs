using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public interface IPhoneBook
    {
        public void AddContact(Contact contact);
        public void RemoveContact(string keyword);
        public void UpdateContact(string keyword);
        List<Contact> GetContacts(int sortOrder);
        List<Contact> SearchContacts(string keyword, int searchType);
    }
}
