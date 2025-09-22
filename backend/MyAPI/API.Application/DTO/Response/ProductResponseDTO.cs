
namespace API.Application.DTO.Response
{
   public class ProductReponseDTO
    {
        public DateTime OrderDate { get; set; }

        public List<OrderItemResponseDTO> Items { get; set; }

    }
}