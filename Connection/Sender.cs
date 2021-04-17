using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

namespace ServerToClient
{
    class Sender : UDPSender
    {
        public Sender(string name, string port, string remoteAdress, string type = "upd") : base(name: name, type: type, port: port, remoteAdress: remoteAdress)
        {
        }
        public override bool Connection()
        {
            endPoint = new IPEndPoint(this.remoteAdress, this.port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            if (endPoint != null)
                return true;
            else 
                return false;
        }

        public override void Send(object message)
        {
            try
            {
                byte[] messageCoding = Encoding.Unicode.GetBytes(message.ToString());
                socket.SendTo(messageCoding, endPoint);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("UDPSend " + ex.Message);
            }
        }
    }
}