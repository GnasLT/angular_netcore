

using System.Security.Claims;

namespace API.Application.DTO.Response
{
    public class UserResponseDTO
    {
        public bool Success { get; set; }
        
        public string? Message { get; set; }
        
        public IEnumerable<Claim>? Claim { get; set; }
    }
    
}