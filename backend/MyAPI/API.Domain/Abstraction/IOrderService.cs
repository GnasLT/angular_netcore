using API.Application.DTO.Request;
using API.Application.DTO.Response;
using API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Abstractions
{
    public interface IOrderService
    {
        public Task <Result<OrderResponseDTO>> CreateOrder(OrderRequestDTO orders, string userId);

    }
}