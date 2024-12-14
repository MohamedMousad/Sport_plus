using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using SportPlus.BLL.ModelVM.Account;
using SportPlus.BLL.ModelVM.User;
using SportPlus.BLL.Service.Abstraction;
using SportPlus.DAL.Entities;
using System.Security.Claims;

namespace SportPlus.PLL.Controllers
{
    public class AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration, IAccountService userService) : Controller
    {

        // repo 
        private readonly SignInManager<User> _signInManager = signInManager;
        private readonly UserManager<User> _userManager = userManager;
        private readonly IAccountService userService = userService;
        private readonly IConfiguration _configuration = configuration;

        //CRUD
        //1 represent profile of user 
        public async Task<IActionResult> Profile()
        {
            var UserProfileVM = await userService.GetProfile(User);
            if (UserProfileVM == null)
            {
                return View("Register");
            }

            return View(UserProfileVM);
        }
        //2 update 
        public async Task<IActionResult> UpdateProfile()
        {
            var model = await userService.GetUserForEdit(User);
            if (model == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(EditUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userService.UpdateUser(User, model);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            TempData["SuccessMessage"] = "Your profile has been updated successfully!";
            return RedirectToAction("Profile", "Account");
        }
        //3 delete
        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var user = await userService.GetCurrentUser(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount()
        {
            var result = await userService.DeleteUserAccount(User);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Your account has been deactivated.";
                return RedirectToAction("Register", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("DeleteAccount");
        }
        //4 update password
        public IActionResult ChangePassword() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordAccountVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userService.ChangePassword(model);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            TempData["SuccessMessage"] = "Password changed successfully.";
            return RedirectToAction("Profile", "Account");
        }
        //login
        public async Task<IActionResult> Login()
        {
            var loginVM = await userService.GetLoginViewModelAsync();
            return View(loginVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginVM);
            }

            var result = await userService.Login(loginVM);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            if (result.IsNotAllowed)
            {
                return RedirectToAction("EmailConfirmation", "Account");
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account is locked. Please try again later.");
                return View("Login", loginVM);
            }
            ModelState.AddModelError("", "Invalid login attempt. Please check your email and password.");
            return View("Login", loginVM);
        }
        // register(create user)
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", registerVM);
            }

            var result = await userService.RegisterUserAsync(registerVM);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("Register", registerVM);
        }

        //logout
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return RedirectToAction("Index", "Home");
        }

        // email confirmation

        public Task<IActionResult> EmailConfirmation()
        {
            var confirmEmail = new ConfirmEmailLoginVM();
            return Task.FromResult<IActionResult>(View(confirmEmail));
        }

        public async Task<IActionResult> SendEmailConfirmation(ConfirmEmailLoginVM confirmEmailLoginVM)
        {

            var user = await _userManager.FindByEmailAsync(confirmEmailLoginVM.EmailAddress);

            //2. Create a confirmation link
            if (user != null)
            {
                var userToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var userConfirmationLink = Url.Action("EmailConfirmationVerified", "Account", new { userId = user.Id, userConfirmationToken = userToken }, Request.Scheme);

                //3. Send the email
                var apiKey = _configuration["SendGrid:ShortlyKey"];
                var sendGridClient = new SendGridClient(apiKey);

                var fromEmailAddress = new EmailAddress(_configuration["SendGrid:FromAddress"], "SportPlus");
                var emailSubject = "[Shortly] Verify your account";
                var toEmailAddress = new EmailAddress(confirmEmailLoginVM.EmailAddress);

                var emailContentTxt = $"Hello from SportPlus Please, click this link to verify your account: {userConfirmationLink}";
                var emailContentHtml = $"Hello from  SportPlus Please, click this link to verify your account: <a href=\"{userConfirmationLink}\"> Verify your account </a> ";

                var emailRequest = MailHelper.CreateSingleEmail(fromEmailAddress, toEmailAddress, emailSubject, emailContentTxt, emailContentHtml);
                await sendGridClient.SendEmailAsync(emailRequest);

                TempData["EmailConfirmation"] = "Thank you! Please, check your email to verify your account";

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", $"Email address {confirmEmailLoginVM.EmailAddress} does not exist");
            return View("EmailConfirmation", confirmEmailLoginVM);
        }

        public async Task<IActionResult> EmailConfirmationVerified(string userId, string userConfirmationToken)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            await _userManager.ConfirmEmailAsync(user, userConfirmationToken);
            TempData["EmailConfirmationVerified"] = "Thank you! Your account has been confirmed. You can now log in!";
            return RedirectToAction("Login", "Account");
        }

        // for forget password by used email when user login 
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            if (ModelState.IsValid && model != null && !string.IsNullOrEmpty(model.Email))
            {
                // Find the user by email

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    // Display success even if the user doesn't exist to avoid revealing user information
                    return View("ForgotPasswordConfirmation");
                }

                // Generate the password reset token
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                // Create the password reset link
                var resetLink = Url.Action("ResetPassword", "Account", new { token = resetToken, email = model.Email }, Request.Scheme);

                // Send password reset email (You can use SendGrid here like you did for email confirmation)
                var apiKey = _configuration["SendGrid:ShortlyKey"];
                var sendGridClient = new SendGridClient(apiKey);

                var fromEmailAddress = new EmailAddress(_configuration["SendGrid:FromAddress"], "SportPlus");
                var emailSubject = "Reset your password";
                var toEmailAddress = new EmailAddress(model.Email);

                var emailContentTxt = $"Please, click this link to reset your password: {resetLink}";
                var emailContentHtml = $"Please, click this link to reset your password: <a href=\"{resetLink}\"> Reset Password </a>";

                var emailRequest = MailHelper.CreateSingleEmail(fromEmailAddress, toEmailAddress, emailSubject, emailContentTxt, emailContentHtml);
                await sendGridClient.SendEmailAsync(emailRequest);

                // Show confirmation page
                return View("ForgotPasswordConfirmation");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }


        //  reset password used after login ,excit in user profile
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            ResetPasswordVM model = new();
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token.");
            }
            else
            {
                model.Token = token;
                model.Email = email;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        public IActionResult ResetPasswordConfirmation()
        {
            TempData["ResetPasswordConfirmation"] = "Now you can LogIn";
            return View();
        }

        // used google for login (external login)
        public IActionResult ExternalLogin(string provider, string returnUrl = "")
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string remoteError = "")
        {

            var loginVM = new LoginVM()
            {
                Schemes = await _signInManager.GetExternalAuthenticationSchemesAsync()
            };

            if (!string.IsNullOrEmpty(remoteError))
            {
                ModelState.AddModelError("", $"Error from extranal login provide: {remoteError}");
                return View("Login", loginVM);
            }

            //Get login info
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError("", $"Error from extranal login provide: {remoteError}");
                return View("Login", loginVM);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
                return RedirectToAction("Index", "Home");
            else
            {
                var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (!string.IsNullOrEmpty(userEmail))
                {
                    var user = await _userManager.FindByEmailAsync(userEmail);

                    if (user == null)
                    {
                        user = new User()
                        {
                            UserName = userEmail,
                            Email = userEmail,
                            EmailConfirmed = true

                        };

                        await _userManager.CreateAsync(user);
                        //  await _userManager.AddToRoleAsync(user, "User");
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    TempData["ExternalLoginCallback"] = "Please,Complete the required information";
                    return RedirectToAction("Index", "Home");
                }

            }

            ModelState.AddModelError("", $"Something went wrong");
            return View("Login", loginVM);
        }



        public async Task<IActionResult> ProfileInfo()
        {
            var model = await userService.GetUserForMoreInfo(User);
            if (model == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }
    }
}
