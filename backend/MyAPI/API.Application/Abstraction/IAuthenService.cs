

using API.Application.DTO.Request;
using API.Application.DTO.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Abstractions
{
    public interface IAuthenService
    {
        public Task<UserResponseDTO> Login(UserRequestDTO userRequest);

        
    }
}