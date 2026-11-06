public interface IProductService
{
    Task<List<Product>> GetAllAsync(CancellationToken ct);
    Task<Product?> GetByIdAsync(int id, CancellationToken ct);
    Task<List<Product>> SearchAsync(string name, CancellationToken ct);
    Task<List<Product>> GetExpensiveAsync(decimal minPrice, CancellationToken ct);
    Task<Product> CreateAsync(Product newProduct, CancellationToken ct);
    Task<Product?> UpdateAsync(int id, Product updateProduct, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
    Task DeleteAllAsync(CancellationToken ct);
}