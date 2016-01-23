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
using Ini;
using System.IO;
using System.Reflection;

namespace DIP_Handheld
{
    public partial class frmSetting : Form
    {

        string strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

        public frmSetting()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (File.Exists(strPath + "\\Setting.txt"))
            {

                pictureBox2.Enabled = false;
                StreamWriter sw = new StreamWriter(strPath + "\\Setting.txt");
                //IniFile ini = new IniFile(strPath + "\\Setting.ini");

                sw.Write("Sound=" + checkBox1.Checked.ToString() + '|' + "RSSI=" + txtRSSI.Text + "|POWER=" + numPower.Value.ToString());
                sw.Close();
                //sw.Dispose();
                Setting.blnSound = checkBox1.Checked;
                Setting.intRssi = Convert.ToInt16(txtRSSI.Text);
                Setting.Power = Convert.ToInt16(numPower.Value);
            }
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(null, null);
            this.Close();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            pictureBox1.SendToBack();
            if (File.Exists(strPath + "\\Setting.txt"))
            {

                pictureBox2.Enabled = false;
                StreamReader sr = new StreamReader(strPath + "\\Setting.txt");
                //IniFile ini = new IniFile(strPath + "\\Setting.ini");
                string[] strData = sr.ReadToEnd().Split('|');
                Setting.blnSound = Convert.ToBoolean(strData[0].Split('=')[1]);
                Setting.intRssi = Convert.ToInt16(strData[1].Split('=')[1]);
                sr.Close();
                //sw.Dispose();
                checkBox1.Checked=Setting.blnSound ;
                txtRSSI.Text= Convert.ToString(Setting.intRssi) ;
            }
        }
    }
}