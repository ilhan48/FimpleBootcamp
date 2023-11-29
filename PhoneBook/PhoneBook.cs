using PhoneBook;

namespace PhoneBook
{

    class PhoneBook : IPhoneBook
    {
        private List<Contact> contacts;

        public PhoneBook()
        {
            contacts = new List<Contact>
            {
                new Contact("Ilhan", "Odun", "123-456-7890"),
                new Contact("Hasan", "Odun", "987-654-3210"),
                new Contact("Nihat", "Odun", "555-123-4567"),
                new Contact("Isa", "Odun", "111-222-3333"),
                new Contact("Barlas", "Odun", "444-555-6666")
            };
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("\n   Kayıt başarılı");
        }

        public void RemoveContact(string keyword)
        {

            var foundContacts = SearchContacts(keyword, 1);

            if (foundContacts.Count == 0)
            {
                Console.WriteLine("  Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n");
                Console.WriteLine("  * Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("  * Yeniden denemek için      : (2)");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("İşlem iptal edildi.");
                        break;
                    case 2:
                        RemoveContact(keyword); // Retry
                        break;
                    default:
                        Console.WriteLine("Geçersiz bir tuşlama yaptınız. İşlem iptal edildi");
                        break;
                }
            }
            else
            {
                Contact contactToRemove = foundContacts.First();
                Console.Write($"{contactToRemove.FirstName} {contactToRemove.LastName} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)");
                string confirmation = Console.ReadLine().ToLower();

                if (confirmation == "y")
                {
                    contacts.Remove(contactToRemove);
                    Console.WriteLine("Silme işlemi başarılı.");
                }
                else if (confirmation == "n")
                {
                    Console.WriteLine("Silme işlemi iptal edildi.");
                }
                else
                {
                    Console.WriteLine("Geçersiz tuşlama. İşlem iptal edildi.");
                }
            }
        }

        public void UpdateContact(string keyword)
        {
            var foundContacts = SearchContacts(keyword, 1);

            if (foundContacts.Count == 0)
            {
                Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Güncellemeyi sonlandırmak için    : (1)");
                Console.WriteLine(" * Yeniden denemek için              : (2)");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Güncelleme iptal edildi.");
                        break;
                    case 2:
                        UpdateContact(keyword); // Retry
                        break;
                    default:
                        Console.WriteLine("Geçersiz tuşlama. İşlem iptal edildi.");
                        break;
                }
            }
            else
            {
                Contact contactToUpdate = foundContacts.First();
                Console.Write($"{contactToUpdate.FirstName} {contactToUpdate.LastName} found. Do you want to update? (y/n): ");
                string confirmation = Console.ReadLine().ToLower();

                if (confirmation == "y")
                {
                    Console.Write("Yeni isim girin (aynı kalmasını sağlamak için boş bırakın):");
                    string newFirstName = Console.ReadLine();
                    Console.Write("Yeni soyisim girin (aynı kalması için boş bırakın):");
                    string newLastName = Console.ReadLine();
                    Console.Write("Yeni telefon numarasını girin (aynı kalması için boş bırakın):");
                    string newPhoneNumber = Console.ReadLine();

                    Contact updatedContact = contactToUpdate;

                    if (!string.IsNullOrEmpty(newFirstName))
                        updatedContact.FirstName = newFirstName;

                    if (!string.IsNullOrEmpty(newLastName))
                        updatedContact.LastName = newLastName;

                    if (!string.IsNullOrEmpty(newPhoneNumber))
                        updatedContact.PhoneNumber = newPhoneNumber;

                    Console.WriteLine("Kayıt başarılı şekilde güncellendi.");
                }
            }
        }

        public List<Contact> GetContacts(int sortOrder)
        {
            switch (sortOrder)
            {
                case 1: // A-Z
                    return contacts.OrderBy(contact => contact.FirstName).ThenBy(contact => contact.LastName).ToList();
                case 2: // Z-A
                    return contacts.OrderByDescending(contact => contact.FirstName).ThenByDescending(contact => contact.LastName).ToList();
                default:
                    return contacts;
            }
        }


        public List<Contact> SearchContacts(string keyword, int searchType)
        {
            switch (searchType)
            {
                case 1: // Search by name
                    return contacts.FindAll(contact =>
                        contact.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        contact.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
                case 2: // Search by phone number
                    return contacts.FindAll(contact =>
                        contact.PhoneNumber.Contains(keyword, StringComparison.OrdinalIgnoreCase));
                default:
                    return new List<Contact>();
            }
        }

    }
}