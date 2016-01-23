namespace DIP_Handheld
{
    partial class frmChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChange));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnScan = new System.Windows.Forms.PictureBox();
            this.btnMainmenu = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAct = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 320);
            // 
            // btnScan
            // 
            this.btnScan.Image = ((System.Drawing.Image)(resources.GetObject("btnScan.Image")));
            this.btnScan.Location = new System.Drawing.Point(60, 204);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(122, 34);
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnMainmenu
            // 
            this.btnMainmenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMainmenu.Image")));
            this.btnMainmenu.Location = new System.Drawing.Point(71, 244);
            this.btnMainmenu.Name = "btnMainmenu";
            this.btnMainmenu.Size = new System.Drawing.Size(100, 21);
            this.btnMainmenu.Click += new System.EventHandler(this.btnMainmenu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(114)))), ((int)(((byte)(183)))));
            this.panel1.Controls.Add(this.lblAct);
            this.panel1.Location = new System.Drawing.Point(60, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 91);
            this.panel1.Visible = false;
            // 
            // lblAct
            // 
            this.lblAct.Font = new System.Drawing.Font("Tahoma", 40F, System.Drawing.FontStyle.Regular);
            this.lblAct.ForeColor = System.Drawing.Color.White;
            this.lblAct.Location = new System.Drawing.Point(15, 9);
            this.lblAct.Name = "lblAct";
            this.lblAct.Size = new System.Drawing.Size(97, 71);
            this.lblAct.Text = "0";
            this.lblAct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmChange
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
            this.Name = "frmChange";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChange_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmChange_Closing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnScan;
        private System.Windows.Forms.PictureBox btnMainmenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAct;
    }
}
