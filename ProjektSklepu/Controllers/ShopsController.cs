using BD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektSklepu.Models;

namespace ProjektSklepu.Controllers;

public class ShopsController : Controller
{
    public ShopItemViewModel ShopItemViewModel { get; set; } = new ShopItemViewModel()
    {
        ShopViewModels = new List<ShopViewModel>()
        {
            new ShopViewModel(1,"IT","Warszawa","Polska","Warszawska","42-444"),
            new ShopViewModel(2,"IT","Bielsko-Biała","Polska","Warszawska","43-444"),
            new ShopViewModel(3,"IT","Kraków","Polska","Warszawska","44-444"),
            new ShopViewModel(4,"IT","Katowice","Polska","Warszawska","45-444"),
        }
    };
    // GET: ShopsController
    public ActionResult Index()
    {
        return View(ShopItemViewModel.ShopViewModels);
    }

    public void Test()
    {
        
    }

    // GET: ShopsController/Details/5
    public ActionResult Details(int id)
    {
        return View(ShopItemViewModel.ShopViewModels[id]);
    }

    // GET: ShopsController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ShopsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ShopsController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ShopsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ShopsController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ShopsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
