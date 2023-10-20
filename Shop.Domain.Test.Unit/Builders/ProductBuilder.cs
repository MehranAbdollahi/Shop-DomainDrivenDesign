using Shop.Domain.ProductAgg;
using Shop.Domain.Products;
using Shop.Domain.Shared;
using System.Collections.Generic;

namespace Shop.Domain.Test.Unit.Builders;

internal class ProductBuilder : IDisposable
{
    private string _title = "test";
    private Money _money = new Money(1000000);

    public ProductBuilder SetTitle(string title)
    {
        _title = title;
        return this;
    }
    public ProductBuilder SetMoney(int rialPrice)
    {
        _money = new Money(rialPrice);
        return this;
    }
    public Product Build()
    {
        return new Product(_title, _money);
    }

    public void Dispose()
    {
        // Tear down
    }
}
