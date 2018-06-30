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
        private static Socket s;
        public static void Connect(string host, int port)
        {
            s = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

            s.Connect(host, port);
        }

        public static void Read<T>(T grid) where T: IGrid, ISocketData
        {
            string StartParsingWord = "Access granted:";
            bool recievedDataToParse = false;


            byte[] buffer = new byte[grid.DataSize];

            while (true)
            {
                Thread.Sleep(1);
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

                grid.AddOrUpdateItems(result);
                Console.Clear();
                Console.WriteLine(grid);

                Array.Clear(buffer, 0, buffer.Length);
            }
        }
    }
}
