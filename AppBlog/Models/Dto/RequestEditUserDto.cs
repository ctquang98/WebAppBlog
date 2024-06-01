using System.ComponentModel.DataAnnotations;

namespace AppBlog.Models.Dto
{
    public class RequestEditUserDto
    {
        [Required]
        public string UserName { get; set; }
        public string NickName { get; set; }
    }
}
