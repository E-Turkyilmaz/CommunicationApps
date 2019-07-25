using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ixxat.Vci4;
using Ixxat.Vci4.Bal;
using Ixxat.Vci4.Bal.Can;

namespace CAN_bus_gui
{
    public partial class CAN_Form1 : Form
    {
        // define the fields to set up the CAN bus (IXXAT vci 4)
        public static IVciDevice mDevice;
        public static ICanControl mCanCtrl;
        public static ICanChannel mCanCh;
        public static ICanScheduler mCanSch;
        public static ICanMessageWriter mWriter;
        public static ICanMessageReader mReader;
        public static Thread rxThread;
        public static long mMustQuit = 0;
        public static AutoResetEvent mRxEvent;
        public IVciDeviceManager deviceManager = null;
        public IVciDeviceList deviceList = null;
        public IEnumerator deviceEnum = null;

        public CAN_Form1()
        {
            InitializeComponent();
            
            foreach(IVciDevice dl in Ixxat.Vci4.VciServer.Instance().DeviceManager.GetDeviceList())
            {
                // find every Ixxat can modules available to the system and list them in combo box
                deviceListCBox.Items.Add(dl);
            }

            // list the operating modes
            ModeSelectCBox.Items.Add(CanOperatingModes.Standard);
            ModeSelectCBox.Items.Add(CanOperatingModes.Extended);

            // list the conventional bus baudrates
            BaudRateCBox.Items.Add(CanBitrate.Cia125KBit);
        }

        // select device on button click
        private void slctDevBtn_Click(object sender, EventArgs e)
        {
            SelectDevice();
        }

