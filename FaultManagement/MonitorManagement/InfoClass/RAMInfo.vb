Imports System.IO
Imports System.Xml
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace InfoClass
    Public Class RAMInfo
        Inherits HardwareInfo

        'Public Function GetRAMMonitorFile() As DataTable
        '    Dim ret As New DataTable
        '    ret.Columns.Add("ServerName")
        '    ret.Columns.Add("RAMPercentUsage", GetType(Double))
        '    ret.Columns.Add("RAMConfigFileName")
        '    ret.Columns.Add("LastMonitorTime", GetType(DateTime))

        '    Dim ini As New MonitorManagement.Org.Mentalis.Files.IniReader(Application.StartupPath & "\Config.ini")
        '    ini.Section = "Setting"
        '    Dim FMMonitorFolder As String = ini.ReadString("FMMonitorFolder")
        '    If Directory.Exists(FMMonitorFolder) = False Then
        '        Directory.CreateDirectory(FMMonitorFolder)
        '    End If

        '    For Each f As String In IO.Directory.GetFiles(FMMonitorFolder, "*RAM_PROCESS.xml")
        '        Dim fInfo As New FileInfo(f)
        '        Dim ff() As String = Split(fInfo.Name, "_")
        '        Dim ServerName As String = ff(0)

        '        Dim xml As New XmlDocument
        '        xml.Load(f)
        '        Dim RAMPercent As Xml.XmlNodeList = xml.GetElementsByTagName("PercentUsageGB")
        '        If RAMPercent.Item(0).InnerXml <> "" Then
        '            Dim dr As DataRow = ret.NewRow
        '            dr("ServerName") = ServerName
        '            dr("RAMPercentUsage") = RAMPercent.Item(0).InnerText
        '            dr("RAMConfigFileName") = ini.ReadString("FMConfigFolder") & ServerName & "_CONFIG_RAM_PROCESS.xml"
        '            dr("LastMonitorTime") = fInfo.LastWriteTime
        '            ret.Rows.Add(dr)
        '        End If
        '        xml = Nothing
        '        fInfo = Nothing

        '        File.Delete(f)
        '    Next
        '    ini = Nothing

        '    Return ret
        'End Function


        Public Sub CreateRAMPendingAlarm(MacAddress As String, ByVal Severity As String)
            MyBase.CreatePendingAlarm("RAM", MacAddress, Severity)
        End Sub

        Public Function GetRAMPendingAlarm(ByVal MacAddress As String, ByVal Severity As String) As DataTable
            Return MyBase.GetPendingAlarm("RAM", MacAddress, Severity)
        End Function

        Public Sub DeleteRAMPendingAlarm(ByVal MacAddress As String)
            MyBase.DeletePendingAlarm("RAM", MacAddress)
        End Sub


        'Public Function GetRamcf(ByVal wh As String) As DataTable
        '    Dim dt As New DataTable
        '    Dim trans As New TransactionDB
        '    Dim lnq As New CfConfigRamLinqDB

        '    If wh <> "" Then
        '        wh = "and " & wh
        '    End If

        '    Dim sql As String = "select id,ServerName ,ServerIP ,MacAddress ,CheckIntervalMinute,AlarmMinorValue ,AlarmMajorValue ,AlarmCriticalValue,ActiveStatus,RepeatCheckMinor,RepeatCheckMajor,RepeatCheckCritical "
        '    sql += "from CF_CONFIG_RAM  where ActiveStatus = 'Y' "
        '    sql += wh

        '    dt = lnq.GetListBySql(sql, trans.Trans)

        '    Return dt
        'End Function

        Public Shared Function GetRAMInfo(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New CfConfigRamLinqDB

            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String = "select id,ServerName ,ServerIP ,MacAddress ,RAMPercent from TB_RAM_INFO  where 1=1"
            sql += wh
            dt = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing
            Return dt
        End Function

        'Public Function GetCountRAM(ByVal wh As String, ByVal Severity As String, ByVal Macaddress As String) As DataTable

        '    Dim trans As New TransactionDB
        '    Dim lnq As New TbActivityPendingAlarmLinqDB
        '    Dim dt As New DataTable

        '    If Severity <> "" Then
        '        Dim sql As String
        '        sql = "select ActivityPendingAlarmID ,ServerName,ServerIP ,AlarmActivity,Severity,AlarmValue from TB_ACTIVITY_PENDING_ALARM where ServerIP ='" & wh & "'and Severity !='" & Severity & "'and AlarmActivity = 'RAM'"
        '        dt = lnq.GetListBySql(sql, trans.Trans)
        '    Else
        '        Dim _sql As String
        '        _sql = "select ActivityPendingAlarmID ,ServerName,ServerIP ,AlarmActivity,Severity,AlarmValue from TB_ACTIVITY_PENDING_ALARM   where ServerIP ='" & wh & "'and AlarmActivity = 'RAM'"
        '        dt = lnq.GetListBySql(_sql, trans.Trans)
        '    End If


        '    If dt.Rows.Count > 0 Then

        '        Dim ret As Boolean = False
        '        For i As Integer = 0 To dt.Rows.Count - 1
        '            Dim Delid As String
        '            Dim Dellnq As New TbActivityPendingAlarmLinqDB
        '            Dim tran As New TransactionDB
        '            Delid = dt.Rows(i)("ActivityPendingAlarmID").ToString()
        '            ret = Dellnq.DeleteByPK(Delid, tran.Trans)
        '            If ret = True Then
        '                tran.CommitTransaction()
        '            Else
        '                tran.RollbackTransaction()
        '            End If
        '        Next


        '    End If


        '    Status_TB_ALARM_WAITING_CLEAR(wh, Severity, Macaddress)

        '    Dim sqlRepeatChk As String = "select ActivityPendingAlarmID,ServerIP,Severity from TB_ACTIVITY_PENDING_ALARM "
        '    sqlRepeatChk += "where ServerIP = '" & wh & "' and Severity = '" & Severity & "' and AlarmActivity = 'RAM'"
        '    Dim dtRepeatChk As DataTable = lnq.GetListBySql(sqlRepeatChk, trans.Trans)

        '    Return dtRepeatChk

        'End Function

        Public Sub Status_TB_ALARM_WAITING_CLEAR(ByVal ip As String, ByVal Severity As String, ByVal Macaddress As String)
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            If Severity = "" Then
                Dim sql As String = "select id ,ServerName,HostIP,AlarmActivity,Severity,SpecificProblem,AlarmValue from TB_ALARM_WAITING_CLEAR"
                sql += " where HostIP = '" & ip & "' and FlagAlarm = 'Alarm' and AlarmActivity = 'RAM'"
                dt = lnq.GetListBySql(sql, trans.Trans)
            Else
                Dim sql As String = "select id ,ServerName,HostIP,AlarmActivity,Severity,SpecificProblem,AlarmValue from TB_ALARM_WAITING_CLEAR"
                sql += " where HostIP = '" & ip & "' and FlagAlarm = 'Alarm' and Severity != '" & Severity & "'and AlarmActivity = 'RAM'"
                dt = lnq.GetListBySql(sql, trans.Trans)
            End If



            If dt.Rows.Count > 0 Then
                Dim _sql As String
                _sql = "UPDATE TB_ALARM_WAITING_CLEAR SET FlagAlarm = 'Clear',ClearDate = '" & DateTime.Now & "'"
                _sql += " where id= '" & dt.Rows(0)(0).ToString() & "' and AlarmActivity = 'RAM'"
                SqlDB.ExecuteNonQuery(_sql)
                SaveAlarmLog(dt.Rows(0)("ServerName").ToString, dt.Rows(0)("HostIP").ToString, dt.Rows(0)("Severity").ToString, dt.Rows(0)("AlarmValue").ToString, dt.Rows(0)("id").ToString, Macaddress)
            End If


        End Sub
        Public Sub SaveAlarmLog(ByVal servername As String, ByVal HostIP As String, ByVal Severity As String, ByVal CurrentValue As String, ByVal AlarmWaitingClearID As String, ByVal Macaddress As String)
            Dim sql As String = ""
            sql = "insert into TB_ALARM_LOG (AlarmActivity,CreateDate,ServerName,HostIP,Severity ,CurrentValue,AlarmMethod,FlagAlarm,AlarmWaitingClearID ,MacAddress)"
            sql += "values('RAM','" & DateTime.Now & "','" & servername & "','" & HostIP & "','" & Severity & "','" & CurrentValue & "','E-mail','Clear','" & AlarmWaitingClearID & "','" & Macaddress & "')"
            SqlDB.ExecuteNonQuery(sql)
        End Sub
        Public Shared Function GetdtWAITING_CLEAR(MacAddress As String)
            Dim dt As New DataTable
            Dim lnq As New TbAlarmWaitingClearLinqDB

            Dim sql = "select id,HostIP ,Severity,FlagAlarm ,AlarmQty,AlarmActivity from TB_ALARM_WAITING_CLEAR where "
            sql += "MacAddress ='" & MacAddress & "' and FlagAlarm = 'Alarm' and AlarmActivity = 'RAM'"

            dt = lnq.GetListBySql(sql, Nothing)

            Return dt
        End Function

        Public Sub ProcessRAMAlarm(ByVal awDT As DataTable, ByVal cf As CfConfigRamLinqDB, ByVal CheckSeverity As String, CheckValue As String, RepeatCheck As Int16, info As TbRamInfoLinqDB, ByVal RAMPercentUsage As Double, ByVal AlarmMethod As String)
            awDT.DefaultView.RowFilter = "Severity<>'" & CheckSeverity & "'"
            If awDT.DefaultView.Count > 0 Then
                For Each awDR As DataRowView In awDT.DefaultView
                    Dim SpecificProblem As String = cf.SERVERNAME & " RAM Usage " & awDR("Severity") & " is Clear"
                    SendClearAlarm(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, awDR("Severity"), RAMPercentUsage, AlarmMethod, "RAM", SpecificProblem, awDT.DefaultView(0)("id"))
                Next
            End If

            Dim dt As New DataTable
            dt = GetRAMPendingAlarm(cf.MACADDRESS, CheckSeverity)
            If dt.Rows.Count < (RepeatCheck - 1) Then
                CreateRAMPendingAlarm(cf.MACADDRESS, CheckSeverity)
            Else
                Dim SpecificProblem As String = cf.SERVERNAME & " RAM Usage is " & RAMPercentUsage & "% over than " & CheckValue & "% " & CheckSeverity
                awDT.DefaultView.RowFilter = "Severity='" & CheckSeverity & "'"
                If awDT.DefaultView.Count = 0 Then
                    If InsertAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, CheckSeverity, RAMPercentUsage, "RAM", AlarmMethod, SpecificProblem) > 0 Then
                        DeleteRAMPendingAlarm(cf.MACADDRESS)
                    End If
                Else
                    If UpdateAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, CheckSeverity, RAMPercentUsage, "RAM", AlarmMethod, SpecificProblem, awDT.DefaultView(0)("id")) = True Then
                        DeleteRAMPendingAlarm(cf.MACADDRESS)
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

            Dim _sql As String = "select MAX (id) from TB_ALARM_WAITING_CLEAR where HostIP ='" & ip & "' and AlarmActivity = 'RAM' "
            dt = lnq.GetListBySql(_sql, trans.Trans)

            Dim id As String = dt.Rows(0)(0).ToString()
            Return ID
        End Function

        Public Sub CheckRam(ByVal ip As String, ByVal MacAddress As String)
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
                sql += " where id= '" & id & "' and AlarmActivity = 'RAM'"
                SqlDB.ExecuteNonQuery(sql)
                SaveAlarmLog(dtWaiting.Rows(0)("ServerName").ToString, dtWaiting.Rows(0)("HostIP").ToString, dtWaiting.Rows(0)("Severity").ToString, dtWaiting.Rows(0)("AlarmValue").ToString, dtWaiting.Rows(0)("id").ToString, Macaddress)
            End If

        End Sub


        Public Function Panding(ByVal ip As String) As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbActivityPendingAlarmLinqDB
            Dim dt As New DataTable

            Dim sql As String = "select * from TB_ACTIVITY_PENDING_ALARM where AlarmActivity ='RAM' and ServerIP ='" & ip & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function Waiting(ByVal ip As String) As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            Dim dt As New DataTable

            Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR where AlarmActivity ='RAM' and FlagAlarm = 'Alarm' and HostIP  ='" & ip & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function GetConfigTime(ByVal wh As String) As DataTable
            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String = "select * from CF_CONFIG_RAM where 1=1"
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

