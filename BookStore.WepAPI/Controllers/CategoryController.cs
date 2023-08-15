using BookStore.Entities.Models;
using BookStore.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategory([FromRoute] int id)
        {
            var category = await _serviceManager.CategoryService.GetOneCategoryByIdAsync(id, false);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneCategory([FromBody] Category category)
        {
            if (category is null)
            {
                return BadRequest();
            }
            await _serviceManager.CategoryService.CreateOneCategoryAsync(category);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCategory([FromRoute] int id)
        {
            await _serviceManager.CategoryService.DeleteOneCategoryAsync(id, true);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOneCategory([FromRoute] int id, [FromBody] Category category)
        {
            if (category is null)
            {
                return BadRequest();
            }
            await _serviceManager.CategoryService.UpdateOneCategoryAsync(id, category, true);
            return Ok();
        }
    }
}
