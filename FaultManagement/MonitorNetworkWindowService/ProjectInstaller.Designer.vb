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
        Me.MonitorNetworkSPInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.MonitorNetworkInstaller = New System.ServiceProcess.ServiceInstaller()
        '
        'MonitorNetworkSPInstaller
        '
        Me.MonitorNetworkSPInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.MonitorNetworkSPInstaller.Password = Nothing
        Me.MonitorNetworkSPInstaller.Username = Nothing
        '
        'MonitorNetworkInstaller
        '
        Me.MonitorNetworkInstaller.Description = "Fault Management Monitor Network Service"
        Me.MonitorNetworkInstaller.DisplayName = "Fault Management Monitor Network Service"
        Me.MonitorNetworkInstaller.ServiceName = "Service1"
        Me.MonitorNetworkInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.MonitorNetworkSPInstaller, Me.MonitorNetworkInstaller})

    End Sub
    Friend WithEvents MonitorNetworkSPInstaller As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents MonitorNetworkInstaller As System.ServiceProcess.ServiceInstaller

End Class
