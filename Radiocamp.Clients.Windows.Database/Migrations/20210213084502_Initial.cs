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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Command = table.Column<int>(type: "INTEGER", nullable: false),
                    Key = table.Column<int>(type: "INTEGER", nullable: false),
                    ModifierKey = table.Column<int>(type: "INTEGER", nullable: false),
                    IsEnabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotkeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Radiostations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Volume = table.Column<double>(type: "REAL", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    StreamURL = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCustom = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCurrent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radiostations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MainWindowWidth = table.Column<double>(type: "REAL", nullable: false),
                    MainWindowHeight = table.Column<double>(type: "REAL", nullable: false),
                    MainWindowLeft = table.Column<double>(type: "REAL", nullable: false),
                    MainWindowTop = table.Column<double>(type: "REAL", nullable: false),
                    MainWindowCompactAdvancedHeight = table.Column<double>(type: "REAL", nullable: false),
                    MainWindowMode = table.Column<int>(type: "INTEGER", nullable: false),
                    MainWindowAdvancedCompactPosition = table.Column<int>(type: "INTEGER", nullable: false),
                    StartMinimized = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShowFavoritesAtStart = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShowOnlyCustomAtStart = table.Column<bool>(type: "INTEGER", nullable: false),
                    SearchEngine = table.Column<int>(type: "INTEGER", nullable: false),
                    ShowOnlyFavorites = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportRadiostationsAll = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportRadiostationsOnlyFavoritesOrCustom = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportRadiostationsFavoritesOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportRadiostationsCustomOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportRadiostationsSaveSoundSettings = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportRadiostationsSaveFavoritesTags = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExportRadiostationsFormat = table.Column<int>(type: "INTEGER", nullable: false),
                    ExportRadiostationsPath = table.Column<string>(type: "TEXT", nullable: true),
                    AlwaysShowTrayIcon = table.Column<bool>(type: "INTEGER", nullable: false),
                    HideApplicationOnCloseButtonClick = table.Column<bool>(type: "INTEGER", nullable: false),
                    HideApplicationOnMinimizeButtonClick = table.Column<bool>(type: "INTEGER", nullable: false),
                    Localization = table.Column<int>(type: "INTEGER", nullable: false),
                    IsNightMode = table.Column<bool>(type: "INTEGER", nullable: false),
                    MainWindowTopmost = table.Column<bool>(type: "INTEGER", nullable: false),
                    MainWindowTopmostOnlyCompact = table.Column<bool>(type: "INTEGER", nullable: false),
                    HideInTaskbar = table.Column<bool>(type: "INTEGER", nullable: false),
                    HideInTaskbarOnlyCompact = table.Column<bool>(type: "INTEGER", nullable: false),
                    Volume = table.Column<double>(type: "REAL", nullable: false),
                    VolumeStep = table.Column<int>(type: "INTEGER", nullable: false),
                    HotkeysIsEnabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("8798db76-1377-4334-ade9-f5d63fd0311d"), 1, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("d08d65ba-e65f-44ac-9915-0faa6054d8e7"), 2, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("119aee2b-4bd6-4c23-8cf0-bd4f05b4c909"), 3, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("a80438a1-a2ea-4118-abe1-25b2b700fbd1"), 4, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("aaa6ba5e-2513-4ab3-8936-9646d8dc4cb6"), 5, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("61936faa-7b81-4b6f-a480-59ae92dfa5c0"), 6, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "AlwaysShowTrayIcon", "ExportRadiostationsAll", "ExportRadiostationsCustomOnly", "ExportRadiostationsFavoritesOnly", "ExportRadiostationsFormat", "ExportRadiostationsOnlyFavoritesOrCustom", "ExportRadiostationsPath", "ExportRadiostationsSaveFavoritesTags", "ExportRadiostationsSaveSoundSettings", "HideApplicationOnCloseButtonClick", "HideApplicationOnMinimizeButtonClick", "HideInTaskbar", "HideInTaskbarOnlyCompact", "HotkeysIsEnabled", "IsNightMode", "Localization", "MainWindowAdvancedCompactPosition", "MainWindowCompactAdvancedHeight", "MainWindowHeight", "MainWindowLeft", "MainWindowMode", "MainWindowTop", "MainWindowTopmost", "MainWindowTopmostOnlyCompact", "MainWindowWidth", "SearchEngine", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "ShowOnlyFavorites", "StartMinimized", "Volume", "VolumeStep" },
                values: new object[] { new Guid("e0fbe53f-8903-48e4-8a26-b31ca30c8d6d"), true, true, false, false, 0, false, null, true, true, true, false, false, false, false, false, 0, 0, 400.0, 0.0, 0.0, 0, 0.0, false, false, 0.0, 0, false, false, false, false, 50.0, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotkeys");

            migrationBuilder.DropTable(
                name: "Radiostations");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
