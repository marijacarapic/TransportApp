using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public class Server
    {
        private Socket serverSocket;
        public Server()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }
        public void Start()
        {
            try
            {

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));
                serverSocket.Bind(endPoint);
                serverSocket.Listen(1);
            }
            catch (IOException ex)
            {

                Debug.WriteLine(ex);
            } 
        
        }
        public void PoveziKlijente()
        {

            try
            {
                while (true)
                {

                    Socket clientSocket = serverSocket.Accept();
                    ClientHandler handler = new ClientHandler(clientSocket);
                    Thread thread = new Thread(handler.HandleRequests);
                    thread.IsBackground = true;
                    thread.Start();

                }
            }
            catch (SocketException ex)
            {

                MessageBox.Show(">>>" + ex.Message);
            }
        }
        public void Stop()
        {
            serverSocket.Close();
        }
    }
}
