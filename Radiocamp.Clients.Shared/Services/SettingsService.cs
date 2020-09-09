using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Core.Extensions;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Shared.Attributes;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public abstract class SettingsService<SettingsType, DatabaseContextType> : ISettings<SettingsType> where SettingsType : Settings where DatabaseContextType : DbContext
	{

		protected readonly DatabaseContextType databaseContext;

		protected SettingsService(DatabaseContextType databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public virtual void Initialize()
		{

			SettingsType settings = databaseContext.Set<SettingsType>().AsNoTracking().FirstOrDefault();

			if (settings == null)
			{
				return;
			}

			Type thisType = GetType();
			IEnumerable<FieldInfo> thisFields = thisType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField);
			IEnumerable<String> thisFieldsNames = thisFields.Select(field => field.Name);
			Type settingsType = settings.GetType();
			IEnumerable<PropertyInfo> settingsProperties = settingsType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			foreach (PropertyInfo settingsProperty in settingsProperties)
			{

				if (Attribute.IsDefined(settingsProperty, typeof(IgnorePropertyAttribute)))
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

		protected virtual void SetValue<TypeDefinition>(TypeDefinition value, String eventName = null, [CallerMemberName] String propertyName = null)
		{
			if (!propertyName.IsNullOrEmpty())
			{

				String lowerCasePropertyName = propertyName.ToLowerCaseFirstChar();
				Type thisType = GetType();
				FieldInfo field = thisType.GetField(lowerCasePropertyName, BindingFlags.NonPublic | BindingFlags.Instance);

				if (field == null)
				{
					return;
				}

				TypeDefinition thisValue = (TypeDefinition) field.GetValue(this);

				if (thisValue.Equals(value))
				{
					return;
				}

				field.SetValue(this, value);

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

				Task.Run(() =>
				{
					lock (databaseContext)
					{

						SettingsType settings = databaseContext.Set<SettingsType>().FirstOrDefault();

						if (settings == null)
						{
							return;
						}

						Type settingsType = settings.GetType();
						PropertyInfo property = settingsType.GetProperty(propertyName);

						if (property == null)
						{
							return;
						}

						TypeDefinition valueFromStorage = (TypeDefinition) property.GetValue(settings, null);

						if (valueFromStorage.Equals(value))
						{
							return;
						}

						property.SetValue(settings, value);
						databaseContext.Set<SettingsType>().Update(settings);
						databaseContext.SaveChanges();

					}
				});

			}
		}

	}
}