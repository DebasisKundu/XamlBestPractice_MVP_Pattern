namespace GHouseMobile.Core.Models.Settings
{
    public class UserSettings
    {
        public UserSettings()
        {
            NotificationSetting = new NotificationSettings();
        }

        public NotificationSettings NotificationSetting { get; set; }
    }
}
