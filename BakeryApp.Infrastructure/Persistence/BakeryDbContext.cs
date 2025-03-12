using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Domain.Entities;
using BakeryApp.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakeryApp.Infrastructure.Persistence
{
    public class BakeryDbContext : DbContext
    {
        public BakeryDbContext(DbContextOptions<BakeryDbContext> options) : base(options) { }


        public DbSet<BakeryOfficeEntity> BakeryOffices { get; set; }
        public DbSet<OrderListEntity> OrderLists { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        public DbSet<BreadEntity> Breads { get; set; }
        public DbSet<PreparationEntity> Preparations { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            var bakeryOffice1 = new BakeryOfficeEntity
            {
                Id = 1,
                Name = "Main Office",
                Address = "742 Evergreen Terrace",
                MaxCapacity = 150
            };

            var bakeryOffice2 = new BakeryOfficeEntity
            {
                Id = 2,
                Name = "Second Office",
                Address = "P. Sherman, 42 Wallaby, Sydney",
                MaxCapacity = 100
            };

            var preparation1 = new PreparationEntity
            {
                Id = 1,
                CookingTime = "15 minutes",
                RestingTime = "0.5 hours",
                FermentTime = "1 day",
                CookingTemp = "270°C"
            };

            var preparation2 = new PreparationEntity
            {
                Id = 2,
                CookingTime = "30 minutes",
                RestingTime = "1 hour",
                FermentTime = "4 hours",
                CookingTemp = "180°C"
            };

            var preparation3 = new PreparationEntity
            {
                Id = 3,
                CookingTime = "15 minutes",
                RestingTime = "10 minutes",
                FermentTime = "4 hours",
                CookingTemp = "180°C"
            };

            var preparation6 = new PreparationEntity
            {
                Id = 6,
                CookingTime = "15 minutes",
                RestingTime = "0.5 hour",
                FermentTime = "4 hours",
                CookingTemp = "180°C"
            };

            var bread1 = new BreadEntity
            {
                Name = "Baguette",
                Price = 2.0,
                PreparationId = 1
            };

            var bread2 = new BreadEntity
            {
                Name = "White Bread",
                Price = 2.5,
                PreparationId = 2
            };

            var bread3 = new BreadEntity
            {
                Name = "Milk Bread",
                Price = 1.5,
                PreparationId = 3
            };

            var bread6 = new BreadEntity
            {
                Name = "Hamburguer Bun",
                Price = 1.0,
                PreparationId = 6
            };

            modelBuilder.Entity<BakeryOfficeEntity>().HasData(bakeryOffice1, bakeryOffice2);
            modelBuilder.Entity<BreadEntity>().HasData(bread1, bread2, bread3, bread6);
            modelBuilder.Entity<PreparationEntity>().HasData(preparation1, preparation2, preparation3, preparation6);

            modelBuilder.Entity<BreadEntity>()
                .HasKey(b => b.Name);

            modelBuilder.Entity<BreadEntity>()
                .HasOne(b => b.Preparation)
                .WithMany()
                .HasForeignKey(b => b.PreparationId);

            modelBuilder.Entity<BakeryOfficeEntity>()
                .HasMany(bo => bo.Menu)
                .WithMany(b => b.BakeryOffices)
                .UsingEntity<Dictionary<string, object>>(
                    "BakeryOfficeBread",
                    j => j.HasData(
                        new { BakeryOfficesId = 1, MenuName = "Baguette" },
                        new { BakeryOfficesId = 1, MenuName = "White Bread" },
                        new { BakeryOfficesId = 1, MenuName = "Milk Bread" },
                        new { BakeryOfficesId = 2, MenuName = "Baguette" },
                        new { BakeryOfficesId = 2, MenuName = "White Bread" },
                        new { BakeryOfficesId = 2, MenuName = "Hamburguer Bun" }
                    )
                );
        }
    }
}
