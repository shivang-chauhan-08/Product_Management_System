namespace ProductManagement.Repository;

public class ProductRepository(ApplicationDBContext context) : IProductRepository
{
    public async Task<List<Product>> GetAll()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        return await context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Create(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product == null)
        {
            throw new Exception("Product Not Found");
        }
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }
}
