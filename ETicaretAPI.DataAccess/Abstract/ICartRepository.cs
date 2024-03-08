using ETicaretAPI.Model.Entity;
using ETicaretAPI.Model.ViewModel;

namespace ETicaretAPI.DataAccess.Abstract;
public interface ICartRepository
{
    void Add(Cart cart);
    void Delete(int id);
    List<Cart> GetAll();
    Cart? GetById(int id);
    List<UserToProduct> UserToProduct(int Userid);
}
