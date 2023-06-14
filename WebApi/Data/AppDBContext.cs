using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApi.Models;
using WebApi.Utils;

namespace WebApi.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e => {
            e.ToTable("Users");
        });

        modelBuilder.Entity<Product>(e => {
            e.ToTable("Products");
        });

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = Guid.Parse("5C12B6B1-26BE-454A-B32E-FEE36D0853C1"), Name = "PC", Description = "PC One", Image = null, Price = 10, Quantity = 120 },
            new Product { Id = Guid.Parse("7D0BC73F-89EC-48D4-8417-2D7E785AEC77"), Name = "Smart Watch", Description = "Smart Watch", Image = null, Price = 15, Quantity = 500 },
            new Product { Id = Guid.Parse("1DCC375D-752E-4E2D-BEA0-571BB849AC46"), Name = "Mobile Phone", Description = "Mobiles", Image = null, Price = 12, Quantity = 1308 },
            new Product { Id = Guid.Parse("7E87E47D-BD80-4F0F-8ECA-A70764079DD0"), Name = "Television", Description = "TV", Image = null, Price = 12, Quantity = 340 },
            new Product { Id = Guid.Parse("0F1D41E8-F929-4F99-B0A7-F82D3CE557E9"), Name = "IPad", Description = "IPAD", Image = null, Price = 10, Quantity = 34 }
        );

        modelBuilder.Entity<User>().HasData(new User { UserName = "admin@test.com", PasswordHash = PasswordHasher.HashPassword("admin@123"), NormalizedUserName = "admin@test.com".ToUpper(), Email = "admin@test.com".ToUpper(), NormalizedEmail = "admin@test.com".ToUpper() });

        base.OnModelCreating(modelBuilder);
    }
}
