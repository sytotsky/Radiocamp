using System;
using System.Windows;
using System.Windows.Controls;
using Dartware.Radiocamp.Core;
using Dartware.Radiocamp.Core.Models;
using Dartware.Radiocamp.Clients.Windows.UI.Localization;

namespace Dartware.Radiocamp.Clients.Windows.UI.Controls
{
	public sealed class GenreCountry : Label
	{

		public static readonly DependencyProperty GenreProperty = DependencyProperty.Register(nameof(Genre), typeof(Genre), typeof(GenreCountry), new FrameworkPropertyMetadata(default(Genre), FrameworkPropertyMetadataOptions.AffectsMeasure, OnGenreChanged));

		public Genre Genre
		{
			get => (Genre) GetValue(GenreProperty);
			set => SetValue(GenreProperty, value);
		}

		public static readonly DependencyProperty GenreStringProperty = DependencyProperty.Register(nameof(GenreString), typeof(String), typeof(GenreCountry), new PropertyMetadata(default(String)));

		public String GenreString
		{
			get => (String) GetValue(GenreStringProperty);
			private set => SetValue(GenreStringProperty, value);
		}

		private static void OnGenreChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{
			
			if (!(dependency is GenreCountry genreCountry))
			{
				return;
			}

			Object value = args.NewValue;
			String localizationResourceKey = value.GetLocalizationResourceKey();

			if (localizationResourceKey.IsNullOrEmptyOrWhiteSpace())
			{
				return;
			}

			genreCountry.SetResourceReference(GenreCountry.GenreStringProperty, localizationResourceKey);

		}

		public static readonly DependencyProperty CountryProperty = DependencyProperty.Register(nameof(Country), typeof(Country), typeof(GenreCountry), new FrameworkPropertyMetadata(default(Country), FrameworkPropertyMetadataOptions.AffectsMeasure, OnCountryChanged));

		public Country Country
		{
			get => (Country) GetValue(CountryProperty);
			set => SetValue(CountryProperty, value);
		}

		public static readonly DependencyProperty CountryStringProperty = DependencyProperty.Register(nameof(CountryString), typeof(String), typeof(GenreCountry), new PropertyMetadata(default(String)));

		public String CountryString
		{
			get => (String) GetValue(CountryStringProperty);
			private set => SetValue(CountryStringProperty, value);
		}

		private static void OnCountryChanged(DependencyObject dependency, DependencyPropertyChangedEventArgs args)
		{

			if (!(dependency is GenreCountry genreCountry))
			{
				return;
			}

			Object value = args.NewValue;
			String localizationResourceKey = value.GetLocalizationResourceKey();

			if (localizationResourceKey.IsNullOrEmptyOrWhiteSpace())
			{
				return;
			}

			genreCountry.SetResourceReference(GenreCountry.CountryStringProperty, localizationResourceKey);

		}

	}
}