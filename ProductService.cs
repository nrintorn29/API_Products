public class ProductService : IProductService
{
    private readonly List<Product> _products = new()
    {
        new Product {Id = 1, Name = "ปากกา", Price = 12},
        new Product {Id = 2, Name = "สมุด", Price = 45}
    };

    public List<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public bool IsValid(Product product) => !string.IsNullOrWhiteSpace(product.Name) && product.Price > 0;

    public Product Create(Product newProduct)
    {
        newProduct.Id = _products.Count == 0 ? 1 : _products.Max(p => p.Id) + 1;
        _products.Add(newProduct);

        return newProduct;
    }

    public List<Product> Search(string name)
    {
        var products = _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        return products;
    }

    public Product? Update(int id, Product updateProduct)
    {
        var product = GetById(id);

        if (product == null)
            return null;

        product.Name = updateProduct.Name;
        product.Price = updateProduct.Price;

        return product;
    }

    public bool Delete(int id)
    {
        var product = GetById(id);

        if (product == null)
            return false;
        
        _products.Remove(product);

        return true;
    }

    public void DeleteAll() => _products.Clear();

    public List<Product> GetExpensive(decimal minPrice) => _products.Where(p => p.Price >= minPrice).ToList();
}
