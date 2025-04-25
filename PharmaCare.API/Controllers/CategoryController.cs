using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.API.Helper;
using PharmaCare.Core.DTO;
using PharmaCare.Core.Entites.Products;
using PharmaCare.Core.Interfaces;

namespace PharmaCare.API.Controllers
{
    
    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork uow,IMapper mapper) : base(uow,mapper) { }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await uow.categoryRepository.GetAllAsync();
                if (categories.Count < 1)
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
                    return NotFound(new ResponseAPI(404, $"no category was found with id : {id}"));
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
                var category = mapper.Map<Category>(categoryDTO);
                await uow.categoryRepository.AddAsync(category);
                return Ok(new ResponseAPI (200 , "Item has been added succefuly"));
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
                    return NotFound(new ResponseAPI(404, $"no category was found with id : {id}"));

                mapper.Map(categoryDTO,category);

                await uow.categoryRepository.UpdateAsync(category);

                return Ok(new ResponseAPI(200, "Item has been updated succefuly"));
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
                var category = await uow.categoryRepository.GetByIdAsync(id);

                if (category == null)
                    return NotFound(new ResponseAPI(404, $"no category was found with id : {id}"));

                await uow.categoryRepository.DeleteAsync(id);
                return Ok(new ResponseAPI(200, "Item has been deleted succefuly"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
