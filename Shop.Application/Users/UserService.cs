using Shop.Application.Products.DTOs;
using Shop.Application.Users.DTOs;
using Shop.Application.Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.Shared;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.ValueObjects;
using Shop.Domain.Users.ValueObjects;
using Shop.Contracts;
namespace Shop.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public OperationResult RegisterUser(UserRegisterDto command)
    {
        var isUserNameExist = _repository.GetList().Any(u => u.UserName == command.UserName);

        if (isUserNameExist)
        {
            return OperationResult.Error("نام کاربری تکراری است .");
        }

        var phoneNumber = new PhoneNumber("09171112565");
        var fax = new PhoneNumber("09171112565");
        var phone = new PhoneBook(phoneNumber, fax);
        var hashedPassword = command.PassWord.EncodeToMd5();

        var user = new User(command.UserName,
            command.UserName,
            phone, command.Email,
            User.UserRole.Admin,
            hashedPassword);

        _repository.Add(user);
        _repository.Save();
        // sms
        return OperationResult.Success("موفق");
    }

    public UserDto LoginUser(UserLoginDto command)
    {
        var user = _repository.GetList().FirstOrDefault(u => u.UserName == command.UserName
                                                             && u.PassWord == command.PassWord.EncodeToMd5());

        if (user == null)
        {
            return null;
        }

        var userDto = new UserDto()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            UserName = user.UserName,
            PassWord = user.PassWord,
            Role = user.Role
        };

        return userDto;
    }
}