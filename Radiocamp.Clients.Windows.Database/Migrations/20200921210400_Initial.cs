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
                    ShowFavoritesAtStart = table.Column<bool>(nullable: false),
                    ShowOnlyCustomAtStart = table.Column<bool>(nullable: false),
                    SearchEngine = table.Column<int>(nullable: false),
                    MainWindowWidth = table.Column<double>(nullable: false),
                    MainWindowHeight = table.Column<double>(nullable: false),
                    MainWindowLeft = table.Column<double>(nullable: false),
                    MainWindowTop = table.Column<double>(nullable: false),
                    HotkeysIsEnabled = table.Column<bool>(nullable: false),
                    StartMinimized = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("a3474b9a-4df6-44bb-923b-5d9935905224"), 1, true, 62, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("883efdbf-21cb-43e2-959a-a138a294a987"), 2, true, 44, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("9d71dcb9-9ae2-4623-8920-b2707410c01a"), 3, true, 47, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("1a649e7a-0a24-4a34-bc6c-37df71abc40e"), 4, true, 24, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("a3334e91-f816-47ff-8ec0-b82094435268"), 5, true, 26, 1 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("a9291976-9948-4c59-933c-777d53943685"), 6, true, 67, 1 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "HotkeysIsEnabled", "MainWindowHeight", "MainWindowLeft", "MainWindowTop", "MainWindowWidth", "SearchEngine", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "StartMinimized" },
                values: new object[] { new Guid("889ef244-dea0-4c94-863c-9e949b9fbb9d"), false, 0.0, 0.0, 0.0, 0.0, 0, false, false, false });
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
