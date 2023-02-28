using Microsoft.EntityFrameworkCore;
using FronToBack.Models;
namespace FronToBack.DAL;
public class AppDbContext : DbContext
{
   
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

         public DbSet<Slider> Sliders{get;set;}
         public DbSet<SliderDetail> SliderDetails {get;set;}
         public DbSet<Category> Categories{get;set;}
         public DbSet<Product> Products{get;set;}
         public DbSet<ProductImage> ProductImages{get;set;}
         public DbSet<Bio> Bios{get;set;}
         public DbSet<About> Abouts{get;set;}
             
} 