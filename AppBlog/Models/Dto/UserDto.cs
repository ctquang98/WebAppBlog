namespace AppBlog.Models.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Nickname { get; set; }
        public string Token { get; set; }
        public List<UserFollowingDto> followings { get; set; } = new List<UserFollowingDto>();
        public List<UserFollowerDto> followers { get; set; } = new List<UserFollowerDto>();
    }
}
