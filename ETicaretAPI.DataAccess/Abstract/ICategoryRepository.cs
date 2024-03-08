using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.DataAccess.Abstract;
public interface ICategoryRepository
{
    void Add(Category category);
    void Delete(int id);
    Category GrtById(int id);
}
