using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PracticeModelValidation.Data;
using PracticeModelValidation.Helpers.CustomValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PracticeModelValidationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PracticeModelValidationContext") ?? throw new InvalidOperationException("Connection string 'PracticeModelValidationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register your Custom Validation Provider here
builder.Services.AddSingleton<IValidationAttributeAdapterProvider, AdapterProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
