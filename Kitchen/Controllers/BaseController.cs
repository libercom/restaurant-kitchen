using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [ApiController]
    [Route("api")]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        [HttpPost("order")]
        public IActionResult RecieveOrder()
        {
            _logger.LogInformation("Order recieved");

            return Ok();
        }
    }
}
