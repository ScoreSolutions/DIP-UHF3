Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.Data
Imports System.IO
Imports System.Globalization
Imports Engine

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService
#Region "Signage"
#Region "Sever"
    <WebMethod()> _
    Public Function LoadDipAllServer() As String
        Try
            'Dim strSql As New StringBuilder
            '
            'strSql.Append(" select ")
            'strSql.Append(" '1' imgdipdbserver ")
            'strSql.Append(" ,'• Online' lbldipdbserverconnect ")
            'strSql.Append(" ,'DIPDbServer' lbldipdbservername ")
            'strSql.Append(" ,'10.1.1.1' lbldipdbserverip ")
            'strSql.Append(" ,'Server Room' lbldipdbserverlocation ")
            'strSql.Append(" ,'Win 2008' lbldipdbserveros ")
            'strSql.Append(" ,'50%' lbldipdbserveravailability ")
            'strSql.Append(" ,'50%' lbldipdbservercpu ")
            'strSql.Append(" ,'50%' lbldipdbserverram ")
            'strSql.Append(" ,'50%' lbldipdbserverdisk ")
            'Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim strdata As String
            Dim dt As DataTable = FaultMngENG.GetSignageServerInfo
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function
#End Region

#Region "Speedway"
    <WebMethod()> _
    Public Function LoadDipSpeedway() As String
        Try
            'Dim strSql As New StringBuilder
            Dim strdata As String
            'strSql.Append(" select ")
            'strSql.Append(" '. Online' dipswconnect ")
            'strSql.Append(" ,'(Fl.10)' dipswflor ")
            'strSql.Append(" ,'1' imagedipsw ")
            'strSql.Append(" ,'Speedway1' dipswname ")
            'strSql.Append(" ,'10.1.1.21' dipswip ")
            'strSql.Append(" ,'CentOS' dipswos ")
            'strSql.Append(" ,'90%' dipswavailability ")
            'strSql.Append(" ,'90%' dipswcpu ")
            'strSql.Append(" ,'90%' dipswram ")
            'strSql.Append(" ,'90%' dipswdisk ")

            'Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable = FaultMngENG.GetSignageSpeedwayInfo
            'dt.DefaultView.Sort = "floor_name"
            'dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function
#End Region

#Region "TV"
    <WebMethod()> _
    Public Function LoadDipTV() As String
        Try
            'Dim strSql As New StringBuilder
            Dim strdata As String
            'strSql.Append(" select ")
            'strSql.Append(" '. Online' diptvconnect ")
            'strSql.Append(" ,'(Fl.10)'diptvfloor ")
            'strSql.Append(" ,'1' imgdiptv ")
            'strSql.Append(" ,'TV1' diptvname ")
            'strSql.Append(" ,'10.1.1.31' diptvip ")
            'strSql.Append(" ,'Android' diptvos ")
            'strSql.Append(" ,'20%' diptvavailability ")
            'strSql.Append(" ,'20%' diptvram ")
            'strSql.Append(" ,'20%' diptvcpu ")
            'strSql.Append(" ,'20%' diptvdisk ")

            ' Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim dt As DataTable = FaultMngENG.GetSignageTVInfo
            ' dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function
#End Region

