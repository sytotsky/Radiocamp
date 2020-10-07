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
                    MainWindowWidth = table.Column<double>(nullable: false),
                    MainWindowHeight = table.Column<double>(nullable: false),
                    MainWindowLeft = table.Column<double>(nullable: false),
                    MainWindowTop = table.Column<double>(nullable: false),
                    MainWindowCompactAdvancedHeight = table.Column<double>(nullable: false),
                    MainWindowMode = table.Column<int>(nullable: false),
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
                values: new object[] { new Guid("9dd2d805-05fd-4ef2-82d3-84c2cca25b87"), 1, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("8b3cfb20-2e4c-4876-8cc1-eb2e62ceaa63"), 2, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("58630aab-5c6a-44d1-b7f7-50ba66bdb6a9"), 3, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("0f58f832-3e97-4b99-9788-38573274ed16"), 4, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("4fa187f2-2dad-49ca-9ba4-792313ca573d"), 5, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("3d908afa-3c03-4744-8b9b-264ba0fd3e1d"), 6, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "AlwaysShowTrayIcon", "ExportRadiostationsAll", "ExportRadiostationsCustomOnly", "ExportRadiostationsFavoritesOnly", "ExportRadiostationsFormat", "ExportRadiostationsOnlyFavoritesOrCustom", "ExportRadiostationsPath", "ExportRadiostationsSaveFavoritesTags", "ExportRadiostationsSaveSoundSettings", "HideApplicationOnCloseButtonClick", "HideApplicationOnMinimizeButtonClick", "HotkeysIsEnabled", "IsNightMode", "Localization", "MainWindowCompactAdvancedHeight", "MainWindowHeight", "MainWindowLeft", "MainWindowMode", "MainWindowTop", "MainWindowWidth", "SearchEngine", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "StartMinimized", "VolumeStep" },
                values: new object[] { new Guid("6344adc9-7e7e-4474-be03-80dbeea1fbe6"), true, true, false, false, 0, false, null, true, true, true, false, false, false, 0, 0.0, 0.0, 0.0, 0, 0.0, 0.0, 0, false, false, false, 4 });
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
