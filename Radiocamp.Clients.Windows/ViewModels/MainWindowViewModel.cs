using System;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;
using Dartware.Radiocamp.Clients.Windows.Services;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class MainWindowViewModel : ViewModel
	{

		[Reactive]
		public Double Width { get; set; }

		[Reactive]
		public Double Height { get; set; }

		[Reactive]
		public Double Left { get; set; }

		[Reactive]
		public Double Top { get; set; }

		public MainWindowViewModel(ISettings settings)
		{
			Width = settings.MainWindowWidth;
			Height = settings.MainWindowHeight;
			Left = settings.MainWindowLeft;
			Top = settings.MainWindowTop;
		}

	}
}