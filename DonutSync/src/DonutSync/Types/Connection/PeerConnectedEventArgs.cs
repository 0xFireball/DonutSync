namespace DonutSync.Types.Connection
{
    public class PeerConnectedEventArgs
    {
        public ConnectedPeer Peer { get; }

        public PeerConnectedEventArgs(ConnectedPeer peer)
        {
            Peer = peer;
        }
    }
}