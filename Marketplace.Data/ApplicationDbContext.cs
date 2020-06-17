using System;
using Microsoft.EntityFrameworkCore;
using Marketplace.Models;

namespace Marketplace.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        DbSet<Order> Orders { get; set; }

        DbSet<Item> Items { get; set; }

        DbSet<ItemType> ItemTypes { get; set; }

        DbSet<SubOrder> SubOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(p => p.ItemType)
                .WithMany(b => b.Items)
                .HasForeignKey(k => k.ItemTypeID);

            modelBuilder.Entity<SubOrder>()
                .HasOne(p => p.Item)
                .WithMany()
                .HasForeignKey(k => k.ItemID);

            modelBuilder.Entity<SubOrder>()
                .HasOne(p => p.Order)
                .WithMany(o => o.SubOrders)
                .HasForeignKey(k => k.OrderID);
        }
    }
}
