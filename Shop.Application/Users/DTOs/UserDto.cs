using Shop.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shop.Domain.UserAgg.User;

namespace Shop.Application.Users.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string UserName { get;  set; }
        public string PassWord { get;  set; }
        public UserRole Role { get; set; }
    }
}
