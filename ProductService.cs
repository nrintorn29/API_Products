using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly AppDbContext _db;

    public ProductService(AppDbContext db) {_db = db;}

    public async Task<List<Product>> GetAllAsync(CancellationToken ct)
        => await _db.Products.ToListAsync(ct);

    public async Task<Product?> GetByIdAsync(int id, CancellationToken ct)
        => await _db.Products.FindAsync(new object[] {id}, ct);

    public async Task<List<Product>> SearchAsync(string name, CancellationToken ct)
        => await _db.Products
                    .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
                    .ToListAsync(ct);
    
    public async Task<List<Product>> GetExpensiveAsync(decimal minPrice, CancellationToken ct)
        => await _db.Products
                    .Where(p => p.Price >= minPrice)
                    .ToListAsync(ct);

    public async Task<Product> CreateAsync(Product newProduct, CancellationToken ct)
    {
        _db.Products.Add(newProduct);
        await _db.SaveChangesAsync(ct);
        return newProduct;
    }

    public async Task<Product?> UpdateAsync(int id, Product updateProduct, CancellationToken ct)
    {
        var updated = await _db.Products.FindAsync(new object[] {id}, ct);
        if (updated == null)
            return null;
        updated.Name = updateProduct.Name;
        updated.Price = updateProduct.Price;
        updated.Description = updateProduct.Description;
        await _db.SaveChangesAsync(ct);
        return updated;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var deleted = await _db.Products.FindAsync(new object[] {id}, ct);
        if (deleted == null)
            return false;
        _db.Products.Remove(deleted);
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task DeleteAllAsync(CancellationToken ct)
        => await _db.Products.ExecuteDeleteAsync(ct);
}