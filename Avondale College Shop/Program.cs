using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Avondale_College_Shop.Areas.Identity.Data;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("AvondaleDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AvondaleDbContextConnection' not found.");
builder.Services.AddDbContext<AvondaleDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AvondaleCollegeShopUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AvondaleDbContext>().AddDefaultTokenProviders();

// Add services to the container.

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();