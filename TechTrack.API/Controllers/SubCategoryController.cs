using Microsoft.AspNetCore.Mvc;
using TechTrack.Domain.DTOs.SubCategory;
using TechTrack.Domain.Interfaces.IService;
using TechTrack.DTOs.SubCategory;

namespace TechTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _service;

        public SubCategoryController(ISubCategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all subcategories
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(object), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            if (!result.Success)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true, data = result.Data });
        }

        /// <summary>
        /// Get subcategory by ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (!result.Success)
                return NotFound(new { success = false, errors = result.Errors });

            return Ok(new { success = true, data = result.Data });
        }

        /// <summary>
        /// Create a new subcategory with optional image
        /// </summary>
        /// <remarks>
        /// Send as multipart/form-data:
        /// - CategoryId: int (required)
        /// - SubCategoryName: string (required)
        /// - Description: string (required)
        /// - DifficultyLevel: int? (optional)
        /// - EstimatedDuration: int (required)
        /// - Image: file (optional)
        /// </remarks>
        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromForm] SubCategoryCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });

            var result = await _service.CreateAsync(dto);

            if (!result.Success)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true, data = result.Data, message = "SubCategory created successfully" });
        }

        /// <summary>
        /// Update an existing subcategory
        /// </summary>
        /// <remarks>
        /// Send as multipart/form-data:
        /// - CategoryId: int (required)
        /// - SubCategoryName: string (required)
        /// - Description: string (required)
        /// - DifficultyLevel: int? (optional)
        /// - EstimatedDuration: int (required)
        /// - Image: file (optional - new image to upload)
        /// - DeleteImage: boolean (optional - set to true to remove existing image)
        /// </remarks>
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromForm] SubCategoryUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });

            var result = await _service.UpdateAsync(id, dto);

            if (!result.Success)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true, data = result.Data, message = "SubCategory updated successfully" });
        }

        /// <summary>
        /// Delete a subcategory and its image
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.Success)
                return NotFound(new { success = false, errors = result.Errors });

            return Ok(new { success = true, message = "SubCategory deleted successfully" });
        }
    }
}
