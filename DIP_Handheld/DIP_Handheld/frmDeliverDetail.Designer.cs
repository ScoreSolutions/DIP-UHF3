namespace DIP_Handheld
{
    partial class frmDeliverDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeliverDetail));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.bg = new System.Windows.Forms.PictureBox();
            this.dgView = new System.Windows.Forms.DataGrid();
            this.lblBorrowDate = new System.Windows.Forms.Label();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblFileBorrowCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbBorrowName = new System.Windows.Forms.PictureBox();
            this.lblFileQty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bg
            // 
            this.bg.Image = ((System.Drawing.Image)(resources.GetObject("bg.Image")));
            this.bg.Location = new System.Drawing.Point(0, 0);
            this.bg.Name = "bg";
            this.bg.Size = new System.Drawing.Size(240, 320);
            // 
            // dgView
            // 
            this.dgView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgView.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.dgView.Location = new System.Drawing.Point(3, 141);
            this.dgView.Name = "dgView";
            this.dgView.Size = new System.Drawing.Size(234, 138);
            this.dgView.TabIndex = 1;
            // 
            // lblBorrowDate
            // 
            this.lblBorrowDate.BackColor = System.Drawing.Color.Silver;
            this.lblBorrowDate.Location = new System.Drawing.Point(3, 96);
            this.lblBorrowDate.Name = "lblBorrowDate";
            this.lblBorrowDate.Size = new System.Drawing.Size(234, 20);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(165, 281);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(72, 35);
            this.btnSign.TabIndex = 5;
            this.btnSign.Text = "Sign";
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 281);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 35);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "<Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblFileBorrowCode
            // 
            this.lblFileBorrowCode.Location = new System.Drawing.Point(98, 323);
            this.lblFileBorrowCode.Name = "lblFileBorrowCode";
            this.lblFileBorrowCode.Size = new System.Drawing.Size(100, 20);
            this.lblFileBorrowCode.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.Text = "ª×èÍ¼ÙéÂ×Á :";
            // 
            // pbBorrowName
            // 
            this.pbBorrowName.Location = new System.Drawing.Point(63, 74);
            this.pbBorrowName.Name = "pbBorrowName";
            this.pbBorrowName.Size = new System.Drawing.Size(174, 20);
            // 
            // lblFileQty
            // 
            this.lblFileQty.BackColor = System.Drawing.Color.Silver;
            this.lblFileQty.Location = new System.Drawing.Point(3, 118);
            this.lblFileQty.Name = "lblFileQty";
            this.lblFileQty.Size = new System.Drawing.Size(234, 20);
            // 
            // frmDeliverDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.ControlBox = false;
            this.Controls.Add(this.lblFileQty);
            this.Controls.Add(this.pbBorrowName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFileBorrowCode);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.dgView);
            this.Controls.Add(this.bg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeliverDetail";
            this.Text = "Document Finder V.1.0.0.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bg;
        private System.Windows.Forms.DataGrid dgView;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblFileBorrowCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbBorrowName;
        private System.Windows.Forms.Label lblFileQty;
    }
}

