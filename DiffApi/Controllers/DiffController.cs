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
        private readonly IRightDiffService _rightDiffService;

        public DiffController(
            ILogger<DiffController> logger, 
            ILeftDiffService leftDiffService, 
            IRightDiffService rightDiffService)
        {
            _logger = logger;
            _leftDiffService = leftDiffService;
            _rightDiffService = rightDiffService;
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

        [HttpPut("{id}/right")]
        public IActionResult CreateRightDiff(int id, [FromBody] DiffRequestDto data)
        {
            if (data != null)
            {
                RightDiff rightDiff = new RightDiff { Id = id, Data = data.Data };
                var diffId = _rightDiffService.FindDiffById(id);

                if (diffId == null) _rightDiffService.CreateDiff(rightDiff);
                else _rightDiffService.UpdateDiff(rightDiff);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}