using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppBaseController : ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper Mapper => HttpContext.RequestServices.GetService<IMapper>();
    }
}
