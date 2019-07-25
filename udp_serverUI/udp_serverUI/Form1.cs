using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace udp_serverUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // define fields
        public static int listenPort = 11000;
        public UdpClient listener;
        public IPEndPoint groupEp;
        public string received_data;
        public byte[] buffer = new byte[1024];  

        // start listener on button click
        private void startBtn_Click(object sender, EventArgs e)
        {
            startListening();
        }

        private void startListening()
        {
            try
            {
                // assign the port the listen and IP pool
                listener = new UdpClient(listenPort);
                groupEp = new IPEndPoint(IPAddress.Any, listenPort);
                txtReceive.AppendText("\n**Server Is Up!**\n");
                startBtn.Enabled = false;
                stopBtn.Enabled = true;
                // start listening
                receivingWorker.RunWorkerAsync();
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
                    // listen from the buffer
                    buffer = listener.Receive(ref groupEp);
                    received_data = Encoding.UTF8.GetString(buffer);
                    this.txtReceive.Invoke(new MethodInvoker(delegate()
                        {
                            // prompt the readings
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

        // stop the server on button click
        private void stopBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
        }
    }
}
