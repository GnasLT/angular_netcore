

using System.ComponentModel.DataAnnotations;

namespace API.Application.DTO.Request
{
    public class UserRequestDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

}