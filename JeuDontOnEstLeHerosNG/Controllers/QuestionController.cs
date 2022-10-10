using AutoMapper;
using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Infra.Database.Repositories;
using JeuDontOnEstLeHerosNG.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontOnEstLeHerosNG.Web.Controllers;

public class QuestionController : Controller
{
    private readonly IQuestionRepository questionRepository;
    private readonly IParagrapheRepository paragrapheRepository;
    private readonly IMapper mapper;

    public QuestionController(IParagrapheRepository paragrapheRepository, IQuestionRepository questionRepository, IMapper mapper)
    {
        this.questionRepository = questionRepository;
        this.paragrapheRepository = paragrapheRepository;
        this.mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        ViewBag.Paragraphes = paragrapheRepository.GetAll().ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateQuestionRequest request)
    {
        var question = new Question { Title = request.Title, ParagrapheId = request.ParagrapheId };

        if (ModelState.IsValid)
        {
            questionRepository.Create(question);
        }

        ViewBag.Paragraphes = paragrapheRepository.GetAll().ToList();
        return View();
    }
}
