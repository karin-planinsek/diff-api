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
        private readonly ILeftDiffService _leftDiffService;
        private readonly IRightDiffService _rightDiffService;
        private readonly IDiffService _diffService;

        public DiffController(
            ILeftDiffService leftDiffService, 
            IRightDiffService rightDiffService,
            IDiffService diffService)
        {
            _leftDiffService = leftDiffService;
            _rightDiffService = rightDiffService;
            _diffService = diffService;
        }

        [HttpGet("{id}")]
        public IActionResult GetDiff(int id)
        {
            var leftDiff = _leftDiffService.FindDiffById(id);
            var rightDiff = _rightDiffService.FindDiffById(id);

            if (leftDiff == null || rightDiff == null) return NotFound();
            else return Ok(_diffService.GetDiff(leftDiff.Data, rightDiff.Data));
        }

        [HttpPut("{id}/left")]
        public IActionResult CreateLeftDiff(int id, [FromBody] DiffRequestDto data)
        {
            if (data.Data != null)
            {
                _leftDiffService.CreateDiff(id, data.Data);

                return Created("left", null);
            } else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}/right")]
        public IActionResult CreateRightDiff(int id, [FromBody] DiffRequestDto data)
        {
            if (data.Data != null)
            {
                _rightDiffService.CreateDiff(id, data.Data);

                return Created("right", null);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}