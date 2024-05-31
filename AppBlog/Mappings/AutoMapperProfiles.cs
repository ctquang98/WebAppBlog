using AppBlog.Models.Domain;
using AppBlog.Models.Dto;
using AutoMapper;

namespace AppBlog.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Boxer, BoxerDto>().ReverseMap();
            CreateMap<AppUser, UserDto>()
                //.ForMember(userDto => userDto.Nickname, option => option.MapFrom(appUser => appUser.UserName))
                .ReverseMap();
        }
    }
}
