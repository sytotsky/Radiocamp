using System;
using System.Threading.Tasks;
using DynamicData;
using Dartware.Radiocamp.Core.Models;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.ViewModels;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class RadiostationsService : IRadiostations
	{

		private readonly DatabaseContext databaseContext;
		private readonly IDialogs dialogs;

		public ISourceCache<Radiostation, Guid> All { get; private set; }

		public RadiostationsService(DatabaseContext databaseContext, IDialogs dialogs)
		{
			this.databaseContext = databaseContext;
			this.dialogs = dialogs;
		}

		public void Initialize()
		{

			All = new SourceCache<Radiostation, Guid>(radiostation => radiostation.Id);

			All.AddOrUpdate(databaseContext.Radiostations);

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

				radiostation.Id = Guid.NewGuid();
				radiostation.IsCustom = true;
				radiostation.DateOfCreation = DateTime.Now;

				All.AddOrUpdate(radiostation);
				await databaseContext.Radiostations.AddAsync(radiostation);
				await databaseContext.SaveChangesAsync();

			}

		}

		public Task ExportAsync(ExportArgs exportArgs)
		{
			throw new NotImplementedException();
		}

		public Task ImportAsync()
		{
			throw new NotImplementedException();
		}

		public Task ClearAsync()
		{
			throw new NotImplementedException();
		}

	}
}