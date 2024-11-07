using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class Sender
    {
        private Socket socket;
        private NetworkStream stream;
        private BinaryFormatter formatter;

        public Sender(Socket socket)
        {
            this.socket = socket;
            this.stream = new NetworkStream(socket);
            this.formatter = new BinaryFormatter();
        }

        public void Send(object argument)
        {
            formatter.Serialize(stream, argument);
        }
    }
}
