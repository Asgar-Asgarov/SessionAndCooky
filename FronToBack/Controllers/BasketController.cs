using FronToBack.Models;
using Microsoft.AspNetCore.Mvc;
using FronToBack.DAL;
using Newtonsoft.Json;

namespace FronToBack.Controllers;

public class BasketController:Controller
{

private readonly AppDbContext _appDbContext;

    public BasketController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
        //  HttpContext.Session.SetString("name","Asgar");
         Response.Cookies.Append("name","Asgar",new CookieOptions{MaxAge=TimeSpan.FromDays(1)});
        return Content("set olundu");
    }

        public IActionResult GetItem()
    {
    //    string name = HttpContext.Session.GetString("name");
       string name = Request.Cookies["name"];
        return Content(name);
    }

     public async Task<IActionResult>  Add(int id,string name)
    {
        if(id==null) return NotFound();
        Product product = await _appDbContext.Products.FindAsync(id);
        List<Product> products =new();
        products.Add(product);
        Response.Cookies.Append("basket",
        JsonConvert.SerializeObject(products),
        new CookieOptions{MaxAge=TimeSpan.FromHours(1)});
      
        return RedirectToAction(nameof(Index),"Home");
    }

         public IActionResult ShowBasket()
    {
   
       string basket = Request.Cookies["basket"];
        return Content(basket);
    }


    
}