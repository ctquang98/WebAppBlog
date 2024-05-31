using AppBlog.Models.Domain;
using AppBlog.Models.Dto;
using AppBlog.Services;
using AppBlog.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public AccountController(UserManager<AppUser> userManager, IMapper mapper, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] RequestLoginDto body)
        {
            if (body?.Email == null) return Ok(ResponseResult<bool>.Error(EErrorCode.NotFound.ToString()));

            var user = await userManager.FindByEmailAsync(body.Email);
            if (user == null) return Ok(ResponseResult<bool>.Error(EErrorCode.InvalidEmail.ToString()));

            var isValid = await userManager.CheckPasswordAsync(user, body.Password);
            if (!isValid) return Ok(ResponseResult<bool>.Error(EErrorCode.InvalidPassword.ToString()));

            var userDto = mapper.Map<UserDto>(user);
            userDto.Token = tokenService.GenerateToken(user);
            return Ok(ResponseResult<UserDto>.Success(userDto));
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RequestRegisterDto body)
        {
            if (body?.Email == null) return Ok(ResponseResult<bool>.Error(EErrorCode.InvalidEmail.ToString()));
            if (body?.Password == null) return Ok(ResponseResult<bool>.Error(EErrorCode.InvalidPassword.ToString()));
            if (await userManager.Users.AnyAsync(x => x.Email == body.Email)) Ok(ResponseResult<bool>.Error(EErrorCode.EmailExisted.ToString()));

            var userRegister = new AppUser { Email = body.Email, UserName = body.Username };
            var result = await userManager.CreateAsync(userRegister, body.Password);
            if (!result.Succeeded) return Ok(ResponseResult<bool>.Error(EErrorCode.RegisterFailed.ToString()));

            var user = await userManager.FindByEmailAsync(body.Email);
            var userDto = mapper.Map<UserDto>(user);

            userDto.Token = tokenService.GenerateToken(user);
            return Ok(ResponseResult<UserDto>.Success(userDto));
        }
        //[HttpGet]
        //[Route("add_user_data")]
        //public async Task<IActionResult> AddUser()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        var user = new AppUser { Email = $"asd{i}", UserName = $"user_asd{i}" };
        //        await userManager.CreateAsync(user, "123");
        //    }
        //    return Ok(true);
        //}
    }
}
