using AppBlog.Data;
using AppBlog.Models.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppBlog.Features.User
{
    public class Detail
    {
        public class Query : IRequest<AppUser?>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, AppUser?>
        {
            private readonly AppDbContext db;

            public Handler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<AppUser?> Handle(Query request, CancellationToken cancellationToken)
            {
                return await db.Users
                    .Include(x => x.followings)
                        .ThenInclude(x => x.Target)
                    .Include(x => x.followers)
                        .ThenInclude(x => x.Target)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
            }
        }
    }
}
