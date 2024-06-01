using AppBlog.Features.User;
using AppBlog.Models.Domain;
using AppBlog.Models.Dto;
using AppBlog.Utils;
using MediatR;
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
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterField = "",
            [FromQuery] string? filterValue = "",
            [FromQuery] string? sortField = "",
            [FromQuery] bool sortAsc = true,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10
        )
        {
            var users = await Mediator.Send(new List.Query
            {
                filterField = filterField,
                filterValue = filterValue,
                sortField = sortField,
                sortAsc = sortAsc,
                page = page,
                pageSize = pageSize
            });
            var usersDto = Mapper.Map<List<UserListDto>>(users);
            return Ok(ResponseResult<List<UserListDto>>.Success(usersDto));
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

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Edit([FromRoute] string id, [FromBody] RequestEditUserDto body)
        {
            if (string.IsNullOrEmpty(body.UserName)) return Ok(ResponseResult<bool>.Error(EErrorCode.InvalidUserName.ToString()));
            var userRequest = new AppUser { Id = id, UserName = body.UserName, NickName = body.NickName };
            var user = await Mediator.Send(new Edit.Command { user = userRequest });

            if (user == null) return Ok(ResponseResult<bool>.Error(EErrorCode.ErrorEditUser.ToString()));
            var userDto = Mapper.Map<UserDto>(user);
            return Ok(ResponseResult<UserDto>.Success(userDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
           var result = await Mediator.Send(new Delete.Command { Id = id });
           return Ok(result);
        }

        [HttpPut]
        [Route("add_following/{id}")]
        public async Task<IActionResult> AddFollowing([FromRoute] string id)
        {
            var result = await Mediator.Send(new Following.Query { Id = id });
            return Ok(result);
        }
    }
}
