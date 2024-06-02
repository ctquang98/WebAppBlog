using AppBlog.Data;
using AppBlog.Models.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppBlog.Features.User
{
    public class Delete
    {
        public class Command : IRequest<bool>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly AppDbContext db;
            //private readonly UserManager<AppUser> userManager;

            public Handler(AppDbContext db, UserManager<AppUser> userManager)
            {
                this.db = db;
                //this.userManager = userManager;
            }
            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                //var user = await userManager.FindByIdAsync(request.Id);
                //if (user == null) return true;

                //var result = await userManager.DeleteAsync(user);
                //return result.Succeeded;
                var user = await db.Users.FindAsync(request.Id);
                if (user == null) return true;

                var followings = await db.UserFollowings.Where(x => x.ObserverId == user.Id).ToListAsync();
                if (followings.Any()) db.UserFollowings.RemoveRange(followings);

                var followers = await db.UserFollowers.Where(x => x.ObserverId == user.Id).ToListAsync();
                if (followers.Any()) db.UserFollowers.RemoveRange(followers);

                db.Users.Remove(user);
                return await db.SaveChangesAsync() > 0;
            }
        }
    }
}
