using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Threading;
using DynamicData;
using DynamicData.Binding;
using Dartware.Radiocamp.Clients.Shared;
using Dartware.Radiocamp.Clients.Shared.Extensions;
using Dartware.Radiocamp.Clients.Windows.Dialogs;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SelectorViewModel<SelectorType> : DynamicDialogViewModel where SelectorType : struct, IConvertible
	{

		private readonly Action<SelectorType> changeCallback;
		private readonly ISourceCache<SelectorValue<SelectorType>, SelectorType> list;

		private SelectorType current;
		private SelectorItemViewModel<SelectorType> selected;
		private String titleLocalizationResourceKey;
		private String searchQuery;
		private ReadOnlyObservableCollection<SelectorItemViewModel<SelectorType>> values;

		public ReadOnlyObservableCollection<SelectorItemViewModel<SelectorType>> Values => values;

		public SelectorItemViewModel<SelectorType> Selected
		{
			get => selected;
			set => SetAndRaise(ref selected, value);
		}

		public String TitleLocalizationResourceKey
		{
			get => titleLocalizationResourceKey;
			private set => SetAndRaise(ref titleLocalizationResourceKey, value);
		}

		public String SearchQuery
		{
			get => searchQuery;
			set => SetAndRaise(ref searchQuery, value);
		}

		public SelectorViewModel(SelectorType current, Action<SelectorType> changeCallback)
		{
			this.current = current;
			this.changeCallback = changeCallback;
			list = new SourceCache<SelectorValue<SelectorType>, SelectorType>(value => value.Value);
		}

		public override void Initialize()
		{
			
			base.Initialize();

			Width = 300;
			MaxHeight = 420;

			Type type = typeof(SelectorType);

			if (Attribute.IsDefined(type, typeof(LocalizationAttribute)))
			{
				if (Attribute.GetCustomAttribute(type, typeof(LocalizationAttribute)) is LocalizationAttribute localizationAttribute)
				{
					TitleLocalizationResourceKey = localizationAttribute.Key;
				}
			}

			IEnumerable<SelectorType> values = Enum.GetValues(type) as IEnumerable<SelectorType>;

			list.AddOrUpdate(values.Select(value =>
			{

				String localizationResourceKey = value.ToLocalizationResourceKey();
				String searchText = Application.Current.Resources[localizationResourceKey] as String;

				return new SelectorValue<SelectorType>(value, value.Equals(current), localizationResourceKey)
				{
					SearchText = searchText,
					HintLocalizationResourceKey = value.ToHintLocalizationResourceKey()
				};

			}));

			IObservable<Func<SelectorValue<SelectorType>, Boolean>> searchFilter = this.WhenValueChanged(viewModel => viewModel.SearchQuery, true)
																					   .Select(BuildSearcher);

			IDisposable listSubscription = list.Connect()
											   .NotEmpty()
											   .Filter(searchFilter)
											   .Transform(value =>
											   {
												   return new SelectorItemViewModel<SelectorType>(value.Value, value.IsCurrent, value.LocalizationResourceKey)
												   {
													   HintLocalizationResourceKey = value.HintLocalizationResourceKey
												   };
											   })
											   .ObserveOnDispatcher(DispatcherPriority.Background)
											   .Bind(out this.values)
											   .DisposeMany()
											   .Subscribe();

			disposables.Add(listSubscription);

			IDisposable selectedSubscription = this.WhenValueChanged(viewModel => viewModel.Selected)
												   .Where(value => value != null)
												   .Subscribe(OnSelectedChanged);

			disposables.Add(selectedSubscription);

		}

		private void OnSelectedChanged(SelectorItemViewModel<SelectorType> newSelected)
		{

			current = newSelected.Value;

			SelectorValue<SelectorType> oldSelected = list.Items.FirstOrDefault(value => value.IsCurrent);

			if (oldSelected != null)
			{

				oldSelected.IsCurrent = false;

				list.AddOrUpdate(oldSelected);

			}
			
			list.AddOrUpdate(new SelectorValue<SelectorType>(current, true, current.ToLocalizationResourceKey())
			{
				HintLocalizationResourceKey = current.ToHintLocalizationResourceKey()
			});

			changeCallback?.Invoke(current);

		}

		private Func<SelectorValue<SelectorType>, Boolean> BuildSearcher(String searchQuery)
		{

			if (String.IsNullOrEmpty(searchQuery))
			{
				return selectorValue => true;
			}

			return selectorValue =>
			{

				String preparedSearchQuery = SearchQuery.ToLower().Trim();
				String preparedSearchText = selectorValue.SearchText.ToLower();

				return preparedSearchText.Contains(preparedSearchQuery);

			};

		}

	}
}