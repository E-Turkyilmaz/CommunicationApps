using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace serial_port_com
{
    public partial class SerialPort_SendBack_Form2 : Form
    {
        public SerialPort_SendBack_Form2()
        {
            InitializeComponent();
            cmdClose.Enabled = false;
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
        }

        public System.IO.Ports.SerialPort sPort;
        String data;

        private void SerialPort_SendBack_Form2_Load(object sender, EventArgs e)
        {
            init();
        }

        public void serialport_connect(String port, int baudrate, Parity parity, int dataBits, StopBits stopBits)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();
            sPort = new System.IO.Ports.SerialPort(port, baudrate, parity, dataBits, stopBits);
            try
            {
                sPort.Open();
                cmdClose.Enabled = true;
                cmdConnect.Enabled = false;
                textReceive.AppendText("[" + dtn + "]" + "Connected\n");
                sPort.DataReceived += new SerialDataReceivedEventHandler(sPort_DataReceived);
            }
            catch (Exception ex) { throw ex; }
        }

        private void sPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToShortTimeString();

            data = sPort.ReadExisting();

            if (this.textReceive.InvokeRequired)
            {
                this.textReceive.Invoke(new MethodInvoker(delegate()
                {
                    textReceive.AppendText("[" + dtn + "]" + "Received: " + data + "\n");
                }));
            }

            sendData();
        }

        private void init()
        {
            XmlTextReader xmlRead = new XmlTextReader("C:/Users/Egemen/Desktop/TEU_Client_App/TEU_Client_App/TEU_Client_App/bin/Debug/Configuration.xml");
            XmlDocument docxml = new XmlDocument();

            try
            {
                docxml.Load(xmlRead);
                xmlRead.Close();
            }
            catch
            {
                MessageBox.Show("System cannot load specified XML file!");
                System.Environment.Exit(1);
            }

            XmlNode TestsNode = docxml.DocumentElement;
            XmlNode xNode;
            XmlNode comNode;
            XmlNode uutNode;
            XmlNodeList uutList;
            XmlNodeList nodeList;
            XmlNodeList dataNodeList;

            try
            {
                if (TestsNode.HasChildNodes)
                {
                    uutList = TestsNode.ChildNodes;
                    for (int k = 0; k < uutList.Count; k++)
                    {
                        uutNode = TestsNode.ChildNodes[k];
                        if (uutNode.Name == "UUT" + (k + 1).ToString())
                        {
                            nodeList = uutNode.ChildNodes;
                            for (int i = 0; i < nodeList.Count; i++)
                            {
                                xNode = uutNode.ChildNodes[i];
                                if (xNode.Name == "SerialTests")
                                {
                                    if (xNode.HasChildNodes)
                                    {
                                        dataNodeList = xNode.ChildNodes;
                                        for (int j = 0; j < dataNodeList.Count; j++)
                                        {
                                            int index = 0;
                                            SerialSettings serialNode = new SerialSettings();
                                            comNode = xNode.ChildNodes[j];
                                            serialNode.baudrate = comNode.ChildNodes[index].InnerText;
                                            serialNode.parity = comNode.ChildNodes[++index].InnerText;
                                            serialNode.databits = comNode.ChildNodes[++index].InnerText;
                                            serialNode.stopbits = comNode.ChildNodes[++index].InnerText;
                                            serialNode.testdata = comNode.ChildNodes[++index].InnerText;
                                            serialNode.type = comNode.ChildNodes[++index].InnerText;
                                            serialNode.pName = comNode.ChildNodes[++index].InnerText;
                                            serialNode.name = comNode.ChildNodes[++index].InnerText;

                                            UUTSettingsConfig.SerialTestConfig.Add(serialNode);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Yükleme Hatası: configuration.xml dosyasında bilgisayarda bulunmayan bir port var.", "YAZILIM TEST GÖREVSAYAR 19P HATA MESAJI");
                System.Environment.Exit(1);
            }
            ConnectAllPortsInEchoMode();

        }
        private void ConnectAllPortsInEchoMode()
        {
            try
            {
                for (int k = 0; k < UUTSettingsConfig.SerialTestConfig.Count; k++)
                {
                    int baudrate = int.Parse(UUTSettingsConfig.SerialTestConfig[k].baudrate);
                    int databits = int.Parse(UUTSettingsConfig.SerialTestConfig[k].databits);
                    Parity prty = (Parity)Enum.Parse(typeof(Parity), UUTSettingsConfig.SerialTestConfig[k].parity);
                    StopBits stpbts = (StopBits)Enum.Parse(typeof(StopBits), UUTSettingsConfig.SerialTestConfig[k].stopbits);
                    serialport_connect(UUTSettingsConfig.SerialTestConfig[k].pName, baudrate, prty, databits, stpbts);
                }
            }
            catch
            {
                MessageBox.Show("Yükleme Hatası: configuration.xml dosyasında bilgisayarda bulunmayan bir port var.", "YAZILIM TEST GÖREVSAYAR 19P HATA MESAJI");
                System.Environment.Exit(1);
            }
        }
        private void sendData()
        {
            DateTime dt = DateTime.Now;
            string dtn = dt.ToShortTimeString();

            try
            {
                if (data != "")
                {
                    sPort.Write(data.ToUpper());

                    if (this.textReceive.InvokeRequired)
                    {
                        this.textReceive.Invoke(new MethodInvoker(delegate()
                            {
                                textReceive.AppendText("[" + dtn + "]" + "Sent: " + data.ToUpper() + "\n");
                            }));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String dtn = dt.ToLongTimeString();

            if (sPort.IsOpen)
            {
                sPort.Close();
                cmdClose.Enabled = false;
                cmdConnect.Enabled = true;
                textReceive.AppendText("[" + dtn + "]" + "Disconnected\n");
            }
            if (MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        
        public class SerialSettings
        {
            public string pName;
            public string baudrate;
            public string parity;
            public string databits;
            public string stopbits;
            public string testdata;
            public string type;
            public string name;
        }

        public class UUTSettings
        {
            public List<SerialSettings> SerialTestConfig = new List<SerialSettings>();
        }

        public static UUTSettings UUTSettingsConfig = new UUTSettings();

    }
}
