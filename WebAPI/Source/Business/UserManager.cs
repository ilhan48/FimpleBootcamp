using System.Collections.Generic;
namespace WebAPI.Source.Business
{
    public class UserManager : IUserService
    {
        // !! Fake data
        List<User> _userDal = new List<User>
        {
            new User(firstName: "Ilhan", lastName: "Odun", email:"ilhan@mail.com","123456),")
        };
        // ! Ekleme senaryosu
        public void Add(User user)
        {
            _userDal.Add(user);
            System.Console.WriteLine("User added");
        }
        // ! Silme senaryosu
        public void Delete(User user)
        {
            _userDal.Remove(user);
            System.Console.WriteLine("User deleted");
        }
        // ! Tüm kullanıcıları listeleme senaryosu
        public List<User> GetAll()
        {
            return _userDal;
        }
        // ! Id'ye göre kullanıcı bulma senaryosu
        public User GetById(int id)
        {
            return _userDal.Find(u => u.Id == id);
        }
        // ! Güncelleme senaryosu
        public void Update(User user)
        {
            User userToUpdate = _userDal.Find(u => u.Id == user.Id);
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
            System.Console.WriteLine("User updated");
        }
    }
}