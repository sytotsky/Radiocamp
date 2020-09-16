using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dartware.Radiocamp.Clients.Windows.Core.Async.Tasks
{
	public abstract class SingleTaskWorker
	{

		protected ManualResetEvent WorkerFinishedEvent = new ManualResetEvent(true);
		protected CancellationTokenSource CancellationToken = new CancellationTokenSource();

		public abstract String WorkerName { get; }

		public String LockingKey { get; set; }

		public Boolean Stopping => CancellationToken.IsCancellationRequested;

		public Boolean IsRunning
		{
			get => !WorkerFinishedEvent.WaitOne(0);
			set
			{
				if (value)
				{
					WorkerFinishedEvent.Reset();
				}
				else
				{
					throw new InvalidOperationException($"Use {nameof(StopAsync)} instead.");
				}
			}
		}

		public SingleTaskWorker()
		{
			WorkerFinishedEvent = new ManualResetEvent(true);
			CancellationToken = new CancellationTokenSource();
			LockingKey = nameof(SingleTaskWorker) + Guid.NewGuid().ToString("N");
		}

		public Task<Boolean> StartAsync()
		{
			return AsyncLock.LockResultAsync(LockingKey, () =>
			{

				if (IsRunning)
				{
					return false;
				}

				CancellationToken = new CancellationTokenSource();
				IsRunning = true;

				RunWorkerTaskNoAwait();

				return true;

			});
		}

		public Task StopAsync()
		{
			return AsyncLock.LockAsync(LockingKey, async () =>
			{

				if (!IsRunning)
				{
					return;
				}

				CancellationToken.Cancel();
				await WorkerFinishedEvent.WaitOneAsync();

			});
		}

		protected void RunWorkerTaskNoAwait()
		{
			Task.Run(async () =>
			{
				try
				{
					await WorkerTaskAsync(CancellationToken.Token);
				}
				catch (TaskCanceledException)
				{
				}
				catch (Exception)
				{
				}
				finally
				{
					WorkerFinishedEvent.Set();
				}
			});
		}

		protected virtual Task WorkerTaskAsync(CancellationToken cancellationToken) => Task.FromResult(0);

	}
}