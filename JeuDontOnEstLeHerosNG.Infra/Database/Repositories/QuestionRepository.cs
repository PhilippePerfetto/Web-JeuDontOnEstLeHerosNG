
using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Infra.Helpers;

namespace JeuDontOnEstLeHerosNG.Infra.Database.Repositories;

public interface IQuestionRepository
{
    IEnumerable<Question> GetAll();
    Question GetById(int id);
    void Create(Question model);
    void Update(int id, Question model);
    void Delete(int id);
}

public class QuestionRepository : IQuestionRepository
{
    private readonly AventureDataContext _context;

    public QuestionRepository(AventureDataContext context)
    {
        _context = context ?? throw new NullReferenceException("No question found :(");
    }

    public IEnumerable<Question> GetAll() => _context.Questions;

    public Question GetById(int id) => getQuestion(id);

    public void Create(Question question)
    {
        // validate
        if (_context.Questions.Any(x => x.Title == question.Title))
            throw new AppException("Question with the title '" + question.Title + "' already exists");

        // save question
        _context.Questions.Add(question);

        try
        {
            _context.SaveChanges();
        }
        catch (Exception)
        {
            _context.Questions.Remove(question);
        }
    }

    public void Update(int id, Question model)
    {
        var question = getQuestion(id);

        // validate
        if (_context.Questions.Any(x => x.Title == model.Title))
            throw new AppException("Question with the title '" + model.Title + "' already exists");

        question.Title = model.Title;
        question.ParagrapheId = model.ParagrapheId;

        // copy model to question and save
        _context.Questions.Update(model);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var question = getQuestion(id);
        _context.Questions.Remove(question);
        _context.SaveChanges();
    }

    // helper methods

    private Question getQuestion(int id)
    {
        var question = _context.Questions.Find(id);
        if (question == null) throw new KeyNotFoundException("question not found");
        return question;
    }
}
