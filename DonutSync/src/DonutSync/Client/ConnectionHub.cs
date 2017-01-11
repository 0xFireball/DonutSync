using DonutSync.Types.Connection;
using System.Collections.Generic;

namespace DonutSync.Client
{
    public class ConnectionHub
    {
        public void ConnectClients(IEnumerable<PeerConnectInformation> connectionInformation)
        {
            foreach (var connectionInfo in connectionInformation)
            {
                ConnectClient(connectionInfo);
            }
        }

        public void ConnectClient(PeerConnectInformation connectInfo)
        {

        }
    }
}