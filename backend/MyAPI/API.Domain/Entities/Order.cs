

namespace API.Domain.Entities
{
    public class Orders
    {
        public int Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public int UserId { get; private set; }

        private readonly List<OrderItems> orderitems = new();
        public IReadOnlyCollection<OrderItems> Items => orderitems.AsReadOnly();

        public Orders(int id,DateTime orderDate, int userId, List<OrderItems> orderitems)
        {
            Id = id;
            OrderDate = orderDate;
            UserId = userId;
            this.orderitems = orderitems;
        }

        public void AddItem(int productid, int quanlity)
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

        public void RemoveItem(int productid)
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
        public int ProductId;
        public int Quanlity;

        internal OrderItems(int ProductId, int Quanlity)
        {
            this.Quanlity = Quanlity;
            this.ProductId = ProductId;
        }

    }
}


