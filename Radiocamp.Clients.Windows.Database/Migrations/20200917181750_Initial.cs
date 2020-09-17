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
                    HotkeysIsEnabled = table.Column<bool>(nullable: false),
                    StartMinimized = table.Column<bool>(nullable: false),
                    ShowFavoritesAtStart = table.Column<bool>(nullable: false),
                    ShowOnlyCustomAtStart = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("19aecc23-3a83-4b0e-bf21-4a4b6c8e314d"), 1, true, 62, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("f3f3d001-3897-40e2-a4c5-fff8cc9506f0"), 2, true, 44, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("8ddf96c5-4991-439b-af9b-2c69e51736da"), 3, true, 47, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("05962220-c9d2-4a11-b671-0b2f584a0cbf"), 4, true, 24, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("49c90cf5-aac9-44c3-96ec-ed2ef276b4d8"), 5, true, 26, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("35e1d74f-1844-4b6a-9f1b-3af64502d0c3"), 6, true, 67, 1 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "HotkeysIsEnabled", "MainWindowHeight", "MainWindowLeft", "MainWindowTop", "MainWindowWidth", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "StartMinimized" },
                values: new object[] { new Guid("bf4e6232-6000-4781-9978-3fd9cf1344b9"), false, 0.0, 0.0, 0.0, 0.0, false, false, false });
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
