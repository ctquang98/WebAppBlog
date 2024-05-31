using System.ComponentModel.DataAnnotations;

namespace AppBlog.Models.Dto
{
    public class RequestLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
