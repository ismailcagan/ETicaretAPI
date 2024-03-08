using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.DataAccess.Abstract;
public interface IAdminRepository
{
    void Add(Admin admin);
    void Update(Admin admin);
    void Delete(int id);
    List<Admin> GetAll();
    Admin? GetById(int id);
}
