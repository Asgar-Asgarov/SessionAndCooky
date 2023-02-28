namespace FronToBack.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
   public List<ProductImage> productImages { get; set; }
}