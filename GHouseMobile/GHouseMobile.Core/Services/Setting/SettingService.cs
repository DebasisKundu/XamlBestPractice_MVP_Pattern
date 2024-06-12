using GHouseMobile.Core.Models.Settings;
using GHouseMobile.Core.Services.Request;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace GHouseMobile.Core.Services.Setting
{
    public class SettingService : ISettingService
    {
        readonly IRequestService _requestService;

        public SettingService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<RemoteSettings> LoadRemoteSettingAsync(string uri)
        {
            return await _requestService.GetAsync<RemoteSettings>(GlobalSettings.SettingsEndpoint, GlobalSettings.User?.Token);
        }

        public Task<RemoteSettings> LoadSettingAsync()
        {
            var remoteSetting = new RemoteSettings();
            remoteSetting.AppSetting.HttpRequestRetryAttempt = GlobalSettings.HttpRequestRetryAttempt;
            remoteSetting.AppSetting.RollbarTimeoutSeconds = GlobalSettings.RollbarTimeoutSeconds;
            remoteSetting.AppSetting.RollbarAccessToken = GlobalSettings.RollbarAccessToken;
            remoteSetting.AppSetting.RollbarEnvironment = GlobalSettings.RollbarEnvironment;
            remoteSetting.EndpointSetting.Urls.CurrentUserData = GlobalSettings.CurrentUserDataEndpoint;
            remoteSetting.EndpointSetting.Urls.Register = GlobalSettings.RegisterEndpoint;
            remoteSetting.EndpointSetting.Urls.Login = GlobalSettings.LoginEndpoint;
            remoteSetting.EndpointSetting.Urls.Post = GlobalSettings.PostEndpoint;
            remoteSetting.EndpointSetting.Urls.Comment = GlobalSettings.CommentEndpoint;
            remoteSetting.EndpointSetting.Urls.CheckUser = GlobalSettings.CheckUserEndpoint;
            remoteSetting.UserSetting.NotificationSetting.MutePushNotifications = GlobalSettings.MutePushNotifications;

            return Task.FromResult(remoteSetting);
        }

        public Task PersistRemoteSettingAsync(RemoteSettings remoteSetting)
        {
            GlobalSettings.HttpRequestRetryAttempt = remoteSetting.AppSetting.HttpRequestRetryAttempt;
            GlobalSettings.RollbarTimeoutSeconds = remoteSetting.AppSetting.RollbarTimeoutSeconds;
            GlobalSettings.RollbarAccessToken = remoteSetting.AppSetting.RollbarAccessToken;
            GlobalSettings.RollbarEnvironment = remoteSetting.AppSetting.RollbarEnvironment;
            GlobalSettings.CurrentUserDataEndpoint = remoteSetting.EndpointSetting.Urls.CurrentUserData;
            GlobalSettings.RegisterEndpoint = remoteSetting.EndpointSetting.Urls.Register;
            GlobalSettings.LoginEndpoint = remoteSetting.EndpointSetting.Urls.Login;
            GlobalSettings.PostEndpoint = remoteSetting.EndpointSetting.Urls.Post;
            GlobalSettings.CommentEndpoint = remoteSetting.EndpointSetting.Urls.Comment;
            GlobalSettings.MutePushNotifications = remoteSetting.UserSetting.NotificationSetting.MutePushNotifications;

            return Task.FromResult(false);
        }

        public int Get(string key, int defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public bool Get(string key, bool defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public string Get(string key, string defaultValue)
        {
            return Preferences.Get(key, defaultValue);
        }

        public void Set(string key, int value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, bool value)
        {
            Preferences.Set(key, value);
        }

        public void Set(string key, string? value)
        {
            Preferences.Set(key, value);
        }

        public void Remove(string key)
        {
            Preferences.Remove(key);
        }
    }
}
