using System.Net;
using System.Net.Sockets;

namespace DonutSync.Types.Connection
{
    public class ConnectedPeer
    {
        public TcpClient Socket { get; }
        public IPEndPoint Endpoint { get; }

        public ConnectedPeer(TcpClient socket, IPEndPoint endpoint)
        {
            Socket = socket;
            Endpoint = endpoint;
        }
    }
}