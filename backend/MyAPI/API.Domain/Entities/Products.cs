

namespace API.Domain.Entities
{
    public class Products
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public VPrice Price { get; private set; }

        public VStock Stock { get; private set; }
        

    }
}