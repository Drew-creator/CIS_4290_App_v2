using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CIS4290_App.Models;

namespace CIS4290_App.Models
{
    public class ApplicationContext : IdentityDbContext<User> // inheriting from IdentityDbContext base class
    {
        public ApplicationContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CIS4290_App.Models.ApiData> ApiData { get; set; }
    }

}
