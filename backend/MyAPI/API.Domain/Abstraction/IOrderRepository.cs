using API.Application.DTO.Request;
using API.Domain.Entities;



namespace API.Application.Abstractions
{
    public interface IOrderRepository
    {
        public Orders CreateOrder(Orders orders);

    }
}