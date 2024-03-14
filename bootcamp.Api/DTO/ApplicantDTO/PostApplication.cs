using System.ComponentModel.DataAnnotations;

namespace bootcamp.Api.DTO.ApplicantDTO
{
    public class PostApplication
    {
        [Required(ErrorMessage = "Fullname is required")]
        [StringLength(100)]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "Fullname is required")]
        [StringLength(100)]
        public string? Lastname { get; set; }


        [Required(ErrorMessage = "Email Address is required")]
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
