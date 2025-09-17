

namespace API.Domain.Entities
{
    public class VRole
    {
        public string Name { get; private set; }

        public VRole(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Role name cannot be empty", nameof(name));
            }
            Name = name;
        }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if (obj is VRole other)
            {
                return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode() => Name.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}