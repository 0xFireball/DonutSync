using DonutSync.Types.Connection;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace DonutSync.Client
{
    public class ConnectionHub
    {
        public IPEndPoint LocalEndpoint { get; }
        public TcpListener ListenerSocket { get; }

        public ConnectionHub() : this(new IPEndPoint(IPAddress.Loopback, DonutSync.Types.Constants.DefaultPort))
        {
        }

        public ConnectionHub(IPEndPoint localEndpoint)
        {
            LocalEndpoint = localEndpoint;
            ListenerSocket = new TcpListener(LocalEndpoint);
        }

        public void Start()
        {
            ListenerSocket.Start();
        }

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