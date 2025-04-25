using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.API.Helper;
using PharmaCare.Core.Entites.Products;
using PharmaCare.Core.Interfaces;

namespace PharmaCare.API.Controllers
{

    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await uow.productRepository.GetAllAsync();

                if (products.Count < 1)
                    return NotFound(new ResponseAPI(404, "no product was found"));

                return Ok(products);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await uow.productRepository.GetByIdAsync(id);

                if (product == null)
                    return NotFound(new ResponseAPI(404, $"no product was found with id : {id}"));

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
