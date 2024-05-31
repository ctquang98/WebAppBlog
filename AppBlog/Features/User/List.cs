using AppBlog.Data;
using AppBlog.Models.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppBlog.Features.User
{
    public class List
    {
        public class Query : IRequest<List<AppUser>> { }

        public class Handler : IRequestHandler<Query, List<AppUser>>
        {
            private readonly AppDbContext db;

            public Handler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<List<AppUser>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await db.Users.ToListAsync();
            }
        }
    }
}
