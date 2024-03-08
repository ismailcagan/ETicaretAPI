using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.DataAccess.Abstract;
public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
    List<Product> GetAll();
    Product? GetById(int id);
}
