using Microsoft.AspNetCore.Mvc;
using TechTrack.Domain.DTOs.RoadmapWithSteps;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.DTOs.Roadmap;

namespace TechTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoadmapController : ControllerBase
    {
        private readonly IRoadmapService _service;

        public RoadmapController(IRoadmapService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            if (!result.Success || result.Data == null)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (!result.Success || result.Data == null)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoadmapCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            if (!result.Success || result.Data == null)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoadmapUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result.Success || result.Data == null)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.Success || result.Data == null)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true, deleted = result.Data });
        }

     /*   // Get all roadmaps, with their steps grouped inside
        [HttpGet("grouped")]
        public async Task<ActionResult<IEnumerable<RoadmapGetDto>>> GetAllGrouped()
        {
            var allResult = await _service.GetAllAsync();

            if (!allResult.Success || allResult.Data == null)
                return BadRequest(new { success = false, errors = allResult.Errors });

            // The service returns RoadmapGetDto (with Steps: List<string>) — group by RoadmapId and merge steps safely.
            var grouped = allResult.Data
                .GroupBy(r => r.RoadmapId)
                .Select(g => new RoadmapGetDto
                {
                    RoadmapId = g.Key,
                    TechnologyId = g.First().TechnologyId,
                    Title = g.First().Title,
                    Description = g.First().Description,
                    Steps = g.SelectMany(r => r.Steps ?? new List<string>()).ToList()
                })
                .OrderBy(r => r.RoadmapId);

            return Ok(grouped);
        }*/
    }
}
