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
    public partial class frmDeliverConfirm : Form
    {
        //string strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

        public string FileBorrowCode {
            set { lblBorrowCode.Text = value; }
        }
        public frmDeliverConfirm()
        {
            InitializeComponent();
        }

        private System.Nullable<Point> _Previous = null;

        private void pbSign_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Previous != null) {
                if (pbSign.Image == null) {
                    Bitmap bmp = new Bitmap(pbSign.Width, pbSign.Height);
                    using (Graphics g = Graphics.FromImage(bmp)) {
                        g.Clear(Color.White);
                    }
                    pbSign.Image = bmp;
                }

                using (Graphics g = Graphics.FromImage(pbSign.Image)) {
                    Pen p = new Pen(Color.Black, 1);
                    g.DrawLine(p, _Previous.Value.X,_Previous.Value.Y, e.X, e.Y);
                }
                pbSign.Invalidate();
                _Previous = new Point(e.X, e.Y);
            }
        }

        private void pbSign_MouseDown(object sender, MouseEventArgs e)
        {
            _Previous = new Point(e.X,e.Y);
            pbSign_MouseMove(sender, e);
        }

        private void pbSign_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try {
                StreamWriter stw = new StreamWriter(@"\My Documents\FileBorrowDeliverList.txt",true);
                stw.WriteLine(lblBorrowCode.Text + "|" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss",new System.Globalization.CultureInfo("en-US")));
                stw.Close();
                stw.Dispose();

                string signFolder = @"\My Documents\FileBorrowDeliverSign\";
                if (Directory.Exists(signFolder) == false)
                {
                    Directory.CreateDirectory(signFolder);
                }

                if (File.Exists(signFolder + lblBorrowCode.Text + ".jpg") == true) {
                    try {
                        File.Delete(signFolder + lblBorrowCode.Text + ".jpg");
                    }
                    catch { }
                }

                pbSign.Image.Save(signFolder + lblBorrowCode.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}