Imports System.IO
Imports System.Xml
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace InfoClass
    Public Class ProcessInfo
        Inherits HardwareInfo

        Public Function GetProcesscf(ByVal wh As String) As DataTable
            Dim dt As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigProcessLinqDB


            If wh <> "" Then
                wh = "and " & wh
            End If

            Dim sql As String

            sql = "select CF.id as idConfig,CF.ServerName,CF.ServerIP,CF.MacAddress,CF.CheckIntervalMinute,CF.RepeatCheckQty,CF.ms_process_checklist_id ,MS.DisplayName,MS.WindowProcessName,CF.ActiveStatus from "
            sql += "CF_CONFIG_PROCESS CF inner join MS_MASTER_PROCESS_CHECKLIST MS on CF.ms_process_checklist_id = MS .id where cf.ActiveStatus ='Y'"
            sql += wh
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function GetProcssInfo(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbProcessInfoLinqDB

            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String = " select id,ServerName,ServerIP,MacAddress,WindowProcessName,ProcessAlive  from TB_PROCESS_INFO where 1=1"
            sql += wh
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function GetCountProcess(ByVal wh As String, ByVal ProcessName As String, ByVal NextTime As DateTime) As DataTable

            Dim trans As New TransactionDB
            Dim lnq As New TbActivityPendingAlarmLinqDB
            Dim dt As New DataTable


            'If Severity <> "" Then
            '    Dim sql As String
            '    sql = "select ActivityPendingAlarmID,ServerIP,Severity from TB_ACTIVITY_PENDING_ALARM where ServerIP ='" & wh & "'"
            '    dt = lnq.GetListBySql(sql, trans.Trans)
            'Else
            Dim _sql As String
            _sql = "select ActivityPendingAlarmID,ServerIP,Severity from TB_ACTIVITY_PENDING_ALARM where ServerIP ='" & wh & "'and AlarmName = '" & ProcessName & "'"
            dt = lnq.GetListBySql(_sql, trans.Trans)
            'End If


            Return dt

        End Function

        Public Sub Status_TB_ALARM_WAITING_CLEAR(ByVal ip As String, ByVal NextTime As DateTime, ByVal ProcessName As String, ByVal MacAddress As String)
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB

            'If Severity = "" Then
            Dim sql As String = "select id ,ServerName,HostIP,AlarmActivity,Severity,SpecificProblem,AlarmValue,AlarmName from TB_ALARM_WAITING_CLEAR"
            sql += " where HostIP = '" & ip & "' and FlagAlarm = 'Alarm' and AlarmName = '" & ProcessName & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)
            'Else
            '    Dim sql As String = "select id ,HostIP ,Severity,FlagAlarm from TB_ALARM_WAITING_CLEAR"
            '    sql += " where HostIP = '" & ip & "' and FlagAlarm = 'Alarm' and Severity != '" & Severity & "'and AlarmActivity = 'HDD/" & DriveLetter & "'"
            '    dt = lnq.GetListBySql(sql, trans.Trans)
            'End If



            If dt.Rows.Count > 0 Then
                Dim _sql As String
                _sql = "UPDATE TB_ALARM_WAITING_CLEAR SET FlagAlarm = 'Clear',ClearDate = '" & NextTime & "'"
                _sql += " where id= '" & dt.Rows(0)(0).ToString() & "' and AlarmName = '" & ProcessName & "'"
                SqlDB.ExecuteNonQuery(_sql)
                SaveAlarmLogProcess(NextTime, dt.Rows(0)("ServerName").ToString, dt.Rows(0)("HostIP").ToString, dt.Rows(0)("AlarmValue").ToString, dt.Rows(0)("id").ToString, MacAddress, ProcessName, dt.Rows(0)("SpecificProblem").ToString)
            End If


        End Sub

        Public Sub SaveAlarmLogProcess(ByVal _Time As DateTime, ByVal ServerName As String, ByVal HostIP As String, ByVal CurrentValue As String, ByVal AlarmWaitingClearID As String, ByVal MacAddress As String, ByVal ProcessName As String, ByVal SpecificProblem As String)
            Dim sql As String = ""
            sql = "insert into TB_ALARM_LOG (AlarmActivity,CreateDate,ServerName,HostIP,AlarmName,CurrentValue,AlarmMethod,FlagAlarm,SpecificProblem ,AlarmWaitingClearID ,MacAddress)"
            sql += "values('Process','" & _Time & "','" & ServerName & "','" & HostIP & "','" & ProcessName & "','" & CurrentValue & "','E-mail','Clear','" & SpecificProblem & "','" & AlarmWaitingClearID & "','" & MacAddress & "')"
            SqlDB.ExecuteNonQuery(sql)
        End Sub

        Public Shared Function GetdtWAITING_CLEAR(ByVal MacAddress As String, ByVal ProcessName As String)
            Dim dt As New DataTable
            Dim lnq As New TbAlarmWaitingClearLinqDB

            Dim sql = "select id,AlarmActivity from TB_ALARM_WAITING_CLEAR where "
            sql += "MacAddress ='" & MacAddress & "' and FlagAlarm = 'Alarm' and AlarmActivity = 'Process_" & ProcessName & "'"
            dt = lnq.GetListBySql(sql, Nothing)
            Return dt
        End Function

        Public Function IDAlarmWaitingClear(ByVal ip As String, ByVal ProcessName As String) As String
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB

            Dim _sql As String = "select MAX (id) from TB_ALARM_WAITING_CLEAR where HostIP ='" & ip & "' and AlarmName = '" & ProcessName & "'"
            dt = lnq.GetListBySql(_sql, trans.Trans)

            Dim id As String = dt.Rows(0)(0).ToString()
            Return id
        End Function

        Public Sub ClearPending(ByVal wh As String, ByVal ProcessName As String, ByVal NextTime As DateTime, ByVal MacAddress As String)
            Dim trans As New TransactionDB
            Dim lnq As New TbActivityPendingAlarmLinqDB
            Dim dt As New DataTable
            Dim sql As String
            sql = "select ActivityPendingAlarmID,ServerIP,AlarmName from TB_ACTIVITY_PENDING_ALARM where ServerIP ='" & wh & "' and AlarmName = '" & ProcessName & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)

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

            Status_TB_ALARM_WAITING_CLEAR(wh, NextTime, ProcessName, MacAddress)
        End Sub

        Public Function GetConfigTime(ByVal wh As String) As DataTable
            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String = "select DISTINCT ServerName,MacAddress,CheckIntervalMinute,RepeatCheckQty,ActiveStatus,AlarmSun,AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri,AlarmSat,AlarmTimeFrom ,AlarmTimeTo ,AllDayEvent from CF_CONFIG_PROCESS where 1=1"
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

        Public Sub CheckProcess(ByVal ip As String, ByVal MacAddress As String)
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
                For i As Integer = 0 To dtWaiting.Rows.Count - 1

                    Dim id As String = dtWaiting.Rows(i)(0).ToString()

                    Dim sql As String
                    sql = "UPDATE TB_ALARM_WAITING_CLEAR SET FlagAlarm = 'Clear',ClearDate = '" & DateTime.Now & "'"
                    sql += " where id= '" & id & "'"
                    SqlDB.ExecuteNonQuery(sql)

                    SaveAlarmLogProcess(DateTime.Now, dtWaiting.Rows(i)("ServerName").ToString, dtWaiting.Rows(i)("HostIP").ToString, dtWaiting.Rows(i)("AlarmValue").ToString, dtWaiting.Rows(i)("id").ToString, MacAddress, dtWaiting.Rows(i)("AlarmName").ToString, dtWaiting.Rows(i)("SpecificProblem").ToString)

                Next
            End If

        End Sub


        Public Function Panding(ByVal ip As String) As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbActivityPendingAlarmLinqDB
            Dim dt As New DataTable

            Dim sql As String = "select * from TB_ACTIVITY_PENDING_ALARM where  AlarmActivity = 'Process' and ServerIP ='" & ip & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function Waiting(ByVal ip As String) As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            Dim dt As New DataTable

            Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR where AlarmActivity = 'Process' and FlagAlarm = 'Alarm' and HostIP  ='" & ip & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function


        Public Sub CreateProcessPendingAlarm(MacAddress As String, ByVal ProcessName As String)
            MyBase.CreatePendingAlarm("Process_" & ProcessName, MacAddress, "CRITICAL")
        End Sub

        Public Function GetProcessPendingAlarm(ByVal MacAddress As String, ByVal ProcessName As String) As DataTable
            Return MyBase.GetPendingAlarm("Process_" & ProcessName, MacAddress, "CRITICAL")
        End Function

        Public Sub DeleteProcessPendingAlarm(ByVal MacAddress As String, ProcessName As String)
            MyBase.DeletePendingAlarm("Process_" & ProcessName, MacAddress)
        End Sub

        Public Sub ProcessProcessAlarm(ByVal awDT As DataTable, ByVal cf As CfConfigProcessLinqDB, RepeatCheck As Int16, info As TbProcessInfoLinqDB, ByVal AlarmMethod As String, DisplayName As String)
            Try
                Dim Severity As String = "CRITICAL"
                Dim dt As New DataTable
                dt = GetProcessPendingAlarm(cf.MACADDRESS, info.WINDOWPROCESSNAME)
                If dt.Rows.Count < (RepeatCheck - 1) Then
                    CreateProcessPendingAlarm(cf.MACADDRESS, info.WINDOWPROCESSNAME)
                Else
                    Dim AlarmMsg As String = "The Windows Process " & DisplayName & " on " & cf.SERVERIP & " has down"
                    awDT.DefaultView.RowFilter = " AlarmActivity='Process_' + '" & info.WINDOWPROCESSNAME & "'"
                    If awDT.DefaultView.Count = 0 Then
                        If InsertAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, Severity, 0, "Process_" & info.WINDOWPROCESSNAME, AlarmMethod, AlarmMsg) > 0 Then
                            DeleteProcessPendingAlarm(cf.MACADDRESS, info.WINDOWPROCESSNAME)
                        End If
                    Else
                        If UpdateAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, Severity, 0, "Process_" & info.WINDOWPROCESSNAME, AlarmMethod, AlarmMsg, awDT.DefaultView(0)("id")) = True Then
                            DeleteProcessPendingAlarm(cf.MACADDRESS, info.WINDOWPROCESSNAME)
                        End If
                    End If
                    awDT.DefaultView.RowFilter = ""
                End If
                dt.Dispose()

            Catch ex As Exception

            End Try

        End Sub
    End Class

End Namespace

