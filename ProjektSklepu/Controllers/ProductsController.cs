#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BD;
using AutoMapper;
using ProjektSklepu.Models;
using ProjektSklepu.Services;

namespace ProjektSklepu.Controllers;

public class ProductsController : Controller
{
    //private readonly Context _context;
    private readonly IRepositoryService<Produkt> _repositoryProduktService;
    private readonly IRepositoryService<Kategoria> _repositoryCategoryService;
    private readonly IMapper _mapper;

    public ProductsController(IRepositoryService<Produkt> repositoryService, IRepositoryService<Kategoria> repositoryCategoryService, IMapper mapper)
    {
        //_context = context;
        _repositoryProduktService = repositoryService;
        _repositoryCategoryService = repositoryCategoryService;
        _mapper = mapper;


        if (_repositoryProduktService.GetSingle(1) == null)
        {
            _repositoryCategoryService.Add(
                new Kategoria()
                {
                    Id = 1,
                    NazwaKategorii = "Napoje"
                });
            _repositoryCategoryService.Add(
                new Kategoria()
                {
                    Id = 2,
                    NazwaKategorii = "Mieso"
                });
            _repositoryCategoryService.Add(
                new Kategoria()
                {
                    Id = 3,
                    NazwaKategorii = "Owoce"
                });
            _repositoryProduktService.Add(new Produkt()
            {
                Id = 1,
                Nazwa = "Cola",
                Opis = "Takie słodkie niezdrowe",
                Cena = 20,
                Kategoria = _repositoryCategoryService.GetSingle(1)
            });
        }
    }

    // GET: Products
    public async Task<IActionResult> Index()
    {
        var temp = _repositoryProduktService.GetAllRecords();

        var produktViewModel = new List<ProduktViewModel>();

        _mapper.Map(temp, produktViewModel);

        return View(produktViewModel);
    }

    // GET: Products/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var produkt = _repositoryProduktService.GetSingle((int)id);

        if (produkt == null)
            return NotFound();

        var produktViewModel = _mapper.Map<ProduktViewModel>(produkt);

        return View(produktViewModel);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
        IEnumerable<KategoriaViewModel> temp = new List<KategoriaViewModel>();
        _mapper.Map(_repositoryCategoryService.GetAllRecords(), temp);
        ViewBag.Kategoria = new SelectList(temp, "Id", "NazwaKategorii");
        return View();
    }

    // POST: Products/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nazwa,Opis,Kategoria,Cena")] ProduktViewModel produkt)
    {
        if (ModelState.IsValid)
        {
            var newProdukt = _mapper.Map<Produkt>(produkt);
            //var temp = new Produkt();
            _repositoryProduktService.Add(newProdukt);
            return RedirectToAction(nameof(Index));
        }
        IEnumerable<KategoriaViewModel> temp = new List<KategoriaViewModel>();
        _mapper.Map(_repositoryCategoryService.GetAllRecords(), temp);
        ViewBag.Kategoria = new SelectList(temp, "Id", "NazwaKategorii");
        return View(produkt);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var produkt = _mapper.Map<ProduktViewModel>(_repositoryProduktService.GetSingle((int)id));

        if (produkt == null)
            return NotFound();
        IEnumerable<KategoriaViewModel> temp = new List<KategoriaViewModel>();
        _mapper.Map(_repositoryCategoryService.GetAllRecords(), temp);
        ViewBag.Kategoria = new SelectList(temp, "Id", "NazwaKategorii", produkt.Kategoria);

        return View(produkt);
    }

    // POST: Products/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Opis,Kategoria,Cena")] ProduktViewModel produkt)
    {
        if (id != produkt.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                var editProduct = _mapper.Map<Produkt>(produkt);
                _repositoryProduktService.Edit(editProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduktExists(produkt.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        IEnumerable<KategoriaViewModel> temp = new List<KategoriaViewModel>();
        _mapper.Map(_repositoryCategoryService.GetAllRecords(), temp);
        ViewBag.Kategoria = new SelectList(temp, "Id", "NazwaKategorii");
        return View(produkt);
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var produkt = _repositoryProduktService.GetSingle((int)id);

        if (produkt == null)
            return NotFound();
        return View(produkt);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        _repositoryProduktService.Delete(_repositoryProduktService.GetSingle(id));
        return RedirectToAction(nameof(Index));
    }

    private bool ProduktExists(int id)
    {
        return _repositoryProduktService.GetSingle(id) != null;
    }
}

