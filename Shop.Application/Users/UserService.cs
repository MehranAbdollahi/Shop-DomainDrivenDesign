using Shop.Application.Products.DTOs;
using Shop.Application.Users.DTOs;
using Shop.Application.Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.Products;
using Shop.Domain.Shared;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.ValueObjects;
using Shop.Domain.Users.ValueObjects;

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
        var isFullNameExist = _repository.GetList().Any(u => u.UserName == command.UserName);

        if (isFullNameExist)
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
            User.UserRole.User,
            hashedPassword);

        _repository.Add(user);
        _repository.Save();

        return OperationResult.Success("موفق");
    }
}