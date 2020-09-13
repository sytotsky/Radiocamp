using System;
using System.Windows.Input;

namespace Dartware.Radiocamp.Clients.Windows.Core.MVVM
{
	public sealed class RelayCommand : ICommand
	{

		private readonly Action action;
		private readonly Func<Boolean> canExecute;

		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public RelayCommand(Action action, Func<Boolean> canExecute = null)
		{
			this.action = action;
			this.canExecute = canExecute ?? (() => true);
		}

		public Boolean CanExecute(Object parameter) => canExecute.Invoke();

		public void Execute(Object parameter)
		{
			action?.Invoke();
		}

		public void Refresh()
		{
			CommandManager.InvalidateRequerySuggested();
		}

	}
}