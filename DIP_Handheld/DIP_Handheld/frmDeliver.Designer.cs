namespace DIP_Handheld
{
    partial class frmDeliver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeliver));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bg = new System.Windows.Forms.PictureBox();
            this.pbMainMenu = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // bg
            // 
            this.bg.Image = ((System.Drawing.Image)(resources.GetObject("bg.Image")));
            this.bg.Location = new System.Drawing.Point(0, 0);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(240, 320);
            // 
            // pbMainMenu
            // 
            this.pbMainMenu.Image = ((System.Drawing.Image)(resources.GetObject("pbMainMenu.Image")));
            this.pbMainMenu.Location = new System.Drawing.Point(50, 275);
            this.pbMainMenu.Name = "pbMainMenu";
            this.pbMainMenu.Size = new System.Drawing.Size(130, 37);
            this.pbMainMenu.Click += new System.EventHandler(this.pbMainMenu_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 193);
            // 
            // frmDeliver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbMainMenu);
            this.Controls.Add(this.bg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeliver";
            this.Text = "Document Finder V.1.0.0.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDeliver_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.PictureBox pbMainMenu;
        private System.Windows.Forms.Panel panel1;
    }
}

