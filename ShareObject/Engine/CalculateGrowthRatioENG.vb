Imports LinqDB.ConnectDB
Public Class CalculateGrowthRatioENG
    Public Shared Sub CalculateGrowthRatioMonth()
        Try
            Dim vTrans As New TransactionDB(SelectDB.DIPRFID)
            DIPRFIDSqlDB.ExecuteNonQuery("delete from TS_SIGNAGE_FILE_GROWTH_MONTH", vTrans.Trans)
            vTrans.CommitTransaction()

            Dim FirstMonth As DateTime = DateTime.Now
            Dim pDt As DataTable = DIPRFIDSqlDB.ExecuteTable("select id from tb_patent_type where id<>2")
            If pDt.Rows.Count > 0 Then
                For Each pDr As DataRow In pDt.Rows
                    Dim vLine As Integer = 1
                    Dim iMonth As Integer = 1

                    For i As Integer = 1 To 60
                        Dim CurrMonth As DateTime = FirstMonth.AddMonths(-i)
                        Dim ShowMonth As String = CurrMonth.ToString("MMM", New Globalization.CultureInfo("en-US"))
                        Dim ShowYear As String = CurrMonth.Year 'FirstMonth.AddYears(-vLine).ToString("yyyy", New Globalization.CultureInfo("en-US")) & "-" & FirstMonth.AddYears(-vLine).AddMonths(12).ToString("yyyy", New Globalization.CultureInfo("en-US"))
                        Dim intMonth As Integer = CurrMonth.Month
                        Dim FirstDayOfMonth As String = CurrMonth.Year & CurrMonth.Month.ToString.PadLeft(2, "0") & "01"
                        Dim LastdayOfMonth As String = CurrMonth.Year & CurrMonth.Month.ToString.PadLeft(2, "0") & DateTime.DaysInMonth(CurrMonth.Year, CurrMonth.Month).ToString.PadLeft(2, "0")

                        Dim dt As New DataTable
                        Dim trans As New TransactionDB(SelectDB.PATENDB)
                        Dim sql As String = " select count(id) qty "
                        sql += " from  REQUISITION"
                        sql += " where formtype = 1 "
                        sql += " and convert(varchar(8),RECEIVE_DATE,112) between '" & FirstDayOfMonth & "' and '" & LastdayOfMonth & "'"
                        sql += " and pat_type='" & pDr("id") & "'"

                        dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                        If dt.Rows.Count = 0 Then
                            dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                            If dt.Rows.Count = 0 Then
                                dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                            End If
                        End If
                        trans.CommitTransaction()

                        If dt.Rows.Count > 0 Then
                            Dim lnq As New LinqDB.TABLE.TsSignageFileGrowthMonthLinqDB
                            lnq.ChkDataBySHOW_MONTH_SHOW_YEAR_TB_PATENT_TYPE_ID(ShowMonth, CurrMonth.Year, pDr("id"), Nothing)

                            lnq.TB_PATENT_TYPE_ID = pDr("id")
                            lnq.SERIE_NAME = vLine
                            lnq.SHOW_MONTH = ShowMonth
                            lnq.SHOW_YEAR = ShowYear
                            lnq.FILE_QTY = Convert.ToInt64(dt.Rows(0)("qty"))
                            lnq.GROWTH_RATIO = GetGrowthRatioByMonth(vLine, CurrMonth, Convert.ToInt64(dt.Rows(0)("qty")), pDr("id"))

                            Dim re As Boolean = False
                            Dim DipTrans As New TransactionDB(SelectDB.DIPRFID)
                            If lnq.ID = 0 Then
                                re = lnq.InsertData("CalculateGrowthRatioENG.CalculateGrowthRatioMonth", DipTrans.Trans)
                            Else
                                re = lnq.UpdateByPK("CalculateGrowthRatioENG.CalculateGrowthRatioMonth", DipTrans.Trans)
                            End If

                            If re = True Then
                                DipTrans.CommitTransaction()
                            Else
                                DipTrans.RollbackTransaction()
                            End If
                        End If
                        dt.Dispose()

                        iMonth += 1
                        If iMonth > 12 Then
                            vLine += 1
                            iMonth = 1
                        End If
                    Next
                Next
            End If
            pDt.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Shared Function GetGrowthRatioByMonth(vLine As Integer, CurrMonth As DateTime, FileQty As Long, PatenTypeID As Int16) As Int16
        'หาอัตราการเจริญเติบโตของแฟ้มเป็นรายเดือน โดยเอาปีปัจจุบัน เทียบกับปีก่อนหน้า
        Dim ret As Int16 = 0
        If vLine = 5 Then
            ret = 100
        Else
            Dim FirstDayOfMonth As String = CurrMonth.AddYears(-1).ToString("yyyyMM", New Globalization.CultureInfo("en-US")) & "01"
            Dim LastDayOfMonth As String = CurrMonth.AddYears(-1).ToString("yyyyMM", New Globalization.CultureInfo("en-US")) & DateTime.DaysInMonth(CurrMonth.Year, CurrMonth.Month)
            Dim dt As New DataTable
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String = " select count(id) qty "
            sql += " from  REQUISITION "
            sql += " where formtype = 1 "
            sql += " and convert(varchar(8),RECEIVE_DATE,112) between '" & FirstDayOfMonth & "' and '" & LastDayOfMonth & "'"
            sql += " and pat_type='" & PatenTypeID & "'"

            dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            If dt.Rows.Count = 0 Then
                dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                If dt.Rows.Count = 0 Then
                    dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                End If
            End If
            trans.CommitTransaction()

            If dt.Rows.Count > 0 Then
                ret = ((FileQty - Convert.ToDouble(dt.Rows(0)("qty"))) * 100) / Convert.ToDouble(dt.Rows(0)("qty"))
            End If
        End If
        Return ret
    End Function

    Private Shared Function GetGrowthRatioByYear(vLine As Integer, CurrMonth As DateTime, FileQty As Long, PatenTypeID As Int16) As Double
        'หาอัตราการเจริญเติบโตของแฟ้มเป็นรายเดือน โดยเอาปีปัจจุบัน เทียบกับปีก่อนหน้า
        Dim ret As Double = 0
        If vLine = 5 Then
            ret = 100
        Else
            Dim FirstDayOfMonth As String = CurrMonth.AddYears(-1).Year & "0101"
            Dim LastDayOfMonth As String = CurrMonth.AddYears(-1).Year & "1231"
            Dim dt As New DataTable
            Dim trans As New TransactionDB(SelectDB.PATENDB)
            Dim sql As String = " select count(id) qty "
            sql += " from  REQUISITION"
            sql += " where formtype = 1 "
            sql += " and convert(varchar(8),RECEIVE_DATE,112) between '" & FirstDayOfMonth & "' and '" & LastDayOfMonth & "'"
            sql += " and pat_type='" & PatenTypeID & "'"

            dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
            If dt.Rows.Count = 0 Then
                dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                If dt.Rows.Count = 0 Then
                    dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                End If
            End If
            trans.CommitTransaction()

            If dt.Rows.Count > 0 Then
                ret = ((FileQty - Convert.ToDouble(dt.Rows(0)("qty"))) * 100) / Convert.ToDouble(dt.Rows(0)("qty"))
            End If
        End If
        Return ret
    End Function



    Public Shared Sub CalculateGrowthRatioYear()
        Dim vTrans As New TransactionDB(SelectDB.DIPRFID)
        DIPRFIDSqlDB.ExecuteNonQuery("delete from TS_SIGNAGE_FILE_GROWTH_YEAR", vTrans.Trans)
        vTrans.CommitTransaction()

        Dim FirstYear As DateTime = DateTime.Now
        Dim pDt As DataTable = DIPRFIDSqlDB.ExecuteTable("select id from tb_patent_type where id<>2")
        If pDt.Rows.Count > 0 Then
            For Each pDr As DataRow In pDt.Rows
                For i As Integer = 1 To 5
                    Dim CurrYear As DateTime = FirstYear.AddYears(-i)
                    Dim ShowYear As String = CurrYear.Year
                    Dim FirstDayYear As String = CurrYear.Year & "0101"
                    Dim LastDayYear As String = CurrYear.Year & "1231"

                    Dim dt As New DataTable
                    Dim trans As New TransactionDB(SelectDB.PATENDB)
                    Dim sql As String = " select count(id) qty "
                    sql += " from  REQUISITION"
                    sql += " where formtype = 1 "
                    sql += " and convert(varchar(8),RECEIVE_DATE,112) between '" & FirstDayYear & "' and '" & LastDayYear & "'"
                    sql += " and pat_type='" & pDr("id") & "'"

                    dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                    If dt.Rows.Count = 0 Then
                        dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                        If dt.Rows.Count = 0 Then
                            dt = PatentSqlDB.ExecuteTable(sql, trans.Trans)
                        End If
                    End If
                    trans.CommitTransaction()

                    If dt.Rows.Count > 0 Then
                        Dim lnq As New LinqDB.TABLE.TsSignageFileGrowthYearLinqDB
                        lnq.ChkDataBySHOW_YEAR_TB_PATENT_TYPE_ID(ShowYear, pDr("id"), Nothing)

                        lnq.TB_PATENT_TYPE_ID = pDr("id")
                        lnq.SHOW_YEAR = ShowYear
                        lnq.FILE_QTY = Convert.ToInt64(dt.Rows(0)("qty"))
                        lnq.GROWTH_RATIO = GetGrowthRatioByYear(i, CurrYear, lnq.FILE_QTY, pDr("id"))

                        Dim re As Boolean = False
                        Dim DipTrans As New TransactionDB(SelectDB.DIPRFID)
                        If lnq.ID = 0 Then
                            re = lnq.InsertData("CalculateGrowthRatioENG.CalculateGrowthRatioYear", DipTrans.Trans)
                        Else
                            re = lnq.UpdateByPK("CalculateGrowthRatioENG.CalculateGrowthRatioYear", DipTrans.Trans)
                        End If

                        If re = True Then
                            DipTrans.CommitTransaction()
                        Else
                            DipTrans.RollbackTransaction()
                        End If
                    End If
                    dt.Dispose()
                Next
            Next
        End If
        pDt.Dispose()
    End Sub
End Class
