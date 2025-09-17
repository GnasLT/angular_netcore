

using System.ComponentModel.DataAnnotations;

namespace API.Application.DTO.Request
{
    public class UserRequestDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

}