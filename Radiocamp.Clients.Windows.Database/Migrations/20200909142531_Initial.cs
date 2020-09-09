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
                    table.UniqueConstraint("AK_Hotkeys_Command", x => x.Command);
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
                    HotkeysIsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("3f554723-f57a-4ab4-9b5c-df9a8aeb7e47"), 1, true, 62, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("df7491c5-cd12-44cb-ab74-689d7b641a09"), 2, true, 44, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("683ce175-86d9-4d46-9f73-1398cfc72374"), 3, true, 47, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("5a1a8148-5ca6-4643-9524-fa531119387c"), 4, true, 24, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("88432ee0-4232-4f70-869f-fda1b94479e8"), 5, true, 26, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("ef9d8acd-cead-4d07-9107-39e9a9aac2e6"), 6, true, 67, 1 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "HotkeysIsEnabled", "MainWindowHeight", "MainWindowLeft", "MainWindowTop", "MainWindowWidth" },
                values: new object[] { new Guid("4802fbc1-1e06-4ef4-afd4-dc82fb22fce6"), false, 0.0, 0.0, 0.0, 0.0 });
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
