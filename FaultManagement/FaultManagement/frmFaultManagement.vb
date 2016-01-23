Imports System.Data
Imports Engine.Common
Imports System.IO
Imports System.DirectoryServices

Public Class frmFaultManagement
    Dim ComputerName As String = Environment.MachineName
    Dim IPAddress As String = GetIPAddress()
    Dim MacAddress As String = FunctionEng.GetMACAddress


#Region "Monitor Zone"
    Private Sub SendCPUInfo(ws As FaultManagementService.FaultManagementService)
        Try
            Dim inf As New Engine.Info.CPUInfoENG
            Try
                ws.SendCPUInfoToDC(ComputerName, IPAddress, inf.PercentUsage, MacAddress)
            Catch ex As Exception
                Engine.Common.FunctionEng.CreateErrorLog("frmMain", "SendCPUInfo", ex.Message & vbNewLine & ex.StackTrace)
            End Try
            inf = Nothing
        Catch ex As Exception
            Engine.Common.FunctionEng.CreateErrorLog("frmMain", "SendCPUInfo", ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub SendRamInfo(ws As FaultManagementService.FaultManagementService)
        Try
            Dim inf As New Engine.Info.RamInfoENG
            Try
                ws.SendRAMInfoToDC(ComputerName, IPAddress, inf.PercentUsageGB, MacAddress)
            Catch ex As Exception
                Engine.Common.FunctionEng.CreateErrorLog("frmMain", "SendRamInfo", ex.Message & vbNewLine & ex.StackTrace)
            End Try
            inf = Nothing
        Catch ex As Exception
            Engine.Common.FunctionEng.CreateErrorLog("frmMain", "SendRamInfo", ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub SendDriveInfo(ws As FaultManagementService.FaultManagementService)
        Try
            Dim inf As New Engine.Info.DriveInfoENG
            Try
                ws.SendDriveInfoToDC(ComputerName, IPAddress, inf.GetDriveInfoToDT, MacAddress)
            Catch ex As Exception
                FunctionEng.CreateErrorLog("frmMain", "SendDriveInfo", ex.Message & vbNewLine & ex.StackTrace)
            End Try
            inf = Nothing
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmMain", "SendDriveInfo", ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub SendServiceInfo(ws As FaultManagementService.FaultManagementService)
        Dim ServiceDt As New DataTable
        ServiceDt.Columns.Add("ServiceName")
        ServiceDt.Columns.Add("ServiceType")
        ServiceDt.Columns.Add("ServiceStatus")

        Try
            Dim dt As New DataTable
            dt = ws.GetWindowsServiceCheckList(MacAddress)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If dr("ActiveStatus").ToString = "Y" Then

                        Dim ServiceInfo As New Engine.Info.WindowsServiceInfoENG(dr("WindowServiceName"))
                        Dim sdr As DataRow = ServiceDt.NewRow
                        sdr("ServiceName") = dr("WindowServiceName")

                        If ServiceInfo.ServiceType = "" Then
                            sdr("ServiceType") = "Not_Type"
                        Else
                            sdr("ServiceType") = ServiceInfo.ServiceType
                        End If

                        Select Case ServiceInfo.ServiceStatus
                            Case "1"
                                sdr("ServiceStatus") = "STOPPED"
                            Case "2"
                                sdr("ServiceStatus") = "START_PENDING"
                            Case "3"
                                sdr("ServiceStatus") = "STOP_PENDING"
                            Case "4"
                                sdr("ServiceStatus") = "RUNNING"
                            Case ""
                                sdr("ServiceStatus") = "Not_Service"
                            Case Else
                                sdr("ServiceStatus") = "Service"
                        End Select
                        ServiceDt.Rows.Add(sdr)
                    End If
                Next

                Try
                    ServiceDt.TableName = "ServiceDt"
                    ws.SendServiceInfoToDC(ComputerName, IPAddress, ServiceDt, MacAddress)
                Catch ex As Exception
                    FunctionEng.CreateErrorLog("frmMain", "SendServiceInfo", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            dt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmMain", "SendServiceInfo", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        ServiceDt.Dispose()
    End Sub
    
    Private Sub SendProcessInfo(ws As FaultManagementService.FaultManagementService)
        Dim ProcessDt As New DataTable
        ProcessDt.Columns.Add("WindowProcessName")
        ProcessDt.Columns.Add("ProcessAlive")

        Try
            Dim dt As New DataTable
            dt = ws.GetWindowsProcessCheckList(MacAddress)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim pDr As DataRow = ProcessDt.NewRow
                    pDr("WindowProcessName") = dr("WindowProcessName")
                    If Process.GetProcessesByName(dr("WindowProcessName")).Length = 0 Then
                        'Process ไม่อยู่แล้ว
                        pDr("ProcessAlive") = "N"
                    Else
                        'Process ยังคงอยู่
                        pDr("ProcessAlive") = "Y"
                    End If
                    ProcessDt.Rows.Add(pDr)
                Next

                Try
                    ProcessDt.TableName = "ProcessDt"
                    ws.SendProcessInfoToDC(ComputerName, IPAddress, ProcessDt, MacAddress)
                Catch ex As Exception
                    FunctionEng.CreateErrorLog("frmMain", "ProcessMonitor", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            dt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmMain", "ProcessMonitor", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ProcessDt.Dispose()
    End Sub

    Private Sub WebMonitor(ws As FaultManagementService.FaultManagementService)
        Try
            Dim wDt As New DataTable
            wDt = GetWebApplicationList()
            ws.SendWebAppInfoToDC(ComputerName, IPAddress, wDt, MacAddress)
            wDt.Dispose()
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmMain", "WebMonitor", ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Function GetWebApplicationList() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("SiteName")
        dt.Columns.Add("WebApplicationName")
        dt.Columns.Add("ApplicationPool")
        dt.Columns.Add("ApplicationStatus")
        Try
            Dim mgr As New Microsoft.Web.Administration.ServerManager()
            For Each WebSite As Microsoft.Web.Administration.Site In mgr.Sites
                For Each WebApp As Microsoft.Web.Administration.Application In WebSite.Applications
                    If Replace(WebApp.Path, "/", "") <> "" Then
                        Dim applState
                        applState = mgr.ApplicationPools(WebApp.ApplicationPoolName).State

                        Dim dr As DataRow = dt.NewRow
                        dr("SiteName") = WebSite.Name
                        dr("WebApplicationName") = Replace(WebApp.Path, "/", "")
                        dr("ApplicationPool") = Replace(WebApp.ApplicationPoolName, "/", "")
                        dr("ApplicationStatus") = applState
                        dt.Rows.Add(dr)
                    End If
                Next
            Next
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmMain", "GetWebApplicationList", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        dt.TableName = "GetWebApplicationList"
        Return dt
    End Function

    Private Sub SendFileSizeInfo(ws As FaultManagementService.FaultManagementService)
        Try
            Dim dt As New DataTable
            dt = ws.GetConfigFileSizeList(MacAddress)
            If dt.Rows.Count > 0 Then
                Dim FileSizeDT As New DataTable
                FileSizeDT.Columns.Add("FileName")
                FileSizeDT.Columns.Add("FileSizeGB", GetType(Double))

                For Each dr As DataRow In dt.Rows
                    If File.Exists(dr("FileName")) = True Then
                        Dim ff As New FileInfo(dr("FileName"))

                        Dim fDr As DataRow = FileSizeDT.NewRow
                        fDr("FileName") = ff.FullName
                        fDr("FileSizeGB") = Math.Round(ff.Length / (1024 ^ 3), 2)
                        FileSizeDT.Rows.Add(fDr)
                        ff = Nothing
                    End If
                Next

                Try
                    FileSizeDT.TableName = "FileSizeDT"
                    ws.SendFileSizeInfoToDC(ComputerName, IPAddress, FileSizeDT, MacAddress)
                Catch ex As Exception
                    FunctionEng.CreateErrorLog("frmMain", "SendFileSizeInfo", ex.Message & vbNewLine & ex.StackTrace)
                End Try
                FileSizeDT.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub ProcessFileSizeAlarm(ByVal awDT As DataTable, ByVal conf As Engine.Config.FileConfigENG, ByVal CheckSeverity As String, ByVal eng As InfoClass.FileListInfo, ByVal FileSizeUse As Double, ByVal AlarmMethod As String, ByVal ValueOver As Double, ByVal AlarmCode As String, ByVal ff As FileInfo)
    '    Dim AlarmDesc As String = "The DATAFILESIZE " & ff.FullName & " at " & ff.Directory.Root.Name & " on " & conf.ServerName & " usage over " & ValueOver
    '    Dim dt As New DataTable
    '    dt = eng.GetFileSizePendingAlarm(conf.ServerName, CheckSeverity, ff.FullName)
    '    If dt.Rows.Count < (Convert.ToInt16(conf.RepeateCheck) - 1) Then
    '        awDT.DefaultView.RowFilter = "Severity<>'" & CheckSeverity & "'"
    '        If awDT.DefaultView.Count > 0 Then
    '            For Each awDR As DataRowView In awDT.DefaultView
    '                eng.SendClearAlarm(conf.ServerName, conf.ServerName & "_DATAFILESIZE_" & ff.FullName, conf.IPAddress, conf.AlarmType, conf.ServerName & "_DATAFILESIZE_" & ff.FullName, awDR("Severity"), FileSizeUse, "ALM_DATAFILESIZE_" & awDR("Severity") & " is Clear", awDR("AlarmMethod"), "FileSize_" & ff.FullName, "")
    '            Next
    '        End If
    '        eng.CreateFileSizePendingAlarm(conf, CheckSeverity, AlarmDesc, "1", AlarmMethod, ff.FullName)
    '    Else

    '        awDT.DefaultView.RowFilter = "Severity='" & CheckSeverity & "'"
    '        If awDT.DefaultView.Count = 0 Then
    '            If eng.CreateAlarmWaitingClear(conf.ServerName, conf.IPAddress, CheckSeverity, FileSizeUse, AlarmMethod, "FileSize_" & ff.FullName, AlarmDesc, AlarmCode, conf.ServerName & "_DATAFILESIZE_" & ff.FullName) > 0 Then
    '                eng.DeleteFileSizePendingAlarm(conf.ServerName, ff.FullName)
    '            End If
    '            eng.SendAlarm(conf.ServerName, conf.ServerName & "_DATAFILESIZE_" & ff.FullName, conf.IPAddress, conf.AlarmType, conf.ServerName & "_DATAFILESIZE_" & ff.FullName, CheckSeverity, FileSizeUse, AlarmDesc, AlarmMethod, "FileSize_" & ff.FullName)
    '        Else
    '            If eng.UpdateAlarmWaitingClear(conf.ServerName, conf.IPAddress, CheckSeverity, FileSizeUse, AlarmMethod, "FileSize_" & ff.FullName, AlarmDesc, awDT.DefaultView(0)("id")) = True Then
    '                eng.DeleteFileSizePendingAlarm(conf.ServerName, ff.FullName)
    '            End If
    '        End If
    '        awDT.DefaultView.RowFilter = ""
    '    End If
    '    dt.Dispose()
    'End Sub


    'Dim FileLostInterval As Integer = 0
    'Dim FileLostLastMonitorTime As DateTime = DateTime.Now
    'Private Sub FileLostMonitor()
    '    If DateAdd(DateInterval.Minute, FileLostInterval, FileLostLastMonitorTime) < DateTime.Now Then
    '        Dim eng As New InfoClass.FileListInfo
    '        Dim FileLostConfigFile As String = Application.StartupPath & "\Config\" & Environment.MachineName & "_CONFIG_DATAFILELOST.xml"
    '        If File.Exists(FileLostConfigFile) = True Then
    '            Dim conf As New Engine.Config.FileConfigENG
    '            conf.GetFileLostConfigFromXML(FileLostConfigFile)
    '            If conf.CheckAlarmWithTimeConfig(conf.AlamDateList, conf.AllDayEvent, conf.AlamTimeFrom, conf.AlamTimeTo) = True Then
    '                Dim dt As New DataTable
    '                dt = conf.ConfigFileList
    '                If dt.Rows.Count > 0 Then
    '                    For Each dr As DataRow In dt.Rows
    '                        Dim FileName As String = dr("FileName").ToString
    '                        If dr("Active").ToString = "Y" Then
    '                            Dim awDt As New DataTable
    '                            awDt = eng.GetAlarmWaitingClear(Environment.MachineName, "FileLost_" & dr("FileName"), "Alarm")
    '                            If File.Exists(FileName) = False Then
    '                                'Dim ff As New FileInfo(dr("FileName"))
    '                                Dim AlarmCode As String = conf.ServerName & "_FILECONFIG_" & FileName & "_" & FileName.Substring(0, 2)
    '                                Dim AlarmDesc As String = "The FILE CONFIG " & FileName & " at " & FileName.Substring(0, 2) & " on " & conf.ServerName & " is lost"
    '                                Dim pdDt As New DataTable
    '                                pdDt = eng.GetFileLostPendingAlarm(conf.ServerName, "CRITICAL", FileName)
    '                                If pdDt.Rows.Count < (Convert.ToInt16(conf.RepeateCheck) - 1) Then
    '                                    awDt.DefaultView.RowFilter = "Severity<>'CRITICAL'"
    '                                    If awDt.DefaultView.Count > 0 Then
    '                                        For Each awDR As DataRowView In awDt.DefaultView
    '                                            eng.SendClearAlarm(conf.ServerName, conf.ServerName & "_FILECONFIG_" & FileName, conf.IPAddress, conf.AlarmType, conf.ServerName & "_FILECONFIG_" & FileName, awDR("Severity"), 0, "ALM_FILECONFIG_" & awDR("Severity") & " is Clear", awDR("AlarmMethod"), "FileLost_" & FileName, "")
    '                                        Next
    '                                    End If
    '                                    eng.CreateFileLostPendingAlarm(conf, "CRITICAL", AlarmDesc, "1", conf.AlarmMethod, FileName)
    '                                Else
    '                                    awDt.DefaultView.RowFilter = "Severity='CRITICAL'"
    '                                    If awDt.DefaultView.Count = 0 Then
    '                                        If eng.CreateAlarmWaitingClear(conf.ServerName, conf.IPAddress, "CRITICAL", 0, conf.AlarmMethod, "FileLost_" & FileName, AlarmDesc, AlarmCode, conf.ServerName & "_FILECONFIG_" & FileName) > 0 Then
    '                                            eng.DeleteFileLostPendingAlarm(conf.ServerName, FileName)
    '                                        End If
    '                                        eng.SendAlarm(conf.ServerName, conf.ServerName & "_FILECONFIG_" & FileName, conf.IPAddress, conf.AlarmType, conf.ServerName & "_FILECONFIG_" & FileName, "CRITICAL", 0, AlarmDesc, conf.AlarmMethod, "FileLost_" & FileName)
    '                                    Else
    '                                        If eng.UpdateAlarmWaitingClear(conf.ServerName, conf.IPAddress, "CRITICAL", 0, conf.AlarmMethod, "FileLost_" & FileName, AlarmDesc, awDt.DefaultView(0)("id")) = True Then
    '                                            eng.DeleteFileLostPendingAlarm(conf.ServerName, FileName)
    '                                        End If
    '                                    End If
    '                                    awDt.DefaultView.RowFilter = ""
    '                                End If
    '                                pdDt.Dispose()
    '                            Else
    '                                If awDt.Rows.Count > 0 Then
    '                                    Dim awDr As DataRow = awDt.Rows(0)
    '                                    Dim sw As New InfoClass.SoftwareInfo
    '                                    sw.SendClearAlarm(conf.ServerName, conf.ServerName & "_FILECONFIG_" & FileName, conf.IPAddress, conf.AlarmType, conf.ServerName & "_DATAFILESIZE_", awDr("Severity"), 0, "ALM_FILECONFIG_LOST is Clear", conf.AlarmMethod, "FileLost_" & FileName, "")
    '                                    sw = Nothing
    '                                End If
    '                            End If
    '                            awDt.Dispose()
    '                        End If
    '                    Next
    '                End If
    '                dt.Dispose()
    '                FileLostInterval = conf.IntervalMinute
    '                FileLostLastMonitorTime = DateTime.Now
    '            End If
    '        End If
    '        eng = Nothing
    '    End If
    'End Sub

    Private Sub SendFileLostInfo(ws As FaultManagementService.FaultManagementService)
        Try
            Dim dt As New DataTable
            dt = ws.GetConfigFileLostList(MacAddress)

            If dt.Rows.Count > 0 Then
                Dim FileLostDT As New DataTable
                FileLostDT.Columns.Add("FileName")
                FileLostDT.Columns.Add("FileLostStatus")

                For Each dr As DataRow In dt.Rows
                    Dim FileLostDr As DataRow = FileLostDT.NewRow
                    FileLostDr("FileName") = dr("FileName")
                    If File.Exists(dr("FileName")) = False Then
                        FileLostDr("FileLostStatus") = "N"
                    Else
                        FileLostDr("FileLostStatus") = "Y"
                    End If
                    FileLostDT.Rows.Add(FileLostDr)
                Next
                Dim re As Boolean = False
                Try
                    FileLostDT.TableName = "FileLostDT"
                    re = ws.SendFileLostInfoToDC(ComputerName, IPAddress, FileLostDT, MacAddress)
                Catch ex As Exception
                    FunctionEng.CreateErrorLog("frmMain", "SendFileLostInfo", ex.Message & vbNewLine & ex.StackTrace)
                End Try

                FileLostDT.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try
    End Sub


    Dim ImaAliveInterval As Integer = 0
    Dim ImaAliveMonitorTime As DateTime = DateTime.Now
    Private Sub SendAliveInfo()
        Try
            If DateAdd(DateInterval.Minute, ImaAliveInterval, ImaAliveMonitorTime) < DateTime.Now Then
                Dim ini As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\Config.ini")
                ini.Section = "ConfigAlive"

                Dim cfgIntervelMinute As Integer = IIf(ini.ReadString("IntervalMinute") = "", 0, ini.ReadString("IntervalMinute"))
                Dim AliveStartTime As String = ini.ReadString("StartTime")
                Dim AliveEndTime As String = ini.ReadString("EndTime")
                Dim vDateNow As DateTime = DateTime.Now
                Dim vTimeNow As String = vDateNow.ToString("HH:mm")
                'If vTimeNow >= AliveStartTime And vTimeNow <= AliveEndTime Then
                ini.Section = "Setting"
                Try
                    Dim ws As New FaultManagementService.FaultManagementService
                    ws.Url = ini.ReadString("FaultWebserviceURL")
                    ws.SendImAlive(ComputerName, IPAddress, MacAddress, cfgIntervelMinute, AliveStartTime, AliveEndTime, vDateNow)
                    ws = Nothing
                Catch ex As Exception

                End Try
                'End If
                ini = Nothing
                ImaAliveInterval = cfgIntervelMinute
                ImaAliveMonitorTime = DateTime.Now
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Config Zone"

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
            NotifyIcon1.Text = "Fault Management V" & getMyVersion()
        Else
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Function getMyVersion() As String
        Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly.GetName().Version
        Return version.Major & "." & version.Minor & "." & version.Build & "." & version.Revision
    End Function

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Try

            Me.Text = "Fault Management V" & getMyVersion()
            tmSendInfo.Start()
            Me.WindowState = FormWindowState.Minimized

        Catch ex As Exception

        End Try
    End Sub

    Public Shared ReadOnly Property ExistedWebsites() As String()
        Get
            Dim ret As New List(Of String)()

            ' get directory service
            Dim Services As New DirectoryEntry("IIS://localhost/W3SVC")
            Dim ie As IEnumerator = Services.Children.GetEnumerator()
            Dim Server As DirectoryEntry = Nothing

            ' find iis website
            While ie.MoveNext()
                Server = DirectCast(ie.Current, DirectoryEntry)
                If Server.SchemaClassName = "IIsWebServer" Then
                    ' "ServerComment" means name

                    ret.Add(Server.Properties("ServerComment")(0).ToString())
                End If
            End While

            Return ret.ToArray()
        End Get
    End Property
#End Region

    Private Sub tmSendInfo_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmSendInfo.Tick
        tmSendInfo.Enabled = False
        Try
            Me.Text = "Fault Management V" & getMyVersion() & "  Last Refresh Time :" & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", New Globalization.CultureInfo("en-US"))

            Dim ini As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\Config.ini")
            ini.Section = "Setting"
            Dim ws As New FaultManagementService.FaultManagementService
            ws.Timeout = 20000
            ws.Url = ini.ReadString("FaultWebserviceURL")

            Dim cThe As New Threading.Thread(AddressOf SendCPUInfo)
            cThe.Start(ws)
            'SendCPUInfo(ws)

            Dim rThe As New Threading.Thread(AddressOf SendRamInfo)
            rThe.Start(ws)
            'SendRamInfo(ws)

            Dim dThe As New Threading.Thread(AddressOf SendDriveInfo)
            dThe.Start(ws)
            'SendDriveInfo(ws)

            Dim sThe As New Threading.Thread(AddressOf SendServiceInfo)
            sThe.Start(ws)
            'SendServiceInfo(ws)

            Dim pThe As New Threading.Thread(AddressOf SendProcessInfo)
            pThe.Start(ws)
            'SendProcessInfo(ws)

            Dim fsThe As New Threading.Thread(AddressOf SendFileSizeInfo)
            fsThe.Start(ws)
            SendFileSizeInfo(ws)

            Dim flThe As New Threading.Thread(AddressOf SendFileLostInfo)
            flThe.Start(ws)
            'SendFileLostInfo(ws)

            ''WebMonitor(ws)
            ws = Nothing
            ini = Nothing
        Catch ex As Exception

        End Try
        tmSendInfo.Enabled = True
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub tmCheckAlive_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmCheckAlive.Tick
        Try
            tmCheckAlive.Enabled = False
            'Dim nThread As New System.Threading.Thread(AddressOf SendAliveInfo)
            'nThread.Start()
            SendAliveInfo()

            tmCheckAlive.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetFileListRootPath(LoadTempPathID As Long) As DataTable
        Dim dt As New DataTable
        Try
            dt.Columns.Add("LoadTempPathID", GetType(Long))
            dt.Columns.Add("ServerIP", GetType(String))
            dt.Columns.Add("PathFile", GetType(String))
            dt.Columns.Add("DisplayType", GetType(String))
            dt.Columns.Add("FileSizeGB", GetType(String))

            Dim dInf As New Engine.Info.DriveInfoENG
            Dim tmpDrive As DataTable = dInf.GetDriveInfoToDT
            If tmpDrive.Rows.Count > 0 Then
                For Each tmpDr As DataRow In tmpDrive.Rows
                    Dim RootPath As String = tmpDr("DriveLetter") & ":\"

                    'Get All Directory at Root Path
                    For Each d As String In Directory.GetDirectories(RootPath)
                        Dim dr As DataRow = dt.NewRow
                        dr("LoadTempPathID") = LoadTempPathID
                        dr("ServerIP") = IPAddress
                        dr("PathFile") = d
                        dr("DisplayType") = "D"
                        dt.Rows.Add(dr)
                    Next

                    'Get All File at Root Path
                    For Each f As String In Directory.GetFiles(RootPath)
                        Dim fInfo As New FileInfo(f)

                        Dim dr As DataRow = dt.NewRow
                        dr("LoadTempPathID") = LoadTempPathID
                        dr("ServerIP") = IPAddress
                        dr("PathFile") = f
                        dr("DisplayType") = "F"
                        dr("FileSizeGB") = Convert.ToDouble(fInfo.Length / (1024 ^ 3)).ToString("#,##0.00")
                        dt.Rows.Add(dr)
                    Next
                Next
            End If
            tmpDrive.Dispose()
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Private Sub FileSizeCheckListFile(ws As FaultManagementService.FaultManagementService)
        Dim dt As New DataTable
        Dim _dt As New DataTable
        Try
            dt = ws.GetLoadTempPath(IPAddress)
            If dt.Rows.Count > 0 Then
                _dt.Columns.Add("LoadTempPathID", GetType(Long))
                _dt.Columns.Add("ServerIP", GetType(String))
                _dt.Columns.Add("PathFile", GetType(String))
                _dt.Columns.Add("DisplayType", GetType(String))
                _dt.Columns.Add("FileSizeGB", GetType(String))

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim dr As DataRow = dt.Rows(i)
                    If dr("PathFile") = "ROOT" Then
                        _dt = GetFileListRootPath(dr("id"))
                    Else
                        Dim PathFile As String = dr("PathFile")
                        If PathFile.EndsWith("\") = False Then
                            PathFile += "\"
                        End If

                        If Directory.Exists(PathFile) = True Then
                            For Each d As String In Directory.GetDirectories(PathFile)
                                Dim tdr As DataRow = _dt.NewRow
                                tdr("LoadTempPathID") = dr("id")
                                tdr("ServerIP") = IPAddress
                                tdr("PathFile") = d
                                tdr("DisplayType") = "D"
                                _dt.Rows.Add(tdr)
                            Next

                            For Each f As String In Directory.GetFiles(PathFile)
                                Dim fInfo As New FileInfo(f)

                                Dim tdr As DataRow = _dt.NewRow
                                tdr("LoadTempPathID") = dr("id")
                                tdr("ServerIP") = IPAddress
                                tdr("PathFile") = f
                                tdr("DisplayType") = "F"
                                tdr("FileSizeGB") = Convert.ToDouble(fInfo.Length / (1024 ^ 3)).ToString("#,##0.00")
                                _dt.Rows.Add(tdr)
                            Next
                        End If
                    End If

                    _dt.TableName = "TempFile"
                    ws.SendTempFile(_dt, dr("id"))
                Next
            End If
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmFaultManagement", "FileSizeCheckListFile", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tmGetTempFile_Tick(sender As Object, e As EventArgs) Handles tmGetTempFile.Tick
        tmGetTempFile.Enabled = False
        Try
            Dim ini As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\Config.ini")
            ini.Section = "Setting"
            Dim ws As New FaultManagementService.FaultManagementService
            ws.Timeout = 20000
            ws.Url = ini.ReadString("FaultWebserviceURL")
            FileSizeCheckListFile(ws)
            ws = Nothing
            ini = Nothing
        Catch ex As Exception
            FunctionEng.CreateErrorLog("frmFaultManagement", "tmGetTempFile_Tick", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        tmGetTempFile.Enabled = True
    End Sub

    Private Shared Function GetIPAddress() As String
        Dim ini As New Org.Mentalis.Files.IniReader(Application.StartupPath & "\Config.ini")
        ini.Section = "Setting"

        Dim IP As String = ini.ReadString("IPAddress")
        If IP.Trim = "" Then
            Dim oAddr As System.Net.IPAddress
            'Dim sAddr As String
            With System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName())
                oAddr = New System.Net.IPAddress(.AddressList(0).Address)
                IP = oAddr.ToString
            End With
        End If
        ini = Nothing
        Return IP
    End Function
End Class