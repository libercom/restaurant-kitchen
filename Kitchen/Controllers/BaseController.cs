using Kitchen.Dtos;
using Kitchen.Services;
using Microsoft.AspNetCore.Mvc;


namespace Kitchen.Controllers
{
    [ApiController]
    [Route("api")]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IKitchenService _kitchenService;

        public BaseController(ILogger<BaseController> logger, IKitchenService kitchenService)
        {
            _logger = logger;
            _kitchenService = kitchenService;
        }

        [HttpPost("order")]
        public IActionResult RecieveOrder(OrderDto orderDto)
        {
            _logger.LogInformation($"Kitchen: Recieved order with id: {orderDto.OrderId}");
            _kitchenService.TakeOrder(orderDto);

            return Ok();
        }
    }
}
