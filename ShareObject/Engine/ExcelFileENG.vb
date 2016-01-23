Imports System
Imports System.IO
Imports LinqDB.TABLE

Public Class ExcelFileENG
    Public Shared Function ReadExcelToDatatable(ExcelFile As String, ExcelVersion As ExcelVersion) As DataTable
        If ExcelVersion = Engine.ExcelVersion.Excel2007 Then
            Return ReadExcel2007ToDatatable(ExcelFile)
        ElseIf ExcelVersion = Engine.ExcelVersion.Excel2003 Then
            Return ReadExcel2003ToDatatable(ExcelFile)
        End If
    End Function
    Private Shared Function ReadExcel2003ToDatatable(ExcelFile As String) As DataTable
        'Dim dt As New DataTable
        'Try
        '    If File.Exists(ExcelFile) = True Then
        '        Using fs As New FileStream(ExcelFile, FileMode.Open, FileAccess.Read)
        '            Dim wBook As New HSSFWorkbook(fs)
        '            If wBook.Count > 0 Then  'Sheet Count
        '                'Dim sh As HSSFSheet = wBook.GetSheet("Sheet1")  'Get Sheet by Sheet Name
        '                Dim sh As HSSFSheet = wBook.GetSheetAt(0)   'Get Sheet by Index

        '                'Create DataColumn
        '                With sh.GetRow(0)
        '                    If .Cells.Count > 0 Then
        '                        For i As Integer = 0 To .Cells.Count - 1
        '                            'Select Case .Cells(i).CellType
        '                            '    Case NPOI.SS.UserModel.CellType.Numeric
        '                            '        dt.Columns.Add(.Cells(i).NumericCellValue)
        '                            '    Case NPOI.SS.UserModel.CellType.String

        '                            'End Select

        '                            dt.Columns.Add(.Cells(i).StringCellValue)
        '                        Next
        '                    End If
        '                End With

        '                Dim j As Long = 0
        '                Do
        '                    Dim row As NPOI.SS.UserModel.IRow = sh.GetRow(j)
        '                    If row IsNot Nothing Then
        '                        Dim dr As DataRow = dt.NewRow
        '                        For k As Integer = 0 To sh.GetRow(j).Cells.Count - 1
        '                            dr(k) = sh.GetRow(j).Cells(k).StringCellValue
        '                        Next
        '                        dt.Rows.Add(dr)
        '                    End If
        '                Loop While sh.GetRow(j) IsNot Nothing
        '            End If
        '            wBook = Nothing
        '        End Using
        '    End If
        'Catch ex As Exception
        '    dt = New DataTable
        'End Try
        'Return dt
    End Function
    Private Shared Function ReadExcel2007ToDatatable(ExcelFile As String) As DataTable
        Dim tbl As New DataTable
        Try
            Dim pck = New OfficeOpenXml.ExcelPackage()
            pck.Load(New IO.FileInfo(ExcelFile).OpenRead)
            If pck.Workbook.Worksheets.Count <> 0 Then
                Dim ws = pck.Workbook.Worksheets.First

                Dim hasHeader = False ' adjust accordingly '
                For Each firstRowCell In ws.Cells(1, 1, 1, ws.Dimension.End.Column)
                    tbl.Columns.Add(
                        If(hasHeader,
                           firstRowCell.Text,
                           String.Format("Column {0}", firstRowCell.Start.Column)))
                Next
                Dim startRow = If(hasHeader, 2, 1)
                For rowNum = startRow To ws.Dimension.End.Row
                    Dim wsRow = ws.Cells(rowNum, 1, rowNum, ws.Dimension.End.Column)
                    tbl.Rows.Add(wsRow.Select(Function(cell) cell.Text).ToArray)
                Next
            End If
            pck.Dispose()
        Catch ex As Exception
            tbl = New DataTable
        End Try
        Return tbl
    End Function

    Public Shared Sub ReadTextExcelFromMHT381SD(MsHumidityTempID As Long, TextFile As String)
        Try
            Dim Stream As New StreamReader(TextFile, System.Text.UnicodeEncoding.Default)
            Dim i As Long = 0
            While Stream.Peek <> -1
                Dim str As String = Stream.ReadLine
                If str.Trim <> "" Then
                    Try
                        If i = 0 Then   'First row is a Header Row
                            i += 1
                            Continue While
                        End If

                        Dim strFld As String() = Split(str, Chr(9))   'TAB
                        'Position	Date	Time	Ch1_Value	Ch1_Unit	Ch2_Value	Ch2_unit
                        Dim lnq As New TsHumidityTempDataLinqDB
                        lnq.ChkDataByMS_HUMIDITY_TEMP_ID(MsHumidityTempID, Nothing)

                        lnq.MS_HUMIDITY_TEMP_ID = MsHumidityTempID
                        lnq.RECORD_DATETIME = GlobalFunction.cStrToDateTime3(strFld(1).Trim, strFld(2).Trim)
                        lnq.HUMIDITY_VALUE = Convert.ToDouble(strFld(3).Trim)
                        lnq.TEMP_VALUE = Convert.ToDouble(strFld(5).Trim)
                        lnq.TEMP_UNIT = strFld(6).Trim.Replace("DEGREE ", "")

                        Dim ret As Boolean = False
                        Dim trans As New LinqDB.ConnectDB.TransactionDB(LinqDB.ConnectDB.SelectDB.DIPRFID)
                        If lnq.ID > 0 Then
                            ret = lnq.UpdateByPK("ExcelFileENG.ReadTextExcelFromMHT381SD", trans.Trans)
                        Else
                            ret = lnq.InsertData("ExcelFileENG.ReadTextExcelFromMHT381SD", trans.Trans)
                        End If

                        If ret = True Then
                            ret = InsertHumidityTempHistory(lnq, trans)
                            If ret = True Then
                                trans.CommitTransaction()
                            Else
                                trans.RollbackTransaction()
                            End If
                        Else
                            trans.RollbackTransaction()
                            LogFile.LogENG.SaveErrLog("ExcelFileENG.ReadTextExcelFromMHT381SD", lnq.ErrorMessage)
                        End If
                        lnq = Nothing
                    Catch ex As Exception
                        LogFile.LogENG.SaveErrLog("ExcelFileENG.ReadTextExcelFromMHT381SD", "Exception 1 " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
                i += 1
            End While
            Stream.Close()
            Stream = Nothing
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("ExcelFileENG.ReadTextExcelFromMHT381SD", "Exception 2 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Shared Function InsertHumidityTempHistory(DataLnq As TsHumidityTempDataLinqDB, trans As LinqDB.ConnectDB.TransactionDB) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New TsHumidityTempHistoryLinqDB
            lnq.MS_HUMIDITY_TEMP_ID = DataLnq.MS_HUMIDITY_TEMP_ID
            lnq.RECORD_DATETIME = DataLnq.RECORD_DATETIME
            lnq.HUMIDITY_VALUE = DataLnq.HUMIDITY_VALUE
            lnq.TEMP_VALUE = DataLnq.TEMP_VALUE
            lnq.TEMP_UNIT = DataLnq.TEMP_UNIT

            ret = lnq.InsertData("ExcelFileENG.InsertHumidityTempHistory", trans.Trans)
            If ret = False Then
                LogFile.LogENG.SaveErrLog("ExcelFileENG.InsertHumidityTempHistory", lnq.ErrorMessage)
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = False
            LogFile.LogENG.SaveErrLog("ExcelFileENG.InsertHumidityTempHistory", "Exception " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
End Class

Public Enum ExcelVersion As Integer
    Excel2003 = 1
    Excel2007 = 2
End Enum