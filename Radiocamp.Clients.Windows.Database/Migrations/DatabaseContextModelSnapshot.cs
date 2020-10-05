﻿// <auto-generated />
using System;
using Dartware.Radiocamp.Clients.Windows.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dartware.Radiocamp.Clients.Windows.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("Dartware.Radiocamp.Clients.Windows.Hotkeys.Hotkey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Command")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModifierKey")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Hotkeys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ed9d805-f792-4ba4-9045-28bce3eef7ba"),
                            Command = 1,
                            IsEnabled = false,
                            Key = 0,
                            ModifierKey = 0
                        },
                        new
                        {
                            Id = new Guid("447ea216-fb30-4321-a999-4e62893bf913"),
                            Command = 2,
                            IsEnabled = false,
                            Key = 0,
                            ModifierKey = 0
                        },
                        new
                        {
                            Id = new Guid("56143d36-21c1-4243-a824-335051f16a62"),
                            Command = 3,
                            IsEnabled = false,
                            Key = 0,
                            ModifierKey = 0
                        },
                        new
                        {
                            Id = new Guid("246632bd-7d4b-4561-a3a6-ebf9c371fde2"),
                            Command = 4,
                            IsEnabled = false,
                            Key = 0,
                            ModifierKey = 0
                        },
                        new
                        {
                            Id = new Guid("eb718113-e5b0-468d-855b-f5df95ca10c7"),
                            Command = 5,
                            IsEnabled = false,
                            Key = 0,
                            ModifierKey = 0
                        },
                        new
                        {
                            Id = new Guid("9ac07f03-971b-48ae-affa-a90a0db99351"),
                            Command = 6,
                            IsEnabled = false,
                            Key = 0,
                            ModifierKey = 0
                        });
                });

            modelBuilder.Entity("Dartware.Radiocamp.Clients.Windows.Settings.Settings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("AlwaysShowTrayIcon")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExportRadiostationsAll")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExportRadiostationsCustomOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExportRadiostationsFavoritesOnly")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExportRadiostationsFormat")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExportRadiostationsOnlyFavoritesOrCustom")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExportRadiostationsPath")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ExportRadiostationsSaveFavoritesTags")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExportRadiostationsSaveSoundSettings")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HideApplicationOnCloseButtonClick")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HideApplicationOnMinimizeButtonClick")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HotkeysIsEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsNightMode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Localization")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MainWindowHeight")
                        .HasColumnType("REAL");

                    b.Property<double>("MainWindowLeft")
                        .HasColumnType("REAL");

                    b.Property<double>("MainWindowTop")
                        .HasColumnType("REAL");

                    b.Property<double>("MainWindowWidth")
                        .HasColumnType("REAL");

                    b.Property<int>("SearchEngine")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowFavoritesAtStart")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowOnlyCustomAtStart")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("StartMinimized")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VolumeStep")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33c88bf9-4e46-4038-b2df-07b76f20a857"),
                            AlwaysShowTrayIcon = true,
                            ExportRadiostationsAll = true,
                            ExportRadiostationsCustomOnly = false,
                            ExportRadiostationsFavoritesOnly = false,
                            ExportRadiostationsFormat = 0,
                            ExportRadiostationsOnlyFavoritesOrCustom = false,
                            ExportRadiostationsSaveFavoritesTags = true,
                            ExportRadiostationsSaveSoundSettings = true,
                            HideApplicationOnCloseButtonClick = true,
                            HideApplicationOnMinimizeButtonClick = false,
                            HotkeysIsEnabled = false,
                            IsNightMode = false,
                            Localization = 0,
                            MainWindowHeight = 0.0,
                            MainWindowLeft = 0.0,
                            MainWindowTop = 0.0,
                            MainWindowWidth = 0.0,
                            SearchEngine = 0,
                            ShowFavoritesAtStart = false,
                            ShowOnlyCustomAtStart = false,
                            StartMinimized = false,
                            VolumeStep = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
