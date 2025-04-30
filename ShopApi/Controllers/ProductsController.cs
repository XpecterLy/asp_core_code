using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NuGet.Configuration;
using ShopApi.Config;
using ShopApi.Interfaces;
using ShopApi.Models;
using ShopApi.ViewModel;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly MyAppSettings _settings;

        public ProductsController(IProductService productService, IOptions<MyAppSettings> settings)
        {
            _productService = productService;
            _settings = settings.Value;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtProduct>>> GetProducts() {
            return Ok(await _productService.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DtProduct>> GetProduct(int id)
        {
            return Ok(await _productService.GetProduct(id));
        }

        [HttpPost]
        public async Task<ActionResult<DtProduct>> AddProduct(ProductRequestInsertModel data)
        {
            var res = await _productService.AddProduct(data);

            return CreatedAtAction(nameof(GetProduct), new { id = res.ProductId }, res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DtProduct>> UpdateProduct(int id, ProductRequestUpdateModel? data)
        {
            return Ok(await _productService.UpdateProduct(id, data));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DtProduct>> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