#Region "Function"


    <WebMethod()> _
    Public Function GetTextScrolling(ip As String) As String
        Try
            Dim strText As String = DigitalSignageENG.GetCurrentTextScrolling(ip)
            'Dim strSql As New StringBuilder
            Dim strspeed As String = "15000"
            Dim strdata As String = ""
            'strSql.Append(" select text_scrolling_speed  from ms_led_tv where id=" & ip)
            'Dim trans As New TransactionDB(SelectDB.DIPRFID)
            'Dim dt As DataTable
            'dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString)
            'If dt.Rows.Count > 0 Then
            '    Select Case dt.Rows(0)("text_scrolling_speed")
            '        Case 1
            '            strspeed = "25000"
            '        Case 2
            '            strspeed = "15000"
            '        Case 3
            '            strspeed = "5000"
            '    End Select
            '    strdata = strText & "," & strspeed
            'End If

            Dim arr As String() = strText.Split("|")
            If arr.Length = 2 Then
                Select Case arr(1)
                    Case 1
                        strspeed = "25000"
                    Case 2
                        strspeed = "15000"
                    Case 3
                        strspeed = "5000"
                End Select
                strdata = arr(0) & "|" & strspeed
            End If

            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function GetTempleteSchedule(ip As String) As String
        Dim strText As String = DigitalSignageENG.GetCurrentSignageURL(ip)
        Return strText
    End Function
    '<WebMethod()> _
    'Public Function GetTempleteSchedule(tvid As String) As String
    '    Try
    '        Dim strcondition As String = ""
    '        Dim strSql As New StringBuilder
    '        Dim strSqlDefault As New StringBuilder
    '        Dim strSqlSchedule As New StringBuilder
    '        Dim strUrlId As String = ""
    '        Dim strUrl As String = ""
    '        strSql.Append(" select ")
    '        strSql.Append(" sts.id")
    '        strSql.Append(" ,sts.start_time")
    '        strSql.Append(" ,sts.end_time")
    '        strSql.Append(" ,schedule_type")
    '        strSql.Append(" ,sst.time_from")
    '        strSql.Append(" ,sst.time_to")
    '        strSql.Append(" ,sct.template_name")
    '        strSql.Append(" ,sts.ms_signage_content_template_id")
    '        strSql.Append(" from MS_SIGNAGE_TEMPLATE_SCHEDULE sts")
    '        strSql.Append(" inner join MS_SIGNAGE_SCHEDULE_TIME sst")
    '        strSql.Append(" on sst.ms_signage_template_schedule_id =sts.id")
    '        strSql.Append(" inner join MS_SIGNAGE_CONTENT_TEMPLATE sct")
    '        strSql.Append(" on sct.id = sts.ms_signage_content_template_id")
    '        strSql.Append(" where 1 = 1")
    '        strSql.Append(" and ms_led_tv_id = " & tvid)
    '        strSql.Append(" and schedule_status ='Y'")
    '        strSql.Append(" and getdate() between sts.start_time and sts.end_time")
    '        strSql.Append(" and convert(time,getdate()) between convert(time,sst.time_from) and convert(time,sst.time_to)")
    '        strSql.Append(" order by sst.time_from")
    '        Dim trans As New TransactionDB(SelectDB.DIPRFID)
    '        Dim dt, dtSchedule As DataTable
    '        dt = DIPRFIDSqlDB.ExecuteTable(strSql.ToString, trans.Trans)
    '        If dt.Rows.Count > 0 Then
    '            Select Case dt.Rows(0)("schedule_type")
    '                Case "D"
    '                    strSqlSchedule.Append(" select * from MS_SIGNAGE_SCHEDULE_DAILY where ms_signage_template_schedule_id=" & dt.Rows(0)("id"))
    '                    dtSchedule = DIPRFIDSqlDB.ExecuteTable(strSqlSchedule.ToString, trans.Trans)
    '                    If dtSchedule.Rows.Count > 0 Then
    '                        strUrlId = dt.Rows(0)("ms_signage_content_template_id")
    '                    End If
    '                Case "W"
    '                    Select Case Date.Now.DayOfWeek
    '                        Case DayOfWeek.Monday
    '                            strcondition = " and sch_mon='Y'"
    '                        Case DayOfWeek.Tuesday
    '                            strcondition = " and sch_tue='Y'"
    '                        Case DayOfWeek.Thursday
    '                            strcondition = " and sch_thu='Y'"
    '                        Case DayOfWeek.Wednesday
    '                            strcondition = " and sch_wed='Y'"
    '                        Case DayOfWeek.Friday
    '                            strcondition = " and sch_fri='Y'"
    '                        Case DayOfWeek.Saturday
    '                            strcondition = " and sch_sat='Y'"
    '                        Case DayOfWeek.Sunday
    '                            strcondition = " and sch_sun='Y'"
    '                    End Select
    '                    strSqlSchedule.Append(" select * ")
    '                    strSqlSchedule.Append(" from MS_SIGNAGE_SCHEDULE_WEEKLY ")
    '                    strSqlSchedule.Append(" where ms_signage_template_schedule_id=" & dt.Rows(0)("id") & strcondition)
    '                    dtSchedule = DIPRFIDSqlDB.ExecuteTable(strSqlSchedule.ToString, trans.Trans)
    '                    If dtSchedule.Rows.Count > 0 Then
    '                        strUrlId = dt.Rows(0)("ms_signage_content_template_id")
    '                    End If
    '                Case "M"
    '                    strSqlSchedule.Append(" select * ")
    '                    strSqlSchedule.Append(" from MS_SIGNAGE_SCHEDULE_MONTHLY ")
    '                    strSqlSchedule.Append(" where ms_signage_template_schedule_id = " & dt.Rows(0)("id"))
    '                    strSqlSchedule.Append(" and month_no in(month(getdate())) ")
    '                    strSqlSchedule.Append(" and date_no  in (day(getdate())) ")
    '                    dtSchedule = DIPRFIDSqlDB.ExecuteTable(strSqlSchedule.ToString, trans.Trans)
    '                    If dtSchedule.Rows.Count > 0 Then
    '                        strUrlId = dt.Rows(0)("ms_signage_content_template_id")
    '                    End If
    '            End Select
    '        End If

    '        If strUrlId = "" Then
    '            strSqlDefault.Append("select ms_signage_template_id_default from MS_LED_TV where id=" & tvid)
    '            dtSchedule = DIPRFIDSqlDB.ExecuteTable(strSqlDefault.ToString, trans.Trans)
    '            If dtSchedule.Rows.Count > 0 Then
    '                strUrlId = dtSchedule.Rows(0)("ms_signage_template_id_default")
    '            End If
    '        End If

    '        Select Case strUrlId
    '            Case 1
    '                strUrl = "frmSignage_01.aspx,frmSignage_02.aspx"
    '            Case 2
    '                strUrl = "frmSignage_03.aspx"
    '            Case 3
    '                strUrl = "frmSignage_04.aspx"
    '            Case Else
    '                strUrl = ""
    '        End Select

    '        Return strUrl

    '    Catch ex As Exception
    '        Return ""
    '    End Try
    'End Function
