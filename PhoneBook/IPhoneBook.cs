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
        public void RemoveContact(Contact contact);
        public void UpdateContact(Contact oldContact, Contact newContact);
        List<Contact> GetAllContacts();
        List<Contact> SearchContacts(string keyword);
    }
}
