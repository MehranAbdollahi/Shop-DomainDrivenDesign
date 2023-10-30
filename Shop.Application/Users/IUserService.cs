using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.Users.DTOs;

namespace Shop.Application.Users
{
    public interface IUserService
    {
        void RegisterUser(UserRegisterDto userRegisterDto);
    }
}
