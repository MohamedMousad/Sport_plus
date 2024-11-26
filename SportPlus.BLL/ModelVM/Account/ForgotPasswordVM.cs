using System.ComponentModel.DataAnnotations;


namespace SportPlus.BLL.ModelVM.Account
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
