<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRFIDReaderImportData
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
        Me.lblIPAddress = New System.Windows.Forms.Label()
        Me.lblMacAddress = New System.Windows.Forms.Label()
        Me.lblSerialNo = New System.Windows.Forms.Label()
        Me.lblPortNo = New System.Windows.Forms.Label()
        Me.lblMsRoomID = New System.Windows.Forms.Label()
        Me.lblLocationName = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblIPAddress
        '
        Me.lblIPAddress.AutoSize = True
        Me.lblIPAddress.Location = New System.Drawing.Point(150, 34)
        Me.lblIPAddress.Name = "lblIPAddress"
        Me.lblIPAddress.Size = New System.Drawing.Size(0, 13)
        Me.lblIPAddress.TabIndex = 1
        '
        'lblMacAddress
        '
        Me.lblMacAddress.AutoSize = True
        Me.lblMacAddress.Location = New System.Drawing.Point(158, 42)
        Me.lblMacAddress.Name = "lblMacAddress"
        Me.lblMacAddress.Size = New System.Drawing.Size(0, 13)
        Me.lblMacAddress.TabIndex = 2
        '
        'lblSerialNo
        '
        Me.lblSerialNo.AutoSize = True
        Me.lblSerialNo.Location = New System.Drawing.Point(166, 50)
        Me.lblSerialNo.Name = "lblSerialNo"
        Me.lblSerialNo.Size = New System.Drawing.Size(0, 13)
        Me.lblSerialNo.TabIndex = 3
        '
        'lblPortNo
        '
        Me.lblPortNo.AutoSize = True
        Me.lblPortNo.Location = New System.Drawing.Point(174, 58)
        Me.lblPortNo.Name = "lblPortNo"
        Me.lblPortNo.Size = New System.Drawing.Size(0, 13)
        Me.lblPortNo.TabIndex = 4
        '
        'lblMsRoomID
        '
        Me.lblMsRoomID.AutoSize = True
        Me.lblMsRoomID.Location = New System.Drawing.Point(182, 66)
        Me.lblMsRoomID.Name = "lblMsRoomID"
        Me.lblMsRoomID.Size = New System.Drawing.Size(0, 13)
        Me.lblMsRoomID.TabIndex = 5
        '
        'lblLocationName
        '
        Me.lblLocationName.AutoSize = True
        Me.lblLocationName.Location = New System.Drawing.Point(0, 0)
        Me.lblLocationName.Name = "lblLocationName"
        Me.lblLocationName.Size = New System.Drawing.Size(0, 13)
        Me.lblLocationName.TabIndex = 6
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'frmRFIDReaderImportData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 80)
        Me.Controls.Add(Me.lblLocationName)
        Me.Controls.Add(Me.lblMsRoomID)
        Me.Controls.Add(Me.lblPortNo)
        Me.Controls.Add(Me.lblSerialNo)
        Me.Controls.Add(Me.lblMacAddress)
        Me.Controls.Add(Me.lblIPAddress)
        Me.Name = "frmRFIDReaderImportData"
        Me.Text = "RFID Reader Import Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIPAddress As System.Windows.Forms.Label
    Friend WithEvents lblMacAddress As System.Windows.Forms.Label
    Friend WithEvents lblSerialNo As System.Windows.Forms.Label
    Friend WithEvents lblPortNo As System.Windows.Forms.Label
    Friend WithEvents lblMsRoomID As System.Windows.Forms.Label
    Friend WithEvents lblLocationName As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
