using API.Application.Abstractions;
using API.Domain.Entities;
using API.Application.DTO.Request;

namespace API.Infrastructure.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private IEnumerable<Orders> _orders;

        public OrderRepository()
        {
            _orders = new List<Orders>
            {
                new Orders(1,DateTime.Now, 3 , new List<OrderItems>
                {
                    new OrderItems(1, 2),
                    new OrderItems(2, 3)
                }),
                new Orders(2,DateTime.Now, 4, new List<OrderItems>
                {
                    new OrderItems(3, 1),
                    new OrderItems(4, 4)
                })
            };
        }
        public Orders CreateOrder(Orders order)
        {

            _orders = _orders.Append(order);
            return order;
        }

        public void DeleteOrder(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}