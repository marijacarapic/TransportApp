using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class Receiver
    {
        private Socket socket;
        private NetworkStream stream;
        private BinaryFormatter formatter;

        public Receiver(Socket socket)
        {
            this.socket = socket;
            this.stream = new NetworkStream(socket);
            this.formatter = new BinaryFormatter();
        }

        public T Receive<T>() where T : class
        {
            return (T)formatter.Deserialize(stream);
        }

    }
}
