namespace ProductManagement.Service;

public class ProductService(IProductRepository repo) : IProductService
{
    public async Task<List<Product>> GetProducts()
    {
        return await repo.GetAll();
    }

    public async Task<Product?> GetProduct(int id)
    {
        return await repo.GetById(id);
    }

    public async Task AddProduct(Product product)
    {
        await repo.Create(product);
    }

    public async Task UpdateProduct(Product product)
    {
        await repo.Update(product);
    }

    public async Task DeleteProduct(int id)
    {
        await repo.Delete(id);
    }
}
