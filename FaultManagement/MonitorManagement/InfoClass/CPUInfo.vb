Imports System.IO
Imports System.Xml
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace InfoClass
    Public Class CPUInfo
        Inherits HardwareInfo
        Public Function GetCPUInfo() As DataTable
            Dim ret As New DataTable
            ret.Columns.Add("ServerName")
            ret.Columns.Add("CPUPercentUsage")
            ret.Columns.Add("CPUConfigFileName")
            ret.Columns.Add("LastMonitorTime", GetType(DateTime))

            Dim ini As New MonitorManagement.Org.Mentalis.Files.IniReader(Application.StartupPath & "\Config.ini")
            ini.Section = "Setting"
            Dim FMMonitorFolder As String = ini.ReadString("FMMonitorFolder")
            If Directory.Exists(FMMonitorFolder) = False Then
                Directory.CreateDirectory(FMMonitorFolder)
            End If

            For Each f As String In IO.Directory.GetFiles(FMMonitorFolder, "*CPU_PROCESS.xml")
                Dim fInfo As New FileInfo(f)
                Dim ff() As String = Split(fInfo.Name, "_")
                Dim ServerName As String = ff(0)

                Dim xml As New XmlDocument
                xml.Load(f)
                Dim CPUPercent As Xml.XmlNodeList = xml.GetElementsByTagName("PercentUsage")
                If CPUPercent.Item(0).InnerXml <> "" Then
                    Dim dr As DataRow = ret.NewRow
                    dr("ServerName") = ServerName
                    dr("CPUPercentUsage") = CPUPercent.Item(0).InnerText
                    dr("CPUConfigFileName") = ini.ReadString("FMConfigFolder") & ServerName & "_CONFIG_CPU_PROCESS.xml"
                    dr("LastMonitorTime") = fInfo.LastWriteTime
                    ret.Rows.Add(dr)
                End If
                xml = Nothing
                fInfo = Nothing

                File.Delete(f)
            Next
            ini = Nothing

            Return ret
        End Function

        Public Sub CreateCPUPendingAlarm(MacAddress As String, ByVal Severity As String)
            MyBase.CreatePendingAlarm("CPU", MacAddress, Severity)
        End Sub

        Private Function GetCPUPendingAlarm(ByVal ServerName As String, ByVal Severity As String) As DataTable
            Return MyBase.GetPendingAlarm("CPU", ServerName, Severity)
        End Function

        Public Sub DeleteCPUPendingAlarm(ByVal MacAddress As String)
            MyBase.DeletePendingAlarm("CPU", MacAddress)
        End Sub




        Public Shared Function GetCPUInfo(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New CfConfigCpuLinqDB

            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String = "select id,ServerName ,ServerIP ,MacAddress ,CPUPercent  from TB_CPU_INFO where 1=1"
            sql += wh
            dt = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing
            Return dt
        End Function

        Public Function GetCPUcf(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigCpuLinqDB


            If wh <> "" Then
                wh = "and " & wh
            End If

            Dim sql As String = "select id,ServerName ,ServerIP ,MacAddress ,CheckIntervalMinute,AlarmMinorValue ,AlarmMajorValue ,AlarmCriticalValue,ActiveStatus,RepeatCheckMinor,RepeatCheckMajor,RepeatCheckCritical "
            sql += "from CF_CONFIG_CPU where ActiveStatus = 'Y' "
            sql += wh

            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function GetRegister(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String = "select id,ServerName ,ServerIP ,MacAddress,E_mail,LocationServer + '/'+LocationNo as SysLocation from TB_REGISTER where 1=1" & wh

            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function GetCountCPU(ByVal wh As String, ByVal Severity As String, ByVal Macaddress As String) As DataTable

            Dim trans As New TransactionDB
            Dim lnq As New CfConfigCpuLinqDB
            Dim dt As New DataTable

            If Severity <> "" Then
                Dim sql As String
                sql = "select ActivityPendingAlarmID,ServerIP,Severity from TB_ACTIVITY_PENDING_ALARM where ServerIP ='" & wh & "'and Severity !='" & Severity & " 'and AlarmActivity='CPU' "
                dt = lnq.GetListBySql(sql, trans.Trans)
            Else
                Dim _sql As String
                _sql = "select ActivityPendingAlarmID,ServerIP,Severity from TB_ACTIVITY_PENDING_ALARM where ServerIP ='" & wh & "'and AlarmActivity='CPU'"
                dt = lnq.GetListBySql(_sql, trans.Trans)
            End If


            If dt.Rows.Count > 0 Then

                Dim ret As Boolean = False
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim Delid As String
                    Dim Dellnq As New TbActivityPendingAlarmLinqDB
                    Dim tran As New TransactionDB
                    Delid = dt.Rows(i)("ActivityPendingAlarmID").ToString()
                    ret = Dellnq.DeleteByPK(Delid, tran.Trans)
                    If ret = True Then
                        tran.CommitTransaction()
                    Else
                        tran.RollbackTransaction()
                    End If
                Next


            End If


            Status_TB_ALARM_WAITING_CLEAR(wh, Severity, Macaddress)

            Dim sqlRepeatChk As String = "select ActivityPendingAlarmID,ServerIP,Severity from TB_ACTIVITY_PENDING_ALARM "
            sqlRepeatChk += "where ServerIP = '" & wh & "' and Severity = '" & Severity & "'and AlarmActivity='CPU'"
            Dim dtRepeatChk As DataTable = lnq.GetListBySql(sqlRepeatChk, trans.Trans)

            Return dtRepeatChk

        End Function

        Public Sub Status_TB_ALARM_WAITING_CLEAR(ByVal ip As String, ByVal Severity As String, ByVal Macaddress As String)
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            If Severity = "" Then
                Dim sql As String = "select id ,ServerName,HostIP,AlarmActivity,Severity,SpecificProblem,AlarmValue from TB_ALARM_WAITING_CLEAR"
                sql += " where HostIP = '" & ip & "' and FlagAlarm = 'Alarm'and AlarmActivity='CPU'"
                dt = lnq.GetListBySql(sql, trans.Trans)
            Else
                Dim sql As String = "select id ,ServerName,HostIP,AlarmActivity,Severity,SpecificProblem,AlarmValue from TB_ALARM_WAITING_CLEAR"
                sql += " where HostIP = '" & ip & "' and FlagAlarm = 'Alarm' and Severity != '" & Severity & "'and AlarmActivity='CPU'"
                dt = lnq.GetListBySql(sql, trans.Trans)
            End If



            If dt.Rows.Count > 0 Then
                Dim _sql As String
                _sql = "UPDATE TB_ALARM_WAITING_CLEAR SET FlagAlarm = 'Clear',ClearDate = '" & DateTime.Now & "'"
                _sql += " where id= '" & dt.Rows(0)(0).ToString() & "'and AlarmActivity='CPU'"
                SqlDB.ExecuteNonQuery(_sql)
                SaveAlarmLog(dt.Rows(0)("ServerName").ToString, dt.Rows(0)("HostIP").ToString, dt.Rows(0)("Severity").ToString, dt.Rows(0)("AlarmValue").ToString, dt.Rows(0)("id").ToString, Macaddress)
            End If


        End Sub

        Public Sub SaveAlarmLog(ByVal servername As String, ByVal HostIP As String, ByVal Severity As String, ByVal CurrentValue As String, ByVal AlarmWaitingClearID As String, ByVal Macaddress As String)
            Dim sql As String
            sql = "insert into TB_ALARM_LOG (AlarmActivity,CreateDate,ServerName,HostIP,Severity ,CurrentValue,AlarmMethod,FlagAlarm,AlarmWaitingClearID ,MacAddress)"
            sql += "values('CPU','" & DateTime.Now & "','" & servername & "','" & HostIP & "','" & Severity & "','" & CurrentValue & "','E-mail','Clear','" & AlarmWaitingClearID & "','" & Macaddress & "')"
            SqlDB.ExecuteNonQuery(sql)
        End Sub


        Public Shared Function GetdtWAITING_CLEAR(ByVal MacAddress As String)
            Dim dt As New DataTable
            Dim lnq As New TbAlarmWaitingClearLinqDB
            dt = lnq.GetDataList("MacAddress ='" & MacAddress & "' and FlagAlarm = 'Alarm' and AlarmActivity='CPU'", "", Nothing)
            lnq = Nothing
            Return dt
        End Function


        Public Sub ProcessCPUAlarm(ByVal awDT As DataTable, ByVal cf As CfConfigCpuLinqDB, ByVal CheckSeverity As String, CheckValue As String, RepeatCheck As Int16, info As TbCpuInfoLinqDB, ByVal CPUPercentUsage As Double, ByVal AlarmMethod As String)
            awDT.DefaultView.RowFilter = "Severity<>'" & CheckSeverity & "'"
            If awDT.DefaultView.Count > 0 Then
                For Each awDR As DataRowView In awDT.DefaultView
                    Dim SpecificProblem As String = cf.SERVERNAME & " CPU Usage " & awDR("Severity") & " is Clear"
                    SendClearAlarm(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, awDR("Severity"), CPUPercentUsage, AlarmMethod, "CPU", SpecificProblem, awDT.DefaultView(0)("id"))
                Next
            End If

            Dim dt As New DataTable
            dt = GetCPUPendingAlarm(cf.MACADDRESS, CheckSeverity)
            If dt.Rows.Count < (RepeatCheck - 1) Then
                CreateCPUPendingAlarm(cf.MACADDRESS, CheckSeverity)
            Else
                Dim SpecificProblem As String = cf.SERVERNAME & " CPU Usage is " & CPUPercentUsage & "% over than " & CheckValue & "% " & CheckSeverity
                awDT.DefaultView.RowFilter = "Severity='" & CheckSeverity & "'"
                If awDT.DefaultView.Count = 0 Then
                    If InsertAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, CheckSeverity, CPUPercentUsage, "CPU", AlarmMethod, SpecificProblem) > 0 Then
                        DeleteCPUPendingAlarm(cf.MACADDRESS)
                    End If
                Else
                    If UpdateAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, CheckSeverity, CPUPercentUsage, "CPU", AlarmMethod, SpecificProblem, awDT.DefaultView(0)("id")) = True Then
                        DeleteCPUPendingAlarm(cf.MACADDRESS)
                    End If
                End If
                awDT.DefaultView.RowFilter = ""
            End If
            dt.Dispose()
        End Sub


        Public Function IDAlarmWaitingClear(ByVal ip As String) As String
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB

            Dim _sql As String = "select MAX (id) from TB_ALARM_WAITING_CLEAR where HostIP ='" & ip & "'and AlarmActivity='CPU'"
            dt = lnq.GetListBySql(_sql, trans.Trans)

            Dim id As String = dt.Rows(0)(0).ToString()
            Return ID
        End Function


        Public Sub CheckCPU(ByVal ip As String, ByVal MacAddress As String)
            Dim dtPand As New DataTable
            Dim dtWaiting As New DataTable

            dtPand = Panding(ip)
            If dtPand.Rows.Count > 0 Then
                Dim ret As Boolean = False
                For i As Integer = 0 To dtPand.Rows.Count - 1
                    Dim Delid As String
                    Dim Dellnq As New TbActivityPendingAlarmLinqDB
                    Dim tran As New TransactionDB
                    Delid = dtPand.Rows(i)("ActivityPendingAlarmID").ToString()
                    ret = Dellnq.DeleteByPK(Delid, tran.Trans)
                    If ret = True Then
                        tran.CommitTransaction()
                    Else
                        tran.RollbackTransaction()
                    End If
                Next
            End If
            dtWaiting = Waiting(ip)
            If dtWaiting.Rows.Count > 0 Then
                Dim id As String = dtWaiting.Rows(0)(0).ToString()
                Dim sql As String
                sql = "UPDATE TB_ALARM_WAITING_CLEAR SET FlagAlarm = 'Clear',ClearDate = '" & DateTime.Now & "'"
                sql += " where id= '" & id & "' and AlarmActivity = 'CPU'"
                SqlDB.ExecuteNonQuery(sql)
                SaveAlarmLog(dtWaiting.Rows(0)("ServerName").ToString, dtWaiting.Rows(0)("HostIP").ToString, dtWaiting.Rows(0)("Severity").ToString, dtWaiting.Rows(0)("AlarmValue").ToString, dtWaiting.Rows(0)("id").ToString, MacAddress)
            End If

        End Sub

        Public Function Panding(ByVal ip As String) As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbActivityPendingAlarmLinqDB
            Dim dt As New DataTable

            Dim sql As String = "select * from TB_ACTIVITY_PENDING_ALARM where AlarmActivity ='CPU' and ServerIP ='" & ip & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function Waiting(ByVal ip As String) As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            Dim dt As New DataTable

            Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR where AlarmActivity ='CPU' and FlagAlarm = 'Alarm' and HostIP  ='" & ip & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function GetConfigTime(ByVal wh As String) As DataTable
            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String = "select * from CF_CONFIG_CPU  where 1=1"
            sql += wh

            Dim dt As New DataTable
            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                dt.Columns.Add("CheckAlarmWithTimeConfig", GetType(Boolean))
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("CheckAlarmWithTimeConfig") = CheckAlarmWithTimeConfig(dt.Rows(i))
                Next
            End If

            Return dt
        End Function
        Private Function CheckAlarmWithTimeConfig(ByVal dr As DataRow) As Boolean
            Dim ret As Boolean = False
            Dim vDateNow As DateTime = DateTime.Now
            Dim CaseDay As Integer = DatePart(DateInterval.Weekday, vDateNow)
            Select Case CaseDay
                Case 1
                    ret = (Convert.ToString(dr("AlarmSun")) = "Y")
                Case 2
                    ret = (Convert.ToString(dr("AlarmMon")) = "Y")
                Case 3
                    ret = (Convert.ToString(dr("AlarmTue")) = "Y")
                Case 4
                    ret = (Convert.ToString(dr("AlarmWed")) = "Y")
                Case 5
                    ret = (Convert.ToString(dr("AlarmThu")) = "Y")
                Case 6
                    ret = (Convert.ToString(dr("AlarmFri")) = "Y")
                Case 7
                    ret = (Convert.ToString(dr("AlarmSat")) = "Y")
            End Select

            If ret = True Then
                If Convert.ToString(dr("AllDayEvent")) = "N" Then
                    If Convert.ToString(dr("AlarmTimeFrom")) <> "" And Convert.ToString(dr("AlarmTimeTo")) <> "" Then
                        If Convert.ToString(dr("AlarmTimeFrom")) <= vDateNow.ToString("HH:mm") And vDateNow.ToString("HH:mm") <= Convert.ToString(dr("AlarmTimeTo")) Then
                            ret = True
                        Else
                            ret = False
                        End If
                    Else
                        ret = False
                    End If

                Else
                    If Convert.ToString(dr("AllDayEvent")) = "Y" Then
                        ret = True
                    Else
                        ret = False
                    End If

                End If
            Else
                If Convert.ToString(dr("AllDayEvent")) = "Y" Then
                    ret = True
                Else
                    ret = False
                End If
            End If

            Return ret
        End Function


    End Class
End Namespace

