using AppBlog.Models.Domain;
using AppBlog.Models.Dto;
using AutoMapper;

namespace AppBlog.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<AppUser, UserListDto>();
            CreateMap<UserFollowing, UserFollowingDto>()
                .ForMember(userFollowingDto => userFollowingDto.Id, option => option.MapFrom(userFollowing => userFollowing.TargetId))
                .ForMember(userFollowingDto => userFollowingDto.UserName, option => option.MapFrom(userFollowing => userFollowing.Target.UserName))
                .ForMember(userFollowingDto => userFollowingDto.NickName, option => option.MapFrom(userFollowing => userFollowing.Target.NickName));
            CreateMap<UserFollower, UserFollowerDto>()
                .ForMember(userFollowerDto => userFollowerDto.Id, option => option.MapFrom(userFollower => userFollower.TargetId))
                .ForMember(userFollowerDto => userFollowerDto.UserName, option => option.MapFrom(userFollower => userFollower.Target.UserName))
                .ForMember(userFollowerDto => userFollowerDto.NickName, option => option.MapFrom(userFollower => userFollower.Target.NickName));
        }
    }
}
