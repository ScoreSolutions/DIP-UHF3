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

    public partial class frmFloorUserSelect : Form
    {
        DataTable dtdepartment = new DataTable();
        DataRow drdepartment;
        DataTable dt = new DataTable();
        DataRow dr;
        private string _FloorSelect;
        public string FloorSelect
        {
            get
            {
                return this._FloorSelect;
            }
            set
            {
                this._FloorSelect = value;
            }
        }

        string strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

        public frmFloorUserSelect()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnSetting_Click(object sender, EventArgs e)
        {

        }

        private void frmFloorSelect_Load(object sender, EventArgs e)
        {


            cbDepartment.DataSource = getdepartment();
            cbDepartment.ValueMember = "id";
            cbDepartment.DisplayMember = "department_name";

            cbUser.DataSource = getuser();
            cbUser.ValueMember = "id";
            cbUser.DisplayMember = "fullname";

        }





        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cmb = (ComboBox)sender;
            int selectedIndex = cmb.SelectedIndex;

            //int selectedValue = (int)cmb.SelectedValue;

            //ComboboxItem selectedCar = (ComboboxItem)cmb.SelectedItem;
           // MessageBox.Show(String.Format("Index: [{0}] CarName={1}; Value={2}", selectedIndex, selectedCar.Text, selecteVal));     
                DataTable dtcopy = new DataTable();
                dtcopy = getuser();

                DataView dvcopy = new DataView();
                dvcopy = dtcopy.DefaultView;
                if (selectedIndex != 0)
                {
                 dvcopy.RowFilter = "department_id=" + cmb.SelectedValue;

                }
                else {
                    dvcopy.RowFilter = "";
                }
                cbUser.DataSource = dvcopy;
                cbUser.ValueMember = "id";
                cbUser.DisplayMember = "fullname";
           
        }

        private DataTable getdepartment()
        {

            dtdepartment.Columns.Add("id");
            dtdepartment.Columns.Add("department_name");
            if (File.Exists(@"\My Documents\departmentname.txt"))
            {
                StreamReader readerdepartment = new StreamReader(@"\My Documents\departmentname.txt", Encoding.GetEncoding("windows-874"));

                using (var sr = readerdepartment)
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string data = line;
                        string[] words = data.Split(',');
                        drdepartment = dtdepartment.NewRow();
                        drdepartment["id"] = words[0];
                        drdepartment["department_name"] = words[1];
                        dtdepartment.Rows.Add(drdepartment);
                    }



                }

            }

            return dtdepartment;

        }

        private DataTable getuser()
        {
            if (dt.Rows.Count > 0) {
                return dt;
            }
            dt.Columns.Add("id");
            dt.Columns.Add("fullname");
            dt.Columns.Add("department_id");
            dt.Columns.Add("department_name");
            if (File.Exists(@"\My Documents\officername.txt"))
            {
                StreamReader reader = new StreamReader(@"\My Documents\officername.txt", Encoding.GetEncoding("windows-874"));

                using (var sr = reader)
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string data = line;
                        string[] words = data.Split(',');
                        dr = dt.NewRow();
                        dr["id"] = words[0];
                        dr["fullname"] = words[1];
                        dr["department_id"] = words[2];
                        dr["department_name"] = words[3];
                        dt.Rows.Add(dr);
                    }


                }

            }

            return dt;

        }

        private void ckbIsOfficer_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbIsOfficer.Checked)
            {
                cbDepartment.Enabled = false;
                cbUser.Enabled = false;
            }
            else {
                cbDepartment.Enabled = true;
                cbUser.Enabled = true;
            }
         
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            frmFloorSelectCount frm = new frmFloorSelectCount();
            if (ckbIsOfficer.Checked)
            {
                frm.FloorSelect = _FloorSelect;
                frm.UserIdSelect = "0";
                frm.UserNameSelect = "";
            }
            else
            {
                frm.FloorSelect = _FloorSelect;
                frm.UserIdSelect = cbUser.SelectedValue + "";
                frm.UserNameSelect = cbUser.Text + "";
            }
            frm.Show();
            this.Close();
        }
    }
}