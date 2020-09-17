using System.Windows.Controls;
using ReactiveUI.Fody.Helpers;
using Dartware.Radiocamp.Clients.Windows.Core.MVVM;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class DialogWindowViewModel : ViewModel
	{
		[Reactive]
		public Control Content { get; set; }
	}
}