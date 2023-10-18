using Shop.Domain.Shared;
using Shop.Domain.Shared.Exceptions;
using Shop.Domain.ProductAgg;

namespace Shop.Domain.Products;

public class Product : AggregateRoot
{
    public string Title { get; private set; }
    public Money Money { get; private set; }
    public ICollection<ProductImage> Images { get; private set; }
    public Product(string title, Money price)
    {
        Guard(title);
        Title = title;
        Money = price;
        Images = new List<ProductImage>();
    }

    public void Edit(string title, Money price)
    {
        Guard(title);
        Title = title;
        Money = price;
    }
    public void RemoveImage(long id)
    {
        var image = Images.FirstOrDefault(f => f.Id == id);
        if (image == null)
            throw new NullOrEmptyDomainDataException("Image not found");

        Images.Remove(image);
    }
    public void AddImage(string imageName)
    {
        Images.Add(new ProductImage(Id, imageName));
    }
    private void Guard(string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
    }
}