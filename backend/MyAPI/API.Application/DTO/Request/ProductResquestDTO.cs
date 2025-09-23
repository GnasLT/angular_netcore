
using API.Domain.Entities;

namespace API.Application.DTO.Request
{
    public class ProductRequestDTO
    {
        public DateTime OrderDate { get; set; }

        public List<ProductItems> Items { get; set; }

    }

    
}