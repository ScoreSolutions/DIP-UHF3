namespace DIP_Handheld
{
    partial class frmDeliverConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeliverConfirm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bg = new System.Windows.Forms.PictureBox();
            this.pbSign = new System.Windows.Forms.PictureBox();
            this.lblBorrowCode = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // bg
            // 
            this.bg.Image = ((System.Drawing.Image)(resources.GetObject("bg.Image")));
            this.bg.Location = new System.Drawing.Point(0, 0);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(240, 320);
            // 
            // pbSign
            // 
            this.pbSign.Location = new System.Drawing.Point(1, 75);
            this.pbSign.Name = "pbSign";
            this.pbSign.Size = new System.Drawing.Size(237, 203);
            this.pbSign.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbSign_MouseMove);
            this.pbSign.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbSign_MouseDown);
            this.pbSign.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbSign_MouseUp);
            // 
            // lblBorrowCode
            // 
            this.lblBorrowCode.Location = new System.Drawing.Point(3, 31);
            this.lblBorrowCode.Name = "lblBorrowCode";
            this.lblBorrowCode.Size = new System.Drawing.Size(100, 20);
            this.lblBorrowCode.Text = "label1";
            this.lblBorrowCode.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(82, 280);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 36);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(201, 279);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 40);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // frmDeliverConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblBorrowCode);
            this.Controls.Add(this.pbSign);
            this.Controls.Add(this.bg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeliverConfirm";
            this.Text = "Document Finder V.1.0.0.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.PictureBox pbSign;
        private System.Windows.Forms.Label lblBorrowCode;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox btnExit;
    }
}

