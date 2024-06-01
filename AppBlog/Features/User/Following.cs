using AppBlog.Data;
using AppBlog.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AppBlog.Models.Domain;
using AppBlog.Utils;

namespace AppBlog.Features.User
{
    public class Following
    {
        public class Query : IRequest<ResponseResult2<string>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ResponseResult2<string>>
        {
            private readonly AppDbContext db;
            private readonly ICurrentUserAccessor userAccessor;

            public Handler(AppDbContext db, ICurrentUserAccessor userAccessor)
            {
                this.db = db;
                this.userAccessor = userAccessor;
            }

            public async Task<ResponseResult2<string>> Handle(Query request, CancellationToken cancellationToken)
            {
                var observer = await db.Users.FirstOrDefaultAsync(x => x.Email == userAccessor.GetCurrentUserEmail());
                if (observer == null) return ResponseResult2<string>.Fail(EFollowStatus.NotFoundObserver.ToString());

                var target = await db.Users.FindAsync(request.Id);
                if (target == null) return ResponseResult2<string>.Fail(EFollowStatus.NotFoundTarget.ToString());

                if (observer.Id == target.Id) return ResponseResult2<string>.Fail(EFollowStatus.DuplicateId.ToString());
                EFollowStatus status;

                var following = await db.UserFollowings.FindAsync(observer.Id, target.Id);
                var follower = await db.UserFollowers.FindAsync(target.Id, observer.Id);

                if (following == null)
                {
                    status = EFollowStatus.Following;
                    await db.UserFollowings.AddAsync(new UserFollowing
                    {
                        Observer = observer,
                        Target = target,
                    });
                }
                else
                {
                    status = EFollowStatus.Unfollow;
                    db.UserFollowings.Remove(following);
                }

                if (follower == null)
                {
                    await db.UserFollowers.AddAsync(new UserFollower
                    {
                        Observer = target,
                        Target = observer
                    });
                }
                else
                {
                    db.UserFollowers.Remove(follower);
                }

                await db.SaveChangesAsync();
                return ResponseResult2<string>.Success(status.ToString());
            }
        }
    }
}
