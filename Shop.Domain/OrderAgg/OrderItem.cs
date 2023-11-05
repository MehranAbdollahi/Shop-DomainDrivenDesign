using Shop.Domain.Shared;

namespace Shop.Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {


        public long OrderId { get; protected set; }
        public int Count { get; private set; }
        public long ProductId { get; private set; }
        public Money Price { get; private set; }
        public OrderItem(long orderId, int count, long productId, Money price)
        {
            OrderId = orderId;
            Count = count;
            ProductId = productId;
            Price = price;
        }
#pragma warning disable CS8618
        private OrderItem()
#pragma warning restore CS8618
        {

        }


    }
}
