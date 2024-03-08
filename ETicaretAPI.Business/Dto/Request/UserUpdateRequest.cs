namespace ETicaretAPI.Business.Dto.Request;
public class UserUpdateRequest
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? UserEposta { get; set; }
    public string? Telefon { get; set; }
}
