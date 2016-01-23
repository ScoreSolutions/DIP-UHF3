Imports System.Timers
Imports Engine.LogFile
Imports System.Windows.Forms

Public Class wsImportDataFromAECWindowService

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.


        LogENG.CreateTransLogFile("Start Import Data From DIP SCAN AEC WindowService")

        tmImportData = New System.Timers.Timer
        tmImportData.Interval = 1000
        AddHandler tmImportData.Elapsed, AddressOf tmImportData_Tick
        tmImportData.Start()
        tmImportData.Enabled = True
    End Sub

    Dim tmImportData As System.Timers.Timer
    Protected Sub tmImportData_Tick(sender As Object, e As ElapsedEventArgs)
        tmImportData.Enabled = False
        Engine.DigitalSignageENG.ImportDataFromDIPAEC("wsImportDataFromAECWindowService")
        tmImportData.Enabled = True
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

End Class
