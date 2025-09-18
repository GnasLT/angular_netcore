

namespace API.Domain.Entities
{
    public class Orders
    {
        public Guid Id { get; private set; }
        public VOrderStatus Status { get; private set; }
        public DateTime OrderDate { get; private set; }
        public VPrice TotalAmount { get; private set; }
        public Guid UserId { get; private set; }
        public Users User { get; private set; }
        public ICollection<OrderItems> OrderItems { get; private set; }

        public Orders(VOrderStatus status, DateTime orderDate, VPrice totalAmount, Guid userId)
        {
            Id = Guid.NewGuid();
            Status = status;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            UserId = userId;
            OrderItems = new List<OrderItems>();
        }

        public void UpdateStatus(VOrderStatus newStatus)
        {
            Status = newStatus;
        }

        public void AddOrderItem(OrderItems orderItem)
        {
            OrderItems.Add(orderItem);
        }
    }
}