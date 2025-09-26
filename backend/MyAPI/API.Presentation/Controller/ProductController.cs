
using System.Security.Claims;
using API.Application.Abstractions;
using API.Application.DTO.Request;
using API.Application.DTO.Response;
using API.Application.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;
        private readonly IOrderService _orderService;

        public ProductController(IProductService productservice, IOrderService OrderService)
        {

            this._productservice = productservice;
            this._orderService = OrderService;
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("/getall")]
        public IActionResult GetAll()
        {
            return Ok(new { Enumerable = _productservice.GetAllProducts(), Message = "Get all products successfully" });
        }

        [Authorize(Roles = "Seller")]
        [HttpPut("/update")]
        public async Task<Result<ProductReponseDTO>> UpdateProduct([FromBody] ProductRequestDTO productRequest)
        {
            return await _productservice.UpdateProduct(productRequest);
        }

        [Authorize(Roles = "Seller")]
        [HttpDelete("/delete/{id}")]
        public Task DeleteProduct(int id)
        {
            return _productservice.DeleteProduct(id);
        }

        [Authorize(Roles = "Seller")]
        [HttpPost("/addproduct")]
        public async Task<Result<ProductReponseDTO>> AddProduct([FromBody] ProductRequestDTO productRequest)
        {
            return await _productservice.AddProduct(productRequest);
        }
        
        [Authorize(Roles = "Customer")]
        [HttpPost("/buying")]
        public async Task<Result<OrderResponseDTO>> Buying([FromBody] OrderRequestDTO orders)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _orderService.CreateOrder(orders, userId);
        }
    }
    
}