namespace PhoneBook
{

    class PhoneBookApp
    {
        private IPhoneBook phoneBook;

        public PhoneBookApp()
        {
            phoneBook = new PhoneBook();
        }

        public void Start()
        {
            while (true)
            {
                DisplayMenu();
                int choice = GetUserChoice();
                PerformAction(choice);
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine(" \n Lütfen yapmak istediğiniz işlemi seçiniz :) \n  ******************************************* \n\r   (1) Yeni Numara Kaydetmek \n\r   (2) Varolan Numarayı Silmek \n\r   (3) Varolan Numarayı Güncelleme \n\r   (4) Rehberi Listelemek \n\r   (5) Rehberde Arama Yapmak﻿ \n\r");
        }

        private int GetUserChoice()
        {
            return int.Parse(Console.ReadLine());
        }

        private void PerformAction(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddContactAction();
                    break;
                case 2:
                    RemoveContactAction();
                    break;
                case 3:
                    UpdateContactAction();
                    break;
                case 4:
                    DisplayContactsAction();
                    break;
                case 5:
                    SearchContactsAction();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz bir seçim yaptınız. Lütfen tekrar deneyiniz.");
                    break;
            }
        }

        private void AddContactAction()
        {
            Console.Write(" Lütfen isim giriniz             :");
            string firstName = Console.ReadLine();

            Console.Write(" Lütfen soyisim giriniz          :");
            string lastName = Console.ReadLine();

            Console.Write(" Lütfen telefon numarası giriniz :");
            string phoneNumber = Console.ReadLine();

            Contact newContact = new Contact(firstName, lastName, phoneNumber);
            phoneBook.AddContact(newContact);
        }

        private void RemoveContactAction()
        {
            Console.WriteLine("  Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:\n");

            string keyword = Console.ReadLine();
            phoneBook.RemoveContact(keyword);
        }

        private void UpdateContactAction()
        {
            Console.WriteLine("  Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:\n");

            string keyword = Console.ReadLine();
            phoneBook.UpdateContact(keyword);
        }

        private void DisplayContactsAction()
        {
            
            Console.WriteLine("  Sıralama tipi A-Z: (1)");
            Console.WriteLine("  Sıralama tipi Z-A: (2)");
            int orderBy = int.Parse(Console.ReadLine());
            var contacts = phoneBook.GetContacts(orderBy);
            Console.WriteLine("  Telefon Rehberi\r\n  ********************************************** \n");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"    isim: {contact.FirstName}, Soyisim: {contact.LastName}, Telefon Numarası: {contact.PhoneNumber}");
            }
        }

        private void SearchContactsAction()
        {
            Console.WriteLine("  Arama yapmak istediğiniz tipi seçiniz.\r\n ********************************************** \n");
            Console.WriteLine("  İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("  Telefon numarasına göre arama yapmak için: (2)");
            int searchType = int.Parse(Console.ReadLine());
            

            string keyword = Console.ReadLine();


            var foundContacts = phoneBook.SearchContacts(keyword, searchType);

            if (foundContacts.Count == 0)
            {
                Console.WriteLine("Eşleşen bir arama bulunamadı.");
            }
            else
            {
                Console.WriteLine(" Arama Sonuçlarınız:\r\n ********************************************** \n");
                foreach (var contact in foundContacts)
                {
                    Console.WriteLine($"    isim: {contact.FirstName}, Soyisim: {contact.LastName}, Telefon Numarası: {contact.PhoneNumber}");
            }
            }
        }
    }
}
