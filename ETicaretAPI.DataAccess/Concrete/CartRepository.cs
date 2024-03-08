using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Context;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;
using ETicaretAPI.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.DataAccess.Concrete;
public class CartRepository : ICartRepository
{
    private readonly BaseDbContext _context;
    private readonly UserToProduct _userToProduct;
    public CartRepository(BaseDbContext context, UserToProduct userToProduct)
    {
        _context = context;
        _userToProduct = userToProduct;
    }

    public void Add(Cart cart)
    {
        _context.Carts.Add(cart);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Cart? cart = _context.Carts.Find(id);
        if (cart is null)
        {
            throw new NotFoundException(id);
        }
        _context.Carts.Remove(cart);
        _context.SaveChanges();
    }

    public List<Cart> GetAll()
    {
        List<Cart> carts = _context.Carts.
                            Include(x => x.Product).
                            // Include(x=>x.Product.Category).
                            ThenInclude(x => x.Category).
                            Include(x => x.Product.Admin).
                            Include(x => x.User).
                            ToList();
        return carts;
    }

    public Cart? GetById(int id)
    {
        Cart? cart = _context.Carts.Find(id);
        if (cart is null)
        {
            throw new NotFoundException(id);
        }
        return cart;
    }

    public List<UserToProduct> UserToProduct(int Userid)
    {

        var details = _context.Carts.Where(x => x.UserId == Userid).Join(_context.Products,
            c => c.ProductId,
            p => p.Id,
            (cart, product) => new UserToProduct
            {
                UserId = Userid,
                ProductId = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,
                AdminId = product.Admin.Id,
                AdminName = cart.Product.Admin.AdminName
            }
            ).ToList();

        return details;
    }
}
