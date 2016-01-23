<System.ComponentModel.RunInstaller(True)> Partial Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

    'Installer overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DocTracingSPInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.DocTracingInstaller = New System.ServiceProcess.ServiceInstaller()
        '
        'DocTracingSPInstaller
        '
        Me.DocTracingSPInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.DocTracingSPInstaller.Password = Nothing
        Me.DocTracingSPInstaller.Username = Nothing
        '
        'DocTracingInstaller
        '
        Me.DocTracingInstaller.Description = "DIP UHF 3 Windows Service for Document Tracing"
        Me.DocTracingInstaller.DisplayName = "DIP UHF 3 Document Tracing Service"
        Me.DocTracingInstaller.ServiceName = "wsDocTracingService"
        Me.DocTracingInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.DocTracingInstaller, Me.DocTracingSPInstaller})

    End Sub
    Friend WithEvents DocTracingSPInstaller As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents DocTracingInstaller As System.ServiceProcess.ServiceInstaller

End Class
