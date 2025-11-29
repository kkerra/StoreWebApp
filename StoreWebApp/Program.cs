using StoreWebApp.Contexts;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<Dbde3503Context>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru-RU")
{
    NumberFormat = { NumberDecimalSeparator = "." }
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseAuthentication();
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
