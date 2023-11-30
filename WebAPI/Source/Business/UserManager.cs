using System.Collections.Generic;
using WebAPI.Source.Entities;
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
       public List<User> GetAll(string sortBy)
        {
            if (sortBy == "id")
            {
                _userDal.Sort((x, y) => x.Id.CompareTo(y.Id));
                return _userDal;
            }


            else if (sortBy == "firstName")
            {
                _userDal.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
                return _userDal;
            }
            else if (sortBy == "lastName")
            {
                _userDal.Sort((x, y) => x.LastName.CompareTo(y.LastName));
                return _userDal;
            }
            else if (sortBy == "email")
            {
                _userDal.Sort((x, y) => x.Email.CompareTo(y.Email));
                return _userDal;
            }
            else if (sortBy == "password")
            {
                _userDal.Sort((x, y) => x.Password.CompareTo(y.Password));
                return _userDal;
            }
            else
            {
                return _userDal;
            }
            
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

      // ! Map fonksiyonu User-> UserDto
        public UserDto Map<T>(User user)
        {
            UserDto userDto = new UserDto();
            userDto.Email = user.Email;
            userDto.Password = user.Password;
            return userDto;
        }
        
    }
}