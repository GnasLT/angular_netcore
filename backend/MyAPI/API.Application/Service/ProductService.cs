

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
            ProductReponseDTO reponseDTO = new ProductReponseDTO();
            reponseDTO.OrderDate = productRequest.OrderDate;
            foreach (var item in productRequest.Items)
            {
                Products temp = _productRepository.GetProductByID(item.Id);
                if (temp == null)
                {
                    _productRepository.AddProduct(item.Id, item.Name, new VPrice(item.Price.Value, item.Price.Currency), new VStock(item.Stock.quantity));
                    reponseDTO.Items.Add(new ProductItemsResponseDTO
                    {
                        Name = item.Name,
                        Price = new VPriceDTO
                        {
                            Value = item.Price.Value,
                            Currency = item.Price.Currency
                        },
                        Stock = new VStockDTO
                        {
                            quantity = item.Stock.quantity
                        }
                    });
                }
                else
                {
                    return Result<ProductReponseDTO>.FailureResult("Product ID already exists");
                }
            }
            return Result<ProductReponseDTO>.SuccessResult(reponseDTO, "Add product successfully");
        }

        public Task<Result<ProductReponseDTO>> UpdateProduct(ProductRequestDTO productRequest)
        {
            ProductReponseDTO reponseDTO = new ProductReponseDTO();
            reponseDTO.OrderDate = productRequest.OrderDate;
            foreach (var item in productRequest.Items)
            {
                Products temp = _productRepository.GetProductByID(item.Id);
                if (temp != null)
                {
                    temp.UpdateProduct(item.Name, new VPrice(item.Price.Value, item.Price.Currency), new VStock(item.Stock.quantity));
                    reponseDTO.Items.Add(new ProductItemsResponseDTO
                    {
                        Name = item.Name,
                        Price = new VPriceDTO
                        {
                            Value = item.Price.Value,
                            Currency = item.Price.Currency
                        },
                        Stock = new VStockDTO
                        {
                            quantity = item.Stock.quantity
                        }
                    });
                }
                else
                {
                    return Task.FromResult(Result<ProductReponseDTO>.FailureResult("Product ID does not exist"));
                }
            }


            return Task.FromResult(Result<ProductReponseDTO>.SuccessResult(reponseDTO, "Update product successfully"));
        }

        public Task DeleteProduct(int productId)
        {
            Products temp = _productRepository.GetProductByID(productId);
            if (temp != null)
            {
                _productRepository.DeleteProduct(productId);
                return Task.CompletedTask;
            }
            else
            {
                throw new InvalidOperationException("Product ID does not exist");
            }
        }
    }
}