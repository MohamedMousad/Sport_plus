using Microsoft.AspNetCore.Http;
using SportPlus.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace SportPlus.BLL.ModelVM.Account
{
    public class RegistrationVM
	{
		// in this page we used validation client side 
	
		public string? FullName { get; set; }

		
		public required string UserName { get; set; }

		
		public required string Email { get; set; }

		//[Required(ErrorMessage = "Password is required")]
		//[DataType(DataType.Password)]
		//[PasswordRules(ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
		public required string Password { get; set; }

	
		public required string ConfirmPassword { get; set; }

		
		public string? PhoneNumber { get; set; }

		public string? Country { get; set; }

		public FavouriteTeam? FavouriteTeam { get; set; }

		public Gender? Gender { get; set; } = DAL.Enums.Gender.notset;

		public IFormFile? ProfileImage { get; set; }
		public string? Name {  get; set; }
	}
}
