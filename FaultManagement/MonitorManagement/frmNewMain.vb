Imports System.Data
Imports LinqDB.TABLE
Imports LinqDB.ConnectDB

Imports Engine.Common
Imports Engine.Config
Imports System.Net.Mail



Public Class frmNewMain
    Dim TimeNow As New DateTime
    Private Sub frmNewMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimeNow = Now
        Label1.Text = TimeNow
    End Sub

    Private Sub tmMonitor_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmMonitor.Tick
        tmMonitor.Enabled = False
        Me.Text = "DIP Fault Monitor Management V" & getMyVersion() & "  Last Refresh Time :" & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", New Globalization.CultureInfo("en-US"))

        Dim cThe As New System.Threading.Thread(AddressOf MonitorCPU)
        cThe.Start()
        'MonitorCPU()

        Dim rThe As New System.Threading.Thread(AddressOf MonitorRAM)
        rThe.Start()
        'MonitorRAM()

        Dim hThe As New System.Threading.Thread(AddressOf MonitorHDD)
        hThe.Start()
        'MonitorHDD()

        Dim sThe As New System.Threading.Thread(AddressOf MonitorService)
        sThe.Start()
        'MonitorService()

        Dim pThe As New System.Threading.Thread(AddressOf MonitorProcess)
        pThe.Start()
        'MonitorProcess()

        Dim fsThe As New System.Threading.Thread(AddressOf MonitorFileSize)
        fsThe.Start()
        'MonitorFileSize()

        Dim flThe As New System.Threading.Thread(AddressOf MonitorFileLost)
        flThe.Start()
        'MonitorFileLost()

        'Dim ptThe As New System.Threading.Thread(AddressOf MonitorPort)
        'ptThe.Start()
        ''MonitorPort()

        'Dim piThe As New System.Threading.Thread(AddressOf PingToServer)
        'piThe.Start()
        ''PingToServer()

        Dim alThe As New System.Threading.Thread(AddressOf MonitorIamAlive)
        alThe.Start()
        ''MonitorIamAlive()

        tmMonitor.Enabled = True
    End Sub

    Private Sub MonitorIamAlive()
        Try
            Dim vDateNow As DateTime = SqlDB.GetDateNowFromDB(Nothing)
            Dim vTimeNow As String = vDateNow.ToString("HH:mm")
            Dim dt As New DataTable
            Dim eng As New Engine.Config.ConfigENG
            dt = eng.GetIamAliveList()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If dr("cfg_monitor_time_start") <= vTimeNow And vTimeNow <= dr("cfg_monitor_time_end") Then
                        Dim hng As New InfoClass.HardwareInfo
                        Dim hDt As DataTable = hng.GetAlarmWaitingClear(dr("ServerName"), "I_AM_ALIVE_" & dr("ServerName"), "Alarm")

                        Dim NextAliveTime As DateTime = Convert.ToDateTime(dr("next_alive_time"))
                        If vDateNow > NextAliveTime Then
                            'ถ้าเวลาปัจจุบันมากกว่า Next Alive Time แสดงว่า FaultManagement ไม่ทำงาน ให้ทำการส่ง Alarm
                            'Clear Alarm
                            Dim AlarmMsg As String = "Alarm Fault Management Process on " & dr("ServerName") & " is not Alive"
                            hDt.DefaultView.RowFilter = " AlarmActivity='I_AM_ALIVE_' + '" & dr("ServerName") & "'"
                            If hDt.DefaultView.Count = 0 Then
                                If hng.InsertAlarmWaitingClear(dr("ServerName"), dr("HostIP"), dr("MacAddress"), "CRITICAL", 0, "I_AM_ALIVE_" & dr("ServerName"), "Mail", AlarmMsg) > 0 Then
                                    hng.DeletePendingAlarm("I_AM_ALIVE_" & dr("ServerName"), dr("MacAddress"))
                                End If
                            Else
                                If hng.UpdateAlarmWaitingClear(dr("ServerName"), dr("HostIP"), dr("MacAddress"), "CRITICAL", 0, "I_AM_ALIVE_" & dr("ServerName"), "Mail", AlarmMsg, hDt.DefaultView(0)("id")) = True Then
                                    hng.DeletePendingAlarm("I_AM_ALIVE_" & dr("ServerName"), dr("MacAddress"))
                                End If
                            End If
                        Else
                            If hDt.Rows.Count > 0 Then
                                'Clear Alarm
                                hng.SendClearAlarm(dr("ServerName"), dr("HostIP"), dr("MacAddress"), "CRITICAL", 0, "Mail", "I_AM_ALIVE_" & dr("ServerName"), "Fault Management Process on " & dr("ServerName") & " is Clear", hDt.Rows(0)("id"))
                            End If
                        End If
                        hng = Nothing
                        hDt.Dispose()
                    End If
                Next
            End If
            dt.Dispose()
            eng = Nothing
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "MonitorIamAlive", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub




    Private Function getMyVersion() As String
        Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly.GetName().Version
        Return version.Major & "." & version.Minor & "." & version.Build & "." & version.Revision
    End Function


    '-------------------------------MonitorCPU
