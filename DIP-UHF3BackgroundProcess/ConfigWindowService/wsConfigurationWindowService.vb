Imports System.Timers
Imports Engine.LogFile
Imports System.Windows.Forms

Public Class wsConfigurationWindowService

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        LogENG.CreateTransLogFile("Start Configs WindowService")

        tmSignageContentSchedule = New System.Timers.Timer
        tmSignageContentSchedule.Interval = 1000
        AddHandler tmSignageContentSchedule.Elapsed, AddressOf tmSignageContentSchedule_Tick
        tmSignageContentSchedule.Start()
        tmSignageContentSchedule.Enabled = True


        tmSignageTextSchedule = New System.Timers.Timer
        tmSignageTextSchedule.Interval = 1000
        AddHandler tmSignageTextSchedule.Elapsed, AddressOf tmSignageTextSchedule_Tick
        tmSignageTextSchedule.Start()
        tmSignageTextSchedule.Enabled = True

        tmCheckConfigSpeedwaySchedule = New System.Timers.Timer
        tmCheckConfigSpeedwaySchedule.Interval = 60000   '6 หมื่น = 1 นาที
        AddHandler tmCheckConfigSpeedwaySchedule.Elapsed, AddressOf tmCheckConfigSpeedwaySchedule_Tick
        tmCheckConfigSpeedwaySchedule.Start()
        tmCheckConfigSpeedwaySchedule.Enabled = True


        'Fault Management Update Device Register Data
        tmFaultUpdateDevice = New System.Timers.Timer
        tmFaultUpdateDevice.Interval = 60000
        AddHandler tmFaultUpdateDevice.Elapsed, AddressOf tmFaultUpdateDevice_Tick
        tmFaultUpdateDevice.Start()
        tmFaultUpdateDevice.Enabled = True
    End Sub

    Dim tmSignageTextSchedule As System.Timers.Timer
    Protected Sub tmSignageTextSchedule_Tick(sender As Object, e As ElapsedEventArgs)
        tmSignageTextSchedule.Enabled = False
        Engine.DigitalSignageENG.SetScheduleTextScrolling()
        tmSignageTextSchedule.Enabled = True
    End Sub

    Dim tmSignageContentSchedule As System.Timers.Timer
    Protected Sub tmSignageContentSchedule_Tick(sender As Object, e As ElapsedEventArgs)
        tmSignageContentSchedule.Enabled = False
        Engine.DigitalSignageENG.SetScheduleSignageContent()
        tmSignageContentSchedule.Enabled = True
    End Sub

    Dim tmFaultUpdateDevice As System.Timers.Timer
    Protected Sub tmFaultUpdateDevice_Tick(sender As Object, e As ElapsedEventArgs)
        tmFaultUpdateDevice.Enabled = False
        Engine.FaultMngENG.UpdateRegisterDeviceDataToFaultMng()
        tmFaultUpdateDevice.Enabled = True
    End Sub

    Dim tmCheckConfigSpeedwaySchedule As System.Timers.Timer
    Protected Sub tmCheckConfigSpeedwaySchedule_Tick(sender As Object, e As ElapsedEventArgs)
        tmCheckConfigSpeedwaySchedule.Enabled = False
        Dim vDateNow As String = DateTime.Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        Engine.SpeedwayENG.UpdateConfigSchedule("wsRFIDWindowService.tmCheckConfigSpeedwaySchedule_Tick", vDateNow)
        tmCheckConfigSpeedwaySchedule.Enabled = True
    End Sub


    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.

        LogENG.CreateTransLogFile("Stop Configs WindowService")
    End Sub

End Class
