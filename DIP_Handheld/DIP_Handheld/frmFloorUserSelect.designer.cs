namespace DIP_Handheld
{
    partial class frmFloorUserSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFloorUserSelect));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bg = new System.Windows.Forms.PictureBox();
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbIsOfficer = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bg
            // 
            this.bg.Image = ((System.Drawing.Image)(resources.GetObject("bg.Image")));
            this.bg.Location = new System.Drawing.Point(0, 0);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(240, 320);
            // 
            // cbUser
            // 
            this.cbUser.Location = new System.Drawing.Point(18, 185);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(200, 23);
            this.cbUser.TabIndex = 8;
            // 
            // cbDepartment
            // 
            this.cbDepartment.Location = new System.Drawing.Point(18, 133);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(200, 23);
            this.cbDepartment.TabIndex = 11;
            this.cbDepartment.SelectedIndexChanged += new System.EventHandler(this.cbDepartment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(18, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Department";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(18, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Officer";
            // 
            // ckbIsOfficer
            // 
            this.ckbIsOfficer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ckbIsOfficer.Location = new System.Drawing.Point(125, 107);
            this.ckbIsOfficer.Name = "ckbIsOfficer";
            this.ckbIsOfficer.Size = new System.Drawing.Size(93, 20);
            this.ckbIsOfficer.TabIndex = 15;
            this.ckbIsOfficer.Text = "Skip";
            this.ckbIsOfficer.CheckStateChanged += new System.EventHandler(this.ckbIsOfficer_CheckStateChanged);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Green;
            this.btnNext.Location = new System.Drawing.Point(64, 258);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(113, 31);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // frmFloorUserSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.ckbIsOfficer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.cbUser);
            this.Controls.Add(this.bg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFloorUserSelect";
            this.Text = "Document Finder V.1.0.0.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFloorSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckbIsOfficer;
        private System.Windows.Forms.Button btnNext;
    }
}

