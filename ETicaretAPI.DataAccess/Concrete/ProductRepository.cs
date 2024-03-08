using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Context;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.DataAccess.Concrete;
public class ProductRepository : IProductRepository
{
    private readonly BaseDbContext _context;

    public ProductRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Add(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Product? product = _context.Products.Find(id);
        if (product is null)
        {
            throw new NotFoundException(id);
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public List<Product> GetAll()
    {
        List<Product> products = _context.Products.
                                  Include(x => x.Admin).
                                  Include(x => x.Category).
                                  ToList();
        return products;
    }

    public Product? GetById(int id)
    {
        Product? product = _context.Products.Include(x => x.Admin).SingleOrDefault();
        if (product is null)
        {
            throw new NotFoundException(id);
        }
        return product;
    }

    public void Update(Product product)
    {
        Product? products = _context.Products.Find(product.Id);
        if (products is null)
        {
            throw new NotFoundException(product.Id);
        }
        products.Id = product.Id;
        products.ProductName = product.ProductName;
        products.Price = product.Price;
        products.CategoryId = product.CategoryId;
        products.AdminId = product.AdminId;
        _context.Products.Update(products);
        _context.SaveChanges();
    }
}
