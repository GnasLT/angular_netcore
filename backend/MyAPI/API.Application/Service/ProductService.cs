

using API.Application.Abstractions;
using API.Domain.Entities;

namespace API.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}