using System.Net.Sockets;

namespace ServerToClient
{
    abstract class UDPReceiver : UniversalConnection
    {
        protected UdpClient client;
        protected bool active = false;

        public UDPReceiver(string name, string port, string remoteAdress, string type = "upd") : base(name: name, type: type, port: port, remoteAdress: remoteAdress)
        {
        }
        
        public void Close() 
        {
            active = false;
            client.Close();
            System.Console.WriteLine("stop receive");            
        }

        public abstract void Receive();

    }
}