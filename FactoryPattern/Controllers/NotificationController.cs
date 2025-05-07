using FactoryPattern.Services;
using FactoryPattern.Types;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationServiceFactory _factory;

        public NotificationController(INotificationServiceFactory factory)
        {
            _factory = factory;
        }

        [HttpPost("{type}")]
        public IActionResult SendNotification(NotificationType type, [FromBody] string message)
        {
            var service = _factory.Create(type);
            service.Send(message);
            return Ok("Notificación enviada.");
        }
    }
}
