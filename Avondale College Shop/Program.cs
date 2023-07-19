using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Avondale_College_Shop.Areas.Identity.Data;
using Microsoft.Extensions.ObjectPool;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Avondale_College_Shop
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("AvondaleDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AvondaleDbContextConnection' not found.");

            builder.Services.AddDbContext<AvondaleDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentity<AvondaleCollegeShopUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<AvondaleCollegeShopUser>()
                .AddEntityFrameworkStores<AvondaleDbContext>().AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddRazorPages();

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
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Employee" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));

                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AvondaleCollegeShopUser>>();

                string Aemail = "admin@avondalecollege.com";
                string Apassword = "Admin123$";

                string Eemail = "employee@avondalecollege.com";
                string Epassword = "Employee123$";

                if(await userManager.FindByEmailAsync(Aemail) == null)
                {
                    var user = new AvondaleCollegeShopUser();
                    user.UserName = Aemail;
                    user.Email = Aemail;
                    user.FirstName = "Admin";
                    user.LastName = "Account";

                    await userManager.CreateAsync(user, Apassword);
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                if (await userManager.FindByEmailAsync(Eemail) == null)
                {
                    var user = new AvondaleCollegeShopUser();
                    user.UserName = Eemail;
                    user.Email = Eemail;
                    user.FirstName = "Employee";
                    user.LastName = "Account";

                    await userManager.CreateAsync(user, Epassword);
                    await userManager.AddToRoleAsync(user, "Employee");
                }

            }
                app.Run();

        }
    }
}

