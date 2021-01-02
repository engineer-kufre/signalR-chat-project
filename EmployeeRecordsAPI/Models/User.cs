using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeRecordsAPI.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Entry is longer than 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Entry is longer than 30 characters")]
        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; } = DateTime.Now;
    }
}