using System;
using System.Windows;
using System.Windows.Input;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Views
{
	public partial class RadiostationItem : View
	{

		public RadiostationItemViewModel ViewModel { get; private set; }

		public RadiostationItem()
		{
			
			InitializeComponent();

			DataContextChanged += OnDataContextChanged;

		}

		private void OnDataContextChanged(Object sender, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue is RadiostationItemViewModel viewModel)
			{
				ViewModel = viewModel;
			}
		}

		protected override async void OnMouseLeftButtonDown(MouseButtonEventArgs args)
		{
			base.OnMouseLeftButtonDown(args);
			await ViewModel.StartPlayback();
		}

		private async void StartPlaybackContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			await ViewModel.StartPlayback();
		}

		private void StopPlaybackContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			ViewModel.StopPlayback();
		}

		private void AddToFavoritesContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			ViewModel.AddToFavorites();
		}

		private void RemoveFromFavoritesContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			ViewModel.RemoveFromFavorites();
		}

		private void PinToTopContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			ViewModel.PinToTop();
		}

		private void UnpinFromTopContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			ViewModel.UnpinFromTop();
		}

		private void ShowPlaybackHistoryContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			// (DataContext as RadiostationItemViewModel)?.ShowPlaybackHistory();
		}

		private void EditContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			ViewModel.Edit();
		}

		private void RemoveContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			ViewModel.Remove();
		}

		private void CopyStreamURLContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			ViewModel.CopyStreamURL();
		}

		private void CopyNameContextMenuItem_OnClick(Object sender, RoutedEventArgs args)
		{
			ViewModel.CopyName();
		}

	}
}