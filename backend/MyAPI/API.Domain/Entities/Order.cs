

namespace API.Domain.Entities
{
    public class Orders
    {
        public Guid Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Guid UserId { get; private set; }

        private readonly List<OrderItems> orderitems = new();
        public IReadOnlyCollection<OrderItems> Items => orderitems.AsReadOnly();

        public Orders(DateTime orderDate, Guid userId, List<OrderItems> orderitems)
        {
            Id = Guid.NewGuid();
            OrderDate = orderDate;
            UserId = userId;
            this.orderitems = orderitems;
        }

        public void AddItem(Guid productid, int quanlity)
        {
            if (quanlity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");
            orderitems.Add(new OrderItems(productid, quanlity));
        }

        public void AddItem(OrderItems items)
        {
            if (items.Quanlity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");
            orderitems.Add(items);
        }

        public void RemoveItem(Guid productid)
        {
            var item = orderitems.FirstOrDefault(u => u.ProductId == productid);
            if (item != null)
            {
                orderitems.Remove(item);
            }
        }

    }



    public class OrderItems
    {
        public Guid ProductId;
        public int Quanlity;

        internal OrderItems(Guid ProductId, int Quanlity)
        {
            this.Quanlity = Quanlity;
            this.ProductId = ProductId;
        }

    }
}


