using Microsoft.AspNetCore.Mvc;
using TechTrack.DTOs.Roadmap;
using TechTrack.Domain.Interfaces.IService;

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
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(RoadmapCreateDto dto) => Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoadmapUpdateDto dto) => Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _service.DeleteAsync(id));
    }
}
