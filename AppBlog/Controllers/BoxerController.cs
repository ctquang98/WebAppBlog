using AppBlog.Features.Boxers;
using AppBlog.Models.Domain;
using AppBlog.Models.Dto;
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
    }
}
