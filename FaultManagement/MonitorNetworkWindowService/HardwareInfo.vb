'Imports Engine.ConnectDB
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports Engine.Common


Namespace InfoClass
    Public Class HardwareInfo

        Public Function InsertAlarmWaitingClear(ByVal ServerName As String, ByVal IPAddress As String, MacAddress As String, ByVal Severity As String, ByVal AlarmValue As Double, ByVal AlarmActivity As String, ByVal AlarmMethod As String, ByVal SpecificProblem As String) As Long
            Dim ret As Long = 0
            Try
                Dim lnq As New TbAlarmWaitingClearLinqDB
                lnq.SERVERNAME = ServerName
                lnq.HOSTIP = IPAddress
                lnq.MACADDRESS = MacAddress
                lnq.ALARMACTIVITY = AlarmActivity
                lnq.SEVERITY = Severity
                lnq.ALARMVALUE = AlarmValue
                lnq.ALARMMETHOD = AlarmMethod
                lnq.FLAGALARM = "Alarm"
                lnq.SPECIFICPROBLEM = SpecificProblem
                lnq.ALARMQTY = 1
                lnq.ISSENDALARM = "N"
                lnq.ISSENDCLEAR = "Z"

                Dim trans As New TransactionDB

                If lnq.InsertData("HardwareInfo", trans.Trans) = True Then
                    trans.CommitTransaction()
                    ret = lnq.ID
                    InsertAlarmLog(ServerName, IPAddress, MacAddress, AlarmActivity, Severity, AlarmValue, "Alarm", AlarmMethod, SpecificProblem, ret)
                Else
                    ret = 0
                    trans.RollbackTransaction()
                End If
                lnq = Nothing
            Catch ex As Exception
                ret = 0
            End Try

            Return ret
        End Function

        Public Function UpdateAlarmWaitingClear(ByVal ServerName As String, ByVal IPAddress As String, MacAddress As String, ByVal Severity As String, ByVal AlarmValue As Double, ByVal AlarmActivity As String, ByVal AlarmMethod As String, ByVal SpecificProblem As String, ByVal AlarmWaitingClearID As Long) As Boolean
            Dim ret As Boolean = False
            Try
                Dim lnq As New TbAlarmWaitingClearLinqDB
                lnq.GetDataByPK(AlarmWaitingClearID, Nothing)

                lnq.ALARMQTY = lnq.ALARMQTY + 1
                lnq.LASTUPDATEDATE = DateTime.Now

                If lnq.ID > 0 Then
                    Dim trans As New TransactionDB
                    ret = lnq.UpdateByPK("HardwareInfo_UpdateAlarmWaitingClear", trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()

                        InsertAlarmLog(ServerName, IPAddress, MacAddress, AlarmActivity, Severity, AlarmValue, "Alarm", AlarmMethod, SpecificProblem, AlarmWaitingClearID)
                    Else
                        trans.RollbackTransaction()
                    End If
                End If
                lnq = Nothing
            Catch ex As Exception
                ret = False
            End Try
            Return ret

            'Dim sql As String = "update TB_ALARM_WAITING_CLEAR set AlarmQty = AlarmQty + 1,UpdateDate=getdate(),SpecificProblem='" & SpecificProblem & "' where id=" & AlarmWaitingClearID
            'Dim ret As Long = SqlDB.ExecuteNonQuery(sql)
            'If ret > 0 Then
            '    InsertAlarmLog(ServerName, IPAddress, AlarmActivity, Severity, AlarmValue, "Alarm", AlarmDesc, SpecificProblem, AlarmWaitingClearID)
            'End If

            'Return (ret > 0)
        End Function

        Public Function GetAlarmWaitingClear(ByVal ServerName As String, ByVal AlarmActivity As String, ByVal FlagAlarm As String) As DataTable
            Dim ret As New DataTable
            Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR where ServerName='" & ServerName & "' and AlarmActivity='" & AlarmActivity & "' and FlagAlarm='" & FlagAlarm & "'"
            ret = SqlDB.ExecuteTable(sql)
            Return ret
        End Function

        Public Function GetAllAlarmWaitingClear(ByVal AlarmActivity As String) As DataTable
            Dim ret As New DataTable
            Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR where  AlarmActivity like '%" & AlarmActivity & "%' and FlagAlarm='Alarm'"
            ret = SqlDB.ExecuteTable(sql)
            Return ret
        End Function

        Public Function SendClearAlarm(ByVal ServerName As String, ByVal HostIP As String, MacAddress As String, ByVal Severity As String, ByVal AlarmValue As String, ByVal AlarmMethod As String, ByVal AlarmActivity As String, ByVal ClearMessage As String, ByVal AlarmWaitingClearID As Integer) As Boolean
            Dim ret As Boolean = False
            Try
                Dim lnq As New TbAlarmWaitingClearLinqDB
                lnq.GetDataByPK(AlarmWaitingClearID, Nothing)

                lnq.FLAGALARM = "Clear"
                lnq.CLEARDATE = DateTime.Now
                lnq.ISSENDCLEAR = "N"
                lnq.CLEARMESSAGE = ClearMessage

                If lnq.ID > 0 Then
                    Dim trans As New TransactionDB
                    ret = lnq.UpdateByPK("HardwareInfo.SendClearAlarm", trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()

                        InsertAlarmLog(ServerName, HostIP, MacAddress, AlarmActivity, Severity, AlarmValue, "Clear", AlarmMethod, ClearMessage, AlarmWaitingClearID)
                    Else
                        trans.RollbackTransaction()
                    End If
                End If
                lnq = Nothing
            Catch ex As Exception

            End Try

            'Dim dt As DataTable = Engine.Common.FunctionEng.ExecuteDataTable("select top 1 id from TB_ALARM_WAITING_CLEAR where ServerName='" & ServerName & "' and AlarmActivity='" & AlarmActivity & "' and Severity='" & Severity & "' and FlagAlarm='Alarm'")
            'If dt.Rows.Count > 0 Then
            '    Dim sql As String = "update TB_ALARM_WAITING_CLEAR set FlagAlarm='Clear', ClearDate=getdate() where id=" & dt.Rows(0)("id")
            '    If QisFaultDB.ExecuteNonQuery(sql, INIFile) > 0 Then
            '        ret = True
            '        InsertAlarmLog(ServerName, HostIP, AlarmActivity, Severity, AlarmValue, AlarmMethod, "Clear", AlarmDesc, SpecificProblem, dt.Rows(0)("id"))
            '    End If
            'End If
            'dt.Dispose()

            Return ret
        End Function

        Private Sub InsertAlarmLog(ByVal ServerName As String, ByVal HostIP As String, MacAddress As String, ByVal AlarmActivity As String, ByVal Severity As String, ByVal CurrentValue As String, ByVal FlagAlarm As String, ByVal AlarmMethod As String, ByVal SpecificPloblem As String, ByVal AlarmWaitingClearID As Integer)
            Try
                Dim lnq As New TbAlarmLogLinqDB
                lnq.SERVERNAME = ServerName
                lnq.HOSTIP = HostIP
                lnq.MACADDRESS = MacAddress
                lnq.ALARMACTIVITY = AlarmActivity
                lnq.SEVERITY = Severity
                lnq.ALARMVALUE = CurrentValue
                lnq.ALARMMETHOD = AlarmMethod
                lnq.FLAGALARM = FlagAlarm
                lnq.SPECIFICPROBLEM = SpecificPloblem
                lnq.ALARMWAITINGCLEARID = AlarmWaitingClearID

                Dim trans As New TransactionDB
                If lnq.InsertData("HardwardInfo", trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
                lnq = Nothing
            Catch ex As Exception

            End Try

        End Sub

        Public Sub CreatePendingAlarm(ByVal AlarmActivity As String, ByVal MacAddress As String, ByVal Severity As String)
            Try
                Dim lnq As New TbActivityPendingAlarmLinqDB
                lnq.ALARMACTIVITY = AlarmActivity
                lnq.MACADDRESS = MacAddress
                lnq.SEVERITY = Severity

                Dim trans As New TransactionDB
                If lnq.InsertData("HardwareInfo", trans.Trans) Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
                lnq = Nothing
            Catch ex As Exception

            End Try

        End Sub

        Protected Function GetPendingAlarm(ByVal AlarmActivity As String, ByVal MacAddress As String, ByVal Severity As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id from TB_ACTIVITY_PENDING_ALARM where AlarmActivity='" & AlarmActivity & "' and MacAddress='" & MacAddress & "' and Severity='" & Severity & "'"
            dt = FunctionEng.ExecuteDataTable(sql)
            Return dt
        End Function

        Public Sub DeletePendingAlarm(ByVal AlarmActivity As String, ByVal MacAddress As String)
            Dim sql As String = "delete from TB_ACTIVITY_PENDING_ALARM where MacAddress='" & MacAddress & "' and AlarmActivity='" & AlarmActivity & "' "
            SqlDB.ExecuteNonQuery(sql)
        End Sub

        Public Function AddConfigPort(ByVal ServerName As String, ByVal IPAddress As String, ByVal PortNumber As Integer, ByVal ChkSun As String, ByVal ChkMon As String, ByVal ChkTue As String, ByVal ChkWed As String, ByVal ChkThu As String, ByVal ChkFri As String, ByVal ChkSat As String, ByVal ChkAllDay As String, ByVal AlarmTimeFrom As String, ByVal AlarmTimeTo As String) As Boolean
            Dim sql As String = "insert into TB_CONFIG_PORT_LIST (HostIP,HostName,PortNumber,"
            sql += " AlarmSun, AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri,AlarmSat,AllDayEvent,AlarmTimeFrom,AlarmTimeTo)"
            sql += " values('" & IPAddress & "','" & ServerName & "','" & PortNumber & "',"
            sql += " '" & ChkSun & "','" & ChkMon & "','" & ChkTue & "','" & ChkWed & "','" & ChkThu & "','" & ChkFri & "','" & ChkSat & "','" & ChkAllDay & "','" & AlarmTimeFrom & "','" & AlarmTimeTo & "')"
            Return (SqlDB.ExecuteNonQuery(sql) > 0)
        End Function

        Public Function GetConfigPortList(ByVal whText As String) As DataTable
            Dim sql As String = " select * from TB_CONFIG_PORT_LIST where 1=1 " & whText
            Dim dt As New DataTable
            dt = SqlDB.ExecuteTable(sql)
            dt.TableName = "GetConfigPortList"
            Return dt
        End Function

        Public Function DeleteConfigPortList(ByVal id As Long) As Boolean
            Dim sql As String = "delete from TB_CONFIG_PORT_LIST where id=" & id
            Return (SqlDB.ExecuteNonQuery(sql) > 0)
        End Function

        Public Shared Function UpdateLastCheckTime(TbName As String, cfID As Long) As Boolean
            Dim ret As Boolean = False
            Try
                Dim sql As String = "update " & TbName
                sql += " set LastCheckTime=getdate()"
                sql += " where id='" & cfID & "'"

                ret = Engine.Common.FunctionEng.ExecuteNonQuery(sql)
            Catch ex As Exception
                ret = False
            End Try
            Return ret
        End Function
    End Class
End Namespace

