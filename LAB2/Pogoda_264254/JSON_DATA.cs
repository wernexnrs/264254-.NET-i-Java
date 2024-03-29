﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Pogoda_264254
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<WeatherData> WeatherData { get; set; }
        public DbSet<main> main { get; set; }
        public DbSet<wind> wind { get; set; }
        public DbSet<sys> sys { get; set; }
        public DbSet<clouds> clouds { get; set; }
        public DbSet<coord> coord { get; set; }
        public DbSet<weather> weather { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database2.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // key
            modelBuilder.Entity<WeatherData>()
                .HasKey(w => w.unique_id);
 

            //1-1
            modelBuilder.Entity<WeatherData>()
                .HasOne<main>(w => w.main)
                .WithOne()
                .HasForeignKey<main>(m => m.WeatherDataId);


            //1-1
            modelBuilder.Entity<WeatherData>()
                .HasOne<wind>(w => w.wind)
                .WithOne()
                .HasForeignKey<wind>(w => w.WeatherDataId);

            modelBuilder.Entity<WeatherData>()
               .HasOne<sys>(w => w.sys)
               .WithOne()
               .HasForeignKey<sys>(w => w.WeatherDataId);

            modelBuilder.Entity<WeatherData>()
               .HasOne<coord>(w => w.coord)
               .WithOne()
               .HasForeignKey<coord>(w => w.WeatherDataId);

            modelBuilder.Entity<WeatherData>()
               .HasOne<clouds>(w => w.clouds)
               .WithOne()
               .HasForeignKey<clouds>(w => w.WeatherDataId);



            base.OnModelCreating(modelBuilder);
        }
    }
    public class WeatherData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int unique_id { get; set; }

        [JsonPropertyName("id")]
        public int id { get; set; }
        public main main { get; set; }
        public List <weather> weather { get; set; }
        public wind wind { get; set; }
        [JsonPropertyName("coord")]

        public coord coord { get; set; }
        public sys sys { get; set; }
        public clouds clouds { get; set; }
        public string name { get; set; }
        [JsonPropertyName("base")]
        public string Base { get; set; }
        public int visibility { get; set; }
        public int timezone { get; set; }
        public int cod { get; set; }
        public int dt { get; set; }
    }

    public class main
    {
        
        public int? Id { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class wind
    {
        public int? Id { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class coord
    {
        public int? Id { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        [JsonPropertyName("lon")]

        public float lon { get; set; }
        [JsonPropertyName("lat")]

        public float lat { get; set; }
    }

    public class weather
    {
        public int? Id { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class clouds
    {
        public int? Id { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        public int all { get; set; }
    }
    public class sys
    {
        public int? Id { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        public int type { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public string country { get; set; }
    }
}