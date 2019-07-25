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
using System.IO;

namespace udp_clientUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // define fields for the udp socket
        public Socket sending_socket;
        public IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
        public IPEndPoint sendEP;
        public string message;
        public byte[] buffer = new byte[1024];

        // connect to the buffer on button click
        private void connectBtn_Click(object sender, EventArgs e)
        {
            connectToListener();
        }

        private void connectToListener()
        {
            try
            {
                // initialize the socket assign the end point to listen
                sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sendEP = new IPEndPoint(ipaddress, 9501);
                txtReceive.AppendText("Connected to listener!\n");
                sendingWorker.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // send message on button click
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (txtSend.Text != "")
            {
                message = txtSend.Text;
                sendingWorker.RunWorkerAsync();
            }

            txtSend.Text = "";
        }

        private void sendingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
                // read in the message and put it into buffer
                buffer = Encoding.UTF8.GetBytes(message);
                sending_socket.SendTo(buffer, sendEP);
                this.txtReceive.Invoke(new MethodInvoker(delegate()
                    {
                        txtReceive.AppendText("\nSENT To: " + sendEP.Address.ToString() + "\n");
                        txtReceive.AppendText("\n>> " + message + "\n");
                    }));

            sendingWorker.CancelAsync();
        }
    }
}
