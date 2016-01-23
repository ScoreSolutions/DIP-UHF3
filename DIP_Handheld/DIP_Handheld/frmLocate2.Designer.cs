namespace DIP_Handheld
{
    partial class frmLocate2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocate2));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnLocate = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtSegment3 = new System.Windows.Forms.TextBox();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(114)))), ((int)(((byte)(183)))));
            this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 77);
            this.label1.Text = "00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(71, 251);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 21);
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click_1);
            // 
            // btnLocate
            // 
            this.btnLocate.Image = ((System.Drawing.Image)(resources.GetObject("btnLocate.Image")));
            this.btnLocate.Location = new System.Drawing.Point(60, 215);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(122, 34);
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(60, 92);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(122, 122);
            // 
            // txtSegment3
            // 
            this.txtSegment3.Location = new System.Drawing.Point(165, 68);
            this.txtSegment3.Name = "txtSegment3";
            this.txtSegment3.Size = new System.Drawing.Size(54, 23);
            this.txtSegment3.TabIndex = 11;
            // 
            // txtDocNo
            // 
            this.txtDocNo.Location = new System.Drawing.Point(57, 68);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(104, 23);
            this.txtDocNo.TabIndex = 8;
            this.txtDocNo.Text = "3000000000000010817105090001";
            // 
            // cboDocType
            // 
            this.cboDocType.Items.Add("PX");
            this.cboDocType.Items.Add("PL");
            this.cboDocType.Items.Add("PH");
            this.cboDocType.Items.Add("PA");
            this.cboDocType.Items.Add("PM");
            this.cboDocType.Items.Add("PYH");
            this.cboDocType.Items.Add("PU");
            this.cboDocType.Items.Add("PMR");
            this.cboDocType.Items.Add("PT");
            this.cboDocType.Items.Add("PS");
            this.cboDocType.Items.Add("PSC");
            this.cboDocType.Items.Add("PDK");
            this.cboDocType.Items.Add("PCH");
            this.cboDocType.Items.Add("PTYK");
            this.cboDocType.Items.Add("PRP");
            this.cboDocType.Items.Add("PHGK");
            this.cboDocType.Location = new System.Drawing.Point(5, 68);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size(51, 23);
            this.cboDocType.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 320);
            // 
            // frmLocate2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnLocate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtSegment3);
            this.Controls.Add(this.txtDocNo);
            this.Controls.Add(this.cboDocType);
            this.Controls.Add(this.pictureBox1);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.Name = "frmLocate2";
            this.Text = "frmLocate2";
            this.Load += new System.EventHandler(this.frmLocate2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox btnLocate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtSegment3;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}