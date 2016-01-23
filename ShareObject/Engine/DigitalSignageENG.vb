Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Public Class DigitalSignageENG
#Region "Signage Content Schedule"
    Public Shared Sub SetScheduleSignageContent()
        Try
            Dim dt As DataTable = GetSignageContentSchedule(" and st.schedule_status='N' and st.active_status='Y'")
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If DeleteSignageContentScheduleData(dr("id")) = True Then

                        Dim dtTime As DataTable = GetSignageContentScheduleTime(dr("id"))

                        Select Case dr("schedule_type")
                            Case "D"
                                SetSignageScheduleTypeDay(dr, dtTime)
                            Case "W"
                                SetSignageScheduleTypeWeek(dr, dtTime)
                            Case "M"
                                SetSignageScheduleTypeMonth(dr, dtTime)
                        End Select
                    End If
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetScheduleSignageContent", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

#Region "Set Schedule all Type"
    'Private Shared Sub SetSignageScheduleTypeDay(dr As DataRow, dtTime As DataTable)
    '    Dim re As Boolean = False
    '    Try
    '        Dim trans As New TransactionDB(SelectDB.DIPRFID)
    '        Dim lnq As New MsSignageScheduleDailyLinqDB
    '        lnq.ChkDataByMS_SIGNAGE_TEMPLATE_SCHEDULE_ID(dr("id"), trans.Trans)
    '        If lnq.ID > 0 Then
    '            Dim CurrDate As DateTime = Convert.ToDateTime(dr("start_time"))
    '            Dim DayCount As Integer = lnq.RECUR_EVERY_DAYS

    '            Dim StartDate As DateTime = Convert.ToDateTime(dr("start_time"))
    '            Dim EndDate As DateTime = Convert.ToDateTime(dr("end_time"))

    '            Dim CurrTime As DateTime = StartDate

    '            Do   'Loop ตามวันที่
    '                re = True
    '                If DayCount = lnq.RECUR_EVERY_DAYS Then
    '                    DayCount = 1

    '                    Dim EndTime As DateTime = New DateTime(CurrDate.Year, CurrDate.Month, CurrDate.Day, 23, 59, 0)
    '                    Do
    '                        If EndTime.ToString("yyyyMMdd") = EndDate.ToString("yyyyMMdd") Then
    '                            'ถ้า EndTime ตรงกับวันที่สุดท้าย ให้กำหนดเป็นเวลาสุดท้ายของวันนั้น
    '                            EndTime = EndDate
    '                        End If

    '                        Dim DurationMin As Integer = 0
    '                        For Each drTime As DataRow In dtTime.Rows
    '                            If CurrTime <= EndDate Then
    '                                DurationMin = Convert.ToInt16(drTime("duration_minute"))
    '                                If DurationMin > 0 Then
    '                                    Dim TimeFrom As DateTime = CurrTime
    '                                    Dim TimeTo As DateTime = CurrTime.AddMinutes(DurationMin)

    '                                    'ถ้าเป็นวันที่สุดท้ายใน Schedule
    '                                    If CurrTime.ToString("yyyyMMdd") = Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd") Then
    '                                        Dim TmpTimeTo As DateTime = Convert.ToDateTime(dr("end_time"))

    '                                        If TimeFrom <= TmpTimeTo Then
    '                                            If TimeTo > TmpTimeTo Then
    '                                                TimeTo = TmpTimeTo
    '                                            End If
    '                                        Else
    '                                            CurrTime = DateAdd(DateInterval.Minute, DurationMin, CurrTime)
    '                                            Exit For
    '                                        End If
    '                                    End If

    '                                    Try
    '                                        'Dim TmpCurrDate As String = CurrDate.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
    '                                        Dim tLnq As New MsSignageContentSchDataLinqDB
    '                                        tLnq.MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = dr("id")
    '                                        tLnq.SCHEDULE_NAME = dr("schedule_name")
    '                                        tLnq.MS_SIGNAGE_CONTENT_TEMPLATE_ID = drTime("ms_signage_content_template_id")
    '                                        tLnq.TEMPLATE_NAME = drTime("template_name")
    '                                        tLnq.MS_LED_TV_ID = dr("ms_led_tv_id")
    '                                        tLnq.TV_NAME = dr("tv_name")
    '                                        tLnq.IP_ADDRESS = dr("ip_address")
    '                                        tLnq.START_TIME = TimeFrom 'GlobalFunction.cStrToDateTime(TmpCurrDate, TimeFrom & ":00")
    '                                        tLnq.END_TIME = TimeTo ' GlobalFunction.cStrToDateTime(TmpCurrDate, TimeTo & ":00")

    '                                        trans = New TransactionDB(SelectDB.DIPRFID)
    '                                        re = tLnq.InsertData("DigitalSignageENG.SetSignageScheduleTypeDay", trans.Trans)
    '                                        If re = False Then
    '                                            trans.RollbackTransaction()
    '                                            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeDay", tLnq.ErrorMessage)
    '                                            Exit For
    '                                        Else
    '                                            trans.CommitTransaction()
    '                                        End If
    '                                    Catch ex As Exception
    '                                        re = False
    '                                        LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeDay", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
    '                                        Exit For
    '                                    End Try
    '                                End If
    '                                If DateAdd(DateInterval.Minute, DurationMin, CurrTime).Date = CurrTime.Date Then
    '                                    'ถ้ายังอยู่ภายในวันเดียวกัน ก็ให้ทำต่อ
    '                                    CurrTime = DateAdd(DateInterval.Minute, DurationMin, CurrTime)
    '                                Else
    '                                    CurrTime = DateAdd(DateInterval.Minute, DurationMin, CurrTime)
    '                                    Exit For
    '                                End If
    '                            End If
    '                        Next
    '                        If re = False Then
    '                            Exit Do
    '                        End If
    '                    Loop While CurrTime.ToString("yyyyMMdd HH:mm") < EndTime.ToString("yyyyMMdd HH:mm")
    '                Else
    '                    'ถ้าเป็นการกำหนดค่า Schedule ข้ามวัน
    '                    DayCount += 1
    '                    CurrTime = DateAdd(DateInterval.Day, 1, CurrTime)
    '                End If
    '                CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
    '            Loop While CurrDate.ToString("yyyyMMdd") <= Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd")
    '        End If

    '        trans = New TransactionDB(SelectDB.DIPRFID)
    '        If re = True Then
    '            If UpdateSignageScheduleType(dr("id"), trans) = True Then
    '                trans.CommitTransaction()
    '            Else
    '                trans.RollbackTransaction()
    '            End If
    '        Else
    '            trans.RollbackTransaction()
    '        End If

    '        lnq = Nothing
    '    Catch ex As Exception
    '        LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeDay", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
    '    End Try
    'End Sub


    Private Shared Function CreateSignageScheduleAllDay(dt As DataTable, StartDate As DateTime, EndDate As DateTime, dr As DataRow, dtTime As DataTable, trans As TransactionDB) As Boolean
        Dim re As Boolean = False
        'dt ก็จะมีเฉพาะวันที่ที่ถูกกำหนดค่าไว้
        If dt.Rows.Count > 0 Then
            For Each DateDr As DataRow In dt.Rows
                Dim CurrTime As DateTime = StartDate
                Dim lDate As Date = Convert.ToDateTime(DateDr("CurrDate")).Date
                If lDate.Date > StartDate.Date Then
                    'ถ้าวันที่ใน Loop ไม่ใช่วันที่เริ่มต้น
                    CurrTime = New DateTime(lDate.Year, lDate.Month, lDate.Day, 0, 0, 0)
                End If

                Dim EndTime As DateTime = New DateTime(lDate.Year, lDate.Month, lDate.Day, 23, 59, 0)
                If EndTime.Date = EndDate.Date Then
                    EndTime = EndDate
                End If

                Do
                    For Each drTime As DataRow In dtTime.Rows
                        Dim DurationMinute As Integer = Convert.ToInt16(drTime("duration_minute"))

                        Dim TimeFrom As DateTime = CurrTime
                        Dim TimeTo As DateTime = CurrTime.AddMinutes(DurationMinute)
                        If TimeTo > EndTime Then
                            TimeTo = EndTime
                        End If
                        If TimeFrom >= TimeTo Then
                            CurrTime = CurrTime.AddMinutes(DurationMinute)
                            Exit For
                        End If

                        Try
                            'Dim TmpCurrDate As String = CurrDate.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
                            Dim tLnq As New MsSignageContentSchDataLinqDB
                            tLnq.MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = dr("id")
                            tLnq.SCHEDULE_NAME = dr("schedule_name")
                            tLnq.MS_SIGNAGE_CONTENT_TEMPLATE_ID = drTime("ms_signage_content_template_id")
                            tLnq.TEMPLATE_NAME = drTime("template_name")
                            tLnq.MS_LED_TV_ID = dr("ms_led_tv_id")
                            tLnq.TV_NAME = dr("tv_name")
                            tLnq.IP_ADDRESS = dr("ip_address")
                            tLnq.START_TIME = TimeFrom 'GlobalFunction.cStrToDateTime(TmpCurrDate, TimeFrom & ":00")
                            tLnq.END_TIME = TimeTo ' GlobalFunction.cStrToDateTime(TmpCurrDate, TimeTo & ":00")

                            trans = New TransactionDB(SelectDB.DIPRFID)
                            re = tLnq.InsertData("DigitalSignageENG.SetSignageScheduleTypeDay", trans.Trans)
                            If re = False Then
                                trans.RollbackTransaction()
                                LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeDay", tLnq.ErrorMessage)
                                Return False
                            Else
                                trans.CommitTransaction()
                            End If
                        Catch ex As Exception
                            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeDay", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                            Return False
                        End Try

                        CurrTime = CurrTime.AddMinutes(DurationMinute)
                        If CurrTime.Date > TimeFrom.Date Then
                            'ถ้ามีการ Add เวลาไปแล้ว กลายเป็นเวลาที่ข้ามวัน
                            Exit For
                        End If
                    Next
                Loop While CurrTime.ToString("yyyyMMdd HH:mm") <= EndTime.ToString("yyyyMMdd HH:mm")
            Next
        End If

        Return re
    End Function




    Private Shared Sub SetSignageScheduleTypeDay(dr As DataRow, dtTime As DataTable)
        Dim re As Boolean = False
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim lnq As New MsSignageScheduleDailyLinqDB
            lnq.ChkDataByMS_SIGNAGE_TEMPLATE_SCHEDULE_ID(dr("id"), trans.Trans)
            If lnq.ID > 0 Then
                Dim StartDate As DateTime = Convert.ToDateTime(dr("start_time"))
                Dim EndDate As DateTime = Convert.ToDateTime(dr("end_time"))
                Dim CurrDate As DateTime = StartDate
                Dim DayCount As Integer = lnq.RECUR_EVERY_DAYS

                'หาวันที่ที่ทำการ Config ก่อน
                Dim DateDt As New DataTable
                DateDt.Columns.Add("CurrDate", GetType(Date))
                Do
                    If DayCount = lnq.RECUR_EVERY_DAYS Then
                        DayCount = 1
                        Dim DateDr As DataRow = DateDt.NewRow
                        DateDr("CurrDate") = CurrDate.Date
                        DateDt.Rows.Add(DateDr)
                    Else
                        DayCount += 1
                    End If

                    CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                Loop While CurrDate.ToString("yyyyMMdd") <= Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd")

                re = CreateSignageScheduleAllDay(DateDt, StartDate, EndDate, dr, dtTime, trans)
            End If

            trans = New TransactionDB(SelectDB.DIPRFID)
            If re = True Then
                If UpdateSignageScheduleType(dr("id"), trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeDay", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Shared Sub SetSignageScheduleTypeWeek(dr As DataRow, dtTime As DataTable)
        Dim re As Boolean = False
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim lnq As New MsSignageScheduleWeeklyLinqDB
            lnq.ChkDataByMS_SIGNAGE_TEMPLATE_SCHEDULE_ID(dr("id"), trans.Trans)
            If lnq.ID > 0 Then
                Dim StartDate As DateTime = Convert.ToDateTime(dr("start_time"))
                Dim EndDate As DateTime = Convert.ToDateTime(dr("end_time"))
                Dim CurrDate As DateTime = StartDate

                Dim WeekCount As Integer = lnq.RECUR_EVERY_WEEK

                'หาวันที่ที่ทำการ Config ก่อน
                Dim DateDt As New DataTable
                DateDt.Columns.Add("CurrDate", GetType(Date))
                Do
                    If WeekCount = lnq.RECUR_EVERY_WEEK Then
                        WeekCount = 1

                        For i As Integer = 1 To 7
                            If CheckSignageScheduleDayOfWeek(CurrDate, lnq) = True Then
                                Dim DateDr As DataRow = DateDt.NewRow
                                DateDr("CurrDate") = CurrDate.Date
                                DateDt.Rows.Add(DateDr)
                            End If
                            CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                            If CurrDate.Date > EndDate.Date Then
                                Exit Do
                            End If
                        Next
                    Else
                        WeekCount += 1
                        CurrDate = DateAdd(DateInterval.WeekOfYear, 1, CurrDate)
                        If CurrDate.Date > EndDate.Date Then
                            Exit Do
                        End If
                    End If
                Loop While CurrDate.ToString("yyyyMMdd") <= Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd")

                re = CreateSignageScheduleAllDay(DateDt, StartDate, EndDate, dr, dtTime, trans)
            End If

            trans = New TransactionDB(SelectDB.DIPRFID)
            If re = True Then
                If UpdateSignageScheduleType(dr("id"), trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeWeek", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Shared Function CheckSignageScheduleDayOfWeek(CurrDate As DateTime, lnq As MsSignageScheduleWeeklyLinqDB) As Boolean
        Dim ret As Boolean = False
        Dim CaseDay As Integer = DatePart(DateInterval.Weekday, CurrDate)
        Select Case CaseDay
            Case 1
                ret = (lnq.SCH_SUN = "Y")
            Case 2
                ret = (lnq.SCH_MON = "Y")
            Case 3
                ret = (lnq.SCH_TUE = "Y")
            Case 4
                ret = (lnq.SCH_WED = "Y")
            Case 5
                ret = (lnq.SCH_THU = "Y")
            Case 6
                ret = (lnq.SCH_FRI = "Y")
            Case 7
                ret = (lnq.SCH_SAT = "Y")
        End Select
        Return ret
    End Function

    Private Shared Sub SetSignageScheduleTypeMonth(dr As DataRow, dtTime As DataTable)
        Dim re As Boolean = False
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim lnq As New MsSignageScheduleMonthlyLinqDB
            Dim dt As DataTable = lnq.GetDataList("ms_signage_template_schedule_id='" & dr("id") & "'", "month_no,date_no", trans.Trans)
            If dt.Rows.Count > 0 Then
                Dim StartDate As DateTime = Convert.ToDateTime(dr("start_time"))
                Dim EndDate As DateTime = Convert.ToDateTime(dr("end_time"))
                Dim CurrDate As DateTime = StartDate

                Dim DateDt As New DataTable
                DateDt.Columns.Add("CurrDate", GetType(Date))
                Do
                    Dim vMonthNo As Integer = CurrDate.Month
                    Dim vDateNo As Integer = CurrDate.Day
                    dt.DefaultView.RowFilter = "month_no='" & vMonthNo & "' and date_no='" & vDateNo & "'"
                    If dt.DefaultView.Count > 0 Then
                        Dim DateDr As DataRow = DateDt.NewRow
                        DateDr("CurrDate") = CurrDate.Date
                        DateDt.Rows.Add(DateDr)
                    End If
                    dt.DefaultView.RowFilter = ""

                    CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                Loop While CurrDate.ToString("yyyyMMdd") <= EndDate.ToString("yyyyMMdd")

                re = CreateSignageScheduleAllDay(DateDt, StartDate, EndDate, dr, dtTime, trans)
            End If
            dt.Dispose()

            trans = New TransactionDB(SelectDB.DIPRFID)
            If re = True Then
                If UpdateSignageScheduleType(dr("id"), trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeMonth", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    'Private Shared Sub SetSignageScheduleTypeWeek(dr As DataRow, dtTime As DataTable)
    '    Dim re As Boolean = False
    '    Try
    '        Dim trans As New TransactionDB(SelectDB.DIPRFID)
    '        Dim lnq As New MsSignageScheduleWeeklyLinqDB
    '        lnq.ChkDataByMS_SIGNAGE_TEMPLATE_SCHEDULE_ID(dr("id"), trans.Trans)
    '        If lnq.ID > 0 Then
    '            Dim CurrDate As DateTime = Convert.ToDateTime(dr("start_time"))
    '            Dim EndDate As DateTime = Convert.ToDateTime(dr("end_time"))
    '            Dim CurrTime As DateTime = CurrDate

    '            Dim WeekCount As Integer = lnq.RECUR_EVERY_WEEK
    '            Do
    '                re = True
    '                If WeekCount = lnq.RECUR_EVERY_WEEK Then
    '                    WeekCount = 1

    '                    Dim vDate As DateTime = CurrDate
    '                    For i As Integer = 1 To 7
    '                        If vDate.ToString("yyyyMMdd") <= Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd") Then
    '                            If CheckSignageScheduleDayOfWeek(vDate, lnq) = True Then

    '                                Dim EndTime As DateTime = New DateTime(CurrDate.Year, CurrDate.Month, CurrDate.Day, 23, 59, 0)
    '                                Do
    '                                    If EndTime.ToString("yyyyMMdd") = EndDate.ToString("yyyyMMdd") Then
    '                                        'ถ้า EndTime ตรงกับวันที่สุดท้าย ให้กำหนดเป็นเวลาสุดท้ายของวันนั้น
    '                                        EndTime = EndDate
    '                                    End If

    '                                    Dim DurationMin As Integer = 0
    '                                    For Each drTime As DataRow In dtTime.Rows
    '                                        DurationMin = Convert.ToInt16(drTime("duration_minute"))
    '                                        If DurationMin > 0 Then
    '                                            Try
    '                                                Dim TimeFrom As DateTime = CurrTime
    '                                                Dim TimeTo As DateTime = CurrTime.AddMinutes(DurationMin)

    '                                                'ถ้าเป็นวันที่สุดท้ายใน Schedule
    '                                                If vDate.ToString("yyyyMMdd") = Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd") Then
    '                                                    Dim TmpTimeTo As DateTime = Convert.ToDateTime(dr("end_time"))

    '                                                    If TimeFrom <= TmpTimeTo Then
    '                                                        If TimeTo > TmpTimeTo Then
    '                                                            TimeTo = TmpTimeTo
    '                                                        End If
    '                                                    Else
    '                                                        CurrTime = DateAdd(DateInterval.Minute, DurationMin, CurrTime)
    '                                                        Exit For
    '                                                    End If
    '                                                End If

    '                                                'Dim TmpCurrDate As String = vDate.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
    '                                                Dim tLnq As New MsSignageContentSchDataLinqDB
    '                                                tLnq.MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = dr("id")
    '                                                tLnq.SCHEDULE_NAME = dr("schedule_name")
    '                                                tLnq.MS_SIGNAGE_CONTENT_TEMPLATE_ID = drTime("ms_signage_content_template_id")
    '                                                tLnq.TEMPLATE_NAME = drTime("template_name")
    '                                                tLnq.MS_LED_TV_ID = dr("ms_led_tv_id")
    '                                                tLnq.TV_NAME = dr("tv_name")
    '                                                tLnq.IP_ADDRESS = dr("ip_address")
    '                                                tLnq.START_TIME = TimeFrom 'GlobalFunction.cStrToDateTime(TmpCurrDate, TimeFrom & ":00")
    '                                                tLnq.END_TIME = TimeTo 'GlobalFunction.cStrToDateTime(TmpCurrDate, TimeTo & ":00")

    '                                                trans = New TransactionDB(SelectDB.DIPRFID)
    '                                                re = tLnq.InsertData("DigitalSignageENG.SetSignageScheduleTypeWeek", trans.Trans)
    '                                                If re = False Then
    '                                                    trans.RollbackTransaction()
    '                                                    LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeWeek", tLnq.ErrorMessage)
    '                                                    Exit For
    '                                                Else
    '                                                    trans.CommitTransaction()
    '                                                End If
    '                                            Catch ex As Exception
    '                                                re = False
    '                                                LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeWeek", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
    '                                                Exit For
    '                                            End Try
    '                                        End If
    '                                        If DateAdd(DateInterval.Minute, DurationMin, CurrTime).Date = CurrTime.Date Then
    '                                            CurrTime = DateAdd(DateInterval.Minute, DurationMin, CurrTime)
    '                                        Else
    '                                            CurrTime = DateAdd(DateInterval.Minute, DurationMin, CurrTime)
    '                                            Exit For
    '                                        End If
    '                                    Next
    '                                    If re = False Then
    '                                        Exit Do
    '                                    End If
    '                                Loop While CurrTime.ToString("yyyyMMdd HH:mm") < EndTime.ToString("yyyyMMdd HH:mm")
    '                            Else
    '                                Dim TmpDate As DateTime = DateAdd(DateInterval.Day, 1, vDate)
    '                                CurrTime = New DateTime(TmpDate.Year, TmpDate.Month, TmpDate.Day, 0, 0, 0)
    '                            End If
    '                        End If
    '                        vDate = DateAdd(DateInterval.Day, 1, vDate)
    '                        CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
    '                    Next
    '                    If re = False Then
    '                        Exit Do
    '                    End If
    '                Else
    '                    WeekCount += 1
    '                    CurrDate = DateAdd(DateInterval.WeekOfYear, 1, CurrDate)
    '                    CurrTime = New DateTime(CurrDate.Year, CurrDate.Month, CurrDate.Day, 0, 0, 0)
    '                End If
    '            Loop While CurrDate.ToString("yyyyMMdd") <= Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd")
    '        End If

    '        trans = New TransactionDB(SelectDB.DIPRFID)
    '        If re = True Then
    '            If UpdateSignageScheduleType(dr("id"), trans) = True Then
    '                trans.CommitTransaction()
    '            Else
    '                trans.RollbackTransaction()
    '            End If
    '        Else
    '            trans.RollbackTransaction()
    '        End If

    '        lnq = Nothing
    '    Catch ex As Exception
    '        LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeWeek", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
    '    End Try
    'End Sub

    'Private Shared Sub SetSignageScheduleTypeMonth(dr As DataRow, dtTime As DataTable)
    '    Dim re As Boolean = False
    '    Try
    '        Dim trans As New TransactionDB(SelectDB.DIPRFID)
    '        Dim lnq As New MsSignageScheduleMonthlyLinqDB
    '        Dim dt As DataTable = lnq.GetDataList("ms_signage_template_schedule_id='" & dr("id") & "'", "month_no,date_no", trans.Trans)
    '        If dt.Rows.Count > 0 Then
    '            Dim CurrDate As DateTime = Convert.ToDateTime(dr("start_time"))
    '            Dim EndDate As DateTime = Convert.ToDateTime(dr("end_time"))
    '            Dim CurrTime As DateTime = CurrDate

    '            Do
    '                re = True
    '                Dim vMonthNo As Integer = CurrDate.Month
    '                Dim vDateNo As Integer = CurrDate.Day
    '                dt.DefaultView.RowFilter = "month_no='" & vMonthNo & "' and date_no='" & vDateNo & "'"
    '                If dt.DefaultView.Count > 0 Then
    '                    If CurrTime.ToString("MMdd") <> vMonthNo.ToString.PadLeft(2, "0") & vDateNo.ToString.PadLeft(2, "0") Then
    '                        CurrTime = New DateTime(CurrDate.Year, vMonthNo, vDateNo, 0, 0, 0)
    '                    End If

    '                    Dim EndTime As DateTime = New DateTime(CurrDate.Year, CurrDate.Month, CurrDate.Day, 23, 59, 0)
    '                    Do
    '                        If EndTime.ToString("yyyyMMdd") = EndDate.ToString("yyyyMMdd") Then
    '                            'ถ้า EndTime ตรงกับวันที่สุดท้าย ให้กำหนดเป็นเวลาสุดท้ายของวันนั้น
    '                            EndTime = EndDate
    '                        End If

    '                        Dim DurationMin As Integer = 0
    '                        For Each drTime As DataRow In dtTime.Rows
    '                            DurationMin = Convert.ToInt16(drTime("duration_minute"))
    '                            If DurationMin > 0 Then
    '                                Try
    '                                    Dim TimeFrom As DateTime = CurrTime
    '                                    Dim TimeTo As DateTime = CurrTime.AddMinutes(DurationMin)

    '                                    'ถ้าเป็นวันที่สุดท้ายใน Schedule
    '                                    If CurrDate.ToString("yyyyMMdd") = Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd") Then
    '                                        Dim TmpTimeTo As String = Convert.ToDateTime(dr("end_time")).ToString("HH:mm")

    '                                        If TimeFrom <= TmpTimeTo Then
    '                                            If TimeTo > TmpTimeTo Then
    '                                                TimeTo = TmpTimeTo
    '                                            End If
    '                                        Else
    '                                            CurrTime = DateAdd(DateInterval.Minute, DurationMin, CurrTime)
    '                                            Exit For
    '                                        End If
    '                                    End If

    '                                    'Dim TmpCurrDate As String = CurrDate.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US"))
    '                                    Dim tLnq As New MsSignageContentSchDataLinqDB
    '                                    tLnq.MS_SIGNAGE_TEMPLATE_SCHEDULE_ID = dr("id")
    '                                    tLnq.SCHEDULE_NAME = dr("schedule_name")
    '                                    tLnq.MS_SIGNAGE_CONTENT_TEMPLATE_ID = drTime("ms_signage_content_template_id")
    '                                    tLnq.TEMPLATE_NAME = drTime("template_name")
    '                                    tLnq.MS_LED_TV_ID = dr("ms_led_tv_id")
    '                                    tLnq.TV_NAME = dr("tv_name")
    '                                    tLnq.IP_ADDRESS = dr("ip_address")
    '                                    tLnq.START_TIME = TimeFrom 'GlobalFunction.cStrToDateTime(TmpCurrDate, TimeFrom & ":00")
    '                                    tLnq.END_TIME = TimeTo 'GlobalFunction.cStrToDateTime(TmpCurrDate, TimeTo & ":00")

    '                                    trans = New TransactionDB(SelectDB.DIPRFID)
    '                                    re = tLnq.InsertData("DigitalSignageENG.SetSignageScheduleTypeMonth", trans.Trans)
    '                                    If re = False Then
    '                                        trans.RollbackTransaction()
    '                                        LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeMonth", tLnq.ErrorMessage)
    '                                        Exit For
    '                                    Else
    '                                        trans.CommitTransaction()
    '                                    End If
    '                                Catch ex As Exception
    '                                    re = False
    '                                    LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeMonth", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
    '                                    Exit For
    '                                End Try
    '                                If re = False Then
    '                                    Exit Do
    '                                End If
    '                            End If
    '                            If DateAdd(DateInterval.Minute, DurationMin, CurrTime).Date = CurrTime.Date Then
    '                                CurrTime = DateAdd(DateInterval.Minute, DurationMin, CurrTime)
    '                            Else
    '                                CurrTime = DateAdd(DateInterval.Minute, DurationMin, CurrTime)
    '                                Exit For
    '                            End If
    '                        Next
    '                    Loop While CurrTime.ToString("yyyyMMdd HH:mm") < EndTime.ToString("yyyyMMdd HH:mm")
    '                End If
    '                dt.DefaultView.RowFilter = ""
    '                CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
    '            Loop While CurrDate.ToString("yyyyMMdd") <= Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd")
    '        End If
    '        dt.Dispose()

    '        trans = New TransactionDB(SelectDB.DIPRFID)
    '        If re = True Then
    '            If UpdateSignageScheduleType(dr("id"), trans) = True Then
    '                trans.CommitTransaction()
    '            Else
    '                trans.RollbackTransaction()
    '            End If
    '        Else
    '            trans.RollbackTransaction()
    '        End If

    '        lnq = Nothing
    '    Catch ex As Exception
    '        LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetSignageScheduleTypeMonth", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
    '    End Try
    'End Sub


#End Region

    Private Shared Function DeleteSignageContentScheduleData(MsSignageTemplateScheduleID As Long) As Boolean
        Dim ret As Boolean = False
        Try
            Dim sql As String = "delete from MS_SIGNAGE_CONTENT_SCH_DATA where ms_signage_template_schedule_id='" & MsSignageTemplateScheduleID & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql)
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Private Shared Function UpdateSignageScheduleType(MsSignageTemplateScheduleID As Long, trans As TransactionDB) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New MsSignageTemplateScheduleLinqDB
            lnq.GetDataByPK(MsSignageTemplateScheduleID, trans.Trans)
            If lnq.ID > 0 Then
                lnq.SCHEDULE_STATUS = "Y"
                ret = lnq.UpdateByPK("DigitalSignageENG.UpdateSignageScheduleType", trans.Trans)
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Private Shared Function GetSignageContentSchedule(wh As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select st.id, st.schedule_name, " & vbNewLine
            sql += " st.ms_led_tv_id, tv.tv_name, tv.install_position, tv.ip_address, tv.ms_floor_id, fl.floor_name, " & vbNewLine
            sql += " st.start_time, st.end_time, st.active_status, st.schedule_type, st.schedule_status " & vbNewLine
            sql += " from ms_signage_template_schedule st" & vbNewLine
            sql += " inner join ms_led_tv tv on tv.id=st.ms_led_tv_id" & vbNewLine
            sql += " inner join ms_floor fl on fl.id=tv.ms_floor_id" & vbNewLine
            If wh.Trim <> "" Then
                sql += " where 1=1 " & wh & vbNewLine
            End If
            sql += " order by tv.ip_address, st.schedule_name" & vbNewLine

            dt = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            dt = New DataTable
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.GetSignageContentSchedule", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return dt
    End Function
    Private Shared Function GetSignageContentScheduleTime(MsSignageTemplateScheduleID As Long) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select t.id, t.ms_signage_template_schedule_id, t.ms_signage_content_template_id, t.duration_minute,st.template_name " & vbNewLine
            sql += " from MS_SIGNAGE_SCHEDULE_TIME t " & vbNewLine
            sql += " inner join MS_SIGNAGE_CONTENT_TEMPLATE st on st.id=t.ms_signage_content_template_id " & vbNewLine
            sql += " where t.ms_signage_template_schedule_id='" & MsSignageTemplateScheduleID & "' " & vbNewLine
            sql += " order by t.id "

            Dim lnq As New MsSignageScheduleTimeLinqDB
            dt = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Public Shared Function CheckDuplicateSignageScheduleTime(MsSignageTemplateScheduleID As Long, MsLedTvID As Long, StartDateTime As DateTime, EndDateTime As DateTime) As Boolean
        Dim ret As Boolean = False
        Try
            Dim CheckTimeFrom As String = CType(StartDateTime, DateTime).AddMinutes(1).ToString("HH:mm")
            Dim CheckTimeTo As String = CType(EndDateTime, DateTime).AddMinutes(-1).ToString("HH:mm")

            Dim lnq As New MsSignageTemplateScheduleLinqDB
            lnq.GetDataByPK(MsSignageTemplateScheduleID, Nothing)
            If lnq.ID > 0 Then
                Dim CurrDate As DateTime = StartDateTime
                Do
                    Dim chkTimeFrom As String = CurrDate.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & " " & CheckTimeFrom
                    Dim chkTimeTo As String = CurrDate.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & " " & CheckTimeTo

                    Dim sql As String = ""
                    sql += " declare @chkTimeFrom varchar(16); set @chkTimeFrom='" & chkTimeFrom & "'" & vbNewLine
                    sql += " declare @chkTimeTo varchar(16); set @chkTimeTo='" & chkTimeTo & "'" & vbNewLine
                    sql += " Select id" & vbNewLine
                    sql += " from MS_SIGNAGE_CONTENT_SCH_DATA" & vbNewLine
                    sql += " where ms_led_tv_id = '" & MsLedTvID & "'" & vbNewLine
                    sql += " and (convert(varchar(16),start_time,120) between @chkTimeFrom and @chkTimeTo " & vbNewLine
                    sql += "        or convert(varchar(16),end_time,120) between @chkTimeFrom and @chkTimeTo)" & vbNewLine
                    sql += " and ms_signage_template_schedule_id<>'" & MsSignageTemplateScheduleID & "'" & vbNewLine
                    sql += " union" & vbNewLine
                    sql += " Select id" & vbNewLine
                    sql += " from MS_SIGNAGE_CONTENT_SCH_DATA" & vbNewLine
                    sql += " where ms_led_tv_id = '" & MsLedTvID & "'" & vbNewLine
                    sql += " and (convert(varchar(16),start_time,120)  between @chkTimeFrom and @chkTimeTo " & vbNewLine
                    sql += "        or convert(varchar(16),end_time,120) between @chkTimeFrom and @chkTimeTo)" & vbNewLine
                    sql += " and ms_signage_template_schedule_id<>'" & MsSignageTemplateScheduleID & "'" & vbNewLine
                    sql += " union" & vbNewLine
                    sql += " Select id" & vbNewLine
                    sql += " from MS_SIGNAGE_CONTENT_SCH_DATA" & vbNewLine
                    sql += " where ms_led_tv_id = '" & MsLedTvID & "'" & vbNewLine
                    sql += " and convert(varchar(16),start_time,120)<=@chkTimeFrom and convert(varchar(16),end_time,120)>=@chkTimeTo" & vbNewLine
                    sql += " and ms_signage_template_schedule_id<>'" & MsSignageTemplateScheduleID & "'" & vbNewLine
                    sql += " union" & vbNewLine
                    sql += " Select id" & vbNewLine
                    sql += " from MS_SIGNAGE_CONTENT_SCH_DATA" & vbNewLine
                    sql += " where ms_led_tv_id = '" & MsLedTvID & "'" & vbNewLine
                    sql += " and @chkTimeFrom<=convert(varchar(16),start_time,120) and @chkTimeTo>=convert(varchar(16),end_time,120)" & vbNewLine
                    sql += " and ms_signage_template_schedule_id<>'" & MsSignageTemplateScheduleID & "'" & vbNewLine

                    Dim tmpDt As DataTable = DIPRFIDSqlDB.ExecuteTable(sql)
                    If tmpDt.Rows.Count > 0 Then
                        ret = True
                        Exit Do
                    End If

                    CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                Loop While CurrDate.ToString("yyyyMMdd") <= EndDateTime.ToString("yyyyMMdd")
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = False
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.CheckDuplicateSignageScheduleTime", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Function GetCurrentSignageURL(LedTvIPAddress As String) As String
        Dim ret As String = ""
        Try
            Dim sql As String = "select  sct.template_url "
            sql += " from MS_SIGNAGE_CONTENT_SCH_DATA scs"
            sql += " inner join MS_SIGNAGE_CONTENT_TEMPLATE sct on sct.id=scs.ms_signage_content_template_id"
            sql += " where scs.ip_address = '" & LedTvIPAddress & "'"
            sql += " and getdate() between scs.start_time and scs.end_time"

            Dim dt As DataTable = DIPRFIDSqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("template_url")
            Else
                sql = " select sct.template_url"
                sql += " from MS_LED_TV tv "
                sql += " inner join MS_SIGNAGE_CONTENT_TEMPLATE sct on sct.id=tv.ms_signage_template_id_default"
                sql += " where tv.ip_address='" & LedTvIPAddress & "'"

                dt = DIPRFIDSqlDB.ExecuteTable(sql)
                If dt.Rows.Count > 0 Then
                    ret = dt.Rows(0)("template_url")
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.GetCurrentSignageURL", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
#End Region

#Region "Text Scrolling Schedule"



    Private Shared Function GetTextScrollingSchedule(wh As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = "select ts.id,  ts.ms_led_tv_id, tv.tv_name, tv.install_position,"
            sql += " tv.ip_address, tv.ms_floor_id, fl.floor_name, ts.start_time, ts.end_time,"
            sql += " ts.active_status, ts.schedule_type, ts.schedule_status"
            sql += " from MS_TEXT_SCROLLING_SCHEDULE ts"
            sql += " inner join MS_LED_TV tv on tv.id=ts.ms_led_tv_id"
            sql += " inner join MS_FLOOR fl on fl.id=tv.ms_floor_id"
            If wh.Trim <> "" Then
                sql += " where 1=1 " & wh
            End If
            sql += " order by tv.ip_address"

            dt = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            dt = New DataTable
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.GetTextScrollingSchedule", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return dt
    End Function

    Private Shared Function DeleteTextScrollingScheduleData(MsTextScrollingScheduleID As Long) As Boolean
        Dim ret As Boolean = False
        Try
            Dim sql As String = "delete from MS_TEXT_SCROLLING_SCH_DATA where ms_text_scrolling_schedule_id='" & MsTextScrollingScheduleID & "'"
            ret = DIPRFIDSqlDB.ExecuteNonQuery(sql)
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Private Shared Function GetTextScrollingScheduleTime(MsTextScrollingScheduleId As Long) As DataTable
        Dim dt As New DataTable
        Try
            'Dim sql As String = "select t.id, t.ms_text_scrolling_schedule_id, t.scrolling_text, t.duration_minute, t.speed_level "
            Dim lnq As New MsTextScrollingSchTimeLinqDB
            dt = lnq.GetDataList("ms_text_scrolling_schedule_id='" & MsTextScrollingScheduleId & "'", "id", Nothing)
            lnq = Nothing
        Catch ex As Exception
            dt = New DataTable
        End Try

        Return dt
    End Function

    Public Shared Sub SetScheduleTextScrolling()
        Try
            Dim dt As DataTable = GetTextScrollingSchedule(" and ts.schedule_status='N' and ts.active_status='Y'")
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    If DeleteTextScrollingScheduleData(dr("id")) = True Then
                        Dim dtTime As DataTable = GetTextScrollingScheduleTime(dr("id"))

                        Select Case dr("schedule_type")
                            Case "D"
                                SetTextScheduleTypeDay(dr, dtTime)
                            Case "W"
                                SetTextScheduleTypeWeek(dr, dtTime)
                            Case "M"
                                SetTextScheduleTypeMonth(dr, dtTime)
                        End Select
                    End If
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetScheduleTextScrolling", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

#Region "Set Text Scrolling all Type"
    Private Shared Function CreateTextScrollingScheduleAllDay(dt As DataTable, StartDate As DateTime, EndDate As DateTime, dr As DataRow, dtTime As DataTable, trans As TransactionDB) As Boolean
        Dim re As Boolean = False
        'dt ก็จะมีเฉพาะวันที่ที่ถูกกำหนดค่าไว้
        If dt.Rows.Count > 0 Then
            For Each DateDr As DataRow In dt.Rows
                Dim CurrTime As DateTime = StartDate
                Dim lDate As Date = Convert.ToDateTime(DateDr("CurrDate")).Date
                If lDate.Date > StartDate.Date Then
                    'ถ้าวันที่ใน Loop ไม่ใช่วันที่เริ่มต้น
                    CurrTime = New DateTime(lDate.Year, lDate.Month, lDate.Day, 0, 0, 0)
                End If

                Dim EndTime As DateTime = New DateTime(lDate.Year, lDate.Month, lDate.Day, 23, 59, 0)
                If EndTime.Date = EndDate.Date Then
                    EndTime = EndDate
                End If

                Do
                    For Each drTime As DataRow In dtTime.Rows
                        Dim DurationMinute As Integer = Convert.ToInt16(drTime("duration_minute"))

                        Dim TimeFrom As DateTime = CurrTime
                        Dim TimeTo As DateTime = CurrTime.AddMinutes(DurationMinute)
                        If TimeTo > EndTime Then
                            TimeTo = EndTime
                        End If
                        If TimeFrom >= TimeTo Then
                            CurrTime = CurrTime.AddMinutes(DurationMinute)
                            Exit For
                        End If

                        Try
                            Dim tLnq As New MsTextScrollingSchDataLinqDB
                            tLnq.MS_TEXT_SCROLLING_SCHEDULE_ID = dr("id")
                            tLnq.SCROLLING_TEXT = drTime("scrolling_text")
                            tLnq.SPEED_LEVEL = drTime("speed_level")
                            tLnq.MS_LED_TV_ID = dr("ms_led_tv_id")
                            tLnq.TV_NAME = dr("tv_name")
                            tLnq.IP_ADDRESS = dr("ip_address")
                            tLnq.START_TIME = TimeFrom
                            tLnq.END_TIME = TimeTo

                            trans = New TransactionDB(SelectDB.DIPRFID)
                            re = tLnq.InsertData("DigitalSignageENG.SetTextScheduleTypeDay", trans.Trans)
                            If re = False Then
                                trans.RollbackTransaction()
                                LogFile.LogENG.SaveErrLog("DigitalSignageENG.CreateTextScrollingScheduleAllDay", tLnq.ErrorMessage)
                                Exit For
                            Else
                                trans.CommitTransaction()
                            End If
                            tLnq = Nothing
                        Catch ex As Exception
                            re = False
                            LogFile.LogENG.SaveErrLog("DigitalSignageENG.CreateTextScrollingScheduleAllDay", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                            Exit For
                        End Try

                        CurrTime = CurrTime.AddMinutes(DurationMinute)
                        If CurrTime.Date > TimeFrom.Date Then
                            'ถ้ามีการ Add เวลาไปแล้ว กลายเป็นเวลาที่ข้ามวัน
                            Exit For
                        End If
                    Next
                Loop While CurrTime.ToString("yyyyMMdd HH:mm") <= EndTime.ToString("yyyyMMdd HH:mm")
            Next
        End If

        Return re
    End Function
    Private Shared Sub SetTextScheduleTypeDay(dr As DataRow, dtTime As DataTable)
        Dim re As Boolean = False
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim lnq As New MsTextScrollingSchDailyLinqDB
            lnq.ChkDataByMS_TEXT_SCROLLING_SCHEDULE_ID(dr("id"), trans.Trans)
            If lnq.ID > 0 Then
                Dim StartDate As DateTime = Convert.ToDateTime(dr("start_time"))
                Dim EndDate As DateTime = Convert.ToDateTime(dr("end_time"))
                Dim CurrDate As DateTime = StartDate
                Dim DayCount As Integer = lnq.RECUR_EVERY_DAYS

                'หาวันที่ที่ทำการ Config ก่อน
                Dim DateDt As New DataTable
                DateDt.Columns.Add("CurrDate", GetType(Date))
                Do
                    If DayCount = lnq.RECUR_EVERY_DAYS Then
                        DayCount = 1
                        Dim DateDr As DataRow = DateDt.NewRow
                        DateDr("CurrDate") = CurrDate.Date
                        DateDt.Rows.Add(DateDr)
                    Else
                        DayCount += 1
                    End If

                    CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                Loop While CurrDate.ToString("yyyyMMdd") <= Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd")

                re = CreateTextScrollingScheduleAllDay(DateDt, StartDate, EndDate, dr, dtTime, trans)
            End If

            trans = New TransactionDB(SelectDB.DIPRFID)
            If re = True Then
                If UpdateTextScrollingScheduleType(dr("id"), trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetTextScheduleTypeDay", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Shared Function CheckTextScrollingScheduleDayOfWeek(CurrDate As DateTime, lnq As MsTextScrollingSchWeeklyLinqDB) As Boolean
        Dim ret As Boolean = False
        Dim CaseDay As Integer = DatePart(DateInterval.Weekday, CurrDate)
        Select Case CaseDay
            Case 1
                ret = (lnq.SCH_SUN = "Y")
            Case 2
                ret = (lnq.SCH_MON = "Y")
            Case 3
                ret = (lnq.SCH_TUE = "Y")
            Case 4
                ret = (lnq.SCH_WED = "Y")
            Case 5
                ret = (lnq.SCH_THU = "Y")
            Case 6
                ret = (lnq.SCH_FRI = "Y")
            Case 7
                ret = (lnq.SCH_SAT = "Y")
        End Select
        Return ret
    End Function
    Private Shared Sub SetTextScheduleTypeWeek(dr As DataRow, dtTime As DataTable)
        Dim re As Boolean = False
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim lnq As New MsTextScrollingSchWeeklyLinqDB
            lnq.ChkDataByMS_TEXT_SCROLLING_SCHEDULE_ID(dr("id"), trans.Trans)
            If lnq.ID > 0 Then
                Dim StartDate As DateTime = Convert.ToDateTime(dr("start_time"))
                Dim EndDate As DateTime = Convert.ToDateTime(dr("end_time"))
                Dim CurrDate As DateTime = StartDate

                Dim WeekCount As Integer = lnq.RECUR_EVERY_WEEK

                 'หาวันที่ที่ทำการ Config ก่อน
                Dim DateDt As New DataTable
                DateDt.Columns.Add("CurrDate", GetType(Date))
                Do
                    If WeekCount = lnq.RECUR_EVERY_WEEK Then
                        WeekCount = 1

                        For i As Integer = 1 To 7
                            If CheckTextScrollingScheduleDayOfWeek(CurrDate, lnq) = True Then
                                Dim DateDr As DataRow = DateDt.NewRow
                                DateDr("CurrDate") = CurrDate.Date
                                DateDt.Rows.Add(DateDr)
                            End If
                            CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                            If CurrDate.Date > EndDate.Date Then
                                Exit Do
                            End If
                        Next
                    Else
                        WeekCount += 1
                        CurrDate = DateAdd(DateInterval.WeekOfYear, 1, CurrDate)
                        If CurrDate.Date > EndDate.Date Then
                            Exit Do
                        End If
                    End If
                Loop While CurrDate.ToString("yyyyMMdd") <= Convert.ToDateTime(dr("end_time")).ToString("yyyyMMdd")

                re = CreateTextScrollingScheduleAllDay(DateDt, StartDate, EndDate, dr, dtTime, trans)
            End If

            trans = New TransactionDB(SelectDB.DIPRFID)
            If re = True Then
                If UpdateTextScrollingScheduleType(dr("id"), trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetTextScheduleTypeWeek", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Shared Function GetFirstDayOfWeek(ByVal ServiceDate As Date) As Date
        Dim CalDate As Date = DateAdd(DateInterval.Day, -1, ServiceDate)
        Dim FirstDay As Date = DateAdd(DateInterval.Day, 1 - CalDate.DayOfWeek, CalDate)
        If FirstDay < New Date(ServiceDate.Year, 1, 1) Then
            FirstDay = New Date(ServiceDate.Year, 1, 1)
        End If
        Return FirstDay
    End Function

    Private Shared Sub SetTextScheduleTypeMonth(dr As DataRow, dtTime As DataTable)
        Dim re As Boolean = False
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim lnq As New MsTextScrollingSchMonthlyLinqDB
            Dim dt As DataTable = lnq.GetDataList("ms_text_scrolling_schedule_id='" & dr("id") & "'", "month_no,date_no", trans.Trans)
            If dt.Rows.Count > 0 Then
                Dim StartDate As DateTime = Convert.ToDateTime(dr("start_time"))
                Dim EndDate As DateTime = Convert.ToDateTime(dr("end_time"))
                Dim CurrDate As DateTime = StartDate

                Dim DateDt As New DataTable
                DateDt.Columns.Add("CurrDate", GetType(Date))

                Do
                    Dim vMonthNo As Integer = CurrDate.Month
                    Dim vDateNo As Integer = CurrDate.Day
                    dt.DefaultView.RowFilter = "month_no='" & vMonthNo & "' and date_no='" & vDateNo & "'"
                    If dt.DefaultView.Count > 0 Then
                        Dim DateDr As DataRow = DateDt.NewRow
                        DateDr("CurrDate") = CurrDate.Date
                        DateDt.Rows.Add(DateDr)
                    End If
                    dt.DefaultView.RowFilter = ""

                    CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                Loop While CurrDate.ToString("yyyyMMdd") <= EndDate.ToString("yyyyMMdd")

                re = CreateTextScrollingScheduleAllDay(DateDt, StartDate, EndDate, dr, dtTime, trans)
            End If
            dt.Dispose()

            trans = New TransactionDB(SelectDB.DIPRFID)
            If re = True Then
                If UpdateTextScrollingScheduleType(dr("id"), trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.SetTextScheduleTypeMonth", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
#End Region

    Private Shared Function UpdateTextScrollingScheduleType(MsTextScrollingScheduleID As Long, trans As TransactionDB) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New MsTextScrollingScheduleLinqDB
            lnq.GetDataByPK(MsTextScrollingScheduleID, trans.Trans)
            If lnq.ID > 0 Then
                lnq.SCHEDULE_STATUS = "Y"
                ret = lnq.UpdateByPK("DigitalSignageENG.UpdateTextScrollingScheduleType", trans.Trans)
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function

    Public Shared Function CheckDuplicateTextScheduleTime(MsTextScrollingScheduleID As Long, MsLedTvID As Long, StartDateTime As DateTime, EndDateTime As DateTime) As Boolean
        Dim ret As Boolean = False
        Try
            Dim CheckTimeFrom As String = CType(StartDateTime, DateTime).AddMinutes(1).ToString("HH:mm")
            Dim CheckTimeTo As String = CType(EndDateTime, DateTime).AddMinutes(-1).ToString("HH:mm")

            Dim lnq As New MsTextScrollingScheduleLinqDB
            lnq.GetDataByPK(MsTextScrollingScheduleID, Nothing)
            If lnq.ID > 0 Then
                Dim CurrDate As DateTime = StartDateTime
                Do
                    Dim chkTimeFrom As String = CurrDate.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & " " & CheckTimeFrom
                    Dim chkTimeTo As String = CurrDate.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & " " & CheckTimeTo

                    Dim sql As String = ""
                    sql += " declare @chkTimeFrom varchar(16); set @chkTimeFrom='" & chkTimeFrom & "'" & vbNewLine
                    sql += " declare @chkTimeTo varchar(16); set @chkTimeTo='" & chkTimeTo & "'" & vbNewLine
                    sql += " Select id" & vbNewLine
                    sql += " from MS_TEXT_SCROLLING_SCH_DATA" & vbNewLine
                    sql += " where ms_led_tv_id = '" & MsLedTvID & "'" & vbNewLine
                    sql += " and (convert(varchar(16),start_time,120) between @chkTimeFrom and @chkTimeTo " & vbNewLine
                    sql += "        or convert(varchar(16),end_time,120) between @chkTimeFrom and @chkTimeTo)" & vbNewLine
                    sql += " and ms_text_scrolling_schedule_id<>'" & MsTextScrollingScheduleID & "'" & vbNewLine
                    sql += " union" & vbNewLine
                    sql += " Select id" & vbNewLine
                    sql += " from MS_TEXT_SCROLLING_SCH_DATA" & vbNewLine
                    sql += " where ms_led_tv_id = '" & MsLedTvID & "'" & vbNewLine
                    sql += " and (convert(varchar(16),start_time,120)  between @chkTimeFrom and @chkTimeTo " & vbNewLine
                    sql += "        or convert(varchar(16),end_time,120) between @chkTimeFrom and @chkTimeTo)" & vbNewLine
                    sql += " and ms_text_scrolling_schedule_id<>'" & MsTextScrollingScheduleID & "'" & vbNewLine
                    sql += " union" & vbNewLine
                    sql += " Select id" & vbNewLine
                    sql += " from MS_TEXT_SCROLLING_SCH_DATA" & vbNewLine
                    sql += " where ms_led_tv_id = '" & MsLedTvID & "'" & vbNewLine
                    sql += " and convert(varchar(16),start_time,120)<=@chkTimeFrom and convert(varchar(16),end_time,120)>=@chkTimeTo" & vbNewLine
                    sql += " and ms_text_scrolling_schedule_id<>'" & MsTextScrollingScheduleID & "'" & vbNewLine
                    sql += " union" & vbNewLine
                    sql += " Select id" & vbNewLine
                    sql += " from MS_TEXT_SCROLLING_SCH_DATA" & vbNewLine
                    sql += " where ms_led_tv_id = '" & MsLedTvID & "'" & vbNewLine
                    sql += " and @chkTimeFrom<=convert(varchar(16),start_time,120) and @chkTimeTo>=convert(varchar(16),end_time,120)" & vbNewLine
                    sql += " and ms_text_scrolling_schedule_id<>'" & MsTextScrollingScheduleID & "'" & vbNewLine

                    Dim tmpDt As DataTable = DIPRFIDSqlDB.ExecuteTable(sql)
                    If tmpDt.Rows.Count > 0 Then
                        ret = True
                        Exit Do
                    End If

                    CurrDate = DateAdd(DateInterval.Day, 1, CurrDate)
                Loop While CurrDate.ToString("yyyyMMdd") <= EndDateTime.ToString("yyyyMMdd")
            End If
            lnq = Nothing


        Catch ex As Exception
            ret = False
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.CheckDuplicateTextScheduleTime", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Function GetCurrentTextScrolling(LedTvIPAddress As String) As String
        Dim ret As String = ""
        Try
            Dim sql As String = "select scrolling_text, speed_level "
            sql += " from MS_TEXT_SCROLLING_SCH_DATA"
            sql += " where ip_address = '" & LedTvIPAddress & "'"
            sql += " and getdate() between start_time and end_time"

            Dim dt As DataTable = DIPRFIDSqlDB.ExecuteTable(sql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("scrolling_text") & "|" & dt.Rows(0)("speed_level")
            Else
                Dim lnq As New MsLedTvLinqDB
                lnq.ChkDataByIP_ADDRESS(LedTvIPAddress, Nothing)
                If lnq.ID > 0 Then
                    ret = lnq.DEFAULT_TEXT_SCROLLING & "|" & lnq.TEXT_SCROLLING_SPEED
                End If
                lnq = Nothing
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.GetCurrentTextScrolling", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

#End Region


#Region "Operation Signage Content"
    Public Shared Function GetFileGrowthRatio(vYear As Integer) As DataTable
        'แสดงอัตราการเติบโตของแฟ้ม
        Dim dt As New DataTable
        Try
            Dim tSql As String = ""
            For i As Int16 = 1 To 12
                Dim TmpDate As New Date(vYear, i, 1)
                Dim txtMonth As String = TmpDate.ToString("MMM", New Globalization.CultureInfo("en-US"))

                Dim sql As String = "select '" & txtMonth & "' mm ,count(id) qty " & vbNewLine
                sql += " from REQUISITION" & vbNewLine
                sql += " where formtype = 1 and convert(varchar(6),isnull(FRM_SUBMIT_DATE,isnull(SYS_SUBMIT_DATE,isnull(RECEIVE_DATE,isnull(APP_SUBMIT_DATE,PUBLICDATE)))),112)='" & vYear & i.ToString.PadLeft(2, "0") & "'" & vbNewLine

                If tSql = "" Then
                    tSql = sql
                Else
                    tSql += " union all" & vbNewLine & sql
                End If
            Next
            dt = PatentSqlDB.ExecuteTable(tSql)
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function
    Public Shared Function GetFileBorrowAndReserveQty(vDate As DateTime) As DataTable
        'แสดงจำนวนแฟ้มที่ถูกยืม และ จำนวนแฟ้มที่ค้างอยู่
        Dim ret As New DataTable
        Try
            Dim tmpDate As String = vDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

            'Dim Sql As String = "select 'BORROW' file_data, count(id) qty " & vbNewLine
            'Sql += " from TMP_FILEBORROWITEM " & vbNewLine
            'Sql += " where convert(varchar(8),borrowdate,112)='" & tmpDate & "'" & vbNewLine
            'Sql += " union all " & vbNewLine
            'Sql += " select 'RESERVE' file_date, count(id) " & vbNewLine
            'Sql += " from  v_reserve_list" & vbNewLine
            'Sql += " where convert(varchar(8),reserve_date,112)='" & tmpDate & "'" & vbNewLine
            'Sql += " and reserve_order=1"
            'Sql += " and id not in (select reserve_id from TB_FILEBORROWITEM)"
            'Sql += " union all " & vbNewLine
            'Sql += " select 'RESERVEALL' file_date, count(id) " & vbNewLine
            'Sql += " from  v_reserve_list" & vbNewLine
            'Sql += " where convert(varchar(8),reserve_date,112)='" & tmpDate & "'" & vbNewLine

            Dim Sql As String = " select 'BORROW' file_data, count(fb.id) qty " & vbNewLine
            Sql += " from TMP_FILEBORROWITEM  fb" & vbNewLine
            Sql += " inner join TB_OFFICER o on o.id=fb.borrower_id" & vbNewLine
            Sql += " inner join tb_department d on d.id=o.department_id" & vbNewLine
            Sql += " inner join ms_room rm on rm.id=d.ms_room_id" & vbNewLine
            Sql += " where convert(varchar(8),fb.borrowdate,112)='" & tmpDate & "'" & vbNewLine
            Sql += " and rm.ms_floor_id=5" & vbNewLine
            Sql += " union all" & vbNewLine
            Sql += " select 'RESERVE' file_date, count(r.id) " & vbNewLine
            Sql += " from  TB_RESERVE r" & vbNewLine
            Sql += " inner join TB_OFFICER o on o.id=r.member_id" & vbNewLine
            Sql += " inner join tb_department d on d.id=o.department_id" & vbNewLine
            Sql += " inner join ms_room rm on rm.id=d.ms_room_id" & vbNewLine
            Sql += " where convert(varchar(8),r.reserve_date,112)='" & tmpDate & "'" & vbNewLine
            Sql += " and r.reserve_order=1" & vbNewLine
            Sql += " and r.id not in (select reserve_id from TB_FILEBORROWITEM)" & vbNewLine
            Sql += " and rm.ms_floor_id=5" & vbNewLine
            Sql += " union all" & vbNewLine
            Sql += " select 'RESERVEALL' file_date, count(r.id) " & vbNewLine
            Sql += " from  TB_RESERVE r" & vbNewLine
            Sql += " inner join TB_OFFICER o on o.id=r.member_id" & vbNewLine
            Sql += " inner join tb_department d on d.id=o.department_id" & vbNewLine
            Sql += " inner join ms_room rm on rm.id=d.ms_room_id" & vbNewLine
            Sql += " where convert(varchar(8),r.reserve_date,112)='" & tmpDate & "'"
            Sql += " and rm.ms_floor_id=5"

            ret = DIPRFIDSqlDB.ExecuteTable(Sql)
        Catch ex As Exception
            ret = New DataTable
        End Try

        Return ret
    End Function

    Public Shared Function GetFileBorrowAndReserveQtyNow() As DataTable 'วันปัจจบัน
        'แสดงจำนวนแฟ้มที่ถูกยืม และ จำนวนแฟ้มที่ค้างอยู่
        Dim ret As New DataTable
        Try
            Dim vDate As Date = Date.Now
            Dim tmpDate As String = vDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

            Dim Sql As String = "select 'BORROW' file_data, count(id) qty " & vbNewLine
            Sql += " from TMP_FILEBORROWITEM " & vbNewLine
            Sql += " where convert(varchar(8),borrowdate,112)='" & tmpDate & "'" & vbNewLine
            Sql += " union all " & vbNewLine
            Sql += " select 'RESERVE' file_date, count(id) " & vbNewLine
            Sql += " from  v_reserve_list" & vbNewLine
            Sql += " where convert(varchar(8),reserve_date,112)='" & tmpDate & "'" & vbNewLine
            Sql += " and reserve_order=1"
            Sql += " and id not in (select reserve_id from TB_FILEBORROWITEM)"

            ret = DIPRFIDSqlDB.ExecuteTable(Sql)
        Catch ex As Exception
            ret = New DataTable
        End Try

        Return ret
    End Function

    Public Shared Function GetFileQtyByFloor() As DataTable
        'จำนวนแฟ้มในแต่ละชั้น
        Dim ret As New DataTable
        Try
            Dim Signage6FloorID As String = GlobalFunction.GetSysConfing("Signage6FloorID")

            Dim sql As String = "select fl.id, fcl.ms_room_id,fl.floor_name, pt.patent_type_name, count(fcl.id) qty "
            sql += " ,rq.patent_type_id, (case   when rq.patent_type_id =  1 then '#27a9e2' when rq.patent_type_id =  2 then '#28b779' when rq.patent_type_id =  3 then '#852b99' end) as colors"
            sql += " from TS_FILE_CURRENT_LOCATION fcl"
            sql += " inner join MS_ROOM r on r.id=fcl.ms_room_id"
            sql += " inner join MS_FLOOR fl on fl.id=r.ms_floor_id"
            sql += " inner join TS_REQUISITION_TAG rt on rt.tag_no=fcl.app_no"
            sql += " inner join TB_REQUISTION rq on rq.id=rt.tb_requisition_id"
            sql += " inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id"
            sql += " where fl.id in (" & Signage6FloorID & ") and rq.patent_type_id in (1,3) "
            sql += " group by fl.id, fcl.ms_room_id,fl.floor_name, pt.patent_type_name,rq.patent_type_id"

            sql += "  Union"

            sql += "  select '99' id,'0' ms_room_id,'ทรัพย์สรีไทย' floor_name,pt.patent_type_name, count( distinct fs.app_no) qty  "
            sql += "  ,rq.patent_type_id, (case   when rq.patent_type_id =  1 then '#27a9e2' when rq.patent_type_id =  2 then '#28b779' when rq.patent_type_id =  3 then '#852b99' end) as colors"
            sql += "  from TB_FILESTORE  fs"
            sql += "  inner join TB_REQUISTION rq on rq.app_no=fs.app_no"
            sql += "  inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id"
            sql += "  where fs.filelocation = 5"
            sql += "  and rq.patent_type_id in (1,3) "
            sql += "  group by  pt.patent_type_name,rq.patent_type_id"

            ret = DIPRFIDSqlDB.ExecuteTable(sql)

            'Dim dt As New DataTable
            'dt.Columns.Add("id")
            'dt.Columns.Add("qty")
            'dt.Columns.Add("colors")
            'Dim dr As DataRow
            'dr = dt.NewRow
            'dr("id") = 6
            'dr("qty") = 1910
            'dr("colors") = "#27a9e2"
            'dt.Rows.Add(dr)
            'dr = dt.NewRow
            'dr("id") = 6
            'dr("qty") = 512
            'dr("colors") = "#28b779"
            'dt.Rows.Add(dr)
            'dr = dt.NewRow
            'dr("id") = 6
            'dr("qty") = 777
            'dr("colors") = "#852b99"
            'dt.Rows.Add(dr)

            'ret = dt
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function


    Public Shared Function GetFileQtyByRoomCurrent(MsRoomID As String) As DataTable
        'จำนวนแฟ้มในแต่ละชั้น
        Dim ret As New DataTable
        Try
            'Dim Signage6FloorID As String = GlobalFunction.GetSysConfing("Signage6FloorID")

            Dim sql As String = ""
            sql += " select  f.id, isnull(fc.ms_room_id,fl.ms_room_id) ms_room_id, f.floor_name,pt.patent_type_name,count(rq.app_no) qty " & vbNewLine
            sql += " ,rq.patent_type_id, (case   when rq.patent_type_id =  1 then '#27a9e2' when rq.patent_type_id =  2 then '#28b779' when rq.patent_type_id =  3 then '#852b99' end) as colors" & vbNewLine
            sql += " from [dbo].[TB_REQUISTION] rq" & vbNewLine
            sql += " left join TS_FILE_CURRENT_LOCATION fc on fc.app_no=rq.app_no " & vbNewLine
            sql += " left join MS_ROOM rm on fc.ms_room_id=rm.id" & vbNewLine
            sql += " left join [dbo].[TB_FILELOCATION] fl on rq.filelocation = fl.id " & vbNewLine
            sql += " left join MS_FLOOR f on isnull(rm.ms_floor_id, fl.ms_floor_id)= f.id " & vbNewLine
            sql += " inner join TB_PATENT_TYPE pt on rq.patent_type_id =pt.id" & vbNewLine
            sql += " where isnull(fc.ms_room_id,fl.ms_room_id) = '" & MsRoomID & "' and rq.patent_type_id in (1,3)" & vbNewLine
            sql += " group by  f.id,isnull(fc.ms_room_id,fl.ms_room_id), f.floor_name,pt.patent_type_name,rq.patent_type_id, " & vbNewLine
            sql += " (case   when rq.patent_type_id =  1 then '#27a9e2' when rq.patent_type_id =  2 then '#28b779' when rq.patent_type_id =  3 then '#852b99' end) " & vbNewLine

            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetFileQtyFloor3() As DataTable
        'จำนวนแฟ้มในแต่ละชั้น 3
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql += " select  2 id, 3 ms_room_id,'ชั้น 3' floor_name,pt.patent_type_name,count(rq.app_no) qty "
            sql += " ,rq.patent_type_id, (case   when rq.patent_type_id =  1 then '#27a9e2' when rq.patent_type_id =  2 then '#28b779' when rq.patent_type_id =  3 then '#852b99' end) as colors"
            sql += " from [dbo].[TB_REQUISTION] rq"
            sql += " left join TS_FILE_CURRENT_LOCATION fc on fc.app_no=rq.app_no "
            sql += " left join MS_ROOM rm on fc.ms_room_id=rm.id"
            sql += " left join [TB_FILELOCATION] fl on rq.filelocation = fl.id "
            'sql += " left join MS_FLOOR f on isnull(rm.ms_floor_id, fl.ms_floor_id)= f.id "
            sql += " inner join TB_PATENT_TYPE pt on rq.patent_type_id =pt.id"
            sql += " where isnull(rm.ms_floor_id,fl.ms_floor_id)=2 "  'ชั้น 3
            sql += " and rq.patent_type_id in (1,3)"
            sql += " group by  pt.patent_type_name,rq.patent_type_id, "
            sql += " (case   when rq.patent_type_id =  1 then '#27a9e2' when rq.patent_type_id =  2 then '#28b779' when rq.patent_type_id =  3 then '#852b99' end) "

            ret = DIPRFIDSqlDB.ExecuteTable(sql)
            'If ret.Rows.Count > 0 Then

            '    Dim TmpDt As DataTable = GetFileQtyByRoomCurrent(3)
            '    For i As Integer = 0 To ret.Rows.Count - 1
            '        Dim dr As DataRow = ret.Rows(i)
            '        TmpDt.DefaultView.RowFilter = "id='" & dr("id") & "' and ms_room_id='" & dr("ms_room_id") & "' and patent_type_id='" & dr("patent_type_id") & "'"
            '        If TmpDt.DefaultView.Count > 0 Then
            '            ret.Rows(i)("qty") += Convert.ToInt64(TmpDt.DefaultView(0)("qty"))
            '        End If
            '    Next
            'End If
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetFileQtyAtDestroy() As DataTable
        'จำนวนแฟ้มที่เก็บอยู่ที่ทรัพย์ศรีไทย
        Dim ret As New DataTable
        Try
            Dim Sql As String = "  select '99' id,'ทรัพย์ศรีไทย' floor_name, count( distinct fs.app_no) qty  " & vbNewLine
            Sql += "  ,(case when rq.pat_type =  1 then 'สิทธิบัตรการประดิษฐ์' when rq.pat_type =  2 then 'สิทธิบัตรการออกแบบผลิตภัณฑ์' when rq.pat_type =  3 then 'อนุสิทธิบัตร' end) as patent_type_name " & vbNewLine
            Sql += "  ,rq.pat_type patent_type_id, (case   when rq.pat_type =  1 then '#27a9e2' when rq.pat_type =  2 then '#28b779' when rq.pat_type =  3 then '#852b99' end) as colors" & vbNewLine
            Sql += "  from filestore  fs" & vbNewLine
            Sql += "  inner join requisition rq on rq.app_no=fs.app_no" & vbNewLine
            Sql += "  where fs.filelocation = 5" & vbNewLine
            Sql += "  and rq.formtype=1"
            Sql += "  and rq.pat_type in (1,3) " & vbNewLine
            Sql += "  group by  rq.pat_type" & vbNewLine
            ret = PatentSqlDB.ExecuteTable(Sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function


    Public Shared Function GetFileQtyByFloorCurrent() As DataTable
        'จำนวนแฟ้มในแต่ละชั้น
        Dim ret As New DataTable
        Try
            Dim Signage6FloorID As String = GlobalFunction.GetSysConfing("Signage6FloorID")

            Dim sql As String = ""
            sql += " select  f.id, isnull(fc.ms_room_id,fl.ms_room_id) ms_room_id, f.floor_name,pt.patent_type_name,count(rq.app_no) qty " & vbNewLine
            sql += " ,rq.patent_type_id, (case   when rq.patent_type_id =  1 then '#27a9e2' when rq.patent_type_id =  2 then '#28b779' when rq.patent_type_id =  3 then '#852b99' end) as colors" & vbNewLine
            sql += " from [dbo].[TB_REQUISTION] rq" & vbNewLine
            sql += " left join TS_FILE_CURRENT_LOCATION fc on fc.app_no=rq.app_no " & vbNewLine
            sql += " left join MS_ROOM rm on fc.ms_room_id=rm.id" & vbNewLine
            sql += " left join [dbo].[TB_FILELOCATION] fl on rq.filelocation = fl.id " & vbNewLine
            sql += " left join MS_FLOOR f on isnull(rm.ms_floor_id, fl.ms_floor_id)= f.id " & vbNewLine
            sql += " inner join TB_PATENT_TYPE pt on rq.patent_type_id =pt.id" & vbNewLine
            sql += " where isnull(rm.ms_floor_id,fl.ms_room_id)  in (" & Signage6FloorID & ") and rq.patent_type_id in (1,3)" & vbNewLine
            sql += " group by  f.id,isnull(fc.ms_room_id,fl.ms_room_id), f.floor_name,pt.patent_type_name,rq.patent_type_id, " & vbNewLine
            sql += " (case   when rq.patent_type_id =  1 then '#27a9e2' when rq.patent_type_id =  2 then '#28b779' when rq.patent_type_id =  3 then '#852b99' end) " & vbNewLine


            sql += "  Union" & vbNewLine

            sql += "  select '99' id,'ทรัพย์สรีไทย' floor_name,pt.patent_type_name, count( distinct fs.app_no) qty  " & vbNewLine
            sql += "  ,rq.patent_type_id, (case   when rq.patent_type_id =  1 then '#27a9e2' when rq.patent_type_id =  2 then '#28b779' when rq.patent_type_id =  3 then '#852b99' end) as colors" & vbNewLine
            sql += "  from TB_FILESTORE  fs" & vbNewLine
            sql += "  inner join TB_REQUISTION rq on rq.app_no=fs.app_no" & vbNewLine
            sql += "  inner join TB_PATENT_TYPE pt on pt.id=rq.patent_type_id" & vbNewLine
            sql += "  where fs.filelocation = 5" & vbNewLine
            sql += "  and rq.patent_type_id in (1,3) " & vbNewLine
            sql += "  group by  pt.patent_type_name,rq.patent_type_id" & vbNewLine

            ret = DIPRFIDSqlDB.ExecuteTable(sql)

            'Dim dt As New DataTable
            'dt.Columns.Add("id")
            'dt.Columns.Add("qty")
            'dt.Columns.Add("colors")
            'Dim dr As DataRow
            'dr = dt.NewRow
            'dr("id") = 6
            'dr("qty") = 1910
            'dr("colors") = "#27a9e2"
            'dt.Rows.Add(dr)
            'dr = dt.NewRow
            'dr("id") = 6
            'dr("qty") = 512
            'dr("colors") = "#28b779"
            'dt.Rows.Add(dr)
            'dr = dt.NewRow
            'dr("id") = 6
            'dr("qty") = 777
            'dr("colors") = "#852b99"
            'dt.Rows.Add(dr)

            'ret = dt
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetCompareBorrowReturn() As DataTable
        'เปรียบเทียบอัตรการยืม / คืน
        Dim ret As New DataTable
        Try
            Dim sql As String = "select convert(varchar(10),getdate(),103) borrowerdate,'TODAY' day_type," & vbNewLine
            sql += "	(select count(fi.id)" & vbNewLine
            sql += "	from TB_FILEBORROW fb" & vbNewLine
            sql += "	inner join TB_FILEBORROWITEM fi on fb.id=fi.fileborrow_id" & vbNewLine
            sql += "	inner join TB_REQUISTION rq on fi.requisition_id = rq.id" & vbNewLine
            sql += "	where convert(varchar(8),fb.borrowerdate,112)=convert(varchar(8),getdate(),112) and patent_type_id in(1,3)) borrow_qty," & vbNewLine
            sql += "	(select count(fi.id)" & vbNewLine
            sql += "	from TB_FILEBORROW fb" & vbNewLine
            sql += "	inner join TB_FILEBORROWITEM fi on fb.id=fi.fileborrow_id" & vbNewLine
            sql += "	inner join TB_REQUISTION rq on fi.requisition_id = rq.id" & vbNewLine
            sql += "	where convert(varchar(8),fi.returndate,112)=convert(varchar(8),getdate(),112) and patent_type_id in(1,3)) return_qty" & vbNewLine
            sql += "    union" & vbNewLine
            sql += " select convert(varchar(10),getdate()-1,103) borrowdate, 'YESTERDAY' day_type," & vbNewLine
            sql += "	(select count(fi.id)" & vbNewLine
            sql += "	from TB_FILEBORROW fb" & vbNewLine
            sql += "	inner join TB_FILEBORROWITEM fi on fb.id=fi.fileborrow_id" & vbNewLine
            sql += "	inner join TB_REQUISTION rq on fi.requisition_id = rq.id" & vbNewLine
            sql += "	where convert(varchar(8),fb.borrowerdate,112)=convert(varchar(8),getdate()-1,112) and patent_type_id in(1,3)) borrow_qty," & vbNewLine
            sql += "	(select count(fi.id)" & vbNewLine
            sql += "	from TB_FILEBORROW fb" & vbNewLine
            sql += "	inner join TB_FILEBORROWITEM fi on fb.id=fi.fileborrow_id" & vbNewLine
            sql += "	inner join TB_REQUISTION rq on fi.requisition_id = rq.id" & vbNewLine
            sql += "	where convert(varchar(8),fi.returndate,112)=convert(varchar(8),getdate()-1,112) and patent_type_id in(1,3)) return_qty" & vbNewLine
            sql += " order by borrowerdate desc" & vbNewLine
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function


    Public Shared Function GetFileHoldingByDepartment() As DataTable
        'จำนวนแฟ้มที่ถือครองในแต่ละกลุ่มงาน
        Dim ret As New DataTable
        Try
            'Dim sql As String = "select dp.department_name, count(fi.id) qty" & vbNewLine
            'sql += " from TMP_FILEBORROWITEM fi" & vbNewLine
            'sql += " inner join TB_OFFICER o on o.id=fi.borrower_id" & vbNewLine
            'sql += " inner join TB_DEPARTMENT dp on dp.id=o.department_id" & vbNewLine
            'sql += " group by dp.department_name" & vbNewLine
            Dim sql As String = " select dp.department_name, count(fi.id) qty "
            sql += " from TMP_FILEBORROWITEM fi "
            sql += " inner join TB_OFFICER o on o.id=fi.borrower_id "
            sql += " inner join TB_DEPARTMENT dp on dp.id=o.department_id "
            sql += " inner join TB_REQUISTION rq on rq.app_no=fi.app_no "
            sql += " where dp.ms_room_id in (6,7,8,9) "
            sql += " and rq.patent_type_id in (1,3) "
            sql += " group by dp.department_name "
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    'Public Shared Function GetSignageFloor6KPI() As DataTable
    '    'ค่า KPI ของการยืมและการคืน
    '    Dim ret As New DataTable
    '    Try
    '        Dim sql As String = "select 'BORROW_KPI' kpi_type, 50 kpi" & vbNewLine
    '        sql += " union " & vbNewLine
    '        sql += " select 'RETURN_KPI' kpi_type, 45 kpi " & vbNewLine

    '        ret = DIPRFIDSqlDB.ExecuteTable(sql)
    '    Catch ex As Exception
    '        ret = New DataTable
    '    End Try
    '    Return ret
    'End Function

    Private Shared Function UpdateFileChangeLocation(ret As DataTable, WhLocationTo As String, QtyFeldName As String) As DataTable
        Try
            Dim cfSql As String = "select cl.*, f.location_name"
            cfSql += " from cf_change_location cl"
            cfSql += " inner join TB_FILELOCATION f on f.id=cl.location_id_to"
            cfSql += " where " & WhLocationTo
            cfSql += " order by cl.location_id_from, cl.status_name"

            Dim cfLnq As New CfChangeLocationLinqDB
            Dim cfDt As DataTable = cfLnq.GetListBySql(cfSql, Nothing)

            If cfDt.Rows.Count > 0 Then
                For Each cfDr As DataRow In cfDt.Rows
                    Dim sql As String = "select pt.id patent_type_id, pt.patent_type_name, count(r.id) qty, '" & cfDr("location_name") & "' location_name_to"
                    sql += " from TB_REQUISTION r"
                    sql += " inner join TB_PATENT_TYPE pt on r.patent_type_id=pt.id"
                    sql += " left join TB_STATUS st on st.id=r.app_status"
                    sql += " where r.filelocation='" & cfDr("location_id_from") & "'"

                    If cfDr("status_name").ToString.ToUpper <> "ALL" Then
                        sql += " and isnull(st.status_name,'')='" & cfDr("status_name") & "'"
                    End If
                    sql += " group by pt.id, pt.patent_type_name"

                    Dim dt As DataTable = DIPRFIDSqlDB.ExecuteTable(sql)
                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To ret.Rows.Count - 1
                            For Each dr As DataRow In dt.Rows
                                If dr("patent_type_id") = ret.Rows(i)("patent_type_id") Then
                                    ret.Rows(i)(QtyFeldName) += dr("qty")
                                End If
                            Next
                        Next
                    End If
                Next
            End If
            cfDt.Dispose()
            cfLnq = Nothing
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetFileChangeDue() As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = " select pt.id patent_type_id, pt.patent_type_name, "
            '--จำนวนแฟ้มจากชั้น 6 ที่ต้องย้ายลงไปชั้น 1"
            sql += " (select count(distinct rq.id)"
            sql += " from TB_REQUISTION rq"
            sql += " inner join TB_FILESTORE fs on rq.app_no=fs.app_no"
            sql += " inner join CF_CHANGE_LOCATION cl on fs.filelocation=cl.location_id_from   " '--แฟ้มที่ครบอายุแล้วจากชั้น 6"
            sql += " inner join TB_FILELOCATION fl on fl.id=cl.location_id_to"
            sql += " inner join TB_STATUS st on st.id=rq.app_status"
            sql += "  where rq.patent_type_id = pt.id"
            sql += " and rq.RECEIVE_DATE<DATEADD(yy,0-cl.year_qty,getdate())"
            sql += " and st.status_name=cl.status_name"
            sql += " and fl.ms_floor_id=1   " '--จะต้องย้ายลงไปชั้น 1
            sql += " ) location_1_qty, "
            ' --จำนวนแฟ้ม จากทุกที่ ที่ต้องย้ายไปทรัพย์ศรีไทย"
            sql += " (select count(rq.id)"
            sql += " from TB_REQUISTION rq"
            sql += " inner join TB_FILESTORE fs on rq.app_no=fs.app_no"
            sql += " inner join CF_CHANGE_LOCATION cl on fs.filelocation=cl.location_id_from"
            sql += " inner join TB_FILELOCATION fl on fl.id=cl.location_id_to"
            sql += " inner join TB_STATUS st on st.id=rq.app_status"
            sql += " where rq.patent_type_id = pt.id"
            sql += " and rq.RECEIVE_DATE<DATEADD(yy,0-cl.year_qty,getdate())"
            sql += " and st.status_name=cl.status_name"
            sql += " and fl.id=5 " '  --จะต้องย้ายไปทรัพย์ศรีไทย"
            sql += "  )  location_sup_qty "
            sql += " from tb_patent_type pt"
            sql += " where pt.id in (1,3)"
            sql += " order by pt.id"
            ret = DIPRFIDSqlDB.ExecuteTable(Sql)

        Catch ex As Exception

        End Try
        Return ret
    End Function

    Public Shared Function GetLocationDeviceData() As DataTable
        'แสดงข้อมูล อุหภูมิ/ความชื่้น
        Dim ret As New DataTable
        Try
            Dim vDate As Date = Date.Now
            Dim tmpDate As String = vDate.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

            Dim Sql As String
            Sql = "  select "
            Sql += " r.id"
            Sql += " ,r.room_name "
            Sql += " ,round(sum(hdt.temp_value) / count(r.id),1) as temp_value"
            Sql += " ,round(sum(hdt.humidity_value) / count(r.id),1) as humidity_value"
            Sql += " from MS_HUMIDITY_TEMP_DEVICE htd"
            Sql += " inner join MS_ROOM r on htd.ms_room_id = r.id"
            Sql += " inner join TS_HUMIDITY_TEMP_DATA hdt on  hdt.ms_humidity_temp_id = htd.id"
            'Sql += " where convert(varchar(8),record_datetime,112)='" & tmpDate & "'"
            Sql += " group by  r.id"
            Sql += " ,r.room_name "


            ret = DIPRFIDSqlDB.ExecuteTable(Sql)
        Catch ex As Exception
            ret = New DataTable
        End Try

        Return ret
    End Function

    Public Shared Function GetParticleValue() As DataTable
        'แสดงข้อมูล ฝุ่นละออง
        Dim ret As New DataTable
        Try

            Dim Sql As String = ""
            Sql += " select r.id,r.room_name,round((avg(channel_0_3+channel_0_5+channel_1_0+channel_2_5+channel_5_0+channel_10_0)*100)/1000000.0,1) particle_value"
            Sql += " from TS_PARTICLE_COUNTER_DATA pch"
            Sql += " inner join MS_PARTICLE_COUNTER_DEVICE mptd on  pch.ms_particle_counter_device_id = mptd.id"
            Sql += " inner join MS_ROOM r on mptd.ms_room_id = r.id"
            'Sql += " where Convert(varchar(8), import_time, 112) = Convert(varchar(8), getdate(), 112)"
            Sql += " group by  r.id ,r.room_name "

            ret = DIPRFIDSqlDB.ExecuteTable(Sql)
        Catch ex As Exception
            ret = New DataTable
        End Try

        Return ret
    End Function

#End Region

#Region "Floor 10"


    Public Shared Function GetComparePatentypeAmountFloor10() As DataTable
        'จำนวนของแฟ้มที่อยู่บนชั้นที่ 10 ของวันนี้เทียบเมื่อวานนี้ สำหรับแต่ละประเภทของแฟ้มสำหรับชั้น 10
        Dim ret As New DataTable
        Try
            Dim sql As String = ""

            sql &= " select 'today' as typeday , pt.patent_type_name as patent_type_name,isnull(table1.amountapp,0) amountapp from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id, pt.patent_type_name,count(fcl.app_no) as amountapp  from TS_FILE_CURRENT_LOCATION fcl"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on fcl.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= " where fcl.ms_room_id = 8"
            sql &= " and convert(varchar(8),fcl.move_date,112)=convert(varchar(8),getdate(),112)  "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= " where pt.id = 1"

            sql &= " union"
            sql &= " select 'today' as typeday , pt.patent_type_name as patent_type_name,isnull(table1.amountapp,0) amountapp from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id, pt.patent_type_name,count(fcl.app_no) as amountapp  from TS_FILE_CURRENT_LOCATION fcl"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on fcl.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= " where fcl.ms_room_id = 8"
            sql &= " and convert(varchar(8),fcl.move_date,112)=convert(varchar(8),getdate(),112)  "
            sql &= " and   isnull(pct,'N')='N' "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= " where pt.id = 3"

            sql &= " union"
            sql &= " select 'today' as typeday ,'คำขอ PCT' as patent_type_name,sum(isnull(table1.amountapp,0)) amountapp from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id, pt.patent_type_name,count(fcl.app_no) as amountapp  from TS_FILE_CURRENT_LOCATION fcl"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on fcl.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= " where fcl.ms_room_id = 8 and  pct='Y'"
            sql &= " and convert(varchar(8),fcl.move_date,112)=convert(varchar(8),getdate(),112)  "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            'sql &= " where pt.id = 3"

            '---------------------------------------------------------------
            sql &= " union"
            sql &= " select 'yesterday',pt.patent_type_name as patent_type_name,isnull(table1.amountapp,0) amountapp from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id, pt.patent_type_name,count(fcl.app_no) as amountapp  from TS_FILE_CURRENT_LOCATION fcl"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on fcl.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= " where fcl.ms_room_id = 8"
            sql &= " and convert(varchar(8),fcl.move_date,112)=convert(varchar(8),getdate()-1,112) "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= "  where pt.id = 1"

            sql &= " union"
            sql &= " select 'yesterday',pt.patent_type_name as patent_type_name,isnull(table1.amountapp,0) amountapp from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id, pt.patent_type_name,count(fcl.app_no) as amountapp  from TS_FILE_CURRENT_LOCATION fcl"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on fcl.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= "  where fcl.ms_room_id = 8"
            sql &= " and convert(varchar(8),fcl.move_date,112)=convert(varchar(8),getdate()-1,112) "
            sql &= " and isnull(pct,'N')='N' "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= " where pt.id = 3"

            sql &= " union"
            sql &= " select 'yesterday','คำขอ PCT' as patent_type_name,sum(isnull(table1.amountapp,0)) amountapp from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id, pt.patent_type_name,count(fcl.app_no) as amountapp  from TS_FILE_CURRENT_LOCATION fcl"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on fcl.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= " where fcl.ms_room_id = 8"
            sql &= " and convert(varchar(8),fcl.move_date,112)=convert(varchar(8),getdate()-1,112) and  pct='Y' "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            'sql &= " where pt.id = 3"

            'sql = " select 'today' as typeday ,(case   when pt.id =  2 then 'คำขอ PCT' else pt.patent_type_name end) as patent_type_name,isnull(table1.amountapp,0) amountapp from TB_PATENT_TYPE pt"
            'sql &= " left join ("
            'sql &= " select pt.id, pt.patent_type_name,count(fcl.app_no) as amountapp  from TS_FILE_CURRENT_LOCATION fcl"
            'sql &= " inner join TB_REQUISTION rq"
            'sql &= " on fcl.app_no =  rq.app_no"
            'sql &= " inner join TB_PATENT_TYPE pt"
            'sql &= " on rq.patent_type_id = pt.id"
            'sql &= " where fcl.ms_room_id = 8"
            'sql &= " and convert(varchar(8),fcl.move_date,112)=convert(varchar(8),getdate(),112) and  pct='Y' and patent_type_id=3"
            'sql &= " group by pt.id,pt.patent_type_name"
            'sql &= " ) as table1"
            'sql &= " on pt.id = table1.id"
            'sql &= " union"
            'sql &= " select 'yesterday',(case   when pt.id =  2 then 'คำขอ PCT' else pt.patent_type_name end) as patent_type_name,isnull(table1.amountapp,0) amountapp from TB_PATENT_TYPE pt"
            'sql &= " left join ("
            'sql &= " select pt.id, pt.patent_type_name,count(fcl.app_no) as amountapp  from TS_FILE_CURRENT_LOCATION fcl"
            'sql &= " inner join TB_REQUISTION rq"
            'sql &= " on fcl.app_no =  rq.app_no"
            'sql &= " inner join TB_PATENT_TYPE pt"
            'sql &= " on rq.patent_type_id = pt.id"
            'sql &= " where fcl.ms_room_id = 8"
            'sql &= " and convert(varchar(8),fcl.move_date,112)=convert(varchar(8),getdate()-1,112) and  pct='Y' and patent_type_id=3"
            'sql &= " group by pt.id,pt.patent_type_name"
            'sql &= " ) as table1"
            'sql &= " on pt.id = table1.id"
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetPatentypeAmountFloor10() As DataTable
        'จำนวนร้อยละของแฟ้มที่ถูกเบิกมานานกว่า 1 เดือน ตามแต่ละประเภท และ จำนวนร้อยละของแฟ้มที่ถูกเบิกมานานกว่า 6 เดือน ตามแต่ละประเภท
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql &= "  select '6' as type,  pt.patent_type_name"
            sql &= " ,isnull(table1.amountapp,0) amountapp,pt.id as patent_type_id, '#3399FF'  colors"
            sql &= "  from TB_PATENT_TYPE pt"
            sql &= " inner join ("
            sql &= " select pt.id,pt.patent_type_name,count(tfm.app_no) as  amountapp "
            sql &= " from TMP_FILEBORROWITEM tfm"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on tfm.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= " where DateDiff(Month, tfm.borrowdate, getdate()) <= 6"
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= "  where pt.id = 1"
            sql &= "  union all"
            sql &= " select '6' as type, pt.patent_type_name"
            sql &= " ,isnull(table1.amountapp,0) amountapp,pt.id as patent_type_id, '#660000'  as colors"
            sql &= "  from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id,pt.patent_type_name,count(tfm.app_no) as  amountapp "
            sql &= " from TMP_FILEBORROWITEM tfm"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on tfm.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= "  where DateDiff(Month, tfm.borrowdate, getdate()) <= 6"
            sql &= " and  isnull(pct,'N')='N' "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= "  where pt.id = 3"
            sql &= " union all"

            sql &= " select '6' as type,  'คำขอ PCT' as patent_type_name "
            sql &= " ,isnull(table1.amountapp,0) amountapp,pt.id as patent_type_id,'#9900FF' as colors"
            sql &= "  from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id,pt.patent_type_name,count(tfm.app_no) as  amountapp "
            sql &= " from TMP_FILEBORROWITEM tfm"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on tfm.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= " where DateDiff(Month, tfm.borrowdate, getdate()) <= 6"
            sql &= " and  pct='Y' "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= "  where pt.id = 3"
            '------------------------------------------------------------------------------------------------------------------
            sql &= " union all"
            sql &= " select 'more6' as type, pt.patent_type_name "
            sql &= " ,isnull(table1.amountapp,0) amountapp,pt.id as patent_type_id, '#3399FF' colors"
            sql &= " from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id,pt.patent_type_name,count(tfm.app_no) as  amountapp "
            sql &= " from TMP_FILEBORROWITEM tfm"
            sql &= " inner join TB_REQUISTION rq on tfm.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt on rq.patent_type_id = pt.id"
            sql &= " where DateDiff(Month, tfm.borrowdate, getdate()) > 6"
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= "  where pt.id = 1"
            sql &= "  union all"
            sql &= " select 'more6' as type,pt.patent_type_name "
            sql &= " ,isnull(table1.amountapp,0) amountapp,pt.id as patent_type_id,'#660000' as colors"
            sql &= " from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id,pt.patent_type_name,count(tfm.app_no) as  amountapp "
            sql &= " from TMP_FILEBORROWITEM tfm"
            sql &= " inner join TB_REQUISTION rq on tfm.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt on rq.patent_type_id = pt.id"
            sql &= "    where DateDiff(Month, tfm.borrowdate, getdate()) > 6"
            sql &= " and   isnull(pct,'N')='N' "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= " where pt.id = 3"

            sql &= " union all"
            sql &= " select 'more6' as type,  'คำขอ PCT' "
            sql &= " ,isnull(table1.amountapp,0) amountapp,pt.id as patent_type_id,  '#9900FF'  as colors"
            sql &= " from TB_PATENT_TYPE pt"
            sql &= " left join ("
            sql &= " select pt.id,pt.patent_type_name,count(tfm.app_no) as  amountapp "
            sql &= " from TMP_FILEBORROWITEM tfm"
            sql &= " inner join TB_REQUISTION rq"
            sql &= " on tfm.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt"
            sql &= " on rq.patent_type_id = pt.id"
            sql &= " where DateDiff(Month, tfm.borrowdate, getdate()) > 6"
            sql &= " and  pct='Y' "
            sql &= " group by pt.id,pt.patent_type_name"
            sql &= " ) as table1"
            sql &= " on pt.id = table1.id"
            sql &= "  where pt.id = 3"

            'sql = " select '6' as type, (case   when pt.id =  2 then 'คำขอ PCT' else pt.patent_type_name end) as patent_type_name"
            'sql &= " ,isnull(table1.amountapp,0) amountapp,pt.id as patent_type_id, "
            'sql &= " (case   when pt.id =  1 then '#3399FF' when pt.id =  2 then '#9900FF' when pt.id =  3 then '#660000' end) as colors"
            'sql &= " from TB_PATENT_TYPE pt"
            'sql &= " left join ("
            'sql &= " select pt.id,pt.patent_type_name,count(tfm.app_no) as  amountapp "
            'sql &= " from TMP_FILEBORROWITEM tfm"
            'sql &= " inner join TB_REQUISTION rq"
            'sql &= " on tfm.app_no =  rq.app_no"
            'sql &= " inner join TB_PATENT_TYPE pt"
            'sql &= " on rq.patent_type_id = pt.id"
            'sql &= " where DateDiff(Month, tfm.borrowdate, getdate()) <= 6"
            'sql &= " and  pct='Y' and patent_type_id=3"
            'sql &= " group by pt.id,pt.patent_type_name"
            'sql &= " ) as table1"
            'sql &= " on pt.id = table1.id"
            'sql &= " union"
            'sql &= " select 'more6' as type, (case   when pt.id =  2 then 'คำขอ PCT' else pt.patent_type_name end) as patent_type_name"
            'sql &= ",isnull(table1.amountapp,0) amountapp,pt.id as patent_type_id, "
            'sql &= " (case   when pt.id =  1 then '#3399FF' when pt.id =  2 then '#9900FF' when pt.id =  3 then '#660000' end) as colors"
            'sql &= " from TB_PATENT_TYPE pt"
            'sql &= " left join ("
            'sql &= " select pt.id,pt.patent_type_name,count(tfm.app_no) as  amountapp "
            'sql &= " from TMP_FILEBORROWITEM tfm"
            'sql &= " inner join TB_REQUISTION rq"
            'sql &= " on tfm.app_no =  rq.app_no"
            'sql &= " inner join TB_PATENT_TYPE pt"
            'sql &= " on rq.patent_type_id = pt.id"
            'sql &= " where DateDiff(Month, tfm.borrowdate, getdate()) > 6"
            'sql &= " and  pct='Y' and patent_type_id=3"
            'sql &= " group by pt.id,pt.patent_type_name"
            'sql &= " ) as table1"
            'sql &= " on pt.id = table1.id"
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetPatentypeAmountTopTimeFloor10(patenttype_id As String) As DataTable
        'Top 5
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql = "  select top 10 pt.id,pt.patent_type_name, r.app_no,"
            sql &= " re.member_name, DATEDIFF(day,re.reserve_date,getdate()) amountday"
            sql &= " from TB_RESERVE re"
            sql &= " inner join TB_REQUISTION r on r.id=re.requidition_id"
            sql &= " inner join TB_PATENT_TYPE pt on pt.id=r.patent_type_id"
            sql &= " where pt.id = '" & patenttype_id & "' and r.id not in (select reserve_id from TB_FILEBORROWITEM) and re.borrowstatus='S'"
            sql &= " order by DATEDIFF(day,re.reserve_date,getdate()) desc"
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetPatentypeAmountTopReserveFloor10(patenttype_id As String) As DataTable
        'Top 5
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql &= " select top 10 pt.id,pt.patent_type_name,tfm.app_no,"
            sql &= " tfm.borrower_name, datediff(day,tfm.borrowdate,getdate()) amountday"
            sql &= " from TMP_FILEBORROWITEM tfm"
            sql &= " inner join TB_REQUISTION rq on tfm.app_no =  rq.app_no"
            sql &= " inner join TB_PATENT_TYPE pt on rq.patent_type_id = pt.id"
            sql &= " where pt.id = '" & patenttype_id & "' and tfm.fileborrowitem_id <> 0"
            sql &= " order by datediff(day,tfm.borrowdate,getdate())  desc"
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetCompareReserveBorrowYieldAmountFloor10() As DataTable
        'กราฟเส้นชั้น 10
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql = " select *"
            sql &= " ,(case when table4.amountapp_borrow > 0 then table3.amountapp_reserve/table4.amountapp_borrow * 100 "
            sql &= " else 0 end) as yield"
            sql &= " from ("
            sql &= " select table1.* from ("
            sql &= " select convert(varchar,getdate()-4,103) as days_reserve,(select   count(*) "
            sql &= " from [dbo].[TB_RESERVE]"
            sql &= " where Convert(varchar, reserve_date, 103) = Convert(varchar, getdate() - 4, 103) and borrowstatus ='S'"
            sql &= " ) as amountapp_reserve"
            sql &= " union"
            sql &= " select convert(varchar,getdate()-3,103) as days_reserve,(select   count(*) "
            sql &= " from [dbo].[TB_RESERVE]"
            sql &= " where Convert(varchar, reserve_date, 103) = Convert(varchar, getdate() - 3, 103) and borrowstatus ='S'"
            sql &= " ) as amountapp_reserve"
            sql &= " union"
            sql &= " select convert(varchar,getdate()-2,103) as days_reserve,(select   count(*) "
            sql &= " from [dbo].[TB_RESERVE]"
            sql &= " where Convert(varchar, reserve_date, 103) = Convert(varchar, getdate() - 2, 103) and borrowstatus ='S'"
            sql &= " ) as amountapp_reserve"
            sql &= " union"
            sql &= " select convert(varchar,getdate()-1,103) as days_reserve,(select   count(*) "
            sql &= " from [dbo].[TB_RESERVE]"
            sql &= " where Convert(varchar, reserve_date, 103) = Convert(varchar, getdate() - 1, 103) and borrowstatus ='S'"
            sql &= " ) as amountapp_reserve"
            sql &= " union"
            sql &= " select convert(varchar,getdate(),103) as days_reserve,(select   count(*) "
            sql &= " from [dbo].[TB_RESERVE]"
            sql &= " where Convert(varchar, reserve_date, 103) = Convert(varchar, getdate(), 103) and borrowstatus ='S'"
            sql &= " ) as amountapp_reserve"
            sql &= " ) as table1"
            sql &= " ) as table3"
            sql &= " inner join ("

            sql &= " select table2.* from ("

            sql &= " select convert(varchar,getdate()-4,103) as days_borrow"
            sql &= " ,isnull((select count(*)"
            sql &= " from TMP_FILEBORROWITEM"
            sql &= " where convert(varchar,borrowdate ,103) = convert(varchar,getdate()-4,103)),0) as amountapp_borrow"
            sql &= " union"
            sql &= " select convert(varchar,getdate()-3,103) as days_borrow"
            sql &= " ,isnull((select count(*)"
            sql &= " from TMP_FILEBORROWITEM"
            sql &= " where convert(varchar,borrowdate ,103) = convert(varchar,getdate()-3,103)),0) as amountapp_borrow"
            sql &= " union"
            sql &= " select convert(varchar,getdate()-2,103) as days_borrow"
            sql &= " ,isnull((select count(*)"
            sql &= " from TMP_FILEBORROWITEM"
            sql &= " where convert(varchar,borrowdate ,103) = convert(varchar,getdate()-2,103)),0) as amountapp_borrow"
            sql &= " union"
            sql &= " select convert(varchar,getdate()-1,103) as days_borrow"
            sql &= " ,isnull((select count(*)"
            sql &= " from TMP_FILEBORROWITEM"
            sql &= " where convert(varchar,borrowdate ,103) = convert(varchar,getdate()-1,103)),0) as amountapp_borrow"
            sql &= " union"
            sql &= " select convert(varchar,getdate(),103) as days_borrow"
            sql &= " ,isnull((select count(*)"
            sql &= " from TMP_FILEBORROWITEM"
            sql &= " where convert(varchar,borrowdate ,103) = convert(varchar,getdate(),103)),0) as amountapp_borrow"
            sql &= " ) as table2"
            sql &= " ) as table4"
            sql &= " on table3.days_reserve =table4.days_borrow"
            sql &= " order by  Convert(datetime,table3.days_reserve,103)  "
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetCompareReserveBorrowYieldAmountFloor10_bar(num As Integer) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            'sql = " select * from ("
            'sql &= " select table1.* from ("
            'sql &= " select convert(varchar,getdate()- " & num & ",103) as days_reserve,(select   count(*) "
            'sql &= " from [dbo].[TB_RESERVE]"
            'sql &= " where Convert(varchar, reserve_date, 103) = Convert(varchar, getdate() - " & num & ", 103) and borrowstatus ='S'"
            'sql &= " ) as amountapp_reserve"
            'sql &= " )table1 ) T1 inner join"
            'sql &= " (select table2.* from ("
            'sql &= " select convert(varchar,getdate()- " & num & ",103) as days_borrow"
            'sql &= " ,isnull((select count(*)"
            'sql &= " from TMP_FILEBORROWITEM"
            'sql &= " where convert(varchar,borrowdate ,103) = convert(varchar,getdate()- " & num & ",103)),0) as amountapp_borrow"
            'sql &= " )table2) T2 on T1.days_reserve = T2.days_borrow "

            sql = " select * from ("
            sql &= " select table1.* from ("
            sql &= " select convert(varchar,getdate()- " & num & ",103) as days_reserve,("
            sql &= " select   count(*) "
            sql &= " from [dbo].[TB_RESERVE] rs"
            sql &= " inner join tb_officer o on rs.member_id = o.id"
            sql &= " inner join TB_REQUISTION re on rs.requidition_id = re.id"
            sql &= " inner join tb_department d on o.department_id = d.id"
            sql &= " inner join ms_room r on d.ms_room_id = r.id"
            sql &= " where r.ms_floor_id = 5 And patent_type_id <> 2"
            sql &= " and Convert(varchar, reserve_date, 103) = Convert(varchar, getdate() - " & num & ", 103) and borrowstatus ='S'"
            sql &= " ) as amountapp_reserve"
            sql &= " )table1 ) T1 inner join"
            sql &= " (select table2.* from ("
            sql &= " select convert(varchar,getdate()- " & num & ",103) as days_borrow"
            sql &= " ,isnull(("
            sql &= " select count(*)"
            sql &= " from TMP_FILEBORROWITEM f"
            sql &= " inner join tb_officer o on f.borrower_id = o.id"
            sql &= " inner join TB_REQUISTION re on f.app_no = re.app_no"
            sql &= " inner join tb_department d on o.department_id = d.id"
            sql &= " inner join ms_room r on d.ms_room_id = r.id"
            sql &= " where r.ms_floor_id = 5 And patent_type_id <> 2"
            sql &= " and convert(varchar,borrowdate ,103) = convert(varchar,getdate()- " & num & ",103)"
            sql &= " ),0) as amountapp_borrow"
            sql &= " )table2) T2 on T1.days_reserve = T2.days_borrow "

            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret

    End Function
#End Region


#Region "Time Line"
    Public Shared Sub ImportDataFromDIPAEC(username As String)
        Dim dt As New DataTable
        Try
            Dim sql As String = "select id,app_no,checkout_time from TB_REGISTER_QUEUE where convert(varchar(10),checkout_time,103) = convert(varchar(10),getdate(),103)  and ms_requisition_type_id = 1"
            dt = QDIPAECDB.ExecuteTable(sql)

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim ret As Boolean = True
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim lnq As New TsFileOperationTimelineLinqDB
                Dim tmpdt As New DataTable
                Dim timeline_id As String = "0"
                Dim tb_register_queue_id As String = dt.Rows(i)("id").ToString
                tmpdt = lnq.GetListBySql("Select id from TS_FILE_OPERATION_TIMELINE where TB_REGISTER_QUEUE_ID='" & tb_register_queue_id & "'", trans.Trans)
                If tmpdt.Rows.Count > 0 Then
                    timeline_id = tmpdt.Rows(0)("id").ToString
                End If

                lnq.GetDataByPK(timeline_id, trans.Trans)
                With lnq
                    .APP_NO = dt.Rows(i)("app_no").ToString
                    .OPERATION_DATE = dt.Rows(i)("checkout_time")
                    .OPERATION_ACTION = "จัดเก็บ"
                    .TB_REGISTER_QUEUE_ID = tb_register_queue_id
                End With

                If lnq.ID = 0 Then
                    ret = lnq.InsertData(username, trans.Trans)
                Else
                    ret = lnq.UpdateByPK(username, trans.Trans)
                End If

                If ret = False Then
                    LogFile.LogENG.SaveErrLog("DigitalSignageENG.ImportDataFromDIPAEC", "Exception : " & lnq.ErrorMessage)
                    Exit For
                End If

            Next

            If ret Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("DigitalSignageENG.ImportDataFromDIPAEC", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
#End Region

#Region "Floor 6"
    Public Shared Function GetGrowFileMonthFloor6(patenttype_id As String) As DataTable

        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql = "   select * from ts_signage_file_growth_month where tb_patent_type_id=" & patenttype_id
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
    Public Shared Function GetGrowFileYearFloor6(patenttype_id As String) As DataTable

        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql = "   select * from ts_signage_file_growth_year where tb_patent_type_id=" & patenttype_id
            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
#End Region

#Region "Document Tracing"
    Public Shared Function CheckDocTracingTV(MsLedTVID As Long, TagNo As String) As String
        Dim ret As String = "False"
        Try
            Dim lnq As New TmpDocTrackingLedTvLinqDB
            Dim sql As String = "select id"
            sql += " from TMP_DOC_TRACKING_LED_TV "
            sql += " where ms_led_tv_id='" & MsLedTVID & "'"
            sql += " and tag_no='" & TagNo & "'"
            sql += " and getdate() between start_time and end_time "

            Dim dt As DataTable = GlobalFunction.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                ret = "True|" & TagNo
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = "False|" & ex.Message & ex.StackTrace
        End Try
        Return ret
    End Function
#End Region
End Class
