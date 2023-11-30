
namespace WebAPI.Source.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public  string Email { get; set; }
    public  string Password { get; set; }


    public User(string firstName, string lastName, string email, string password)
    {
        Id += 1;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        
    }
}

