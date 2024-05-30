using AppBlog.Data;
using AppBlog.Models.Domain;
using MediatR;

namespace AppBlog.Features.Boxers
{
    public class Detail
    {
        public class Query : IRequest<Boxer>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Boxer>
        {
            private readonly AppDbContext db;

            public Handler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<Boxer> Handle(Query request, CancellationToken cancellationToken)
            {
                return await db.boxers.FindAsync(request.Id);
            }
        }
    }
}
