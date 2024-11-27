using System.ComponentModel.DataAnnotations;
namespace SportPlus.BLL.ModelVM.Account
{
    public class ConfirmEmailLoginVM
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        //[CustomEmailValidator(ErrorMessage = "Email address is not valid (custom)")]
        public string EmailAddress { get; set; }
    }

}
