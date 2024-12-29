using FirmaSiparisYonetimi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaSiparisYonetimi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
       
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        public AppDbContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ///**** relationship for order Table
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Company)
                .WithMany(p=>p.Orders)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d=>d.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            });

            ///***relationShip for product
            ///
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Price).HasPrecision(18, 2); // Specify the SQL column type
                entity.HasKey(p =>p.Id );
                entity.HasOne(p => p.Company)
                .WithMany(p=>p.Products)
                .HasForeignKey(p => p.CompanyId);
            });


           
           

        }


    }
}


/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 modelBuilder.Entity<Company>(entity =>
            {
                entity.HasMany(p => p.Products)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            });
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasMany(p => p.Orders)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            });

 
 
 
 
 
 */