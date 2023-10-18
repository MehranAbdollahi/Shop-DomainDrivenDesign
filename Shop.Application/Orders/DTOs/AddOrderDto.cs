namespace Shop.Application.Orders.DTOs;

public class AddOrderDto
{
    public AddOrderDto(long productId, int count, int price)
    {
        ProductId = productId;
        Count = count;
        Price = price;
    }

    public long ProductId { get;  set; }
    public int Count { get;  set; }
    public int Price { get;  set; }
}