using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.Business.Dto.Response;
public class ProductResponseDto
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public CategoryResponseDto? Category { get; set; }
    public AdminResponseDto? Admin { get; set; }
}