#Region "Monitor CPU" '-------------------------------MonitorCPU
    Private Sub MonitorCPU()
        Try
            Dim CPUcfDt As New DataTable
            CPUcfDt = CPUConfigENG.GetCPUConfigList()
            If CPUcfDt.Rows.Count > 0 Then
                For Each CPUcfDr As DataRow In CPUcfDt.Rows
                    Dim cfLnq As New LinqDB.TABLE.CfConfigCpuLinqDB
                    cfLnq.GetDataByPK(CPUcfDr("id"), Nothing)
                    If cfLnq.ID > 0 Then
                        Dim chk As Boolean = (cfLnq.ALLDAYEVENT = "Y")
                        If chk = False Then
                            Dim CurrTime As String = DateTime.Now.ToString("HH:mm")
                            If cfLnq.ALARMTIMEFROM <= CurrTime And CurrTime <= cfLnq.ALARMTIMETO Then
                                chk = True
                            End If
                        End If

                        If chk = True Then
                            If DateAdd(DateInterval.Minute, cfLnq.CHECKINTERVALMINUTE, cfLnq.LASTCHECKTIME) < LinqDB.ConnectDB.SqlDB.GetDateNowFromDB(Nothing) Then
                                Dim CPUInfoDt As DataTable = InfoClass.CPUInfo.GetCPUInfo("MacAddress='" & cfLnq.MACADDRESS & "'")
                                If CPUInfoDt.Rows.Count > 0 Then
                                    Dim infoLnq As New LinqDB.TABLE.TbCpuInfoLinqDB
                                    infoLnq.GetDataByPK(CPUInfoDt.Rows(0)("id"), Nothing)
                                    If infoLnq.ID > 0 Then
                                        Dim awDT As New DataTable
                                        awDT = InfoClass.CPUInfo.GetdtWAITING_CLEAR(cfLnq.MACADDRESS)

                                        Dim iEng As New InfoClass.CPUInfo
                                        If infoLnq.CPUPERCENT > cfLnq.ALARMCRITICALVALUE Then
                                            Dim Desc As String = "CPU Usage on " & cfLnq.SERVERNAME & " is " & infoLnq.CPUPERCENT & " % over " & cfLnq.ALARMCRITICALVALUE & " % (CRITICAL)"
                                            iEng.ProcessCPUAlarm(awDT, cfLnq, "CRITICAL", cfLnq.ALARMCRITICALVALUE, cfLnq.REPEATCHECKCRITICAL, infoLnq, infoLnq.CPUPERCENT, "Mail")
                                        ElseIf infoLnq.CPUPERCENT > cfLnq.ALARMMAJORVALUE Then
                                            Dim Desc As String = "CPU Usage on " & cfLnq.SERVERNAME & " is " & infoLnq.CPUPERCENT & " % over " & cfLnq.ALARMMAJORVALUE & " % (MAJOR)"
                                            iEng.ProcessCPUAlarm(awDT, cfLnq, "MAJOR", cfLnq.ALARMMAJORVALUE, cfLnq.REPEATCHECKMAJOR, infoLnq, infoLnq.CPUPERCENT, "Mail")
                                        ElseIf infoLnq.CPUPERCENT > cfLnq.ALARMMINORVALUE Then
                                            Dim Desc As String = "CPU Usage on " & cfLnq.SERVERNAME & " is " & infoLnq.CPUPERCENT & " % over " & cfLnq.ALARMMINORVALUE & " % (MONOR)"
                                            iEng.ProcessCPUAlarm(awDT, cfLnq, "MINOR", cfLnq.ALARMMINORVALUE, cfLnq.REPEATCHECKMINOR, infoLnq, infoLnq.CPUPERCENT, "Mail")
                                        ElseIf infoLnq.CPUPERCENT <= cfLnq.ALARMMINORVALUE Then
                                            If awDT.Rows.Count > 0 Then
                                                Dim dr As DataRow = awDT.Rows(0)
                                                Dim hw As New InfoClass.HardwareInfo
                                                Dim SpecificProblem As String = cfLnq.SERVERNAME & " CPU Usage " & dr("Severity") & " is Clear"
                                                hw.SendClearAlarm(cfLnq.SERVERNAME, cfLnq.SERVERIP, cfLnq.MACADDRESS, dr("Severity"), infoLnq.CPUPERCENT, "Mail", "CPU", SpecificProblem, dr("id"))
                                                hw = Nothing
                                            End If
                                        End If
                                        awDT.Dispose()
                                    End If
                                End If
                                CPUInfoDt.Dispose()

                                InfoClass.HardwareInfo.UpdateLastCheckTime(cfLnq.TableName, cfLnq.ID)
                            End If
                        End If
                    End If
                    cfLnq = Nothing
                Next
            End If
            CPUcfDt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "MonitorCPU", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
#End Region



