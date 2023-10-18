namespace Shop.Domain.CategoryAgg.Repository;

public interface ICategoryRepository
{
    List<Category> GetList();
    Category GetById(long id);
    void Add(Category order);
    void Update(Category order);
    void SaveChanges();
}