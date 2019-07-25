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

namespace tcpServer_ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // define fields for network streaming
        public NetworkStream stream;
        public StreamReader STR;
        public StreamWriter STW;
        public System.Net.Sockets.TcpListener server;
        public System.Net.Sockets.TcpClient client;
        public int portNumber = 8888;
        public int i;
        public string str;
        public string endStr;
        public String data = null;
        public Byte[] readByte = new Byte[1024];
        
        // start server on button click 
        private void startBtn_Click(object sender, EventArgs e)
        {
            startServer();
        }

        private void startServer()
        {
                try
                {
                    // set the server attributes as connectable from any ip and a certain port number
                    server = new TcpListener(IPAddress.Any, portNumber);
                    server.Start();
                    stopBtn.Enabled = true;
                    startBtn.Enabled = false;
                    
                    // iform the user on connection status and the listened port
                    txtReceive.AppendText(">> Waiting For Connection...\n");
                    txtReceive.AppendText(">> Port Number: " + portNumber.ToString() + "\n");
                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(() => AcceptClients()));
                        return;
                    }
                    AcceptClients();
                    STR = new StreamReader(client.GetStream());
                    STW = new StreamWriter(client.GetStream());
                    STW.AutoFlush = true;

                    txtReceive.AppendText("\n**Connection Established**\n");

                    // run background work asynchronously to grant reader and writer seperate access to the buffer
                    receivingWorker.RunWorkerAsync();
                    sendingWorker.WorkerSupportsCancellation = true;
                    receivingWorker.WorkerSupportsCancellation = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        private void AcceptClients()
        {
            // format the prompting
            txtReceive.AppendText("==========\n");
            client = server.AcceptTcpClient();
            txtReceive.AppendText("==========\n");

        }

        // send message on button click
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (txtSend.Text != "")
            {
                // read in the message
                str = txtSend.Text;
                sendingWorker.RunWorkerAsync();
            }
            
            txtSend.Text = "";
        }
        
        private void sendingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (InvokeRequired)
            {
                // write the message to the buffer
                STW.WriteLine(str);
                this.txtSend.Invoke(new MethodInvoker(delegate()
                {
                    txtReceive.AppendText("\nSENT: " + str + "\n");
                }));
            }
            else // check for exceptions
            {
                MessageBox.Show("Failed to send the message!");
            }
            // stop asynchronous access to the buffer
            sendingWorker.CancelAsync();
        }
        
        private void receivingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    // read from the buffer
                    stream = client.GetStream();
                    i = stream.Read(readByte, 0, readByte.Length);
                    data = Encoding.UTF8.GetString(readByte, 0, i);
                    this.txtReceive.Invoke(new MethodInvoker(delegate()
                    {
                        if (data != "['][CLOSE][']\r\n")
                        {
                            // propmt the received message from the buffer
                            txtReceive.AppendText("\nRECEIVED: " + data + "\n");
                        }
                    }));

                    if (data == "['][CLOSE][']\r\n")
                    {
                        // end connection if token acquired
                        break;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
            // release the resources
            STR.Close();
            STW.Close();
            receivingWorker.CancelAsync();
            client.Close();
            server.Stop();

            // reset button states
            if (InvokeRequired)
            {
                this.stopBtn.Invoke(new MethodInvoker(delegate()
                    {
                        stopBtn.Enabled = false;
                    }));
                this.startBtn.Invoke(new MethodInvoker(delegate()
                    {
                        startBtn.Enabled = true;
                    }));
            }
        }

        // end connection on button click
        private void stopBtn_Click(object sender, EventArgs e)
        {
            endStr = "['][CLOSE][']\r\n";
            STW.Write(endStr);
            STR.Close();
            STW.Close();
            receivingWorker.CancelAsync();
            client.Close();
            server.Stop();
            stopBtn.Enabled = false;
            startBtn.Enabled = true;
        }   
    }
}