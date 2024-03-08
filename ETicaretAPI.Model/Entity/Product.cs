namespace ETicaretAPI.Model.Entity;
public class Product
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int AdminId { get; set; }
    public Admin Admin { get; set; }
    public List<Cart>? Carts { get; set; } = new List<Cart>();
}
