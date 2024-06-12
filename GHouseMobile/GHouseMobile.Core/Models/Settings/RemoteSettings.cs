using System.Collections.Generic;
using GHouseMobile.Core.Models.Localization;

namespace GHouseMobile.Core.Models.Settings
{
    public class RemoteSettings
    {
        public RemoteSettings()
        {
            UserSetting = new UserSettings();
            AppSetting = new AppSettings();
            EndpointSetting = new EndpointSettings();
        }

        public UserSettings UserSetting { get; set; }

        public AppSettings AppSetting { get; set; }

        public EndpointSettings EndpointSetting { get; set; }

        public List<LocalResource> LocalResources { get; set; }

        public List<LookupResource> LookupResources { get; set; }
    }
}
