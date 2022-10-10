using AutoMapper;
using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Infra.Database.Repositories;
using JeuDontOnEstLeHerosNG.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontOnEstLeHerosNG.Web.Controllers;

public class ReponseController : Controller
{
    private readonly IQuestionRepository questionRepository;
    private readonly IParagrapheRepository paragrapheRepository;
    private readonly IReponseRepository reponseRepository;
    private readonly IMapper mapper;

    public ReponseController(IParagrapheRepository paragrapheRepository, IQuestionRepository questionRepository, IReponseRepository reponseRepository, IMapper mapper)
    {
        this.questionRepository = questionRepository;
        this.paragrapheRepository = paragrapheRepository;
        this.reponseRepository = reponseRepository;
        this.mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        ViewBag.Questions = questionRepository.GetAll().ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateReponseRequest request)
    {
        var reponse = new Reponse { Description = request.Description, QuestionId = request.QuestionId };

        if (ModelState.IsValid)
        {
            reponseRepository.Create(reponse);
        }

        ViewBag.Questions = questionRepository.GetAll().ToList();
        return View();
    }
}
