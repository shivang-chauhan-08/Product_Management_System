namespace ProductManagement.NUnitTest.Services;

[TestFixture]
public class ProductServiceTests
{
    [Test]
    public async Task GetProducts_ReturnAllProducts()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();

        List<Product> products = [
            new Product {
                Id = 1,
                Name = "Laptop",
                Price = 50000,
                Description = "Best Laptop"
            },
            new Product {
                Id = 2,
                Name = "Mobile",
                Price = 25000,
                Description = "Best Phone"
            }
         ];

        mockRepo.Setup(x => x.GetAll()).ReturnsAsync(products);

        var service = new ProductService(mockRepo.Object);

        // Act
        var result = await service.GetProducts();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].Name, Is.EqualTo("Laptop"));
    }

    [Test]
    public async Task GetProduct_ReturnProductById()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();

        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 50000,
            Description = "Best Laptop"
        };

        mockRepo.Setup(x => x.GetById(1)).ReturnsAsync(product);

        var service = new ProductService(mockRepo.Object);

        // Act
        var result = await service.GetProduct(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(1));
        Assert.That(result.Name, Is.EqualTo("Laptop"));
    }
}
