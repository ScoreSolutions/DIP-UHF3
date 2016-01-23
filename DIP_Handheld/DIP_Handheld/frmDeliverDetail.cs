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
using System.Text.RegularExpressions;


namespace DIP_Handheld
{
    public partial class frmDeliverDetail : Form
    {
        //string strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        public string FileBorrowCode {
            set { 
                lblFileBorrowCode.Text = value;

                Bitmap bm = new Bitmap(@"\My Documents\FileBorrowerName\" + lblFileBorrowCode.Text + ".jpg");
                pbBorrowName.Image = bm;
            }
        }
        public string FileBorrowDate {
            set { lblBorrowDate.Text = "วันที่ยืม : " + value; }
        }
        public string TagList {
            set {
                //Load data to Datatable
                DataTable dt = new DataTable();
                dt.Columns.Add("tag_no");
                dt.Columns.Add("location_name");

                foreach (string tagInf in Regex.Split(value, "##"))
                {
                    string[] tag = Regex.Split(tagInf, ",",RegexOptions.CultureInvariant);
                    if (tag.Length == 2)
                    {
                        DataRow dr = dt.NewRow();
                        dr["tag_no"] = tag[0];
                        dr["location_name"] = tag[1];
                        dt.Rows.Add(dr);
                    }
                }
                dt.TableName = "TagList";

                dgView.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = dt.TableName;
                
                //Column Tag No
                DataGridTextBoxColumn tbcName = new DataGridTextBoxColumn();
                tbcName.Width = 100;
                tbcName.MappingName = "tag_no";
                tbcName.HeaderText = "หมายเลขแฟ้ม";
                tableStyle.GridColumnStyles.Add(tbcName);

                tbcName = new DataGridTextBoxColumn();
                tbcName.Width = 150;
                tbcName.MappingName = "location_name";
                tbcName.HeaderText = "สถานที่พบ";
                tableStyle.GridColumnStyles.Add(tbcName);

                dgView.TableStyles.Add(tableStyle);

                dgView.DataSource = dt;

                lblFileQty.Text = "จำนวนแฟ้ม : " + dt.Rows.Count + " แฟ้ม"; 
            }
        }

        DataTable DataListDt = new DataTable();
        int btnPoint = 0;

        public frmDeliverDetail()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            frmDeliverConfirm frm = new frmDeliverConfirm();
            frm.FileBorrowCode = lblFileBorrowCode.Text;
            if (frm.ShowDialog() == DialogResult.OK) {
                this.Close();
            }
        }

        
    }
}