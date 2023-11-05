using Shop.Domain.Shared;
using Shop.Domain.Shared.Exceptions;

namespace Shop.Domain.ProductAgg;

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

#pragma warning disable CS8618
    private Product()
#pragma warning restore CS8618
    {
        
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