using System.ComponentModel.DataAnnotations;

public class UpdateProductDto
{
    private const string MinPrice = "0.01";
    private const string MaxPrice = "1000000";

    [Required(ErrorMessage = "กรุณาใส่ชื่อสินค้า")]
    [StringLength(100, ErrorMessage = "ชื่อไม่เกิน 100 ตัวอักษร")]
    public string Name {get; set;} = string.Empty;

    [Range(typeof(decimal), MinPrice, MaxPrice, ErrorMessage = $"ราคาระหว่าง {MinPrice} ถึง {MaxPrice}")]
    public decimal Price {get; set;}

    [StringLength(500, ErrorMessage = "ข้อความไม่เกิน 500 ตัวอักษร")]
    public string? Description {get; set;}
}