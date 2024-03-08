using ETicaretAPI.DataAccess.Abstract;
using ETicaretAPI.DataAccess.Context;
using ETicaretAPI.DataAccess.Error;
using ETicaretAPI.Model.Entity;

namespace ETicaretAPI.DataAccess.Concrete;
public class AdminRepository : IAdminRepository
{
    private readonly BaseDbContext _context;

    public AdminRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(Admin admin)
    {
        _context.Admins.Add(admin);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Admin? admin = _context.Admins.Find(id);
        if (admin is null)
        {
            throw new NotFoundException(id);
        }
        _context.Admins.Remove(admin);
        _context.SaveChanges();
    }

    public List<Admin> GetAll()
    {
        List<Admin> admins = _context.Admins.ToList();
        return admins;
    }

    public Admin? GetById(int id)
    {
         Admin? admin = _context.Admins.SingleOrDefault(x=> x.Id == id);
        //Admin? admin = _context.Admins.Find(id);
        if (admin is null)
        {
            throw new NotFoundException(id);
        }
        return admin;
    }

    public void Update(Admin admin)
    {
        Admin? admins = _context.Admins.SingleOrDefault(x=> x.Id == admin.Id);
        if( admins is null)
        {
            throw new NotFoundException(admin.Id);
        }
        admins.Id = admin.Id;
        admins.AdminName = admin.AdminName;
        admins.AdminEPosta = admin.AdminEPosta;
        admins.AdminTelefon = admin.AdminTelefon;
        _context.Admins.Update(admins);
        _context.SaveChanges();
    }
}
