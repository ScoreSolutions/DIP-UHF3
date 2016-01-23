using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ini;
using System.IO;
using System.Reflection;

namespace DIP_Handheld
{
    public partial class frmMain : Form
    {
        string strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLocate_Click(object sender, EventArgs e)
        {
            frmLocateSearch frm = new frmLocateSearch();
            //frmLocateList frm = new frmLocateList();
            frm.Show();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            frmCheckOut_List frm = new frmCheckOut_List();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            frmCheckIn_Re frm = new frmCheckIn_Re();
            frm.Show();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            frmChange_Re frm = new frmChange_Re();
            frm.Show();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting();
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(strPath + "\\Setting.txt"))
                {
                    StreamReader sr = new StreamReader(strPath + "\\Setting.txt");
                    //IniFile ini = new IniFile(strPath + "\\Setting.ini");
                    string[] strData = sr.ReadToEnd().Split('|');
                    Setting.blnSound = Convert.ToBoolean(strData[0].Split('=')[1]);
                    Setting.intRssi = Convert.ToInt16(strData[1].Split('=')[1]);
                    sr.Close();

                    //sr.Dispose();
                }


                //Create FileLost DataTable
                //dtLost
                if (File.Exists(@"\My Documents\DIPFileLost.txt")) {
                    using (var sr = new StreamReader(@"\My Documents\DIPFileLost.txt"))
                    {
                        FunctionENG.dtLost = new DataTable();
                        FunctionENG.dtLost.Columns.Add("app_no");
                        FunctionENG.dtLost.Columns.Add("rowindex");

                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            DataRow drLost = FunctionENG.dtLost.NewRow();
                            drLost["app_no"] = line;
                            FunctionENG.dtLost.Rows.Add(drLost);
                        }
                    }

                    if (FunctionENG.dtLost.Rows.Count > 0)
                    {
                        if (File.Exists(@"\My Documents\DIPFileDiscover.txt") == true)
                        {
                            using (var fd = new StreamReader(@"\My Documents\DIPFileDiscover.txt"))
                            {
                                string line;
                                while ((line = fd.ReadLine()) != null)
                                {
                                    DataView dv = FunctionENG.dtLost.DefaultView;
                                    dv.RowFilter = "app_no='" + line + "'";
                                    if (dv.Count > 0)
                                    {
                                        for (int j = FunctionENG.dtLost.Rows.Count-1; j >= 0; j--)
                                        {
                                            if (FunctionENG.dtLost.Rows[j]["app_no"].ToString() == line)
                                            {
                                                FunctionENG.dtLost.Rows.RemoveAt(j);
                                                break;
                                            }
                                        }
                                    }
                                    dv.RowFilter = "";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnFloorUpdate_Click(object sender, EventArgs e)
        {
            frmFloorSelect frm = new frmFloorSelect();
            frm.Show();
        }

        private void btnMoveToFloor_Click(object sender, EventArgs e)
        {
            frmFloorMoveOut frm = new frmFloorMoveOut();
            frm.Show();
        }

        private void pbDeliver_Click(object sender, EventArgs e)
        {
            frmDeliver frm = new frmDeliver();
            frm.Show();
        }

        private void pbCurrentLocation_Click(object sender, EventArgs e)
        {
            frmCurrentLocation frm = new frmCurrentLocation();
            frm.Show();
        }

    }
}