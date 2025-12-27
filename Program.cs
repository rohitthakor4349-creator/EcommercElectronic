using Ecommerce.Entity;
using Ecommerce.NTier;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//API Call
builder.Services.AddControllers();
// register Entity Framework

builder.Services.AddDbContext<EntityDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("dbcon"));
});

// NTier Services Using Dependancy Injection
builder.Services.AddScoped<ICategoryTblServices, CategoryTblServices>();
builder.Services.AddScoped<ISubCategoryTblServices, SubCategoryTblServices>();
builder.Services.AddScoped<IThirdCategoryTblServices, ThirdCategoryTblServices>();
builder.Services.AddScoped<IBrandTblServices, BrandTblServices>();
builder.Services.AddScoped<IProductTblServices, ProductTblServices>();
builder.Services.AddScoped<IProductTblServices, ProductTblServices>();
builder.Services.AddScoped<ICountryTblSevices, CountryTblSevices>();
builder.Services.AddScoped<IStateTblServices, StateTblServices>();
builder.Services.AddScoped<ICityTblServices, CityTblServices>();
builder.Services.AddScoped<IMenuServices, MenuServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapimg Pipeline
app.MapControllers();

app.MapRazorPages();

app.Run();
