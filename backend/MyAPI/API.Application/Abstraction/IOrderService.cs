using API.Application.DTO.Request;
using API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Abstractions
{
    public interface IOrderService
    {
        public Task <IActionResult> CreateOrder(OrderRequestDTO orders);

    }
}