namespace ProductManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await service.GetProducts();
        return Ok(products);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await service.GetProduct(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        await service.AddProduct(product);
        return Ok("Product Created");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(Product product)
    {
        await service.UpdateProduct(product);
        return Ok("Product Updated");
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await service.DeleteProduct(id);
        return Ok("Product Deleted");
    }
}
