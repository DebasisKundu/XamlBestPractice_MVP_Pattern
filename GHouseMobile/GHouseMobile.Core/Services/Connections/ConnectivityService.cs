using Xamarin.Essentials;

namespace GHouseMobile.Core.Services.Connections
{
    public class ConnectivityService : IConnectivityService
    {
        public bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}
