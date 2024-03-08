namespace ETicaretAPI.DataAccess.Error;
public class NotFoundException : Exception
{
    public NotFoundException(int id) : base($"{id} id ye ait veri bulunamadı")
    {
        
    }
}
