namespace Shop.Application.Orders.DTOs;

public class FinallyOrderDto
{
    public FinallyOrderDto(long orderId)
    {
        OrderId = orderId;
    }

    public long OrderId { get; set; }

}