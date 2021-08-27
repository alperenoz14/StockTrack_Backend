using Microsoft.EntityFrameworkCore;
using StockTrack_Backed_Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrack_Backend_Data
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NNE3V2L\MSSQLDATABASE;Database=StockTrackDB;Trusted_Connection=True",
                opt => opt.MigrationsAssembly("StockTrack_Backend_Data"));
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().HasKey(x => x.ID);
            modelBuilder.Entity<Plant>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Plant>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Plant>().Property(x => x.OrganizationETSOCode).IsRequired();
            modelBuilder.Entity<Plant>().Property(x => x.EIC).IsRequired();

            modelBuilder.Entity<Product>().HasKey(x => x.ID);
            modelBuilder.Entity<Product>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Order>().HasKey(x => x.ID);
            modelBuilder.Entity<Order>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Order>().Property(x => x.ProductId).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.PlantId).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.UnitPrice).IsRequired();
        }
    }
}
