using BE_ProgettoSettimana4.Data;
using BE_ProgettoSettimana4.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GestioneSanzioniDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services
    .AddScoped<IAnagraficaService, AnagraficaService>()
    .AddScoped<IViolazioneService, ViolazioneService>()
    .AddScoped<IVerbaleService, VerbaleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Riepilogo}/{id?}");

app.Run();
