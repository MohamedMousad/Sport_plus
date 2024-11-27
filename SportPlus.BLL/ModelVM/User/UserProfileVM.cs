using Microsoft.AspNetCore.Http;

namespace SportPlus.BLL.ModelVM.User
{
    public class UserProfileVM
    {
        public string? Fullname { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Image { get; set; }
        public IFormFile? ImageName { get; set; }
    }
}
