using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly AppDbContext _db;

    public ProductService(AppDbContext db)
    {
        _db = db;
    }

    public List<Product> GetAll() => _db.Products.ToList();

    public Product? GetById(int id) => _db.Products.Find(id);

    public bool IsValid(Product product) => !string.IsNullOrWhiteSpace(product.Name) && product.Price > 0;

    public Product Create(Product newProduct)
    {
        newProduct.Id = 0;
        _db.Products.Add(newProduct);
        _db.SaveChanges();

        return newProduct;
    }

    public List<Product> Search(string name)
        => _db.Products
            .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
            .ToList();

    public Product? Update(int id, Product updateProduct)
    {
        var product = _db.Products.Find(id);

        if (product == null)
            return null;

        product.Name = updateProduct.Name;
        product.Price = updateProduct.Price;
        _db.SaveChanges();

        return product;
    }

    public bool Delete(int id)
    {
        var product = _db.Products.Find(id);

        if (product == null)
            return false;
        
        _db.Products.Remove(product);
        _db.SaveChanges();

        return true;
    }

    public void DeleteAll() => _db.Products.ExecuteDelete();

    public List<Product> GetExpensive(decimal minPrice) => _db.Products.Where(p => p.Price >= minPrice).ToList();
}
