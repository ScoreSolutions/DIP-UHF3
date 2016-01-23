Public Class RFIDReaderENG
    Public Shared Function GetRFIDReaderList() As DataTable
        Dim ret As New DataTable
        Try
            'ret.Columns.Add("ip_address")

            'Dim dr As DataRow = ret.NewRow
            'dr("ip_address") = "192.168.1.100"
            'ret.Rows.Add(dr)

            'dr = ret.NewRow
            'dr("ip_address") = "192.168.1.101"
            'ret.Rows.Add(dr)

            Dim sql As String = "select ip_address from MS_MID_RANGE_READER where active_status='Y'"
            ret = GlobalFunction.GetDatatable(sql)

        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
End Class
