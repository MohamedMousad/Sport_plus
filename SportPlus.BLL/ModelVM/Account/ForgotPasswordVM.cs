using System.ComponentModel.DataAnnotations;


namespace SportPlus.BLL.ModelVM.Account
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
