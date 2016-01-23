Imports System.Web.Security
Imports System.Data
Imports System.Linq
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace Web_Config

    Public Class PortEng

        Public Function SetgvCfPortList(ByVal wh As String) As DataTable
            Dim dt As DataTable
            Dim lnq As New CfConfigPortLinqDB
            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String
            sql = "select cp.id, CP.HostIP, cp.HostName, cp.MacAddress, cpd.PortNumber, cpd.RepeatCheck,TR.id as idRes "
            sql += " from CF_CONFIG_PORT CP "
            sql += " inner join TB_REGISTER TR on CP.HostIP = TR.ServerIP "
            sql += " inner join CF_CONFIG_PORT_DETAIL cpd on cp.id=cpd.cf_config_port_id"
            sql += wh
            dt = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing
            Return dt
        End Function

        Public Function AddConfigPort(ByVal ServerName As String, ByVal IPAddress As String, ByVal PortNumber As Integer, ByVal ChkSun As String, ByVal ChkMon As String, ByVal ChkTue As String, ByVal ChkWed As String, ByVal ChkThu As String, ByVal ChkFri As String, ByVal ChkSat As String, ByVal ChkAllDay As String, ByVal AlarmTimeFrom As String, ByVal AlarmTimeTo As String) As Boolean
            Dim sql As String = "insert into CF_CONFIG_PORT (HostIP,HostName,PortNumber,"
            sql += " AlarmSun, AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri,AlarmSat,AllDayEvent,AlarmTimeFrom,AlarmTimeTo)"
            sql += " values('" & IPAddress & "','" & ServerName & "','" & PortNumber & "',"
            sql += " '" & ChkSun & "','" & ChkMon & "','" & ChkTue & "','" & ChkWed & "','" & ChkThu & "','" & ChkFri & "','" & ChkSat & "','" & ChkAllDay & "','" & AlarmTimeFrom & "','" & AlarmTimeTo & "')"
            Return (SqlDB.ExecuteNonQuery(sql) > 0)
        End Function

        Public Function EditConfigPort(ByVal ServerName As String, ByVal IPAddress As String, ByVal PortNumber As Integer, ByVal ChkSun As String, ByVal ChkMon As String, ByVal ChkTue As String, ByVal ChkWed As String, ByVal ChkThu As String, ByVal ChkFri As String, ByVal ChkSat As String, ByVal ChkAllDay As String, ByVal AlarmTimeFrom As String, ByVal AlarmTimeTo As String, ByVal id As String) As Boolean
            Dim sql As String = "update CF_CONFIG_PORT set HostIP ='" & IPAddress & "',HostName ='" & ServerName & "',PortNumber ='" & PortNumber & "',AlarmSun ='" & ChkSun & "',AlarmMon ='" & ChkMon & "',"
            sql += "AlarmTue ='" & ChkTue & "',AlarmWed ='" & ChkWed & "',AlarmThu ='" & ChkThu & "',AlarmFri ='" & ChkFri & "',AlarmSat ='" & ChkSat & "',AlarmTimeFrom ='" & AlarmTimeFrom & "',AlarmTimeTo ='" & AlarmTimeTo & "',AllDayEvent ='" & ChkAllDay & "'"
            sql += " where id = '" & id & "'"
            Return (SqlDB.ExecuteNonQuery(sql) > 0)
        End Function


        Public Function GetConfigPortList(ByVal whText As String) As DataTable
            Dim sql As String = " select * from CF_CONFIG_PORT where 1=1 "
            Dim dt As New DataTable
            dt = SqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                dt.Columns.Add("CheckAlarmWithTimeConfig", GetType(Boolean))
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("CheckAlarmWithTimeConfig") = CheckAlarmWithTimeConfig(dt.Rows(i))
                Next
            End If

            dt.TableName = "GetConfigPortList"
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


        Public Function GetAlarmWaitingClear(ByVal Serverip As String, ByVal Port As String) As DataTable
            Dim ret As New DataTable
            Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR where HostIP='" & Serverip & "' and AlarmActivity='Port' and FlagAlarm='Alarm' and AlarmName like '%" & Port & "%'"
            ret = SqlDB.ExecuteTable(sql)
            Return ret
        End Function

        Public Function CreateAlarmWaitingClear(ByVal ServerName As String, ByVal IPAddress As String, ByVal SpecificProblem As String, ByVal SysLocation As String, ByVal Port As String) As Long

            Dim ret As Long = 0
            Dim AlarmName As String = "PORT" & Port & " process on " & IPAddress

            Dim sql As String = "insert into TB_ALARM_WAITING_CLEAR(CreateDate,ServerName,HostIP,AlarmActivity ,SysLocation ,Severity ,AlarmMethod ,FlagAlarm ,SpecificProblem ,AlarmQty,AlarmName,AlarmValue)"
            sql += " values('" & DateTime.Now & "','" & ServerName & "','" & IPAddress & "','Port','" & SysLocation & "','Critical','E-mail','Alarm','" & SpecificProblem & "','1','" & AlarmName & "','Not Connect')"
            ret = SqlDB.ExecuteNonQuery(sql)
            If ret > 0 Then
                ret = SqlDB.GetLastID("TB_ALARM_WAITING_CLEAR", Nothing)
            End If

            InsertAlarmLog(ServerName, IPAddress, SpecificProblem, ret, SpecificProblem, "Alarm")

            Return ret
        End Function

        Public Sub InsertAlarmLog(ByVal ServerName As String, ByVal HostIP As String, ByVal SpecificPloblem As String, ByVal AlarmWaitingClearID As Integer, ByVal AlarmDesc As String, ByVal FlagAlarm As String)
            Dim sql As String = "insert into TB_ALARM_LOG (CreateDate,ServerName,HostIP,AlarmActivity,Severity,"
            sql += " FlagAlarm,AlarmDesc,SpecificProblem,AlarmWaitingClearID,AlarmMethod)"
            sql += " values('" & DateTime.Now & "','" & ServerName & "','" & HostIP & "','PORT','Critical',"
            sql += " '" & FlagAlarm & "','" & AlarmDesc & "','" & SpecificPloblem & "','" & AlarmWaitingClearID & "','E-mail')"

            SqlDB.ExecuteNonQuery(sql)
        End Sub

        Public Function UpdateAlarmWaitingClear(ByVal ServerName As String, ByVal IPAddress As String, ByVal AlarmWaitingClearID As Long, ByVal SpecificProblem As String, ByVal AlarmDesc As String) As Boolean
            Dim sql As String = "update TB_ALARM_WAITING_CLEAR set AlarmQty = AlarmQty + 1,UpdateDate='" & DateTime.Now & "' where id='" & AlarmWaitingClearID & "'"
            Dim ret As Long = SqlDB.ExecuteNonQuery(sql)
            If ret > 0 Then
                InsertAlarmLog(ServerName, IPAddress, SpecificProblem, AlarmWaitingClearID, AlarmDesc, "Alarm")
            End If

            Return (ret > 0)
        End Function

        Public Function SendClearAlarm(ByVal HostIP As String) As Boolean
            Dim ret As Boolean = False
            Dim dt As New DataTable
            Dim lnq As New TbAlarmWaitingClearLinqDB
            Dim trans As New TransactionDB
            Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR where AlarmActivity = 'Port' and FlagAlarm  = 'Alarm' and HostIP = '" & HostIP & "'"
            dt = lnq.GetListBySql(sql, trans.Trans)
            If dt.Rows.Count > 0 Then
                Dim _sql As String = "update TB_ALARM_WAITING_CLEAR set ClearDate = '" & DateTime.Now & "',FlagAlarm = 'Clear' where id='" & dt.Rows(0)(0).ToString() & "'"
                Dim _ret As Long = SqlDB.ExecuteNonQuery(_sql)
                If _ret > 0 Then
                    InsertAlarmLog(dt.Rows(0)("ServerName").ToString(), HostIP, dt.Rows(0)("SpecificProblem").ToString(), dt.Rows(0)(0).ToString(), dt.Rows(0)("SpecificProblem").ToString(), "Clear")
                End If


            End If
            Return ret
        End Function

        Dim _err As String = ""

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err.Trim()
            End Get
        End Property
        'Public Function CheckDuplicatePort(ByVal id As Long, ByVal Port As String, HostName As String, HostIP As String) As Boolean

        '    Dim ret As Boolean = False
        '    Dim lnq As New CfConfigPortLinqDB
        '    Dim trans As New TransactionDB

        '    ret = lnq.ChkDuplicateByHOSTIP_PORTNUMBER(HostIP, Port, id, trans.Trans)
        '    If ret = True Then
        '        _err = "alert('Port Repeated !');"
        '    Else
        '        ret = lnq.ChkDuplicateByHOSTNAME_PORTNUMBER(HostName, Port, id, trans.Trans)
        '        If ret = True Then
        '            _err = "lert('Port Repeated !');"
        '        End If
        '    End If
        '    trans.CommitTransaction()
        '    lnq = Nothing

        '    Return ret
        'End Function


        Public Function GetPort(ServerIP As String, ServerName As String, MacAddress As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,HostIP,hostName,LastCheckTime,ActiveStatus,MacAddress,AlarmSun,AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri"
            sql += " ,AlarmSat,AlarmTimeFrom,AlarmTimeTo,AllDayEvent,LastCheckTime from CF_CONFIG_PORT"
            sql += " where HostIP ='" & ServerIP & "' or hostName='" & ServerName & "' or MacAddress='" & MacAddress & "'"
            dt = SqlDB.ExecuteTable(sql)

            Return dt
        End Function

        Public Function GetPortDetail(PortID As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,cf_config_port_id,PortNumber,RepeatCheck from CF_CONFIG_PORT_DETAIL  where cf_config_port_id='" & PortID & "'"
            dt = SqlDB.ExecuteTable(sql)
            Return dt
        End Function

    End Class

End Namespace

