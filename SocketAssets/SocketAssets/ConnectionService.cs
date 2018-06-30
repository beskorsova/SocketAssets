using SocketAssets.Formatter;
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
            string StartParsingWord = "Access granted:";
            bool recievedDataToParse = false;

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

                byte[] buffer = new byte[1024];
                var numberOfBytes = s.Receive(buffer);
                var result = Encoding.ASCII.GetString(buffer, 0, numberOfBytes);

                if (!recievedDataToParse)
                {
                    if (result.IndexOf(StartParsingWord) != -1)
                    {
                        result = result.Substring(result.IndexOf(StartParsingWord) + StartParsingWord.Length).TrimEnd(' ');
                        recievedDataToParse = true;
                    }
                    continue;
                }

                foreach (var assest in new AssetFormatter().FromString(result))
                {
                    Console.WriteLine(assest);
                }
            }
        }
    }
}