#End Region

#Region "Top5"
    <WebMethod()> _
    Public Function GetTopDevice() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = FaultMngENG.TopDeviceAvailability(5)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function GetTopCPU() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = FaultMngENG.TopCPUUtilication(5)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function GetTopRAM() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = FaultMngENG.TopRAMUtilication(5)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    <WebMethod()> _
    Public Function GetTopDisk() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = FaultMngENG.TopDiskUtilication(5)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try
    End Function
#End Region
#End Region

#Region "Floor 6"
#Region "line chart"
    <WebMethod()> _
    Public Function LoadDipGrowLineChart() As String
        Try

            Dim strdata As String = ""
            For cnt As Integer = 0 To 4
                Dim strYear As String = Date.Now.Year - cnt
                Dim strdataqty As String = ""
                Dim strdatamm As String = ""

                Dim dt As DataTable = DigitalSignageENG.GetFileGrowthRatio(strYear)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If strdatamm = "" Then
                            strdatamm = dt.Rows(i)("mm")
                            strdataqty = dt.Rows(i)("qty")
                        Else
                            strdatamm &= "," & dt.Rows(i)("mm")
                            strdataqty &= "," & dt.Rows(i)("qty")
                        End If
                    Next


                    If cnt = 0 Then
                        strdata &= strdatamm & "|"
                    End If

                    strdata &= strdataqty

                    If cnt < 5 Then
                        strdata &= "|"
                    End If
                End If


            Next
            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function
#End Region

