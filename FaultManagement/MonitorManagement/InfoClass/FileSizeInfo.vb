Imports System.IO
Imports System.Xml
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace InfoClass
    Public Class FileSizeInfo
        Inherits HardwareInfo
        Public Function GetFileSizecf(ByVal wh As String) As DataTable
            Dim dt As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigFilesizeDetailLinqDB

            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String
            sql = "select CFD.id,cf.ServerIP,cf.ServerName,cf.MacAddress,cf.CheckIntervalMinute,cf.RepeateCheckQty,CFD.cf_config_filesize_id,CFD.FileName ,cfd.FileSizeMinor,CFD.FileSizeMajor,CFD.FileSizeCritical,CFD.RepeatCheckMinor,CFD.RepeatCheckMajor,CFD.RepeatCheckCritical "
            sql += "from CF_CONFIG_FILESIZE_DETAIL CFD inner join CF_CONFIG_FILESIZE CF on CFD .cf_config_filesize_id = CF.id where CF.ActiveStatus = 'Y'"
            sql += wh
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function GetFilsSizeInfo(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbFilesizeInfoLinqDB

            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String = "select id,ServerName,ServerIP,MacAddress,FileName,FileSizeGB from TB_FILESIZE_INFO where 1=1"
            sql += wh
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function GetCountFileSize(ByVal wh As String, ByVal Severity As String, ByVal FileName As String, ByVal NextTime As DateTime, ByVal MacAddress As String) As DataTable

            Dim trans As New TransactionDB
            Dim lnq As New TbActivityPendingAlarmLinqDB
            Dim dt As New DataTable

            If Severity <> "" Then
                Dim sql As String
                sql = "select ActivityPendingAlarmID,ServerIP,Severity from TB_ACTIVITY_PENDING_ALARM where ServerIP ='" & wh & "'and Severity !='" & Severity & "'and AlarmName = '" & FileName & "'"
                dt = lnq.GetListBySql(sql, trans.Trans)
            Else
                Dim _sql As String
                _sql = "select ActivityPendingAlarmID,ServerIP,Severity from TB_ACTIVITY_PENDING_ALARM where ServerIP ='" & wh & "'and AlarmName = '" & FileName & "'"
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


            Status_TB_ALARM_WAITING_CLEAR(wh, Severity, FileName, NextTime, MacAddress)

            Dim sqlRepeatChk As String = "select ActivityPendingAlarmID,ServerIP,Severity from TB_ACTIVITY_PENDING_ALARM "
            sqlRepeatChk += "where ServerIP = '" & wh & "' and Severity = '" & Severity & "' and AlarmName = '" & FileName & "'"
            Dim dtRepeatChk As DataTable = lnq.GetListBySql(sqlRepeatChk, trans.Trans)

            Return dtRepeatChk

        End Function

        Public Sub Status_TB_ALARM_WAITING_CLEAR(ByVal ip As String, ByVal Severity As String, ByVal FileName As String, ByVal NextTime As DateTime, ByVal MacAddress As String)
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            If Severity = "" Then
                Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR"
                sql += " where HostIP = '" & ip & "' and FlagAlarm = 'Alarm' and AlarmName = '" & FileName & "'"
                dt = lnq.GetListBySql(sql, trans.Trans)
            Else
                Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR"
                sql += " where HostIP = '" & ip & "' and FlagAlarm = 'Alarm' and Severity != '" & Severity & "'and AlarmName = '" & FileName & "'"
                dt = lnq.GetListBySql(sql, trans.Trans)
            End If



            If dt.Rows.Count > 0 Then
                Dim _sql As String
                _sql = "UPDATE TB_ALARM_WAITING_CLEAR SET FlagAlarm = 'Clear',ClearDate = '" & NextTime & "'"
                _sql += " where id= '" & dt.Rows(0)(0).ToString() & "' and AlarmName = '" & FileName & "'"
                SqlDB.ExecuteNonQuery(_sql)
                SaveAlarmLogFileName(DateTime.Now, dt.Rows(0)("ServerName").ToString, dt.Rows(0)("HostIP").ToString, dt.Rows(0)("Severity").ToString, dt.Rows(0)("AlarmValue").ToString, dt.Rows(0)("SpecificProblem").ToString, dt.Rows(0)("id").ToString, MacAddress, dt.Rows(0)("AlarmName").ToString)
            End If


        End Sub

        Public Function GetdtWAITING_CLEAR(ByVal ip As String, ByVal Severity As String, ByVal FileName As String)
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB

            Dim sql = "select id,HostIP ,SysLocation ,Severity,FlagAlarm ,AlarmQty,AlarmActivity from TB_ALARM_WAITING_CLEAR where "
            sql += "HostIP ='" & ip & "' and Severity ='" & Severity & "' and FlagAlarm = 'Alarm' and AlarmName = '" & FileName & "'"

            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function IDAlarmWaitingClear(ByVal ip As String, ByVal FileName As String) As String
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB

            Dim _sql As String = "select MAX (id) from TB_ALARM_WAITING_CLEAR where HostIP ='" & ip & "' and AlarmName = '" & FileName & "'"
            dt = lnq.GetListBySql(_sql, trans.Trans)

            Dim id As String = dt.Rows(0)(0).ToString()
            Return id
        End Function

        Public Sub SaveAlarmLogFileName(ByVal _Time As String, ByVal ServerName As String, ByVal HostIP As String, ByVal Severity As String, ByVal CurrentValue As String, ByVal SpecificProblem As String, ByVal AlarmWaitingClearID As String, ByVal MacAddress As String, ByVal FileName As String)
            Dim sql As String = ""
            sql = "insert into TB_ALARM_LOG (AlarmActivity,CreateDate,ServerName,HostIP,Severity ,CurrentValue,AlarmMethod,FlagAlarm,SpecificProblem ,AlarmWaitingClearID ,MacAddress,AlarmName)"
            sql += "values('File','" & _Time & "','" & ServerName & "','" & HostIP & "','" & Severity & "','" & CurrentValue & "','E-mail','Clear','" & SpecificProblem & "','" & AlarmWaitingClearID & "','" & MacAddress & "','" & FileName & "')"
            SqlDB.ExecuteNonQuery(sql)
        End Sub
        Public Function GetConfigTime(ByVal wh As String) As DataTable
            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String = "select * from CF_CONFIG_FILESIZE  where 1=1"
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


        Public Sub CheckFile(ByVal ip As String, ByVal MacAddress As String)
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

                    SaveAlarmLogFileName(DateTime.Now, dtWaiting.Rows(i)("ServerName").ToString, dtWaiting.Rows(i)("HostIP").ToString, dtWaiting.Rows(i)("Severity").ToString, dtWaiting.Rows(i)("AlarmValue").ToString, dtWaiting.Rows(i)("SpecificProblem").ToString, dtWaiting.Rows(i)("id").ToString, MacAddress, dtWaiting.Rows(i)("AlarmName").ToString)

                Next
            End If

        End Sub


        Public Function Panding(ByVal ip As String) As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbActivityPendingAlarmLinqDB
            Dim dt As New DataTable

            Dim sql As String = "select * from TB_ACTIVITY_PENDING_ALARM where  AlarmActivity = 'File' and ServerIP ='" & ip & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function Waiting(ByVal ip As String) As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            Dim dt As New DataTable

            Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR where AlarmActivity = 'File' and FlagAlarm = 'Alarm' and HostIP  ='" & ip & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Sub CreateFileSizePendingAlarm(MacAddress As String, ByVal Severity As String, ByVal FileName As String)
            MyBase.CreatePendingAlarm("FileSize_" & FileName, MacAddress, Severity)
        End Sub

        Private Function GetFileSizePendingAlarm(ByVal MacAddress As String, ByVal Severity As String, ByVal FileName As String) As DataTable
            Return MyBase.GetPendingAlarm("FileSize_" & FileName, MacAddress, Severity)
        End Function

        Public Sub DeleteFileSizePendingAlarm(ByVal MacAddress As String, ByVal FileName As String)
            MyBase.DeletePendingAlarm("FileSize_" & FileName, MacAddress)
        End Sub


        Public Shared Function GetFileSizeInfo(ByVal MacAddress As String, FileName As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New CfConfigFilesizeLinqDB

            Dim sql As String = "select id "
            sql += " from TB_FILESIZE_INFO"
            sql += " where 1=1"
            sql += " and MacAddress='" & MacAddress & "' and FileName='" & FileName & "'"
            dt = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing
            Return dt
        End Function


        Public Shared Function GetdtWAITING_CLEAR(ByVal MacAddress As String, ByVal FileName As String)
            Dim dt As New DataTable
            Dim lnq As New TbAlarmWaitingClearLinqDB

            Dim sql = "select id,HostIP ,Severity,FlagAlarm ,AlarmQty,AlarmActivity from TB_ALARM_WAITING_CLEAR where "
            sql += "MacAddress ='" & MacAddress & "' and FlagAlarm = 'Alarm' and AlarmActivity = 'FileSize_" & FileName & "'"
            dt = lnq.GetListBySql(sql, Nothing)
            Return dt
        End Function


        Public Sub ProcessFileSizeAlarm(ByVal awDT As DataTable, ByVal cf As CfConfigFilesizeLinqDB, ByVal CheckSeverity As String, CheckValue As String, RepeatCheck As Int16, info As TbFilesizeInfoLinqDB, ByVal CurrentFileSize As Double, ByVal AlarmMethod As String, FileName As String)
            awDT.DefaultView.RowFilter = "Severity<>'" & CheckSeverity & "'"
            If awDT.DefaultView.Count > 0 Then
                For Each awDR As DataRowView In awDT.DefaultView
                    Dim ClearMessage As String = " File Size Alarm " & FileName & " on " & cf.SERVERNAME & " " & awDR("Severity") & " is Clear"
                    SendClearAlarm(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, awDR("Severity"), CurrentFileSize, AlarmMethod, "FileSize_" & FileName, ClearMessage, awDT.DefaultView(0)("id"))
                Next
            End If

            Dim dt As New DataTable
            dt = GetFileSizePendingAlarm(cf.MACADDRESS, CheckSeverity, FileName)
            If dt.Rows.Count < (RepeatCheck - 1) Then
                CreateFileSizePendingAlarm(cf.MACADDRESS, CheckSeverity, FileName)
            Else
                Dim SpecificProblem As String = "File " & FileName & " on " & cf.SERVERIP & " size " & CurrentFileSize & " is over than " & CheckValue & " (CRITICAL)"
                awDT.DefaultView.RowFilter = "Severity='" & CheckSeverity & "' and AlarmActivity='FileSize_' + '" & info.FILENAME & "'"
                If awDT.DefaultView.Count = 0 Then
                    If InsertAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, CheckSeverity, CurrentFileSize, "FileSize_" & info.FILENAME, AlarmMethod, SpecificProblem) > 0 Then
                        DeleteFileSizePendingAlarm(cf.MACADDRESS, FileName)
                    End If
                Else
                    If UpdateAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, CheckSeverity, CurrentFileSize, "FileSize_" & info.FILENAME, AlarmMethod, SpecificProblem, awDT.DefaultView(0)("id")) = True Then
                        DeleteFileSizePendingAlarm(cf.MACADDRESS, FileName)
                    End If
                End If
                awDT.DefaultView.RowFilter = ""
            End If
            dt.Dispose()
        End Sub
    End Class

End Namespace

