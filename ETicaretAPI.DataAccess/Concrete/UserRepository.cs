using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Context;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.DataAccess.Concrete;
public class UserRepository : IUserRepository
{
    private readonly BaseDbContext _context;

    public UserRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        User? user = _context.Users.Find(id);
        if (user is null)
        {
            throw new NotFoundException(id);
        }
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public List<User> GetAll()
    {
        List<User> users = _context.Users.ToList();
        return users;
    }

    public User? GetById(int id)
    {
        User? user = _context.Users.Find(id);
        if (user is null)
        {
            throw new NotFoundException(id);
        }
        return user;
    }

    public void Update(User user)
    {
        User? users = _context.Users.Find(user.Id);
        if (users is null)
        {
            throw new NotFoundException(user.Id);
        }
        users.Id = user.Id;
        users.UserName = user.UserName;
        users.UserEposta = user.UserEposta;
        users.Telefon = user.Telefon;
        _context.Users.Update(users);
        _context.SaveChanges();
    }
}
