using Microsoft.EntityFrameworkCore;
using OtoparkTakipSistemi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoparkTakipSistemi.DataAccess
{
    public class OtoparkDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string dbPath = System.IO.Path.Combine(documentsPath, "OtoparkDb.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<ParkingRecord> ParkingRecords { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tariff>().HasData(
                new Tariff
                {
                    Id = 1,
                    TariffName = "Standart Gündüz Tarifesi",
                    BasePrice = 40.00m,   
                    HourlyPrice = 15.00m   
                }
            );
            
            modelBuilder.Entity<ParkingSlot>().HasData(
                new ParkingSlot { Id = 1, SlotNumber = "A-1", Floor = "Kat 1", Capacity = 3, OccupiedCount = 0 },
                new ParkingSlot { Id = 2, SlotNumber = "A-2", Floor = "Kat 1", Capacity = 2, OccupiedCount = 0 },
                new ParkingSlot { Id = 3, SlotNumber = "B-1", Floor = "Kat 2", Capacity = 1, OccupiedCount = 0 },
                new ParkingSlot { Id = 4, SlotNumber = "B-2", Floor = "Kat 2", Capacity = 1, OccupiedCount = 0 }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
