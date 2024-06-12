using GHouseMobile.Core.Models.Settings;
using System.Threading.Tasks;

namespace GHouseMobile.Core.Services.Setting
{
    public interface ISettingService
    {
        Task<RemoteSettings> LoadRemoteSettingAsync(string uri);

        Task<RemoteSettings> LoadSettingAsync();

        Task PersistRemoteSettingAsync(RemoteSettings remoteSetting);

        int Get(string key, int defaultValue);
        bool Get(string key, bool defaultValue);
        string Get(string key, string defaultValue);

        void Set(string key, int value);
        void Set(string key, bool value);
        void Set(string key, string? value);

        void Remove(string key);
    }
}
