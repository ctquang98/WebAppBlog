using AppBlog.Data;
using AppBlog.Models.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppBlog.Features.Boxers
{
    public class List
    {
        public class Query : IRequest<List<Boxer>> {}

        public class Handler : IRequestHandler<Query, List<Boxer>>
        {
            private readonly AppDbContext db;

            // use mapper here cause error ??
            public Handler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<List<Boxer>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await db.boxers.ToListAsync();
            }
        }
    }
}
