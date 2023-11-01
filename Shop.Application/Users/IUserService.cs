using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Users.DTOs;
using Shop.Application.Utilities;

namespace Shop.Application.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDto userRegisterDto);
        UserDto LoginUser(UserLoginDto  userLoginDto);
    }
}
