using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorAuthDemo.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Database>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AddUser>();
builder.Services.AddScoped<AddProject>();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<Database>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Index1";
});


builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

// skriven med mycket hjälp av AI