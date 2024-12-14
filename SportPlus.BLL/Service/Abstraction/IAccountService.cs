using SportPlus.BLL.ModelVM.Account;
using SportPlus.BLL.ModelVM.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SportPlus.DAL.Entities;

namespace SportPlus.BLL.Service.Abstraction
{
	public interface IAccountService
    {
        Task<UserProfileVM> GetProfile(ClaimsPrincipal user);
        Task<EditUserVM> GetUserForEdit(ClaimsPrincipal user);
        Task<UserProfileVM> GetUserForMoreInfo(ClaimsPrincipal user);
        Task<IdentityResult> UpdateUser(ClaimsPrincipal user, EditUserVM model);
        Task<User> GetCurrentUser(ClaimsPrincipal user);
        Task<IdentityResult> DeleteUserAccount(ClaimsPrincipal user);
        Task<IdentityResult> ChangePassword(ChangePasswordAccountVM model);
        // Task<User> GetCurrentUser();
        Task<IdentityResult> UpdateUser(User User);
        Task<LoginVM> GetLoginViewModelAsync();
        Task<SignInResult> Login(LoginVM loginVM);
        Task<IdentityResult> RegisterUserAsync(RegistrationVM registerVM);
        Task Logout();
        Task<bool> IsLockedOut(User User);
    }
}
