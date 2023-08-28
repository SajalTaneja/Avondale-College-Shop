using Avondale_College_Shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Avondale_College_Shop.Models;

namespace Avondale_College_Shop.Areas.Identity.Data;

public class AvondaleDbContext : IdentityDbContext<AvondaleCollegeShopUser>
{
    public AvondaleDbContext(DbContextOptions<AvondaleDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

    }

    internal static object Initialize(AvondaleDbContext context, UserManager<IdentityUser> userMgr, RoleManager<IdentityRole> roleMgr)
    {
        throw new NotImplementedException();
    }

    private class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<AvondaleCollegeShopUser>
    {
        public void Configure(EntityTypeBuilder<AvondaleCollegeShopUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(155);
            builder.Property(u => u.FirstName).HasMaxLength(155);

        }
    }

    public DbSet<Avondale_College_Shop.Models.Customer>? Customer { get; set; }

    public DbSet<Avondale_College_Shop.Models.Order>? Order { get; set; }

    public DbSet<Avondale_College_Shop.Models.Product>? Product { get; set; }

    public DbSet<Avondale_College_Shop.Models.Shipment>? Shipment { get; set; }
}

