Imports System.Data
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.IO

Namespace Web_Config

    Public Class HistoryEng

        Public Function GetbtnAlarmHistory(ServerName As String, ByRef HostIP As String, ByRef Specific_Problem As String, ByRef AlarmT As String, ByRef Orderby As String, ByRef DateFrom As String, ByRef DateTo As String, ByRef TimeFrom As String, ByRef TimeTo As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbAlarmWaitingClearLinqDB
            Dim sql As String

            If AlarmT = "Select" Then
                AlarmT = ""
            End If
            If TimeFrom = "" Then
                TimeFrom = "00:00"
            End If
            If TimeTo = "" Then
                TimeTo = "23:59"
            End If

            Dim wh As String = ""
            If ServerName <> "" Then
                wh &= " and ServerName Like '%" & ServerName & "%'"
            End If
            If HostIP <> "" Then
                wh &= " and HostIP LIKE '%" & HostIP & "%'"
            End If
            If Specific_Problem <> "" Then
                wh &= " and SpecificProblem LIKE '%" & Specific_Problem & "%'"
            End If
            If AlarmT <> "" Then
                wh &= " and AlarmActivity LIKE '%" & AlarmT & "%'"
            End If

            If DateFrom <> "" And DateTo <> "" Then
                wh &= " and Convert(Varchar(16), CreatedDate,120) between '" & CDate(DateFrom).ToString("yyyy-MM-dd") & " " & TimeFrom & "' and '" & CDate(DateTo).ToString("yyyy-MM-dd") & " " & TimeTo & "'"
            End If

            sql = " Select id,ServerName,HostIP,SpecificProblem  , AlarmActivity "
            sql += " ,Severity ,case when AlarmActivity = 'Process' then AlarmValue"
            sql += " else case when AlarmActivity  = 'Service' then AlarmValue"
            sql += " else case when AlarmActivity  <> 'Procss' and AlarmActivity  <> 'Service' then  Convert(Varchar(255),AlarmValue )+' %' end end end as Value "
            sql += " ,AlarmQty ,FlagAlarm ,(convert(varchar(10),CreatedDate,103) + ' ' + convert(varchar(10),CreatedDate,108) ) CreatedDate "
            sql += " ,(convert(varchar(10),ClearDate,103) + ' ' + convert(varchar(10),ClearDate,108) ) ClearDate  "
            sql += " from TB_ALARM_WAITING_CLEAR where FlagAlarm = 'Clear'" & wh
            If Orderby = "Select" Then
                Orderby = "id"
                sql += " Order by " & Orderby & " ASC "
            ElseIf Orderby = "ServerName" Then
                sql += " Order by " & Orderby & " ASC "
            ElseIf Orderby = "CreateDate" Then
                sql += " Order by " & Orderby & " DESC "
            ElseIf Orderby = "ClearDate" Then
                sql += " Order by " & Orderby & " DESC "
            End If

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("AlarmActivity").ToString.ToLower <> "port" And dt.Rows(i)("AlarmActivity").ToString.ToLower <> "service" _
                   And dt.Rows(i)("AlarmActivity").ToString.ToLower <> "process" Then
                    dt.Rows(i)("Value") = ""
                End If
            Next


           
            Return dt
        End Function


        Public Function GetgvAlarmHistory() As DataTable

            Dim dt As New DataTable
            Dim lnq As New TbAlarmLogLinqDB

            Dim sql As String
            sql = "Select id,ServerName,HostIP,SpecificProblem  , AlarmActivity "
            sql += " ,Severity ,case when AlarmActivity = 'Process' then AlarmValue"
            sql += " else case when AlarmActivity  = 'Service' then AlarmValue"
            sql += " else case when AlarmActivity  <> 'Procss' and AlarmActivity  <> 'Service' then  Convert(Varchar(255),AlarmValue )+' %' end end end as Value "
            sql += " ,AlarmQty ,FlagAlarm ,(convert(varchar(10),CreatedDate,103) + ' ' + convert(varchar(10),CreatedDate,108) ) CreatedDate  "
            sql += ",(convert(varchar(10),ClearDate,103) + ' ' + convert(varchar(10),ClearDate,108) ) ClearDate  "
            sql += " from TB_ALARM_WAITING_CLEAR"
            sql += " where  FlagAlarm = 'Clear'"

            dt = lnq.GetListBySql(sql, Nothing)
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("AlarmActivity").ToString.ToLower <> "port" And dt.Rows(i)("AlarmActivity").ToString.ToLower <> "service" _
                   And dt.Rows(i)("AlarmActivity").ToString.ToLower <> "process" Then
                    dt.Rows(i)("Value") = ""
                End If
            Next
            Return dt
        End Function

        'Public Function GetdrpAlarmT() As DataTable

        '    Dim dt As DataTable
        '    Dim trans As New TransactionDB
        '    Dim lnq As New TbAlarmLogLinqDB
        '    dt = lnq.GetDataList("", "AlarmActivity", trans.Trans)
        '    trans.CommitTransaction()
        '    lnq = Nothing
        '    Return dt

        'End Function

    End Class

End Namespace
