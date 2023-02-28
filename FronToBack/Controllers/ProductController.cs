using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FronToBack.Models;
using FronToBack.DAL;
using FronToBack.ViewModel;
namespace FronToBack.Controllers;


public class ProductController : Controller
{

private readonly AppDbContext _appDbContext;
private static int skip = 2;
    public ProductController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
       ViewBag.ProductCount=_appDbContext.Products.Count();
       var Categories = _appDbContext
       .Categories
        .Include(c => c.products)   
        .Take(2)
        .ToList();
        var products = _appDbContext.Products
        .Include(p=>p.productImages)
        .ToList();
        return View(Categories);
    }
    public IActionResult LoadMore(){
        var Categories = _appDbContext
       .Categories
        .Include(c => c.products)
        .Skip(skip)  
        .Take(3)
        .ToList();
        var products = _appDbContext.Products
        .Include(p=>p.productImages)
        .ToList();
        skip +=2;
        return View("_ProductLoadMorePartial.cshtml",Categories);
        
    }

}