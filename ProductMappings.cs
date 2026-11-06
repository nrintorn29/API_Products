public static class ProductMappings
{
    public static Product ToEntity(this CreateProductDto dto) => new()
    {
        Name = dto.Name.Trim(),
        Price = dto.Price,
        Description = dto.Description
    };

    public static Product ToEntity(this UpdateProductDto dto) => new()
    {
        Name = dto.Name.Trim(),
        Price = dto.Price,
        Description = dto.Description
    };

    public static ResponseProductDto ToResponse(this Product p) => new()
    {
        Id = p.Id,
        Name = p.Name,
        Price = p.Price,
        Description = p.Description
    };
}