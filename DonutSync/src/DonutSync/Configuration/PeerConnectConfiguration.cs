using DonutSync.Types.Connection;
using Newtonsoft.Json;

namespace DonutSync.Configuration
{
    public class PeerConnectConfiguration
    {
        [JsonProperty("connectionInfo")]
        public PeerConnectInformation[] ConnectionInformation { get; } = new PeerConnectInformation[0];
    }
}