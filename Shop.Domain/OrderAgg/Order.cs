using Shop.Domain.OrderAgg.Events;
using Shop.Domain.OrderAgg.Exceptions;
using Shop.Domain.OrderAgg.Services;
using Shop.Domain.OrderAgg;
using Shop.Domain.Shared;
using Shop.Domain.Shared.Exceptions;

namespace Shop.Domain.Orders;

public class Order : AggregateRoot
{
    public long UserId { get; private set; }
    public int TotalPrice;
    public int TotalItems { get; set; }
    public bool IsFinally { get; private set; }
    public DateTime FinallyDate { get; private set; }
    public ICollection<OrderItem> Items { get; private set; }
    public Order(long userId)
    {
        UserId = userId;
        Items = new List<OrderItem>();
    }
    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
        AddDomainEvent(new OrderFinalized(Id, UserId));
    }
    public void AddItem(long productId, int count, int price, IOrderDomainService orderService)
    {
        if (orderService.IsProductNotExsist(productId))
            throw new ProductNotFoundException();

        if (Items.Any(p => p.ProductId == productId))
            return;

        Items.Add(new OrderItem(Id, count, productId, Money.FromTooman(price)));
        TotalItems += count;
    }
    public void RemoveItem(long productId)
    {
        var item = Items.FirstOrDefault(f => f.ProductId == productId);
        if (item == null)
            throw new InvalidDomainDataException();

        Items.Remove(item);
        TotalItems -= item.Count;
    }
}