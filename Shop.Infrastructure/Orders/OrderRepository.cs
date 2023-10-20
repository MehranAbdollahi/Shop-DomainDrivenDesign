using Shop.Domain.Orders;
using Shop.Domain.Orders.Repository;
using Shop.Infrastructure.Context;

namespace Shop.Infrastructure.Orders;

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