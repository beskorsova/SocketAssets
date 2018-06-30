using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SocketAssets
{
    class ConnectionService
    {
        private Socket socket;
        private string startParsingWord = "Access granted:";
        private bool recievedDataToParse = false;

        //TODO: refactor: this is a work around for not parsing login password access granted values
        private bool checkForData(string result)
        {
            if (!recievedDataToParse)
            {
                if (result.IndexOf(startParsingWord) != -1)
                {
                    result = result.Substring(result.IndexOf(startParsingWord) + startParsingWord.Length).TrimEnd(' ');
                    recievedDataToParse = true;
                }
                return false;
            }

            return true;
        }

        public void Connect(string host, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

            socket.Connect(host, port);
        }

        public void Read(int dataSize, Action<string> callback)
        {
            byte[] buffer = new byte[dataSize];

            while (true)
            {
                Thread.Sleep(1);
                var numberOfBytes = socket.Receive(buffer);
                var result = Encoding.ASCII.GetString(buffer, 0, numberOfBytes);

                if (!checkForData(result)) continue;

                callback(result);

                Array.Clear(buffer, 0, buffer.Length);
            }
        }
    }
}
