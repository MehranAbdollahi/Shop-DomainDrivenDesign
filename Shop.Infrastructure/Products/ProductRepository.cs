using Shop.Domain.ProductAgg;
using Shop.Infrastructure.EF.Core.Context;

namespace Shop.Infrastructure.EF.Core.Products;

public class ProductRepository : IProductRepository
{
    private readonly ShopContext _context;
    public ProductRepository(ShopContext context)
    {
        _context = context;
    }
    public List<Product> GetList()
    {
        return _context.Products.ToList();
    }

    public Product GetById(long id)
    {
        return _context.Products.FirstOrDefault(f => f.Id == id);
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Product product)
    {
        var oldProduct = GetById(product.Id);
        _context.Products.Update(oldProduct);
      //  Add(product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public bool IsProductExist(long id)
    {
        return _context.Products.Any(p => p.Id == id);
    }
}