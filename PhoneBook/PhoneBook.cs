using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class PhoneBook : IPhoneBook
    {
        private List<Contact> contacts;

        public PhoneBook()
        {
            contacts = new List<Contact>();
        }
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            contacts.Remove(contact);
        }

        public void UpdateContact(Contact oldContact, Contact newContact)
        {
            int index = contacts.IndexOf(oldContact);
            if (index != -1)
            {
                contacts[index] = newContact;
            } 

        }

        public List<Contact> SearchContacts(string keyword)
        {
            return contacts.FindAll(contact =>
                contact.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                contact.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase)  ||
                contact.PhoneNumber.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

    }
}
