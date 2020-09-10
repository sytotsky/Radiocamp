using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Dartware.Radiocamp.Clients.Windows.Core.Async.Tasks
{
    public interface ITaskManager
    {
        Task Run(Func<Task> function, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0);
		Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0);
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0);
        Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0);
        Task<TResult> Run<TResult>(Func<TResult> function, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0);
        Task Run(Func<Task> function, CancellationToken cancellationToken, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0);
        Task Run(Action action, CancellationToken cancellationToken, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0);
        Task Run(Action action, [CallerMemberName] String origin = "", [CallerFilePath] String filePath = "", [CallerLineNumber] Int32 lineNumber = 0);
    }
}