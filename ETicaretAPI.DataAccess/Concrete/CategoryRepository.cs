using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Context;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.DataAccess.Concrete;
public class CategoryRepository : ICategoryRepository
{
    private readonly BaseDbContext _context;

    public CategoryRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Category? category = _context.Categories.Find(id);
        if (category is null) 
        {
            throw new NotFoundException(id);
        }
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }

    public Category GrtById(int id)
    {
        Category? category = _context.Categories.Find(id);
        if(category is null)
        {
            throw new NotFoundException(id);
        }
        return category;
    }
}
