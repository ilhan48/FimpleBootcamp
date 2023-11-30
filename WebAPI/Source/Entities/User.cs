
namespace WebAPI.Source.Entities;

public class User
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }


    public User(string firstName, string lastName, string email, string password)
    {
        Id += 1;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        
    }
}

