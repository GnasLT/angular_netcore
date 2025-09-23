

using API.Application.DTO.Request;
using API.Application.DTO.Response;
using API.Domain.Entities;

namespace API.Application.Abstractions
{
    public interface IProductService
    {
        public IEnumerable<Products> GetAllProducts();

        public Task<Result<ProductReponseDTO>> AddProduct(ProductRequestDTO productRequest);

        public Task<Result<ProductReponseDTO>> UpdateProduct(ProductRequestDTO productRequest);
        
        public Task DeleteProduct(int productId);
    }
}