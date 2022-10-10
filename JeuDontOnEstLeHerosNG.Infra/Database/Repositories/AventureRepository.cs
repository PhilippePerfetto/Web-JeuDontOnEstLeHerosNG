using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Infra.Helpers;

namespace JeuDontOnEstLeHerosNG.Infra.Database.Repositories;

public interface IAventureRepository
{
    IEnumerable<Aventure> GetAll();
    Aventure GetById(int id);
    void Create(Aventure model);
    void Update(int id, Aventure model);
    void Delete(int id);
}

public class AventureRepository : IAventureRepository
{
    private readonly AventureDataContext _context;

    public AventureRepository(AventureDataContext context)
    {
        _context = context ?? throw new NullReferenceException("No aventuresfound :(");
    }

    public IEnumerable<Aventure> GetAll() => _context.Aventures;

    public Aventure GetById(int id) => getAventure(id);

    public void Create(Aventure aventure)
    {
        // validate
        if (_context.Aventures.Any(x => x.Title == aventure.Title))
            throw new AppException("Aventure with the title '" + aventure.Title + "' already exists");

        // hash password
        // aventure.PasswordHash = BCrypt.HashPassword(model.Password);

        // save aventure
        _context.Aventures.Add(aventure);
        _context.SaveChanges();
    }

    public void Update(int id, Aventure model)
    {
        var aventure = getAventure(id);

        // validate
        if (_context.Aventures.Any(x => x.Title == model.Title))
            throw new AppException("Aventure with the title '" + model.Title + "' already exists");

        // copy model to aventure and save
        _context.Aventures.Update(aventure);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var aventure = getAventure(id);
        _context.Aventures.Remove(aventure);
        _context.SaveChanges();
    }

    // helper methods

    private Aventure getAventure(int id)
    {
        var aventure = _context.Aventures.Find(id);
        if (aventure == null) throw new KeyNotFoundException("Aventure not found");
        return aventure;
    }
}
