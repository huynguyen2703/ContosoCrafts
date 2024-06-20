using ContosoCrafts.WebSite.Model;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.Website.Controllers
{   // route is determined by class name with suffix Controller
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        JsonFileProductService productServiceObject;
        public ProductsController(JsonFileProductService productService) 
        {
            productServiceObject = productService;
        }

        public JsonFileProductService ProductService => productServiceObject;

        [HttpGet]
        public IEnumerable<Product> Get() 
        {
            return ProductService.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string ProductId, [FromQuery]int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }


    }
}
