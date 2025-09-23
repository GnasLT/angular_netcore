
using API.Application.DTO.Request;
using API.Domain.Entities;

namespace API.Application.DTO.Response
{
    public class ProductReponseDTO
    {
        public DateTime OrderDate { get; set; }

        public List<ProductItemsResponseDTO> Items { get; set; } = new List<ProductItemsResponseDTO>();

    }

    public class ProductItemsResponseDTO
    {
        public string Name { get; set; }

        public VPriceDTO Price { get; set; }

        public VStockDTO Stock { get; set; }
    }
}