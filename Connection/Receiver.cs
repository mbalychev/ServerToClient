using System.Net;
using System.Net.Sockets;
using System;
using System.Text;

namespace ServerToClient
{
    class Receiver : UDPReceiver
    {
        public Receiver(string name, string port, string remoteAdress, string type = "upd") : base(name: name, type: type, port: port, remoteAdress: remoteAdress)
        {
        }
        public override bool Connection()
        {
            endPoint = new IPEndPoint(IPAddress.Any, this.port);
            client = new UdpClient(this.port);

            if (endPoint != null)
            {
                this.active = true;
                return true;
            }
            else 
                return false;
        }

        public override void Receive()
        {
            System.Console.WriteLine("start listening");
            try
            {
                while (this.active)
                {
                    byte[] data = client.Receive(ref endPoint);
                    string message = Encoding.Unicode.GetString(data, 0, data.Length);
                    if (message == "stop")  
                        this.Close();
                    else
                        System.Console.WriteLine("{0} - {1}",this.Name, message);
                }
            }
            catch(ObjectDisposedException)
            {

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("UDPReceive " + ex.Message);
            }
        }

    }
}