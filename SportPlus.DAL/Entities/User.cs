using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 letter")]
        [MinLength(3, ErrorMessage = "NAme must be greater than 3 letter")]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"(Male|Famale)", ErrorMessage = "Gender Must be Male or Fmale")]
        public string Gender { get; set; } = string.Empty;

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Image { get; set; }
        public DateTime DOB { get; set; } = DateTime.Now;
        public string FavoriteTeam { get; set; }
    }
}
}
