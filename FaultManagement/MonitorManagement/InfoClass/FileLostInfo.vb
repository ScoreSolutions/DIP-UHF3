Imports System.IO
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace InfoClass
    Public Class FileLostInfo
        Inherits HardwareInfo





        Public Sub CreateFileLostPendingAlarm(MacAddress As String, ByVal FileName As String)
            MyBase.CreatePendingAlarm("FileLost_" & FileName, MacAddress, "CRITICAL")
        End Sub

        Private Function GetFileLostPendingAlarm(ByVal MacAddress As String, ByVal FileName As String) As DataTable
            Return MyBase.GetPendingAlarm("FileLost_" & FileName, MacAddress, "CRITICAL")
        End Function

        Public Sub DeleteFileLostPendingAlarm(ByVal MacAddress As String, ByVal FileName As String)
            MyBase.DeletePendingAlarm("FileLost_" & FileName, "CRITICAL")
        End Sub

        Public Shared Function GetFileLostInfo(ByVal MacAddress As String, FileName As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New CfConfigFilesizeLinqDB

            Dim sql As String = "select id "
            sql += " from TB_FILELOST_INFO"
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
            sql += "MacAddress ='" & MacAddress & "' and FlagAlarm = 'Alarm' and AlarmActivity = 'FileLost_" & FileName & "'"
            dt = lnq.GetListBySql(sql, Nothing)
            Return dt
        End Function

        Public Sub ProcessFileLostAlarm(ByVal awDT As DataTable, ByVal cf As CfConfigFilelostLinqDB, RepeatCheck As Int16, info As TbFilelostInfoLinqDB, ByVal AlarmMethod As String)
            Dim dt As New DataTable
            dt = GetFileLostPendingAlarm(cf.MACADDRESS, info.FILENAME)
            If dt.Rows.Count < (RepeatCheck - 1) Then
                CreateFileLostPendingAlarm(cf.MACADDRESS, info.FILENAME)
            Else
                Dim AlarmMsg As String = "The FILE CONFIG " & info.FILENAME & " on " & cf.SERVERIP & " is lost (CRITICAL)"
                awDT.DefaultView.RowFilter = "AlarmActivity='FileLost_' + '" & info.FILENAME & "'"
                If awDT.DefaultView.Count = 0 Then
                    If InsertAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, "CRITICAL", 0, "FileLost_" & info.FILENAME, AlarmMethod, AlarmMsg) > 0 Then
                        DeleteFileLostPendingAlarm(cf.MACADDRESS, info.FILENAME)
                    End If
                Else
                    If UpdateAlarmWaitingClear(cf.SERVERNAME, cf.SERVERIP, cf.MACADDRESS, "CRITICAL", 0, "FileLost_" & info.FILENAME, AlarmMethod, AlarmMsg, awDT.DefaultView(0)("id")) = True Then
                        DeleteFileLostPendingAlarm(cf.MACADDRESS, info.FILENAME)
                    End If
                End If
                awDT.DefaultView.RowFilter = ""
            End If
            dt.Dispose()
        End Sub
    End Class
End Namespace

