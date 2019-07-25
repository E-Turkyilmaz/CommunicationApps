using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serial_port_com
{

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
        public string UUTIP;
        public string UUTSocket;
        public List<SerialSettings> SerialTestConfig = new List<SerialSettings>();
    }

    public class Config
    {
        public static UUTSettings UUTSettingsConfig = new UUTSettings();

        public static void loadXML()
        {
            // define the field for xml file
            XmlDocument docxml = new XmlDocument();

            try
            {
                // load the cofiguration file
                docxml.Load(Application.StartupPath + "C:/Users/Egemen/Documents/Projects/serial_port_com/serial_port_com/Configuraiton.xml");
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

            // test xml nodes
            try
            {
                if (TestsNode.HasChildNodes)
                {
                    uutList = TestsNode.ChildNodes;
                    for (int k = 0; k <= uutList.Count; k++)
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
                                            // go through all child nodes and set the configuration accordingly
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
                MessageBox.Show("Yükleme Hatası: settings.xml dosyası formatı bozuk.\nUygulama kapatılacaktır.", "YAZILIM TEST GÖREVSAYAR 412Y HATA MESAJI");
                System.Environment.Exit(1);
            }
            
        }
    }
}