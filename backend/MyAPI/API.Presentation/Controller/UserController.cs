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

        public UserController(IAuthenService authenService)
        {

            this._authenService = authenService;
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

        // [HttpPost("/register")]
        // public async Task<Result<UserResponseDTO>> Register([FromBody] UserRequestDTO userRequest)
        // {
        //     return await _authenService.Register(userRequest);
        // }


        

    }
}


