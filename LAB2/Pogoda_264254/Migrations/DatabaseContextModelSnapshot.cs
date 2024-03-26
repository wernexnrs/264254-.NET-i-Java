﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pogoda_264254;

#nullable disable

namespace Pogoda_264254.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Pogoda_264254.WeatherData", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Base")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "base");

                    b.Property<int>("cod")
                        .HasColumnType("INTEGER");

                    b.Property<int>("dt")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("timezone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("visibility")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("WeatherData");
                });

            modelBuilder.Entity("Pogoda_264254.clouds", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeatherDataId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("all")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDataId")
                        .IsUnique();

                    b.ToTable("clouds");
                });

            modelBuilder.Entity("Pogoda_264254.coord", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeatherDataId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("lat")
                        .HasColumnType("REAL");

                    b.Property<double>("lon")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDataId")
                        .IsUnique();

                    b.ToTable("coord");
                });

            modelBuilder.Entity("Pogoda_264254.main", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeatherDataId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("feels_like")
                        .HasColumnType("REAL");

                    b.Property<int>("humidity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pressure")
                        .HasColumnType("INTEGER");

                    b.Property<double>("temp")
                        .HasColumnType("REAL");

                    b.Property<double>("temp_max")
                        .HasColumnType("REAL");

                    b.Property<double>("temp_min")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDataId")
                        .IsUnique();

                    b.ToTable("main");
                });

            modelBuilder.Entity("Pogoda_264254.sys", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeatherDataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("sunrise")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sunset")
                        .HasColumnType("INTEGER");

                    b.Property<int>("type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDataId")
                        .IsUnique();

                    b.ToTable("sys");
                });

            modelBuilder.Entity("Pogoda_264254.weather", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeatherDataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("main")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDataId");

                    b.ToTable("weather");
                });

            modelBuilder.Entity("Pogoda_264254.wind", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeatherDataId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("deg")
                        .HasColumnType("REAL");

                    b.Property<double>("speed")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("WeatherDataId")
                        .IsUnique();

                    b.ToTable("wind");
                });

            modelBuilder.Entity("Pogoda_264254.clouds", b =>
                {
                    b.HasOne("Pogoda_264254.WeatherData", null)
                        .WithOne("clouds")
                        .HasForeignKey("Pogoda_264254.clouds", "WeatherDataId");
                });

            modelBuilder.Entity("Pogoda_264254.coord", b =>
                {
                    b.HasOne("Pogoda_264254.WeatherData", null)
                        .WithOne("coord")
                        .HasForeignKey("Pogoda_264254.coord", "WeatherDataId");
                });

            modelBuilder.Entity("Pogoda_264254.main", b =>
                {
                    b.HasOne("Pogoda_264254.WeatherData", null)
                        .WithOne("main")
                        .HasForeignKey("Pogoda_264254.main", "WeatherDataId");
                });

            modelBuilder.Entity("Pogoda_264254.sys", b =>
                {
                    b.HasOne("Pogoda_264254.WeatherData", null)
                        .WithOne("sys")
                        .HasForeignKey("Pogoda_264254.sys", "WeatherDataId");
                });

            modelBuilder.Entity("Pogoda_264254.weather", b =>
                {
                    b.HasOne("Pogoda_264254.WeatherData", null)
                        .WithMany("weather")
                        .HasForeignKey("WeatherDataId");
                });

            modelBuilder.Entity("Pogoda_264254.wind", b =>
                {
                    b.HasOne("Pogoda_264254.WeatherData", null)
                        .WithOne("wind")
                        .HasForeignKey("Pogoda_264254.wind", "WeatherDataId");
                });

            modelBuilder.Entity("Pogoda_264254.WeatherData", b =>
                {
                    b.Navigation("clouds")
                        .IsRequired();

                    b.Navigation("coord")
                        .IsRequired();

                    b.Navigation("main")
                        .IsRequired();

                    b.Navigation("sys")
                        .IsRequired();

                    b.Navigation("weather");

                    b.Navigation("wind")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
