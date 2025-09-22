using System.Security.Claims;
using System.Threading.Tasks;
using API.Application.Abstractions;
using API.Application.DTO.Request;
using API.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using API.Application.DTO.Response;

namespace API.Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenService _authenService;
        private readonly IProductRepository _productRepository;

        private readonly IOrderService _orderService;

        public UserController(IAuthenService authenService, IProductRepository productRepository, IOrderService orderService)
        {

            this._authenService = authenService;
            this._productRepository = productRepository;
            this._orderService = orderService;
        }

        [HttpPost("/login")]
        public async Task<Result<UserResponseDTO>> Login([FromBody] UserRequestDTO userRequest)
        {
            Result<UserResponseDTO> result = await _authenService.Login(userRequest);

            if (!result.Success)
            {
                return Result<UserResponseDTO>.FailureResult(result.Message);
            }

            var claimsIdentity = new ClaimsIdentity(
                result.Data.Claim,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            await HttpContext.SignInAsync(
                "MyCookieAuth",
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
                });

            return Result<UserResponseDTO>.SuccessResult(result.Data, result.Message);
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("/getall")]
        public IActionResult GetAll()
        {
            return Ok(new { Enumerable = _productRepository.GetAllProducts(), Message = "Get all products successfully" });
        }

        [Authorize(Roles = "Seller")]
        [HttpPost("/addproduct")]
        public async Task<Result<ProductReponseDTO>> AddProduct([FromBody] ProductRequestDTO productRequest)
        {
            _productRepository.AddProduct(productRequest);
            return null;
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


// next step: adding DI for interfaces and implementations, then implement the methods in the service and repository layers.