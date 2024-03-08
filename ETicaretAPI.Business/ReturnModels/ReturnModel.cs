using System.Net;

namespace ETicaretAPI.Business.ReturnModels;
public class ReturnModel<T>
{
    public T? Data { get; set; }
    public string? Message {  get; set; }
    public HttpStatusCode StatusCode { get; set; }
}
