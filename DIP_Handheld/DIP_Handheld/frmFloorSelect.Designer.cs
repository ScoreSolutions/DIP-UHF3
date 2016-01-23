namespace DIP_Handheld
{
    partial class frmFloorSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFloorSelect));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnMainMenu = new System.Windows.Forms.PictureBox();
            this.btnChange = new System.Windows.Forms.PictureBox();
            this.btnCheckOut = new System.Windows.Forms.PictureBox();
            this.btnCheckIn = new System.Windows.Forms.PictureBox();
            this.bg = new System.Windows.Forms.PictureBox();
            this.btnFloor12 = new System.Windows.Forms.PictureBox();
            this.btnFloor10 = new System.Windows.Forms.PictureBox();
            this.btnFloor9 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMainMenu.Image")));
            this.btnMainMenu.Location = new System.Drawing.Point(49, 273);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(130, 37);
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnChange
            // 
            this.btnChange.Image = ((System.Drawing.Image)(resources.GetObject("btnChange.Image")));
            this.btnChange.Location = new System.Drawing.Point(150, 102);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(60, 60);
            this.btnChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckOut.Image")));
            this.btnCheckOut.Location = new System.Drawing.Point(84, 102);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(60, 60);
            this.btnCheckOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckIn.Image")));
            this.btnCheckIn.Location = new System.Drawing.Point(18, 102);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(60, 60);
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
            // btnFloor12
            // 
            this.btnFloor12.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor12.Image")));
            this.btnFloor12.Location = new System.Drawing.Point(150, 181);
            this.btnFloor12.Name = "btnFloor12";
            this.btnFloor12.Size = new System.Drawing.Size(60, 60);
            this.btnFloor12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFloor12.Click += new System.EventHandler(this.btnFloor12_Click);
            // 
            // btnFloor10
            // 
            this.btnFloor10.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor10.Image")));
            this.btnFloor10.Location = new System.Drawing.Point(84, 181);
            this.btnFloor10.Name = "btnFloor10";
            this.btnFloor10.Size = new System.Drawing.Size(60, 60);
            this.btnFloor10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFloor10.Click += new System.EventHandler(this.btnFloor10_Click);
            // 
            // btnFloor9
            // 
            this.btnFloor9.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor9.Image")));
            this.btnFloor9.Location = new System.Drawing.Point(18, 181);
            this.btnFloor9.Name = "btnFloor9";
            this.btnFloor9.Size = new System.Drawing.Size(60, 60);
            this.btnFloor9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFloor9.Click += new System.EventHandler(this.btnFloor9_Click);
            // 
            // frmFloorSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.btnFloor12);
            this.Controls.Add(this.btnFloor10);
            this.Controls.Add(this.btnFloor9);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.bg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFloorSelect";
            this.Text = "Document Finder V.1.0.0.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFloorSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.PictureBox btnCheckIn;
        private System.Windows.Forms.PictureBox btnCheckOut;
        private System.Windows.Forms.PictureBox btnChange;
        private System.Windows.Forms.PictureBox btnMainMenu;
        private System.Windows.Forms.PictureBox btnFloor12;
        private System.Windows.Forms.PictureBox btnFloor10;
        private System.Windows.Forms.PictureBox btnFloor9;
    }
}