#Region "-------------------------------MonitorRAM"
    Private Sub MonitorRAM()
        Try
            Dim cfDt As DataTable = RamConfigENG.GetRAMConfigList()
            If cfDt.Rows.Count > 0 Then
                For Each cfDr As DataRow In cfDt.Rows
                    Dim cfLnq As New CfConfigRamLinqDB
                    cfLnq.GetDataByPK(cfDr("id"), Nothing)
                    If cfLnq.ID > 0 Then
                        Dim chk As Boolean = (cfLnq.ALLDAYEVENT = "Y")
                        If chk = False Then
                            Dim CurrTime As String = DateTime.Now.ToString("HH:mm")
                            If cfLnq.ALARMTIMEFROM <= CurrTime And CurrTime <= cfLnq.ALARMTIMETO Then
                                chk = True
                            End If
                        End If

                        If chk = True Then
                            If DateAdd(DateInterval.Minute, cfLnq.CHECKINTERVALMINUTE, cfLnq.LASTCHECKTIME) < LinqDB.ConnectDB.SqlDB.GetDateNowFromDB(Nothing) Then
                                Dim InfoDt As DataTable = InfoClass.RAMInfo.GetRAMInfo("MacAddress='" & cfLnq.MACADDRESS & "'")
                                If InfoDt.Rows.Count > 0 Then
                                    Dim infoLnq As New TbRamInfoLinqDB
                                    infoLnq.GetDataByPK(InfoDt.Rows(0)("id"), Nothing)
                                    If infoLnq.ID > 0 Then
                                        Dim awDT As New DataTable
                                        awDT = InfoClass.RAMInfo.GetdtWAITING_CLEAR(cfLnq.MACADDRESS)

                                        Dim iEng As New InfoClass.RAMInfo
                                        If infoLnq.RAMPERCENT >= cfLnq.ALARMCRITICALVALUE Then
                                            Dim Desc As String = "RAM Usage on " & cfLnq.SERVERIP & " is " & infoLnq.RAMPERCENT & " % over " & cfLnq.ALARMCRITICALVALUE & " % (CRITICAL)"
                                            iEng.ProcessRAMAlarm(awDT, cfLnq, "CRITICAL", cfLnq.ALARMCRITICALVALUE, cfLnq.REPEATCHECKCRITICAL, infoLnq, infoLnq.RAMPERCENT, "Mail")
                                        ElseIf infoLnq.RAMPERCENT >= cfLnq.ALARMMAJORVALUE Then
                                            Dim Desc As String = "RAM Usage on " & cfLnq.SERVERIP & " is " & infoLnq.RAMPERCENT & " % over " & cfLnq.ALARMMAJORVALUE & " % (MAJOR)"
                                            iEng.ProcessRAMAlarm(awDT, cfLnq, "MAJOR", cfLnq.ALARMMAJORVALUE, cfLnq.REPEATCHECKMAJOR, infoLnq, infoLnq.RAMPERCENT, "Mail")
                                        ElseIf infoLnq.RAMPERCENT >= cfLnq.ALARMMINORVALUE Then
                                            Dim Desc As String = "RAM Usage on " & cfLnq.SERVERIP & " is " & infoLnq.RAMPERCENT & " % over " & cfLnq.ALARMMINORVALUE & " % (MINOR)"
                                            iEng.ProcessRAMAlarm(awDT, cfLnq, "MINOR", cfLnq.ALARMMAJORVALUE, cfLnq.REPEATCHECKMAJOR, infoLnq, infoLnq.RAMPERCENT, "Mail")
                                        Else
                                            If awDT.Rows.Count > 0 Then
                                                Dim dr As DataRow = awDT.Rows(0)
                                                Dim hw As New InfoClass.HardwareInfo
                                                Dim SpecificProblem As String = cfLnq.SERVERNAME & " RAM Usage " & dr("Severity") & " is Clear"
                                                hw.SendClearAlarm(cfLnq.SERVERNAME, cfLnq.SERVERIP, cfLnq.MACADDRESS, dr("Severity"), infoLnq.RAMPERCENT, "Mail", "RAM", SpecificProblem, dr("id"))
                                                hw = Nothing
                                            End If
                                        End If
                                        iEng = Nothing
                                    End If
                                    infoLnq = Nothing
                                End If
                                InfoDt.Dispose()

                                InfoClass.HardwareInfo.UpdateLastCheckTime(cfLnq.TableName, cfLnq.ID)
                            End If
                        End If
                    End If
                    cfLnq = Nothing
                Next
            End If
            cfDt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "MonitorRAM", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
#End Region


