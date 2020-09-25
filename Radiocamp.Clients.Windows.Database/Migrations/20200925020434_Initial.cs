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
                    Command = table.Column<int>(nullable: false),
                    Key = table.Column<int>(nullable: false),
                    ModifierKey = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotkeys", x => x.Command);
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
                columns: new[] { "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { 1, true, 62, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { 2, true, 44, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { 3, true, 47, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { 4, true, 24, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { 5, true, 26, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { 6, true, 67, 1 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "ExportRadiostationsAll", "ExportRadiostationsCustomOnly", "ExportRadiostationsFavoritesOnly", "ExportRadiostationsFormat", "ExportRadiostationsOnlyFavoritesOrCustom", "ExportRadiostationsPath", "ExportRadiostationsSaveFavoritesTags", "ExportRadiostationsSaveSoundSettings", "HotkeysIsEnabled", "IsNightMode", "Localization", "MainWindowHeight", "MainWindowLeft", "MainWindowTop", "MainWindowWidth", "SearchEngine", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "StartMinimized" },
                values: new object[] { new Guid("b68eeacc-d3f1-4dda-a0d9-dabca36598be"), true, false, false, 0, false, null, true, true, false, false, 0, 0.0, 0.0, 0.0, 0.0, 0, false, false, false });
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
