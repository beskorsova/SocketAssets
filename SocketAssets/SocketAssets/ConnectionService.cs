using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketAssets
{
    class ConnectionService
    {
        public static void Connect(string host, int port)
        {
           // IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            Console.WriteLine("Establishing Connection to {0}",
                host);
            s.Connect(host, port);
            Console.WriteLine("Connection established");

            while (true)
            {
                Thread.Sleep(1);
               
                byte[] buffer = new byte[256];
                var numberOfBytes = s.Receive(buffer);
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, numberOfBytes));
            }
        }
    }
}
