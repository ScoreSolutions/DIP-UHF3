<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyTextfileFromSpeedway
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCopyTextfileFromSpeedway))
        Me.TimerCopyTextFile = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TimerImportTextFile = New System.Windows.Forms.Timer(Me.components)
        Me.lblCurrentFile = New System.Windows.Forms.Label()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TimerCopyTextFile
        '
        Me.TimerCopyTextFile.Enabled = True
        Me.TimerCopyTextFile.Interval = 60000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'TimerImportTextFile
        '
        Me.TimerImportTextFile.Enabled = True
        Me.TimerImportTextFile.Interval = 1000
        '
        'lblCurrentFile
        '
        Me.lblCurrentFile.AutoSize = True
        Me.lblCurrentFile.Location = New System.Drawing.Point(30, 18)
        Me.lblCurrentFile.Name = "lblCurrentFile"
        Me.lblCurrentFile.Size = New System.Drawing.Size(0, 13)
        Me.lblCurrentFile.TabIndex = 0
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(30, 55)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(0, 13)
        Me.lblProcess.TabIndex = 1
        '
        'frmCopyTextfileFromSpeedway
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 94)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.lblCurrentFile)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCopyTextfileFromSpeedway"
        Me.Text = "Import Textfile From Speedway"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimerCopyTextFile As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents TimerImportTextFile As System.Windows.Forms.Timer
    Friend WithEvents lblCurrentFile As System.Windows.Forms.Label
    Friend WithEvents lblProcess As System.Windows.Forms.Label
End Class
