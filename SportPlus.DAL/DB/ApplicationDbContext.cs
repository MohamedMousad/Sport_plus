using SportPlus.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace SportPlus.DAL.DB
{
        public class ApplicationDbContext : IdentityDbContext<User>
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
        }
}

