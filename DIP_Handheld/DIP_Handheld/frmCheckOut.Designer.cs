namespace DIP_Handheld
{
    partial class frmCheckOut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckOut));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAct = new System.Windows.Forms.Label();
            this.btnMainmenu = new System.Windows.Forms.PictureBox();
            this.btnScan = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(114)))), ((int)(((byte)(183)))));
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblAct);
            this.panel1.Location = new System.Drawing.Point(59, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 91);
            this.panel1.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Regular);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(71, 22);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(58, 59);
            this.lblTotal.Text = "0";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(52, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 59);
            this.label2.Text = "/";
            // 
            // lblAct
            // 
            this.lblAct.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Regular);
            this.lblAct.ForeColor = System.Drawing.Color.White;
            this.lblAct.Location = new System.Drawing.Point(-10, 22);
            this.lblAct.Name = "lblAct";
            this.lblAct.Size = new System.Drawing.Size(62, 59);
            this.lblAct.Text = "0";
            this.lblAct.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnMainmenu
            // 
            this.btnMainmenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMainmenu.Image")));
            this.btnMainmenu.Location = new System.Drawing.Point(71, 244);
            this.btnMainmenu.Name = "btnMainmenu";
            this.btnMainmenu.Size = new System.Drawing.Size(100, 21);
            this.btnMainmenu.Click += new System.EventHandler(this.btnMainmenu_Click);
            // 
            // btnScan
            // 
            this.btnScan.Image = ((System.Drawing.Image)(resources.GetObject("btnScan.Image")));
            this.btnScan.Location = new System.Drawing.Point(59, 204);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(122, 34);
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 320);
            // 
            // frmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMainmenu);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCheckOut";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCheckOut_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmCheckOut_Closing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnScan;
        private System.Windows.Forms.PictureBox btnMainmenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAct;
    }
}
