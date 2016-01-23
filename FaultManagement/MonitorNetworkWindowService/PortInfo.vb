Imports LinqDB.TABLE
Imports LinqDB.ConnectDB

Namespace InfoClass
    Public Class PortInfo
        Inherits HardwareInfo

        Public Sub CreatePortPendingAlarm(MacAddress As String, ByVal Severity As String)
            MyBase.CreatePendingAlarm("Port", MacAddress, Severity)
        End Sub

        Private Function GetPortPendingAlarm(ByVal ServerName As String, ByVal Severity As String) As DataTable
            Return MyBase.GetPendingAlarm("Port", ServerName, Severity)
        End Function

        Public Sub DeletePortPendingAlarm(ByVal MacAddress As String)
            MyBase.DeletePendingAlarm("Port", MacAddress)
        End Sub

        Public Shared Function GetdtWAITING_CLEAR(ByVal MacAddress As String, ByVal PortNumber As String)
            Dim dt As New DataTable
            Dim lnq As New TbAlarmWaitingClearLinqDB

            Dim sql = "select id,AlarmActivity from TB_ALARM_WAITING_CLEAR where "
            sql += "MacAddress ='" & MacAddress & "' and FlagAlarm = 'Alarm' and AlarmActivity = 'Port_" & PortNumber & "'"
            dt = lnq.GetListBySql(sql, Nothing)
            Return dt
        End Function

        Public Sub ProcessPortAlarm(ByVal awDT As DataTable, ByVal cf As CfConfigPortLinqDB, PortNumber As Integer, RepeatCheck As Int16, ByVal AlarmMethod As String)
            Try
                Dim Severity As String = "CRITICAL"
                Dim dt As New DataTable
                dt = GetPortPendingAlarm(cf.MACADDRESS, Severity)
                If dt.Rows.Count < (RepeatCheck - 1) Then
                    CreatePortPendingAlarm(cf.MACADDRESS, Severity)
                Else
                    Dim AlarmMsg As String = "PORT " & PortNumber & " on " & cf.HOSTIP & " is not connect"
                    awDT.DefaultView.RowFilter = " AlarmActivity='Port_' + '" & PortNumber & "'"
                    If awDT.DefaultView.Count = 0 Then
                        If InsertAlarmWaitingClear(cf.HOSTNAME, cf.HOSTIP, cf.MACADDRESS, Severity, 0, "Port_" & PortNumber, AlarmMethod, AlarmMsg) > 0 Then
                            DeletePortPendingAlarm(cf.MACADDRESS)
                        End If
                    Else
                        If UpdateAlarmWaitingClear(cf.HOSTNAME, cf.HOSTIP, cf.MACADDRESS, Severity, 0, "Port_" & PortNumber, AlarmMethod, AlarmMsg, awDT.DefaultView(0)("id")) = True Then
                            DeletePortPendingAlarm(cf.MACADDRESS)
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

