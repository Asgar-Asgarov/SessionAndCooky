using FronToBack.Models;
namespace FronToBack.ViewModel;


public class HomeVM
{
    public List<Slider> Sliders { get; set; }
    public SliderDetail SliderDetail {get; set;}
    public List<Category> Categories { get; set; }
    public List<Product> Products { get; set; }
    public List<ProductImage> ProductImages { get; set; }
}