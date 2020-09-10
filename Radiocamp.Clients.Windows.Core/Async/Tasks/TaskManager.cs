using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Dartware.Radiocamp.Clients.Windows.Core.Async.Tasks
{
    public class TaskManager : ITaskManager
    {

        public async Task Run(Func<Task> function, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0)
        {
            try
            {
                await Task.Run(function);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0)
        {
            try
            {
                return await Task.Run(function, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0)
        {
            try
            {
                return await Task.Run(function);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0)
        {
            try
            {
                return await Task.Run(function, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0)
        {
            try
            {
                return await Task.Run(function);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0)
        {
            try
            {
                await Task.Run(function, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0)
        {
            try
            {
                await Task.Run(action, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Run(Action action, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0)
        {
            try
            {
                await Task.Run(action);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}