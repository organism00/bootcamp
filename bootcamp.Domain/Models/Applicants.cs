using bootcamp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace bootcamp.Domain.Models
{
    public class Applicants
    {
        [Key]
        public Guid ApplicantId { get; set; } = new Guid();
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public AccountStatus Status { get; set; } = AccountStatus.user;
        public DateTime AccountCreatedAt { get; set; }
        public DateTime AccountUpdatedAt { get; set; }
    }
   
}