using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Shared.Services
{
	public interface ISettings<SettingsType> where SettingsType : Settings
	{
		void Initialize();
	}
}