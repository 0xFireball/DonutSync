using DonutSync.Types.Connection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

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

        public async Task ConnectPeers(IEnumerable<PeerConnectInformation> connectionInformation)
        {
            var taskList = new List<Task>();
            foreach (var connectionInfo in connectionInformation)
            {
                taskList.Add(ConnectPeer(connectionInfo));
            }
            await Task.WhenAll(taskList);
        }

        public async Task ConnectPeer(PeerConnectInformation connectInfo)
        {
            var remoteEndpoint = connectInfo.CreateConnectEndpoint();
            var connectSocket = new TcpClient();
            await connectSocket.ConnectAsync(remoteEndpoint.Address, remoteEndpoint.Port);
            // Create new connected client
            var connPeer = new ConnectedPeer(connectSocket, remoteEndpoint);
            PeerConnected?.Invoke(this, new PeerConnectedEventArgs(connPeer));
        }

        public event EventHandler<PeerConnectedEventArgs> PeerConnected;
    }
}