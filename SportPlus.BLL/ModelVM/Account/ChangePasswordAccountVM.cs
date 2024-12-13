
using System.ComponentModel.DataAnnotations;


namespace SportPlus.BLL.ModelVM.Account
{
    public class ChangePasswordAccountVM
    {
        [Required]
        public required string CurrentPassword { get; set; }
        [Required]
        public required string NewPassword { get; set; }
        [Required]
        public required string ConfirmPassword { get; set; }
    }
}
