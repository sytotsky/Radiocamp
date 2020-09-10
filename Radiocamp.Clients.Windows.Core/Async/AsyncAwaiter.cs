using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Dartware.Radiocamp.Clients.Windows.Core.Async
{
	public static class AsyncAwaiter
	{

		private static readonly SemaphoreSlim selfLock;
		private static readonly Dictionary<String, SemaphoreSlim> semaphores;

		static AsyncAwaiter()
		{
			selfLock = new SemaphoreSlim(1, 1);
			semaphores = new Dictionary<string, SemaphoreSlim>();
		}

		public static async Task<T> AwaitResultAsync<T>(String key, Func<Task<T>> task, Int32 maxAccessCount = 1)
		{

			await selfLock.WaitAsync();

			try
			{
				if (!semaphores.ContainsKey(key))
				{
					semaphores.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
				}
			}
			finally
			{
				selfLock.Release();
			}

			SemaphoreSlim semaphore = semaphores[key];

			await semaphore.WaitAsync();

			try
			{
				return await task();
			}
			finally
			{
				semaphore.Release();
			}

		}

		public static async Task AwaitAsync(String key, Func<Task> task, Int32 maxAccessCount = 1)
		{

			await selfLock.WaitAsync();

			try
			{
				if (!semaphores.ContainsKey(key))
				{
					semaphores.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
				}
			}
			finally
			{
				selfLock.Release();
			}

			SemaphoreSlim semaphore = semaphores[key];

			await semaphore.WaitAsync();

			try
			{
				await task();
			}
			catch (Exception exception)
			{

				String error = exception.Message;

				Debugger.Break();

				throw;

			}
			finally
			{
				semaphore.Release();
			}

		}

	}
}