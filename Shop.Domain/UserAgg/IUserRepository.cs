using Shop.Domain.Products;

namespace Shop.Domain.UserAgg;

public interface IUserRepository
{
    List<User> GetList();
    User GetById(long id);
    void Add(User user);
    void Update(User user);
    void Remove(User user);
    void Save();
}