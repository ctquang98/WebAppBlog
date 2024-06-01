using AppBlog.Data;
using AppBlog.Models.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AppBlog.Features.User
{
    public class Edit
    {
        public class Command : IRequest<AppUser>
        {
            public AppUser user;
        }

        public class Handler : IRequestHandler<Command, AppUser>
        {
            private readonly AppDbContext db;

            public Handler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<AppUser> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await db.Users.FindAsync(request.user.Id);
                if (user == null) return null;

                user.UserName = request.user.UserName;
                user.NickName = request.user.NickName;

                var result = await db.SaveChangesAsync() > 0;
                return result ? user : null;
            }
        }
    }
}
