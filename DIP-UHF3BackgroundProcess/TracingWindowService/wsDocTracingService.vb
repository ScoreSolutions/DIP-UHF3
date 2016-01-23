Imports Engine.LogFile
Imports System.Timers

Public Class wsDocTracingService

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        LogENG.CreateTransLogFile("Start Document Tracing Service")


        tmDocTracing = New System.Timers.Timer
        tmDocTracing.Interval = 1000
        AddHandler tmDocTracing.Elapsed, AddressOf tmDocTracing_Tick
        tmDocTracing.Start()
        tmDocTracing.Enabled = True

        'tmDocUpdateCurrentLocation = New System.Timers.Timer
        'tmDocUpdateCurrentLocation.Interval = 60000
        'AddHandler tmDocUpdateCurrentLocation.Elapsed, AddressOf tmDocUpdateCurrentLocation_Tick
        'tmDocUpdateCurrentLocation.Start()
        'tmDocUpdateCurrentLocation.Enabled = True
    End Sub

    Dim tmDocTracing As System.Timers.Timer
    Protected Sub tmDocTracing_Tick(sender As Object, e As ElapsedEventArgs)
        tmDocTracing.Enabled = False
        Engine.FileLocationENG.TracingDocumentData()
        Engine.FileLocationENG.ClearTrackingDocumentData(1)
        tmDocTracing.Enabled = True
    End Sub

    'Dim tmDocUpdateCurrentLocation As System.Timers.Timer
    'Protected Sub tmDocUpdateCurrentLocation_Tick(sender As Object, e As ElapsedEventArgs)
    '    'LogENG.CreateTransLogFile("Start tmDocUpdateCurrentLocation_Tick")
    '    tmDocUpdateCurrentLocation.Enabled = False
    '    Engine.FileLocationENG.SpeedwayUpdateCurrentLocation()
    '    tmDocUpdateCurrentLocation.Enabled = True
    'End Sub


    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

End Class
