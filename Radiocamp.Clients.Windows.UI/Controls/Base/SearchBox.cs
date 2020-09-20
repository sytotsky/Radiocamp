using System;
using System.Windows;
using System.Windows.Input;
using Dartware.Radiocamp.Core.Extensions;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public abstract class SearchBox : RadiocampTextBox
	{

		public SearchBox()
		{
			Loaded += OnLoaded;
		}



		protected override void OnKeyDown(KeyEventArgs args)
		{

			base.OnKeyDown(args);

			if (args.Key == Key.Escape && !Text.IsNullOrEmpty())
			{

				Clear();

				args.Handled = true;

			}

		}

		protected void ClearButton_OnClick(Object sender, RoutedEventArgs args)
		{
			Clear();
		}

		private void OnLoaded(Object sender, RoutedEventArgs args)
		{
			Focus();
		}

	}
}