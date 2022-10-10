using AutoMapper;
using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Infra.Database.Repositories;
using JeuDontOnEstLeHerosNG.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontOnEstLeHerosNG.Web.Controllers;

public class ParagrapheController : Controller
{
    private readonly IParagrapheRepository paragrapheRepository;
    private readonly IMapper mapper;

    public ParagrapheController(IParagrapheRepository paragrapheRepository, IMapper mapper)
    {
        this.paragrapheRepository = paragrapheRepository;
        this.mapper = mapper;
    }

    public IActionResult Index()
    {
        ViewBag.MonTitle = "Aventures (UI)";
        return View(paragrapheRepository.GetAll().ToList());
    }

    [HttpPost]
    public IActionResult Create(CreateParagrapheRequest paragraphe)
    {
        paragrapheRepository.Create(new Paragraphe { Numero = paragraphe.Numero, Title = paragraphe.Title, Description = paragraphe.Description });

        return Redirect("~/Paragraphe");
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        return View(paragrapheRepository.GetAll().First(x => x.Id == id));
    }

    [HttpPost]
    public IActionResult Edit(UpdateParagrapheRequest parRequest)
    {
        if (parRequest != null)
        {
            var bddParagraphe = paragrapheRepository.GetById(parRequest.Id);
            bddParagraphe.Title = parRequest.Title;
            bddParagraphe.Description = parRequest.Description;
            paragrapheRepository.Update(parRequest.Id, mapper.Map<Paragraphe>(parRequest));
        }

        return View();
    }
}
