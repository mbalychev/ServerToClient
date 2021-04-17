using System.Net;

namespace ServerToClient.Connection
{
    abstract public class ClientConnection
    {
        public string Name;
            public string Type; //upd or tcp
            public IPAddress RemoteAddress;
            public int Port;
            public abstract bool Connection();

            public abstract bool Send(string message);
    }
}