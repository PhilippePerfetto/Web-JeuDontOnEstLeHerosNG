using AutoMapper;
using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Infra.Database.Repositories;
using JeuDontOnEstLeHerosNG.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontOnEstLeHerosNG.Web.Controllers;

public class AventureController : Controller
{
    private readonly IAventureRepository aventureRepository;
    private readonly IMapper mapper;

    public AventureController(IAventureRepository aventureRepository, IMapper mapper)
    {
        this.aventureRepository = aventureRepository;
        this.mapper = mapper;
    }

    public IActionResult Index()
    {
        ViewBag.MonTitle = "Aventures (UI)";
        return View(aventureRepository.GetAll().ToList());
    }

    [HttpPost]
    public IActionResult Create(CreateAventureRequest aventureRequest)
    {
        aventureRepository.Create(new Aventure { DateDeCreation = DateTime.Now, Title = aventureRequest.Title });
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        return View(aventureRepository.GetById(id));
    }
}
