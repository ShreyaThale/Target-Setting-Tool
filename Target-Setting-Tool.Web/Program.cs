using Microsoft.EntityFrameworkCore;
using Target_Setting_Tool.Web.Contexts;
using Target_Setting_Tool.Web.Services.RightsServices;
using Target_Setting_Tool.Web.Services.RolesServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRightsService, RightsService>();
builder.Services.AddScoped<IRolesService, RolesService>();
string connectionString = builder.Configuration.GetConnectionString("ShreyaConnectionstring");
builder.Services.AddDbContext<ApplicationDbContext>(u => u.UseSqlServer(connectionString));

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
    pattern: "{controller=Rights}/{action=GetAllRights}/{id?}");

app.Run();
