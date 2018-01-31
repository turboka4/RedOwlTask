using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RedOwl.DbModel.Entities;
using RedOwl.DbModel.Repositories.Interfaces;

namespace RedOwl.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET api/getproducts
        [HttpGet("getproducts")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> GetProductsAsync()
        {
            return Ok(await productRepository.FindAllAsync().ConfigureAwait(false));
        }

        // POST api/addproduct
        [HttpPost("addproduct")]
        [EnableCors("AllowAll")]
        public async Task<IActionResult> AddProductAsync([FromBody]Product product)
        {
            var result = await productRepository.CreateAsync(product).ConfigureAwait(false);

            if (result != null)
                return Ok();

            return BadRequest();
        }
    }
}
