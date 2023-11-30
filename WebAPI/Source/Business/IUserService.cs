using WebAPI.Source.Entities;

namespace WebAPI.Source.Business
{
    public interface IUserService
    {
        List<User> GetAll(string sortBy);
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        UserDto Map<T>(User user);
    }
}