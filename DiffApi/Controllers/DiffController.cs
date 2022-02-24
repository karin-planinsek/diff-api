using Microsoft.AspNetCore.Mvc;

namespace DiffApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DiffController : ControllerBase
    {
        private readonly ILogger<DiffController> _logger;

        public DiffController(ILogger<DiffController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get()
        {
            
        }
    }
}