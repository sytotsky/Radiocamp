using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IDialogs
	{

		event Action ShowDialog;

		Task Show<DialogType, ViewModelType>() where DialogType : Dialog, new() where ViewModelType : DialogViewModel, new();
		Task<Boolean> Confirm(ConfirmArgs args);
		Task Selector<SelectorType>(SelectorArgs<SelectorType> args = null) where SelectorType : struct, IConvertible;

	}
}