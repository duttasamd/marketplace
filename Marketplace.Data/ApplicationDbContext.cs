using System;
using Microsoft.EntityFrameworkCore;
using Marketplace.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Marketplace.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        DbSet<Order> Orders { get; set; }

        DbSet<Item> Items { get; set; }

        DbSet<ItemType> ItemTypes { get; set; }

        DbSet<OrderItem> SubOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemSubType>()
                .HasOne(p => p.ItemType)
                .WithMany(b => b.ItemSubTypes)
                .HasForeignKey(k => k.ItemTypeId);

            modelBuilder.Entity<Item>()
                .HasOne(p => p.ItemSubType)
                .WithMany(b => b.Items)
                .HasForeignKey(k => k.ItemSubTypeID);

            modelBuilder.Entity<OrderItem>()
                .HasOne(p => p.Item)
                .WithMany()
                .HasForeignKey(k => k.ItemID);

            modelBuilder.Entity<OrderItem>()
                .HasOne(p => p.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(k => k.OrderID);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(o => o.Orders)
                .HasForeignKey(k => k.ApplicationUserId);
        }
    }
}
