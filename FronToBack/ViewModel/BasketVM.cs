using FronToBack.Models;
namespace FronToBack.ViewModel;

public class BasketVM
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public string  ImageUrl { get; set; }
    public int BasketCount { get; set; }
    public double Price { get; set; }
}