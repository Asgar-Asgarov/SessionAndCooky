using Microsoft.EntityFrameworkCore;
using FronToBack.DAL;


var builder = WebApplication.CreateBuilder(args);
var _config=builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options=>{
options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
// options.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);  //2nd way .This way is not good,because writing strings in this way aren`t liked.

}

);
builder.Services.AddSession(options=>{
 options.IdleTimeout=TimeSpan.FromSeconds(15);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
