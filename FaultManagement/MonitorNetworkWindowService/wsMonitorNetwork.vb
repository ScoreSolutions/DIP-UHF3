Imports System.Timers
Imports System.Windows.Forms
Public Class wsMonitorNetwork
    Dim tmMonitorPort As System.Timers.Timer
    Dim tmMonitorPing As System.Timers.Timer

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        tmMonitorPort = New System.Timers.Timer
        tmMonitorPort.Interval = 60000    'ทำทุก 1 นาที = 60000
        AddHandler tmMonitorPort.Elapsed, AddressOf tmMonitorPort_Tick
        tmMonitorPort.Start()
        tmMonitorPort.Enabled = True



        tmMonitorPing = New System.Timers.Timer
        tmMonitorPing.Interval = 60000    'ทำทุก 1 นาที = 60000
        AddHandler tmMonitorPing.Elapsed, AddressOf tmMonitorPing_Tick
        tmMonitorPing.Start()
        tmMonitorPing.Enabled = True
    End Sub

    Protected Sub tmMonitorPort_Tick(sender As Object, e As ElapsedEventArgs)
        tmMonitorPort.Enabled = False
        Try
            Info.MonitorNetworkInfoENG.MonitorPort()
        Catch ex As Exception

        End Try
        tmMonitorPort.Enabled = True
    End Sub

    Protected Sub tmMonitorPing_Tick(sender As Object, e As ElapsedEventArgs)
        tmMonitorPing.Enabled = False
        Try
            Info.MonitorNetworkInfoENG.PingToServer()
        Catch ex As Exception

        End Try
        tmMonitorPing.Enabled = True
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

End Class
