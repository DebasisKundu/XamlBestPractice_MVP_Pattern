namespace GHouseMobile.Core.Models.User
{
    public class LoginInfo
    {
        public LoginInfo(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