#Region "-------------------------------MonitorHDD"
    Private Sub MonitorHDD()
        Try
            Dim TmpcfDt As DataTable = HDDConfigENG.GetHDDConfigList()
            If TmpcfDt.Rows.Count > 0 Then
                Dim cfDt As DataTable = TmpcfDt.DefaultView.ToTable(True, "cfDriveId").Copy
                For Each cfDr As DataRow In cfDt.Rows
                    Dim cfLnq As New CfConfigDriveLinqDB
                    cfLnq.GetDataByPK(cfDr("cfDriveId"), Nothing)
                    If cfLnq.ID > 0 Then
                        Dim chk As Boolean = (cfLnq.ALLDAYEVENT = "Y")
                        If chk = False Then
                            Dim CurrTime As String = DateTime.Now.ToString("HH:mm")
                            If cfLnq.ALARMTIMEFROM <= CurrTime And CurrTime <= cfLnq.ALARMTIMETO Then
                                chk = True
                            End If
                        End If

                        If chk = True Then
                            If DateAdd(DateInterval.Minute, cfLnq.CHECKINTERVALMINUTE, cfLnq.LASTCHECKTIME) < LinqDB.ConnectDB.SqlDB.GetDateNowFromDB(Nothing) Then
                                TmpcfDt.DefaultView.RowFilter = "cfDriveId='" & cfLnq.ID & "'"
                                For Each dr As DataRowView In TmpcfDt.DefaultView
                                    Dim cfDetailLnq As New CfConfigDriveDetailLinqDB
                                    cfDetailLnq.GetDataByPK(dr("cfDriveDetailid"), Nothing)
                                    If cfDetailLnq.ID > 0 Then
                                        Dim InfoDt As DataTable = InfoClass.HDDInfo.GetHDDInfo("MacAddress='" & cfLnq.MACADDRESS & "' and DriveLetter='" & cfDetailLnq.DRIVELETTER & "'")
                                        If InfoDt.Rows.Count > 0 Then
                                            Dim infoLnq As New TbDriveInfoLinqDB
                                            infoLnq.GetDataByPK(InfoDt.Rows(0)("id"), Nothing)
                                            If infoLnq.ID > 0 Then
                                                Dim awDT As New DataTable
                                                awDT = InfoClass.HDDInfo.GetdtWAITING_CLEAR(cfLnq.MACADDRESS, infoLnq.DRIVELETTER)

                                                Dim iEng As New InfoClass.HDDInfo
                                                If infoLnq.PERCENTUSAGE >= cfDetailLnq.ALARMCRITICALVALUE Then
                                                    Dim Desc As String = "HDD Usage on " & cfLnq.SERVERIP & " Drive " & cfDetailLnq.DRIVELETTER & " is " & infoLnq.PERCENTUSAGE & " % over " & cfDetailLnq.ALARMCRITICALVALUE & " % (CRITICAL)"
                                                    iEng.ProcessHDDAlarm(awDT, cfLnq, "CRITICAL", cfDetailLnq.ALARMCRITICALVALUE, cfDetailLnq.REPEATCHECKCRITICAL, infoLnq, infoLnq.PERCENTUSAGE, "Mail", cfDetailLnq.DRIVELETTER)
                                                ElseIf infoLnq.PERCENTUSAGE >= cfDetailLnq.ALARMMAJORVALUE Then
                                                    Dim Desc As String = "HDD Usage on " & cfLnq.SERVERIP & " Drive " & cfDetailLnq.DRIVELETTER & " is " & infoLnq.PERCENTUSAGE & " % over " & cfDetailLnq.ALARMMAJORVALUE & " % (MAJOR)"
                                                    iEng.ProcessHDDAlarm(awDT, cfLnq, "MAJOR", cfDetailLnq.ALARMMAJORVALUE, cfDetailLnq.REPEATCHECKMAJOR, infoLnq, infoLnq.PERCENTUSAGE, "Mail", cfDetailLnq.DRIVELETTER)
                                                ElseIf infoLnq.PERCENTUSAGE >= cfDetailLnq.ALARMMINORVALUE Then
                                                    Dim Desc As String = "HDD Usage on " & cfLnq.SERVERIP & " Drive " & cfDetailLnq.DRIVELETTER & " is " & infoLnq.PERCENTUSAGE & " % over " & cfDetailLnq.ALARMMINORVALUE & " % (MINOR)"
                                                    iEng.ProcessHDDAlarm(awDT, cfLnq, "MINOR", cfDetailLnq.ALARMMINORVALUE, cfDetailLnq.REPEATCHECKMINOR, infoLnq, infoLnq.PERCENTUSAGE, "Mail", cfDetailLnq.DRIVELETTER)
                                                Else
                                                    If awDT.Rows.Count > 0 Then
                                                        Dim awDR As DataRow = awDT.Rows(0)
                                                        Dim hw As New InfoClass.HardwareInfo
                                                        Dim ClearMessage As String = cfLnq.SERVERNAME & " HDD Usage on Drive " & cfDetailLnq.DRIVELETTER & " " & awDR("Severity") & " is Clear"
                                                        hw.SendClearAlarm(cfLnq.SERVERNAME, cfLnq.SERVERIP, cfLnq.MACADDRESS, awDR("Severity"), infoLnq.PERCENTUSAGE, "Mail", "Drive_" & cfDetailLnq.DRIVELETTER, ClearMessage, awDR("id"))
                                                        hw = Nothing
                                                    End If
                                                End If
                                                awDT.Dispose()
                                            End If
                                            infoLnq = Nothing
                                        End If
                                        InfoDt.Dispose()
                                    End If
                                    cfDetailLnq = Nothing
                                Next
                                TmpcfDt.DefaultView.RowFilter = ""

                                InfoClass.HardwareInfo.UpdateLastCheckTime(cfLnq.TableName, cfLnq.ID)
                            End If
                        End If
                    End If
                    cfLnq = Nothing
                Next
                cfDt.Dispose()
            End If
            TmpcfDt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "MonitorHDD", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
