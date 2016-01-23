namespace DIP_Handheld
{
    partial class frmFloorSelectCount
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFloorSelectCount));
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGrid();
            this.lblAct = new System.Windows.Forms.Label();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.colAppNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(57, 278);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(130, 37);
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click_1);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(60, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 34);
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 320);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(114)))), ((int)(((byte)(183)))));
            this.panel1.Controls.Add(this.dgView);
            this.panel1.Location = new System.Drawing.Point(8, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 124);
            this.panel1.Visible = false;
            // 
            // dgView
            // 
            this.dgView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgView.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.dgView.Location = new System.Drawing.Point(2, 2);
            this.dgView.Name = "dgView";
            this.dgView.Size = new System.Drawing.Size(221, 119);
            this.dgView.TabIndex = 1;
            this.dgView.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // lblAct
            // 
            this.lblAct.BackColor = System.Drawing.Color.LightCoral;
            this.lblAct.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.lblAct.ForeColor = System.Drawing.Color.White;
            this.lblAct.Location = new System.Drawing.Point(60, 197);
            this.lblAct.Name = "lblAct";
            this.lblAct.Size = new System.Drawing.Size(122, 33);
            this.lblAct.Text = "0";
            this.lblAct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colAppNo);
            // 
            // colAppNo
            // 
            this.colAppNo.Format = "";
            this.colAppNo.FormatInfo = null;
            this.colAppNo.HeaderText = "หมายเลขแฟ้ม";
            this.colAppNo.MappingName = "app_no";
            this.colAppNo.NullText = "";
            this.colAppNo.Width = 150;
            // 
            // frmFloorSelectCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.lblAct);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFloorSelectCount";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAct;
        private System.Windows.Forms.DataGrid dgView;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn colAppNo;

    }
}

