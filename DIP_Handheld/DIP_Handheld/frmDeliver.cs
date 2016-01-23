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
    public partial class frmDeliver : Form
    {
        //string strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

        DataTable DataListDt = new DataTable();
        int btnPoint = 0;

        public frmDeliver()
        {
            InitializeComponent();
        }

        private void pbMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void AddDataRow(string BorrowCode, string BorrowernamePath, string TagList, string BorrowDate)
        {
            //Create Display Label
            Font fnt = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

            Label btnP = new Label();
            btnP.Width = 80;
            btnP.Height = 20;
            btnP.Name = "lblP_" + BorrowCode;
            btnP.Text = BorrowCode;
            btnP.Font = fnt;
            btnP.BackColor = Color.White;
            btnP.Top = btnPoint;
            //btnP.Left = btnTag.Width;
            btnP.TextAlign = ContentAlignment.TopCenter;
            panel1.Controls.Add(btnP);


            PictureBox pbName = new PictureBox();
            pbName.Width = 150;
            pbName.Height = 20;
            pbName.Name = "pb_" + BorrowCode;
            pbName.Tag = BorrowCode;
            //btnTag.Text = TagNo;

            Bitmap bm = new Bitmap(BorrowernamePath);
            pbName.Image = bm;
            pbName.Enabled = true;
            pbName.Top = btnPoint;
            pbName.Left = btnP.Width;
            pbName.Click += new EventHandler(imgBorrowerName_Click);

            panel1.Controls.Add(pbName);

            //เอาไว้เก็บข้อมูล Tag ที่มีในใบเบิก
            Label tl = new Label();
            tl.Name = "lblTl_" + BorrowCode;
            tl.Text = TagList;
            tl.Visible = false;
            panel1.Controls.Add(tl);

            Label bd = new Label();
            bd.Name = "lblBd_" + BorrowCode;
            bd.Text = BorrowDate;
            bd.Visible = false;
            panel1.Controls.Add(bd);

            btnPoint += pbName.Height + 1;
        }

        private void imgBorrowerName_Click(Object sender, EventArgs e)
        {
            string TagList = "";
            string BorrowerDate = "";
            PictureBox pb = (PictureBox)sender;
            foreach (Control ctl in panel1.Controls) {
                if (ctl is Label)
                {
                    if (ctl.Name.Replace("lblTl_", "") == pb.Name.Replace("pb_", ""))
                    {
                        TagList = ctl.Text;
                    }
                    if (ctl.Name.Replace("lblBd_", "") == pb.Name.Replace("pb_", "")) {
                        BorrowerDate = ctl.Text;
                    }
                }
            }
            //MessageBox.Show(pb.Name + " $$$ " + pb.Tag);
            frmDeliverDetail frm = new frmDeliverDetail();
            frm.FileBorrowCode = pb.Tag.ToString();
            frm.FileBorrowDate = BorrowerDate;
            frm.TagList = TagList;
            frm.ShowDialog();
            
            LoadDataList();
        }

        private void LoadDataList() {
            try
            {
                if (File.Exists(@"\My Documents\FileBorrowList.txt"))
                {
                    using (var sr = new StreamReader(@"\My Documents\FileBorrowList.txt"))
                    {
                        //Add Data From Textfile to Datable
                        DataListDt = new DataTable();
                        DataListDt.Columns.Add("RowIndex");
                        DataListDt.Columns.Add("fileborrow_code");
                        DataListDt.Columns.Add("fileborrow_date");
                        DataListDt.Columns.Add("tag_list");

                        string line;
                        int DataRowIndex = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] data = line.Split('|');
                            DataRow Dr = DataListDt.NewRow();
                            Dr["RowIndex"] = DataRowIndex;
                            Dr["fileborrow_code"] = data[0];
                            Dr["fileborrow_date"] = data[1];
                            Dr["tag_list"] = data[2];
                            DataListDt.Rows.Add(Dr);

                            DataRowIndex += 1;
                        }

                        //Compare Datatable with FileBorrowDeliveList
                        if (File.Exists(@"\My Documents\FileBorrowDeliverList.txt") == true)
                        {
                            using (var fdr = new StreamReader(@"\My Documents\FileBorrowDeliverList.txt"))
                            {
                                while ((line = fdr.ReadLine()) != null)
                                {
                                    string[] tmp = line.Split('|');
                                    if (tmp.Length == 2)
                                    {
                                        DataListDt.DefaultView.RowFilter = "fileborrow_code='" + tmp[0] + "'";
                                        if (DataListDt.DefaultView.Count > 0)
                                        {
                                            DataListDt.Rows.RemoveAt(Convert.ToInt32(DataListDt.DefaultView[0]["RowIndex"]));
                                        }
                                        DataListDt.DefaultView.RowFilter = "";
                                    }
                                }
                            }
                        }

                        panel1.Controls.Clear();
                        if (DataListDt.Rows.Count > 0)
                        {
                            btnPoint = 0;
                            foreach (DataRow dr in DataListDt.Rows)
                            {
                                AddDataRow(dr["fileborrow_code"].ToString(), @"\My Documents\FileBorrowerName\" + dr["fileborrow_code"].ToString() + ".jpg", dr["tag_list"].ToString(), dr["fileborrow_date"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void frmDeliver_Load(object sender, EventArgs e)
        {
            LoadDataList();
        }
    }
}