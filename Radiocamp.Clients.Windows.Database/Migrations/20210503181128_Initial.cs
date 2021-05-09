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
                    IsPinned = table.Column<bool>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    StreamURL = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    IsFavorite = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCustom = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCurrent = table.Column<bool>(type: "INTEGER", nullable: false),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false),
                    ListenTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    LastPlayTime = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    SortingType = table.Column<int>(type: "INTEGER", nullable: false),
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
                    HotkeysIsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    Country = table.Column<int>(type: "INTEGER", nullable: false),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCustomOnly = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("653fc076-c1ca-4de9-b986-e404e0423fc1"), 1, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("c264a967-534e-4be9-9494-211397668453"), 2, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("8feddbf0-d655-499b-8748-63529e242de7"), 3, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("511ef7fc-b4c5-4a22-b13f-46e3ea117bfe"), 4, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("38513515-93c4-49d8-b876-6c4eba0a6c6a"), 5, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("6b825436-b5a1-49e5-9b78-42abe43c05c2"), 6, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "AlwaysShowTrayIcon", "Country", "ExportRadiostationsAll", "ExportRadiostationsCustomOnly", "ExportRadiostationsFavoritesOnly", "ExportRadiostationsFormat", "ExportRadiostationsOnlyFavoritesOrCustom", "ExportRadiostationsPath", "ExportRadiostationsSaveFavoritesTags", "ExportRadiostationsSaveSoundSettings", "Genre", "HideApplicationOnCloseButtonClick", "HideApplicationOnMinimizeButtonClick", "HideInTaskbar", "HideInTaskbarOnlyCompact", "HotkeysIsEnabled", "IsCustomOnly", "IsNightMode", "Localization", "MainWindowAdvancedCompactPosition", "MainWindowCompactAdvancedHeight", "MainWindowHeight", "MainWindowLeft", "MainWindowMode", "MainWindowTop", "MainWindowTopmost", "MainWindowTopmostOnlyCompact", "MainWindowWidth", "SearchEngine", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "ShowOnlyFavorites", "SortingType", "StartMinimized", "Volume", "VolumeStep" },
                values: new object[] { new Guid("e2ab5c7d-ae56-4917-8459-3c5a9b039cc5"), true, 0, true, false, false, 0, false, null, true, true, 0, true, false, false, false, false, false, false, 0, 0, 400.0, 0.0, 0.0, 0, 0.0, false, false, 0.0, 0, false, false, false, 0, false, 50.0, 4 });
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
