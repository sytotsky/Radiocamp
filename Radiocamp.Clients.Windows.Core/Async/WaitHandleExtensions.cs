using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dartware.Radiocamp.Clients.Windows.Core.Async
{
	public static class WaitHandleExtensions
    {

		public static async Task<bool> WaitOneAsync(this WaitHandle handle, Int32 millisecondsTimeout, CancellationToken? cancellationToken)
        {

            RegisteredWaitHandle registeredWaitHandle = null;
            CancellationTokenRegistration? tokenRegistration = null;

            try
            {

                TaskCompletionSource<Boolean> taskCompletionSource = new TaskCompletionSource<Boolean>();
                
                registeredWaitHandle = ThreadPool.RegisterWaitForSingleObject(handle, (state, timedOut) => ((TaskCompletionSource<Boolean>) state).TrySetResult(!timedOut), taskCompletionSource, millisecondsTimeout, true);

                if (cancellationToken.HasValue)
                {
                    tokenRegistration = cancellationToken.Value.Register(state => ((TaskCompletionSource<bool>)state).TrySetCanceled(), taskCompletionSource);
                }

                return await taskCompletionSource.Task;

            }
            finally
            {
                registeredWaitHandle?.Unregister(null);
                tokenRegistration?.Dispose();
            }

        }

		public static Task<Boolean> WaitOneAsync(this WaitHandle handle, TimeSpan timeout, CancellationToken? cancellationToken = null) => handle.WaitOneAsync((int)timeout.TotalMilliseconds, cancellationToken);

		public static Task<Boolean> WaitOneAsync(this WaitHandle handle, CancellationToken? cancellationToken = null) => handle.WaitOneAsync(Timeout.Infinite, cancellationToken);

	}
}