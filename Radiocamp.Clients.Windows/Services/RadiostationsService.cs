using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DynamicData;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Windows.Dialogs;
using Dartware.Radiocamp.Clients.Windows.ViewModels;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class RadiostationsService : IRadiostations
	{

		private readonly DatabaseContext databaseContext;
		private readonly IDialogs dialogs;

		private ISourceCache<WindowsRadiostation, Guid> all;
		private Boolean isInitialized;

		public RadiostationsService(DatabaseContext databaseContext, IDialogs dialogs)
		{
			this.databaseContext = databaseContext;
			this.dialogs = dialogs;
		}

		public async Task<IObservable<IChangeSet<WindowsRadiostation, Guid>>> ConnectAsync()
		{

			if (!isInitialized)
			{

				all = new SourceCache<WindowsRadiostation, Guid>(radiostation => radiostation.Id);

				all.AddOrUpdate(await databaseContext.Radiostations.ToListAsync());

				isInitialized = true;

			}

			return all?.Connect();

		}

		public async Task CreateAsync()
		{

			RadiostationEditorArgs radiostationEditorArgs = new RadiostationEditorArgs(null)
			{
				Mode = RadiostationEditorMode.Create
			};

			WindowsRadiostation radiostation = await dialogs.Show<WindowsRadiostation, RadiostationEditorDialog, RadiostationEditorDialogViewModel>(radiostationEditorArgs);

			if (radiostation != null)
			{

				radiostation.Id = Guid.NewGuid();
				radiostation.IsCustom = true;
				radiostation.DateOfCreation = DateTime.Now;

				all.AddOrUpdate(radiostation);
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