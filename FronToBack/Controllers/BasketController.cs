using Microsoft.AspNetCore.Mvc;

namespace FronToBack.Controllers;

public class BasketController:Controller
{
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

    
}