#End Region
    '-------------------------------MonitorHDD


    '-------------------------------MonitorProcess
    Private Sub MonitorProcess()
        Try
            Dim TmpCfDt As DataTable = ProcessConfigENG.GetProcessConfigList()
            If TmpCfDt.Rows.Count > 0 Then
                Dim cfDT As DataTable = TmpCfDt.DefaultView.ToTable(True, "ProcessID")
                For Each cfDr As DataRow In cfDt.Rows
                    Dim cfLnq As New CfConfigProcessLinqDB
                    cfLnq.GetDataByPK(cfDr("ProcessID"), Nothing)
                    If cfLnq.ID > 0 Then
                        Dim chk As Boolean = (cfLnq.ALLDAYEVENT = "Y")
                        If chk = False Then
                            Dim CurrTime As String = DateTime.Now.ToString("HH:mm")
                            If cfLnq.ALARMTIMEFROM <= CurrTime And CurrTime <= cfLnq.ALARMTIMETO Then
                                chk = True
                            End If
                        End If

                        If chk = True Then
                            If DateAdd(DateInterval.Minute, cfLnq.CHECKINTERVALMINUTE, cfLnq.LASTCHECKTIME) < LinqDB.ConnectDB.SqlDB.GetDateNowFromDB(Nothing) Then
                                TmpCfDt.DefaultView.RowFilter = "ProcessID='" & cfLnq.ID & "'"
                                For Each dr As DataRowView In TmpCfDt.DefaultView
                                    Dim cfDetailLnq As New CfConfigProcessDetailLinqDB
                                    cfDetailLnq.GetDataByPK(dr("ProcessDetailID"), Nothing)
                                    If cfDetailLnq.ID > 0 Then
                                        Dim InfoLnq As New TbProcessInfoLinqDB
                                        InfoLnq.ChkDataByMACADDRESS_WINDOWPROCESSNAME(cfLnq.MACADDRESS, dr("WindowProcessName"), Nothing)
                                        If InfoLnq.ID > 0 Then
                                            Dim awDT As New DataTable
                                            awDT = InfoClass.ProcessInfo.GetdtWAITING_CLEAR(cfLnq.MACADDRESS, InfoLnq.WINDOWPROCESSNAME)

                                            Dim iEng As New InfoClass.ProcessInfo
                                            If InfoLnq.PROCESSALIVE <> "Y" Then
                                                iEng.ProcessProcessAlarm(awDT, cfLnq, cfDetailLnq.REPEATCHECKQTY, InfoLnq, "Mail", dr("DisplayName"))
                                            Else
                                                If awDT.Rows.Count > 0 Then
                                                    Dim hw As New InfoClass.HardwareInfo
                                                    Dim ClearMsg As String = "Alarm Windows Process " & dr("DisplayName") & " down on " & cfLnq.SERVERIP & " is Clear"
                                                    hw.SendClearAlarm(cfLnq.SERVERNAME, cfLnq.SERVERIP, cfLnq.MACADDRESS, "CRITICAL", 0, "Mail", "Process_" & InfoLnq.WINDOWPROCESSNAME, ClearMsg, awDT.Rows(0)("id"))
                                                    hw = Nothing
                                                End If
                                            End If
                                            awDT.Dispose()
                                        End If
                                        InfoLnq = Nothing
                                    End If
                                    cfDetailLnq = Nothing
                                Next
                                TmpCfDt.DefaultView.RowFilter = ""

                                InfoClass.HardwareInfo.UpdateLastCheckTime(cfLnq.TableName, cfLnq.ID)
                            End If
                        End If
                    End If
                    cfLnq = Nothing
                Next
                cfDT.Dispose()
            End If
            TmpCfDt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "MonitorProcess", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub MonitorService()
        Try
            Dim TmpCfDt As DataTable = ServiceConfigENG.GetServiceConfigList()
            If TmpCfDt.Rows.Count > 0 Then
                Dim cfDT As DataTable = TmpCfDt.DefaultView.ToTable(True, "ServiceID")
                If cfDt.Rows.Count > 0 Then
                    For Each cfDr As DataRow In cfDt.Rows
                        Dim cfLnq As New CfConfigServiceLinqDB
                        cfLnq.GetDataByPK(cfDr("ServiceID"), Nothing)
                        If cfLnq.ID > 0 Then
                            Dim chk As Boolean = (cfLnq.ALLDAYEVENT = "Y")
                            If chk = False Then
                                Dim CurrTime As String = DateTime.Now.ToString("HH:mm")
                                If cfLnq.ALARMTIMEFROM <= CurrTime And CurrTime <= cfLnq.ALARMTIMETO Then
                                    chk = True
                                End If
                            End If

                            If chk = True Then
                                If DateAdd(DateInterval.Minute, cfLnq.CHECKINTERVALMINUTE, cfLnq.LASTCHECKTIME) < LinqDB.ConnectDB.SqlDB.GetDateNowFromDB(Nothing) Then
                                    TmpCfDt.DefaultView.RowFilter = "ServiceID='" & cfLnq.ID & "'"
                                    For Each dr As DataRowView In TmpCfDt.DefaultView
                                        Dim cfDetailLnq As New CfConfigServiceDetailLinqDB
                                        cfDetailLnq.GetDataByPK(dr("ServiceDetailID"), Nothing)
                                        If cfDetailLnq.ID > 0 Then
                                            Dim InfoLnq As New TbServiceInfoLinqDB
                                            InfoLnq.ChkDataByMACADDRESS_SERVICENAME(cfLnq.MACADDRESS, dr("WindowServiceName"), Nothing)
                                            If InfoLnq.ID > 0 Then
                                                Dim awDT As New DataTable
                                                awDT = InfoClass.ServiceInfo.GetdtWAITING_CLEAR(cfLnq.MACADDRESS, InfoLnq.SERVICENAME)

                                                Dim iEng As New InfoClass.ServiceInfo
                                                If InfoLnq.SERVICESTATUS <> "RUNNING" Then
                                                    iEng.ProcessServiceAlarm(awDT, cfLnq, cfDetailLnq.REPEATCHECKQTY, InfoLnq, "Mail", dr("DisplayName"))
                                                Else
                                                    If awDT.Rows.Count > 0 Then
                                                        Dim hw As New InfoClass.HardwareInfo
                                                        Dim ClearMsg As String = "Alarm Service " & dr("DisplayName") & " down on " & cfLnq.SERVERIP & " is Clear"
                                                        hw.SendClearAlarm(cfLnq.SERVERNAME, cfLnq.SERVERIP, cfLnq.MACADDRESS, "CRITICAL", 0, "Mail", "Service_" & InfoLnq.SERVICENAME, ClearMsg, awDT.Rows(0)("id"))
                                                        hw = Nothing
                                                    End If
                                                End If
                                                awDT.Dispose()
                                            End If
                                            InfoLnq = Nothing
                                        End If
                                        cfDetailLnq = Nothing
                                    Next
                                    TmpCfDt.DefaultView.RowFilter = ""

                                    InfoClass.HardwareInfo.UpdateLastCheckTime(cfLnq.TableName, cfLnq.ID)
                                End If
                            End If
                        End If
                        cfLnq = Nothing
                    Next
                End If
                cfDt.Dispose()
            End If
            TmpCfDt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "MonitorService", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    '-------------------------------MonitorService

    '-------------------------------MonitorFileSize
    Private Sub MonitorFileSize()
        Try
            Dim TmpCfDt As DataTable = FileConfigENG.GetFileSizeConfigList
            If TmpCfDt.Rows.Count > 0 Then
                Dim cfDT As DataTable = TmpCfDt.DefaultView.ToTable(True, "FileSizeID")
                For Each cfDr As DataRow In cfDT.Rows
                    Dim cfLnq As New CfConfigFilesizeLinqDB
                    cfLnq.GetDataByPK(cfDr("FileSizeID"), Nothing)
                    If cfLnq.ID > 0 Then
                        Dim chk As Boolean = (cfLnq.ALLDAYEVENT = "Y")
                        If chk = False Then
                            Dim CurrTime As String = DateTime.Now.ToString("HH:mm")
                            If cfLnq.ALARMTIMEFROM <= CurrTime And CurrTime <= cfLnq.ALARMTIMETO Then
                                chk = True
                            End If
                        End If

                        If chk = True Then
                            If DateAdd(DateInterval.Minute, cfLnq.CHECKINTERVALMINUTE, cfLnq.LASTCHECKTIME) < LinqDB.ConnectDB.SqlDB.GetDateNowFromDB(Nothing) Then
                                TmpCfDt.DefaultView.RowFilter = "FileSizeID='" & cfLnq.ID & "'"
                                For Each dr As DataRowView In TmpCfDt.DefaultView
                                    Dim cfDetailLnq As New CfConfigFilesizeDetailLinqDB
                                    cfDetailLnq.GetDataByPK(dr("FileSizeDetailID"), Nothing)
                                    If cfDetailLnq.ID > 0 Then
                                        Dim InfoDt As DataTable = InfoClass.FileSizeInfo.GetFileSizeInfo(cfLnq.MACADDRESS, cfDetailLnq.FILENAME)
                                        If InfoDt.Rows.Count > 0 Then
                                            Dim InfoLnq As New TbFilesizeInfoLinqDB
                                            InfoLnq.GetDataByPK(InfoDt.Rows(0)("id"), Nothing)
                                            If InfoLnq.ID > 0 Then
                                                Dim awDT As New DataTable
                                                awDT = InfoClass.FileSizeInfo.GetdtWAITING_CLEAR(cfLnq.MACADDRESS, InfoLnq.FILENAME)

                                                Dim iEng As New InfoClass.FileSizeInfo
                                                If InfoLnq.FILESIZEGB >= cfDetailLnq.FILESIZECRITICAL Then
                                                    Dim Desc As String = "File " & InfoLnq.FILENAME & " on " & cfLnq.SERVERIP & " size " & InfoLnq.FILESIZEGB & " is over than " & cfDetailLnq.FILESIZECRITICAL & "  (CRITICAL)"
                                                    iEng.ProcessFileSizeAlarm(awDT, cfLnq, "CRITICAL", cfDetailLnq.FILESIZECRITICAL, cfDetailLnq.REPEATCHECKCRITICAL, InfoLnq, InfoLnq.FILESIZEGB, "Mail", cfDetailLnq.FILENAME)
                                                ElseIf InfoLnq.FILESIZEGB >= cfDetailLnq.FILESIZEMAJOR Then
                                                    Dim Desc As String = "File " & InfoLnq.FILENAME & " on " & cfLnq.SERVERIP & " size " & InfoLnq.FILESIZEGB & " is over than " & cfDetailLnq.FILESIZEMAJOR & "  (MAJOR)"
                                                    iEng.ProcessFileSizeAlarm(awDT, cfLnq, "MAJOR", cfDetailLnq.FILESIZEMAJOR, cfDetailLnq.REPEATCHECKMAJOR, InfoLnq, InfoLnq.FILESIZEGB, "Mail", cfDetailLnq.FILENAME)
                                                ElseIf InfoLnq.FILESIZEGB >= cfDetailLnq.FILESIZEMINOR Then
                                                    Dim Desc As String = "File " & InfoLnq.FILENAME & " on " & cfLnq.SERVERIP & " size " & InfoLnq.FILESIZEGB & " is over than " & cfDetailLnq.FILESIZEMINOR & "  (MINOR)"
                                                    iEng.ProcessFileSizeAlarm(awDT, cfLnq, "MINOR", cfDetailLnq.FILESIZEMINOR, cfDetailLnq.REPEATCHECKMINOR, InfoLnq, InfoLnq.FILESIZEGB, "Mail", cfDetailLnq.FILENAME)
                                                Else
                                                    If awDT.Rows.Count > 0 Then
                                                        Dim awDR As DataRow = awDT.Rows(0)
                                                        Dim hw As New InfoClass.HardwareInfo
                                                        Dim ClearMessage As String = " File Size Alarm " & InfoLnq.FILENAME & " on " & cfLnq.SERVERNAME & " " & awDR("Severity") & " is Clear"
                                                        hw.SendClearAlarm(cfLnq.SERVERNAME, cfLnq.SERVERIP, cfLnq.MACADDRESS, awDR("Severity"), InfoLnq.FILESIZEGB, "Mail", "FileSize_" & cfDetailLnq.FILENAME, ClearMessage, awDR("id"))
                                                        hw = Nothing
                                                    End If
                                                End If
                                                awDT.Dispose()
                                            End If
                                            InfoLnq = Nothing
                                        End If
                                        InfoDt.Dispose()
                                    End If
                                    cfDetailLnq = Nothing
                                Next
                                TmpCfDt.DefaultView.RowFilter = ""

                                InfoClass.HardwareInfo.UpdateLastCheckTime(cfLnq.TableName, cfLnq.ID)
                            End If
                        End If
                    End If
                    cfLnq = Nothing
                Next
                cfDT.Dispose()
            End If
            TmpCfDt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "MonitorFileSize", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub MonitorFileLost()
        Try
            Dim TmpCfDt As DataTable = FileConfigENG.GetFileLostConfigList
            If TmpCfDt.Rows.Count > 0 Then
                Dim cfDT As DataTable = TmpCfDt.DefaultView.ToTable(True, "FileLostID")
                For Each cfDr As DataRow In cfDT.Rows
                    Dim cfLnq As New CfConfigFilelostLinqDB
                    cfLnq.GetDataByPK(cfDr("FileLostID"), Nothing)
                    If cfLnq.ID > 0 Then
                        Dim chk As Boolean = (cfLnq.ALLDAYEVENT = "Y")
                        If chk = False Then
                            Dim CurrTime As String = DateTime.Now.ToString("HH:mm")
                            If cfLnq.ALARMTIMEFROM <= CurrTime And CurrTime <= cfLnq.ALARMTIMETO Then
                                chk = True
                            End If
                        End If

                        If chk = True Then
                            If DateAdd(DateInterval.Minute, cfLnq.CHECKINTERVALMINUTE, cfLnq.LASTCHECKTIME) < LinqDB.ConnectDB.SqlDB.GetDateNowFromDB(Nothing) Then
                                TmpCfDt.DefaultView.RowFilter = "FileLostID='" & cfLnq.ID & "'"
                                For Each dr As DataRowView In TmpCfDt.DefaultView
                                    Dim cfDetailLnq As New CfConfigFilelostDetailLinqDB
                                    cfDetailLnq.GetDataByPK(dr("FileLostDetailID"), Nothing)
                                    If cfDetailLnq.ID > 0 Then
                                        Dim InfoDt As DataTable = InfoClass.FileLostInfo.GetFileLostInfo(cfLnq.MACADDRESS, cfDetailLnq.FILENAME)
                                        If InfoDt.Rows.Count > 0 Then
                                            Dim InfoLnq As New TbFilelostInfoLinqDB
                                            InfoLnq.GetDataByPK(InfoDt.Rows(0)("id"), Nothing)
                                            If InfoLnq.ID > 0 Then
                                                Dim awDT As New DataTable
                                                awDT = InfoClass.FileLostInfo.GetdtWAITING_CLEAR(cfLnq.MACADDRESS, InfoLnq.FILENAME)

                                                Dim iEng As New InfoClass.FileLostInfo
                                                If InfoLnq.FILELOSTSTATUS <> "Y" Then
                                                    iEng.ProcessFileLostAlarm(awDT, cfLnq, cfLnq.REPEATECHECKQTY, InfoLnq, "Mail")
                                                Else
                                                    If awDT.Rows.Count > 0 Then
                                                        Dim hw As New InfoClass.HardwareInfo
                                                        Dim ClearMsg As String = "Alarm File Config Lost " & InfoLnq.FILENAME & " down on " & cfLnq.SERVERIP & " is Clear"
                                                        hw.SendClearAlarm(cfLnq.SERVERNAME, cfLnq.SERVERIP, cfLnq.MACADDRESS, "CRITICAL", 0, "Mail", "FileLost_" & InfoLnq.FILENAME, ClearMsg, awDT.Rows(0)("id"))
                                                        hw = Nothing
                                                    End If
                                                End If
                                                awDT.Dispose()
                                            End If
                                            InfoLnq = Nothing
                                        End If
                                        InfoDt.Dispose()
                                    End If
                                    cfDetailLnq = Nothing
                                Next
                                TmpCfDt.DefaultView.RowFilter = ""

                                InfoClass.HardwareInfo.UpdateLastCheckTime(cfLnq.TableName, cfLnq.ID)
                            End If
                        End If
                    End If
                    cfLnq = Nothing
                Next
                cfDT.Dispose()
            End If
            TmpCfDt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "MonitorFileLost", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    '-------------------------------MonitorFileSize


    

