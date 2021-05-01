using System;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

		private Boolean showOnlyFavorites;
		private SortingType sortingType;
		private Country country;
		private Genre genre;
		private Boolean isCustomOnly;

		[Field(nameof(showOnlyFavorites))]
		public Boolean ShowOnlyFavorites
		{
			get => showOnlyFavorites;
			set => SetValue(value);
		}

		[Field(nameof(sortingType))]
		public SortingType SortingType
		{
			get => sortingType;
			set => SetValue(value);
		}

		[Field(nameof(country))]
		public Country Country
		{
			get => country;
			set => SetValue(value);
		}

		[Field(nameof(genre))]
		public Genre Genre
		{
			get => genre;
			set => SetValue(value);
		}

		[Field(nameof(isCustomOnly))]
		public Boolean IsCustomOnly
		{
			get => isCustomOnly;
			set => SetValue(value);
		}

	}
}