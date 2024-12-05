using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportPlus.BLL.Mapping;
using SportPlus.BLL.Service.Abstraction;
using SportPlus.BLL.Service.Implementation;
using SportPlus.DAL.DB;
using SportPlus.DAL.Entities;
using SportPlus.DAL.Repo.Abstraction;
using SportPlus.DAL.Repo.Implementation;

namespace SportPlus.PLL
{
    public class Program
    {
		public static void Main(string[] args)
		{

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Add DbContext with configuration
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<IAccountRepo, AccountRepo>();
			builder.Services.AddScoped<IAccountService, AccountService>();

			// Add AutoMapper
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			builder.Services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

//			builder.Services.AddAuthentication()
//			   .AddGoogle(options =>
//			   {
//#pragma warning disable CS8601 // Possible null reference assignment.
//				   options.ClientId = builder.Configuration["Auth:Google:ClientId"];
//#pragma warning restore CS8601 // Possible null reference assignment.
//#pragma warning disable CS8601 // Possible null reference assignment.
//				   options.ClientSecret = builder.Configuration["Auth:Google:ClientSecret"];
//#pragma warning restore CS8601 // Possible null reference assignment.
//			   });
//			builder.Services.AddAuthentication()
//			   .AddFacebook(options =>
//			   {
//#pragma warning disable CS8601 // Possible null reference assignment.
//				   options.AppId = builder.Configuration["Auth:Facebook:AppId"];
//#pragma warning restore CS8601 // Possible null reference assignment.
//#pragma warning disable CS8601 // Possible null reference assignment.
//				   options.AppSecret = builder.Configuration["Auth:Facebook:AppSecret"];
//#pragma warning restore CS8601 // Possible null reference assignment.
//			   });

			builder.Services.AddHttpClient();

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
				options =>
			{
				options.LoginPath = new PathString("/Account/Login");
				options.AccessDeniedPath = new PathString("/Account/Login");
			});
			builder.Services.Configure<IdentityOptions>(options =>
			{
				//Lockout settings
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

				//Signin settings
				options.SignIn.RequireConfirmedEmail = true;
			});

			

			using var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.MapStaticAssets();
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}")
				.WithStaticAssets();

			app.Run();
		}

	}
}
