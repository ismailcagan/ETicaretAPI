using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.Business.Dto.Request;
public class CartCreateRequest
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}
