using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class RadiostationItem : UserControl
	{
		
		public RadiostationItem()
		{
			InitializeComponent();
		}

		protected override async void OnMouseLeftButtonDown(MouseButtonEventArgs args)
		{
			base.OnMouseLeftButtonDown(args);
			await (DataContext as RadiostationItemViewModel)?.StartPlayback();
		}

		private void StartPlaybackContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			(DataContext as RadiostationItemViewModel)?.StartPlayback();
		}

		private void StopPlaybackContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			(DataContext as RadiostationItemViewModel)?.StopPlayback();
		}

		private void AddToFavoritesContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			// (DataContext as RadiostationItemViewModel)?.AddToFavorites();
		}

		private void RemoveFromFavoritesContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			// (DataContext as RadiostationItemViewModel)?.RemoveFromFavorites();
		}

		private void PinToTopContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			(DataContext as RadiostationItemViewModel)?.PinToTop();
		}

		private void UnpinFromTopContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			(DataContext as RadiostationItemViewModel)?.UnpinFromTop();
		}

		private void ShowPlaybackHistoryContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			// (DataContext as RadiostationItemViewModel)?.ShowPlaybackHistory();
		}

		private void EditContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			// (DataContext as RadiostationItemViewModel)?.Edit();
		}

		private void RemoveContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			// (DataContext as RadiostationItemViewModel)?.Remove();
		}

		private void CopyStreamURLContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			// (DataContext as RadiostationItemViewModel)?.CopyStreamURL();
		}

		private void CopyNameContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			// (DataContext as RadiostationItemViewModel)?.CopyName();
		}

		private void FavoriteButton_OnChecked()
		{
			// (DataContext as RadiostationItemViewModel)?.AddToFavorites();
		}

		private void FavoriteButton_OnUnchecked()
		{
			// (DataContext as RadiostationItemViewModel)?.RemoveFromFavorites();
		}

	}
}