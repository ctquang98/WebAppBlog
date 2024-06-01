using AppBlog.Data;
using AppBlog.Models.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppBlog.Features.User
{
    public class List
    {
        public class Query : IRequest<List<AppUser>>
        {
            public string? filterField { get; set; }
            public string? filterValue { get; set; }
            public string? sortField { get; set; }
            public bool sortAsc { get; set; } = true;
            public int page { get; set; } = 1;
            public int pageSize { get; set; } = 10;
        }

        public class Handler : IRequestHandler<Query, List<AppUser>>
        {
            private readonly AppDbContext db;

            public Handler(AppDbContext db)
            {
                this.db = db;
            }

            public async Task<List<AppUser>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = db.Users.AsQueryable();

                if (!string.IsNullOrWhiteSpace(request.filterField) && !string.IsNullOrWhiteSpace(request.filterValue))
                {
                    var field = request.filterField.ToLower();
                    if (field == "username")
                    {
                        queryable = queryable.Where(x => x.UserName != null && x.UserName.Contains(request.filterValue));
                    }
                    else if (field == "nickname")
                    {
                        queryable = queryable.Where(x => x.NickName.Contains(request.filterValue));
                    }
                }

                if (!string.IsNullOrWhiteSpace(request.sortField))
                {
                    var field = request.sortField.ToLower();
                    if (field == "username")
                    {
                        queryable = request.sortAsc ? queryable.OrderBy(x => x.UserName) : queryable.OrderByDescending(x => x.UserName);
                    }
                    else if (field == "nickname")
                    {
                        queryable = request.sortAsc ? queryable.OrderBy(x => x.NickName) : queryable.OrderByDescending(x => x.NickName);
                    }
                }

                int skipResult = (request.page - 1) * request.pageSize;
                return await queryable.Skip(skipResult).Take(request.pageSize).ToListAsync();
            }
        }
    }
}
