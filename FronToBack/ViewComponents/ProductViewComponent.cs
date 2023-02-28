using FronToBack.DAL;
using FronToBack.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FronToBack.ViewComponents;

public class ProductViewComponent:ViewComponent
{
    private readonly AppDbContext _appDbContext;

    public ProductViewComponent(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

     public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = _appDbContext
       .Categories
       .Include(c => c.products)
       .ToList();
        var products = _appDbContext.Products
        .Include(p=>p.productImages)
        .ToList();
        return View(await Task.FromResult(categories));
    }

   
}