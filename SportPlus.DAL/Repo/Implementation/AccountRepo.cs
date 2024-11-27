using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SportPlus.DAL.Repo.Abstraction;
using SportPlus.DAL.Entities;

namespace SportPlus.DAL.Repo.Implementation
{
    public class AccountRepo : IAccountRepo
    { 
        // repo -> used usermanager and signmanager
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        //ctor
        public AccountRepo(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //CRUD
        //1 read one 
        public async Task<User> GetUserAsync(ClaimsPrincipal user)
        {
            return await userManager.GetUserAsync(user);
        }

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

        public async Task<IdentityResult> UpdateUserAsyn(User User)
        {
            return await userManager.UpdateAsync(User);
        }
        // log out
        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
        public async Task<User> FindByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        //  CheckPassword
        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
        }
        //  ChangePassword
        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            return await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task RefreshSignInAsync(User user)
        {
            await signInManager.RefreshSignInAsync(user);
        }

        public async Task<SignInResult> PasswordSignInAsync(User User, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await signInManager.PasswordSignInAsync(User, password, isPersistent, lockoutOnFailure);
        }

        public async Task<IdentityResult> AccessFailedAsync(User User)
        {
            return await userManager.AccessFailedAsync(User);
        }

        public async Task<bool> IsLockedOutAsync(User User)
        {
            return await userManager.IsLockedOutAsync(User);
        }

        public async Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
        {
            return await signInManager.GetExternalAuthenticationSchemesAsync();
        }
        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

        public async Task AddToRoleAsync(User user, string role)
        {
            await userManager.AddToRoleAsync(user, role);
        }

        public async Task<SignInResult> PasswordSignInAsync(User user, string password)
        {
            return await signInManager.PasswordSignInAsync(user, password, false, false);
        }
    }

}
