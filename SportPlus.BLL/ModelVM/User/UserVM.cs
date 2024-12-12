using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportPlus.BLL.ModelVM.User
{
    public class UserVM
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 characters")]
        [MinLength(3, ErrorMessage = "Name must be greater than 3 characters")]
        public required string FullName { get; set; }
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public IFormFile? FormFile { get; set; }
        public string? Country { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
