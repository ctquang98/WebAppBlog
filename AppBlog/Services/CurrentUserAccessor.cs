using System.Security.Claims;

namespace AppBlog.Services
{
    public class CurrentUserAccessor : ICurrentUserAccessor
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public CurrentUserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUserEmail()
        {
            return httpContextAccessor.HttpContext
                ?.User
                ?.Claims
                ?.FirstOrDefault(x => x.Type == ClaimTypes.Email)
                ?.Value;
        }
    }
}
