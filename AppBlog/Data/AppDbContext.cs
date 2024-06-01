using AppBlog.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppBlog.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Boxer> boxers { get; set; }
        public DbSet<UserFollowing> UserFollowings { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }

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

            builder.Entity<UserFollowing>(x =>
            {
                x.HasKey(j => new { j.ObserverId, j.TargetId });
                x.HasOne(x => x.Observer)
                .WithMany(x => x.followings)
                .HasForeignKey(x => x.ObserverId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<UserFollower>(x =>
            {
                x.HasKey(j => new { j.ObserverId, j.TargetId });
                x.HasOne(x => x.Observer)
                .WithMany(x => x.followers)
                .HasForeignKey(x => x.ObserverId)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
