using Shop.Application.Users.DTOs;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Users;

public class UserService : IUserService
{
    private readonly IProductRepository _repository;

    public UserService(IProductRepository repository)
    {
        _repository = repository;
    }
    public void RegisterUser(UserRegisterDto userRegisterDto)
    {
        //
    }
}