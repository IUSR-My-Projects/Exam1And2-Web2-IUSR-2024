using System;
using System.Collections.Generic;
using Exam1And2_Web2_IUSR.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam1And2_Web2_IUSR.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<customer> customers { get; set; }

    public virtual DbSet<order> orders { get; set; }

    public virtual DbSet<product> products { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer(
//             "Server=localhost;Database=MuhmadOmar;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<customer>(entity => { entity.HasKey(e => e.Id).HasName("customers_pk"); });

        modelBuilder.Entity<order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pk");

            entity.HasOne(d => d.customer).WithMany(p => p.orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders___fk");

            entity.HasOne(d => d.product).WithMany(p => p.orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_products_Id_fk");
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pk");

            entity.Property(e => e.Price).HasDefaultValue(0.0);
        });


        // Add Data to Products
        modelBuilder.Entity<product>().HasData(
            new product { Id = 1, Name = "Product 1", Price = 100, ninStock = "nin stock" },
            new product { Id = 2, Name = "Product 2", Price = 200, ninStock = "nin stock" },
            new product { Id = 3, Name = "Product 3", Price = 300, ninStock = "nin stock" },
            new product { Id = 4, Name = "Product 4", Price = 400, ninStock = "nin stock" },
            new product { Id = 5, Name = "Product 5", Price = 500, ninStock = "nin stock" },
            new product { Id = 6, Name = "Product 6", Price = 600, ninStock = "nin stock" },
            new product { Id = 7, Name = "Product 7", Price = 700, ninStock = "nin stock" },
            new product { Id = 8, Name = "Product 8", Price = 800, ninStock = "nin stock" }
        );

        // Add Data to Customers
        modelBuilder.Entity<customer>().HasData(
            new customer
            {
                Id = 1, Fname = "Customer 1", Lname = "Customer 1", Father = "Customer 1", PostalCode = 1234,
                Email = "Customer 1", phoneNumber = "123-123"
            },
            new customer
            {
                Id = 2, Fname = "Customer 2", Lname = "Customer 2", Father = "Customer 2", PostalCode = 2345,
                Email = "Customer 2", phoneNumber = "234-234"
            },
            new customer
            {
                Id = 3, Fname = "Customer 3", Lname = "Customer 3", Father = "Customer 3", PostalCode = 3456,
                Email = "Customer 3", phoneNumber = "345-345"
            }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}