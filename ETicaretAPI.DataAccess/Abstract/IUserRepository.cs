using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.DataAccess.Abstract;
public interface IUserRepository
{
    void Add(User user);
    void Update(User user);
    void Delete(int id);
    List<User> GetAll();
    User? GetById(int id);
}
