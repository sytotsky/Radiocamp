using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dartware.Radiocamp.Clients.Windows.Database.Migrations
{
    public partial class AddSortingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("119aee2b-4bd6-4c23-8cf0-bd4f05b4c909"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("61936faa-7b81-4b6f-a480-59ae92dfa5c0"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("8798db76-1377-4334-ade9-f5d63fd0311d"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("a80438a1-a2ea-4118-abe1-25b2b700fbd1"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("aaa6ba5e-2513-4ab3-8936-9646d8dc4cb6"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("d08d65ba-e65f-44ac-9915-0faa6054d8e7"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("e0fbe53f-8903-48e4-8a26-b31ca30c8d6d"));

            migrationBuilder.AddColumn<int>(
                name: "SortingType",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("ab664de2-c31d-4542-a1db-066b773cfaf8"), 1, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("c2cd9df7-f9ea-4255-ade9-3d8b74ceb1cb"), 2, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("f20e7c06-7a49-4c39-a049-0a03fb171362"), 3, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("4ee052bf-8c12-46ea-86ae-c1ba7d20c1f5"), 4, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("f1d0853d-5a1f-4324-95dd-29ff60d974b5"), 5, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Hotkeys",
                columns: new[] { "Id", "Command", "IsEnabled", "Key", "ModifierKey" },
                values: new object[] { new Guid("47873c75-5ab8-4221-92e9-529a1869f4a2"), 6, false, 0, 0 });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "AlwaysShowTrayIcon", "ExportRadiostationsAll", "ExportRadiostationsCustomOnly", "ExportRadiostationsFavoritesOnly", "ExportRadiostationsFormat", "ExportRadiostationsOnlyFavoritesOrCustom", "ExportRadiostationsPath", "ExportRadiostationsSaveFavoritesTags", "ExportRadiostationsSaveSoundSettings", "HideApplicationOnCloseButtonClick", "HideApplicationOnMinimizeButtonClick", "HideInTaskbar", "HideInTaskbarOnlyCompact", "HotkeysIsEnabled", "IsNightMode", "Localization", "MainWindowAdvancedCompactPosition", "MainWindowCompactAdvancedHeight", "MainWindowHeight", "MainWindowLeft", "MainWindowMode", "MainWindowTop", "MainWindowTopmost", "MainWindowTopmostOnlyCompact", "MainWindowWidth", "SearchEngine", "ShowFavoritesAtStart", "ShowOnlyCustomAtStart", "ShowOnlyFavorites", "SortingType", "StartMinimized", "Volume", "VolumeStep" },
                values: new object[] { new Guid("479197f1-57b2-465f-a338-ebb420da68ba"), true, true, false, false, 0, false, null, true, true, true, false, false, false, false, false, 0, 0, 400.0, 0.0, 0.0, 0, 0.0, false, false, 0.0, 0, false, false, false, 0, false, 50.0, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("47873c75-5ab8-4221-92e9-529a1869f4a2"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("4ee052bf-8c12-46ea-86ae-c1ba7d20c1f5"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("ab664de2-c31d-4542-a1db-066b773cfaf8"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("c2cd9df7-f9ea-4255-ade9-3d8b74ceb1cb"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("f1d0853d-5a1f-4324-95dd-29ff60d974b5"));

            migrationBuilder.DeleteData(
                table: "Hotkeys",
                keyColumn: "Id",
                keyValue: new Guid("f20e7c06-7a49-4c39-a049-0a03fb171362"));

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("479197f1-57b2-465f-a338-ebb420da68ba"));

            migrationBuilder.DropColumn(
                name: "SortingType",
                table: "Settings");

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
    }
}
