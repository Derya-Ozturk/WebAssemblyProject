using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess.Concrete.EntityFramework.Context;

public partial class OkdbContext : DbContext
{
    public readonly string? connection;

    public OkdbContext()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
                           .Build();

        connection = configuration.GetConnectionString("DefaultConnection");

    }

    public OkdbContext(DbContextOptions<OkdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<SalesRepresentive> SalesRepresentives { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(connection);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerNo);

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerName).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNo);

            entity.ToTable("Order");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerRequestDate).HasColumnType("datetime");
            entity.Property(e => e.RevisedDueDate).HasColumnType("datetime");

            entity.HasOne(d => d.Creator).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("FK_Order_User");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerNo)
                .HasConstraintName("FK_Order_Customer");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusNo)
                .HasConstraintName("FK_Order_OrderStatus");

            entity.HasOne(d => d.SalesRepresentive).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SalesRepresentiveId)
                .HasConstraintName("FK_Order_SalesRepresentive");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusNo);

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Description).HasMaxLength(200);
        });

        modelBuilder.Entity<SalesRepresentive>(entity =>
        {
            entity.ToTable("SalesRepresentive");

            entity.Property(e => e.PersonImage).HasMaxLength(100);
            entity.Property(e => e.SalesRepresentiveAbbr)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SalesRepresentiveName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Mail).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
