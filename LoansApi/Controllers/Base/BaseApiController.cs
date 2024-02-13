using LoansApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LoansApi.Controllers.Base
{
    [TypeFilter(typeof(CustomExceptionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
