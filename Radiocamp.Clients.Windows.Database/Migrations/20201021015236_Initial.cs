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
                name: "Radiostations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    StreamURL = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "datetime('now')"),
                    IsFavorite = table.Column<bool>(nullable: false),
                    IsCustom = table.Column<bool>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    Country = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radiostations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MainWindowWidth = table.Column<double>(nullable: false),
                    MainWindowHeight = table.Column<double>(nullable: false),
                    MainWindowLeft = table.Column<double>(nullable: false),
                    MainWindowTop = table.Column<double>(nullable: false),
                    MainWindowCompactAdvancedHeight = table.Column<double>(nullable: false),
                    MainWindowMode = table.Column<int>(nullable: false),
                    MainWindowAdvancedCompactPosition = table.Column<int>(nullable: false),
                    StartMinimized = table.Column<bool>(nullable: false),
                    ShowFavoritesAtStart = table.Column<bool>(nullable: false),
                    ShowOnlyCustomAtStart = table.Column<bool>(nullable: false),
                    SearchEngine = table.Column<int>(nullable: false),
                    ExportRadiostationsAll = table.Column<bool>(nullable: false),
                    ExportRadiostationsOnlyFavoritesOrCustom = table.Column<bool>(nullable: false),
                    ExportRadiostationsFavoritesOnly = table.Column<bool>(nullable: false),
                    ExportRadiostationsCustomOnly = table.Column<bool>(nullable: false),
                    ExportRadiostationsSaveSoundSettings = table.Column<bool>(nullable: false),
                    ExportRadiostationsSaveFavoritesTags = table.Column<bool>(nullable: false),
                    ExportRadiostationsFormat = table.Column<int>(nullable: false),
                    ExportRadiostationsPath = table.Column<string>(nullable: true),
                    AlwaysShowTrayIcon = table.Column<bool>(nullable: false),
                    HideApplicationOnCloseButtonClick = table.Column<bool>(nullable: false),
                    HideApplicationOnMinimizeButtonClick = table.Column<bool>(nullable: false),
                    Localization = table.Column<int>(nullable: false),
                    IsNightMode = table.Column<bool>(nullable: false),
                    MainWindowTopmost = table.Column<bool>(nullable: false),
                    MainWindowTopmostOnlyCompact = table.Column<bool>(nullable: false),
                    HideInTaskbar = table.Column<bool>(nullable: false),
                    HideInTaskbarOnlyCompact = table.Column<bool>(nullable: false),
                    VolumeStep = table.Column<int>(nullable: false),
                    HotkeysIsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("e8d20d28-5149-47dc-94b9-f01e950193c4"), 1, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("1089ebfd-da22-4eb9-90e0-b33649e80b94"), 2, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("aae24729-b45d-4b11-820e-d1f3166f39b6"), 3, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("bec46260-ab7d-4c72-9d6c-0d16478fd7bd"), 4, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("a2dd329b-0746-44df-9471-12a5defda4ea"), 5, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("e49b507f-b99c-41b2-9ee9-07c09276b237"), 6, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "AlwaysShowTrayIcon", "ExportRadiostationsAll", "ExportRadiostationsCustomOnly", "ExportRadiostationsFavoritesOnly", "ExportRadiostationsFormat", "ExportRadiostationsOnlyFavoritesOrCustom", "ExportRadiostationsPath", "ExportRadiostationsSaveFavoritesTags", "ExportRadiostationsSaveSoundSettings", "HideApplicationOnCloseButtonClick", "HideApplicationOnMinimizeButtonClick", "HideInTaskbar", "HideInTaskbarOnlyCompact", "HotkeysIsEnabled", "IsNightMode", "Localization", "MainWindowAdvancedCompactPosition", "MainWindowCompactAdvancedHeight", "MainWindowHeight", "MainWindowLeft", "MainWindowMode", "MainWindowTop", "MainWindowTopmost", "MainWindowTopmostOnlyCompact", "MainWindowWidth", "SearchEngine", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "StartMinimized", "VolumeStep" },
                values: new object[] { new Guid("300a50e2-9829-44aa-aca5-3570e6261b57"), true, true, false, false, 0, false, null, true, true, true, false, false, false, false, false, 0, 0, 400.0, 0.0, 0.0, 0, 0.0, false, false, 0.0, 0, false, false, false, 4 });
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
