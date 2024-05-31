using AppBlog.Models.Domain;

namespace AppBlog.Services
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}
