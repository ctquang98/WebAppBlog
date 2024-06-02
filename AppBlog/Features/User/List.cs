using AppBlog.Data;
using AppBlog.Models.Domain;
using AppBlog.Models.Dto;
using AppBlog.Utils;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppBlog.Features.User
{
    public class List
    {
        public class Query : IRequest<ResponseResult2<List<UserListDto>>>
        {
            public UserListParams listParams;
        }

        public class Handler : IRequestHandler<Query, ResponseResult2<List<UserListDto>>>
        {
            private readonly AppDbContext db;
            private readonly IMapper mapper;

            public Handler(AppDbContext db, IMapper mapper)
            {
                this.db = db;
                this.mapper = mapper;
            }

            public async Task<ResponseResult2<List<UserListDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = db.Users
                    .ProjectTo<UserListDto>(mapper.ConfigurationProvider)
                    .AsQueryable();
                var (filterField, filterValue, sortField, sortAsc, page, pageSize) = request.listParams;

                if (!string.IsNullOrWhiteSpace(filterField) && !string.IsNullOrWhiteSpace(filterValue))
                {
                    var field = filterField.ToLower();
                    if (field == "username")
                    {
                        queryable = queryable.Where(x => x.UserName != null && x.UserName.Contains(filterValue));
                    }
                    else if (field == "nickname")
                    {
                        queryable = queryable.Where(x => x.Nickname.Contains(filterValue));
                    }
                }

                if (!string.IsNullOrWhiteSpace(sortField))
                {
                    var field = sortField.ToLower();
                    if (field == "username")
                    {
                        queryable = sortAsc ? queryable.OrderBy(x => x.UserName) : queryable.OrderByDescending(x => x.UserName);
                    }
                    else if (field == "nickname")
                    {
                        queryable = sortAsc ? queryable.OrderBy(x => x.Nickname) : queryable.OrderByDescending(x => x.Nickname);
                    }
                }

                int skipResult = (page - 1) * pageSize;
                var result = await queryable.Skip(skipResult).Take(pageSize).ToListAsync();
                return ResponseResult2<List<UserListDto>>.Success(result);
            }
        }
    }
}
