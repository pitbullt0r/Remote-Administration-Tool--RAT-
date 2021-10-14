using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Remote_Administration_Tool
{
    public partial class Form1 : Form
    {
        
        static Socket listener;
        static Socket client;
        static ListBox listboxClient;
        static Button buttonListen;
        static Label labelStatus;
        static TextBox textboxMessage;
        
        
        

        #region THREADS
        Thread t1 = new Thread(new ThreadStart(Listen));
        
        #endregion

        public Form1()
        {
            InitializeComponent();
            listboxClient = listClient;
            buttonListen = btnListen;
            labelStatus = lblStatus;
            textboxMessage = txtMessage;
            
            
        }

        
        private void btnListen_Click(object sender, EventArgs e)
        {
            labelStatus.Text = $"Listening on port: 4444";
            buttonListen.Enabled = false;
            t1.Start();
            
           
            
            
        }


        static void Listen()
        {
            
            int port = 4444;
            
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEp = new IPEndPoint(IPAddress.Any, port);
            listener.Bind(ipEp);
            listener.Listen(10);
            client = listener.Accept();
            listboxClient.Items.Add("BOT: " + client.RemoteEndPoint.ToString());
            

        }

        
        
        static void SendMessage()
        {
            byte[] message = Encoding.ASCII.GetBytes(textboxMessage.Text);
            client.Send(message);


        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
    }

    
        

}
