using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportPlus.DAL.Enums;


namespace SportPlus.DAL.Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 letter")]
        [MinLength(3, ErrorMessage = "NAme must be greater than 3 letter")]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public Gender Gender { get; set; } 
        public int? Age { get; set; }    
        public string? Country { get; set; }
        public string? Image { get; set; }
        public  FavouriteTeam? FavouriteTeam  { get; set; }
    }
}
