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

        public async Task<Result<UserResponseDTO>> Login(UserRequestDTO userRequest)
        {
            var user = _userRepository.GetUserByEmail(new VEmail(userRequest.Email));
            if (user == null)
            {
                return Result<UserResponseDTO>.FailureResult("User not found");
            }

            if(user.Password.Value != userRequest.Password)
            {
                return Result<UserResponseDTO>.FailureResult("Invalid password");
            }
            
            var claims = new List<Claim>
            {
                
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name)

            };
            UserResponseDTO userResponse = new UserResponseDTO
            {
                Claim = claims
            };
            return Result<UserResponseDTO>.SuccessResult(userResponse, "User logged in successfully");
            
        }


    }
    
}