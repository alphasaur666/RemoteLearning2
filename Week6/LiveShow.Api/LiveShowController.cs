using Microsoft.AspNetCore.Mvc;

namespace LiveShow.Api
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class LiveShowApiControllerBase : ControllerBase
    {
    }
}
