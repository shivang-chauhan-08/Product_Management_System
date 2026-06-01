namespace ProductManagement.Data;

public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}
