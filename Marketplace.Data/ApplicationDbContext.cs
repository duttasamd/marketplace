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

    }
}
