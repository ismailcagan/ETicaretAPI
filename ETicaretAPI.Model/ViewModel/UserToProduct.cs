using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.Model.ViewModel;
public class UserToProduct
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; } 
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public string?  CategoryName{ get; set; }
    public int AdminId { get; set; }
    public string?  AdminName { get; set; }
}
