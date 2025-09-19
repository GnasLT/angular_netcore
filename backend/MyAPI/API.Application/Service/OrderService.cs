using API.Application.Abstractions;
using API.Application.DTO.Request;
using API.Application.DTO.Response;
using API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace API.Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> CreateOrder(OrderRequestDTO orderdto)
        {
            List<OrderItems> items = new List<OrderItems>();
            items = orderdto.Items.Select(i => new OrderItems(i.ProductId, i.Quantity)).ToList();
            
            Orders order = new Orders(3,orderdto.OrderDate, orderdto.UserId, items);
            foreach (var item in orderdto.Items)
            {
                Products product = _productRepository.GetProductByID(item.ProductId);
                if (product != null)
                {
                   product.DecreaseStock(item.Quantity);
                }
            }
            _orderRepository.CreateOrder(order);

            OrderResponseDTO order_respon = new OrderResponseDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Items = order.Items.Select(i => new OrderItemResponseDTO
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quanlity
                }).ToList()
            };

            return new OkObjectResult(new { Message = "Order created successfully", order_respon });
        }

    }
}