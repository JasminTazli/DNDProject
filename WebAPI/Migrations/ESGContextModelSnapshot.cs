﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(ESGContext))]
    partial class ESGContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("GreenHouse", b =>
                {
                    b.Property<int>("GreenHouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Year")
                        .HasColumnType("TEXT");

                    b.Property<double>("scope12Market")
                        .HasColumnType("REAL");

                    b.Property<double>("scope12location")
                        .HasColumnType("REAL");

                    b.Property<double>("scope3soldproducts")
                        .HasColumnType("REAL");

                    b.HasKey("GreenHouseId");

                    b.ToTable("GHModels");

                    b.HasData(
                        new
                        {
                            GreenHouseId = 1,
                            Unit = "tons CO2 eq",
                            Year = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            scope12Market = 19013.0,
                            scope12location = 20769.0,
                            scope3soldproducts = 1612627.0
                        },
                        new
                        {
                            GreenHouseId = 2,
                            Unit = "tons CO2 eq",
                            Year = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            scope12Market = 20143.0,
                            scope12location = 20783.0,
                            scope3soldproducts = 1929831.0
                        });
                });

            modelBuilder.Entity("Waste", b =>
                {
                    b.Property<int>("WasteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalWaste")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Year")
                        .HasColumnType("TEXT");

                    b.HasKey("WasteId");

                    b.ToTable("WModels");

                    b.HasData(
                        new
                        {
                            WasteId = 1,
                            TotalWaste = 1549.0,
                            Unit = "tons",
                            Year = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            WasteId = 2,
                            TotalWaste = 1559.0,
                            Unit = "tons",
                            Year = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Water", b =>
                {
                    b.Property<int>("WaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.Property<double>("WaterConsumption")
                        .HasColumnType("REAL");

                    b.Property<double>("WaterRecycled")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Year")
                        .HasColumnType("TEXT");

                    b.HasKey("WaterId");

                    b.ToTable("WaModels");

                    b.HasData(
                        new
                        {
                            WaterId = 1,
                            Unit = "m³",
                            WaterConsumption = 18409.0,
                            WaterRecycled = 8955.0,
                            Year = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            WaterId = 2,
                            Unit = "m³",
                            WaterConsumption = 79773.0,
                            WaterRecycled = 12926.0,
                            Year = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Edata", b =>
                {
                    b.Property<int>("Environmentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CrudeFuel")
                        .HasColumnType("REAL");

                    b.Property<double>("FossilEnergy")
                        .HasColumnType("REAL");

                    b.Property<double>("GasFuel")
                        .HasColumnType("REAL");

                    b.Property<double>("PurchElec")
                        .HasColumnType("REAL");

                    b.Property<double>("RenewEnergy")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalEnergy")
                        .HasColumnType("REAL");

                    b.Property<string>("Unit")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Year")
                        .HasColumnType("TEXT");

                    b.HasKey("Environmentid");

                    b.ToTable("EModels");

                    b.HasData(
                        new
                        {
                            Environmentid = 1,
                            CrudeFuel = 52912.0,
                            FossilEnergy = 85667.0,
                            GasFuel = 22516.0,
                            PurchElec = 5268.0,
                            RenewEnergy = 5703.0,
                            TotalEnergy = 91370.0,
                            Unit = "MWh",
                            Year = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Environmentid = 2,
                            CrudeFuel = 49992.0,
                            FossilEnergy = 86986.0,
                            GasFuel = 24177.0,
                            PurchElec = 3567.0,
                            RenewEnergy = 4123.0,
                            TotalEnergy = 91109.0,
                            Unit = "MWh",
                            Year = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
