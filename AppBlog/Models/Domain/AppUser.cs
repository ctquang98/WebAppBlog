using Microsoft.AspNetCore.Identity;

namespace AppBlog.Models.Domain
{
    public class AppUser : IdentityUser
    {
        public string NickName { get; set; } = "";
        public List<UserFollowing> followings { get; set; } = new List<UserFollowing>();
        public List<UserFollower> followers { get; set; } = new List<UserFollower>();
    }
}
