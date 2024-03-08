namespace ETicaretAPI.Business.Dto.Response;
public class UserToCartResponseDto
{
    public int UserId { get; set; }
    public ProductResponseDto? Product { get; set; }
    public decimal Price { get; set; }
    public CategoryResponseDto? Category { get; set; }
    public AdminResponseDto? Admin { get; set; }
}
