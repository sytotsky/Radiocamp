using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DynamicData;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class RadiostationsService : IRadiostations
	{

		private readonly DatabaseContext databaseContext;

		private ISourceCache<WindowsRadiostation, Guid> all;
		private Boolean isInitialized;

		public event Action<WindowsRadiostation> RadiostationUpdated;

		public RadiostationsService(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task InitializeAsync()
		{
			if (!isInitialized)
			{

				all = new SourceCache<WindowsRadiostation, Guid>(radiostation => radiostation.Id);

				all.AddOrUpdate(await databaseContext.Radiostations.AsNoTracking().ToListAsync());

				isInitialized = true;

			}
		}

		public IObservable<IChangeSet<WindowsRadiostation, Guid>> Connect() => all?.Connect();

		public WindowsRadiostation Get(Guid id) => all?.Items.FirstOrDefault(radiostation => radiostation.Id.Equals(id));

		public WindowsRadiostation GetCurrent() => all?.Items.FirstOrDefault(radiostation => radiostation.IsCurrent);

		public async Task CreateAsync(WindowsRadiostation radiostation)
		{

			if (radiostation is null)
			{
				return;
			}

			radiostation.Id = Guid.NewGuid();
			radiostation.IsCustom = true;
			radiostation.Created = DateTime.Now;

			all.AddOrUpdate(radiostation);
			await databaseContext.Radiostations.AddAsync(radiostation);
			await databaseContext.SaveChangesAsync();

			databaseContext.Entry(radiostation).State = EntityState.Detached;

		}

		public async Task UpdateAsync(WindowsRadiostation radiostation)
		{

			if (radiostation is null)
			{
				return;
			}

			if (radiostation.Id == Guid.Empty)
			{
				await CreateAsync(radiostation);
			}
			else
			{

				RadiostationUpdated?.Invoke(radiostation);
				all.AddOrUpdate(radiostation);

				databaseContext.Entry(radiostation).State = EntityState.Modified;

				databaseContext.Radiostations.Update(radiostation);
				await databaseContext.SaveChangesAsync();

				databaseContext.Entry(radiostation).State = EntityState.Detached;

			}

		}

		public async Task RemoveAsync(Guid id)
		{
			
			WindowsRadiostation radiostation = new WindowsRadiostation()
			{
				Id = id
			};

			all.RemoveKey(id);

			databaseContext.Entry(radiostation).State = EntityState.Deleted;

			await databaseContext.SaveChangesAsync();

		}

		public async Task SetCurrentAsync(WindowsRadiostation radiostation)
		{
			
			WindowsRadiostation currentRadiostation = all.Items.FirstOrDefault(windowsRadiostation => windowsRadiostation.IsCurrent);

			if (currentRadiostation is not null)
			{
				
				if (currentRadiostation.Equals(radiostation))
				{
					return;
				}

				currentRadiostation.IsCurrent = false;

				await UpdateAsync(currentRadiostation);

			}

			radiostation.IsCurrent = true;

			await UpdateAsync(radiostation);

		}

		public async Task TogglePinnedAsync(Guid id)
		{

			WindowsRadiostation radiostation = Get(id);

			if (radiostation is not null)
			{

				radiostation.IsPinned = !radiostation.IsPinned;

				await UpdateAsync(radiostation);

			}

		}

		public void SetIsPlay(WindowsRadiostation radiostation, Boolean isPlay)
		{

			WindowsRadiostation current = all.Items.FirstOrDefault(windowsRadiostation => windowsRadiostation.IsPlay);

			if (current is not null && !current.Equals(radiostation))
			{

				current.IsPlay = false;

				all.AddOrUpdate(current);

			}

			radiostation.IsPlay = isPlay;

			all.AddOrUpdate(radiostation);

		}

		public async Task AddListenTimeAsync(Guid id, TimeSpan listenTime)
		{
			
			WindowsRadiostation radiostation = Get(id);

			if (radiostation is not null)
			{
				
				radiostation.ListenTime += listenTime;

				await UpdateAsync(radiostation);
				
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