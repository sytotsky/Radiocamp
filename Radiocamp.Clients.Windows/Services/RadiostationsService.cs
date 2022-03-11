using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DynamicData;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using ProtoBuf;

namespace Dartware.Radiocamp.Clients.Windows.Services
{
	public sealed class RadiostationsService : IRadiostations
	{

		private readonly DatabaseContext databaseContext;
		private readonly IMapper mapper;
		private readonly ISourceCache<WindowsRadiostation, Guid> all;
		private readonly ISubject<WindowsRadiostation> updated;
		private readonly ISubject<Guid> removed;
		private readonly ISubject<Unit> cleared;
		
		private Boolean isInitialized;

		public IObservable<WindowsRadiostation> Updated => updated;
		public IObservable<Guid> Removed => removed;
		public IObservable<Unit> Cleared => cleared;

		public RadiostationsService(DatabaseContext databaseContext, IMapper mapper)
		{
			
			this.databaseContext = databaseContext;
			this.mapper = mapper;
			
			all = new SourceCache<WindowsRadiostation, Guid>(radiostation => radiostation.Id);
			updated = new Subject<WindowsRadiostation>();
			removed = new Subject<Guid>();
			cleared = new Subject<Unit>();

		}

		public async Task InitializeAsync()
		{
			if (!isInitialized)
			{

				all.AddOrUpdate(await databaseContext.Radiostations.AsNoTracking().ToListAsync());

				isInitialized = true;

			}
		}

		public IObservable<IChangeSet<WindowsRadiostation, Guid>> Connect() => all?.Connect();

		public WindowsRadiostation Get(Guid id) => all?.Items.FirstOrDefault(radiostation => radiostation.Id.Equals(id));

		public WindowsRadiostation GetCurrent() => all?.Items.FirstOrDefault(radiostation => radiostation.IsCurrent);

		public async Task CreateAsync(WindowsRadiostation radiostation)
		{
			await CreateAsync(radiostation, true);
		}

		public async Task CreateAsync(WindowsRadiostation radiostation, Boolean isCustom)
		{

			if (radiostation is null)
			{
				return;
			}

			radiostation.Id = Guid.NewGuid();
			radiostation.IsCustom = isCustom;
			radiostation.Created = DateTime.Now;

			all.AddOrUpdate(radiostation);
			await databaseContext.Radiostations.AddAsync(radiostation);
			await databaseContext.SaveChangesAsync();

			databaseContext.Entry(radiostation).State = EntityState.Detached;

		}

		public async Task CreateRangeAsync(IEnumerable<WindowsRadiostation> radiostations)
		{

			if (radiostations is null)
			{
				return;
			}

			if (!radiostations.Any())
			{
				return;
			}

			foreach (WindowsRadiostation radiostation in radiostations)
			{
				radiostation.Id = Guid.NewGuid();
				radiostation.Created = DateTime.Now;
			}

			all.AddOrUpdate(radiostations);
			await databaseContext.Radiostations.AddRangeAsync(radiostations);
			await databaseContext.SaveChangesAsync();

			foreach (WindowsRadiostation radiostation in radiostations)
			{
				databaseContext.Entry(radiostation).State = EntityState.Detached;
			}

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

				updated?.OnNext(radiostation);
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

			removed?.OnNext(id);
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

		public async Task SetLastPlaybackTimeAsync(Guid id)
		{
			
			WindowsRadiostation radiostation = Get(id);

			if (radiostation is not null)
			{
				
				radiostation.LastPlayTime = DateTime.Now;

				await UpdateAsync(radiostation);

			}
			
		}

		public async Task ExportAsync(ExportArgs exportArgs)
		{

			if (exportArgs is null)
			{
				throw new ArgumentNullException(nameof(exportArgs), "Export arguments cannot be null.");
			}

			if (String.IsNullOrEmpty(exportArgs.FilePath))
			{
				throw new ArgumentException("File path cannot be null or empty.", nameof(exportArgs.FilePath));
			}

			IQueryable<WindowsRadiostation> radiostations = databaseContext.Radiostations;

			if (!exportArgs.All)
			{
				if (exportArgs.OnlyFavoritesOrCustom)
				{
					radiostations = radiostations.Where(radiostation => radiostation.IsFavorite || radiostation.IsCustom);
				}
				else
				{
					if (exportArgs.CustomOnly && exportArgs.FavoritesOnly)
					{
						radiostations = radiostations.Where(radiostation => radiostation.IsFavorite && radiostation.IsCustom);
					}
					else if (exportArgs.CustomOnly)
					{
						radiostations = radiostations.Where(radiostation => radiostation.IsCustom);
					}
					else if (exportArgs.FavoritesOnly)
					{
						radiostations = radiostations.Where(radiostation => radiostation.IsFavorite);
					}
				}
			}

			IEnumerable<SerializableRadiostation> serializableRadiostations = mapper.Map<IEnumerable<SerializableRadiostation>>(await radiostations.ToListAsync());

			if (serializableRadiostations is not null)
			{
				switch (exportArgs.Format)
				{
					case ExportFormat.Binary: await ExportAsBinaryFormatAsync(serializableRadiostations, exportArgs.FilePath); break;
					case ExportFormat.JSON: break;
				}
			}

		}

		public async Task ImportAsync(String filePath)
		{

			if (String.IsNullOrEmpty(filePath))
			{
				return;
			}

			if (!File.Exists(filePath))
			{
				return;
			}

			String extension = Path.GetExtension(filePath);

			if (String.IsNullOrEmpty(extension))
			{
				return;
			}

			extension = extension.ToLower();

			switch (extension)
			{
				case ".radcampback": await ImportBinaryAsync(filePath); break;
				case ".json": break;
			}

		}

		public Task ClearAsync()
		{
			
			cleared?.OnNext(Unit.Default);
			
			throw new NotImplementedException();
			
		}

		private async Task ExportAsBinaryFormatAsync(IEnumerable<SerializableRadiostation> serializableRadiostations, String filePath)
		{
			await Task.Run(() =>
			{

				String directory = Path.GetDirectoryName(filePath);

				if (!String.IsNullOrEmpty(directory))
				{
					if (!Directory.Exists(directory))
					{
						Directory.CreateDirectory(directory);
					}
				}

				if (!String.IsNullOrEmpty(filePath))
				{
					
					using FileStream file = File.Create(filePath);

					Serializer.Serialize(file, serializableRadiostations);

				}

			});
		}

		private async Task ImportBinaryAsync(String filePath)
		{

			if (String.IsNullOrEmpty(filePath))
			{
				return;
			}

			if (!File.Exists(filePath))
			{
				return;
			}

			String extension = Path.GetExtension(filePath);

			if (String.IsNullOrEmpty(extension))
			{
				return;
			}

			extension = extension.ToLower();

			if (!extension.Equals(".radcampback"))
			{
				return;
			}

			await Task.Run(async () =>
			{
				
				await using FileStream file = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
				IEnumerable<SerializableRadiostation> serializableRadiostations = Serializer.Deserialize<IEnumerable<SerializableRadiostation>>(file);

				if (serializableRadiostations is null)
				{
					return;
				}

				if (!serializableRadiostations.Any())
				{
					return;
				}

				IEnumerable<WindowsRadiostation> radiostations = mapper.Map<IEnumerable<WindowsRadiostation>>(serializableRadiostations);

				if (radiostations is null)
				{
					return;
				}

				if (!radiostations.Any())
				{
					return;
				}

				await CreateRangeAsync(radiostations);

			});

		}

	}
}