using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.UserAgg;
using Shop.Infrastructure.EF.Core.Context;

namespace Shop.Infrastructure.EF.Core.Users
{
    public class UserRepository : IUserRepository
    {
        ShopContext _shopContext;

        public UserRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public List<User> GetList()
        {
            return _shopContext.Users.ToList();
        }

        public User GetById(long id)
        {
            var user = _shopContext.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public void Add(User user)
        {
            _shopContext.Users.Add(user);
        }

        public void Update(User user)
        {
            var oldUser = GetById(user.Id);
            _shopContext.Users.Update(oldUser);
        }

        public void Remove(User user)
        {
            _shopContext.Users.Remove(user);
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }

    }
}
