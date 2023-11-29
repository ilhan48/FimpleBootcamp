using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class ConsoleUI : IUser
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine(
                "*******************************************" +
                "(1) Yeni Numara Kaydetmek " +
                "(2) Varolan Numarayı Silmek " +
                "(3) Varolan Numarayı Güncelleme" +
                "(4) Rehberi Listelemek " +
                "(5) Rehberde Arama Yapmak"
                );
        }

        public int GetUserChoice()
        {
            return int.Parse( Console.ReadLine() );
        }

        public void PerformAction(int choice, IPhoneBook phoneBook)
        {
            switch (choice)
            {
                case 1:
                    AddContactAction(phoneBook);
                    break;
                case 2:
                    RemoveContactAction(phoneBook);    
                    break;
                case 3:
                    UpdateContactAction(phoneBook);
                    break;
                case 4:
                    DisplayContactsAction(phoneBook);
                    break;
                case 5:
                    SearchContactsAction(phoneBook);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz bir seçim yaptınız. Lütfen tekrar deneyiniz.");
                    break;


            }
        }

        private void SearchContactsAction(IPhoneBook phoneBook)
        {
            throw new NotImplementedException();
        }

        private void DisplayContactsAction(IPhoneBook phoneBook)
        {
            throw new NotImplementedException();
        }

        private void UpdateContactAction(IPhoneBook phoneBook)
        {
            throw new NotImplementedException();
        }

        private void RemoveContactAction(IPhoneBook phoneBook)
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string keyword = Console.ReadLine();

            var foundContacts = phoneBook.SearchContacts(keyword);

            if (foundContacts.Count == 0)
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                int index = int.Parse(Console.ReadLine());

                
            }
        }

        private void AddContactAction(IPhoneBook phoneBook)
        {
            Console.WriteLine("Lütfen isim giriniz              :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Lütfen soyisim giriniz           :");
            string lastName = Console.ReadLine();

            Console.WriteLine("Lütfen telefon numarası giriniz  :");
            string phoneNumber = Console.ReadLine();

            Contact newContact = new(firstName, lastName, phoneNumber);
            phoneBook.AddContact(newContact);

            Console.WriteLine("Kayıt başarılı");
        }
    }
}
