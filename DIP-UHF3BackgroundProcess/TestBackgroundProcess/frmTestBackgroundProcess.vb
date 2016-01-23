
Public Class frmTestBackgroundProcess

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim vDateNow As String = DateTime.Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        'Engine.SpeedwayENG.UpdateConfigSchedule("frmTestBackgroundProcess.Button1_Click", vDateNow)


        'Engine.DigitalSignageENG.SetScheduleSignageContent()

        'Engine.DigitalSignageENG.CheckDuplicateSignageScheduleTime(9, "13:01", "19:00")

        'Engine.DigitalSignageENG.CheckDuplicateTextScheduleTime(2, "08:05", "08:35")

        'Engine.DigitalSignageENG.SetScheduleTextScrolling()

        'Engine.DigitalSignageENG.GetFileChangeDue()



        'Engine.FaultMngENG.GetSignageServerInfo()
        'Engine.FaultMngENG.UpdateRegisterDeviceDataToFaultMng()

        'Engine.FileLocationENG.TracingDocumentData()
        'Engine.FileLocationENG.ClearTrackingDocumentData(10)

        'EngineRFIDReaderTCPModule.RFIDReaderTCPModuleENG.Connect("192.168.1.222", 1024)
        'Engine.FileLocationENG.SpeedwayUpdateCurrentLocation()

        'Dim eng As New Engine.ParticleENG
        'eng.ReadTextFileData("SYSTEM", "D:\My Documents\ScoreSolutions\ProjectDocument\DIP-UHF3\SourceDoc\เครื่องวัดฝุ่นละออง\11-01-2009 11-49-26.txt", 1)






        'If eng.HaveData = True Then
        '    Dim trans As New LinqDB.ConnectDB.TransactionDB(LinqDB.ConnectDB.SelectDB.DIPRFID)
        '    Dim ret = Engine.ParticleENG.SaveParticleCounterData("SYSTEM", eng, trans)
        '    If ret = True Then
        '        trans.CommitTransaction()
        '    Else
        '        trans.RollbackTransaction()
        '    End If

        'End If


        'Dim i As Integer = -1
        'Dim tmp1 As String = i.ToString.Substring(0, i.ToString.Length - 2)
        'Dim tmp2 As String = i.ToString.Substring(tmp1.Length)

        'MessageBox.Show(tmp1 & "." & tmp2)


        'Engine.DigitalSignageENG.ImportDataFromDIPAEC()

        'Engine.FaultMngENG.UpdateRegisterDeviceDataToFaultMng()
        'Engine.SpeedwayENG.CopyTextFileFromSpeedway("D:\SpeedwayTextFile\")


        'Dim vDateNow As String = DateTime.Now.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
        'Engine.SpeedwayENG.UpdateConfigSchedule("wsRFIDWindowService.tmCheckConfigSpeedwaySchedule_Tick", vDateNow)


        'Engine.FileLocationENG.TracingDocumentData()
        'Engine.FileLocationENG.ClearTrackingDocumentData(1)

        'Dim pCmd As String = "C:\Program Files\Microsoft SQL Server\110\DTS\Binn\dtexec.exe "
        'Dim args As String = " /SQL ""\""\ImportSpeedwayTextDataToDB\"""" /SERVER ""\""10.10.18.88\"""" /USER sa /PASSWORD 1qaz@WSX /CHECKPOINTING OFF  /REPORTING EW"
        'Dim proc As New ProcessStartInfo(pCmd, args)
        'Dim pr As Process = Process.Start(proc)
        'pr.WaitForExit()
        'MessageBox.Show("Success")

        'Engine.SpeedwayENG.MergeDataTextFile("D:\SpeedwayTextFile\ProcessPath\SPEEDWAY_PROCESS_FILE.txt", "D:\SpeedwayTextFile\ProcessPath\37014360022")


        'Engine.DigitalSignageENG.SetScheduleTextScrolling()

        Engine.SpeedwayENG.ImportTextDataToDB("D:\A.txt", New Label, New Label)

    End Sub
End Class
