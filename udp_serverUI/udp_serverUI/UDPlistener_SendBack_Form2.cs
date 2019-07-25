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

namespace udp_serverUI
{
    public partial class UDPlistener_SendBack_Form2 : Form
    {
        public UDPlistener_SendBack_Form2()
        {
            InitializeComponent();
        }

        public Socket sending_socket;
        public IPAddress ipaddress = IPAddress.Parse("192.168.1.255");
        public IPEndPoint sendEP;
        public static int listenPort = 11000;
        public UdpClient listener;
        public IPEndPoint groupEp;
        public string received_data;
        public string msg;
        public byte[] receiveBuffer = new byte[1024];
        public byte[] sendBuffer = new byte[1024];

        private void startBtn_Click(object sender, EventArgs e)
        {
            startListening();
        }

        private void startListening()
        {
            try
            {
                sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sendEP = new IPEndPoint(ipaddress, 11000);
                listener = new UdpClient(listenPort);
                groupEp = new IPEndPoint(IPAddress.Any, listenPort);
                txtReceive.AppendText("\n**Server Is Up!**\n");
                startBtn.Enabled = false;
                stopBtn.Enabled = true;
                receivingWorker.RunWorkerAsync();
                receivingWorker.WorkerSupportsCancellation = true;
                sendingWorker.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void receivingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    receiveBuffer = listener.Receive(ref groupEp);
                    received_data = Encoding.UTF8.GetString(receiveBuffer);
                    this.txtReceive.Invoke(new MethodInvoker(delegate()
                        {
                            txtReceive.AppendText(">> Received a broadcast from: " + groupEp.ToString() + "\n");
                            txtReceive.AppendText("\nRECEIVED: " + received_data + "\n");
                        }));
                    sendData(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void sendData(object sender, EventArgs e)
        {
            sendingWorker.RunWorkerAsync();
        }

        private void sendingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            msg = received_data.ToUpper();
            sendBuffer = Encoding.UTF8.GetBytes(msg);
            sending_socket.SendTo(sendBuffer, sendEP);

            this.txtReceive.Invoke(new MethodInvoker(delegate()
                {
                    txtReceive.AppendText("\nSENT To: " + sendEP.Address.ToString() + "\n");
                    txtReceive.AppendText("\n>> " + msg + "\n");
                }));
            sendingWorker.CancelAsync();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
        }
    }
}
