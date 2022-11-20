using UIDTSYS.Models;
using UIDTSYS.Services;

var builder = WebApplication.CreateBuilder(args);

//
builder.Services.Configure<Settings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<UfrService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
