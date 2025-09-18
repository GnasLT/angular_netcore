

using System.Globalization;

namespace API.Domain.Entities
{
    public class VPrice
    {
        public decimal Value { get; }
        public string Currency = "USD";

        public VPrice(decimal value, string currency)
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative", nameof(value));
            }
            if (value == 0)
            {
                throw new ArgumentException("Price cannot be zero", nameof(value));
            }
            
            
            Value = value;
            Currency = currency;
        }

        public override string ToString() {
            // Format the number with thousand separators
            string formatted = Value.ToString("N0");

            return  formatted  + " " + Currency;
        }
        
        public override bool Equals(object obj)
        {
            if (obj is VPrice other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public VPrice Add(VPrice other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }
            
            if (this.Currency != other.Currency)
            {
                throw new InvalidOperationException("Cannot add prices with different currencies");
            }

            return new VPrice(this.Value + other.Value, this.Currency);
        }

        public override int GetHashCode() => Value.GetHashCode();
    }
}