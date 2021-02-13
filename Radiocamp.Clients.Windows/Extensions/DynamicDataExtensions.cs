using System;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.Kernel;

namespace Dartware.Radiocamp.Clients.Windows.Extensions
{
	public static class DynamicDataExtensions
	{
		public static IObservable<IChangeSet<TDestination, TKey>> TransformWithInlineUpdate<TObject, TKey, TDestination>(this IObservable<IChangeSet<TObject, TKey>> source, Func<TObject, TDestination> transformFactory, Action<TDestination, TObject> updateAction = null)
		{
			return source.Scan((ChangeAwareCache<TDestination, TKey>) null, (cache, changes) =>
			{

				if (cache == null)
				{
					cache = new ChangeAwareCache<TDestination, TKey>(changes.Count);
				}

				foreach (Change<TObject, TKey> change in changes)
				{
					switch (change.Reason)
					{
						case ChangeReason.Add: cache.AddOrUpdate(transformFactory(change.Current), change.Key); break;
						case ChangeReason.Update:
						{

							if (updateAction == null)
							{
								continue;
							}

							TDestination previous = cache.Lookup(change.Key).ValueOrDefault();

							if (previous != null && change.Current != null)
							{
								updateAction(previous, change.Current);
							}

							cache.Refresh(change.Key);

							break;

						}
						case ChangeReason.Remove: cache.Remove(change.Key); break;
						case ChangeReason.Refresh: cache.Refresh(change.Key); break;
						case ChangeReason.Moved: break;
					}
				}

				return cache;

			}).Select(cache => cache.CaptureChanges());
		}
	}
}