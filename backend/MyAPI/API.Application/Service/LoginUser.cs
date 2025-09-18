using System.Security.Claims;
using API.Application.Abstractions;
using API.Application.DTO.Request;
using API.Application.DTO.Response;
using API.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace API.Application.Service
{

    public class LoginUser : IAuthenService
    {
        private readonly IUserRepository _userRepository;

        public LoginUser(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<UserResponseDTO> Login(UserRequestDTO userRequest)
        {
            var user = _userRepository.GetUserByEmail(new VEmail(userRequest.Email));
            if (user == null)
            {
                return new UserResponseDTO()
                {
                    Message = "User not found",
                    Success = false
                };
            }

            if(user.Password.Value != userRequest.Password)
            {
                return new UserResponseDTO()
                {
                    Message = "Invalid password",
                    Success = false
                };
            }
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email.Value),
                new Claim(ClaimTypes.Role, user.Role.Name)

            };
            return new UserResponseDTO()
            {
                Message = "User logged in successfully",
                Success = true,
                Claim = claims
            };
        }


    }
    
}