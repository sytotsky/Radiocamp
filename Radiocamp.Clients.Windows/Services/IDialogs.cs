using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public interface IDialogs
	{

		event Action ShowDialog;

		Task Show<DialogType, ViewModelType>(Expression<Func<Boolean>> updatingFlag = null) where DialogType : Dialog, new() where ViewModelType : DialogViewModel, new();
		Task<Boolean> Confirm(ConfirmArgs args);
		Task Selector<SelectorType>(SelectorArgs<SelectorType> args = null) where SelectorType : struct, IConvertible;

	}
}