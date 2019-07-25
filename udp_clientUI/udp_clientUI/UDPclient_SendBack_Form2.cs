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
    public partial class UDPclient_SendBack_Form2 : Form
    {
        public UDPclient_SendBack_Form2()
        {
            InitializeComponent();
        }
        public Socket sending_socket;
        public IPAddress ipaddress = IPAddress.Parse("192.168.1.255");
        public IPEndPoint sendEP;
        public static int listenPort = 8888;
        public UdpClient listener;
        public IPEndPoint groupEp;
        //public StreamWriter STW;
        public string message;
        public string received_data;
        public byte[] buffer = new byte[1024];

        private void connectBtn_Click(object sender, EventArgs e)
        {
            connectToListener();
        }

        private void connectToListener()
        {
            try
            {
                sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sendEP = new IPEndPoint(ipaddress, 11000);
                listener = new UdpClient(listenPort);
                groupEp = new IPEndPoint(IPAddress.Any, listenPort);
                txtReceive.AppendText("Connected to listener!\n");
                receivingWorker.RunWorkerAsync();
                sendingWorker.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (txtSend.Text != "")
            {
                message = txtSend.Text;
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => sendData()));
                }
                sendData();
            }

            txtSend.Text = "";
        }

        private void sendData()
        {
            sendingWorker.RunWorkerAsync();
        }

        private void sendingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                buffer = Encoding.UTF8.GetBytes(message);
                sending_socket.SendTo(buffer, sendEP);

                this.txtReceive.Invoke(new MethodInvoker(delegate()
                    {
                        txtReceive.AppendText("\nSENT To: " + sendEP.Address.ToString() + "\n");
                        txtReceive.AppendText("\n>> " + message + "\n");
                    }));
                sendingWorker.CancelAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void receivingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    buffer = listener.Receive(ref groupEp);
                    received_data = Encoding.UTF8.GetString(buffer);
                    this.txtReceive.Invoke(new MethodInvoker(delegate()
                    {
                        txtReceive.AppendText(">> Received a broadcast from: " + groupEp.ToString() + "\n");
                        txtReceive.AppendText("\nRECEIVED: " + received_data + "\n");

                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
