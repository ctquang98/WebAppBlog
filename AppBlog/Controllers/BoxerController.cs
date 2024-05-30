using AppBlog.Features.Boxers;
using AppBlog.Models.Dto;
using AppBlog.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AppBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxerController : AppBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var boxers = await Mediator.Send(new List.Query());
            var response = Mapper.Map<List<BoxerDto>>(boxers);
            return Ok(ResponseResult<List<BoxerDto>>.Success(response));
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var errNotFound = ResponseResult<bool>.Error("ERR_NOT_FOUND");
            if (Id == null) return Ok(errNotFound);

            var boxer = await Mediator.Send(new Detail.Query() { Id = Id });
            if (boxer == null) return Ok(errNotFound);

            var response = Mapper.Map<BoxerDto>(boxer);
            return Ok(ResponseResult<BoxerDto>.Success(response));
        }
    }
}
