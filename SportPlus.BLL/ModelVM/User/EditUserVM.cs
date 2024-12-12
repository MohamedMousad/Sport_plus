using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportPlus.DAL.Enums;

namespace SportPlus.BLL.ModelVM.User
{
    public class EditUserVM
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
         public IFormFile? NewProfileImage { get; set; }
        public string? Country { get; set; }
        public FavouriteTeam? FavouriteTeam { get; set; } 
    }
}
