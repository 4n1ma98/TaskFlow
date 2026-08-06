using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

public class FinancialProductsDbContext : DbContext
{
    public FinancialProductsDbContext(DbContextOptions<FinancialProductsDbContext> options)
        : base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mapeo explicito si es necesario
        modelBuilder.Entity<Client>().ToTable("Clients");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<ProductType>().ToTable("ProductTypes");
    }
}