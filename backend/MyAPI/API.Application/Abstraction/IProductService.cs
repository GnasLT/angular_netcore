

using API.Domain.Entities;

namespace API.Application.Abstractions
{
    public interface IProductService
    {
        public IEnumerable<Products> GetAllProducts();
        
    }
}