#Region "pie chart"
    <WebMethod()> _
    Public Function LoadDipAmountPieChart(floor_id As String) As String
        Try
            Dim strdata As String = ""
            Dim strdataqty As String = ""
            Dim strdatalabel As String = ""
            Dim strcolor As String = ""
            Dim strType As String = ""
            Dim strdata2 As String = ""
            Dim strdataqty2 As String = ""
            Dim strdatalabel2 As String = ""
            Dim strcolor2 As String = ""
            Dim strType2 As String = ""
            Dim sum2 As Double
            'Dim dt As DataTable = DigitalSignageENG.GetFileQtyByFloor

            Dim dt2 As DataTable = DigitalSignageENG.GetFileQtyByFloorCurrent

            Dim dv2 As DataView = dt2.DefaultView
            dv2.RowFilter = "id=" & floor_id

            'If room_id = 0 Then
            '    dv2.RowFilter = "id=" & id
            'Else
            '    dv2.RowFilter = "id=" & id & " and ms_room_id=" & room_id
            'End If

            If dv2.Count > 0 Then
                For i As Integer = 0 To dv2.Count - 1
                    sum2 += dv2(i)("qty")
                Next
                For i As Integer = 0 To dv2.Count - 1
                    If strdatalabel2 = "" Then
                        strdatalabel2 = Math.Round(dv2(i)("qty") * 100 / sum2, 0)
                        strdataqty2 = dv2(i)("qty")
                        strcolor2 = dv2(i)("colors")
                        strType2 = dv2(i)("patent_type_id")
                    Else
                        strdatalabel2 &= "," & Math.Round(dv2(i)("qty") * 100 / sum2, 0)
                        strdataqty2 &= "," & dv2(i)("qty")
                        strcolor2 &= "," & dv2(i)("colors")
                        strType2 &= "," & dv2(i)("patent_type_id")
                    End If
                Next
            End If
            strdata = strdatalabel2 & "|" & strdataqty2 & "|" & strcolor2 & "|" & strType2


            'Dim dv As DataView = dt.DefaultView
            'If room_id = 0 Then
            '    dv.RowFilter = "id=" & id
            'Else
            '    dv.RowFilter = "id=" & id & " and ms_room_id=" & room_id
            'End If

            'If dv.Count > 0 Then
            '    For i As Integer = 0 To dv.Count - 1
            '        sum += dv(i)("qty")
            '    Next

            '    For i As Integer = 0 To dv.Count - 1
            '        If strdatalabel = "" Then
            '            strdatalabel = Math.Round(dv(i)("qty") * 100 / sum, 0)
            '            strdataqty = dv(i)("qty")
            '            strcolor = dv(i)("colors")
            '            strType = dv(i)("patent_type_id")
            '        Else
            '            strdatalabel &= "," & Math.Round(dv(i)("qty") * 100 / sum, 0)
            '            strdataqty &= "," & dv(i)("qty")
            '            strcolor &= "," & dv(i)("colors")
            '            strType &= "," & dv(i)("patent_type_id")
            '        End If
            '    Next

            'End If
            'If dv.Count <> 0 Or dv2.Count <> 0 Then
            '    If sum > sum2 Then
            '        strdata = strdatalabel & "|" & strdataqty & "|" & strcolor & "|" & strType
            '    Else
            '        strdata = strdatalabel2 & "|" & strdataqty2 & "|" & strcolor2 & "|" & strType2
            '    End If
            'End If


            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function


    <WebMethod()> _
    Public Function LoadDipAmountPieChartFloor1(room_id As String) As String
        Try
            Dim strdata As String = ""
            Dim strdata2 As String = ""
            Dim strdataqty2 As String = ""
            Dim strdatalabel2 As String = ""
            Dim strcolor2 As String = ""
            Dim strType2 As String = ""
            Dim sum2 As Double

            Dim dt2 As DataTable = DigitalSignageENG.GetFileQtyByRoomCurrent(room_id)
            Dim dv2 As DataView = dt2.DefaultView
            dv2.RowFilter = "ms_room_id=" & room_id
            If dv2.Count > 0 Then
                For i As Integer = 0 To dv2.Count - 1
                    sum2 += dv2(i)("qty")
                Next
                For i As Integer = 0 To dv2.Count - 1
                    If strdatalabel2 = "" Then
                        strdatalabel2 = Math.Round(dv2(i)("qty") * 100 / sum2, 0)
                        strdataqty2 = dv2(i)("qty")
                        strcolor2 = dv2(i)("colors")
                        strType2 = dv2(i)("patent_type_id")
                    Else
                        strdatalabel2 &= "," & Math.Round(dv2(i)("qty") * 100 / sum2, 0)
                        strdataqty2 &= "," & dv2(i)("qty")
                        strcolor2 &= "," & dv2(i)("colors")
                        strType2 &= "," & dv2(i)("patent_type_id")
                    End If
                Next
            End If
            strdata = strdatalabel2 & "|" & strdataqty2 & "|" & strcolor2 & "|" & strType2

            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadDipAmountPieChartFloor3() As String
        Try
            Dim strdata As String = ""
            Dim strdata2 As String = ""
            Dim strdataqty2 As String = ""
            Dim strdatalabel2 As String = ""
            Dim strcolor2 As String = ""
            Dim strType2 As String = ""
            Dim sum2 As Double

            Dim dt2 As DataTable = DigitalSignageENG.GetFileQtyFloor3()
            If dt2.Rows.Count > 0 Then
                For i As Integer = 0 To dt2.Rows.Count - 1
                    sum2 += dt2.Rows(i)("qty")
                Next
                For i As Integer = 0 To dt2.Rows.Count - 1
                    If strdatalabel2 = "" Then
                        strdatalabel2 = Math.Round(dt2.Rows(i)("qty") * 100 / sum2, 0)
                        strdataqty2 = dt2.Rows(i)("qty")
                        strcolor2 = dt2.Rows(i)("colors")
                        strType2 = dt2.Rows(i)("patent_type_id")
                    Else
                        strdatalabel2 &= "," & Math.Round(dt2.Rows(i)("qty") * 100 / sum2, 0)
                        strdataqty2 &= "," & dt2.Rows(i)("qty")
                        strcolor2 &= "," & dt2.Rows(i)("colors")
                        strType2 &= "," & dt2.Rows(i)("patent_type_id")
                    End If
                Next
            End If
            strdata = strdatalabel2 & "|" & strdataqty2 & "|" & strcolor2 & "|" & strType2

            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadDipAmountPieChartDestroy() As String
        Try
            Dim strdata As String = ""
            Dim strdata2 As String = ""
            Dim strdataqty2 As String = ""
            Dim strdatalabel2 As String = ""
            Dim strcolor2 As String = ""
            Dim strType2 As String = ""
            Dim sum2 As Double

            Dim dt2 As DataTable = DigitalSignageENG.GetFileQtyAtDestroy()
            If dt2.Rows.Count > 0 Then
                For i As Integer = 0 To dt2.Rows.Count - 1
                    sum2 += dt2.Rows(i)("qty")
                Next
                For i As Integer = 0 To dt2.Rows.Count - 1
                    If strdatalabel2 = "" Then
                        strdatalabel2 = Math.Round(dt2.Rows(i)("qty") * 100 / sum2, 0)
                        strdataqty2 = dt2.Rows(i)("qty")
                        strcolor2 = dt2.Rows(i)("colors")
                        strType2 = dt2.Rows(i)("patent_type_id")
                    Else
                        strdatalabel2 &= "," & Math.Round(dt2.Rows(i)("qty") * 100 / sum2, 0)
                        strdataqty2 &= "," & dt2.Rows(i)("qty")
                        strcolor2 &= "," & dt2.Rows(i)("colors")
                        strType2 &= "," & dt2.Rows(i)("patent_type_id")
                    End If
                Next
            End If
            strdata = strdatalabel2 & "|" & strdataqty2 & "|" & strcolor2 & "|" & strType2

            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function


    <WebMethod()> _
    Public Function LoadDipDepartmentPieChart() As String
        Try
            Dim strdata As String = ""
            Dim strdataqty As String = ""
            Dim strdatalabel As String = ""
            Dim strcolor As String = ""
            Dim sum As Double
            Dim dt As DataTable = DigitalSignageENG.GetFileHoldingByDepartment
            'Dim Sql As String = "select  * from TB_DEPARTMENT"
            'dt = DIPRFIDSqlDB.ExecuteTable(Sql)
            'If Not IsDBNull(dt.Compute("SUM(qty)", "id=" & id)) Then
            '    sum = Val(dt.Compute("SUM(qty)", "id=" & id))
            'Else
            '    sum = 1
            'End If
            If dt.Rows.Count > 0 Then
                'For i As Integer = 0 To dt.Rows.Count - 1
                '    sum += dt.Rows(i)("department_code")
                'Next
                For i As Integer = 0 To dt.Rows.Count - 1
                    If strdatalabel = "" Then
                        strdatalabel = dt.Rows(i)("department_name")
                        strdataqty = dt.Rows(i)("qty")
                    Else
                        strdatalabel &= "," & dt.Rows(i)("department_name")
                        strdataqty &= "," & dt.Rows(i)("qty")
                    End If
                Next
                strdata = strdatalabel & "|" & strdataqty
            Else
                strdata = ""
            End If



            'Dim dv As DataView = dt.DefaultView
            'dv.RowFilter = "id=" & 0
            'If dv.Count > 0 Then
            '    For i As Integer = 0 To dv.Count - 1
            '        sum += dv(i)("qty")
            '    Next

            '    For i As Integer = 0 To dv.Count - 1
            '        If strdatalabel = "" Then
            '            strdatalabel = Math.Round(dv(i)("qty") * 100 / sum, 0)
            '            strdataqty = dv(i)("qty")
            '            strcolor = dv(i)("colors")
            '        Else
            '            strdatalabel &= "," & Math.Round(dv(i)("qty") * 100 / sum, 0)
            '            strdataqty &= "," & dv(i)("qty")
            '            strcolor &= "," & dv(i)("colors")
            '        End If
            '    Next

            '    strdata = strdatalabel & "|" & strdataqty & "|" & strcolor
            'Else
            '    strdata = ""
            'End If
            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function Setnumberformate(qty As String) As String


        If Val(qty) >= 1000 Then
            ' Return Math.Floor(qty / 1000) & "K"
            Return qty / 1000 & "K"
        Else
            Return qty
        End If
    End Function
