using Microsoft.AspNetCore.Mvc;
using TechTrack.Domain.DTOs.RoadmapStep;
using TechTrack.Domain.Interfaces.IService;

namespace TechTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoadmapStepController : ControllerBase
    {
        private readonly IRoadmapStepService _service;

        public RoadmapStepController(IRoadmapStepService service)
        {
            _service = service;
        }

        // Get all roadmap steps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoadmapStepGetDto>>> GetAll()
        {
            var steps = await _service.GetAllAsync();
            return Ok(steps);
        }

        // IMPORTANT: Put this BEFORE the {id} route
        [HttpGet("roadmap/{roadmapId}")]
        public async Task<ActionResult<IEnumerable<RoadmapStepGetDto>>> GetByRoadmapId(int roadmapId)
        {
            var steps = await _service.GetAllByRoadmapIdAsync(roadmapId);
            return Ok(steps);
        }

        // Get roadmap step by ID - This should come AFTER the specific route
        [HttpGet("{id}")]
        public async Task<ActionResult<RoadmapStepGetDto>> GetById(int id)
        {
            var step = await _service.GetByIdAsync(id);
            if (step == null)
                return NotFound();

            return Ok(step);
        }

        // Create new roadmap step
        [HttpPost]
        public async Task<ActionResult<RoadmapStepGetDto>> Create([FromBody] RoadmapStepCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.RoadmapStepId }, created);
        }

        // Update roadmap step
        [HttpPut("{id}")]
        public async Task<ActionResult<RoadmapStepGetDto>> Update(int id, [FromBody] RoadmapStepUpdateDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // Delete roadmap step
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }


        // Get all roadmaps, with their steps grouped inside
        [HttpGet("grouped")] // This will respond to GET api/RoadmapStep/grouped
        public async Task<ActionResult<IEnumerable<RoadmapStepGetDto>>> GetAllGrouped()
        {
            // 1. Get the flat list of ALL steps
            var allSteps = await _service.GetAllAsync();

            // 2. Group the steps by their RoadmapId using LINQ
            var groupedRoadmaps = allSteps
                .GroupBy(step => step.RoadmapId) // Group by the ID
                .Select(group => new RoadmapStepGetDto // Create the new DTO
                {
                    RoadmapId = group.Key, // The ID (1, 2, 3...)
                    Steps = group.OrderBy(step => step.StepOrder).ToList() // The list of steps for that ID
                })
                .OrderBy(roadmap => roadmap.RoadmapId); // Optional: sort the roadmaps

            // 3. Return the new, grouped list
            return Ok(groupedRoadmaps);
        }



    }
}