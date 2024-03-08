using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.Business.Dto.Response;
public class CartResponseDto
{
    public int Id { get; set; }
    public UserResponseDto? User { get; set; }
    public ProductResponseDto? Product { get; set; }
}
