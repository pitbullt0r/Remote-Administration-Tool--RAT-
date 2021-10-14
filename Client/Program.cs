using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string ip = "127.0.0.1";
            IPAddress ipAddress = null;
            IPAddress.TryParse(ip, out ipAddress);
            IPEndPoint ipEp = new IPEndPoint(ipAddress, 4444);

            client.Connect(ipEp);


            while(true)
            {
                byte[] messageReceived = new byte[1024];
                int bytesReceived = client.Receive(messageReceived);
                string message = Encoding.ASCII.GetString(messageReceived, 0, bytesReceived);
                MessageBox.Show(message);
            }

            
        }
    }
}
