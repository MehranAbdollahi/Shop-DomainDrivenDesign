using Shop.Domain.Shared;

namespace Shop.Domain.CategoryAgg
{
    public class CategoryItem : BaseEntity
    {
        public long CategoryId { get; protected set; }
        public long ProductId { get; private set; }
        public CategoryItem(long categoryId, long productId)
        {
            CategoryId = categoryId;
            ProductId = productId;
        }

    }
}
