<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFaultManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFaultManagement))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tmSendInfo = New System.Windows.Forms.Timer(Me.components)
        Me.tmCheckAlive = New System.Windows.Forms.Timer(Me.components)
        Me.tmGetTempFile = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Fault Management"
        Me.NotifyIcon1.Visible = True
        '
        'tmSendInfo
        '
        Me.tmSendInfo.Enabled = True
        Me.tmSendInfo.Interval = 60000
        '
        'tmCheckAlive
        '
        Me.tmCheckAlive.Enabled = True
        Me.tmCheckAlive.Interval = 60000
        '
        'tmGetTempFile
        '
        Me.tmGetTempFile.Enabled = True
        Me.tmGetTempFile.Interval = 500
        '
        'frmFaultManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 652)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFaultManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fault Management"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents tmSendInfo As System.Windows.Forms.Timer
    Friend WithEvents tmCheckAlive As System.Windows.Forms.Timer
    Friend WithEvents tmGetTempFile As System.Windows.Forms.Timer
End Class
