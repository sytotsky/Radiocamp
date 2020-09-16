using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dartware.Radiocamp.Clients.Windows.Core.Async
{
	public static class AsyncLock
	{

		private static readonly SemaphoreSlim selfLock;
		private static readonly Dictionary<String, SemaphoreDetails> semaphores;

		static AsyncLock()
		{
			selfLock = new SemaphoreSlim(1, 1);
			semaphores = new Dictionary<String, SemaphoreDetails>();
		}

		public static async Task<TypeDefenition> LockResultAsync<TypeDefenition>(String key, Func<Task<TypeDefenition>> task, Int32 maxAccessCount = 1)
		{
			
			await selfLock.WaitAsync();

			try
			{
				if (!semaphores.ContainsKey(key))
				{
					semaphores.Add(key, new SemaphoreDetails(key, maxAccessCount));
				}
			}
			finally
			{
				selfLock.Release();
			}

			SemaphoreDetails semaphore = semaphores[key];

			await semaphore.Semaphore.WaitAsync();

			try
			{
				return await task.Invoke();
			}
			finally
			{
				semaphore.Semaphore.Release();
			}

		}

		public static async Task LockAsync(String key, Func<Task> task, Int32 maxAccessCount = 1)
		{
			await LockResultAsync(key, async () =>
			{

				await task.Invoke();

				return true;

			}, maxAccessCount);
		}

		public static Task LockAsync(String key, Action task, Int32 maxAccessCount = 1)
		{
			return LockResultAsync(key, () =>
			{

				task.Invoke();

				return Task.FromResult(true);

			}, maxAccessCount);
		}

		public static Task<TypeDefenition> LockResultAsync<TypeDefenition>(String key, Func<TypeDefenition> task, Int32 maxAccessCount = 1)
		{
			return LockResultAsync(key, () =>
			{
				return Task.FromResult(task.Invoke());
			}, maxAccessCount);
		}

	}
}