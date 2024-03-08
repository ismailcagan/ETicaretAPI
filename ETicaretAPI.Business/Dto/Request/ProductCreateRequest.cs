using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.Business.Dto.Request;
public class ProductCreateRequest
{
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int AdminId { get; set; }
}
