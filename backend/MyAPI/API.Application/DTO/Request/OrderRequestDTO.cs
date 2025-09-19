

namespace API.Application.DTO.Request
{
    public class OrderRequestDTO
    {
        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderItemDTO> Items { get; set; }
    }

    public class OrderItemDTO
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}