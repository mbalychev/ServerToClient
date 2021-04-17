using System.Net;

namespace ServerToClient
{
        abstract class UniversalConnection
        {
        private readonly string name;
        private readonly string type;
        protected readonly IPAddress remoteAdress;
        protected readonly int port;

        protected IPEndPoint endPoint;


        public string Name => name;
            public string Type => type; //upd or tcp
            public IPAddress RemoteAddress => remoteAdress;
            public int Port => port;
            
            public UniversalConnection(string name, string type, string port, string remoteAdress)
            {
                this.name = name;
                this.type = type;
                bool remoteAdressParse = IPAddress.TryParse(remoteAdress, out this.remoteAdress);
                bool portParse = int.TryParse(port, out this.port);

                if (!remoteAdressParse && !portParse)
                    System.Console.WriteLine("wrong settings string in file!");
                else
                {
                Connection();
                }

            }
        public abstract bool Connection();
    }
}