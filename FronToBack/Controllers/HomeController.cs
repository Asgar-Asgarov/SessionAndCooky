using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FronToBack.Models;
using FronToBack.DAL;
using FronToBack.ViewModel;
namespace FronToBack.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _appDbContext;

    public HomeController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
        HomeVM homeVM = new HomeVM();
        homeVM.Sliders = _appDbContext.Sliders.ToList();
        homeVM.SliderDetail = _appDbContext
        .SliderDetails.FirstOrDefault();
        homeVM.Categories = _appDbContext.Categories
        .Include(c => c.products).ToList();
        homeVM.Products = _appDbContext.Products
        .Include(p => p.productImages)
        .ToList();
        homeVM.ProductImages = _appDbContext.ProductImages.ToList();

        return View(homeVM);

    }



}
