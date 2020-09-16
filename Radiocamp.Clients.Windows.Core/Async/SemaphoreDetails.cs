using System;
using System.Threading;

namespace Dartware.Radiocamp.Clients.Windows.Core.Async
{
	public class SemaphoreDetails
	{

		public SemaphoreSlim Semaphore { get; set; }
		public String Key { get; set; }

		public SemaphoreDetails(String key, Int32 maxAccessCount)
		{
			Key = key;
			Semaphore = new SemaphoreSlim(maxAccessCount, maxAccessCount);
		}

	}
}