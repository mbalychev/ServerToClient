using System;
using System.Threading;

namespace ServerToClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //prepare new thread for receive messages
            UDPReceiver receive = new Receiver("Receiver one", "11000", "127.0.0.1");
            Thread thread = new Thread(receive.Receive);
            thread.IsBackground = true;
            thread.Start();

            //reading and sending message, while not command "stop" for break
            UDPSender sender = new Sender("Sender one", "11000", "127.0.0.1");
            while (true)
            {
                string message = Console.ReadLine();
                if (message == "stop")
                    break;
                else 
                    sender.Send(message);

            }
            sender.Close();
        }
    }
}
