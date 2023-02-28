using FronToBack.DAL;
using FronToBack.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace FronToBack.ViewComponents;

public class FooterViewComponent:ViewComponent
{
    private readonly AppDbContext _appDbContext;

    public FooterViewComponent(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

     public async Task<IViewComponentResult> InvokeAsync()
    {
    About about = _appDbContext.Abouts.FirstOrDefault();
    return View(await Task.FromResult(about));
   }


}