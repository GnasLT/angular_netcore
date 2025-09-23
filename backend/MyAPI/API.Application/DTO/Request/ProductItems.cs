

using API.Domain.Entities;

namespace API.Application.DTO.Request
{
    public class ProductItems
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public VPriceDTO Price { get; set; }

        public VStockDTO Stock { get; set; }
    }

    
}