

namespace API.Domain.Entities
{
    public class VStock
    {
        public int quantity { get; private set; }

        public VStock(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Stock cannot be negative", nameof(value));
            }
            quantity = value;
        }
        
        public void Decrease(int amount)
        {
            // if (amount < 0)
            // {
            //     throw new ArgumentException("Decrease amount cannot be negative", nameof(amount));
            // }
            // if (amount > quantity)
            // {
            //     throw new InvalidOperationException("Insufficient stock to decrease");
            // }
            quantity -= amount;
        }

        public void Increase(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Increase amount cannot be negative", nameof(amount));
            }
            quantity += amount;
        }


        public override string ToString() => quantity.ToString();

        public override bool Equals(object obj)
        {
            if (obj is VStock other)
            {
                return quantity == other.quantity;
            }
            return false;
        }

        public override int GetHashCode() => quantity.GetHashCode();


    }
}