namespace ProductManagement.XUnitTest.Services;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockRepo;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _mockRepo = new Mock<IProductRepository>();
        _service = new ProductService(_mockRepo.Object);
    }

    [Fact]
    public async Task GetProducts_ReturnAllProducts()
    {
        // Arrange
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

        _mockRepo.Setup(x => x.GetAll()).ReturnsAsync(products);

        // Act
        var result = await _service.GetProducts();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Laptop", result[0].Name);
    }

    [Fact]
    public async Task GetProduct_ReturnProductById()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 50000,
            Description = "Best Laptop"
        };

        _mockRepo.Setup(x => x.GetById(1)).ReturnsAsync(product);

        // Act
        var result = await _service.GetProduct(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Laptop", result.Name);
    }

    [Fact]
    public async Task CreateProduct()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 50000,
            Description = "Best Laptop"
        };

        // Act
        await _service.AddProduct(product);

        // Assert
        _mockRepo.Verify(x => x.Create(product), Times.Once);
    }

    [Fact]
    public async Task UpdateProduct()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Updated Laptop",
            Price = 50000,
            Description = "Best Laptop"
        };

        // Act
        await _service.UpdateProduct(product);

        // Assert
        _mockRepo.Verify(x => x.Update(product), Times.Once);
    }

    [Fact]
    public async Task DeleteProduct()
    {
        // Act
        await _service.DeleteProduct(1);

        // Assert
        _mockRepo.Verify(x => x.Delete(1), Times.Once);
    }
}