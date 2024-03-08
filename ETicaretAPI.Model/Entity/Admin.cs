namespace ETicaretAPI.Model.Entity;
public class Admin
{
    public int Id { get; set; }
    public string? AdminName { get; set; }
    public string? AdminEPosta { get; set; }
    public string? AdminTelefon { get; set; }
    public List<Product>? Products { get; set; } = new List<Product>();
}
