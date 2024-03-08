namespace ETicaretAPI.Business.Dto.Request;
public class AdminUpdateRequest
{
    public int Id { get; set; }
    public string? AdminName { get; set; }
    public string? AdminEPosta { get; set; }
    public string? AdminTelefon { get; set; }
}
