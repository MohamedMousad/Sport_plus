using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

            builder.Services.AddHttpClient();

            var app = builder.Build();

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
