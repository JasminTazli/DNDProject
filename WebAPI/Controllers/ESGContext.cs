using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

public class ESGContext : DbContext
{
    public ESGContext(DbContextOptions<ESGContext> options) : base(options) { }

    public DbSet<Edata> EModels { get; set; }

    public DbSet<GreenHouse> GHModels { get; set; }

    public DbSet<Waste> WModels { get; set; }

    public DbSet<Water> WaModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Edata>().HasKey(e => e.Environmentid);

        modelBuilder.Entity<Edata>().HasData(
            new Edata
            {
                Environmentid = 1,
                Unit = "MWh",
                CrudeFuel = 52912,
                FossilEnergy = 85667,
                RenewEnergy = 5703,
                GasFuel = 22516,
                TotalEnergy = 91370,
                PurchElec = 5268,
                Year = new DateTime(2024, 1, 1)
            });

        modelBuilder.Entity<GreenHouse>().HasKey(e => e.GreenHouseId);
        modelBuilder.Entity<GreenHouse>().HasData(
            new GreenHouse
            {
                GreenHouseId = 1,
                Unit = "tons CO2 eq",
                scope12Market = 19013,
                scope12location = 20769,
                scope3soldproducts = 1612627,
                Year = new DateTime(2024, 1, 1)
            });

        modelBuilder.Entity<Waste>().HasKey(e => e.WasteId);
        modelBuilder.Entity<Waste>().HasData(
            new Waste
            {
                WasteId = 1,
                Unit = "tons",
                TotalWaste = 1549,
                Year = new DateTime(2024, 1, 1)
            });

        modelBuilder.Entity<Water>().HasKey(e => e.WaterId);
        modelBuilder.Entity<Water>().HasData(
            new Water
            {
                WaterId = 1,
                Unit = "m³",
                WaterConsumption = 18409,
                WaterRecycled = 8955,
                Year = new DateTime(2024, 1, 1)
            });
    modelBuilder.Entity<Edata>().HasKey(e => e.Environmentid);

        modelBuilder.Entity<Edata>().HasData(
            new Edata
            {
                Environmentid = 2,
                Unit = "MWh",
                CrudeFuel = 49992,
                FossilEnergy = 86986,
                RenewEnergy = 4123,
                GasFuel = 24177,
                TotalEnergy = 91109,
                PurchElec = 3567,
                Year = new DateTime(2023, 1, 1)
            });
            modelBuilder.Entity<GreenHouse>().HasKey(e => e.GreenHouseId);
        modelBuilder.Entity<GreenHouse>().HasData(
            new GreenHouse
            {
                GreenHouseId = 2,
                Unit = "tons CO2 eq",
                scope12Market = 20143,
                scope12location = 20783,
                scope3soldproducts = 1929831,
                Year = new DateTime(2023, 1, 1)
            });

        modelBuilder.Entity<Waste>().HasKey(e => e.WasteId);
        modelBuilder.Entity<Waste>().HasData(
            new Waste
            {
                WasteId = 2,
                Unit = "tons",
                TotalWaste = 1559,
                Year = new DateTime(2023, 1, 1)
            });

        modelBuilder.Entity<Water>().HasKey(e => e.WaterId);
        modelBuilder.Entity<Water>().HasData(
            new Water
            {
                WaterId = 2,
                Unit = "m³",
                WaterConsumption = 79773,
                WaterRecycled = 12926,
                Year = new DateTime(2023, 1, 1)
            });
    }
}
