using Newtonsoft.Json;
using System.Net;

namespace DonutSync.Types.Connection
{
    public class PeerConnectInformation
    {
        [JsonProperty("clientAddress")]
        public string ClientAddress { get; set; }

        [JsonProperty("clientPort")]
        public int ClientPort { get; set; } = DonutSync.Types.Constants.DefaultPort;

        public IPEndPoint CreateConnectEndpoint()
        {
            return new IPEndPoint(IPAddress.Parse(ClientAddress), ClientPort);
        }
    }
}