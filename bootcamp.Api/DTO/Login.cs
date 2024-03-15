using System.ComponentModel.DataAnnotations;

namespace bootcamp.Api.DTO
{
    public class Login
    {
        [Required(ErrorMessage = "Enter your username, email or phone")]
        [StringLength(20)]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [StringLength(20)]
        public string? Password { get; set; }
    }
}
