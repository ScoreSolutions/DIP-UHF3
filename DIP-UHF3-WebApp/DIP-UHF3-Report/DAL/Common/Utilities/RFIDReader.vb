Imports RfidApiLib
Imports DIP_RFID.DAL.Table


Namespace Common.Utilities
    Public Class RFIDReader

        'Dim api As New RfidApi
        Public TagCnt As Integer = 0
        Dim EpcReading As Byte = 0

        Public Function ReadRFID(ByVal dt As DataTable, ByVal api As RfidApi) As DataTable
            Dim status As Integer
            Dim i, j As Integer
            Dim IsoBuf(100, 12) As Byte
            Dim tag_cnt As Byte = 0
            Dim s As String = ""
            Dim s1 As String = ""
            Dim tag_flag As Byte = 0

            status = api.EpcMultiTagIdentify(IsoBuf, tag_cnt, tag_flag)
            If tag_cnt > 0 Then
                For i = 0 To tag_cnt - 1
                    s1 = String.Format("", TagCnt)
                    For j = 0 To 11
                        s = String.Format("{0:X2}", IsoBuf(i, j))
                        s1 += s
                    Next

                    Dim dr As DataRow = dt.NewRow
                    dr("APP_NO") = GetAppNoFromRFID(s1)
                    dr("APP_NO10") = GetAppNo10Digit(s1)
                    dt.Rows.Add(dr)

                    TagCnt += 1
                Next
            End If

            Return dt
        End Function


        Private Function GetAppNoFromRFID(ByVal vRFID As String) As String
            'เอา RFID ที่อ่านได้ ไปหา APP_NO
            Dim ret As String
            ret = Left(vRFID, 12)
            Return ret
        End Function

        Private Function GetAppNo10Digit(ByVal vTagNo As String) As String
            Return Left(vTagNo, 10)
        End Function
    End Class
End Namespace