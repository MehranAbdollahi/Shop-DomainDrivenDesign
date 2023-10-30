using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.DTOs
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }

        public string PassWord { get; set; }
    }
}
