using Microsoft.AspNetCore.Mvc;
using TechTrack.DTOs.Category;
using TechTrack.Domain.Interfaces.IService;

namespace TechTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all categories
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
        /// Get category by ID
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
        /// Create a new category with optional image
        /// </summary>
        /// <remarks>
        /// Send as multipart/form-data:
        /// - CategoryName: string (required)
        /// - Description: string (optional)
        /// - Image: file (optional)
        /// </remarks>
        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });

            var result = await _service.CreateAsync(dto);

            if (!result.Success)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true, data = result.Data, message = "Category created successfully" });
        }

        /// <summary>
        /// Update an existing category
        /// </summary>
        /// <remarks>
        /// Send as multipart/form-data:
        /// - CategoryName: string (required)
        /// - Description: string (optional)
        /// - Image: file (optional - new image to upload)
        /// - DeleteImage: boolean (optional - set to true to remove existing image)
        /// </remarks>
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromForm] CategoryUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });

            var result = await _service.UpdateAsync(id, dto);

            if (!result.Success)
                return BadRequest(new { success = false, errors = result.Errors });

            return Ok(new { success = true, data = result.Data, message = "Category updated successfully" });
        }

        /// <summary>
        /// Delete a category and its image
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.Success)
                return NotFound(new { success = false, errors = result.Errors });

            return Ok(new { success = true, message = "Category deleted successfully" });
        }
    }
}
