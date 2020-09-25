using System;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Desktop.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

		private Boolean exportRadiostationsAll;
		private Boolean exportRadiostationsOnlyFavoritesOrCustom;
		private Boolean exportRadiostationsFavoritesOnly;
		private Boolean exportRadiostationsCustomOnly;
		private Boolean exportRadiostationsSaveSoundSettings;
		private Boolean exportRadiostationsSaveFavoritesTags;
		private ExportFormat exportRadiostationsFormat;
		private String exportRadiostationsPath;

		public String ExportRadiostationsFileFormat => ExportRadiostationsFormat switch
		{
			ExportFormat.Binary => "radcampback",
			ExportFormat.JSON => "json",
			_ => "radcampback"
		};

		[Field(nameof(exportRadiostationsAll))]
		public Boolean ExportRadiostationsAll
		{
			get => exportRadiostationsAll;
			set => SetValue(value);
		}

		[Field(nameof(exportRadiostationsOnlyFavoritesOrCustom))]
		public Boolean ExportRadiostationsOnlyFavoritesOrCustom
		{
			get => exportRadiostationsOnlyFavoritesOrCustom;
			set => SetValue(value);
		}

		[Field(nameof(exportRadiostationsFavoritesOnly))]
		public Boolean ExportRadiostationsFavoritesOnly
		{
			get => exportRadiostationsFavoritesOnly;
			set => SetValue(value);
		}

		[Field(nameof(exportRadiostationsCustomOnly))]
		public Boolean ExportRadiostationsCustomOnly
		{
			get => exportRadiostationsCustomOnly;
			set => SetValue(value);
		}

		[Field(nameof(exportRadiostationsSaveSoundSettings))]
		public Boolean ExportRadiostationsSaveSoundSettings
		{
			get => exportRadiostationsSaveSoundSettings;
			set => SetValue(value);
		}

		[Field(nameof(exportRadiostationsSaveFavoritesTags))]
		public Boolean ExportRadiostationsSaveFavoritesTags
		{
			get => exportRadiostationsSaveFavoritesTags;
			set => SetValue(value);
		}

		[Field(nameof(exportRadiostationsFormat))]
		public ExportFormat ExportRadiostationsFormat
		{
			get => exportRadiostationsFormat;
			set => SetValue(value);
		}

		[Field(nameof(exportRadiostationsPath))]
		public String ExportRadiostationsPath
		{
			get => exportRadiostationsPath;
			set => SetValue(value);
		}

	}
}