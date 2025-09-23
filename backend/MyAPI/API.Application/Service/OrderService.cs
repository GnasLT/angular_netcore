using System.Security.Claims;
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

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<OrderResponseDTO>> CreateOrder(OrderRequestDTO orderdto, string userId)
        {
            List<OrderItems> items = new List<OrderItems>();
            
            items = orderdto.Items.Select(i => new OrderItems(i.ProductId, i.Quantity)).ToList();
            Console.WriteLine(userId);
            Orders order = new Orders(3,orderdto.OrderDate, Convert.ToInt32(userId) , items);
            foreach (var item in orderdto.Items)
            {
                Products product = _productRepository.GetProductByID(item.ProductId);
                if (product != null)
                {
                    product.DecreaseStock(item.Quantity);
                    Console.WriteLine(product.Stock.quantity);
                }
                else
                {
                    return Result<OrderResponseDTO>.FailureResult("Product not found");
                }

            }

            OrderResponseDTO order_respon = new OrderResponseDTO
            {
                OrderDate = order.OrderDate,
                Items = order.Items.Select(i => new OrderItemResponseDTO
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quanlity
                }).ToList()
            };
            return Result<OrderResponseDTO>.SuccessResult(order_respon);
        }

    }
}