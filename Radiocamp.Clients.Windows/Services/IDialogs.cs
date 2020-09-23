using System;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IDialogs
	{

		event Action ShowDialog;

		Task Show<DialogType, ViewModelType>(DialogArgs args) where DialogType : Dialog, new() where ViewModelType : DialogViewModel;
		Task<ResultType> Show<ResultType, DialogType, ViewModelType>(DialogArgs args) where DialogType : Dialog, new() where ViewModelType : DialogViewModel<ResultType>;
		Task<Boolean> Confirm(ConfirmDialogArgs args);
		Task Selector<SelectorType>(SelectorDialogArgs<SelectorType> args) where SelectorType : struct, IConvertible;

	}
}