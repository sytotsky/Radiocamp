using System;
using System.Windows;
using Dartware.Radiocamp.Core;
using Dartware.Radiocamp.Clients.Windows.Windows;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{

	public interface IDialogViewModel : IDisposable, IInitializable
	{
		Double Width { get; }
		Double Height { get; }
		Double MaxWidth { get; }
		Double MaxHeight { get; }
		Double MinWidth { get; }
		Double MinHeight { get; }
		Thickness Padding { get; }
		DialogWindow DialogWindow { get; set; }
	}

	public interface IDialogViewModel<ResultType> : IDialogViewModel
	{
		ResultType Result { get; set; }
	}

}