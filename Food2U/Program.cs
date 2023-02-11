using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Food2U.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//JH
builder.Services.AddDbContext<Food2UContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("Food2UContext")));

var app = builder.Build();

//JH
/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}*/

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

app.MapRazorPages();

app.Run();
