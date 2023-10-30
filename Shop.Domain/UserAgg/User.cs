using Shop.Domain.Shared;
using Shop.Domain.UserAgg.Events;
using Shop.Domain.Users.ValueObjects;

namespace Shop.Domain.UserAgg;

public class User : AggregateRoot
{
    private User()
    {
        
    }
    public User(string name, string fullName, PhoneBook phoneBook, string email, UserRole role, string passWord)
    {
        Name = name;
        FullName = fullName;
        PhoneBook = phoneBook;
        Email = email;
        Role = role;
        PassWord = passWord;
    }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string FullName { get; private set; }

    public string PassWord { get; private set; }
    public PhoneBook PhoneBook { get; private set; }
    public UserRole Role { get; set; }

    public static User Register(string email)
    {
        UserRole role = new UserRole();

        var user = new User("", "", null, email, role,"");
        user.AddDomainEvent(new UserRegistered(user.Id, email));
        return user;
    }
    public enum UserRole
    {
        Admin,
        User,
        Writer
    }
}