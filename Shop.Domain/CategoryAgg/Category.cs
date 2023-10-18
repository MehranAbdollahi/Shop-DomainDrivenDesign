using Shop.Domain.Shared;
using Shop.Domain.Shared.Exceptions;

namespace Shop.Domain.CategoryAgg;

public class Category : AggregateRoot
{
    public string Title { get; private set; }
    public ICollection<CategoryItem> Items { get; private set; }
    public int SubCategoryId { get; set; }

    public Category(string title, int subCategoryId)
    {
        Guard(title);
        Title = title;
        SubCategoryId = subCategoryId;
        Items = new List<CategoryItem>();
    }

    public void Edit(string title, int subCategoryId)
    {
        Guard(title);
        Title = title;
        SubCategoryId = subCategoryId;
    }
    public void RemoveItem(long id)
    {
        var item = Items.FirstOrDefault(f => f.Id == id);
        if (item == null)
            throw new NullOrEmptyDomainDataException("Item not found");

        Items.Remove(item);
    }
    public void AddItem(long productId)
    {
        Items.Add(new CategoryItem(Id, productId));
    }
    private void Guard(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
    }
}