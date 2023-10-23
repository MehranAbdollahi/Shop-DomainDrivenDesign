using Shop.Domain.Shared;
using Shop.Domain.Shared.Exceptions;

namespace Shop.Domain.CategoryAgg;

public class Category : AggregateRoot
{
    public string Title { get; private set; }
    public ICollection<CategoryItem> Items { get; private set; }
    public int? ParentId { get; set; }
    public int TotalCategoryItems { get; set; }

    public Category(string title, int? parentId)
    {
        Guard(title);
        Title = title;
        ParentId = parentId;
        Items = new List<CategoryItem>();

    }

    public void Edit(string title, int? subCategoryId)
    {
        Guard(title);
        Title = title;
        ParentId = subCategoryId;
    }
    public void RemoveItem(long productId)
    {
        var item = Items.FirstOrDefault(f => f.ProductId == productId);
        if (item == null)
            throw new NullOrEmptyDomainDataException("Item not found");
        TotalCategoryItems--;
        Items.Remove(item);

    }
    public void AddItem(long productId)
    {
        TotalCategoryItems++;

        Items.Add(new CategoryItem(Id, productId));

    }
    private void Guard(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
    }
}