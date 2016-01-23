<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateCurrentLocationFromTextfile
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
        Me.cbLocation = New System.Windows.Forms.ComboBox()
        Me.txtTextFile = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgTextData = New System.Windows.Forms.DataGridView()
        Me.colTagNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAppNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fdBrowse = New System.Windows.Forms.OpenFileDialog()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgTextData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbLocation
        '
        Me.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLocation.FormattingEnabled = True
        Me.cbLocation.Location = New System.Drawing.Point(92, 22)
        Me.cbLocation.Name = "cbLocation"
        Me.cbLocation.Size = New System.Drawing.Size(291, 21)
        Me.cbLocation.TabIndex = 0
        '
        'txtTextFile
        '
        Me.txtTextFile.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtTextFile.Location = New System.Drawing.Point(92, 49)
        Me.txtTextFile.Name = "txtTextFile"
        Me.txtTextFile.Size = New System.Drawing.Size(291, 20)
        Me.txtTextFile.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(390, 47)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(26, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Location : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Text File : "
        '
        'dgTextData
        '
        Me.dgTextData.AllowUserToAddRows = False
        Me.dgTextData.AllowUserToDeleteRows = False
        Me.dgTextData.AllowUserToOrderColumns = True
        Me.dgTextData.AllowUserToResizeColumns = False
        Me.dgTextData.AllowUserToResizeRows = False
        Me.dgTextData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgTextData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTextData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTagNo, Me.colAppNo})
        Me.dgTextData.Location = New System.Drawing.Point(12, 102)
        Me.dgTextData.Name = "dgTextData"
        Me.dgTextData.RowHeadersVisible = False
        Me.dgTextData.Size = New System.Drawing.Size(421, 433)
        Me.dgTextData.TabIndex = 5
        '
        'colTagNo
        '
        Me.colTagNo.DataPropertyName = "tag_no"
        Me.colTagNo.HeaderText = "Tag No"
        Me.colTagNo.Name = "colTagNo"
        Me.colTagNo.ReadOnly = True
        Me.colTagNo.Width = 200
        '
        'colAppNo
        '
        Me.colAppNo.DataPropertyName = "app_no"
        Me.colAppNo.HeaderText = "เลขแฟ้ม"
        Me.colAppNo.Name = "colAppNo"
        Me.colAppNo.Width = 150
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Result : "
        '
        'fdBrowse
        '
        Me.fdBrowse.FileName = "OpenFileDialog1"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(187, 541)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 34)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'frmUpdateCurrentLocationFromTextfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 586)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgTextData)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtTextFile)
        Me.Controls.Add(Me.cbLocation)
        Me.Name = "frmUpdateCurrentLocationFromTextfile"
        Me.Text = "Update Current Location from Text File"
        CType(Me.dgTextData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbLocation As System.Windows.Forms.ComboBox
    Friend WithEvents txtTextFile As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgTextData As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fdBrowse As System.Windows.Forms.OpenFileDialog
    Friend WithEvents colTagNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAppNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
