using System.Security.Claims;
using System.Threading.Tasks;
using API.Application.Abstractions;
using API.Application.DTO.Request;
using API.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenService _authenService;
        private readonly IProductRepository _productRepository;

        public UserController(IAuthenService authenService, IProductRepository productRepository)
        {
            this._authenService = authenService;
            this._productRepository = productRepository;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] UserRequestDTO userRequest)
        {
            var result = await _authenService.Login(userRequest);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var claimsIdentity = new ClaimsIdentity(
                result.Claim,
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

            return Ok(new { Message = result.Message, });
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("/getall")]
        public IActionResult GetAll()
        {
            return Ok( new { Enumerable = _productRepository.GetAllProducts(), Message = "Get all products successfully" });
        }


    }
}


// next step: adding DI for interfaces and implementations, then implement the methods in the service and repository layers.