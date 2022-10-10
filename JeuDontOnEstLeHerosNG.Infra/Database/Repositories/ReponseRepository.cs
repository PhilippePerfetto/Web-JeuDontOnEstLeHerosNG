
using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Infra.Helpers;

namespace JeuDontOnEstLeHerosNG.Infra.Database.Repositories;

public interface IReponseRepository
{
    IEnumerable<Reponse> GetAll();
    Reponse GetById(int id);
    void Create(Reponse model);
    void Update(int id, Reponse model);
    void Delete(int id);
}

public class ReponseRepository : IReponseRepository
{
    private readonly AventureDataContext _context;

    public ReponseRepository(AventureDataContext context)
    {
        _context = context ?? throw new NullReferenceException("No reponse found :(");
    }

    public IEnumerable<Reponse> GetAll() => _context.Reponses;

    public Reponse GetById(int id) => getReponse(id);

    public void Create(Reponse reponse)
    {
        // validate
        if (_context.Reponses.Any(x => x.Description == reponse.Description))
            throw new AppException("Reponse with the title '" + reponse.Description + "' already exists");

        // save reponse
        _context.Reponses.Add(reponse);

        try
        {
            _context.SaveChanges();
        }
        catch (Exception)
        {
            _context.Reponses.Remove(reponse);
        }
    }

    public void Update(int id, Reponse model)
    {
        var reponse = getReponse(id);

        // validate
        if (_context.Reponses.Any(x => x.Description == model.Description))
            throw new AppException("Reponse with the title '" + model.Description + "' already exists");

        reponse.Description = model.Description;
        reponse.QuestionId = model.QuestionId;

        // copy model to reponse and save
        _context.Reponses.Update(model);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var reponse = getReponse(id);
        _context.Reponses.Remove(reponse);
        _context.SaveChanges();
    }

    // helper methods

    private Reponse getReponse(int id)
    {
        var reponse = _context.Reponses.Find(id);
        if (reponse == null) throw new KeyNotFoundException("reponse not found");
        return reponse;
    }
}
