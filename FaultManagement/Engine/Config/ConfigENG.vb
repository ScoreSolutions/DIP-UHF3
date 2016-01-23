

Namespace Config
    Public Class ConfigENG
        Public Structure AlarmSeverity
            Dim AlarmCode As String
            Dim Severity As String
            Dim ValueOver As Double
        End Structure

        Public Function GetIamAliveList() As DataTable
            Dim dt As New DataTable
            dt = LinqDB.ConnectDB.SqlDB.ExecuteTable("select * from TB_IAM_ALIVE where next_alive_time is not null")
            Return dt
        End Function
    End Class
End Namespace

