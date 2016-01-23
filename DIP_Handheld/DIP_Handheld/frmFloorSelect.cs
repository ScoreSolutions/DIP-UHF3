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
    public partial class frmFloorSelect : Form
    {
        string strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

        public frmFloorSelect()
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
            frmFloorUserSelect frm = new frmFloorUserSelect();
            frm.FloorSelect = "3";
            frm.Show();
            this.Close();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmFloorUserSelect frm = new frmFloorUserSelect();
            frm.FloorSelect = "2";
            frm.Show();
            this.Close();

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            frmFloorUserSelect frm = new frmFloorUserSelect();
            frm.FloorSelect = "1";
            frm.Show();
            this.Close();

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
         
        }

        private void frmFloorSelect_Load(object sender, EventArgs e)
        {
            
        }

        private void btnFloorUpdate_Click(object sender, EventArgs e)
        {
 
        }



        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFloor9_Click(object sender, EventArgs e)
        {
            frmFloorUserSelect frm = new frmFloorUserSelect();
            frm.FloorSelect = "4";
            frm.Show();
            this.Close();
        }

        private void btnFloor10_Click(object sender, EventArgs e)
        {
            frmFloorUserSelect frm = new frmFloorUserSelect();
            frm.FloorSelect = "6";
            frm.Show();
            this.Close();
        }

        private void btnFloor12_Click(object sender, EventArgs e)
        {
            frmFloorUserSelect frm = new frmFloorUserSelect();
            frm.FloorSelect = "7";
            frm.Show();
            this.Close();
        }
    }
}