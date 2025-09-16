

namespace API.Domain.Entities
{
    public class VStock
    {
        public int Quanlity { get; private set; }

        public VStock(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Stock cannot be negative", nameof(value));
            }
            Quanlity = value;
        }
        
        public void Decrease(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Decrease amount cannot be negative", nameof(amount));
            }
            if (amount > Quanlity)
            {
                throw new InvalidOperationException("Insufficient stock to decrease");
            }
            Quanlity -= amount;
        }

        public void Increase(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Increase amount cannot be negative", nameof(amount));
            }
            Quanlity += amount;
        }


        public override string ToString() => Quanlity.ToString();

        public override bool Equals(object obj)
        {
            if (obj is VStock other)
            {
                return Quanlity == other.Quanlity;
            }
            return false;
        }

        public override int GetHashCode() => Quanlity.GetHashCode();


    }
}