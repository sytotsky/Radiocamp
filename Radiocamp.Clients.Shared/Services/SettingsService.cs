using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Core.Extensions;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public abstract class SettingsService<SettingsType, DatabaseContextType> : ISettings<SettingsType> where SettingsType : Settings where DatabaseContextType : DbContext
	{

		protected readonly DatabaseContextType databaseContext;

		protected SettingsService(DatabaseContextType databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		protected void SetValue<TypeDefinition>(TypeDefinition value, String eventName = null, [CallerMemberName] String propertyName = null)
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