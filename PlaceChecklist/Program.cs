using Microsoft.EntityFrameworkCore;
using PlaceChecklist.BusinessService;
using PlaceChecklist.DbStuff;
using PlaceChecklist.DbStuff.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PlaceChecklistDb");
builder.Services.AddDbContext<WebDbContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

//BusinnesService
builder.Services.AddScoped<EstablishmentsBusinessService>();

//Repositories
builder.Services.AddScoped<EstablishmentRepository>();
builder.Services.AddScoped<TagRepository>();
builder.Services.AddScoped<CategoryRepository>();


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
    pattern: "{controller=PlaceChecklist}/{action=Index}/{id?}");

app.Run();
