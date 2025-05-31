using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.API.Helper;
using PharmaCare.Core.DTO;
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
                var products = await uow.productRepository.GetAllAsync(
                    p=>p.Category,products=>products.photos
                    );

                var result = mapper.Map<List<ProductDTO>>(products);

                if (products.Count < 1)
                    return NotFound(new ResponseAPI(404, "no product was found"));

                return Ok(result);

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
                var product = await uow.productRepository.GetByIdAsync(id,p=>p.Category,p=>p.photos);

                var result = mapper.Map<ProductDTO>(product);

                if (product is null)
                    return NotFound(new ResponseAPI(404, $"no product was found with id : {id}"));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(AddProductDTO productDTO)
        {
            try
            {
                await uow.productRepository.AddAsync(productDTO);
                return Ok(new ResponseAPI(200,"Product added successfully"));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
    }
}
