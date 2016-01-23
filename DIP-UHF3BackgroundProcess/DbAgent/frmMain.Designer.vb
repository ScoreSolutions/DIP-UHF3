<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Splitter = New System.Windows.Forms.Splitter
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.btnDBA = New System.Windows.Forms.ToolStripButton
        Me.btnMainDisplay = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnSideBySide = New System.Windows.Forms.ToolStripButton
        Me.btnStacked = New System.Windows.Forms.ToolStripButton
        Me.btnCascade = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.btnQuit = New System.Windows.Forms.ToolStripButton
        Me.tabDB = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnTest1 = New System.Windows.Forms.Button
        Me.txtPassword1 = New System.Windows.Forms.TextBox
        Me.txtUsername1 = New System.Windows.Forms.TextBox
        Me.txtDatabase1 = New System.Windows.Forms.TextBox
        Me.txtserver1 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtserver2 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDatabase2 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtUsername2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPassword2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnTest2 = New System.Windows.Forms.Button
        Me.Tabs = New System.Windows.Forms.TabControl
        Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.tabDB.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Tabs.SuspendLayout()
        Me.SuspendLayout()
        '
        'Splitter
        '
        Me.Splitter.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter.Location = New System.Drawing.Point(0, 212)
        Me.Splitter.Name = "Splitter"
        Me.Splitter.Size = New System.Drawing.Size(807, 18)
        Me.Splitter.TabIndex = 1
        Me.Splitter.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDBA, Me.btnMainDisplay, Me.ToolStripSeparator1, Me.btnSideBySide, Me.btnStacked, Me.btnCascade, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.btnQuit})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(807, 31)
        Me.ToolStrip1.TabIndex = 2
        '
        'btnDBA
        '
        Me.btnDBA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDBA.Image = CType(resources.GetObject("btnDBA.Image"), System.Drawing.Image)
        Me.btnDBA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDBA.Name = "btnDBA"
        Me.btnDBA.Size = New System.Drawing.Size(28, 28)
        Me.btnDBA.ToolTipText = "Open Medtrak Agent"
        '
        'btnMainDisplay
        '
        Me.btnMainDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMainDisplay.Image = CType(resources.GetObject("btnMainDisplay.Image"), System.Drawing.Image)
        Me.btnMainDisplay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMainDisplay.Name = "btnMainDisplay"
        Me.btnMainDisplay.Size = New System.Drawing.Size(28, 28)
        Me.btnMainDisplay.ToolTipText = "Open Unit Display Agent"
        Me.btnMainDisplay.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnSideBySide
        '
        Me.btnSideBySide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSideBySide.Image = CType(resources.GetObject("btnSideBySide.Image"), System.Drawing.Image)
        Me.btnSideBySide.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSideBySide.Name = "btnSideBySide"
        Me.btnSideBySide.Size = New System.Drawing.Size(28, 28)
        Me.btnSideBySide.Text = "Show Windows Side by Side"
        '
        'btnStacked
        '
        Me.btnStacked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStacked.Image = CType(resources.GetObject("btnStacked.Image"), System.Drawing.Image)
        Me.btnStacked.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStacked.Name = "btnStacked"
        Me.btnStacked.Size = New System.Drawing.Size(28, 28)
        Me.btnStacked.Text = "Show Windows Stacked"
        '
        'btnCascade
        '
        Me.btnCascade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCascade.Image = CType(resources.GetObject("btnCascade.Image"), System.Drawing.Image)
        Me.btnCascade.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCascade.Name = "btnCascade"
        Me.btnCascade.Size = New System.Drawing.Size(28, 28)
        Me.btnCascade.Text = "Cascade Windows"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Margin = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton1.Text = "About"
        '
        'btnQuit
        '
        Me.btnQuit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnQuit.Image = CType(resources.GetObject("btnQuit.Image"), System.Drawing.Image)
        Me.btnQuit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(28, 28)
        Me.btnQuit.Text = "ToolStripButton9"
        Me.btnQuit.ToolTipText = "Quit Queue Sharp™ Extension Server"
        '
        'tabDB
        '
        Me.tabDB.Controls.Add(Me.GroupBox1)
        Me.tabDB.Location = New System.Drawing.Point(4, 23)
        Me.tabDB.Name = "tabDB"
        Me.tabDB.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDB.Size = New System.Drawing.Size(799, 179)
        Me.tabDB.TabIndex = 0
        Me.tabDB.Text = "Database Configurations"
        Me.tabDB.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(793, 173)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.btnTest1)
        Me.GroupBox3.Controls.Add(Me.txtPassword1)
        Me.GroupBox3.Controls.Add(Me.txtUsername1)
        Me.GroupBox3.Controls.Add(Me.txtDatabase1)
        Me.GroupBox3.Controls.Add(Me.txtserver1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(359, 157)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Innova Connection"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 14)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Server Host:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 14)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Database Name:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(65, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 14)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Username:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(65, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 14)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Password:"
        '
        'btnTest1
        '
        Me.btnTest1.Location = New System.Drawing.Point(141, 124)
        Me.btnTest1.Name = "btnTest1"
        Me.btnTest1.Size = New System.Drawing.Size(203, 23)
        Me.btnTest1.TabIndex = 7
        Me.btnTest1.Text = "Save"
        Me.btnTest1.UseVisualStyleBackColor = True
        '
        'txtPassword1
        '
        Me.txtPassword1.Location = New System.Drawing.Point(141, 98)
        Me.txtPassword1.MaxLength = 50
        Me.txtPassword1.Name = "txtPassword1"
        Me.txtPassword1.Size = New System.Drawing.Size(203, 20)
        Me.txtPassword1.TabIndex = 4
        Me.txtPassword1.UseSystemPasswordChar = True
        '
        'txtUsername1
        '
        Me.txtUsername1.Location = New System.Drawing.Point(141, 75)
        Me.txtUsername1.MaxLength = 50
        Me.txtUsername1.Name = "txtUsername1"
        Me.txtUsername1.Size = New System.Drawing.Size(203, 20)
        Me.txtUsername1.TabIndex = 3
        '
        'txtDatabase1
        '
        Me.txtDatabase1.Location = New System.Drawing.Point(141, 51)
        Me.txtDatabase1.MaxLength = 50
        Me.txtDatabase1.Name = "txtDatabase1"
        Me.txtDatabase1.Size = New System.Drawing.Size(203, 20)
        Me.txtDatabase1.TabIndex = 2
        '
        'txtserver1
        '
        Me.txtserver1.Location = New System.Drawing.Point(141, 27)
        Me.txtserver1.MaxLength = 50
        Me.txtserver1.Name = "txtserver1"
        Me.txtserver1.Size = New System.Drawing.Size(203, 20)
        Me.txtserver1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtserver2)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtDatabase2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtUsername2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtPassword2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnTest2)
        Me.GroupBox2.Location = New System.Drawing.Point(390, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(359, 157)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Score Connection"
        '
        'txtserver2
        '
        Me.txtserver2.Location = New System.Drawing.Point(141, 27)
        Me.txtserver2.MaxLength = 50
        Me.txtserver2.Name = "txtserver2"
        Me.txtserver2.Size = New System.Drawing.Size(203, 20)
        Me.txtserver2.TabIndex = 27
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(44, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 14)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Server Host:"
        '
        'txtDatabase2
        '
        Me.txtDatabase2.Location = New System.Drawing.Point(141, 51)
        Me.txtDatabase2.MaxLength = 50
        Me.txtDatabase2.Name = "txtDatabase2"
        Me.txtDatabase2.Size = New System.Drawing.Size(203, 20)
        Me.txtDatabase2.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 14)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Database Name:"
        '
        'txtUsername2
        '
        Me.txtUsername2.Location = New System.Drawing.Point(141, 75)
        Me.txtUsername2.MaxLength = 50
        Me.txtUsername2.Name = "txtUsername2"
        Me.txtUsername2.Size = New System.Drawing.Size(203, 20)
        Me.txtUsername2.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(65, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Username:"
        '
        'txtPassword2
        '
        Me.txtPassword2.Location = New System.Drawing.Point(141, 98)
        Me.txtPassword2.MaxLength = 50
        Me.txtPassword2.Name = "txtPassword2"
        Me.txtPassword2.Size = New System.Drawing.Size(203, 20)
        Me.txtPassword2.TabIndex = 30
        Me.txtPassword2.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(65, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Password:"
        '
        'btnTest2
        '
        Me.btnTest2.Location = New System.Drawing.Point(141, 124)
        Me.btnTest2.Name = "btnTest2"
        Me.btnTest2.Size = New System.Drawing.Size(203, 23)
        Me.btnTest2.TabIndex = 31
        Me.btnTest2.Text = "Save"
        Me.btnTest2.UseVisualStyleBackColor = True
        '
        'Tabs
        '
        Me.Tabs.Controls.Add(Me.tabDB)
        Me.Tabs.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tabs.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tabs.Location = New System.Drawing.Point(0, 230)
        Me.Tabs.Name = "Tabs"
        Me.Tabs.SelectedIndex = 0
        Me.Tabs.Size = New System.Drawing.Size(807, 206)
        Me.Tabs.TabIndex = 0
        '
        'imgLst
        '
        Me.imgLst.ImageStream = CType(resources.GetObject("imgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLst.Images.SetKeyName(0, "noActivity")
        Me.imgLst.Images.SetKeyName(1, "active")
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 436)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Splitter)
        Me.Controls.Add(Me.Tabs)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Text = "Database Agent"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tabDB.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Tabs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Splitter As System.Windows.Forms.Splitter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tabs As System.Windows.Forms.TabControl
    Friend WithEvents tabDB As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTest1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSideBySide As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnStacked As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCascade As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDBA As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMainDisplay As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnQuit As System.Windows.Forms.ToolStripButton
    Friend WithEvents imgLst As System.Windows.Forms.ImageList
    Friend WithEvents txtserver1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabase1 As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtserver2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabase2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword2 As System.Windows.Forms.TextBox
    Friend WithEvents btnTest2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
