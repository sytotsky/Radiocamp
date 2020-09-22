using System;
using System.Reactive;
using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using ReactiveUI;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class ExportRadiostationsDialogViewModel : DialogViewModel
	{

		public ReactiveCommand<Unit, Unit> ExportCommand { get; private set; }

		public ExportRadiostationsDialogViewModel(DialogArgs args) : base(args)
		{
		}

		public override void Initialize()
		{
			
			base.Initialize();

			ExportCommand = ReactiveCommand.CreateFromTask(Export);

			Width = 330;
			MaxHeight = 420;

		}

		private async Task Export()
		{
			throw new NotImplementedException();
		}

	}
}