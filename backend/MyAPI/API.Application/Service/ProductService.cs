

using API.Application.Abstractions;
using API.Application.DTO.Request;
using API.Application.DTO.Response;
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

        public async Task<Result<ProductReponseDTO>> AddProduct(ProductRequestDTO productRequest)
        {
            foreach (var item in productRequest.Items)
            {
                Products temp = _productRepository.GetProductByID(item.Id);
                if (temp != null)
                {
                    _productRepository.AddProduct(item.Name, item.Price, item.Stock);
                }
                else
                {
                   _productRepository.IncreaseStock(item.Id, item.Stock);
                }
            }
            return null;
        }
    }
}