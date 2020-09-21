using System;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public abstract partial class SettingsService<SettingsType, DatabaseContextType> where SettingsType : Settings where DatabaseContextType : DbContext
	{

		protected Boolean showFavoritesAtStart;
		protected Boolean showOnlyCustomAtStart;
		protected SearchEngine searchEngine;

		[UserSetting]
		[Default(false)]
		public Boolean ShowFavoritesAtStart
		{
			get => showFavoritesAtStart;
			set => SetValue(value);
		}

		[UserSetting]
		[Default(false)]
		public Boolean ShowOnlyCustomAtStart
		{
			get => showOnlyCustomAtStart;
			set => SetValue(value);
		}

		[UserSetting]
		[Default(SearchEngine.Google)]
		public SearchEngine SearchEngine
		{
			get => searchEngine;
			set => SetValue(value);
		}

	}
}