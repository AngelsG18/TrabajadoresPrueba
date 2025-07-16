using Microsoft.EntityFrameworkCore;
using PRY_TrabajadoresPrueba.Data;
using PRY_TrabajadoresPrueba.Repository;
using PRY_TrabajadoresPrueba.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

//Repositorios y Servicios
builder.Services.AddScoped<TrabajadorRepository>();
builder.Services.AddScoped<TrabajadorService>();

builder.Services.AddScoped<TablasRepository>();
builder.Services.AddScoped<TablasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
