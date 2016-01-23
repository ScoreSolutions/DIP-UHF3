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
        Me.wsDataAECProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.wsDataAECServiceInstaller = New System.ServiceProcess.ServiceInstaller()
        '
        'wsDataAECProcessInstaller
        '
        Me.wsDataAECProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.wsDataAECProcessInstaller.Password = Nothing
        Me.wsDataAECProcessInstaller.Username = Nothing
        '
        'wsDataAECServiceInstaller
        '
        Me.wsDataAECServiceInstaller.Description = "DIP UHF 3 Windows Service for Import Data from Q DIP AEC"
        Me.wsDataAECServiceInstaller.DisplayName = "DIP UHF 3 Windows Service for Import Data from Q DIP AEC"
        Me.wsDataAECServiceInstaller.ServiceName = "wsImportDataFromAECWindowService"
        Me.wsDataAECServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.wsDataAECProcessInstaller, Me.wsDataAECServiceInstaller})

    End Sub
    Friend WithEvents wsDataAECProcessInstaller As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents wsDataAECServiceInstaller As System.ServiceProcess.ServiceInstaller

End Class
