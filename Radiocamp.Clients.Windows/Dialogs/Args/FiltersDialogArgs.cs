using System;
using Dartware.Radiocamp.Clients.Windows.UI.Windows;
using Dartware.Radiocamp.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Dialogs
{
	public sealed class FiltersDialogArgs : DialogArgs
	{

		public Country Country { get; set; }
		public Action<Country> CountryChangeCallback { get; set; }
		public Genre Genre { get; set; }
		public Action<Genre> GenreChangeCallback { get; set; }
		public Boolean IsCustomOnly { get; set; }
		public Action<Boolean> IsCusomOnlyChangeCallback { get; set; }

		public FiltersDialogArgs(BaseWindow owner, Object parameter = null) : base(owner, parameter)
		{
		}

	}
}