        private void SelectDevice()
        {
            try
            {
                // get selected device info
                deviceManager = VciServer.Instance().DeviceManager;
                deviceList = deviceManager.GetDeviceList();
                deviceEnum = deviceListCBox.Items.GetEnumerator();
                deviceEnum.MoveNext();
                mDevice = deviceEnum.Current as IVciDevice;
                IVciCtrlInfo info = mDevice.Equipment[0];
                // inform the user on the selected device
                MessageBox.Show("Selected Device:\n" + mDevice.ToString(), "INFO", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                slctDevBtn.Enabled = true;
            }
            finally
            {
                // release the resources of the library
                DisposeVciObject(deviceManager);
                DisposeVciObject(deviceList);
                DisposeVciObject(deviceEnum);
                slctDevBtn.Enabled = false;
            }
        }

        // method for relasing the occupied resources
        private void DisposeVciObject(object obj)
        {
            if (null != obj)
            {
                IDisposable dispose = obj as IDisposable;
                if (null != dispose)
                {
                    dispose.Dispose();
                    obj = null;
                }
            }
        }

        // start can on button click
        private void CANstartBtn_Click(object sender, EventArgs e)
        {
            if (!InitSocket(0))
            {
                MessageBox.Show("CAN initialization FAILED!");
            }
            else
            {
                // inform the user on can status
                MessageBox.Show("CAN succesfully initialized with followed settings: \n" 
                    + BaudRateCBox.SelectedItem.ToString() 
                    + " of Baud Rate\nin " + ModeSelectCBox.SelectedItem.ToString() + " Mode");

                // threading the background work
                rxThread = new Thread(new ThreadStart(ReceiveThread));
                rxThread.Start();
                Interlocked.Exchange(ref mMustQuit, 1);
                rxThread.Join();
            }
        }

        // initialize can socket
        private bool InitSocket(Byte canNo)
        {
            IBalObject bal = null;
            bool succeeded = false;

            try
            {
                // configure and set the channel to be used
                bal = mDevice.OpenBusAccessLayer();
                mCanCh = bal.OpenSocket(canNo, typeof(ICanChannel)) as ICanChannel;
                mCanSch = bal.OpenSocket(canNo, typeof(ICanScheduler)) as ICanScheduler;
                mCanCh.Initialize(1024, 128, false);
                mReader = mCanCh.GetMessageReader();
                mReader.Threshold = 1;
                mRxEvent = new AutoResetEvent(false);
                mReader.AssignEvent(mRxEvent);
                mWriter = mCanCh.GetMessageWriter();
                mWriter.Threshold = 1;
                mCanCh.Activate();
                mCanCtrl = bal.OpenSocket(canNo, typeof(ICanControl)) as ICanControl;
                if (BaudRateCBox.SelectedItem.Equals(CanBitrate.Cia125KBit))
                {
                    if (ModeSelectCBox.SelectedItem.Equals(CanOperatingModes.Standard))
                    {
                        mCanCtrl.InitLine(CanOperatingModes.Standard | CanOperatingModes.ErrFrame, 
                            CanBitrate.Cia125KBit);
                        mCanCtrl.SetAccFilter(CanFilter.Std, (uint)CanAccCode.All, (uint)CanAccMask.All);
                    }
                    else if (ModeSelectCBox.SelectedItem.Equals(CanOperatingModes.Extended))
                    {
                        mCanCtrl.InitLine(CanOperatingModes.Extended | CanOperatingModes.ErrFrame, 
                            CanBitrate.Cia125KBit);
                        mCanCtrl.SetAccFilter(CanFilter.Ext, (uint)CanAccCode.All, (uint)CanAccMask.All);
                    }
                    mCanCtrl.StartLine();

                    succeeded = true;
                }
                else
                {
                    MessageBox.Show("Please Select The Baud Rate!", "ERROR!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                succeeded = false;
            }
            finally
            {
                DisposeVciObject(bal);
            }
            return succeeded;
        }

        private void ReceiveThread()
        {
            ReadMessage();
        }
            
        // won't be reading messages unless a second can divece is connected to the system
        private void ReadMessage()
        {
            ICanMessage canMessage;
            do
            {
                if (mRxEvent.WaitOne(100, false))
                {
                    while (mReader.ReadMessage(out canMessage))
                    {
                        //txtReveive.AppendText();
                        //MessageBox.Show("Received Message: \n" + "Time : {0,10} ID: {1,3:X} DLC: {2,1} Data: " , canMessage.TimeStamp, canMessage.Identifier, canMessage.DataLength);
                    }
                }
            } while (0 == mMustQuit);
        }

        // trasmit the values on button click
        private void transmitBtn_Click(object sender, EventArgs e)
        {
            IMessageFactory fac = VciServer.Instance().MsgFactory;
            ICanMessage canMsg = (ICanMessage)fac.CreateMsg(typeof(ICanMessage));

            canMsg.TimeStamp = 0;
            canMsg.Identifier = uint.Parse(txtID.Text, System.Globalization.NumberStyles.HexNumber);
            canMsg.FrameType = CanMsgFrameType.Data;
            canMsg.DataLength = 8;
            
            //  message will be consist of an 8 bytes long value
            canMsg[0] = Byte.Parse(D1txt.Text, System.Globalization.NumberStyles.HexNumber);
            canMsg[1] = Byte.Parse(D2txt.Text, System.Globalization.NumberStyles.HexNumber);
            canMsg[2] = Byte.Parse(D3txt.Text, System.Globalization.NumberStyles.HexNumber);
            canMsg[3] = Byte.Parse(D4txt.Text, System.Globalization.NumberStyles.HexNumber);
            canMsg[4] = Byte.Parse(D5txt.Text, System.Globalization.NumberStyles.HexNumber);
            canMsg[5] = Byte.Parse(D6txt.Text, System.Globalization.NumberStyles.HexNumber);
            canMsg[6] = Byte.Parse(D7txt.Text, System.Globalization.NumberStyles.HexNumber);
            canMsg[7] = Byte.Parse(D8txt.Text, System.Globalization.NumberStyles.HexNumber);

            // check the remote transmission option
            if (RFcheckbox.Checked)
                canMsg.RemoteTransmissionRequest = true;
            else
                canMsg.RemoteTransmissionRequest = false;

            mWriter.SendMessage(canMsg);

            MessageBox.Show("Data is succesfully transmitted as: \n" + canMsg.ToString(), 
                "Transmission Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // bit checking
            switch (canMsg.FrameType)
            {
                case CanMsgFrameType.Error:
                    {
                        switch ((CanMsgError)canMsg[0])
                        {
                            case CanMsgError.Stuff:
                                MessageBox.Show("Stuff Error Detected!", "ERROR!", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            case CanMsgError.Form:
                                MessageBox.Show("Form Error Detected!", "ERROR!", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            case CanMsgError.Dlc:
                                MessageBox.Show("Data Length Error Detected!", "ERROR!", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    break;
            }
        }

        // stop can on button click
        private void CANstopBtn_Click(object sender, EventArgs e)
        {
            FinalizeApp();
        }

        private void FinalizeApp()
        {
            DisposeVciObject(mReader);
            DisposeVciObject(mWriter);
            DisposeVciObject(mCanCh);
            DisposeVciObject(mCanCtrl);
            DisposeVciObject(mCanSch);
            DisposeVciObject(mDevice);

            if((MessageBox.Show("Do You Want To End The Application?", "Exit Screen", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                this.Close();
            }
        }

    }
}
