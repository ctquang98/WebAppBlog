using AppBlog.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AppBlog.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Boxer> boxers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed
            var _boxers = new List<Boxer>()
            {
                new Boxer { Id = Guid.NewGuid(), Name = "LongG" },
                new Boxer { Id = Guid.NewGuid(), Name = "Decal" },
                new Boxer { Id = Guid.NewGuid(), Name = "J98" },
                new Boxer { Id = Guid.NewGuid(), Name = "Yangby" },
            };

            builder.Entity<Boxer>().HasData(_boxers);
        }
    }
}
