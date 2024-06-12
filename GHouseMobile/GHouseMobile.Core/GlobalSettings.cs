using GHouseMobile.Core.Abstraction;
using GHouseMobile.Core.Extensions;
using GHouseMobile.Core.Models.User;
using GHouseMobile.Core.Services.Setting;

namespace GHouseMobile.Core
{
    public static class GlobalSettings
    {
        readonly static ISettingService _settingService;

        #region AppSetting Defaults

        const string _root = "https://localhost:44301/api/v1/";
        readonly static string _defaultSettingsEndpoint;
        readonly static string _defaultRegisterEndpoint;
        readonly static string _defaultLoginEndpoint;
        readonly static string _defaultLogoutEndpoint;
        readonly static string _defaultCurrentUserDataEndpoint;
        readonly static string _defaultPostEndpoint;
        readonly static string _defaultCommentEndpoint;
        readonly static string _defaultCheckUserEndpoint;

        const string _defaultRollbarAccessToken = "e12ca28ae4854d24a4043a632946fb5a";
        const string _defaultRollbarEnvironment = "Development"; //TODO: Release
        const int _defaultRollbarTimeoutSeconds = 10;

        const int _defaultHttpRequestRetryAttempt = 5;

        #endregion

        #region UserSetting Defaults

        const bool _defaultMutePushNotifications = false;

        #endregion

        #region AppSetting Properties

        public static UserInfo? User
        {
            get => _settingService.Get(nameof(User), default(UserInfo));
            set => _settingService.Set(nameof(User), value);
        }

        public static void RemoveUserData() => _settingService.Remove(nameof(User));

        public static string SettingsEndpoint
        {
            get => _settingService.Get(nameof(SettingsEndpoint), _defaultSettingsEndpoint);
            set => _settingService.Set(nameof(SettingsEndpoint), value);
        }

        public static string RegisterEndpoint
        {
            get => _settingService.Get(nameof(RegisterEndpoint), _defaultRegisterEndpoint);
            set => _settingService.Set(nameof(RegisterEndpoint), value);
        }

        public static string LoginEndpoint
        {
            get => _settingService.Get(nameof(LoginEndpoint), _defaultLoginEndpoint);
            set => _settingService.Set(nameof(LoginEndpoint), value);
        }

        public static string LogoutEndpoint
        {
            get => _settingService.Get(nameof(LogoutEndpoint), _defaultLogoutEndpoint);
            set => _settingService.Set(nameof(LogoutEndpoint), value);
        }

        public static string PostEndpoint
        {
            get => _settingService.Get(nameof(PostEndpoint), _defaultPostEndpoint);
            set => _settingService.Set(nameof(PostEndpoint), value);
        }

        public static string CommentEndpoint
        {
            get => _settingService.Get(nameof(CommentEndpoint), _defaultCommentEndpoint);
            set => _settingService.Set(nameof(CommentEndpoint), value);
        }

        public static string CurrentUserDataEndpoint
        {
            get => _settingService.Get(nameof(CurrentUserDataEndpoint), _defaultCurrentUserDataEndpoint);
            set => _settingService.Set(nameof(CurrentUserDataEndpoint), value);
        }

        public static string CheckUserEndpoint
        {
            get => _settingService.Get(nameof(CheckUserEndpoint), _defaultCheckUserEndpoint);
            set => _settingService.Set(nameof(CheckUserEndpoint), value);
        }

        public static int HttpRequestRetryAttempt
        {
            get => _settingService.Get(nameof(HttpRequestRetryAttempt), _defaultHttpRequestRetryAttempt);
            set => _settingService.Set(nameof(HttpRequestRetryAttempt), value);
        }

        public static int RollbarTimeoutSeconds
        {
            get => _settingService.Get(nameof(RollbarTimeoutSeconds), _defaultRollbarTimeoutSeconds);
            set => _settingService.Set(nameof(RollbarTimeoutSeconds), value);
        }

        public static string? RollbarAccessToken
        {
            get => _settingService.Get(nameof(RollbarAccessToken), _defaultRollbarAccessToken);
            set => _settingService.Set(nameof(RollbarAccessToken), value);
        }

        public static string? RollbarEnvironment
        {
            get => _settingService.Get(nameof(RollbarEnvironment), _defaultRollbarEnvironment);
            set => _settingService.Set(nameof(RollbarEnvironment), value);
        }

        #endregion

        #region UserSetting Properties

        public static bool MutePushNotifications
        {
            get => _settingService.Get(nameof(MutePushNotifications), _defaultMutePushNotifications);
            set => _settingService.Set(nameof(MutePushNotifications), value);
        }

        #endregion    

        static GlobalSettings()
        {
            _defaultSettingsEndpoint = $"{_root}configuration";
            _defaultRegisterEndpoint = $"{_root}account/register";
            _defaultLoginEndpoint = $"{_root}account/login";
            _defaultLogoutEndpoint = $"{_root}account/logout";
            _defaultPostEndpoint = $"{_root}post";
            _defaultCommentEndpoint = $"{_root}commont";
            _defaultCurrentUserDataEndpoint = $"{_root}me";
            _defaultCheckUserEndpoint = $"{_root}/user/account/checkuser";

            _settingService = ContainerManager.Current.Resolve<ISettingService>();
        }
    }
}
