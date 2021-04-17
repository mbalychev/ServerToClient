using System.Net.Sockets;

namespace ServerToClient
{
    abstract class UDPSender : UniversalConnection
    {
        protected Socket socket;
        public UDPSender (string name, string port, string remoteAdress, string type = "upd") : base(name: name, type: type, port: port, remoteAdress: remoteAdress)
        {
        }
        public abstract void Send(object message);

        public void Close()
        {
            this.socket.Close();
        }
    }
}