using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using NRfidApi;


namespace DIP_Handheld
{
    public partial class frmLocate : Form
    {
        ArrayList Tags;
        RfidApi rfid;
        Point PanelLocationShow;
        Point PanelLocationHide;
        Timer timerStop = null;
        string btnStatus = "Start";

        ArrayList alKeys = null;

            #region  ########## Play_Sound ##########
            [DllImport("coredll.dll")]
            private static extern int PlaySound(string szSound, IntPtr hModule, int flags);

            private enum PlaySoundFlags : int
            {
                SND_SYNC = 0x0,         // play synchronously (default)
                SND_ASYNC = 0x1,        // play asynchronously
                SND_NODEFAULT = 0x2,    // silence (!default) if sound not found
                SND_MEMORY = 0x4,       // pszSound points to a memory file
                SND_LOOP = 0x8,         // loop the sound until next sndPlaySound
                SND_NOSTOP = 0x10,      // don't stop any currently playing sound
                SND_NOWAIT = 0x2000,    // don't wait if the driver is busy
                SND_ALIAS = 0x10000,    // name is a registry alias
                SND_ALIAS_ID = 0x110000,// alias is a predefined ID
                SND_FILENAME = 0x20000, // name is file name
                SND_RESOURCE = 0x40004, // name is resource name or atom
            };
            public void Play_Sound(string fileName)
            {
                PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC));
            }
            public void Play_Sound_NOSTOP(string fileName)
            {
                PlaySound(fileName, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC | PlaySoundFlags.SND_NOSTOP));
            }
            #endregion
        public frmLocate()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //frmMain frm = new frmMain();
            //frm.Show();
            this.Close();
        }

        public void CallbackProc(RFIDCALLBACKDATA CallbackData)
        {
            string Msg = new string(new char[512]);

            // Data GetResult function and read the values separated by a CallbackType Reply to the reporting process.
            rfid.GetResult(Msg, CallbackData.CallbackType, CallbackData.wParam, CallbackData.lParam);
            Msg = Msg.Substring(0, Msg.IndexOf("\0"));
            InventoryProc(Msg, CallbackData.CallbackType);
            

        }
        // Inventory
        public void InventoryProc(string Msg, RFID_CALLBACK_TYPE Type)
        {
            // Memory modules of the Data from the tags and read through it runs so Callback delegate.
            if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_DATA)
            {

                string strMsg = Msg.Split(',')[0].ToLower();
                string intRSSI = Msg.Split(',')[1].Split('=')[1];
                string strTag = txtDocNo.Text.ToLower();
                string strHex = strToHex("PX" + txtDocNo.Text + txtSegment3.Text);
                string strMsgSub = strMsg.Substring(4);
                if (strHex == strMsgSub)
                {
                    //lblStatus.Text = "Found";
                    this.label1.Text = Convert.ToString(Convert.ToInt32((((Convert.ToDouble(intRSSI) + (100)) * 100) / (60))));
                    this.label1.Refresh();
                    this.txtSegment3.Text = Convert.ToString(Convert.ToInt32((((Convert.ToDouble(intRSSI) + (100)) * 100) / (60))));
                    this.Refresh();
                    if (Convert.ToInt16(label1.Text) >= 80)
                    {
                        Play_Sound_NOSTOP(@"\Windows\Voicbeep.wav");
                    }
                    else
                    {
                        Play_Sound_NOSTOP(@"\Windows\Success.wav");
                    }
                    
                }
                else
                {
                    //lblStatus.Text = "0";
                    //lblStatus.Text = "Not Found";
                }


            }
            // Run from the command module to receive the results of running Callback delegate.
            else if (Type == RFID_CALLBACK_TYPE.RFIDCALLBACKTYPE_REPLY)
            {
                if (Msg.Equals("OK") || Msg.Equals("Multi Read Stop") || Msg.Equals(""))
                {
                    btnStatus = "Start";
                    //if (Msg.Equals("")){
                    //lblStatus.Text = "Not Found";
                    //}
                }
                else
                {
                    MessageBox.Show(Msg);
                    btnStatus = "Start";
                    label1.Text = "0";
                    txtSegment3.Text = "0";
                    //lblStatus.Text = "Not Found";
                }
            }
        }

        private void btnLocate_Click(object sender, EventArgs e)
        {
            RFID_READ_TYPE ReadType;
            
            if (btnStatus.Equals("Start"))
            {
                btnStatus = "Stop";
                cboDocType.SelectedIndex = 1;
          
                    ReadType = RFID_READ_TYPE.EPC_GEN2_MULTI_TAG;

                // RFID tag reads from the EPC data.
                rfid.ReadEpc(false, ReadType, String.Empty);

            }
            else
            {
                rfid.Stop();
            }
        }

        private void frmLocate_Closing(object sender, CancelEventArgs e)
        {
            rfid.Close();
            rfid.PowerOff();
        }

        private void frmLocate_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.WindowState = FormWindowState.Maximized;

            alKeys = new ArrayList();

            // Windows CE Fn Keys
            alKeys.Add(Convert.ToInt32(Keys.F7));   // "F7" key
            alKeys.Add(Convert.ToInt32(Keys.F8));   // "F8" key
            alKeys.Add(Convert.ToInt32(Keys.F9));   // "SCAN" key
            alKeys.Add(Convert.ToInt32(Keys.F19));  // Gun trigger

            // Windows Mobile Fn Keys
            alKeys.Add(Convert.ToInt32(0xEF));      // "F7" key
            alKeys.Add(Convert.ToInt32(0xF0));      // "F8" key
            alKeys.Add(Convert.ToInt32(0xD3));      // "SCAN" key
            alKeys.Add(Convert.ToInt32(0xD2));      // Gun trigger

            // windows ce
            if (Environment.OSVersion.Version.Minor != 2)
            {
                this.MaximizeBox = false;
                this.Menu = null;

                //tabControl1.Location = new Point(0, 0);
            }

            Tags = new ArrayList();

            rfid = new RfidApi();

            rfid.PowerOn();

            if (rfid.Open() == RFID_RESULT.RFID_RESULT_SUCCESS)
            {
                //===============================================================================
                //  RFID reader tag data read by the application at the end to register 
                // callback fuction is called.
                //rfid.PowerLevel = 3;
                rfid.EnableExtendedInformation(true);
                rfid.SetCallback(new RfidCallbackProc(CallbackProc));
            }
            else
            {
                //  RFID reader module to an authorized power is removed.
                rfid.PowerOff();
                MessageBox.Show("RFID Open Failed");

                this.Close();
            }

            timerStop = new Timer();
            timerStop.Interval = 10;
            timerStop.Tick += new EventHandler(timerStop_Tick);
        }

        void timerStop_Tick(object sender, EventArgs e)
        {
            timerStop.Enabled = false;
            btnLocate_Click(null, null);
        }

        // trigger KeyDown
        protected override void OnKeyDown(KeyEventArgs e)
        {
           
                if (alKeys.Contains(e.KeyValue))
                {
                    if (btnStatus.Equals("Start"))
                        btnLocate_Click(null, null);
                }
           
            base.OnKeyDown(e);
        }

        // trigger KeyUp
        protected override void OnKeyUp(KeyEventArgs e)
        {
            
                if (alKeys.Contains(e.KeyValue))
                {
                    if (btnStatus.Equals("Stop"))
                        btnLocate_Click(null, null);
                }
           
            base.OnKeyUp(e);
        }

        public static string strToHex(string app_no)
        {
            string txt = null;
            byte[] bytes = null;
            int i = 0;
            // Display the bytes.
            txt = app_no;
            bytes = System.Text.Encoding.ASCII.GetBytes(txt);
            txt = "";
          
            for (i = bytes.GetLowerBound(0); i <= bytes.GetUpperBound(0); i++)
            {
               // txt = txt + Strings.Format(Conversion.Hex(bytes[i]));
                txt = txt + Microsoft.VisualBasic.Conversion.Hex(bytes[i]);
                // concatenate &H here
            }
            return txt;
        }

    }
}