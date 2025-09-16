

namespace API.Domain.Entities
{
    public class VEmail
    {
        public string Value { get; }

        public VEmail(string value)
        {

            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("Invalid email format", nameof(value));
            }
            Value = value;
        }

        public override string ToString() => Value;

        public override bool Equals(object obj)
        {
            if (obj is VEmail other)
            {
                return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
        
        public override int GetHashCode() => Value.GetHashCode(StringComparison.OrdinalIgnoreCase);
       
    }
}