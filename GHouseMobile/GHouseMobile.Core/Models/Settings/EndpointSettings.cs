namespace GHouseMobile.Core.Models.Settings
{
    public class EndpointSettings
    {
        public EndpointSettings()
        {
            Urls = new EndpointData();
        }

        public EndpointData Urls { get; set; }
    }

    public class EndpointData
    {
        public string? CheckUser { get; set; }
        public string? Login { get; set; }
        public string? Register { get; set; }
        public string? Post { get; set; }
        public string? Comment { get; set; }
        public string? CurrentUserData { get; set; }
    }
}
