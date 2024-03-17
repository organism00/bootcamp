using System.ComponentModel.DataAnnotations;

namespace bootcamp.Api.DTO.ApplicantDTO
{
    public class ApplicantLoginDto
    {
        [Required(ErrorMessage = "Email Address is required")]
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
