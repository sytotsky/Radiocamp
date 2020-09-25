using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Core;
using System.Collections.Generic;

namespace Dartware.Radiocamp.Desktop.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

		public void Initialize()
		{
			Initialize(true);
		}

		public async Task ResetAsync()
		{
			await Task.Run(() =>
			{
				lock (databaseContext)
				{

					Settings settings = databaseContext.Set<Settings>().AsTracking().FirstOrDefault();

					if (settings == null)
					{
						return;
					}

					Type thisType = GetType();
					Type settingsType = settings.GetType();
					PropertyInfo[] thisProperties = thisType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

					foreach (PropertyInfo thisProperty in thisProperties)
					{
						if (Attribute.IsDefined(thisProperty, typeof(DefaultAttribute)))
						{
							if (Attribute.GetCustomAttribute(thisProperty, typeof(DefaultAttribute)) is DefaultAttribute defaultAttribute)
							{

								Object value = defaultAttribute.Value;

								if (Attribute.IsDefined(thisProperty, typeof(NoStorageAttribute)))
								{
									thisProperty.SetValue(this, value);
								}
								else
								{

									PropertyInfo property = settingsType.GetProperty(thisProperty.Name);

									if (property != null)
									{
										property.SetValue(settings, value);
									}

								}

							}
						}
					}

					databaseContext.SaveChanges();

				}
			}).ContinueWith(task =>
			{
				Initialize(false);
			}, TaskContinuationOptions.ExecuteSynchronously);
		}

		private void SetValue<TypeDefinition>(TypeDefinition value, [CallerMemberName] String propertyName = null)
		{
			if (!propertyName.IsNullOrEmpty())
			{

				Type thisType = GetType();
				PropertyInfo property = thisType.GetProperty(propertyName);

				if (property == null)
				{
					return;
				}

				String fieldName = null;

				if (Attribute.IsDefined(property, typeof(FieldAttribute)))
				{

					FieldAttribute fieldAttribute = Attribute.GetCustomAttribute(property, typeof(FieldAttribute)) as FieldAttribute;

					fieldName = fieldAttribute.Name;

				}
				else
				{
					fieldName = propertyName.ToLowerCaseFirstChar();
				}

				FieldInfo field = thisType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

				if (field == null)
				{
					return;
				}

				TypeDefinition thisValue = (TypeDefinition)field.GetValue(this);

				if (thisValue != null)
				{
					if (thisValue.Equals(value))
					{
						return;
					}
				}

				field.SetValue(this, value);

				if (Attribute.IsDefined(property, typeof(EventAttribute)))
				{

					EventAttribute eventAttribute = Attribute.GetCustomAttribute(property, typeof(EventAttribute)) as EventAttribute;
					String eventName = eventAttribute.Name;

					if (!eventName.IsNullOrEmpty())
					{

						FieldInfo eventField = thisType.GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic);

						if (eventField != null)
						{

							MulticastDelegate multicastDelegate = (MulticastDelegate)eventField.GetValue(this);

							if (multicastDelegate != null)
							{

								Delegate[] delegates = multicastDelegate.GetInvocationList();

								foreach (Delegate @delegate in delegates)
								{

									Object[] parameters = new Object[]
									{
										value
									};

									@delegate.Method.Invoke(@delegate.Target, parameters);

								}

							}

						}

					}

				}

				Task.Run(() =>
				{
					lock (databaseContext)
					{

						databaseContext.Set<Settings>().Load();

						Settings settings = databaseContext.Set<Settings>().AsTracking().FirstOrDefault();

						if (settings == null)
						{
							return;
						}

						Type settingsType = settings.GetType();
						PropertyInfo settingsProperty = settingsType.GetProperty(propertyName);

						if (settingsProperty == null)
						{
							return;
						}

						TypeDefinition valueFromStorage = (TypeDefinition)settingsProperty.GetValue(settings, null);

						if (valueFromStorage != null)
						{
							if (valueFromStorage.Equals(value))
							{
								return;
							}
						}

						settingsProperty.SetValue(settings, value);
						databaseContext.Set<Settings>().Update(settings);
						databaseContext.SaveChanges();

					}
				});

			}
		}

		private void Initialize(Boolean isFields)
		{

			Settings settings = databaseContext.Set<Settings>().AsNoTracking().FirstOrDefault();

			if (settings == null)
			{
				return;
			}

			Type thisType = GetType();
			Type settingsType = settings.GetType();
			IEnumerable<PropertyInfo> settingsProperties = settingsType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			if (isFields)
			{

				IEnumerable<FieldInfo> thisFields = thisType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField);
				IEnumerable<String> thisFieldsNames = thisFields.Select(field => field.Name);

				foreach (PropertyInfo settingsProperty in settingsProperties)
				{

					if (Attribute.IsDefined(settingsProperty, typeof(IgnoreAttribute)))
					{
						continue;
					}

					String serviceFieldName = settingsProperty.Name.ToLowerCaseFirstChar();

					if (!thisFieldsNames.Contains(serviceFieldName))
					{
						continue;
					}

					Object value = settingsProperty.GetValue(settings);
					FieldInfo field = thisFields.Where(fieldInfo => fieldInfo.Name.Equals(serviceFieldName)).FirstOrDefault();

					if (field == null)
					{
						continue;
					}

					field.SetValue(this, value);

				}

			}
			else
			{
				foreach (PropertyInfo settingsProperty in settingsProperties)
				{

					if (Attribute.IsDefined(settingsProperty, typeof(IgnoreAttribute)))
					{
						continue;
					}

					Object value = settingsProperty.GetValue(settings);
					PropertyInfo property = thisType.GetProperty(settingsProperty.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);

					if (property == null)
					{
						continue;
					}

					property.SetValue(this, value);

				}
			}

		}

	}
}