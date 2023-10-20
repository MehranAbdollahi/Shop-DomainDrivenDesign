namespace Shop.Domain.CategoryAgg.Repository;

public interface ICategoryRepository
{
    List<Category> GetList();
    Category GetById(long id);
    void Add(Category category);
    void Update(Category category);
    void SaveChanges();
}