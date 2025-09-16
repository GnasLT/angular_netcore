

namespace API.Domain.Entities
{
    public class VPassword
    {
        public string Value { get; }

        public VPassword(string value)
        {

            // Example validation: at least 6 characters, contains a number and an uppercase letter
            if (string.IsNullOrWhiteSpace(value) || value.Length < 6 || !value.Any(char.IsDigit) || !value.Any(char.IsUpper))
            {
                throw new ArgumentException("Invalid email format", nameof(value));
            }
            Value = value;
        }

        public override string ToString() => Value;

        public override bool Equals(object obj)
        {
            if (obj is VPassword other)
            {
                return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
        
        public override int GetHashCode() => Value.GetHashCode(StringComparison.OrdinalIgnoreCase);   
    }
}