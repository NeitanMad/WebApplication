using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class DataContext : DbContext
{
    public DbSet<ProductsStorage> ProductsStorages { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=192.168.50.40;Port=5432;Database=storage;Username=postgres;Password=example123");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(product =>
        {
            product.ToTable("Products");

            product.HasKey(x => x.Id).HasName("ProductID");
            product.HasIndex(x => x.Name).IsUnique();

            product.Property(e => e.Name)
                .HasColumnName("ProductName")
                .HasMaxLength(255)
                .IsRequired();

            product.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired();

            product.Property(e => e.Cost)
                .HasColumnName("Price")
                .IsRequired();

            product.HasOne(x => x.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(x => x.Id)
                .HasConstraintName("ProductsToCategory");

            product.HasMany(x => x.Storages)
                .WithMany(y => y.Products)
                .UsingEntity<ProductsStorage>();
        });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Categories");

            category.HasKey(x => x.Id).HasName("CategoryId");
            category.HasIndex(x => x.Name).IsUnique();

            category.Property(x => x.Name)
                .HasColumnName("CategoryName");
            { }
        });

        modelBuilder.Entity<Storage>(storage =>
        {
            storage.ToTable("Storage");

            modelBuilder.Entity<Storage>(storage =>
            {
                storage.ToTable("Storage");

                storage.HasMany(e => e.Products)
                    .WithMany(e => e.Storages)
                    .UsingEntity<ProductsStorage>();
            });
        });
    }
}