using System.Threading.Tasks;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.ViewModels;
using Dartware.Radiocamp.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class RadiostationsService : IRadiostations
	{

		private readonly DatabaseContext databaseContext;
		private readonly IDialogs dialogs;

		public RadiostationsService(DatabaseContext databaseContext, IDialogs dialogs)
		{
			this.databaseContext = databaseContext;
			this.dialogs = dialogs;
		}

		public async Task CreateAsync()
		{

			RadiostationEditorArgs radiostationEditorArgs = new RadiostationEditorArgs(null)
			{
				Mode = RadiostationEditorMode.Create
			};

			Radiostation radiostation = await dialogs.Show<Radiostation, RadiostationEditorDialog, RadiostationEditorDialogViewModel>(radiostationEditorArgs);

			if (radiostation != null)
			{
			}

		}

		public Task ExportAsync(ExportArgs exportArgs)
		{
			throw new System.NotImplementedException();
		}

		public Task ImportAsync()
		{
			throw new System.NotImplementedException();
		}

		public Task ClearAsync()
		{
			throw new System.NotImplementedException();
		}

	}
}