#End Region

#Region "Amount Borrow&Return&Reserve"
    <WebMethod()> _
    Public Function LoadDipAmountBorrow() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetFileBorrowAndReserveQty(DateTime.Now)
            Dim dv As DataView = dt.DefaultView
            dv.RowFilter = "file_data='BORROW'"
            If dv.Count > 0 Then
                strdata = dv(0)("qty")
            Else
                strdata = "0"

            End If
            Return strdata
        Catch ex As Exception
            Return "0"
        End Try
    End Function
    <WebMethod()> _
    Public Function LoadDipAmountReserve() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetFileBorrowAndReserveQty(DateTime.Now)
            Dim dv As DataView = dt.DefaultView
            dv.RowFilter = "file_data='RESERVE'"
            If dv.Count > 0 Then
                strdata = dv(0)("qty")
            Else
                strdata = "0"
            End If
            Return strdata
        Catch ex As Exception
            Return "0"
        End Try
    End Function
    <WebMethod()> _
    Public Function LoadDipAmountReserveAll() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetFileBorrowAndReserveQty(DateTime.Now)
            Dim dv As DataView = dt.DefaultView
            dv.RowFilter = "file_data='RESERVEALL'"
            If dv.Count > 0 Then
                strdata = dv(0)("qty")
            Else
                strdata = "0"
            End If
            Return strdata
        Catch ex As Exception
            Return "0"
        End Try
    End Function
