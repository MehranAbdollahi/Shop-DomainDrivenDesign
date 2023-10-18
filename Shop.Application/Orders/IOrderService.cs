using Shop.Application.Orders.DTOs;

namespace Shop.Application.Orders;

public interface IOrderService
{
    void AddOrder(AddOrderDto command);
    void FinallyOrder(FinallyOrderDto command);
    OrderDto GetOrderById(long id);
    List<OrderDto> GetOrders();

}