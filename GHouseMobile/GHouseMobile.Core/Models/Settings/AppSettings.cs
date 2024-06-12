namespace GHouseMobile.Core.Models.Settings
{
    public class AppSettings
    {
        public int HttpRequestRetryAttempt { get; set; }
        public int RollbarTimeoutSeconds { get; set; }
        public string? RollbarAccessToken { get; set; }
        public string? RollbarEnvironment { get; set; }
        public string PasswordRegex { get; set; }
        public int? DateOfBirthMinimumAge { get; set; }
        public string PhoneNumberRegex { get; set; }
    }
}
