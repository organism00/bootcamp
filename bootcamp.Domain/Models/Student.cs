using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp.Domain.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }

        public string? Firstname { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? FamilyName { get; set; }
        public string? Nationality { get; set; }
        public string? Gender { get; set; }
        public string? Residence { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Bvn { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Street { get; set; }

        public string? HomeAddress { get; set; }
        public string? HashPassword { get; set; }
        public bool? AccountIsActivated { get; set; } = true;
        public bool? AccountIsDisabled { get; set; } = true;
        public List<Applicants>? UserAccounts { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;
    }
}
