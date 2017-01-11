using DonutSync.Client;
using DonutSync.Configuration;
using Newtonsoft.Json;
using System.IO;

namespace DonutSync.PeerClient
{
    public class Program
    {
        private const string ConfigFileName = "config.json";

        public static void Main(string[] args)
        {
            // Load configuration
            var config = new PeerConnectConfiguration();
            if (File.Exists(ConfigFileName))
            {
                JsonConvert.PopulateObject(File.ReadAllText(ConfigFileName), config);
            }
            // Create and start hub
            var connectionHub = new ConnectionHub();
            connectionHub.Start();
            // Attempt to connect to clients
            connectionHub.ConnectClients(config.ConnectionInformation);
        }
    }
}