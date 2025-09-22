

using System.Security.Claims;

namespace API.Application.DTO.Response
{
    public class UserResponseDTO 
    {
        public IEnumerable<Claim>? Claim { get; set; }
    }
    
}