#Region "Send Email Alarm"
    Private Sub tmSendEmail_Tick(sender As Object, e As EventArgs) Handles tmSendEmail.Tick
        SendAlarmMail()
        SendClearMail()
    End Sub

    Public Sub SendAlarmMail()
        Try
            Dim ini As New MonitorManagement.Org.Mentalis.Files.IniReader(Application.StartupPath & "\Config.ini")
            ini.Section = "E-mail"

            Dim FromEmail As String = ini.ReadString("MailServer")
            Dim _Email As String = ini.ReadString("MailAccount")
            Dim Pass As String = ini.ReadString("MailPassword")
            Dim MailPort As String = ini.ReadString("MailPort")
            Dim MailSSL As Boolean = ini.ReadBoolean("MailSSL")

            Dim dt As New DataTable
            Dim lnq As New TbAlarmWaitingClearLinqDB
            Dim sql As String

            sql = "Select AW.id, R.ServerIP as IP ,R.Fname + ' ' + R.Lname as Name , R.E_mail as E_Mail ,AW.SpecificProblem as Specific,  " & vbNewLine
            sql += " aw.ServerName,aw.AlarmActivity,aw.severity" & vbNewLine
            sql += " from TB_REGISTER R " & vbNewLine
            sql += " inner join TB_ALARM_WAITING_CLEAR AW on R.ServerIP = AW.HostIP " & vbNewLine
            sql += " where aw.IsSendAlarm='N'" & vbNewLine

            dt = lnq.GetListBySql(sql, Nothing)
            If dt.Rows.Count > 0 Then
                For l As Integer = 0 To dt.Rows.Count - 1
                    Try
                        Dim Name As String = dt.Rows(l).Item("Name").ToString
                        Dim IP As String = dt.Rows(l).Item("IP").ToString
                        Dim Email As String = dt.Rows(l).Item("E_Mail").ToString
                        Dim Specific As String = dt.Rows(l).Item("Specific").ToString
                        Dim ServerName As String = dt.Rows(l).Item("ServerName")
                        Dim AlarmActivity As String = dt.Rows(l).Item("AlarmActivity")
                        Dim AlarmSeverity As String = dt.Rows(l).Item("severity")

                        Dim MailContent As String = " <b>Alarm " & AlarmSeverity & " !! </b> <br>  " & Specific & " </br>"
                        MailContent += " <br> on " & ServerName & "(" & IP & ")"
                        MailContent += " <b>Please,Check your data.</b> </br>"

                        Dim Mail As New MailMessage
                        Dim SMTP As New SmtpClient(FromEmail)

                        Mail.Subject = "Fault Management Alarm !! " & AlarmActivity & " on " & ServerName & "(" & IP & ")"
                        Mail.From = New MailAddress(_Email)
                        SMTP.Credentials = New System.Net.NetworkCredential(_Email, Pass) '<-- ชื่อเมลที่เราจะใช้ส่ง และรหัส 
                        Mail.To.Add(Email) 'I used ByVal here for address
                        Mail.IsBodyHtml = True

                        Mail.Body = MailContent 'Message Here
                        SMTP.EnableSsl = MailSSL
                        SMTP.Port = MailPort
                        Mail.BodyEncoding = System.Text.Encoding.UTF8
                        SMTP.Send(Mail)

                        UpdateSendMailAlarm(dt.Rows(l)("id"))
                    Catch ex As Exception
                        FunctionEng.CreateErrorLog("frmNewMain", "SendAlarmMail", "1. Exception :" & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "SendAlarmMail", "2. Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub UpdateSendMailAlarm(vAlarmID As String)
        Try
            Dim sql As String = "update TB_ALARM_WAITING_CLEAR"
            sql += " set IsSendAlarm='Y'"
            sql += " where id = '" & vAlarmID & "'"

            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            If lnq.UpdateBySql(sql, trans.Trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "UpdateSendMailAlarm", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub UpdateSendMailClearAlarm(vAlarmID As String)
        Try
            Dim sql As String = "update TB_ALARM_WAITING_CLEAR"
            sql += " set IsSendClear='Y'"
            sql += " where id = '" & vAlarmID & "'"

            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            If lnq.UpdateBySql(sql, trans.Trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmNewMain", "UpdateSendMailClearAlarm", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Sub SendClearMail()
        Try
            Dim ini As New MonitorManagement.Org.Mentalis.Files.IniReader(Application.StartupPath & "\Config.ini")
            ini.Section = "E-mail"
            Dim FromEmail As String = ini.ReadString("MailServer")
            Dim _Email As String = ini.ReadString("MailAccount")
            Dim Pass As String = ini.ReadString("MailPassword")
            Dim MailPort As String = ini.ReadString("MailPort")
            Dim MailSSL As Boolean = ini.ReadBoolean("MailSSL")

            Dim dt As New DataTable
            Dim lnq As New TbAlarmWaitingClearLinqDB
            Dim sql As String

            sql = "Select AW.id, R.ServerIP as IP ,R.Fname + ' ' + R.Lname as Name , R.E_mail as E_Mail ,AW.ClearMessage,  " & vbNewLine
            sql += " aw.ServerName,aw.AlarmActivity,aw.severity" & vbNewLine
            sql += " from TB_REGISTER R " & vbNewLine
            sql += " inner join TB_ALARM_WAITING_CLEAR AW on R.ServerIP = AW.HostIP " & vbNewLine
            sql += " where aw.IsSendClear='N'" & vbNewLine

            dt = lnq.GetListBySql(sql, Nothing)
            If dt.Rows.Count > 0 Then
                For l As Integer = 0 To dt.Rows.Count - 1
                    Try
                        Dim Name As String = dt.Rows(l).Item("Name").ToString
                        Dim IP As String = dt.Rows(l).Item("IP").ToString
                        Dim Email As String = dt.Rows(l).Item("E_Mail").ToString
                        Dim ClearMessage As String = dt.Rows(l).Item("ClearMessage").ToString
                        Dim ServerName As String = dt.Rows(l).Item("ServerName")
                        Dim AlarmActivity As String = dt.Rows(l).Item("AlarmActivity")
                        Dim AlarmSeverity As String = dt.Rows(l).Item("severity")

                        Dim MailContent As String = " <b>Clear Alarm " & AlarmSeverity & " !! </b> <br>  " & ClearMessage & " </br>"
                        MailContent += " <br> on " & ServerName & "(" & IP & ")"
                        MailContent += " <b>Complete</b> </br>"

                        Dim Mail As New MailMessage
                        Dim SMTP As New SmtpClient(FromEmail)

                        Mail.Subject = "Clear Alarm !! " & AlarmActivity & " on " & ServerName & "(" & IP & ")"
                        Mail.From = New MailAddress(_Email)
                        SMTP.Credentials = New System.Net.NetworkCredential(_Email, Pass) '<-- ชื่อเมลที่เราจะใช้ส่ง และรหัส 
                        Mail.To.Add(Email) 'I used ByVal here for address
                        Mail.IsBodyHtml = True

                        Mail.Body = MailContent 'Message Here
                        SMTP.EnableSsl = MailSSL
                        SMTP.Port = MailPort
                        Mail.BodyEncoding = System.Text.Encoding.UTF8
                        SMTP.Send(Mail)

                        UpdateSendMailClearAlarm(dt.Rows(l)("id"))
                    Catch ex As Exception
                        Engine.Common.FunctionEng.CreateErrorLog("frmNewMain", "SendClearMail", "1. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            Engine.Common.FunctionEng.CreateErrorLog("frmNewMain", "SendClearMail", "2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
#End Region

    Private Sub tmTime_Tick(sender As Object, e As EventArgs) Handles tmTime.Tick
        Label1.Text = DateTime.Now
    End Sub

    Private Sub frmNewMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
            NotifyIcon1.Text = "Fault Monitor Management V" & getMyVersion()
        Else
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub frmNewMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Text = "Fault Monitor Management V" & getMyVersion()
        tmMonitor.Start()
        tmSendEmail.Start()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub
End Class