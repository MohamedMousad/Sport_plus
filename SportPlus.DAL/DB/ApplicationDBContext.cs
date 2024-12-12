using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportPlus.DAL.Entities;
using System.Configuration;
using System.Reflection;


namespace SportPlus.DAL.DB
{
	public class ApplicationDbContext :IdentityDbContext<User>
	{
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}