#End Region

#Region "Bar Chart"
    <WebMethod()> _
    Public Function LoadDipBarChart() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetCompareBorrowReturn
            If dt.Rows.Count = 2 Then
                strdata = dt.Rows(1)(2) & "," & dt.Rows(1)(3) & "|" & dt.Rows(0)(2) & "," & dt.Rows(0)(3) & "|" & dt.Rows(0)(0) & "," & dt.Rows(1)(0)
            Else
                strdata = ""

            End If
            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

#End Region

#Region "Amount KPI Borrow&Return"
    <WebMethod()> _
    Public Function LoadDipAmountBorrowKPI() As String
        Try
            'Dim strdata As String
            'Dim dt As DataTable = FaultMngENG.GetSignageServerInfo
            'If dt.Rows.Count > 0 Then
            '    strdata = clsdtHelper.ConvertDataTableToJson(dt)
            'Else
            '    strdata = "[]"

            'End If
            Return "100"
        Catch ex As Exception
            Return "[]"
        End Try

    End Function
    <WebMethod()> _
    Public Function LoadDipAmountReturnKPI() As String
        Try
            'Dim strdata As String
            'Dim dt As DataTable = FaultMngENG.GetSignageServerInfo
            'If dt.Rows.Count > 0 Then
            '    strdata = clsdtHelper.ConvertDataTableToJson(dt)
            'Else
            '    strdata = "[]"
            Dim dt As New DataTable
            Dim dr As DataRow

            'End If
            Return "30"
        Catch ex As Exception
            Return "[]"
        End Try

    End Function
#End Region

#Region "Amount Location"
    <WebMethod()> _
    Public Function LoadDipLocationDeviceData() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetLocationDeviceData
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

#End Region

#Region "Table File Age"
    <WebMethod()> _
    Public Function LoadDipTableFileAge() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetFileChangeDue
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"

            End If
            'Dim dt As New DataTable
            'Dim dr As DataRow
            'dt.Columns.Add("patenttypename")
            'dt.Columns.Add("location1")
            'dt.Columns.Add("location2")

            'dr = dt.NewRow
            'dr("patenttypename") = "สิทธิบัตรการประดิษฐ์"
            'dr("location1") = "1,500"
            'dr("location2") = "2,300"
            'dt.Rows.Add(dr)

            'dr = dt.NewRow
            'dr("patenttypename") = "สิทธิบัตรการออกแบบผลิตรัณฑ์"
            'dr("location1") = "1,500"
            'dr("location2") = "2,300"
            'dt.Rows.Add(dr)

            'dr = dt.NewRow
            'dr("patenttypename") = "อนุสิทธิบัตร"
            'dr("location1") = "1,500"
            'dr("location2") = "2,300"
            'dt.Rows.Add(dr)

            'dr = dt.NewRow
            'dr("patenttypename") = "รวม"
            'dr("location1") = "1,500"
            'dr("location2") = "2,300"
            'dt.Rows.Add(dr)

            strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

#End Region

#Region "Particle"
    <WebMethod()> _
    Public Function LoadParticleValue() As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetParticleValue
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("particle_value") = Format(dt.Rows(i)("particle_value"), "###.0")
                Next

                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"
            End If
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function
#End Region

