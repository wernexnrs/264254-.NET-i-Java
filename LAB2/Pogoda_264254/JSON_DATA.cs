using System;
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
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\Admin\\Desktop\\.NET i Java\\LAB2\\Pogoda_264254\\WeatherDataBase.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //key
            modelBuilder.Entity<WeatherData>()
                .HasKey(w => w.PrimaryKey);

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
        public int PrimaryKey { get; set; }
        public int id { get; set; }
        public main main { get; set; }
        public List <weather> weather { get; set; }
        public wind wind { get; set; }
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

        public override string ToString()
        {
            var weatherConditions = weather != null && weather.Any()
                                    ? string.Join(", ", weather.Select(w => $"{w.main} ({w.description})"))
                                    : "No weather data";

            double tempInCelsius = main.temp - 273.15;
            double feelsLikeInCelsius = main.feels_like - 273.15;

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTimeOffset.FromUnixTimeSeconds(dt).UtcDateTime, timeZone);


            return $"Weather Data for {name} at {localTime.ToString()}: {Environment.NewLine}" +
                   $"- Temperature: {tempInCelsius:F1}°C (Feels like {feelsLikeInCelsius:F1}°C){Environment.NewLine}" +
                   $"- Conditions: {weatherConditions}{Environment.NewLine}" +
                   $"- Wind: {wind.speed} m/s at {wind.deg} degrees{Environment.NewLine}" +
                   $"- Humidity: {main.humidity}%{Environment.NewLine}" +
                   $"- Pressure: {main.pressure} hPa{Environment.NewLine}" +
                   $"- Visibility: {visibility} meters{Environment.NewLine}" +
                   $"- Cloudiness: {clouds.all}%{Environment.NewLine}" +
                   $"- Sunrise: {DateTimeOffset.FromUnixTimeSeconds(sys.sunrise).ToLocalTime():HH:mm:ss}{Environment.NewLine}" +
                   $"- Sunset: {DateTimeOffset.FromUnixTimeSeconds(sys.sunset).ToLocalTime():HH:mm:ss}{Environment.NewLine}";
        }


    }

    public partial class main
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrimaryKey { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }


    }

    public partial class wind
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrimaryKey { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public partial class coord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrimaryKey { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        [JsonPropertyName("lon")]

        public float lon { get; set; }
        [JsonPropertyName("lat")]

        public float lat { get; set; }
    }

    public partial class weather
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrimaryKey { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public partial class clouds
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrimaryKey { get; set; }
        [ForeignKey("WeatherDataId")]
        public int? WeatherDataId { get; set; }
        public int all { get; set; }
    }
    public partial class sys {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrimaryKey { get; set; }
        public int id { get; set; }
        [ForeignKey("WeatherDataId")]
        public int WeatherDataId { get; set; }
        public int type { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public string country { get; set; }
    }
}