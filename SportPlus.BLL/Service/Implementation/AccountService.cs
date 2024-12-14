using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SportPlus.BLL.Images;
using SportPlus.BLL.ModelVM.Account;
using SportPlus.DAL.Repo.Abstraction;
using SportPlus.DAL.Entities;
using SportPlus.BLL.ModelVM.User;
using SportPlus.BLL.Service.Abstraction;
namespace SportPlus.BLL.Service.Implementation
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepo UserRepo;
		private readonly IMapper mapper;

		public AccountService(IAccountRepo UserRepo, IMapper mapper)
		{
			this.UserRepo = UserRepo;
			this.mapper = mapper;
		}
		public async Task<UserProfileVM> GetProfile(ClaimsPrincipal user)
		{
			var User = await UserRepo.GetUserAsync(user);
			if (User == null) return null;

			var UserProfileVM = mapper.Map<UserProfileVM>(User);
			return UserProfileVM;
		}
		public async Task<IdentityResult> UpdateUser(User User)
		{
			return await UserRepo.UpdateUserAsync(User);
		}

		public async Task<EditUserVM> GetUserForEdit(ClaimsPrincipal user)
		{
			var User = await UserRepo.GetUserAsync(user);
			if (User == null)
			{
				return null;
			}
			return mapper.Map<EditUserVM>(User);
		}
		public async Task<UserProfileVM> GetUserForMoreInfo(ClaimsPrincipal user)
		{
			var User = await UserRepo.GetUserAsync(user);
			if (User == null)
			{
				return null;
			}
			return mapper.Map<UserProfileVM>(User);
		}
		public async Task<IdentityResult> UpdateUser(ClaimsPrincipal user, EditUserVM model)
		{
			var User = await UserRepo.GetUserAsync(user);

			if (User == null)
			{
				return IdentityResult.Failed(new IdentityError { Description = "User not found" });
			}
			if (model.NewProfileImage != null && model.NewProfileImage.Length > 0)
			{
				var uploadedFileName = UploadImage.UploadFile("Photo", model.NewProfileImage);
				model.Image = uploadedFileName;
			}
			mapper.Map(model, User);
			return await UserRepo.UpdateUserAsync(User);
		}

		public async Task<User> GetCurrentUser(ClaimsPrincipal user)
		{
			return await UserRepo.GetUserAsync(user);
		}

		public async Task<IdentityResult> DeleteUserAccount(ClaimsPrincipal user)
		{
			var User = await UserRepo.GetUserAsync(user);
			if (User == null)
			{
				return IdentityResult.Failed(new IdentityError { Description = "User not found" });
			}

			var result = await UserRepo.UpdateUserAsync(User);

			if (result.Succeeded)
			{
				await UserRepo.SignOutAsync();
			}

			return result;
		}

		public async Task<LoginVM> GetLoginViewModelAsync()
		{
			var schemes = await UserRepo.GetExternalAuthenticationSchemesAsync();
			return new LoginVM
			{
				Schemes = schemes
			};
		}

		public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginVM loginVM)
		{
			var User = await UserRepo.FindByEmailAsync(loginVM.Email);
			if (User == null)
			{
				return Microsoft.AspNetCore.Identity.SignInResult.Failed;
			}

			var passwordCheck = await UserRepo.CheckPasswordAsync(User, loginVM.Password);
			if (!passwordCheck)
			{
				await UserRepo.AccessFailedAsync(User);
				return Microsoft.AspNetCore.Identity.SignInResult.Failed;
			}

			var result = await UserRepo.PasswordSignInAsync(User, loginVM.Password, false, false);
			return result;
		}

		public async Task<bool> IsLockedOut(User User)
		{
			return await UserRepo.IsLockedOutAsync(User);
		}

		public async Task<IdentityResult> RegisterUserAsync(RegistrationVM registerVM)
		{
			// Check if user exists
			var existingUser = await UserRepo.FindByEmailAsync(registerVM.Email);
			if (existingUser != null)
			{
				return IdentityResult.Failed(new IdentityError
				{
					Description = "Email address is already in use."
				});
			}

			// Handle file upload
			string uploadedFileName = null;
			if (registerVM.ProfileImage != null)
			{
				uploadedFileName = UploadImage.UploadFile("Photo", registerVM.ProfileImage);
			}

			// Use AutoMapper to map RegistrationVM to User
			var newUser = mapper.Map<User>(registerVM);
			newUser.Image = uploadedFileName;
			newUser.LockoutEnabled = true;

			var userCreated = await UserRepo.CreateUserAsync(newUser, registerVM.Password);

			if (userCreated.Succeeded)
			{
				await UserRepo.PasswordSignInAsync(newUser, registerVM.Password);
			}

			return userCreated;
		}
		public async Task Logout()
		{
			await UserRepo.SignOutAsync();
		}

		public Task<IdentityResult> ChangePassword(ChangePasswordAccountVM model)
		{
			throw new NotImplementedException();
		}
	}
}