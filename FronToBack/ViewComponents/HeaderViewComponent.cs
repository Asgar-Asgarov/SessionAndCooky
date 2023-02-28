using FronToBack.DAL;
using FronToBack.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace FronToBack.ViewComponents;

public class HeaderViewComponent:ViewComponent
{
    private readonly AppDbContext _appDbContext;

    public HeaderViewComponent(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
       Bio bio = _appDbContext.Bios.FirstOrDefault();
       return View(await Task.FromResult(bio));
    }


}