﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pogoda_264254.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    Base = table.Column<string>(type: "TEXT", nullable: false),
                    visibility = table.Column<int>(type: "INTEGER", nullable: false),
                    timezone = table.Column<int>(type: "INTEGER", nullable: false),
                    cod = table.Column<int>(type: "INTEGER", nullable: false),
                    dt = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "clouds",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeatherDataId = table.Column<int>(type: "INTEGER", nullable: true),
                    all = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clouds", x => x.PrimaryKey);
                    table.ForeignKey(
                        name: "FK_clouds_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "PrimaryKey");
                });

            migrationBuilder.CreateTable(
                name: "coord",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeatherDataId = table.Column<int>(type: "INTEGER", nullable: true),
                    lon = table.Column<float>(type: "REAL", nullable: false),
                    lat = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coord", x => x.PrimaryKey);
                    table.ForeignKey(
                        name: "FK_coord_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "PrimaryKey");
                });

            migrationBuilder.CreateTable(
                name: "main",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeatherDataId = table.Column<int>(type: "INTEGER", nullable: true),
                    temp = table.Column<double>(type: "REAL", nullable: false),
                    feels_like = table.Column<double>(type: "REAL", nullable: false),
                    temp_min = table.Column<double>(type: "REAL", nullable: false),
                    temp_max = table.Column<double>(type: "REAL", nullable: false),
                    pressure = table.Column<int>(type: "INTEGER", nullable: false),
                    humidity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_main", x => x.PrimaryKey);
                    table.ForeignKey(
                        name: "FK_main_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "PrimaryKey");
                });

            migrationBuilder.CreateTable(
                name: "sys",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    WeatherDataId = table.Column<int>(type: "INTEGER", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    sunrise = table.Column<int>(type: "INTEGER", nullable: false),
                    sunset = table.Column<int>(type: "INTEGER", nullable: false),
                    country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sys", x => x.PrimaryKey);
                    table.ForeignKey(
                        name: "FK_sys_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "PrimaryKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weather",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeatherDataId = table.Column<int>(type: "INTEGER", nullable: true),
                    main = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    icon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weather", x => x.PrimaryKey);
                    table.ForeignKey(
                        name: "FK_weather_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "PrimaryKey");
                });

            migrationBuilder.CreateTable(
                name: "wind",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeatherDataId = table.Column<int>(type: "INTEGER", nullable: true),
                    speed = table.Column<double>(type: "REAL", nullable: false),
                    deg = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wind", x => x.PrimaryKey);
                    table.ForeignKey(
                        name: "FK_wind_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "PrimaryKey");
                });

            migrationBuilder.CreateIndex(
                name: "IX_clouds_WeatherDataId",
                table: "clouds",
                column: "WeatherDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_coord_WeatherDataId",
                table: "coord",
                column: "WeatherDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_main_WeatherDataId",
                table: "main",
                column: "WeatherDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sys_WeatherDataId",
                table: "sys",
                column: "WeatherDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_weather_WeatherDataId",
                table: "weather",
                column: "WeatherDataId");

            migrationBuilder.CreateIndex(
                name: "IX_wind_WeatherDataId",
                table: "wind",
                column: "WeatherDataId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clouds");

            migrationBuilder.DropTable(
                name: "coord");

            migrationBuilder.DropTable(
                name: "main");

            migrationBuilder.DropTable(
                name: "sys");

            migrationBuilder.DropTable(
                name: "weather");

            migrationBuilder.DropTable(
                name: "wind");

            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}
