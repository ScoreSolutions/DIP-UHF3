namespace DIP_Handheld
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnMoveToFloor = new System.Windows.Forms.PictureBox();
            this.btnFloorUpdate = new System.Windows.Forms.PictureBox();
            this.btnChange = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.btnSetting = new System.Windows.Forms.PictureBox();
            this.btnLocate = new System.Windows.Forms.PictureBox();
            this.btnCheckOut = new System.Windows.Forms.PictureBox();
            this.btnCheckIn = new System.Windows.Forms.PictureBox();
            this.bg = new System.Windows.Forms.PictureBox();
            this.pbDeliver = new System.Windows.Forms.PictureBox();
            this.pbCurrentLocation = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // btnMoveToFloor
            // 
            this.btnMoveToFloor.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveToFloor.Image")));
            this.btnMoveToFloor.Location = new System.Drawing.Point(158, 164);
            this.btnMoveToFloor.Name = "btnMoveToFloor";
            this.btnMoveToFloor.Size = new System.Drawing.Size(64, 64);
            this.btnMoveToFloor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMoveToFloor.Click += new System.EventHandler(this.btnMoveToFloor_Click);
            // 
            // btnFloorUpdate
            // 
            this.btnFloorUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnFloorUpdate.Image")));
            this.btnFloorUpdate.Location = new System.Drawing.Point(88, 164);
            this.btnFloorUpdate.Name = "btnFloorUpdate";
            this.btnFloorUpdate.Size = new System.Drawing.Size(64, 64);
            this.btnFloorUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFloorUpdate.Click += new System.EventHandler(this.btnFloorUpdate_Click);
            // 
            // btnChange
            // 
            this.btnChange.Image = ((System.Drawing.Image)(resources.GetObject("btnChange.Image")));
            this.btnChange.Location = new System.Drawing.Point(18, 164);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(64, 64);
            this.btnChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(184, 278);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 38);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Image = ((System.Drawing.Image)(resources.GetObject("btnSetting.Image")));
            this.btnSetting.Location = new System.Drawing.Point(184, 234);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(38, 38);
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnLocate
            // 
            this.btnLocate.Image = ((System.Drawing.Image)(resources.GetObject("btnLocate.Image")));
            this.btnLocate.Location = new System.Drawing.Point(158, 94);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(64, 64);
            this.btnLocate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckOut.Image")));
            this.btnCheckOut.Location = new System.Drawing.Point(88, 94);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(64, 64);
            this.btnCheckOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckIn.Image")));
            this.btnCheckIn.Location = new System.Drawing.Point(18, 94);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(64, 64);
            this.btnCheckIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCheckIn.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // bg
            // 
            this.bg.Image = ((System.Drawing.Image)(resources.GetObject("bg.Image")));
            this.bg.Location = new System.Drawing.Point(0, 0);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(240, 320);
            // 
            // pbDeliver
            // 
            this.pbDeliver.Image = ((System.Drawing.Image)(resources.GetObject("pbDeliver.Image")));
            this.pbDeliver.Location = new System.Drawing.Point(18, 234);
            this.pbDeliver.Name = "pbDeliver";
            this.pbDeliver.Size = new System.Drawing.Size(64, 64);
            this.pbDeliver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeliver.Click += new System.EventHandler(this.pbDeliver_Click);
            // 
            // pbCurrentLocation
            // 
            this.pbCurrentLocation.Image = ((System.Drawing.Image)(resources.GetObject("pbCurrentLocation.Image")));
            this.pbCurrentLocation.Location = new System.Drawing.Point(88, 234);
            this.pbCurrentLocation.Name = "pbCurrentLocation";
            this.pbCurrentLocation.Size = new System.Drawing.Size(64, 64);
            this.pbCurrentLocation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurrentLocation.Click += new System.EventHandler(this.pbCurrentLocation_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.pbCurrentLocation);
            this.Controls.Add(this.pbDeliver);
            this.Controls.Add(this.btnMoveToFloor);
            this.Controls.Add(this.btnFloorUpdate);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnLocate);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.bg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Document Finder V.1.0.0.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.PictureBox btnCheckIn;
        private System.Windows.Forms.PictureBox btnCheckOut;
        private System.Windows.Forms.PictureBox btnLocate;
        private System.Windows.Forms.PictureBox btnSetting;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.PictureBox btnChange;
        private System.Windows.Forms.PictureBox btnFloorUpdate;
        private System.Windows.Forms.PictureBox btnMoveToFloor;
        private System.Windows.Forms.PictureBox pbDeliver;
        private System.Windows.Forms.PictureBox pbCurrentLocation;
    }
}