#Region "Table Grownth"
    <WebMethod()> _
    Public Function LoadGrowMonthFile(patent_id As String) As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetGrowFileMonthFloor6(patent_id)
            Dim strTable As String
            Dim strcoloryear As String = "#7FE817"
            Dim strcolormonth1 As String = "#BCC6CC"
            Dim strcolormonth2 As String = "#FFFFFF"
            Dim strcolorheader As String
            'If patent_id = 1 Then
            '    strcolorheader = strcolorheaderpatenttype1
            'Else
            '    strcolorheader = strcolorheaderpatenttype3
            'End If
            strcolorheader = "#FF6666"
            strTable = "<table width=""100%"" border=""1"" cellspacing=""0"" cellpadding=""5"">"
            Dim dv As DataView = dt.DefaultView
            For i As Integer = 1 To 5
                dv.RowFilter = "tb_patent_type_id=" & patent_id & " and serie_name=" & i
                If dv.Count > 0 Then
                    If i = 1 Then
                        strTable &= "   <tr>"
                        strTable &= "    <td width=""5%"" rowspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>Year</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(0)("show_month") & "</strong></td>"
                        strTable &= "     <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(1)("show_month") & "</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(2)("show_month") & "</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(3)("show_month") & "</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(4)("show_month") & "</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(5)("show_month") & "</strong></td>"
                        strTable &= "    <td width=""1%"" rowspan=""2"" align=""center""></td>"
                        strTable &= "    <td width=""5%"" rowspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>Year</td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(6)("show_month") & "</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(7)("show_month") & "</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(8)("show_month") & "</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(9)("show_month") & "</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(10)("show_month") & "</strong></td>"
                        strTable &= "    <td height=""25px"" colspan=""2"" align=""center"" bgcolor=" & strcolorheader & "><strong>" & dv(11)("show_month") & "</strong></td>"
                        strTable &= "     </tr>"

                        strTable &= "     <tr>"
                        strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "     <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "     <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "     <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "     <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "     <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "      <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "      <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "      <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "      <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "      <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "     <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "      <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "     <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "      <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
                        strTable &= "      <td align=""center"" bgcolor=" & strcolorheader & "><strong>%</strong></td>"
                        strTable &= "     </tr>"
                    End If


                    strTable &= "     <tr>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcoloryear & ">" & dv(0)("show_year") & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(0)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(0)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(1)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(1)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(2)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(2)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(3)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(3)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(4)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(4)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(5)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(5)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td align=""center""></td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcoloryear & ">" & dv(6)("show_year") & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(6)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(6)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(7)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(7)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(8)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(8)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(9)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(9)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(10)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth1 & ">" & FormatNumber(dv(10)("growth_ratio"), 0) & "</td>"
                    strTable &= "     <td height=""25px"" align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(11)("file_qty"), 0) & "</td>"
                    strTable &= "     <td align=""center"" bgcolor=" & strcolormonth2 & ">" & FormatNumber(dv(11)("growth_ratio"), 0) & "</td>"
                    strTable &= "     </tr>"
                End If
            Next

            strTable &= "</table>"
            If dt.Rows.Count > 0 Then
                strdata = strTable
            Else
                strdata = ""
            End If
            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadGrowYearFile(patent_id As String) As String
        Try
            Dim strdata As String
            Dim strcolorheader As String
            strcolorheader = "#FF6666"
            Dim strcoloryear As String = "#7FE817"
            Dim dt As DataTable = DigitalSignageENG.GetGrowFileYearFloor6(patent_id)
            Dim strTable As String
            strTable = "<table width=""100%"" border=""1"" cellspacing=""0"" cellpadding=""5"">"
            strTable &= "   <tr>"
            strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>Year</strong></td>"
            strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>จำนวน</strong></td>"
            strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=" & strcolorheader & "><strong>อัตราเติบโต(%)</strong></td>"
            strTable &= "   </tr>"
            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "tb_patent_type_id=" & patent_id
            If dv.Count = 5 Then
                strTable &= "   <tr>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=" & strcoloryear & ">" & dv(0)("show_year") & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(0)("file_qty"), 0) & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(0)("growth_ratio"), 0) & "</td>"
                strTable &= "   </tr>"

                strTable &= "   <tr>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=" & strcoloryear & ">" & dv(1)("show_year") & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(1)("file_qty"), 0) & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(1)("growth_ratio"), 0) & "</td>"
                strTable &= "   </tr>"

                strTable &= "   <tr>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=" & strcoloryear & ">" & dv(2)("show_year") & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(2)("file_qty"), 0) & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(2)("growth_ratio"), 0) & "</td>"
                strTable &= "   </tr>"

                strTable &= "   <tr>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=" & strcoloryear & ">" & dv(3)("show_year") & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(3)("file_qty"), 0) & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(3)("growth_ratio"), 0) & "</td>"
                strTable &= "   </tr>"

                strTable &= "   <tr>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=" & strcoloryear & ">" & dv(4)("show_year") & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(4)("file_qty"), 0) & "</td>"
                strTable &= "    <td width=""33%"" height=""25px"" align=""center"" bgcolor=""#e6e7e8"">" & FormatNumber(dv(4)("growth_ratio"), 0) & "</td>"
                strTable &= "   </tr>"
            End If


            strTable &= "</table>"
            If dt.Rows.Count > 0 Then
                strdata = strTable
            Else
                strdata = ""
            End If
            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

#End Region

#End Region

