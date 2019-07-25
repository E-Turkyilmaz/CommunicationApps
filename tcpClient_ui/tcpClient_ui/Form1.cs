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

namespace tcpClient_ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // define the fields for network stream
        public System.Net.Sockets.NetworkStream stream;
        public StreamReader STR;
        public StreamWriter STW;
        public System.Net.Sockets.TcpClient client;
        public String data = null;
        public string message;

 
        // connect to the server on button click
        private void conBtn_Click(object sender, EventArgs e)
        {
           // call the related method to connect to the server
            ConnectToServer();
            conBtn.Enabled = false;
            dcBtn.Enabled = true;
        }
        
        private void ConnectToServer()
        {
            try
            {
                // read in the port number and IP address
                Int32 port = Convert.ToInt32(portTextBox.Text);
                IPAddress ipAddress = IPAddress.Parse(ipTextBox.Text);

                // error checking for invalid values
                if ((portTextBox.Text != "") && (ipTextBox.Text != ""))
                {
                    client = new TcpClient(ipAddress.ToString(), port);
                }
                else if(ipAddress == null)
                {
                    MessageBox.Show("Plesase Enter Connection Info!", "IP and Port missing!!!", 
                        MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                }

                STW = new StreamWriter(client.GetStream());
                STR = new StreamReader(client.GetStream());
                STW.AutoFlush = true;

                // run receive and send asynchronously to eliminate buffer overlap
                receivingWorker.RunWorkerAsync();
                sendingWorker.WorkerSupportsCancellation = true;
                receivingWorker.WorkerSupportsCancellation = true;
            }

            catch(Exception ex)
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

        // set the sending worker
        private void sendingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (InvokeRequired)
            {
                STW.WriteLine(message);

                this.txtReceive.Invoke(new MethodInvoker(delegate()
                    {
                        txtReceive.AppendText("\nSENT: " + message   + "\n");
                    }));
            }
            else
            {
                MessageBox.Show("Failed to send the message!");
            }

            sendingWorker.CancelAsync();
        }

        // set the receiving worker
        private void receivingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    data = STR.ReadLine();

                    this.txtSend.Invoke(new MethodInvoker(delegate()
                        {
                            if (data != "['][CLOSE][']\r\n")
                            {
                                txtReceive.AppendText("\nRECEIVED: " + data + "\n");
                            }
                        }));

                    if (data == "['][CLOSE][']\r\n")
                    {
                        // exit the loop if token is read
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            // release resources
            STW.Close();
            STR.Close();
            receivingWorker.CancelAsync();
            client.Close();

            if (InvokeRequired)
            {
                this.dcBtn.Invoke(new MethodInvoker(delegate()
                    {
                        dcBtn.Enabled = false;
                    }));
                this.conBtn.Invoke(new MethodInvoker(delegate()
                    {
                        conBtn.Enabled = true;
                    }));
            }
        }

        // disconnect from server on button click
        private void dcBtn_Click(object sender, EventArgs e)
        {
            // send disconnection token
            message = "['][CLOSE][']";
            STW.WriteLine(message);
            STW.Close();
            STR.Close();
            receivingWorker.CancelAsync();
            client.Close();            
            dcBtn.Enabled = false;
            conBtn.Enabled = true;
        }
    }
}
