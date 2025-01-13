using LanguageInstall.Data.Data;
using LanguageInstall.Service.Service;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("con")));


builder.Services.AddScoped<ITranslationService, TranslationService>();
builder.Services.AddScoped<ILocalizationService, LocalizationService>();


builder.Services.AddHttpClient<TranslationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    var language = context.Request.Cookies["Language"] ?? "en"; // Default to English
    context.Items["Language"] = language;
    await next();
});


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
