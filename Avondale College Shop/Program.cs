using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Avondale_College_Shop.Areas.Identity.Data;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("AvondaleDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AvondaleDbContextConnection' not found.");
builder.Services.AddDbContext<AvondaleDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddIdentity<AvondaleCollegeShopUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<AvondaleDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
options => {
    options.Stores.MaxLengthForKeys = 128;
})
.AddEntityFrameworkStores<AvondaleDbContext>()
.AddRoles<IdentityRole>()
.AddDefaultUI()
.AddDefaultTokenProviders();

builder.Services.AddRazorPages();

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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AvondaleDbContext>();

    context.Database.Migrate();

    var userMgr = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();

    IdentitySeedData.Initialize(context, userMgr, roleMgr).Wait();
}
app.Run();