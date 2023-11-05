using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Infrastructure.EF.Core.Context;

namespace Shop.Infrastructure.EF.Core.Orders;

public class OrderRepository : IOrderRepository
{
    private ShopContext _context;
    public OrderRepository(ShopContext context)
    {
        _context = context;
    }
    public List<Order> GetList()
    {
        return _context.Orders.ToList();
    }

    public Order GetById(long id)
    {
        return _context.Orders.FirstOrDefault(f => f.Id == id);
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public void Update(Order order)
    {
        var oldOrder = GetById(order.Id);
        _context.Orders.Remove(oldOrder);
        Add(order);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}