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
                values: new object[] { new Guid("b593d039-cf72-4af7-b8f2-93cc7ebaf941"), 1, true, 62, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("f4943c4c-eb13-4976-88ac-b901a112f150"), 2, true, 44, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("6b38543b-e12c-4614-85cc-9aeda390d494"), 3, true, 47, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("a9f6e87f-43d9-4899-a016-8d04e0774ebf"), 4, true, 24, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("dab968eb-65f5-4564-bf79-d00603a1ff08"), 5, true, 26, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("d136b3a5-1d24-4626-8f21-0563d541c304"), 6, true, 67, 1 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "ExportRadiostationsAll", "ExportRadiostationsCustomOnly", "ExportRadiostationsFavoritesOnly", "ExportRadiostationsFormat", "ExportRadiostationsOnlyFavoritesOrCustom", "ExportRadiostationsPath", "ExportRadiostationsSaveFavoritesTags", "ExportRadiostationsSaveSoundSettings", "HotkeysIsEnabled", "IsNightMode", "Localization", "MainWindowHeight", "MainWindowLeft", "MainWindowTop", "MainWindowWidth", "SearchEngine", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "StartMinimized" },
                values: new object[] { new Guid("be1e91d8-c72b-42a6-a891-e45fd3e937d9"), true, false, false, 0, false, null, true, true, false, false, 0, 0.0, 0.0, 0.0, 0.0, 0, false, false, false });
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
