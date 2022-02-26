using DiffApi.Dto;
using DiffApi.Infrastructure.Services;
using DiffApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiffApi.Controllers
{
    [ApiController]
    [Route("v1/diff")]
    public class DiffController : ControllerBase
    {
        private readonly ILogger<DiffController> _logger;
        private readonly ILeftDiffService _leftDiffService;

        public DiffController(ILogger<DiffController> logger, ILeftDiffService leftDiffService)
        {
            _logger = logger;
            _leftDiffService = leftDiffService;
        }

        [HttpPut("{id}/left")]
        public IActionResult CreateLeftDiff(int id, [FromBody] DiffRequestDto data)
        {
            if (data != null)
            {
                LeftDiff leftDiff = new LeftDiff { Id = id, Data = data.Data };
                var diffId = _leftDiffService.FindDiffById(id);

                if (diffId == null) _leftDiffService.CreateDiff(leftDiff);
                else _leftDiffService.UpdateDiff(leftDiff);

                return Ok();
            } else
            {
                return BadRequest();
            }
        }
    }
}