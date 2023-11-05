using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Shared;

namespace Shop.Domain.UserAgg.Events
{
    public class UserRegistered : BaseDomainEvent
    {
        public UserRegistered(long userId, string email)
        {
            UserId = userId;
            Email = email;
        }

        public long UserId { get; private set; }
        public string Email { get; private set; }

        
    }
}
