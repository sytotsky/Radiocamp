using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dartware.Radiocamp.Clients.Windows.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotkeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Command = table.Column<int>(nullable: false),
                    Key = table.Column<int>(nullable: false),
                    ModifierKey = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotkeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShowFavoritesAtStart = table.Column<bool>(nullable: false),
                    ShowOnlyCustomAtStart = table.Column<bool>(nullable: false),
                    SearchEngine = table.Column<int>(nullable: false),
                    Localization = table.Column<int>(nullable: false),
                    IsNightMode = table.Column<bool>(nullable: false),
                    MainWindowWidth = table.Column<double>(nullable: false),
                    MainWindowHeight = table.Column<double>(nullable: false),
                    MainWindowLeft = table.Column<double>(nullable: false),
                    MainWindowTop = table.Column<double>(nullable: false),
                    HotkeysIsEnabled = table.Column<bool>(nullable: false),
                    StartMinimized = table.Column<bool>(nullable: false),
                    ExportRadiostationsAll = table.Column<bool>(nullable: false),
                    ExportRadiostationsOnlyFavoritesOrCustom = table.Column<bool>(nullable: false),
                    ExportRadiostationsFavoritesOnly = table.Column<bool>(nullable: false),
                    ExportRadiostationsCustomOnly = table.Column<bool>(nullable: false),
                    ExportRadiostationsSaveSoundSettings = table.Column<bool>(nullable: false),
                    ExportRadiostationsSaveFavoritesTags = table.Column<bool>(nullable: false),
                    ExportRadiostationsFormat = table.Column<int>(nullable: false),
                    ExportRadiostationsPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("5be3a5a0-c206-4c4b-9aed-e6d8da2c5410"), 1, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("133a28b8-e471-4d57-abc8-95874fbde9a6"), 2, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("98e86efd-8ce1-4cfe-88ce-83875123da04"), 3, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("cc40fd76-8aa1-48cc-85cb-94defb12ca1b"), 4, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("2751d8c2-9af9-48b8-81bb-73cdf2d6b17f"), 5, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("1f8feb51-354d-49ef-a7f3-8667e6bf65c7"), 6, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "ExportRadiostationsAll", "ExportRadiostationsCustomOnly", "ExportRadiostationsFavoritesOnly", "ExportRadiostationsFormat", "ExportRadiostationsOnlyFavoritesOrCustom", "ExportRadiostationsPath", "ExportRadiostationsSaveFavoritesTags", "ExportRadiostationsSaveSoundSettings", "HotkeysIsEnabled", "IsNightMode", "Localization", "MainWindowHeight", "MainWindowLeft", "MainWindowTop", "MainWindowWidth", "SearchEngine", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "StartMinimized" },
                values: new object[] { new Guid("07def7df-e32b-49e3-9b0f-20df64832810"), true, false, false, 0, false, null, true, true, false, false, 0, 0.0, 0.0, 0.0, 0.0, 0, false, false, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotkeys");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
