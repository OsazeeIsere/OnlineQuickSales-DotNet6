using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace OnlineQuickSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private DataContext _dataContext;   
        public ProductController(DataContext context) 
        {
            _dataContext=context;
        }
              
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _dataContext.Products.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetOne(int id)
        {
            var dbproduct =await _dataContext.Products.FindAsync(id);
            if (dbproduct == null)
                return BadRequest("Product not available");
            return Ok(dbproduct);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Products.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            var dbproduct =await _dataContext.Products.FindAsync(product.Id);
            if (dbproduct == null)
                return BadRequest("Product Not Available");
            dbproduct.ProductName = product.ProductName;
            dbproduct.UnitCostPrice= product.UnitCostPrice;
            dbproduct.UnitSalesPrice= product.UnitSalesPrice;
            dbproduct.Quantity = product.Quantity;

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Products.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteOne(int id)
        {
            var dbproduct = await _dataContext.Products.FindAsync(id);
            if (dbproduct == null)
                return BadRequest("Product not available");
           
              _dataContext.Products.Remove(dbproduct);
              _dataContext.SaveChanges(); 
            return Ok(await _dataContext.Products.ToListAsync());
        }
    }
}
