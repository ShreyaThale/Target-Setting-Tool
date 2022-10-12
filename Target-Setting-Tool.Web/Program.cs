using Microsoft.EntityFrameworkCore;
using TargetSettingTool.Web.Context;
using TargetSettingTool.Web.RightsServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRightsService, RightsService>();
var YashConnectionString = builder.Configuration.GetConnectionString("YashConnectionstring");
builder.Services.AddDbContext<ApplicationDbContext>(u => u.UseSqlServer(YashConnectionString));

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
