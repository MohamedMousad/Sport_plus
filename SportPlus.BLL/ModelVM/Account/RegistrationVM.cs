using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace SportPlus.BLL.ModelVM.Account
{
    public class RegistrationVM
	{
		// in this page we used validation client side 
	
		public string FullName { get; set; }

		
		public string UserName { get; set; }

		
		public string Email { get; set; }

		//[Required(ErrorMessage = "Password is required")]
		//[DataType(DataType.Password)]
		//[PasswordRules(ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
		public string Password { get; set; }

	
		public string ConfirmPassword { get; set; }

		
		public string PhoneNumber { get; set; }


		public string Gender { get; set; }

		public IFormFile? ProfileImage { get; set; }
		public string? Name {  get; set; }
	}
}
