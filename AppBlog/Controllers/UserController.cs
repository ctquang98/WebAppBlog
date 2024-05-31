using AppBlog.Features.User;
using AppBlog.Models.Dto;
using AppBlog.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : AppBaseController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("get_all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await Mediator.Send(new List.Query());
            var usersDto = Mapper.Map<List<UserDto>>(users);
            return Ok(ResponseResult<List<UserDto>>.Success(usersDto));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get_by_id/{Id}")]
        public async Task<IActionResult> GetByEmail([FromRoute] string Id)
        {
            var user = await Mediator.Send(new Detail.Query() { Id = Id });
            if (user == null) return Ok(ResponseResult<bool>.Error(EErrorCode.NotFound.ToString()));

            var usersDto = Mapper.Map<UserDto>(user);
            return Ok(ResponseResult<UserDto>.Success(usersDto));
        }
    }
}
