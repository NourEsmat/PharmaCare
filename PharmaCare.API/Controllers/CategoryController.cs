using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.Core.DTO;
using PharmaCare.Core.Entites.Products;
using PharmaCare.Core.Interfaces;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork uow) : base(uow) { }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await uow.categoryRepository.GetAllAsync();
                if (categories == null)
                    return NotFound();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet ("get-by-id")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await uow.categoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound("No category was found");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var category = new Category
                {
                    name = categoryDTO.name,
                    description = categoryDTO.description
                };
                await uow.categoryRepository.AddAsync(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-category/{id}")]
        public async Task<IActionResult> UpdateCategory(CategoryDTO categoryDTO,int id)
        {
            try
            {
                var category = await uow.categoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound("No category was found");
                category.name = categoryDTO.name;
                category.description = categoryDTO.description;
                await uow.categoryRepository.UpdateAsync(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await uow.categoryRepository.DeleteAsync(id);
                return Ok("Category deleted successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
