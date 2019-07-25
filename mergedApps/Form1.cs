using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mergedApps
{
    public partial class launcherForm : Form
    {
        public launcherForm()
        {
            InitializeComponent();
        }

        #region button1

        // serial port

        private void button1_Click(object sender, EventArgs e)
        {
            // run on seperate threads to ensure simultanious access to buffer
            Thread spThread1 = new Thread(new ThreadStart(SerialPort1));
            Thread spThread2 = new Thread(new ThreadStart(SerialPort2));
            spThread1.Start();
            Thread.Sleep(500);
            spThread2.Start();
        }

        private void SerialPort1()
        {
            // invoke serial port 1
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => startSP1()));
                return;
            }
            startSP1();
        }

        private void startSP1()
        {
            // open serial port communication app
            serial_port_com.Form1 openSPform1 = new serial_port_com.Form1();
            openSPform1.Show();
        }

        private void SerialPort2()
        {
            // invoke serial port 2
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => startSP2()));
                return;
            }
            startSP2();
        }

        private void startSP2()
        {
            // check if it will run on echo mode
            if (checkBox1.Checked)
            {
                // if true open echo mode version
                serial_port_com.SerialPort_SendBack_Form2 openSPformSendBack = new serial_port_com.SerialPort_SendBack_Form2();
                openSPformSendBack.Show();
            }
            else
            {
                // else open standard version
                serial_port_com.Form1 openSPform2 = new serial_port_com.Form1();
                openSPform2.Show();
            }
        }

        #endregion

        
        
        #region button2

        // TCP/IP
        
        private void button2_Click(object sender, EventArgs e)
        {
            // run on seperate threads to ensure simultanious access to buffer
            Thread tcpServer_thread = new Thread(new ThreadStart(tcpServerStart));
            Thread tcpClient_thread = new Thread(new ThreadStart(tcpClientStart));
            tcpServer_thread.Start();
            Thread.Sleep(500);
            tcpClient_thread.Start();
        }

        private void tcpServerStart()
        {
            // check if echo mode requested
            if (checkBox2.Checked)
            {
                // if true open echo mode version
                tcpServer_ui.TCPserverSRD_Form2 openTCPserverSRD = new tcpServer_ui.TCPserverSRD_Form2();
                Application.Run(openTCPserverSRD);
            }
            else
            {
                // else open standard version
                tcpServer_ui.Form1 openTCPserver = new tcpServer_ui.Form1();
                Application.Run(openTCPserver);
            }
        }

        private void tcpClientStart()
        {
            if (InvokeRequired)
            {
                // invoke tcp client when needed
                this.Invoke(new Action(() => tcpClient()));
                return;
            }
            tcpClient();
        }

        private void tcpClient()
        {
            // open tcp client project
            tcpClient_ui.Form1 openTCPclient = new tcpClient_ui.Form1();
            openTCPclient.Show();
        }

        #endregion



        #region button3

        // UDP

        private void button3_Click(object sender, EventArgs e)
        {
            // run on seperate threads to ensure simultanious access to buffer
            Thread udpServer_thread = new Thread(new ThreadStart(udpServerStart));
            Thread udpClient_thread = new Thread(new ThreadStart(udpClientStart));
            udpServer_thread.Start();
            Thread.Sleep(500);
            udpClient_thread.Start();
        }

        private void udpServerStart()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => launchUDPserver()));
                return;
            }
            launchUDPserver();
        }

        private void launchUDPserver()
        {
            if (checkBox3.Checked)
            {
                udp_serverUI.UDPlistener_SendBack_Form2 openUDPlistenerSendBack = new udp_serverUI.UDPlistener_SendBack_Form2();
                openUDPlistenerSendBack.Show();
            }
            else
            {
                udp_serverUI.Form1 openUDPserver = new udp_serverUI.Form1();
                openUDPserver.Show();
            }
        }

        private void udpClientStart()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => launchUDPclient()));
                return;
            }
            launchUDPclient();
        }

        private void launchUDPclient()
        {
            udp_clientUI.Form1 openUDPclient = new udp_clientUI.Form1();
            openUDPclient.Show();
        }

        #endregion

        #region button4

        // CAN Bus

        private void button4_Click(object sender, EventArgs e)
        {
            Thread CAN_thread = new Thread(new ThreadStart(canInit));
            CAN_thread.Start();
        }

        private void CAN_thread()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => canInit()));
                return;
            }
            canInit();
        }

        private void canInit()
        {
            CAN_bus_gui.CAN_Form1 runCANbusGUI = new CAN_bus_gui.CAN_Form1();
            Application.Run(runCANbusGUI);
        }

        #endregion
    }
}
