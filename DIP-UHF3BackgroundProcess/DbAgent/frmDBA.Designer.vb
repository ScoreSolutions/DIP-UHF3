<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBA
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
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDBA))
        Me.btnStop = New System.Windows.Forms.ToolStripButton()
        Me.DBTool = New System.Windows.Forms.ToolStrip()
        Me.btnStart = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.status = New System.Windows.Forms.StatusStrip()
        Me.tlActive = New System.Windows.Forms.ToolStripDropDownButton()
        Me.statusBar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblTask2 = New System.Windows.Forms.Label()
        Me.pg2 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude4 = New System.Windows.Forms.CheckBox()
        Me.pg4 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude10 = New System.Windows.Forms.CheckBox()
        Me.pg6 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude8 = New System.Windows.Forms.CheckBox()
        Me.pg8 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude6 = New System.Windows.Forms.CheckBox()
        Me.pg10 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude2 = New System.Windows.Forms.CheckBox()
        Me.lblTask4 = New System.Windows.Forms.Label()
        Me.lblPct10 = New System.Windows.Forms.Label()
        Me.lblTask6 = New System.Windows.Forms.Label()
        Me.lblPct8 = New System.Windows.Forms.Label()
        Me.lblTask8 = New System.Windows.Forms.Label()
        Me.lblPct6 = New System.Windows.Forms.Label()
        Me.lblTask10 = New System.Windows.Forms.Label()
        Me.lblPct4 = New System.Windows.Forms.Label()
        Me.lblPct2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTask1 = New System.Windows.Forms.Label()
        Me.pg1 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude3 = New System.Windows.Forms.CheckBox()
        Me.pg3 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude9 = New System.Windows.Forms.CheckBox()
        Me.pg5 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude7 = New System.Windows.Forms.CheckBox()
        Me.pg7 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude5 = New System.Windows.Forms.CheckBox()
        Me.pg9 = New System.Windows.Forms.ProgressBar()
        Me.chkInclude1 = New System.Windows.Forms.CheckBox()
        Me.lblTask3 = New System.Windows.Forms.Label()
        Me.lblPct9 = New System.Windows.Forms.Label()
        Me.lblTask5 = New System.Windows.Forms.Label()
        Me.lblPct7 = New System.Windows.Forms.Label()
        Me.lblTask7 = New System.Windows.Forms.Label()
        Me.lblPct5 = New System.Windows.Forms.Label()
        Me.lblTask9 = New System.Windows.Forms.Label()
        Me.lblPct3 = New System.Windows.Forms.Label()
        Me.lblPct1 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.bw1 = New System.ComponentModel.BackgroundWorker()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.bw2 = New System.ComponentModel.BackgroundWorker()
        Me.bw3 = New System.ComponentModel.BackgroundWorker()
        Me.bw4 = New System.ComponentModel.BackgroundWorker()
        Me.bw5 = New System.ComponentModel.BackgroundWorker()
        Me.bw10 = New System.ComponentModel.BackgroundWorker()
        Me.bw9 = New System.ComponentModel.BackgroundWorker()
        Me.bw8 = New System.ComponentModel.BackgroundWorker()
        Me.bw7 = New System.ComponentModel.BackgroundWorker()
        Me.bw6 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DBTool.SuspendLayout()
        Me.status.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStop
        '
        Me.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStop.Image = CType(resources.GetObject("btnStop.Image"), System.Drawing.Image)
        Me.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(28, 28)
        Me.btnStop.ToolTipText = "Stop Medtrak Agent"
        '
        'DBTool
        '
        Me.DBTool.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.DBTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnStart, Me.btnStop, Me.ToolStripSeparator1, Me.btnClear})
        Me.DBTool.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.DBTool.Location = New System.Drawing.Point(0, 0)
        Me.DBTool.Name = "DBTool"
        Me.DBTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.DBTool.Size = New System.Drawing.Size(785, 31)
        Me.DBTool.TabIndex = 1
        Me.DBTool.Text = "ToolStrip1"
        '
        'btnStart
        '
        Me.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStart.Image = CType(resources.GetObject("btnStart.Image"), System.Drawing.Image)
        Me.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(28, 28)
        Me.btnStart.ToolTipText = "Start Medtrak Agent"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnClear
        '
        Me.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(28, 28)
        Me.btnClear.ToolTipText = "Clear Screen Log"
        '
        'status
        '
        Me.status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlActive, Me.statusBar})
        Me.status.Location = New System.Drawing.Point(0, 424)
        Me.status.Name = "status"
        Me.status.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.status.Size = New System.Drawing.Size(785, 22)
        Me.status.TabIndex = 2
        '
        'tlActive
        '
        Me.tlActive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlActive.Image = CType(resources.GetObject("tlActive.Image"), System.Drawing.Image)
        Me.tlActive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlActive.Name = "tlActive"
        Me.tlActive.ShowDropDownArrow = False
        Me.tlActive.Size = New System.Drawing.Size(20, 20)
        '
        'statusBar
        '
        Me.statusBar.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(748, 17)
        Me.statusBar.Spring = True
        Me.statusBar.Text = "Ready"
        Me.statusBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 254)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(785, 170)
        Me.Panel1.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTask2)
        Me.GroupBox2.Controls.Add(Me.pg2)
        Me.GroupBox2.Controls.Add(Me.chkInclude4)
        Me.GroupBox2.Controls.Add(Me.pg4)
        Me.GroupBox2.Controls.Add(Me.chkInclude10)
        Me.GroupBox2.Controls.Add(Me.pg6)
        Me.GroupBox2.Controls.Add(Me.chkInclude8)
        Me.GroupBox2.Controls.Add(Me.pg8)
        Me.GroupBox2.Controls.Add(Me.chkInclude6)
        Me.GroupBox2.Controls.Add(Me.pg10)
        Me.GroupBox2.Controls.Add(Me.chkInclude2)
        Me.GroupBox2.Controls.Add(Me.lblTask4)
        Me.GroupBox2.Controls.Add(Me.lblPct10)
        Me.GroupBox2.Controls.Add(Me.lblTask6)
        Me.GroupBox2.Controls.Add(Me.lblPct8)
        Me.GroupBox2.Controls.Add(Me.lblTask8)
        Me.GroupBox2.Controls.Add(Me.lblPct6)
        Me.GroupBox2.Controls.Add(Me.lblTask10)
        Me.GroupBox2.Controls.Add(Me.lblPct4)
        Me.GroupBox2.Controls.Add(Me.lblPct2)
        Me.GroupBox2.Location = New System.Drawing.Point(370, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(352, 149)
        Me.GroupBox2.TabIndex = 75
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Update"
        '
        'lblTask2
        '
        Me.lblTask2.AutoSize = True
        Me.lblTask2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask2.Location = New System.Drawing.Point(12, 31)
        Me.lblTask2.Name = "lblTask2"
        Me.lblTask2.Size = New System.Drawing.Size(63, 14)
        Me.lblTask2.TabIndex = 51
        Me.lblTask2.Text = "Position"
        '
        'pg2
        '
        Me.pg2.Location = New System.Drawing.Point(123, 31)
        Me.pg2.Name = "pg2"
        Me.pg2.Size = New System.Drawing.Size(105, 14)
        Me.pg2.TabIndex = 46
        '
        'chkInclude4
        '
        Me.chkInclude4.AutoSize = True
        Me.chkInclude4.Location = New System.Drawing.Point(270, 50)
        Me.chkInclude4.Name = "chkInclude4"
        Me.chkInclude4.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude4.TabIndex = 67
        Me.chkInclude4.Text = "Include"
        Me.chkInclude4.UseVisualStyleBackColor = True
        '
        'pg4
        '
        Me.pg4.Location = New System.Drawing.Point(123, 51)
        Me.pg4.Name = "pg4"
        Me.pg4.Size = New System.Drawing.Size(105, 14)
        Me.pg4.TabIndex = 46
        '
        'chkInclude10
        '
        Me.chkInclude10.AutoSize = True
        Me.chkInclude10.Location = New System.Drawing.Point(270, 110)
        Me.chkInclude10.Name = "chkInclude10"
        Me.chkInclude10.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude10.TabIndex = 67
        Me.chkInclude10.Text = "Include"
        Me.chkInclude10.UseVisualStyleBackColor = True
        '
        'pg6
        '
        Me.pg6.Location = New System.Drawing.Point(123, 71)
        Me.pg6.Name = "pg6"
        Me.pg6.Size = New System.Drawing.Size(105, 14)
        Me.pg6.TabIndex = 46
        '
        'chkInclude8
        '
        Me.chkInclude8.AutoSize = True
        Me.chkInclude8.Location = New System.Drawing.Point(270, 90)
        Me.chkInclude8.Name = "chkInclude8"
        Me.chkInclude8.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude8.TabIndex = 67
        Me.chkInclude8.Text = "Include"
        Me.chkInclude8.UseVisualStyleBackColor = True
        '
        'pg8
        '
        Me.pg8.Location = New System.Drawing.Point(123, 91)
        Me.pg8.Name = "pg8"
        Me.pg8.Size = New System.Drawing.Size(105, 14)
        Me.pg8.TabIndex = 46
        '
        'chkInclude6
        '
        Me.chkInclude6.AutoSize = True
        Me.chkInclude6.Location = New System.Drawing.Point(270, 70)
        Me.chkInclude6.Name = "chkInclude6"
        Me.chkInclude6.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude6.TabIndex = 67
        Me.chkInclude6.Text = "Include"
        Me.chkInclude6.UseVisualStyleBackColor = True
        '
        'pg10
        '
        Me.pg10.Location = New System.Drawing.Point(123, 111)
        Me.pg10.Name = "pg10"
        Me.pg10.Size = New System.Drawing.Size(105, 14)
        Me.pg10.TabIndex = 46
        '
        'chkInclude2
        '
        Me.chkInclude2.AutoSize = True
        Me.chkInclude2.Location = New System.Drawing.Point(270, 30)
        Me.chkInclude2.Name = "chkInclude2"
        Me.chkInclude2.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude2.TabIndex = 67
        Me.chkInclude2.Text = "Include"
        Me.chkInclude2.UseVisualStyleBackColor = True
        '
        'lblTask4
        '
        Me.lblTask4.AutoSize = True
        Me.lblTask4.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask4.Location = New System.Drawing.Point(12, 51)
        Me.lblTask4.Name = "lblTask4"
        Me.lblTask4.Size = New System.Drawing.Size(77, 14)
        Me.lblTask4.TabIndex = 51
        Me.lblTask4.Text = "Department"
        '
        'lblPct10
        '
        Me.lblPct10.AutoSize = True
        Me.lblPct10.Location = New System.Drawing.Point(234, 111)
        Me.lblPct10.Name = "lblPct10"
        Me.lblPct10.Size = New System.Drawing.Size(21, 14)
        Me.lblPct10.TabIndex = 56
        Me.lblPct10.Text = "0%"
        Me.lblPct10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTask6
        '
        Me.lblTask6.AutoSize = True
        Me.lblTask6.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask6.Location = New System.Drawing.Point(12, 71)
        Me.lblTask6.Name = "lblTask6"
        Me.lblTask6.Size = New System.Drawing.Size(56, 14)
        Me.lblTask6.TabIndex = 51
        Me.lblTask6.Text = "Officer"
        '
        'lblPct8
        '
        Me.lblPct8.AutoSize = True
        Me.lblPct8.Location = New System.Drawing.Point(234, 91)
        Me.lblPct8.Name = "lblPct8"
        Me.lblPct8.Size = New System.Drawing.Size(21, 14)
        Me.lblPct8.TabIndex = 56
        Me.lblPct8.Text = "0%"
        Me.lblPct8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTask8
        '
        Me.lblTask8.AutoSize = True
        Me.lblTask8.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask8.Location = New System.Drawing.Point(12, 91)
        Me.lblTask8.Name = "lblTask8"
        Me.lblTask8.Size = New System.Drawing.Size(84, 14)
        Me.lblTask8.TabIndex = 51
        Me.lblTask8.Text = "Requisition"
        '
        'lblPct6
        '
        Me.lblPct6.AutoSize = True
        Me.lblPct6.Location = New System.Drawing.Point(234, 71)
        Me.lblPct6.Name = "lblPct6"
        Me.lblPct6.Size = New System.Drawing.Size(21, 14)
        Me.lblPct6.TabIndex = 56
        Me.lblPct6.Text = "0%"
        Me.lblPct6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTask10
        '
        Me.lblTask10.AutoSize = True
        Me.lblTask10.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask10.Location = New System.Drawing.Point(12, 111)
        Me.lblTask10.Name = "lblTask10"
        Me.lblTask10.Size = New System.Drawing.Size(105, 14)
        Me.lblTask10.TabIndex = 51
        Me.lblTask10.Text = "FileBorrowItem"
        '
        'lblPct4
        '
        Me.lblPct4.AutoSize = True
        Me.lblPct4.Location = New System.Drawing.Point(234, 51)
        Me.lblPct4.Name = "lblPct4"
        Me.lblPct4.Size = New System.Drawing.Size(21, 14)
        Me.lblPct4.TabIndex = 56
        Me.lblPct4.Text = "0%"
        Me.lblPct4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPct2
        '
        Me.lblPct2.AutoSize = True
        Me.lblPct2.Location = New System.Drawing.Point(234, 31)
        Me.lblPct2.Name = "lblPct2"
        Me.lblPct2.Size = New System.Drawing.Size(21, 14)
        Me.lblPct2.TabIndex = 56
        Me.lblPct2.Text = "0%"
        Me.lblPct2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTask1)
        Me.GroupBox1.Controls.Add(Me.pg1)
        Me.GroupBox1.Controls.Add(Me.chkInclude3)
        Me.GroupBox1.Controls.Add(Me.pg3)
        Me.GroupBox1.Controls.Add(Me.chkInclude9)
        Me.GroupBox1.Controls.Add(Me.pg5)
        Me.GroupBox1.Controls.Add(Me.chkInclude7)
        Me.GroupBox1.Controls.Add(Me.pg7)
        Me.GroupBox1.Controls.Add(Me.chkInclude5)
        Me.GroupBox1.Controls.Add(Me.pg9)
        Me.GroupBox1.Controls.Add(Me.chkInclude1)
        Me.GroupBox1.Controls.Add(Me.lblTask3)
        Me.GroupBox1.Controls.Add(Me.lblPct9)
        Me.GroupBox1.Controls.Add(Me.lblTask5)
        Me.GroupBox1.Controls.Add(Me.lblPct7)
        Me.GroupBox1.Controls.Add(Me.lblTask7)
        Me.GroupBox1.Controls.Add(Me.lblPct5)
        Me.GroupBox1.Controls.Add(Me.lblTask9)
        Me.GroupBox1.Controls.Add(Me.lblPct3)
        Me.GroupBox1.Controls.Add(Me.lblPct1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 149)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Insert"
        '
        'lblTask1
        '
        Me.lblTask1.AutoSize = True
        Me.lblTask1.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask1.Location = New System.Drawing.Point(10, 31)
        Me.lblTask1.Name = "lblTask1"
        Me.lblTask1.Size = New System.Drawing.Size(63, 14)
        Me.lblTask1.TabIndex = 51
        Me.lblTask1.Text = "Position"
        '
        'pg1
        '
        Me.pg1.Location = New System.Drawing.Point(121, 31)
        Me.pg1.Name = "pg1"
        Me.pg1.Size = New System.Drawing.Size(105, 14)
        Me.pg1.TabIndex = 46
        '
        'chkInclude3
        '
        Me.chkInclude3.AutoSize = True
        Me.chkInclude3.Location = New System.Drawing.Point(268, 50)
        Me.chkInclude3.Name = "chkInclude3"
        Me.chkInclude3.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude3.TabIndex = 67
        Me.chkInclude3.Text = "Include"
        Me.chkInclude3.UseVisualStyleBackColor = True
        '
        'pg3
        '
        Me.pg3.Location = New System.Drawing.Point(121, 51)
        Me.pg3.Name = "pg3"
        Me.pg3.Size = New System.Drawing.Size(105, 14)
        Me.pg3.TabIndex = 46
        '
        'chkInclude9
        '
        Me.chkInclude9.AutoSize = True
        Me.chkInclude9.Location = New System.Drawing.Point(268, 110)
        Me.chkInclude9.Name = "chkInclude9"
        Me.chkInclude9.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude9.TabIndex = 67
        Me.chkInclude9.Text = "Include"
        Me.chkInclude9.UseVisualStyleBackColor = True
        '
        'pg5
        '
        Me.pg5.Location = New System.Drawing.Point(121, 71)
        Me.pg5.Name = "pg5"
        Me.pg5.Size = New System.Drawing.Size(105, 14)
        Me.pg5.TabIndex = 46
        '
        'chkInclude7
        '
        Me.chkInclude7.AutoSize = True
        Me.chkInclude7.Location = New System.Drawing.Point(268, 90)
        Me.chkInclude7.Name = "chkInclude7"
        Me.chkInclude7.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude7.TabIndex = 67
        Me.chkInclude7.Text = "Include"
        Me.chkInclude7.UseVisualStyleBackColor = True
        '
        'pg7
        '
        Me.pg7.Location = New System.Drawing.Point(121, 91)
        Me.pg7.Name = "pg7"
        Me.pg7.Size = New System.Drawing.Size(105, 14)
        Me.pg7.TabIndex = 46
        '
        'chkInclude5
        '
        Me.chkInclude5.AutoSize = True
        Me.chkInclude5.Location = New System.Drawing.Point(268, 70)
        Me.chkInclude5.Name = "chkInclude5"
        Me.chkInclude5.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude5.TabIndex = 67
        Me.chkInclude5.Text = "Include"
        Me.chkInclude5.UseVisualStyleBackColor = True
        '
        'pg9
        '
        Me.pg9.Location = New System.Drawing.Point(121, 111)
        Me.pg9.Name = "pg9"
        Me.pg9.Size = New System.Drawing.Size(105, 14)
        Me.pg9.TabIndex = 46
        '
        'chkInclude1
        '
        Me.chkInclude1.AutoSize = True
        Me.chkInclude1.Location = New System.Drawing.Point(268, 30)
        Me.chkInclude1.Name = "chkInclude1"
        Me.chkInclude1.Size = New System.Drawing.Size(75, 18)
        Me.chkInclude1.TabIndex = 67
        Me.chkInclude1.Text = "Include"
        Me.chkInclude1.UseVisualStyleBackColor = True
        '
        'lblTask3
        '
        Me.lblTask3.AutoSize = True
        Me.lblTask3.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask3.Location = New System.Drawing.Point(10, 51)
        Me.lblTask3.Name = "lblTask3"
        Me.lblTask3.Size = New System.Drawing.Size(77, 14)
        Me.lblTask3.TabIndex = 51
        Me.lblTask3.Text = "Department"
        '
        'lblPct9
        '
        Me.lblPct9.AutoSize = True
        Me.lblPct9.Location = New System.Drawing.Point(232, 111)
        Me.lblPct9.Name = "lblPct9"
        Me.lblPct9.Size = New System.Drawing.Size(21, 14)
        Me.lblPct9.TabIndex = 56
        Me.lblPct9.Text = "0%"
        Me.lblPct9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTask5
        '
        Me.lblTask5.AutoSize = True
        Me.lblTask5.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask5.Location = New System.Drawing.Point(10, 71)
        Me.lblTask5.Name = "lblTask5"
        Me.lblTask5.Size = New System.Drawing.Size(56, 14)
        Me.lblTask5.TabIndex = 51
        Me.lblTask5.Text = "Officer"
        '
        'lblPct7
        '
        Me.lblPct7.AutoSize = True
        Me.lblPct7.Location = New System.Drawing.Point(232, 91)
        Me.lblPct7.Name = "lblPct7"
        Me.lblPct7.Size = New System.Drawing.Size(21, 14)
        Me.lblPct7.TabIndex = 56
        Me.lblPct7.Text = "0%"
        Me.lblPct7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTask7
        '
        Me.lblTask7.AutoSize = True
        Me.lblTask7.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask7.Location = New System.Drawing.Point(10, 91)
        Me.lblTask7.Name = "lblTask7"
        Me.lblTask7.Size = New System.Drawing.Size(84, 14)
        Me.lblTask7.TabIndex = 51
        Me.lblTask7.Text = "Requisition"
        '
        'lblPct5
        '
        Me.lblPct5.AutoSize = True
        Me.lblPct5.Location = New System.Drawing.Point(232, 71)
        Me.lblPct5.Name = "lblPct5"
        Me.lblPct5.Size = New System.Drawing.Size(21, 14)
        Me.lblPct5.TabIndex = 56
        Me.lblPct5.Text = "0%"
        Me.lblPct5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTask9
        '
        Me.lblTask9.AutoSize = True
        Me.lblTask9.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTask9.Location = New System.Drawing.Point(10, 111)
        Me.lblTask9.Name = "lblTask9"
        Me.lblTask9.Size = New System.Drawing.Size(105, 14)
        Me.lblTask9.TabIndex = 51
        Me.lblTask9.Text = "FileBorrowItem"
        '
        'lblPct3
        '
        Me.lblPct3.AutoSize = True
        Me.lblPct3.Location = New System.Drawing.Point(232, 51)
        Me.lblPct3.Name = "lblPct3"
        Me.lblPct3.Size = New System.Drawing.Size(21, 14)
        Me.lblPct3.TabIndex = 56
        Me.lblPct3.Text = "0%"
        Me.lblPct3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPct1
        '
        Me.lblPct1.AutoSize = True
        Me.lblPct1.Location = New System.Drawing.Point(232, 31)
        Me.lblPct1.Name = "lblPct1"
        Me.lblPct1.Size = New System.Drawing.Size(21, 14)
        Me.lblPct1.TabIndex = 56
        Me.lblPct1.Text = "0%"
        Me.lblPct1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Splitter1
        '
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 250)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(785, 4)
        Me.Splitter1.TabIndex = 7
        Me.Splitter1.TabStop = False
        '
        'bw1
        '
        Me.bw1.WorkerReportsProgress = True
        Me.bw1.WorkerSupportsCancellation = True
        '
        'txtLog
        '
        Me.txtLog.BackColor = System.Drawing.Color.Black
        Me.txtLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLog.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLog.ForeColor = System.Drawing.Color.LimeGreen
        Me.txtLog.Location = New System.Drawing.Point(0, 31)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(785, 219)
        Me.txtLog.TabIndex = 8
        Me.txtLog.WordWrap = False
        '
        'bw2
        '
        Me.bw2.WorkerReportsProgress = True
        Me.bw2.WorkerSupportsCancellation = True
        '
        'bw3
        '
        Me.bw3.WorkerReportsProgress = True
        Me.bw3.WorkerSupportsCancellation = True
        '
        'bw4
        '
        Me.bw4.WorkerReportsProgress = True
        Me.bw4.WorkerSupportsCancellation = True
        '
        'bw5
        '
        Me.bw5.WorkerReportsProgress = True
        Me.bw5.WorkerSupportsCancellation = True
        '
        'bw10
        '
        Me.bw10.WorkerReportsProgress = True
        Me.bw10.WorkerSupportsCancellation = True
        '
        'bw9
        '
        Me.bw9.WorkerReportsProgress = True
        Me.bw9.WorkerSupportsCancellation = True
        '
        'bw8
        '
        Me.bw8.WorkerReportsProgress = True
        Me.bw8.WorkerSupportsCancellation = True
        '
        'bw7
        '
        Me.bw7.WorkerReportsProgress = True
        Me.bw7.WorkerSupportsCancellation = True
        '
        'bw6
        '
        Me.bw6.WorkerReportsProgress = True
        Me.bw6.WorkerSupportsCancellation = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmDBA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 446)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.status)
        Me.Controls.Add(Me.DBTool)
        Me.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDBA"
        Me.Text = "Medtrak DB Agent"
        Me.DBTool.ResumeLayout(False)
        Me.DBTool.PerformLayout()
        Me.status.ResumeLayout(False)
        Me.status.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DBTool As System.Windows.Forms.ToolStrip
    Friend WithEvents btnStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents status As System.Windows.Forms.StatusStrip
    Friend WithEvents statusBar As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents btnStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents bw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents lblPct1 As System.Windows.Forms.Label
    Friend WithEvents lblTask1 As System.Windows.Forms.Label
    Friend WithEvents pg1 As System.Windows.Forms.ProgressBar
    Friend WithEvents chkInclude1 As System.Windows.Forms.CheckBox
    Friend WithEvents tlActive As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkInclude3 As System.Windows.Forms.CheckBox
    Friend WithEvents lblPct3 As System.Windows.Forms.Label
    Friend WithEvents lblTask3 As System.Windows.Forms.Label
    Friend WithEvents pg3 As System.Windows.Forms.ProgressBar
    Friend WithEvents bw2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkInclude5 As System.Windows.Forms.CheckBox
    Friend WithEvents lblPct5 As System.Windows.Forms.Label
    Friend WithEvents lblTask5 As System.Windows.Forms.Label
    Friend WithEvents pg5 As System.Windows.Forms.ProgressBar
    Friend WithEvents bw3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkInclude9 As System.Windows.Forms.CheckBox
    Friend WithEvents chkInclude7 As System.Windows.Forms.CheckBox
    Friend WithEvents lblPct9 As System.Windows.Forms.Label
    Friend WithEvents lblPct7 As System.Windows.Forms.Label
    Friend WithEvents lblTask9 As System.Windows.Forms.Label
    Friend WithEvents lblTask7 As System.Windows.Forms.Label
    Friend WithEvents pg9 As System.Windows.Forms.ProgressBar
    Friend WithEvents pg7 As System.Windows.Forms.ProgressBar
    Friend WithEvents bw4 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw5 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw10 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw9 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw8 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw7 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bw6 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTask2 As System.Windows.Forms.Label
    Friend WithEvents pg2 As System.Windows.Forms.ProgressBar
    Friend WithEvents chkInclude4 As System.Windows.Forms.CheckBox
    Friend WithEvents pg4 As System.Windows.Forms.ProgressBar
    Friend WithEvents chkInclude10 As System.Windows.Forms.CheckBox
    Friend WithEvents pg6 As System.Windows.Forms.ProgressBar
    Friend WithEvents chkInclude8 As System.Windows.Forms.CheckBox
    Friend WithEvents pg8 As System.Windows.Forms.ProgressBar
    Friend WithEvents chkInclude6 As System.Windows.Forms.CheckBox
    Friend WithEvents pg10 As System.Windows.Forms.ProgressBar
    Friend WithEvents chkInclude2 As System.Windows.Forms.CheckBox
    Friend WithEvents lblTask4 As System.Windows.Forms.Label
    Friend WithEvents lblPct10 As System.Windows.Forms.Label
    Friend WithEvents lblTask6 As System.Windows.Forms.Label
    Friend WithEvents lblPct8 As System.Windows.Forms.Label
    Friend WithEvents lblTask8 As System.Windows.Forms.Label
    Friend WithEvents lblPct6 As System.Windows.Forms.Label
    Friend WithEvents lblTask10 As System.Windows.Forms.Label
    Friend WithEvents lblPct4 As System.Windows.Forms.Label
    Friend WithEvents lblPct2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