#Region "Floor10"

    <WebMethod()> _
    Public Function LoadComparePatentypeAmountFloor10BarChart() As String
        Try
            Dim strdata As String = ""
            Dim dt As DataTable = DigitalSignageENG.GetComparePatentypeAmountFloor10

            ''------ data test ----
            'For i As Integer = 0 To dt.Rows.Count - 1
            '    dt.Rows(i)("amountapp") = i + 10
            'Next
            ''------ data test ----

            If dt.Rows.Count = 6 Then
                strdata = dt.Rows(0)(2) & "," & dt.Rows(3)(2) & "|" & dt.Rows(1)(2) & "," & dt.Rows(4)(2) & "|" & dt.Rows(2)(2) & "," & dt.Rows(5)(2)
            End If
            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadPatentypeAmountFloor10PieChart(type As String) As String
        Try
            Dim strdata As String = ""
            Dim strdataqty As String = ""
            Dim strdatalabel As String = ""
            Dim strcolor As String = ""
            Dim strType As String = ""
            Dim strseriename As String = ""
            Dim sum As Double
            Dim dt As DataTable = DigitalSignageENG.GetPatentypeAmountFloor10
            Dim dv As DataView = dt.DefaultView
            dv.RowFilter = "type= '" & type & "'"

            If dv.Count > 0 Then
                For i As Integer = 0 To dv.Count - 1
                    sum += dv(i)("amountapp")
                Next

                For i As Integer = 0 To dv.Count - 1
                    If strdatalabel = "" Then
                        strdatalabel = Math.Round(dv(i)("amountapp") * 100 / sum, 0)
                        strdataqty = dv(i)("amountapp")
                        strcolor = dv(i)("colors")
                        strType = dv(i)("patent_type_name")
                    Else
                        strdatalabel &= "," & Math.Round(dv(i)("amountapp") * 100 / sum, 0)
                        strdataqty &= "," & dv(i)("amountapp")
                        strcolor &= "," & dv(i)("colors")
                        strType &= "," & dv(i)("patent_type_name")
                    End If
                Next

                strdata = strdatalabel & "|" & strdataqty & "|" & strcolor & "|" & strType
            Else
                strdata = ""
            End If
            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadTablePatentypeAmountTopTimeFloor10(patent_type_id As String) As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetPatentypeAmountTopTimeFloor10(patent_type_id)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"

            End If


            strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadTablePatentypeAmountTopReserveFloor10(patent_type_id As String) As String
        Try
            Dim strdata As String
            Dim dt As DataTable = DigitalSignageENG.GetPatentypeAmountTopReserveFloor10(patent_type_id)
            If dt.Rows.Count > 0 Then
                strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Else
                strdata = "[]"

            End If


            strdata = clsdtHelper.ConvertDataTableToJson(dt)
            Return strdata
        Catch ex As Exception
            Return "[]"
        End Try

    End Function

    <WebMethod()> _
    Public Function LoadCompareReserveBorrowYieldAmountFloor10() As String
        Try
            Dim strdataamountreserve As String = ""
            Dim strdataamountborrow As String = ""
            Dim stryield As String = ""
            Dim strdatalabel As String = ""
            Dim strdata As String
            Dim num As Integer = Engine.GlobalFunction.GetSysConfing("AmountDayOfSignageFloor10")
            For j As Integer = 0 To num - 1
                Dim dt As DataTable = DigitalSignageENG.GetCompareReserveBorrowYieldAmountFloor10_bar(num - (j + 1))
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If strdatalabel = "" Then
                            strdatalabel = dt.Rows(i)("days_reserve")
                            strdataamountreserve = dt.Rows(i)("amountapp_reserve")
                            strdataamountborrow = dt.Rows(i)("amountapp_borrow")
                        Else
                            strdatalabel &= "," & dt.Rows(i)("days_reserve")
                            strdataamountreserve &= "," & dt.Rows(i)("amountapp_reserve")
                            strdataamountborrow &= "," & dt.Rows(i)("amountapp_borrow")
                        End If
                    Next
                End If

            Next

            If strdatalabel <> "" Then
                strdata = strdataamountreserve & "|" & strdataamountborrow & "|" & stryield & "|" & strdatalabel
            Else
                strdata = ""
            End If


            ''------- data test -------
            'For i As Integer = 0 To dt.Rows.Count - 1
            '    dt.Rows(i)("amountapp_reserve") = i + 10
            '    dt.Rows(i)("amountapp_borrow") = i + 12
            '    dt.Rows(i)("yield") = i + 5
            'Next
            ''------- data test -------


            Return strdata
        Catch ex As Exception
            Return ""
        End Try

    End Function
    <WebMethod()> _
    Public Function LoadFloorPlanByApp_No(app_no As String, login_username As String) As String
        Return Engine.FileLocationENG.LoadFloorPlanByApp_No(app_no, login_username)
    End Function

    <WebMethod()> _
    Public Function LoadFloorPlanByApp_No_NotMap(app_no As String, login_username As String) As String
        Return Engine.FileLocationENG.LoadFloorPlanByApp_No_NotMap(app_no, login_username)
    End Function
#End Region
End Class