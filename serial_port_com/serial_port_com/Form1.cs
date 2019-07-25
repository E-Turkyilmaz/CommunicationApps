using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace serial_port_com
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // set connection close button as passive at the start
            cmdClose.Enabled = false;

            // list every single serial port available in the system
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                // add names to the combobox
                comboBox1.Items.Add(s);
            }
            
        }

        // define variable to open the port connection
        public System.IO.Ports.SerialPort sPort;

        // the method that sets the connection with necessary parameters
        public void serialport_connect(String port, int baudrate, Parity parity, int dataBits, StopBits stopBits)
        {
            // promt info about the connection 
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();
            sPort = new System.IO.Ports.SerialPort(port, baudrate, parity, dataBits, stopBits);
            try
            {
                sPort.Open();
                // enable connection close button
                cmdClose.Enabled = true;
                // disable set connection button
                cmdConnect.Enabled = false;
                textReceive.AppendText("["+dtn+"]"+"Connected\n");
                sPort.DataReceived += new SerialDataReceivedEventHandler(sPort_DataReceived);
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Error!");}
        }

        // read the data present in the buffer
        private void sPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();
            String data;
            data = sPort.ReadExisting();
            if (this.textReceive.InvokeRequired)
            {
                this.textReceive.Invoke(new MethodInvoker(delegate()
                    {
                        // display the data received
                        textReceive.AppendText("[" + dtn + "]" + "Received: " + data + "\n");
                    }));
            }
        }

        // establish the connection based on button click
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            // choose the port to connect
            String PortName = comboBox1.Text;

            // set the parameters as required
            int BaudRate = 9600;
            Parity parity = Parity.None;
            int dataBits = 8;
            StopBits stopBits = StopBits.One;

            // call the method that sets the connection
            serialport_connect(PortName, BaudRate, parity, dataBits, stopBits);
        }

        // send message on button click
        private void sendButton_Click(object sender, EventArgs e)
        {
            // format the output and display it on chat box
            DateTime dt = DateTime.Now;
            string dtn = dt.ToShortTimeString();
            if (textSend.Text != "")
            {
                String data = textSend.Text;
                sPort.Write(data);
                textReceive.AppendText("[" + dtn + "]" + "Sent: " + data + "\n");
            }
            textSend.Text = "";
        }

        // end the connection on button click
        private void cmdClose_Click(object sender, EventArgs e)
        {
            // format the info
            DateTime dt = DateTime.Now;
            String dtn = dt.ToLongTimeString();

            if (sPort.IsOpen)
            {
                sPort.Close();
                cmdClose.Enabled = false;
                cmdConnect.Enabled = true;
                
                // inform the user when disconnected
                textReceive.AppendText("[" + dtn + "]" + "Disconnected\n");
            }

            // display a message box to confirm the exit
            if (MessageBox.Show("Do you want to exit?", "Confirm", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
