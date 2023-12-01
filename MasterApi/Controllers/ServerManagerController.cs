using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerManagerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ServerManagerController> _logger;

        public ServerManagerController(ILogger<ServerManagerController> logger)
        {
            _logger = logger;
        }

        public async void log()
        {
            _logger.Log(LogLevel.Warning, "error");
        }
    }
}