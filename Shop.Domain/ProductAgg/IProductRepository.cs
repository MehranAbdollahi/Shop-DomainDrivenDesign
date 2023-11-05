namespace Shop.Domain.ProductAgg;

public interface IProductRepository
{
    List<Product> GetList();
    Product GetById(long id);
    void Add(Product product);
    void Update(Product product);
    void Remove(Product product);
    void Save();
    bool IsProductExist(long id);
}