using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SportPlus.DAL.Entities;
using SportPlus.DAL.Repo.Abstraction;
using System.Security.Claims;

namespace SportPlus.DAL.Repo.Implementation
{
    public class AccountRepo(UserManager<User> userManager, SignInManager<User> signInManager) : IAccountRepo
    {
        // repo -> used usermanager and signmanager
        private readonly UserManager<User> userManager = userManager;
        private readonly SignInManager<User> signInManager = signInManager;

        //CRUD
        //1 read one 
        public async Task<User> GetUserAsync(ClaimsPrincipal user) => await userManager.GetUserAsync(user);

        //2 update
        public async Task<IdentityResult> UpdateUserAsync(User User)
        {
            var result = await userManager.UpdateAsync(User);
            if (result.Succeeded)
            {
                await signInManager.RefreshSignInAsync(User);
            }

            return result;
        }

        public async Task<IdentityResult> UpdateUserAsyn(User User) => await userManager.UpdateAsync(User);
        // log out
        public async Task SignOutAsync() => await signInManager.SignOutAsync();
        public async Task<User> FindByEmailAsync(string email) => await userManager.FindByEmailAsync(email);

        //  CheckPassword
        public async Task<bool> CheckPasswordAsync(User user, string password) => await userManager.CheckPasswordAsync(user, password);
        //  ChangePassword
        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword) => await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

        public async Task RefreshSignInAsync(User user) => await signInManager.RefreshSignInAsync(user);

        public async Task<SignInResult> PasswordSignInAsync(User User, string password, bool isPersistent, bool lockoutOnFailure) => await signInManager.PasswordSignInAsync(User, password, isPersistent, lockoutOnFailure);

        public async Task<IdentityResult> AccessFailedAsync(User User) => await userManager.AccessFailedAsync(User);

        public async Task<bool> IsLockedOutAsync(User User) => await userManager.IsLockedOutAsync(User);

        public async Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync() => await signInManager.GetExternalAuthenticationSchemesAsync();
        public async Task<IdentityResult> CreateUserAsync(User user, string password) => await userManager.CreateAsync(user, password);

        //public async Task AddToRoleAsync(User user, string role)
        //{
        //    await userManager.AddToRoleAsync(user, role);
        //}

        public async Task<SignInResult> PasswordSignInAsync(User user, string password) => await signInManager.PasswordSignInAsync(user, password, false, false);
    }
}
