

namespace API.Domain.Entities
{
    public class Products
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public VPrice Price { get; private set; }

        public VStock Stock { get; private set; }

        public Products(Guid id, string name, VPrice price, VStock stock)
        {
            Id = id;
            Name = name ?? throw new InvalidOperationException("Name cannot be null");
            Price = price ?? throw new InvalidOperationException("Price cannot be null");
            Stock = stock ?? throw new InvalidOperationException("Stock cannot be null");
        }

        public void UpdatePrice(VPrice newPrice)
        {
            Price = newPrice;
        }

        public void IncreaseStock(int newStock)
        {
            if (newStock < 0)
            {
                throw new InvalidOperationException("Stock increase must be a positive value.");
            }
            Stock.Increase(newStock);
        }

        public void DecreaseStock(int newStock)
        {
            if (newStock < 0)
            {
                throw new InvalidOperationException("Stock decrease must be a positive value.");
            }
            if (Stock.Quanlity < newStock)
            {
                throw new InvalidOperationException("Insufficient stock to decrease.");
            }
            Stock.Decrease(newStock);
        }

        public void ChangeName(string newName)
        {
            Name = newName ?? throw new InvalidOperationException("Name cannot be null");
        }
        
    }
}