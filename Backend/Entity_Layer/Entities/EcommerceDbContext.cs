using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity_Layer.Entities;

public partial class EcommerceDbContext : DbContext
{
    public EcommerceDbContext()
    {
    }

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-G6S85J4G; Database=ecommerceDB; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.CustomerEmail).HasName("customer_id_pk");

            entity.ToTable("Customer_Details");

            entity.Property(e => e.CustomerEmail)
                .IsUnicode(false)
                .HasColumnName("Customer_Email");
            entity.Property(e => e.CustomerAddressLine1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Customer_AddressLine_1");
            entity.Property(e => e.CustomerAddressLine2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Customer_AddressLine_2");
            entity.Property(e => e.CustomerCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Customer_City");
            entity.Property(e => e.CustomerMobileNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Customer_MobileNo");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Customer_Name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order_id_pk");

            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasColumnName("Customer_Email");
            entity.Property(e => e.DeliveryDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Delivery_Date");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Order_Date");
            entity.Property(e => e.ShipmentCity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Shipment_City");
            entity.Property(e => e.ShipmentStatus).HasColumnName("Shipment_Status");

            entity.HasOne(d => d.CustomerEmailNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerEmail)
                .HasConstraintName("order_id_customer_fk");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("orderitem_id_pk");

            entity.ToTable("Order_Items");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItem_ID");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.TotalPrice)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnitPrice)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("orderitem_orderid_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("orderitem_productid_fk");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("product_id_pk");

            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Product_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
