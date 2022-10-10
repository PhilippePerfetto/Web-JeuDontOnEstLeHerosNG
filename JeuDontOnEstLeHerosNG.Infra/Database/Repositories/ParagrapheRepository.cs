
using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Infra.Helpers;

namespace JeuDontOnEstLeHerosNG.Infra.Database.Repositories;

public interface IParagrapheRepository
{
    IEnumerable<Paragraphe> GetAll();
    Paragraphe GetById(int id);
    void Create(Paragraphe model);
    void Update(int id, Paragraphe model);
    void Delete(int id);
}

public class ParagrapheRepository : IParagrapheRepository
{
    private readonly AventureDataContext _context;

    public ParagrapheRepository(AventureDataContext context)
    {
        _context = context ?? throw new NullReferenceException("No Paragraphes found :(");
    }

    public IEnumerable<Paragraphe> GetAll() => _context.Paragraphes;

    public Paragraphe GetById(int id) => getParagraphe(id);

    public void Create(Paragraphe model)
    {
        // validate
        if (_context.Paragraphes.Any(x => x.Title == model.Title))
            throw new AppException("Paragraphe with the title '" + model.Title + "' already exists");

        // map model to new Paragraphe object
        var paragraphe = new Paragraphe { Numero = model.Numero, Title = model.Title, Description = model.Description };

        // save paragraphe
        _context.Paragraphes.Add(paragraphe);
        _context.SaveChanges();
    }

    public void Update(int id, Paragraphe model)
    {
        var paragraphe = getParagraphe(id);

        // validate
        if (_context.Paragraphes.Any(x => x.Title == model.Title))
            throw new AppException("Paragraphe with the title '" + model.Title + "' already exists");

        // copy model to paragraphe and save
        _context.Paragraphes.Update(paragraphe);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var paragraphe = getParagraphe(id);
        _context.Paragraphes.Remove(paragraphe);
        _context.SaveChanges();
    }

    // helper methods

    private Paragraphe getParagraphe(int id)
    {
        var paragraphe = _context.Paragraphes.Find(id);
        if (paragraphe == null) throw new KeyNotFoundException("Paragraphe not found");
        return paragraphe;
    }
}
