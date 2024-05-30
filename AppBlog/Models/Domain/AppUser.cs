using Microsoft.AspNetCore.Identity;

namespace AppBlog.Models.Domain
{
    public class AppUser : IdentityUser
    {
        public string NickName { get; set; }
    }
}
