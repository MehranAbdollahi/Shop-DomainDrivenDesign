using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Infrastructure.EF.Core.Context;

namespace Shop.Infrastructure.EF.Core.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly ShopContext _shopContext;

        public CategoryRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Category> GetList()
        {
            return _shopContext.Categories.ToList();
        }

        public Category GetById(long id)
        {
            return _shopContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Category category)
        {
            _shopContext.Categories.Add(category);
        }

        public void Update(Category category)
        {
            var oldCategory = GetById(category.Id);
            _shopContext.Categories.Remove(oldCategory);
            Add(category);
        }

        public void SaveChanges()
        {
            _shopContext.SaveChanges();
        }
    }
}
