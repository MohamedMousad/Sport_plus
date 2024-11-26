using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authentication;

namespace SportPlus.DAL.Repo.Abstraction
{

        public interface IAccountRepo
        {
            Task<User> GetUserAsync(ClaimsPrincipal user);
            //  Task<User> GetCurrentUser();
            Task<IdentityResult> UpdateUserAsync(User User);
            Task<IdentityResult> UpdateUserAsyn(User User);
            Task<User> FindByEmailAsync(string email);
            Task<bool> CheckPasswordAsync(User user, string password);
            Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);
            Task RefreshSignInAsync(User user);
            Task<SignInResult> PasswordSignInAsync(User User, string password, bool isPersistent, bool lockoutOnFailure);
            Task<IdentityResult> AccessFailedAsync(User User);
            Task<bool> IsLockedOutAsync(User User);
            Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
            Task<IdentityResult> CreateUserAsync(User user, string password);
            Task AddToRoleAsync(User user, string role);
            Task<SignInResult> PasswordSignInAsync(User user, string password);
            Task SignOutAsync();

        }

    }


