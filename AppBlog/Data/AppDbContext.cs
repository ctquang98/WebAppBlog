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

        public DbSet<UserFollowing> UserFollowings { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
