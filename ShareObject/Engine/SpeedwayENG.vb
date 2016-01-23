Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms
Imports Engine.Common
Imports Engine.LogFile
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.Threading
Imports AlexPilotti.FTPS.Client
Imports AlexPilotti.FTPS.Common


Public Class SpeedwayENG
#Region "Speedway Setting"
    Public Shared Function GetSpeedwaySettingXML(UserName As String, SerialNo As String) As String
        Dim ret As String = ""
        Try
            Dim sql As String = "select s.id, ss.id ms_speedway_setting_id, s.serial_no, ss.setting_label, ss.setting_description, ss.setting_search_mode, ss.setting_session,"
            sql += " ss.setting_tag_populate_estimate, ss.setting_time_correct_enabled,ss.filters_mode,"
            sql += " isnull(sld.is_enabled,'false') low_duty_cycle_is_enabled, isnull(sld.field_ping_interval_in_ms,0) field_ping_interval_in_ms, isnull(sld.emptry_field_timeout_in_ms,0) emptry_field_timeout_in_ms,"
            sql += " ss.keepalive_is_enabled, ss.keepalive_period_in_ms, ss.keepalive_link_down_threshold"
            sql += " from MS_SPEEDWAY_SETTING ss"
            sql += " inner join MS_SPEEDWAY s on s.id=ss.ms_speedway_id"
            sql += " left join MS_SPEEDWAY_LOW_DUTY_CYCLE sld on sld.ms_speedway_setting_id=ss.id"
            sql += " where s.serial_no='" & SerialNo & "'"

            Dim dt As DataTable = GlobalFunction.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)
                ret += "<Settings" & vbNewLine
                ret += "    Label='" & dr("setting_label") & "'" & vbNewLine
                ret += "    Description='" & dr("setting_description") & "'" & vbNewLine
                ret += "    SearchMode='" & dr("setting_search_mode") & "'" & vbNewLine
                ret += "    Session='" & dr("setting_session") & "'" & vbNewLine
                ret += "    TagPopulationEstimate='" & dr("setting_tag_populate_estimate") & "'" & vbNewLine
                ret += "    IsTimestampCorrectionEnabled='" & dr("setting_time_correct_enabled") & "'" & vbNewLine
                ret += "    >" & vbNewLine
                ret += BuildFilterSetting(dr("ms_speedway_setting_id"), dr("filters_mode"))
                ret += BuildAntennaSetting(dr("id"))
                ret += "    <LowDutyCycle" & vbNewLine
                ret += "        IsEnabled='" & dr("low_duty_cycle_is_enabled").ToString.ToLower & "'" & vbNewLine
                ret += "        FieldPingIntervalInMs='" & dr("field_ping_interval_in_ms") & "'" & vbNewLine
                ret += "        EmptyFieldTimeoutInMs='" & dr("emptry_field_timeout_in_ms") & "'" & vbNewLine
                ret += "        />" & vbNewLine
                ret += BuildGPISetting(dr("id"))
                ret += "    <KeepAlive" & vbNewLine
                ret += "        IsEnabled='" & dr("keepalive_is_enabled").ToString.ToLower & "'" & vbNewLine
                ret += "        PeriodInMs='" & dr("keepalive_period_in_ms") & "'" & vbNewLine
                ret += "        LinkDownThreshold='" & dr("keepalive_link_down_threshold") & "'" & vbNewLine
                ret += "        />" & vbNewLine
                ret += "</Settings>" & vbNewLine
            End If
            dt.Dispose()
        Catch ex As Exception
            LogENG.SaveErrLog("SpeedwayENG.GetSpeedwaySettingXML", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Private Shared Function BuildGPISetting(SpeedwayID As Long) As String
        Dim ret As String = ""
        Try
            Dim lnq As New MsSpeedwayGpiLinqDB
            Dim dt As DataTable = lnq.GetDataList("ms_speedway_id='" & SpeedwayID & "'", "port_number", Nothing)
            If dt.Rows.Count > 0 Then
                Dim gpi As String = ""
                For Each dr As DataRow In dt.Rows
                    ret += "<AutoStart" & vbNewLine
                    ret += "    Mode='" & dr("auto_start_mode") & "'" & vbNewLine
                    ret += "    GpiPortNumber='" & dr("port_number") & "'" & vbNewLine
                    ret += "    GpiLevel='" & dr("auto_start_gpi_level").ToString.ToLower & "'" & vbNewLine
                    ret += "    FirstDelayInMs='" & dr("auto_start_first_delay") & "'" & vbNewLine
                    ret += "    PeriodInMs='" & dr("auto_start_period") & "'" & vbNewLine
                    ret += "    />" & vbNewLine

                    ret += "<AutoStop" & vbNewLine
                    ret += "    Mode='" & dr("auto_stop_mode") & "'" & vbNewLine
                    ret += "    GpiPortNumber='" & dr("port_number") & "'" & vbNewLine
                    ret += "    GpiLevel='" & dr("auto_stop_gpi_level").ToString.ToLower & "'" & vbNewLine
                    ret += "    DurationInMs='" & dr("auto_stop_duration") & "'" & vbNewLine
                    ret += "    />" & vbNewLine

                    gpi += "<Gpi" & vbNewLine
                    gpi += "    PortNumber='" & dr("port_number") & "'" & vbNewLine
                    gpi += "    IsEnabled='" & dr("is_enabled").ToString.ToLower & "'" & vbNewLine
                    gpi += "    DebounceInMs='" & dr("debounce_in_ms") & "'" & vbNewLine
                    gpi += "    />" & vbNewLine
                Next
                ret += gpi
            End If
            dt.Dispose()
        Catch ex As Exception
            LogENG.SaveErrLog("SpeedwayENG.BuildGPISetting", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Private Shared Function BuildAntennaSetting(SpeedwayID As Long) As String
        Dim ret As String = ""
        Try
            Dim lnq As New MsSpeedwayAntLinqDB
            Dim dt As DataTable = lnq.GetDataList("ms_speedway_id='" & SpeedwayID & "'", "port_number", Nothing)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    ret += "<Antenna" & vbNewLine
                    ret += "    PortNumber='" & dr("port_number") & "'" & vbNewLine
                    ret += "    IsEnabled='" & dr("is_enabled").ToString.ToLower & "'" & vbNewLine
                    ret += "    TxPowerInDbm='" & dr("tx_power_in_dbm") & "'" & vbNewLine
                    ret += "    RxSensitivityInDbm='" & dr("rx_sensitivity_in_dbm") & "'" & vbNewLine
                    ret += "    />" & vbNewLine
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            LogENG.SaveErrLog("SpeedwayENG.BuildAntennaSetting", ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Private Shared Function BuildFilterSetting(SpeedwaySettingID As Long, FilterMode As String) As String
        Dim ret As String = ""
        Try
            Dim fLnq As New MsSpeedwaySettingFilterLinqDB
            Dim fDt As DataTable = fLnq.GetDataList("ms_speedway_setting_id='" & SpeedwaySettingID & "'", "tag_filter_no", Nothing)
            If fDt.Rows.Count > 0 Then
                ret += "<Filters" & vbNewLine
                ret += "    Mode='" & FilterMode & "'" & vbNewLine
                ret += "    >" & vbNewLine
                For i As Integer = 0 To fDt.Rows.Count - 1
                    Dim fDr As DataRow = fDt.Rows(i)
                    ret += "        <TagFilter" & fDr("tag_filter_no") & vbNewLine
                    ret += "            MemoryBank='" & fDr("memory_bank") & "'" & vbNewLine
                    ret += "            BitPointer='" & fDr("bit_pointer") & "'" & vbNewLine
                    ret += "            BitCount='" & fDr("bit_count") & "'" & vbNewLine
                    ret += "            TagMask='" & fDr("tag_mask") & "'" & vbNewLine
                    ret += "            FilterOp='" & fDr("filter_op") & "'" & vbNewLine
                    ret += "            />" & vbNewLine
                Next
                ret += "</Filters>" & vbNewLine
            End If
            fDt.Dispose()
        Catch ex As Exception
            LogENG.SaveErrLog("SpeedwaySettingENG.BuildFilterSetting", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function


    Public Shared Function GetMaxReaderID(trans As TransactionDB) As String
        Dim ret As String = ""
        Dim sql As String = " select max(convert(int,isnull(readerid,0))) + 1 maxid from ms_speedway "
        Dim dt As DataTable = DIPRFIDSqlDB.ExecuteTable(sql, trans.Trans)

        If dt.Rows.Count > 0 Then
            ret = dt.Rows(0)("maxid")
        Else
            ret = "1"
        End If
        dt.Dispose()

        Return ret
    End Function

#End Region

#Region "Speedway Reading Area"
    Public Shared Function GetAntennaGridArea(UserName As String, SerialNo As String, AntNo As String) As String
        Dim ret As String = ""
        Try
            Dim sql As String = "select gl.id grid_layout_id, gl.layout_name, gl.vertical_line, gl.horizontal_line,"
            sql += " sg.grid_row, sg.grid_col"
            sql += " from MS_SPEEDWAY s"
            sql += " inner join MS_SPEEDWAY_ANT sa on s.id=sa.ms_speedway_id"
            sql += " inner join MS_SPEEDWAY_ANT_GRID sg on sa.id=sg.ms_speedway_ant_id"
            sql += " inner join MS_ROOM r on r.id=s.ms_room_id"
            sql += " inner join MS_GRID_LAYOUT gl on gl.id=r.ms_grid_layout_id_current and gl.id=sg.ms_grid_layout_id"
            sql += " where s.serial_no='" & SerialNo & "' and sa.port_number='" & AntNo & "'"

            Dim dt As DataTable = GlobalFunction.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                Dim ldt As New DataTable
                ldt = dt.DefaultView.ToTable(True, "grid_layout_id", "layout_name", "vertical_line", "horizontal_line")
                If ldt.Rows.Count > 0 Then
                    For Each ldr As DataRow In ldt.Rows
                        ret += "<AntennaGrid>" & vbNewLine
                        ret += "    <LayoutID>" & ldr("grid_layout_id") & "</LayoutID>" & vbNewLine
                        ret += "    <LayoutName>" & ldr("layout_name") & "</LayoutName>" & vbNewLine
                        ret += "    <VerticalLine>" & ldr("vertical_line") & "</VerticalLine>" & vbNewLine
                        ret += "    <HorizontalLine>" & ldr("horizontal_line") & "</HorizontalLine>" & vbNewLine
                        ret += "    <ReadArea>" & vbNewLine
                        dt.DefaultView.RowFilter = "grid_layout_id='" & ldr("grid_layout_id") & "'"
                        For Each dr As DataRowView In dt.DefaultView
                            ret += "        <Point>" & vbNewLine
                            ret += "            <Row>" & dr("grid_row") & "</Row>" & vbNewLine
                            ret += "            <Column>" & dr("grid_col") & "</Column>" & vbNewLine
                            ret += "        </Point>" & vbNewLine
                        Next
                        ret += "    </ReadArea>" & vbNewLine
                        ret += "</AntennaGrid>" & vbNewLine
                        dt.DefaultView.RowFilter = ""
                    Next
                End If
                ldt.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = ""
            LogENG.SaveErrLog(UserName, ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function


    Public Shared Function GetSpeedwayGridArea(UserName As String, SerialNo As String) As String
        Dim ret As String = ""
        Try
            Dim sql As String = "select gl.id grid_layout_id, gl.layout_name, gl.vertical_line, gl.horizontal_line,"
            sql += " sg.grid_row, sg.grid_col, sa.port_number ant_no"
            sql += " from MS_SPEEDWAY s"
            sql += " inner join MS_SPEEDWAY_ANT sa on s.id=sa.ms_speedway_id"
            sql += " inner join MS_SPEEDWAY_ANT_GRID sg on sa.id=sg.ms_speedway_ant_id"
            sql += " inner join MS_ROOM r on r.id=s.ms_room_id"
            sql += " inner join MS_GRID_LAYOUT gl on gl.id=r.ms_grid_layout_id_current and gl.id=sg.ms_grid_layout_id"
            sql += " where s.serial_no='" & SerialNo & "' "
            sql += " order by gl.id, sa.port_number, sg.grid_row, sg.grid_col"

            Dim dt As DataTable = GlobalFunction.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                Dim ldt As New DataTable
                ldt = dt.DefaultView.ToTable(True, "grid_layout_id", "layout_name", "vertical_line", "horizontal_line")
                If ldt.Rows.Count > 0 Then
                    For Each ldr As DataRow In ldt.Rows
                        ret += "<AntennaGrid>" & vbNewLine
                        ret += "    <LayoutID>" & ldr("grid_layout_id") & "</LayoutID>" & vbNewLine
                        ret += "    <LayoutName>" & ldr("layout_name") & "</LayoutName>" & vbNewLine
                        ret += "    <VerticalLine>" & ldr("vertical_line") & "</VerticalLine>" & vbNewLine
                        ret += "    <HorizontalLine>" & ldr("horizontal_line") & "</HorizontalLine>" & vbNewLine

                        Dim aDt As New DataTable
                        aDt = dt.DefaultView.ToTable(True, "grid_layout_id", "ant_no")
                        If aDt.Rows.Count > 0 Then
                            For Each aDr As DataRow In aDt.Rows
                                ret += "    <ReadArea>" & vbNewLine
                                ret += "        <AntNo>" & aDr("ant_no") & "</AntNo>" & vbNewLine
                                dt.DefaultView.RowFilter = "grid_layout_id='" & ldr("grid_layout_id") & "' and ant_no='" & aDr("ant_no") & "'"
                                For Each dr As DataRowView In dt.DefaultView
                                    ret += "        <Point>" & vbNewLine
                                    ret += "            <Row>" & dr("grid_row") & "</Row>" & vbNewLine
                                    ret += "            <Column>" & dr("grid_col") & "</Column>" & vbNewLine
                                    ret += "        </Point>" & vbNewLine
                                Next
                                ret += "    </ReadArea>" & vbNewLine
                                dt.DefaultView.RowFilter = ""
                            Next
                        End If
                        aDt.Dispose()

                        ret += "</AntennaGrid>" & vbNewLine
                        dt.DefaultView.RowFilter = ""
                    Next
                End If
                ldt.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = ""
            LogENG.SaveErrLog(UserName, ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Function GetSpeedwayGridAreaText(UserName As String, SerialNo As String) As String
        Dim ret As String = ""
        Try
            Dim sql As String = "select gl.id grid_layout_id, gl.layout_name, gl.vertical_line, gl.horizontal_line,"
            sql += " sg.grid_row, sg.grid_col, sa.port_number ant_no"
            sql += " from MS_SPEEDWAY s"
            sql += " inner join MS_SPEEDWAY_ANT sa on s.id=sa.ms_speedway_id"
            sql += " inner join MS_SPEEDWAY_ANT_GRID sg on sa.id=sg.ms_speedway_ant_id"
            sql += " inner join MS_ROOM r on r.id=s.ms_room_id"
            sql += " inner join MS_GRID_LAYOUT gl on gl.id=r.ms_grid_layout_id_current and gl.id=sg.ms_grid_layout_id"
            sql += " where s.serial_no='" & SerialNo & "' "
            sql += " order by gl.id, sa.port_number, sg.grid_row, sg.grid_col"

            Dim dt As DataTable = GlobalFunction.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                Dim ldt As New DataTable
                ldt = dt.DefaultView.ToTable(True, "grid_layout_id", "layout_name", "vertical_line", "horizontal_line")
                If ldt.Rows.Count > 0 Then
                    For Each ldr As DataRow In ldt.Rows
                        ret += ldr("grid_layout_id") & "|"
                        Dim aDt As New DataTable
                        aDt = dt.DefaultView.ToTable(True, "grid_layout_id", "ant_no")
                        If aDt.Rows.Count > 0 Then
                            For Each aDr As DataRow In aDt.Rows
                                ret += "*" & aDr("ant_no")
                                dt.DefaultView.RowFilter = "grid_layout_id='" & ldr("grid_layout_id") & "' and ant_no='" & aDr("ant_no") & "'"
                                ret += "," & dt.DefaultView.Count & "|"
                                For Each dr As DataRowView In dt.DefaultView
                                    ret += dr("grid_row") & "," & dr("grid_col") & "|"
                                Next
                            Next
                        End If
                        aDt.Dispose()

                        'ret += "<AntennaGrid>" & vbNewLine
                        'ret += "    <LayoutID>" & ldr("grid_layout_id") & "</LayoutID>" & vbNewLine
                        'ret += "    <LayoutName>" & ldr("layout_name") & "</LayoutName>" & vbNewLine
                        'ret += "    <VerticalLine>" & ldr("vertical_line") & "</VerticalLine>" & vbNewLine
                        'ret += "    <HorizontalLine>" & ldr("horizontal_line") & "</HorizontalLine>" & vbNewLine

                        'Dim aDt As New DataTable
                        'aDt = dt.DefaultView.ToTable(True, "grid_layout_id", "ant_no")
                        'If aDt.Rows.Count > 0 Then
                        '    For Each aDr As DataRow In aDt.Rows
                        '        ret += "    <ReadArea>" & vbNewLine
                        '        ret += "        <AntNo>" & aDr("ant_no") & "</AntNo>" & vbNewLine
                        '        dt.DefaultView.RowFilter = "grid_layout_id='" & ldr("grid_layout_id") & "' and ant_no='" & aDr("ant_no") & "'"
                        '        For Each dr As DataRowView In dt.DefaultView
                        '            ret += "        <Point>" & vbNewLine
                        '            ret += "            <Row>" & dr("grid_row") & "</Row>" & vbNewLine
                        '            ret += "            <Column>" & dr("grid_col") & "</Column>" & vbNewLine
                        '            ret += "        </Point>" & vbNewLine
                        '        Next
                        '        ret += "    </ReadArea>" & vbNewLine
                        '        dt.DefaultView.RowFilter = ""
                        '    Next
                        'End If
                        'aDt.Dispose()

                        'ret += "</AntennaGrid>" & vbNewLine
                        dt.DefaultView.RowFilter = ""
                    Next
                End If
                ldt.Dispose()
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = ""
            LogENG.SaveErrLog(UserName, ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
#End Region

#Region " Speedway FTP File"
    Private Shared Function ValidateCertificate(ByVal sender As Object, _
                                      ByVal certificate As X509Certificate, _
                                      ByVal chain As X509Chain, _
                                      ByVal sslPolicyErrors As Security.SslPolicyErrors) As Boolean
        Return True
    End Function
    Public Shared Function GetTextFileFromSpeedway(IPAddress As String, ftpUser As String, ftpPwd As String, ftpPort As Integer, ftpPath As String, LocalPath As String, DatePath As String, SerialNo As String) As String
        Dim ret As String = ""

        Using ftp As New FTPSClient
            Dim LocalFileName As String = ""
            Try
                Dim cld As New Net.NetworkCredential(ftpUser, ftpPwd)
                'SSL/TSL Mode
                'ret = ftp.Connect(IPAddress, ftpPort, cld, AlexPilotti.FTPS.Client.ESSLSupportMode.Implicit, _
                '    New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate), _
                '    New System.Security.Cryptography.X509Certificates.X509Certificate(), 0, 0, 0, 5000, True)

                Try
                    'No SSL Mode
                    ret = ftp.Connect(IPAddress, ftpPort, cld, AlexPilotti.FTPS.Client.ESSLSupportMode.ClearText, _
                        New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate), _
                        New System.Security.Cryptography.X509Certificates.X509Certificate(), 0, 0, 0, 10000, False, EDataConnectionMode.Active)

                    ret = "True"
                Catch ex As Exception
                    ret = "False"
                    LogFile.LogENG.SaveErrLog("SpeedwayENG.GetTextFileFromSpeedway", "1. Exception : IP=" & IPAddress & "  FileName=" & LocalFileName & " " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If ret = "True" Then
                    ret = LocalPath & "CopyPath\" & SerialNo
                    If IO.Directory.Exists(ret) = False Then
                        IO.Directory.CreateDirectory(ret)
                    End If

                    Dim ftpFileName As String = "Log_file.txt"
                    LocalFileName = ret & "\" & SerialNo & "_" & DatePath & "_" & DateTime.Now.ToString("HHmmss") & ".txt"
                    If IO.File.Exists(LocalFileName) = True Then
                        Try
                            IO.File.Delete(LocalFileName)
                        Catch ex As Exception

                        End Try
                    End If

                    ftp.SetCurrentDirectory(ftpPath)

                    ftp.GetFile(ftpFileName, LocalFileName)
                    If IO.File.Exists(LocalFileName) = True Then
                        ftp.DeleteFile(ftpFileName)
                    End If
                    ret = "True"
                End If
            Catch ex As Exception
                ret = "False"
                LogFile.LogENG.SaveErrLog("SpeedwayENG.GetTextFileFromSpeedway", "2. Exception : IP=" & IPAddress & "  FileName=" & LocalFileName & " " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End Using

        Return ret
    End Function


    Public Shared Function GetTracingSpeedwayList() As DataTable
        Dim dt As DataTable
        Try
            dt = GetSpeedWayData(" and s.ms_speedway_objective_id in (2) ", "ip_address")
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Public Shared Function GetSpeedWayBySerialNo(SerialNo As String) As DataTable
        Dim dt As DataTable
        Try
            dt = GetSpeedWayData(" and s.serial_no='" & SerialNo & "'", "")
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Private Shared Function GetSpeedWayData(wh As String, OrderBy As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim sql As String = " select s.id,s.ReaderID,s.serial_no,s.ip_address,s.install_position, " & vbNewLine
            sql += " r.id ms_room_id, r.room_name, f.id ms_floor_id, f.floor_name," & vbNewLine
            sql += " s.ms_speedway_objective_id, so.objective_name, s.ant_qty, s.gpi_qty," & vbNewLine
            sql += " s.ftp_user, s.ftp_pwd, s.ftp_port, s.ftp_path, s.ftp_data_path" & vbNewLine
            sql += " from MS_SPEEDWAY s" & vbNewLine
            sql += " inner join MS_ROOM r on r.id=s.ms_room_id" & vbNewLine
            sql += " inner join MS_FLOOR f on f.id=r.ms_floor_id" & vbNewLine
            sql += " inner join MS_SPEEDWAY_OBJECTIVE so on so.id=s.ms_speedway_objective_id" & vbNewLine
            sql += " where 1=1 " & wh & vbNewLine
            If OrderBy.Trim <> "" Then
                sql += " order by " & OrderBy & vbNewLine
            End If

            dt = GlobalFunction.GetDatatable(sql)
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

    Public Shared Function MidrangeUpdateCurrentLocation(AppNo As String, MoveDate As String, ReaderID As String, LocationName As String, MsRoomID As Long, trans As TransactionDB) As String
        Dim ret As String = "False"
        Dim fcLnq As New TsFileCurrentLocationLinqDB
        Try
            fcLnq.ChkDataByAPP_NO(AppNo, trans.Trans)
            fcLnq.APP_NO = AppNo
            fcLnq.MOVE_DATE = MoveDate
            fcLnq.READERID = ReaderID
            fcLnq.RSSI = 0
            fcLnq.ANT_PORT_NUMBER = 1    'Midrang มันมี Ant เดียว
            fcLnq.LOCATION_NAME = LocationName
            fcLnq.MS_ROOM_ID = MsRoomID

            'Dim re As Boolean = False
            If fcLnq.ID > 0 Then
                ret = fcLnq.UpdateByPK("SpeedwayENG.MidrangeUpdateCurrentLocation", trans.Trans).ToString
            Else
                ret = fcLnq.InsertData("SpeedwayENG.MidrangeUpdateCurrentLocation", trans.Trans).ToString
            End If

            If ret = "False" Then
                ret = "False|" & fcLnq.ErrorMessage
            Else
                Dim sql As String = "delete from TS_FILE_CURRENT_GRID where ts_file_current_location_id= '" & fcLnq.ID & "' "
                ret = DIPRFIDSqlDB.ExecuteNonQuery(sql, trans.Trans).ToString

                If ret = "False" Then
                    ret = "False|" & DIPRFIDSqlDB.ErrorMessage
                End If
            End If
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("SpeedwayENG.MidrangeUpdateCurrentLocation", "Exception : " & ex.Message & vbNewLine & fcLnq.ErrorMessage)
            ret = "False|Exception : " & ex.Message & vbNewLine & fcLnq.ErrorMessage
        End Try
        fcLnq = Nothing

        Return ret
    End Function


    Private Shared Sub SpeedwayUpdateCurrentLocation(AppNo As String, MoveDate As DateTime, ReaderID As String, Rssi As Double, AntNo As String, MsRoomID As Long, LocationName As String, MsGridLayoutID As Long, GridRow As Integer, GridCol As Integer)
        'ถ้าเป็นรายการที่มาจาก ReaderID เดิม Ant เดิม LayoutID เดิม GridRow เดิม GridColumn เดิม ก็ไม่ต้อง Update Current Location
        Dim cSql As String = "select fc.app_no, fc.readerid,fc.ant_port_number,fc.ms_room_id," & vbNewLine
        cSql += " isnull(fg.ms_grid_layout_id,0) ms_grid_layout_id," & vbNewLine
        cSql += " isnull(fg.grid_row,0) grid_row, isnull(fg.grid_col,0) grid_col" & vbNewLine
        cSql += " from TS_FILE_CURRENT_LOCATION fc" & vbNewLine
        cSql += " left join TS_FILE_CURRENT_GRID fg on fc.id=fg.ts_file_current_location_id " & vbNewLine
        cSql += " where fc.app_no='" & AppNo & "'" & vbNewLine

        Dim cDt As DataTable = GlobalFunction.GetDatatable(cSql)
        cDt.DefaultView.RowFilter = "app_no='" & AppNo & "' and readerid='" & ReaderID & "' and ant_port_number='" & AntNo & "' and ms_grid_layout_id='" & MsGridLayoutID & "' and grid_row='" & GridRow & "' and grid_col='" & GridCol & "'"

        Dim IsInsertHistory As Boolean = False
        Dim BorrowerID As Long = 0
        Dim BorrowerName As String = ""

        Dim DesktopID As Long = 0
        Dim DesktopName As String = ""

        Dim trans As New TransactionDB(SelectDB.DIPRFID)
        If cDt.DefaultView.Count = 0 Then
            'Location เปลี่ยน
            Dim bDt As DataTable = FileLocationENG.GetFileBorrowData(AppNo, MoveDate)
            If bDt.Rows.Count > 0 Then
                BorrowerID = bDt.Rows(0)("borrower_id")
                BorrowerName = bDt.Rows(0)("borrowername")

                If MsGridLayoutID > 0 Then
                    Dim dDt As DataTable = FileLocationENG.GetOfficerDesktop(BorrowerID, MsRoomID)
                    If dDt.Rows.Count > 0 Then
                        DesktopID = dDt.Rows(0)("id")
                        DesktopName = dDt.Rows(0)("desk_name")
                    End If
                    dDt.Dispose()
                End If
            End If
            bDt.Dispose()

            Dim fcLnq As New TsFileCurrentLocationLinqDB
            fcLnq.ChkDataByAPP_NO(AppNo, trans.Trans)
            fcLnq.APP_NO = AppNo

            If MoveDate > fcLnq.MOVE_DATE Then
                fcLnq.MOVE_DATE = MoveDate
            End If
            fcLnq.READERID = ReaderID
            fcLnq.RSSI = Rssi
            fcLnq.ANT_PORT_NUMBER = AntNo
            fcLnq.LOCATION_NAME = LocationName
            fcLnq.MS_ROOM_ID = MsRoomID
            fcLnq.TB_OFFICER_ID = BorrowerID
            fcLnq.OFFICER_NAME = BorrowerName
            fcLnq.MS_DESKTOP_ID = DesktopID
            fcLnq.DESK_NAME = DesktopName

            Dim re As Boolean = False
            If fcLnq.ID > 0 Then
                re = fcLnq.UpdateByPK("SpeedwayENG.SpeedwayUpdateCurrentLocation", trans.Trans)
            Else
                re = fcLnq.InsertData("SpeedwayENG.SpeedwayUpdateCurrentLocation", trans.Trans)
            End If

            If re = True Then
                If MsGridLayoutID > 0 Then
                    Dim fgLnq As New TsFileCurrentGridLinqDB
                    fgLnq.ChkDataByMS_GRID_LAYOUT_ID_TS_FILE_CURRENT_LOCATION_ID(MsGridLayoutID, fcLnq.ID, trans.Trans)

                    fgLnq.TS_FILE_CURRENT_LOCATION_ID = fcLnq.ID
                    fgLnq.MS_GRID_LAYOUT_ID = MsGridLayoutID
                    fgLnq.GRID_COL = GridCol
                    fgLnq.GRID_ROW = GridRow

                    If fgLnq.ID > 0 Then
                        re = fgLnq.UpdateByPK("SpeedwayENG.SpeedwayUpdateCurrentLocation", trans.Trans)
                    Else
                        re = fgLnq.InsertData("SpeedwayENG.SpeedwayUpdateCurrentLocation", trans.Trans)
                    End If

                    If re = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        LogFile.LogENG.SaveErrLog("SpeedwayENG.SpeedwayUpdateCurrentLocation", fgLnq.ErrorMessage)
                    End If
                    fgLnq = Nothing
                Else
                    trans.CommitTransaction()
                End If
            Else
                trans.RollbackTransaction()
                LogFile.LogENG.SaveErrLog("SpeedwayENG.SpeedwayUpdateCurrentLocation", fcLnq.ErrorMessage)
            End If
            fcLnq = Nothing


            ''ถ้า Reader ID เดิมเป็น Midrange
            'Dim IsMidrange As Boolean = False
            'Dim mrDt As DataTable = GlobalFunction.GetDatatable("select id from MS_MID_RANGE_READER where serial_no='" & cDt.DefaultView(0)("readerid") & "'")
            'If mrDt.Rows.Count > 0 Then
            '    IsMidrange = True
            'End If
            'mrDt.Dispose()

            ''และ Reader ID ใหม่ เป็น Speedway
            'Dim IsSpeedway As Boolean = False
            'Dim spDt As DataTable = GlobalFunction.GetDatatable("select id from MS_SPEEDWAY where readerid='" & ReaderID & "'")
            'If spDt.Rows.Count > 0 Then
            '    IsSpeedway = True
            'End If
            'spDt.Dispose()

            'ถ้าเป็นการเคลื่อนแฟ้มจาก Reader หนึ่ง ไปยัง Reader หนึ่ง
            cDt.DefaultView.RowFilter = "app_no='" & AppNo & "' and readerid = '" & ReaderID & "'"
            If cDt.DefaultView.Count = 0 Then
                IsInsertHistory = True
                'ElseIf IsMidrange = True And IsSpeedway = True Then
                '    IsInsertHistory = True
            End If
        Else
            'ถ้ายังอยู่ที่เดิม ให้เช็คว่า History สุดท้าย กับ Current Location ต้องเป็นที่เดียวกัน
            Dim hSql As String = "select max(id) max_id from TS_FILE_MOVE_HISTORY where app_no='" & AppNo & "'"
            Dim hDt As DataTable = GlobalFunction.GetDatatable(hSql)
            If hDt.Rows.Count > 0 Then
                Dim MaxHistory As Long = Convert.ToInt64(hDt.Rows(0)("max_id"))

                hSql = "select id,app_no, move_date,readerid,ant_port_number,ms_room_id, ms_grid_layout_id ,grid_row,grid_col"
                hSql += " from TS_FILE_MOVE_HISTORY "
                hSql += " where id= '" & MaxHistory & "'"
                hDt = GlobalFunction.GetDatatable(hSql)
                If hDt.Rows.Count > 0 Then
                    Dim hDr As DataRow = hDt.Rows(0)

                    hSql = "select fc.app_no, fc.readerid,fc.ant_port_number,fc.ms_room_id," & vbNewLine
                    hSql += " isnull(fg.ms_grid_layout_id,0) ms_grid_layout_id," & vbNewLine
                    hSql += " isnull(fg.grid_row,0) grid_row, isnull(fg.grid_col,0) grid_col" & vbNewLine
                    hSql += " from TS_FILE_CURRENT_LOCATION fc" & vbNewLine
                    hSql += " left join TS_FILE_CURRENT_GRID fg on fc.id=fg.ts_file_current_location_id " & vbNewLine
                    hSql += " where fc.app_no='" & AppNo & "'" & vbNewLine
                    hSql += " and fc.ms_room_id='" & hDr("ms_room_id") & "'"
                    'hSql += " and fc.ant_port_number='" & hDr("ant_port_number") & "'"
                    'hSql += " and isnull(fg.ms_grid_layout_id,0)='" & hDr("ms_grid_layout_id") & "'"
                    'hSql += " and isnull(fg.grid_row,0)='" & hDr("grid_row") & "'"
                    'hSql += " and isnull(fg.grid_col,0)='" & hDr("grid_col") & "'"

                    hDt = GlobalFunction.GetDatatable(hSql)
                    If hDt.Rows.Count = 0 Then
                        IsInsertHistory = True
                    End If
                Else
                    IsInsertHistory = True
                End If
            Else
                IsInsertHistory = True
            End If
            hDt.Dispose()
        End If

        If IsInsertHistory = True Then
            'Insert File Move History
            Dim hLnq As New TsFileMoveHistoryLinqDB
            hLnq.APP_NO = AppNo
            hLnq.MOVE_DATE = MoveDate
            hLnq.READERID = ReaderID
            hLnq.ANT_PORT_NUMBER = AntNo
            hLnq.RSSI = Rssi
            hLnq.LOCATION_NAME = LocationName
            hLnq.MS_ROOM_ID = MsRoomID
            hLnq.TB_OFFICER_ID = BorrowerID
            hLnq.OFFICER_NAME = BorrowerName
            hLnq.MS_DESKTOP_ID = DesktopID
            hLnq.DESK_NAME = DesktopName
            hLnq.MS_GRID_LAYOUT_ID = MsGridLayoutID
            hLnq.GRID_ROW = GridRow
            hLnq.GRID_COL = GridCol
            hLnq.IS_UPDATE_CURRENT_LOCATION = "Y"

            trans = New TransactionDB(SelectDB.DIPRFID)
            If hLnq.InsertData("SpeedwayENG.SpeedwayUpdateCurrentLocation", trans.Trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
            hLnq = Nothing
        End If
    End Sub

    'Private Shared Sub UpdateBorrowerToHistory(AppNo As String, BorrowerID As Long, BorrowerName As String, DesktopID As Long, Rssi As Integer, MsRoomID As Long, ReaderID As String, AntNo As Integer, LocationName As String)

    '    Dim uSql As String = "update TS_FILE_MOVE_HISTORY"
    '    uSql += " set tb_officer_id='" & BorrowerID & " ',"
    '    uSql += " officer_name = '" & BorrowerName & "', "
    '    uSql += " ms_desktop_id = '" & DesktopID & "', "
    '    uSql += " is_update_current_location ='Y'"
    '    uSql += " where app_no='" & AppNo & "'"
    '    uSql += " and rssi='" & Rssi & "'"
    '    uSql += " and ms_room_id='" & MsRoomID & "'"
    '    uSql += " and readerid = '" & ReaderID & "'"
    '    uSql += " and ant_port_number='" & AntNo & "'"
    '    uSql += " and location_name='" & LocationName & "'"

    '    Dim trans As New TransactionDB(SelectDB.DIPRFID)
    '    Dim lnq As New TsFileMoveHistoryLinqDB
    '    Dim re As Boolean = False
    '    re = lnq.UpdateBySql(uSql, trans.Trans)
    '    If re = True Then
    '        trans.CommitTransaction()
    '    Else
    '        trans.RollbackTransaction()
    '        LogFile.LogENG.SaveErrLog("SpeedwayENG.UpdateBorrowerToHistory", lnq.ErrorMessage)
    '    End If
    'End Sub

    Private Shared Function ImportTextFileToDB(LocalPath As String, PathFile As String, FileName As String, dr As DataRow, lnq As TsTempImportTextfileLinqDB) As Boolean
        Dim re As Boolean = True
        Try
            'Bulk Insert Data from Textfile to Temp Table
            Dim Sql As String = "BULK INSERT TMP_SPEEDWAY_TEXTFILE "
            Sql += " FROM '" & FileName & "' "
            Sql += " WITH (FIELDTERMINATOR = '|', ROWTERMINATOR = '" & Chr(10) & "')"

            'ถ้าไม่สำเร็จให้ทำซ้ำ 3 ครั้ง
            If Engine.GlobalFunction.ExecuteNonQuery(Sql, Nothing) = False Then
                If Engine.GlobalFunction.ExecuteNonQuery(Sql, Nothing) = False Then
                    If Engine.GlobalFunction.ExecuteNonQuery(Sql, Nothing) = False Then
                        LogFile.LogENG.SaveErrLog("SpeedwayENG.ConvertAndImportTextFileToDB", Sql & ":::File=" & FileName)
                        re = False
                    End If
                End If
            End If
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("SpeedwayENG.ConvertAndImportTextFileToDB", "1. Exception  : File=" & FileName & " ::: " & ex.Message & vbNewLine & ex.StackTrace)
            re = False
        End Try

        If re = True Then
            'Insert data from Temp to TS_FILE_MOVE_HISTORY
            Dim Location As String = dr("floor_name") & " " & dr("room_name")

            Dim TmpSql As String = " select 'SpeedwayENG.ImportTextFileToDB',getdate(),substring(tag_no,1,10) tag_no,max(move_date) move_date, "
            TmpSql += " '" & dr("ReaderID") & "',ant_no, avg(convert(float,rssi)) rssi, " & vbNewLine
            TmpSql += " '" & Location & "', '" & dr("ms_room_id") & "', grid_col,grid_row, REPLACE(ms_grid_layout_id,char(13),'') ms_grid_layout_id" & vbNewLine
            TmpSql += " from TMP_SPEEDWAY_TEXTFILE" & vbNewLine
            TmpSql += " where serial_no='" & dr("serial_no") & "'" & vbNewLine
            TmpSql += " group by substring(tag_no,1,10),ant_no,grid_col,grid_row, REPLACE(ms_grid_layout_id,char(13),'')"


            Dim iSql As String = "insert into TS_FILE_MOVE_HISTORY(created_by,created_date,app_no,move_date," & vbNewLine
            iSql += " ReaderID,ant_port_number,rssi,location_name,ms_room_id,grid_col,grid_row,ms_grid_layout_id)" & vbNewLine
            iSql += TmpSql

            re = Engine.GlobalFunction.ExecuteNonQuery(iSql, Nothing)
            If re = False Then
                re = Engine.GlobalFunction.ExecuteNonQuery(iSql, Nothing)
                If re = False Then
                    re = Engine.GlobalFunction.ExecuteNonQuery(iSql, Nothing)
                    If re = False Then
                        'trans.RollbackTransaction()
                        LogFile.LogENG.SaveErrLog("SpeedwayENG.ConvertAndImportTextFileToDB", iSql & ":::FilePath=" & PathFile)
                    End If
                End If
            End If

            'Update Current Location
            If re = True Then
                Dim tmpDt As DataTable = Engine.GlobalFunction.GetDatatable(TmpSql)
                If tmpDt.Rows.Count > 0 Then
                    For Each tmpDr As DataRow In tmpDt.Rows
                        Dim AppNo As String = tmpDr("tag_no")
                        Dim MoveDate As DateTime = GlobalFunction.cStrToDateTime(Split(tmpDr("move_date"), " ")(0), Split(tmpDr("move_date"), " ")(1))
                        Dim ReaderID As String = dr("ReaderID")
                        Dim Rssi As Double = Convert.ToDouble(tmpDr("rssi"))
                        Dim AntNo As Integer = Convert.ToInt32(tmpDr("ant_no"))
                        Dim RoomID As Long = Convert.ToInt64(dr("ms_room_id"))
                        Dim GridLayoutID As Long = Convert.ToInt64(tmpDr("ms_grid_layout_id"))
                        Dim GridCol As Integer = Convert.ToInt32(tmpDr("grid_col"))
                        Dim GridRow As Integer = Convert.ToInt32(tmpDr("grid_row"))


                        SpeedwayUpdateCurrentLocation(AppNo, MoveDate, ReaderID, Rssi, AntNo, RoomID, Location, GridLayoutID, GridRow, GridCol)
                    Next
                End If


                'Clear Temp Table
                Dim dSql As String = " delete from TMP_SPEEDWAY_TEXTFILE where serial_no='" & dr("serial_no") & "'"
                re = Engine.GlobalFunction.ExecuteNonQuery(dSql, Nothing)
                If re = False Then
                    re = Engine.GlobalFunction.ExecuteNonQuery(dSql, Nothing)
                    If re = False Then
                        re = Engine.GlobalFunction.ExecuteNonQuery(dSql, Nothing)
                        If re = False Then
                            'trans.RollbackTransaction()
                            LogFile.LogENG.SaveErrLog("SpeedwayENG.ConvertAndImportTextFileToDB", dSql & ":::FilePath=" & PathFile)
                        End If
                    End If
                End If

                If re = True Then
                    'Move Text file to Backup
                    Dim BackupFolder As String = LocalPath & "Backup\" & DateTime.Now.ToString("yyyyMMdd") & "\"
                    If IO.Directory.Exists(BackupFolder) = False Then
                        IO.Directory.CreateDirectory(BackupFolder)
                    End If

                    Dim fInfo As New IO.FileInfo(FileName)
                    Try
                        IO.File.Move(FileName, BackupFolder & DateTime.Now.ToString("HHmmss") & "_" & fInfo.Name)

                        Dim trans As New TransactionDB(SelectDB.DIPRFID)
                        lnq.IMPORT_STATUS = "3"
                        If lnq.UpdateByPK("SpeedwayENG.ImportTextFileToDB", trans.Trans) Then
                            trans.CommitTransaction()
                        Else
                            trans.RollbackTransaction()
                        End If
                    Catch ex As Exception
                        re = False
                    End Try
                    fInfo = Nothing
                End If
            End If
        End If

        Return re
    End Function

    Public Shared Sub ConvertAndImportTextFileToDB(LocalPath As String)
        Try
            'Convert Data From DB to Textfile
            Dim sql As String = "select tt.id, s.ReaderID, s.serial_no, tt.file_name, tt.file_byte," & vbNewLine
            sql += " f.floor_name, s.ms_room_id, r.room_name, tt.import_status" & vbNewLine
            sql += " from TS_TEMP_IMPORT_TEXTFILE tt" & vbNewLine
            sql += " inner join MS_SPEEDWAY s on s.id=tt.ms_speedway_id" & vbNewLine
            sql += " inner join MS_ROOM r on r.id=s.ms_room_id" & vbNewLine
            sql += " inner join MS_FLOOR f on f.id=r.ms_floor_id" & vbNewLine
            sql += " where  tt.file_byte is not null " & vbNewLine

            Dim dt As DataTable = GlobalFunction.GetDatatable(sql)

            dt.DefaultView.RowFilter = "import_status='1'"
            dt = dt.DefaultView.ToTable
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim lnq As New TsTempImportTextfileLinqDB
                    lnq.GetDataByPK(dr("id"), Nothing)
                    If lnq.ID > 0 Then
                        Dim SerialNo As String = Replace(lnq.SERIAL_NO, "-", "")

                        Dim PathFile As String = LocalPath & "ProcessPath\" & SerialNo
                        Dim fs As FileStream
                        If Directory.Exists(PathFile) = False Then
                            Directory.CreateDirectory(PathFile)
                        End If

                        Dim FileName As String = PathFile & "\" & lnq.FILE_NAME
                        Dim re As Boolean = True
                        Try
                            If File.Exists(FileName) = True Then
                                Try
                                    File.SetAttributes(FileName, FileAttributes.Normal)
                                    File.Delete(FileName)
                                Catch ex As Exception

                                End Try
                            End If

                            fs = New FileStream(FileName, FileMode.CreateNew)
                            fs.Write(lnq.FILE_BYTE, 0, lnq.FILE_BYTE.Length)
                            fs.Close()

                            lnq.FILE_BYTE = Nothing
                            lnq.IMPORT_STATUS = "2"

                            Dim trans As New TransactionDB(SelectDB.DIPRFID)
                            If lnq.UpdateByPK("SpeedwayENG.ConvertAndImportTextFileToDB", trans.Trans) = True Then
                                trans.CommitTransaction()

                                ImportTextFileToDB(LocalPath, PathFile, FileName, dr, lnq)
                            Else
                                trans.RollbackTransaction()
                            End If
                        Catch ex As Exception
                            re = False
                        End Try
                    End If    'lnq.ID > 0
                    lnq = Nothing
                Next
            Else
                dt.DefaultView.RowFilter = "import_status='2'"
                dt = dt.DefaultView.ToTable
                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows
                        Dim lnq As New TsTempImportTextfileLinqDB
                        lnq.GetDataByPK(dr("id"), Nothing)
                        If lnq.ID > 0 Then
                            Dim SerialNo As String = Replace(lnq.SERIAL_NO, "-", "")
                            Dim PathFile As String = LocalPath & SerialNo
                            Dim FileName As String = PathFile & "\" & lnq.FILE_NAME

                            ImportTextFileToDB(LocalPath, PathFile, FileName, dr, lnq)
                        End If
                        lnq = Nothing
                    Next
                End If
            End If
            dt.Dispose()

        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("SpeedwayENG.ConvertAndImportTextFileToDB", "3. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Shared Function InsertDataToFileMoveHistory(TxtData As String) As String
        Dim ret As String = "False"
        Try
            Dim txt() As String = Split(TxtData, "|")
            If txt.Length = 8 Then
                Dim SerialNo As String = txt(0)
                Dim TagNo As String = txt(1)
                If TagNo.Length > 10 Then
                    TagNo = TagNo.Substring(0, 10)
                End If
                Dim AntNo As Integer = Convert.ToInt32(txt(2))
                Dim Rssi As Double = Convert.ToDouble(txt(3))
                Dim MoveDate As DateTime = GlobalFunction.cStrToDateTime(Split(txt(4), " ")(0), Split(txt(4), " ")(1))
                Dim GridCol As Integer = Convert.ToInt32(txt(5))
                Dim GridRow As Integer = Convert.ToInt32(txt(6))
                Dim GridLayoutID As Long = Convert.ToInt64(txt(7))

                ret = "True"
            End If

        Catch ex As Exception
            ret = "False"
        End Try
        Return ret
    End Function

    'Private Shared Function ImportTextDataToDB(LocalPath As String, PathFile As String, FileName As String, dr As DataRow, lblCurrFile As Label, lblProcess As Label) As Boolean
    '    Dim re As Boolean = True

    '    'Insert data from Temp to TS_FILE_MOVE_HISTORY
    '    lblCurrFile.Text = FileName
    '    lblProcess.Text = "Insert data from Temp to TS_FILE_MOVE_HISTORY"

    '    Dim Location As String = dr("floor_name") & " " & dr("room_name")
    '    'Dim TmpSql As String = " select 'SpeedwayENG.ImportTextDataToDB',getdate(),substring(tag_no,1,10) tag_no,max(move_date) move_date, "
    '    'TmpSql += " '" & dr("ReaderID") & "',ant_no, avg(convert(float,rssi)) rssi, " & vbNewLine
    '    'TmpSql += " '" & Location & "', '" & dr("ms_room_id") & "', grid_col,grid_row, REPLACE(ms_grid_layout_id,char(13),'') ms_grid_layout_id,'Y'" & vbNewLine
    '    'TmpSql += " from TMP_SPEEDWAY_TEXTFILE" & vbNewLine
    '    'TmpSql += " where serial_no='" & dr("serial_no") & "'" & vbNewLine
    '    'TmpSql += " group by substring(tag_no,1,10),ant_no,grid_col,grid_row, REPLACE(ms_grid_layout_id,char(13),'')"

    '    Dim TmpSql As String = " select distinct 'SpeedwayENG.ImportTextDataToDB',getdate(),substring(a.tag_no,1,10) tag_no,st.move_date, " & vbNewLine
    '    TmpSql += " '" & dr("ReaderID") & "',st.ant_no,st.rssi, '" & Location & "', '" & dr("ms_room_id") & "'," & vbNewLine
    '    TmpSql += " st.grid_col, st.grid_row, REPLACE(st.ms_grid_layout_id,char(13),'') ms_grid_layout_id, 'Y'" & vbNewLine
    '    TmpSql += " from (" & vbNewLine
    '    TmpSql += " 	 select serial_no,tag_no, max(id) id" & vbNewLine
    '    TmpSql += "      from TMP_SPEEDWAY_TEXTFILE" & vbNewLine
    '    TmpSql += " 	 group by  serial_no,tag_no)  a" & vbNewLine
    '    TmpSql += " inner join TMP_SPEEDWAY_TEXTFILE st on a.tag_no=st.tag_no and a.id=st.id and a.serial_no=st.serial_no " & vbNewLine
    '    TmpSql += " where st.serial_no='" & dr("serial_no") & "'" & vbNewLine

    '    Dim iSql As String = "insert into TS_FILE_MOVE_HISTORY(created_by,created_date,app_no,move_date," & vbNewLine
    '    iSql += " ReaderID,ant_port_number,rssi,location_name,ms_room_id,grid_col,grid_row,ms_grid_layout_id,is_update_current_location)" & vbNewLine
    '    iSql += TmpSql

    '    re = Engine.GlobalFunction.ExecuteNonQuery(iSql, Nothing)
    '    If re = False Then
    '        re = Engine.GlobalFunction.ExecuteNonQuery(iSql, Nothing)
    '        If re = False Then
    '            re = Engine.GlobalFunction.ExecuteNonQuery(iSql, Nothing)
    '            If re = False Then
    '                'trans.RollbackTransaction()
    '                LogFile.LogENG.SaveErrLog("SpeedwayENG.ImportTextDataToDB", iSql & " :::FileName=" & FileName)
    '            End If
    '        End If
    '    End If

    '    lblCurrFile.Text = FileName
    '    lblProcess.Text = "Update Current Location"

    '    Dim tmpDt As DataTable
    '    tmpDt = GlobalFunction.GetDatatable(TmpSql)
    '    If tmpDt.Rows.Count = 0 Then
    '        tmpDt = GlobalFunction.GetDatatable(TmpSql)
    '        If tmpDt.Rows.Count = 0 Then
    '            tmpDt = GlobalFunction.GetDatatable(TmpSql)
    '        End If
    '    End If

    '    If tmpDt.Rows.Count > 0 Then
    '        For Each TmpDr As DataRow In tmpDt.Rows
    '            Dim AppNo As String = TmpDr("tag_no")
    '            Dim MoveDate As DateTime = GlobalFunction.cStrToDateTime(Split(TmpDr("move_date"), " ")(0), Split(TmpDr("move_date"), " ")(1))
    '            Dim ReaderID As String = dr("ReaderID")
    '            Dim Rssi As Double = Convert.ToDouble(TmpDr("rssi"))
    '            Dim AntNo As Integer = Convert.ToInt32(TmpDr("ant_no"))
    '            Dim RoomID As Long = Convert.ToInt64(dr("ms_room_id"))
    '            Dim GridLayoutID As Long = Convert.ToInt64(TmpDr("ms_grid_layout_id"))
    '            Dim GridCol As Integer = Convert.ToInt32(TmpDr("grid_col"))
    '            Dim GridRow As Integer = Convert.ToInt32(TmpDr("grid_row"))

    '            'Update Current Location
    '            SpeedwayUpdateCurrentLocation(AppNo, MoveDate, ReaderID, Rssi, AntNo, RoomID, Location, GridLayoutID, GridRow, GridCol)

    '            'Dim lnq As New TsFileMoveHistoryLinqDB
    '            'lnq.APP_NO = AppNo
    '            'lnq.MOVE_DATE = MoveDate
    '            'lnq.READERID = ReaderID
    '            'lnq.RSSI = Rssi
    '            'lnq.ANT_PORT_NUMBER = AntNo
    '            'lnq.MS_ROOM_ID = RoomID
    '            'lnq.MS_GRID_LAYOUT_ID = GridLayoutID
    '            'lnq.GRID_COL = GridCol
    '            'lnq.GRID_ROW = GridRow
    '            'lnq.IS_UPDATE_CURRENT_LOCATION = "Y"

    '            'Dim trans As New TransactionDB(SelectDB.DIPRFID)
    '            'If lnq.InsertData("SpeedwayENG.ImportTextDataToDB", trans.Trans) = True Then
    '            '    trans.CommitTransaction()
    '            'Else
    '            '    trans.RollbackTransaction()

    '            '    LogFile.LogENG.SaveErrLog("SpeedwayENG.ImportTextDataToDB", "Insert TsFileMoveHistoryLinqDB Error : " & lnq.ErrorMessage & " :::FileName=" & FileName)
    '            'End If
    '        Next
    '    End If
    '    tmpDt.Dispose()


    '    'Clear Temp Table
    '    lblCurrFile.Text = FileName
    '    lblProcess.Text = "Clear Table TMP_SPEEDWAY_TEXTFILE"

    '    Dim dSql As String = " truncate table TMP_SPEEDWAY_TEXTFILE"
    '    re = Engine.GlobalFunction.ExecuteNonQuery(dSql, Nothing)
    '    If re = False Then
    '        re = Engine.GlobalFunction.ExecuteNonQuery(dSql, Nothing)
    '        If re = False Then
    '            re = Engine.GlobalFunction.ExecuteNonQuery(dSql, Nothing)
    '            If re = False Then
    '                'trans.RollbackTransaction()
    '                LogFile.LogENG.SaveErrLog("SpeedwayENG.ImportTextDataToDB", "Error Cler Temp Table" & dSql & ":::FilePath=" & PathFile)
    '            End If
    '        End If
    '    End If

    '    Return re
    'End Function


    Public Shared Function ImportTextDataToDB(FileName As String, lblCurrFile As Label, lblProcess As Label) As Boolean
        Dim re As Boolean = True

        ''Insert data from Temp to TS_FILE_MOVE_HISTORY
        'lblCurrFile.Text = FileName
        'lblProcess.Text = "Insert data from Temp to TS_FILE_MOVE_HISTORY"
        'Application.DoEvents()

        Dim TmpSql As String = " select distinct 'SpeedwayENG.ImportTextDataToDB',getdate(),substring(a.tag_no,1,10) tag_no,st.move_date, "
        TmpSql += " s.ReaderID,st.ant_no,st.rssi, s.install_position location,s.ms_room_id,"
        TmpSql += " st.grid_col, st.grid_row, REPLACE(st.ms_grid_layout_id,char(13),'') ms_grid_layout_id, 'Y'"
        TmpSql += " from ("
        TmpSql += "     select serial_no,tag_no, max(id) id"
        TmpSql += "     from TMP_SPEEDWAY_TEXTFILE"
        TmpSql += "     group by  serial_no,tag_no)  a"
        TmpSql += " inner join TMP_SPEEDWAY_TEXTFILE st on a.tag_no=st.tag_no and a.id=st.id and a.serial_no=st.serial_no "
        TmpSql += " inner join MS_SPEEDWAY s on st.serial_no=s.serial_no"
        TmpSql += " inner join MS_ROOM r on r.id=s.ms_room_id"
        TmpSql += " inner join MS_FLOOR fl on fl.id=r.ms_floor_id" & vbNewLine

        'Dim iSql As String = "insert into TS_FILE_MOVE_HISTORY(created_by,created_date,app_no,move_date," & vbNewLine
        'iSql += " ReaderID,ant_port_number,rssi,location_name,ms_room_id,grid_col,grid_row,ms_grid_layout_id,is_update_current_location)" & vbNewLine
        'iSql += TmpSql

        're = Engine.GlobalFunction.ExecuteNonQuery(iSql, Nothing)
        'If re = False Then
        '    re = Engine.GlobalFunction.ExecuteNonQuery(iSql, Nothing)
        '    If re = False Then
        '        re = Engine.GlobalFunction.ExecuteNonQuery(iSql, Nothing)
        '        If re = False Then
        '            'trans.RollbackTransaction()
        '            LogFile.LogENG.SaveErrLog("SpeedwayENG.ImportTextDataToDB", iSql & " :::FileName=" & FileName)
        '        End If
        '    End If
        'End If

        lblCurrFile.Text = FileName
        lblProcess.Text = "Update Current Location"
        Application.DoEvents()

        Dim tmpDt As DataTable
        tmpDt = GlobalFunction.GetDatatable(TmpSql)
        If tmpDt.Rows.Count = 0 Then
            tmpDt = GlobalFunction.GetDatatable(TmpSql)
            If tmpDt.Rows.Count = 0 Then
                tmpDt = GlobalFunction.GetDatatable(TmpSql)
            End If
        End If

        If tmpDt.Rows.Count > 0 Then
            For i As Long = 0 To tmpDt.Rows.Count - 1
                Try
                    Dim TmpDr As DataRow = tmpDt.Rows(i)
                    Dim AppNo As String = TmpDr("tag_no")
                    Dim MoveDate As DateTime = GlobalFunction.cStrToDateTime(Split(TmpDr("move_date"), " ")(0), Split(TmpDr("move_date"), " ")(1))
                    Dim ReaderID As String = TmpDr("ReaderID")
                    Dim Rssi As Double = Convert.ToDouble(TmpDr("rssi"))
                    Dim AntNo As Integer = Convert.ToInt32(TmpDr("ant_no"))
                    Dim RoomID As Long = Convert.ToInt64(TmpDr("ms_room_id"))
                    Dim GridLayoutID As Long = Convert.ToInt64(TmpDr("ms_grid_layout_id"))
                    Dim GridCol As Integer = Convert.ToInt32(TmpDr("grid_col"))
                    Dim GridRow As Integer = Convert.ToInt32(TmpDr("grid_row"))

                    ''Update Current Location
                    'SpeedwayUpdateCurrentLocation(AppNo, MoveDate, ReaderID, Rssi, AntNo, RoomID, TmpDr("location"), GridLayoutID, GridRow, GridCol)


                    'หา แฟ้มทั้งหมดที่อยู่ในใบยืมเดียวกัน
                    Dim sql As String = " select fb.app_no, f.send_time " & vbNewLine
                    sql += " from TMP_FILEBORROWITEM fb" & vbNewLine
                    sql += " inner join TB_FILEBORROWITEM fi on fi.id=fb.fileborrowitem_id" & vbNewLine
                    sql += " inner join TB_FILEBORROW f on f.id=fi.fileborrow_id " & vbNewLine
                    sql += " where fileborrowitem_id <> 0" & vbNewLine
                    sql += " and fi.fileborrow_id in (select fbi.fileborrow_id " & vbNewLine
                    sql += "                            from TMP_FILEBORROWITEM tf " & vbNewLine
                    sql += "                            inner join TB_FILEBORROWITEM fbi on fbi.id=tf.fileborrowitem_id" & vbNewLine
                    sql += "                            where tf.app_no= '" & AppNo & "')" & vbNewLine

                    Dim tDt As DataTable = GlobalFunction.GetDatatable(sql)
                    If tDt.Rows.Count > 0 Then
                        For Each tDr As DataRow In tDt.Rows
                            If Convert.IsDBNull(tDr("send_time")) = False Then
                                'ถ้าเป็นแฟ้มที่รับแล้ว ต้องเช็คว่าเป็น Tag เดียวกันหรือไม่
                                If tDr("app_no").ToString = AppNo Then
                                    SpeedwayUpdateCurrentLocation(AppNo, MoveDate, ReaderID, Rssi, AntNo, RoomID, TmpDr("location"), GridLayoutID, GridRow, GridCol)
                                End If
                            Else
                                'ถ้าเป็นแฟ้มในใบยืมที่ยังไม่รับ ให้ Update Location ทั้งหมด
                                SpeedwayUpdateCurrentLocation(AppNo, MoveDate, ReaderID, Rssi, AntNo, RoomID, TmpDr("location"), GridLayoutID, GridRow, GridCol)
                            End If
                        Next
                    Else
                        'Update Current Location
                        SpeedwayUpdateCurrentLocation(AppNo, MoveDate, ReaderID, Rssi, AntNo, RoomID, TmpDr("location"), GridLayoutID, GridRow, GridCol)
                    End If
                    tDt.Dispose()

                    lblProcess.Text = "Update Current Location Current Row " & (i + 1) & " Total Rows " & tmpDt.Rows.Count
                    Application.DoEvents()
                Catch ex As Exception

                End Try
            Next
        End If
        tmpDt.Dispose()

        'Clear Temp Table
        lblCurrFile.Text = FileName
        lblProcess.Text = "Clear Table TMP_SPEEDWAY_TEXTFILE"
        Application.DoEvents()

        Dim dSql As String = " truncate table TMP_SPEEDWAY_TEXTFILE"
        re = Engine.GlobalFunction.ExecuteNonQuery(dSql, Nothing)
        If re = False Then
            re = Engine.GlobalFunction.ExecuteNonQuery(dSql, Nothing)
            If re = False Then
                re = Engine.GlobalFunction.ExecuteNonQuery(dSql, Nothing)
                If re = False Then
                    'trans.RollbackTransaction()
                    LogFile.LogENG.SaveErrLog("SpeedwayENG.ImportTextDataToDB", "Error Cler Temp Table" & dSql & ":::FilePath=" & FileName)
                End If
            End If
        End If

        Return re
    End Function
    Public Shared Sub MergeDataTextFile(MergeFile As String, ContentFile As String)
        If File.Exists(ContentFile) = True Then
            File.AppendAllText(MergeFile, File.ReadAllText(ContentFile), Encoding.Default) 'The text file will be created if it does not already exist   
        End If
    End Sub

    'Public Shared Sub ImportTextfileToDB(LocalPath As String, lblCurrFile As Label, lblProcess As Label)
    '    Dim dt As DataTable = GetTracingSpeedwayList()
    '    If dt.Rows.Count > 0 Then
    '        Dim vDateNow As DateTime = GlobalFunction.GetDateNowFromDB
    '        Dim DatePath As String = vDateNow.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

    '        For Each dr As DataRow In dt.Rows
    '            Dim SerialNo As String = Replace(dr("serial_no"), "-", "")
    '            Dim ProcessPath As String = LocalPath & "ProcessPath\"
    '            Dim CopyPath As String = LocalPath & "CopyPath\"
    '            Try
    '                If Directory.Exists(ProcessPath & SerialNo) = False Then
    '                    Directory.CreateDirectory(ProcessPath & SerialNo)
    '                End If
    '            Catch ex As Exception

    '            End Try

    '            If Directory.Exists(CopyPath & SerialNo) = True Then
    '                For Each f As String In Directory.GetFiles(CopyPath & SerialNo, "*.txt", SearchOption.AllDirectories)
    '                    lblCurrFile.Text = f
    '                    lblProcess.Text = "Copy File from " & CopyPath & SerialNo & " to " & ProcessPath & SerialNo
    '                    Application.DoEvents()

    '                    'Move File จาก CopyPath ไปใส่ใน Process Path ก่อน
    '                    Dim fInfo As New FileInfo(f)

    '                    Try
    '                        File.SetAttributes(f, FileAttributes.Normal)
    '                        File.Move(f, ProcessPath & SerialNo & "\" & fInfo.Name)
    '                    Catch ex As Exception

    '                    End Try
    '                Next
    '            End If
    '        Next

    '        For Each dr As DataRow In dt.Rows
    '            Dim SerialNo As String = Replace(dr("serial_no"), "-", "")
    '            Dim ProcessPath As String = LocalPath & "ProcessPath\"
    '            'Dim CopyPath As String = LocalPath & "CopyPath\"

    '            For Each f As String In Directory.GetFiles(ProcessPath & SerialNo, "*.txt", SearchOption.AllDirectories)
    '                Dim fInfo As New FileInfo(f)
    '                Try
    '                    lblCurrFile.Text = f
    '                    lblProcess.Text = "Create " & ProcessPath & "SPEEDWAY_PROCESS_FILE.txt"
    '                    Application.DoEvents()

    '                    'Copy มาแล้วให้รวมไฟล์เป็น ProcessPath\SPEEDWAY_PROCESS_FILE.txt
    '                    If File.Exists(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt") = True Then
    '                        Try
    '                            File.SetAttributes(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt", FileAttributes.Normal)
    '                            File.Delete(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt")
    '                        Catch ex As Exception

    '                        End Try
    '                    End If

    '                    File.Copy(f, ProcessPath & "SPEEDWAY_PROCESS_FILE.txt")
    '                    Threading.Thread.Sleep(2000)

    '                    'Execute SSIS เพื่อ Import ข้อมูลลง Temp Table TMP_SPEEDWAY_TEXTFILE
    '                    lblCurrFile.Text = f
    '                    lblProcess.Text = "Execute SSIS"

    '                    Dim pCmd As String = "C:\Program Files\Microsoft SQL Server\110\DTS\Binn\dtexec.exe "
    '                    Dim args As String = " /SQL ""\""\ImportSpeedwayTextDataToDB\"""" /SERVER ""\""10.10.18.88\"""" /USER sa /PASSWORD 1qaz@WSX /CHECKPOINTING OFF  /REPORTING EW"
    '                    Dim proc As New ProcessStartInfo(pCmd, args)
    '                    Dim pr As Process = Process.Start(proc)
    '                    pr.WaitForExit()


    '                    'Move Log file ไปไว้ที่ Backup เลย
    '                    lblCurrFile.Text = f
    '                    lblProcess.Text = "Move File to  Backup Folder"

    '                    Dim BackupFolder As String = LocalPath & "Backup\" & DateTime.Now.ToString("yyyyMM") & "\" & DateTime.Now.ToString("yyyyMMdd") & "\"
    '                    If IO.Directory.Exists(BackupFolder) = False Then
    '                        IO.Directory.CreateDirectory(BackupFolder)
    '                    End If
    '                    Try
    '                        IO.File.Move(f, BackupFolder & DateTime.Now.ToString("HHmmss") & "_" & fInfo.Name)
    '                    Catch ex As Exception

    '                    End Try
    '                    fInfo = Nothing


    '                    'ใช้ ฟังก์ชั่นของ Import Textfile Data From Speedway เพื่อ Insert ข้อมูลลง TS_FILE_MOVE_HISTORY
    '                    'ใช้ ฟังก์ชั่นของ Import Textfile Data From Speedway เพื่อ UPDATE ข้อมูลลง TS_FILE_CURRENT_LOCATION และ TS_FILE_CURRENT_GRID

    '                    lblCurrFile.Text = f
    '                    lblProcess.Text = "Import Text Data To DB"

    '                    Dim PathFile As String = LocalPath & SerialNo
    '                    ImportTextDataToDB(LocalPath, PathFile, f, dr, lblCurrFile, lblProcess)

    '                    lblCurrFile.Text = f
    '                    lblProcess.Text = "Complete Import Data from Textfile"
    '                Catch ex As Exception
    '                    LogFile.LogENG.SaveErrLog("SpeedwayENG.CopyTextFileFromSpeedway", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
    '                End Try
    '            Next
    '        Next
    '    End If
    'End Sub


    Public Shared Sub ImportTextfileToDB(LocalPath As String, lblCurrFile As Label, lblProcess As Label)
        Dim dt As DataTable = GetTracingSpeedwayList()
        If dt.Rows.Count > 0 Then
            Dim vDateNow As DateTime = GlobalFunction.GetDateNowFromDB
            Dim DatePath As String = vDateNow.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
            Dim ProcessPath As String = LocalPath & "ProcessPath\"
            Dim CopyPath As String = LocalPath & "CopyPath\"

            For Each dr As DataRow In dt.Rows
                Dim SerialNo As String = Replace(dr("serial_no"), "-", "")
                Try
                    If Directory.Exists(ProcessPath & SerialNo) = False Then
                        Directory.CreateDirectory(ProcessPath & SerialNo)
                    End If
                Catch ex As Exception

                End Try

                If Directory.Exists(CopyPath & SerialNo) = True Then
                    For Each f As String In Directory.GetFiles(CopyPath & SerialNo, "*.txt", SearchOption.AllDirectories)
                        lblCurrFile.Text = f
                        lblProcess.Text = "Copy File from " & CopyPath & SerialNo & " to " & ProcessPath & SerialNo
                        Application.DoEvents()

                        'Move File จาก CopyPath ไปใส่ใน Process Path ก่อน
                        Dim fInfo As New FileInfo(f)

                        Try
                            File.SetAttributes(f, FileAttributes.Normal)
                            File.Move(f, ProcessPath & SerialNo & "\" & fInfo.Name)
                        Catch ex As Exception

                        End Try
                    Next
                End If
            Next

            lblProcess.Text = "Delete " & ProcessPath & "SPEEDWAY_PROCESS_FILE.txt"
            Application.DoEvents()
            'Copy มาแล้วให้รวมไฟล์เป็น ProcessPath\SPEEDWAY_PROCESS_FILE.txt
            If File.Exists(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt") = True Then
                Try
                    File.SetAttributes(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt", FileAttributes.Normal)
                    File.Delete(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt")
                Catch ex As Exception

                End Try
            End If

            For Each dr As DataRow In dt.Rows
                Dim SerialNo As String = Replace(dr("serial_no"), "-", "")
                'Meage Text File ทุกไฟล์จาก Speedway to SPEEDWAY_PROCESS_FILE.txt
                For Each f As String In Directory.GetFiles(ProcessPath & SerialNo, "*.txt", SearchOption.AllDirectories)
                    Dim fInfo As New FileInfo(f)
                    Try
                        lblCurrFile.Text = f
                        lblProcess.Text = "Meage Text File ทุกไฟล์จาก Speedway to SPEEDWAY_PROCESS_FILE.txt"

                        MergeDataTextFile(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt", f)

                        'Move Log file ไปไว้ที่ Backup เลย
                        Dim BackupFolder As String = LocalPath & "Backup\" & DateTime.Now.ToString("yyyyMM") & "\" & DateTime.Now.ToString("yyyyMMdd") & "\"
                        If IO.Directory.Exists(BackupFolder) = False Then
                            IO.Directory.CreateDirectory(BackupFolder)
                        End If
                        Try
                            IO.File.Move(f, BackupFolder & DateTime.Now.ToString("HHmmss") & "_" & fInfo.Name)
                        Catch ex As Exception

                        End Try
                        fInfo = Nothing
                    Catch ex As Exception
                        LogFile.LogENG.SaveErrLog("SpeedwayENG.CopyTextFileFromSpeedway", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            Next

            If File.Exists(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt") = True Then
                System.Threading.Thread.Sleep(3000)
                'Execute SSIS เพื่อ Import ข้อมูลลง Temp Table TMP_SPEEDWAY_TEXTFILE
                lblCurrFile.Text = ProcessPath & "SPEEDWAY_PROCESS_FILE.txt"
                lblProcess.Text = "Execute SSIS"

                Dim pCmd As String = "C:\Program Files\Microsoft SQL Server\110\DTS\Binn\dtexec.exe "
                Dim args As String = " /SQL ""\""\ImportDataTextFileFromSpeedway\"""" /SERVER ""\""10.10.18.88\"""" /USER sa /PASSWORD 1qaz@WSX /CHECKPOINTING OFF  /REPORTING EW"
                Dim proc As New ProcessStartInfo(pCmd, args)
                Dim pr As Process = Process.Start(proc)
                pr.WaitForExit()

                'ใช้ ฟังก์ชั่นของ Import Textfile Data From Speedway เพื่อ Insert ข้อมูลลง TS_FILE_MOVE_HISTORY
                'ใช้ ฟังก์ชั่นของ Import Textfile Data From Speedway เพื่อ UPDATE ข้อมูลลง TS_FILE_CURRENT_LOCATION และ TS_FILE_CURRENT_GRID
                lblCurrFile.Text = ProcessPath & "SPEEDWAY_PROCESS_FILE.txt"
                lblProcess.Text = "Import Text Data To DB"

                'Dim PathFile As String = LocalPath & SerialNo
                ImportTextDataToDB(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt", lblCurrFile, lblProcess)

            End If
        End If
    End Sub

    Public Shared Sub CopyTextFileFromSpeedway(LocalPath As String)
        Try
            Dim dt As DataTable = GetTracingSpeedwayList()
            If dt.Rows.Count > 0 Then

                Dim vDateNow As DateTime = GlobalFunction.GetDateNowFromDB
                Dim DatePath As String = vDateNow.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))
                For Each dr As DataRow In dt.Rows
                    Try
                        If Convert.IsDBNull(dr("ftp_user")) = False Then
                            Dim IPAddress As String = dr("ip_address")
                            Dim ftpUser As String = dr("ftp_user")
                            Dim ftpPwd As String = LinqDB.ConnectDB.SqlDB.DeCripPwd(dr("ftp_pwd"))
                            Dim ftpPort As Integer = dr("ftp_port")
                            Dim ftpPath As String = dr("ftp_data_path")
                            Dim SerialNo As String = Replace(dr("serial_no"), "-", "")

                            Dim t As New Thread(Sub() GetTextFileFromSpeedway(IPAddress, ftpUser, ftpPwd, ftpPort, ftpPath, LocalPath, DatePath, SerialNo))
                            t.Start()

                            'GetTextFileFromSpeedway(IPAddress, ftpUser, ftpPwd, ftpPort, ftpPath, LocalPath, DatePath, SerialNo)
                        End If
                    Catch ex As Exception
                        LogFile.LogENG.SaveErrLog("SpeedwayENG.CopyTextFileFromSpeedway", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("SpeedwayENG.CopyTextFileFromSpeedway", "3. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

#End Region


#Region "Update Config Schedule "
    Private Shared Function GetConfigScheduleList(ScheduleDate As String) As DataTable
        'ScheduleDate Format  yyyyMMdd
        Dim ret As New DataTable
        Try
            Dim lnq As New CfSpeedwayLinqDB
            Dim sql As String = "select id, serial_no"
            sql += " from CF_SPEEDWAY "
            sql += " where  convert(varchar(8),schedule_date,112)='" & ScheduleDate & "'"
            sql += " and is_send_speedway='N' and is_update_setting='N'"
            sql += " and active_status='Y'"

            ret = lnq.GetListBySql(sql, Nothing)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Private Shared Function UpdateSendSpeedwayStatus(UserName As String, cfID As Long) As String
        Dim ret As String = "False"
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim lnq As New CfSpeedwayLinqDB
            lnq.GetDataByPK(cfID, trans.Trans)

            If lnq.ID > 0 Then
                lnq.IS_SEND_SPEEDWAY = "Y"
                ret = lnq.UpdateByPK(UserName, trans.Trans)
                If ret = "True" Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = "False"
            LogFile.LogENG.SaveErrLog("SpeedwayENG.UpdateSendSpeedwayStatus", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Sub UpdateConfigSchedule(UserName As String, ScheduleDate As String)
        Try
            Dim dt As DataTable = GetConfigScheduleList(ScheduleDate)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim re As String = UpdateSpeedwayConfig(UserName, dr("id"))
                    If re = "True" Then
                        Dim SerialNo As String = Replace(dr("serial_no"), "-", "")
                        Dim SettingPath As String = Application.StartupPath & "\Setting\" & SerialNo
                        If IO.Directory.Exists(SettingPath) = False Then
                            IO.Directory.CreateDirectory(SettingPath)
                        End If

                        Dim RemSettingFile As String = "TheSettings.xml"
                        Dim RemTriggerFile As String = "TheTriggerSettings.txt"

                        Dim SettingFile As String = SettingPath & "\" & RemSettingFile
                        Dim TriggerFile As String = SettingPath & "\" & RemTriggerFile
                        'TheSettings.xml
                        'TheTriggerSettings.txt

                        IO.File.WriteAllText(SettingFile, GetSpeedwaySettingXML(UserName, dr("serial_no")))
                        IO.File.WriteAllText(TriggerFile, "1")

                        If FTPFileSettingToSpeedway(UserName, dr("id"), SettingFile, TriggerFile, RemSettingFile, RemTriggerFile) = "True" Then
                            UpdateSendSpeedwayStatus(UserName, dr("id"))
                        End If
                    End If
                Next
            End If
            dt.Dispose()
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("SpeedwayENG.UpdateConfigSchedule", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Shared Function FTPFileSettingToSpeedway(UserName As String, cfID As Long, SettingFile As String, TriggerFile As String, RemSettingFile As String, RemTriggerFile As String) As String
        Dim ret As String = "False"
        Try
            Dim lnq As New CfSpeedwayLinqDB
            lnq.GetDataByPK(cfID, Nothing)
            If lnq.ID > 0 Then
                Dim ftpUser As String = lnq.FTP_USER
                Dim ftpPwd As String = LinqDB.ConnectDB.SqlDB.DeCripPwd(lnq.FTP_PWD)
                Dim ftpPort As Integer = lnq.FTP_PORT
                Dim ftpPath As String = lnq.FTP_PATH

                Using ftp As New FTPSClient
                    Try
                        Dim cld As New System.Net.NetworkCredential(ftpUser, ftpPwd)
                        Try
                            ret = ftp.Connect(lnq.IP_ADDRESS, ftpPort, cld, AlexPilotti.FTPS.Client.ESSLSupportMode.ClearText, _
                            New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate), _
                            New System.Security.Cryptography.X509Certificates.X509Certificate(), 0, 0, 0, 10000, False, EDataConnectionMode.Active)
                            ret = "True"
                        Catch ex As Exception
                            LogFile.LogENG.SaveErrLog("SpeedwayENG.FTPFileSettingToSpeedway", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                            ret = "False"
                        End Try

                        If ret = "True" Then
                            ftp.SetCurrentDirectory(ftpPath)
                            ftp.PutFile(SettingFile, RemSettingFile)
                            ftp.PutFile(TriggerFile, RemTriggerFile)
                            ret = "True"
                        End If
                    Catch ex As Exception
                        LogFile.LogENG.SaveErrLog("SpeedwayENG.FTPFileSettingToSpeedway", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                        ret = "False"
                    End Try
                End Using
            Else
                ret = "False"
                LogFile.LogENG.SaveErrLog("SpeedwayENG.FTPFileSettingToSpeedway", lnq.ErrorMessage)
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = "False"
            LogFile.LogENG.SaveErrLog("SpeedwayENG.FTPFileSettingToSpeedway", "3. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Public Shared Function FTPFileTracingToSpeedway(UserName As String, IPAddress As String, ftpUser As String, ftpPwd As String, ftpPort As Integer, ftpPath As String, TracingFile As String, RemTracingFile As String) As String
        Dim ret As String = "False"
        Try
            Using ftp As New FTPSClient
                Try
                    Dim cld As New System.Net.NetworkCredential(ftpUser, ftpPwd)
                    Try
                        ftp.Connect(IPAddress, ftpPort, cld, AlexPilotti.FTPS.Client.ESSLSupportMode.ClearText, _
                        New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate), _
                        New System.Security.Cryptography.X509Certificates.X509Certificate(), 0, 0, 0, 10000, False, EDataConnectionMode.Active)
                        ret = "True"
                    Catch ex As Exception
                        ret = "False"
                        LogFile.LogENG.SaveErrLog("SpeedwayENG.FTPFileTracingToSpeedway", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If ret = "True" Then
                        ftp.SetCurrentDirectory(ftpPath)
                        ftp.PutFile(TracingFile, RemTracingFile)
                        ret = "True"
                    End If
                Catch ex As Exception
                    ret = "False"
                    LogFile.LogENG.SaveErrLog("SpeedwayENG.FTPFileTracingToSpeedway", "2. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End Using
        Catch ex As Exception
            ret = "False"
            LogFile.LogENG.SaveErrLog("SpeedwayENG.FTPFileTracingToSpeedway", "3. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function


#Region "Update Config Data to MS_SPEEDWAY"
    Private Shared Function UpdateSpeedwayConfig(UserName As String, CfSpeedwayID As Long) As String
        Dim ret As String = "False"
        Try
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Dim lnq As New CfSpeedwayLinqDB
            lnq.GetDataByPK(CfSpeedwayID, trans.Trans)
            If lnq.ID > 0 Then
                Dim msLnq As MsSpeedwayLinqDB = SetSpeedway(UserName, lnq.MS_SPEEDWAY_ID, lnq, trans)
                If msLnq.HaveData.ToString = "True" Then
                    Dim MsSpeedwaySettingID As Long = SetSpeedwaySetting(UserName, msLnq.ID, CfSpeedwayID, trans)
                    If MsSpeedwaySettingID > 0 Then
                        ret = SetSpeedwayAnt(UserName, msLnq.ID, CfSpeedwayID, trans)
                        If ret = "True" Then
                            ret = SetSpeedwayGPI(UserName, msLnq.ID, CfSpeedwayID, trans)
                            If ret = "True" Then
                                ret = SetSpeedwaySettingFilter(UserName, MsSpeedwaySettingID, CfSpeedwayID, trans)
                                If ret = "True" Then
                                    ret = SetSpeedwayReport(UserName, MsSpeedwaySettingID, CfSpeedwayID, trans)
                                    If ret = "True" Then
                                        ret = SetSpeedwayLowDutyCycle(UserName, MsSpeedwaySettingID, CfSpeedwayID, trans)
                                        If ret = "True" Then
                                            trans.CommitTransaction()
                                        Else
                                            trans.RollbackTransaction()
                                        End If
                                    Else
                                        trans.RollbackTransaction()
                                    End If
                                Else
                                    trans.RollbackTransaction()
                                End If
                            Else
                                trans.RollbackTransaction()
                            End If
                        Else
                            trans.RollbackTransaction()
                        End If
                    Else
                        ret = "False"
                        trans.RollbackTransaction()
                    End If
                Else
                    trans.RollbackTransaction()
                    msLnq = Nothing
                End If
            Else
                trans.RollbackTransaction()
                ret = "False|" & lnq.ErrorMessage
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = "False|Exception " & ex.Message & vbNewLine & ex.StackTrace
            LogFile.LogENG.SaveErrLog("SpeedwayENG.UpdateSpeedwayConfig", "1. Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function

    Private Shared Function SetSpeedway(UserName As String, MsSpeedwayID As Long, CfLnq As CfSpeedwayLinqDB, trans As TransactionDB) As MsSpeedwayLinqDB
        Dim lnq As New MsSpeedwayLinqDB
        Dim IsUpdateMsSpeedwayID As Boolean = False
        Try
            If MsSpeedwayID > 0 Then
                lnq.GetDataByPK(MsSpeedwayID, trans.Trans)
            End If
            If lnq.ID = 0 Then
                lnq.ChkDataBySERIAL_NO(CfLnq.SERIAL_NO, trans.Trans)
            End If

            If CfLnq.MS_SPEEDWAY_ID = 0 Then
                lnq.READERID = GetMaxReaderID(trans)
                IsUpdateMsSpeedwayID = True
            Else
                lnq.READERID = CfLnq.READERID
            End If
            lnq.SERIAL_NO = CfLnq.SERIAL_NO
            lnq.IP_ADDRESS = CfLnq.IP_ADDRESS
            lnq.INSTALL_POSITION = CfLnq.INSTALL_POSITION
            lnq.MS_ROOM_ID = CfLnq.MS_ROOM_ID
            lnq.MS_SPEEDWAY_OBJECTIVE_ID = CfLnq.MS_SPEEDWAY_OBJECTIVE_ID
            lnq.ANT_QTY = CfLnq.ANT_QTY
            lnq.GPI_QTY = CfLnq.GPI_QTY
            lnq.ACTIVE_STATUS = CfLnq.ACTIVE_STATUS
            lnq.FTP_USER = CfLnq.FTP_USER
            lnq.FTP_PWD = CfLnq.FTP_PWD
            lnq.FTP_PORT = CfLnq.FTP_PORT
            lnq.FTP_PATH = CfLnq.FTP_PATH
            lnq.FTP_DATA_PATH = CfLnq.FTP_DATA_PATH
            lnq.BRAND_NAME = CfLnq.BRAND_NAME
            lnq.MODEL_NAME = CfLnq.MODEL_NAME

            Dim ret As String = "False"
            If lnq.ID > 0 Then
                ret = lnq.UpdateByPK(UserName, trans.Trans)
            Else
                ret = lnq.InsertData(UserName, trans.Trans)
            End If

            If ret = "False" Then
                ret = "False|" & lnq.ErrorMessage
            Else
                If IsUpdateMsSpeedwayID = True Then
                    CfLnq.MS_SPEEDWAY_ID = lnq.ID
                    CfLnq.READERID = lnq.READERID

                    ret = CfLnq.UpdateByPK(UserName, trans.Trans)
                    If ret = "False" Then
                        ret = "False|" & CfLnq.ErrorMessage
                    End If
                End If
            End If
        Catch ex As Exception
            'ret = "False|Exception " & ex.Message & vbNewLine & ex.StackTrace
            LogFile.LogENG.SaveErrLog("SpeedwayENG.SetSpeedway", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return lnq
    End Function
    Private Shared Function SetSpeedwayAnt(UserName As String, MsSpeedwayID As Long, CfSpeedwayID As Long, trans As TransactionDB) As String
        Dim ret As String = "False"
        Try
            Dim cfLnq As New CfSpeedwayAntLinqDB
            Dim cfDt As DataTable = cfLnq.GetDataList("cf_speedway_id='" & CfSpeedwayID & "'", "port_number", trans.Trans)
            If cfDt.Rows.Count > 0 Then
                Dim msLnq As New MsSpeedwayAntLinqDB
                Dim msDt As DataTable = msLnq.GetDataList("ms_speedway_id='" & MsSpeedwayID & "'", "port_number", trans.Trans)
                For Each cfDr As DataRow In cfDt.Rows
                    Dim lnq As New MsSpeedwayAntLinqDB

                    msDt.DefaultView.RowFilter = "port_number='" & cfDr("port_number") & "'"
                    If msDt.DefaultView.Count > 0 Then
                        lnq.GetDataByPK(msDt.DefaultView(0)("id"), trans.Trans)
                    End If

                    lnq.MS_SPEEDWAY_ID = MsSpeedwayID
                    lnq.PORT_NUMBER = cfDr("port_number")
                    lnq.IS_ENABLED = cfDr("is_enabled")
                    lnq.TX_POWER_IN_DBM = cfDr("tx_power_in_dbm")
                    lnq.RX_SENSITIVITY_IN_DBM = cfDr("rx_sensitivity_in_dbm")
                    lnq.BRAND_NAME = cfDr("brand_name")
                    lnq.MODEL_NAME = cfDr("model_name")

                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK(UserName, trans.Trans)
                    Else
                        ret = lnq.InsertData(UserName, trans.Trans)
                    End If

                    If ret = "False" Then
                        ret = "False|" & lnq.ErrorMessage
                        Exit For
                    End If
                    lnq = Nothing
                    msDt.DefaultView.RowFilter = ""
                Next
                msDt.Dispose()
            Else
                ret = "True"
            End If
            cfDt.Dispose()
        Catch ex As Exception
            ret = "False|Exception " & ex.Message & vbNewLine & ex.StackTrace
            LogFile.LogENG.SaveErrLog("SpeedwayENG.SetSpeedwayAnt", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
    Private Shared Function SetSpeedwayGPI(UserName As String, MsSpeedwayID As Long, CfSpeedwayID As Long, trans As TransactionDB) As String
        Dim ret As String = "False"
        Try
            Dim cfLnq As New CfSpeedwayGpiLinqDB
            Dim cfDt As DataTable = cfLnq.GetDataList("cf_speedway_id='" & CfSpeedwayID & "'", "port_number", trans.Trans)
            If cfDt.Rows.Count > 0 Then
                Dim msLnq As New MsSpeedwayGpiLinqDB
                Dim msDt As DataTable = msLnq.GetDataList("ms_speedway_id='" & MsSpeedwayID & "'", "port_number", trans.Trans)
                For Each cfDr As DataRow In cfDt.Rows
                    Dim lnq As New MsSpeedwayGpiLinqDB

                    msDt.DefaultView.RowFilter = "port_number='" & cfDr("port_number") & "'"
                    If msDt.DefaultView.Count > 0 Then
                        lnq.GetDataByPK(msDt.DefaultView(0)("id"), trans.Trans)
                    End If

                    lnq.MS_SPEEDWAY_ID = MsSpeedwayID
                    lnq.PORT_NUMBER = cfDr("port_number")
                    lnq.IS_ENABLED = cfDr("is_enabled")
                    lnq.DEBOUNCE_IN_MS = cfDr("debounce_in_ms")
                    lnq.AUTO_START_MODE = cfDr("auto_start_mode")
                    lnq.AUTO_START_GPI_LEVEL = cfDr("auto_start_gpi_level")
                    lnq.AUTO_START_FIRST_DELAY = Convert.ToInt64(cfDr("auto_start_first_delay"))
                    lnq.AUTO_START_PERIOD = Convert.ToInt64(cfDr("auto_start_period"))
                    lnq.AUTO_STOP_MODE = cfDr("auto_stop_mode")
                    lnq.AUTO_STOP_GPI_LEVEL = cfDr("auto_stop_gpi_level")
                    lnq.AUTO_STOP_DURATION = Convert.ToInt64(cfDr("auto_stop_duration"))
                    lnq.BRAND_NAME = cfDr("brand_name")
                    lnq.MODEL_NAME = cfDr("model_name")

                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK(UserName, trans.Trans)
                    Else
                        ret = lnq.InsertData(UserName, trans.Trans)
                    End If

                    If ret = "False" Then
                        ret = "False|" & lnq.ErrorMessage
                        Exit For
                    End If
                Next
                msDt.Dispose()
            Else
                ret = "True"
            End If
            cfDt.Dispose()
        Catch ex As Exception
            ret = "False|Exception " & ex.Message & vbNewLine & ex.StackTrace
            LogFile.LogENG.SaveErrLog("SpeedwayENG.SetSpeedwayGPI", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
    Private Shared Function SetSpeedwaySetting(UserName As String, MsSpeedwayID As Long, CfSpeedwayID As Long, trans As TransactionDB) As Long
        Dim ret As Long = 0
        Try
            Dim lnq As New CfSpeedwaySettingLinqDB
            lnq.ChkDataByCF_SPEEDWAY_ID(CfSpeedwayID, trans.Trans)
            If lnq.ID > 0 Then
                Dim msLnq As New MsSpeedwaySettingLinqDB
                msLnq.ChkDataByMS_SPEEDWAY_ID(MsSpeedwayID, trans.Trans)

                msLnq.MS_SPEEDWAY_ID = MsSpeedwayID
                msLnq.SETTING_LABEL = lnq.SETTING_LABEL
                msLnq.SETTING_DESCRIPTION = lnq.SETTING_DESCRIPTION
                msLnq.SETTING_SEARCH_MODE = lnq.SETTING_SEARCH_MODE
                msLnq.SETTING_SESSION = lnq.SETTING_SESSION
                msLnq.SETTING_TAG_POPULATE_ESTIMATE = lnq.SETTING_TAG_POPULATE_ESTIMATE
                msLnq.SETTING_TIME_CORRECT_ENABLED = lnq.SETTING_TIME_CORRECT_ENABLED
                msLnq.FILTERS_MODE = lnq.FILTERS_MODE
                msLnq.KEEPALIVE_IS_ENABLED = lnq.KEEPALIVE_IS_ENABLED
                msLnq.KEEPALIVE_PERIOD_IN_MS = lnq.KEEPALIVE_PERIOD_IN_MS
                msLnq.KEEPALIVE_LINK_DOWN_THRESHOLD = lnq.KEEPALIVE_LINK_DOWN_THRESHOLD

                Dim re As String = "False"
                If msLnq.ID > 0 Then
                    re = msLnq.UpdateByPK(UserName, trans.Trans).ToString
                Else
                    re = msLnq.InsertData(UserName, trans.Trans).ToString
                End If

                If re = "False" Then
                    ret = 0
                Else
                    ret = msLnq.ID
                End If
            Else
                ret = 0
            End If
        Catch ex As Exception
            'ret = "False|Exception " & ex.Message & vbNewLine & ex.StackTrace
            ret = 0
            LogFile.LogENG.SaveErrLog("SpeedwayENG.SetSpeedwaySetting", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
    Private Shared Function SetSpeedwaySettingFilter(UserName As String, MsSpeedwaySettingID As Long, CfSpeedwayID As Long, trans As TransactionDB) As String
        Dim ret As String = "False"
        Try
            Dim cfLnq As New CfSpeedwaySettingFilterLinqDB
            Dim cfSql As String = " select ssf.id, ssf.cf_speedway_setting_id, ssf.tag_filter_no, ssf.memory_bank, " & vbNewLine
            cfSql += " ssf.bit_pointer, ssf.bit_count, ssf.tag_mask, ssf.filter_op" & vbNewLine
            cfSql += " from CF_SPEEDWAY_SETTING_FILTER ssf " & vbNewLine
            cfSql += " inner join CF_SPEEDWAY_SETTING ss on ss.id=ssf.cf_speedway_setting_id " & vbNewLine
            cfSql += " where ss.cf_speedway_id='" & CfSpeedwayID & "'" & vbNewLine
            Dim cfDt As DataTable = cfLnq.GetListBySql(cfSql, trans.Trans)
            If cfDt.Rows.Count > 0 Then
                Dim msLnq As New MsSpeedwaySettingFilterLinqDB
                Dim msDt As DataTable = msLnq.GetDataList("ms_speedway_setting_id='" & MsSpeedwaySettingID & "'", "", trans.Trans)

                For Each cfDr As DataRow In cfDt.Rows
                    Dim lnq As New MsSpeedwaySettingFilterLinqDB

                    msDt.DefaultView.RowFilter = "tag_filter_no='" & cfDr("tag_filter_no") & "'"
                    If msDt.DefaultView.Count > 0 Then
                        lnq.GetDataByPK(msDt.DefaultView(0)("id"), trans.Trans)
                    End If

                    lnq.MS_SPEEDWAY_SETTING_ID = MsSpeedwaySettingID
                    lnq.TAG_FILTER_NO = cfDr("tag_filter_no")
                    lnq.MEMORY_BANK = cfDr("memory_bank")
                    lnq.BIT_POINTER = cfDr("bit_pointer")
                    lnq.BIT_COUNT = cfDr("bit_count")
                    If Convert.IsDBNull(cfDr("tag_mask")) = False Then lnq.TAG_MASK = cfDr("tag_mask")
                    lnq.FILTER_OP = cfDr("filter_op")

                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK(UserName, trans.Trans)
                    Else
                        ret = lnq.InsertData(UserName, trans.Trans)
                    End If

                    If ret = "False" Then
                        ret = "False|" & lnq.ErrorMessage
                        Exit For
                    End If
                    lnq = Nothing
                Next
                msDt.Dispose()
            Else
                ret = "True"
            End If
            cfDt.Dispose()
        Catch ex As Exception
            ret = "False|Exception " & ex.Message & vbNewLine & ex.StackTrace
            LogFile.LogENG.SaveErrLog("SpeedwayENG.SetSpeedwaySettingFilter", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
    Public Shared Function SetSpeedwayReport(UserName As String, MsSpeedwaySettingID As Long, CfSpeedwayID As Long, trans As TransactionDB) As String
        Dim ret As String = "False"
        Try
            Dim cfLnq As New CfSpeedwayReportLinqDB
            Dim cfSql As String = "select sr.cf_speedway_setting_id, sr.report_mode, sr.include_peak_rssi, sr.include_antenna_port_number,"
            cfSql += " sr.include_first_seen_time, sr.include_last_seen_time, sr.include_seen_count, sr.include_channel, "
            cfSql += " sr.include_phase_angle, sr.include_serialized_tid "
            cfSql += " from CF_SPEEDWAY_REPORT sr"
            cfSql += " inner join CF_SPEEDWAY_SETTING ss on ss.id=sr.cf_speedway_setting_id"
            cfSql += " where ss.cf_speedway_id='" & CfSpeedwayID & "'"
            Dim cfDt As DataTable = cfLnq.GetListBySql(cfSql, trans.Trans)
            If cfDt.Rows.Count > 0 Then
                Dim msLnq As New MsSpeedwayReportLinqDB
                Dim msDt As DataTable = msLnq.GetDataList("ms_speedway_setting_id='" & MsSpeedwaySettingID & "'", "", trans.Trans)

                For Each cfDr As DataRow In cfDt.Rows
                    Dim lnq As New MsSpeedwayReportLinqDB
                    If msDt.Rows.Count > 0 Then
                        lnq.GetDataByPK(msDt.Rows(0)("id"), trans.Trans)
                    End If


                    lnq.MS_SPEEDWAY_SETTING_ID = MsSpeedwaySettingID
                    lnq.REPORT_MODE = cfDr("report_mode")
                    lnq.INCLUDE_PEAK_RSSI = cfDr("include_peak_rssi")
                    lnq.INCLUDE_ANTENNA_PORT_NUMBER = cfDr("include_antenna_port_number")
                    lnq.INCLUDE_FIRST_SEEN_TIME = cfDr("include_first_seen_time")
                    lnq.INCLUDE_LAST_SEEN_TIME = cfDr("include_last_seen_time")
                    lnq.INCLUDE_SEEN_COUNT = cfDr("include_seen_count")
                    lnq.INCLUDE_CHANNEL = cfDr("include_channel")
                    lnq.INCLUDE_PHASE_ANGLE = cfDr("include_phase_angle")
                    lnq.INCLUDE_SERIALIZED_TID = cfDr("include_serialized_tid")

                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK(UserName, trans.Trans)
                    Else
                        ret = lnq.InsertData(UserName, trans.Trans)
                    End If

                    If ret = "False" Then
                        ret = "False|" & lnq.ErrorMessage
                        Exit For
                    End If
                    lnq = Nothing
                Next
                msLnq = Nothing
                msDt.Dispose()
            End If
            cfDt.Dispose()
            cfLnq = Nothing
        Catch ex As Exception
            ret = "False|Exception " & ex.Message & vbNewLine & ex.StackTrace
            LogFile.LogENG.SaveErrLog("SpeedwayENG.SetSpeedwayReport", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
    Public Shared Function SetSpeedwayLowDutyCycle(UserName As String, MsSpeedwaySettingID As Long, CfSpeedwayID As Long, trans As TransactionDB) As String
        Dim ret As String = "False"
        Try
            Dim cfLnq As New CfSpeedwayReportLinqDB
            Dim cfSql As String = "select ld.cf_speedway_setting_id, ld.is_enabled, ld.field_ping_interval_in_ms,ld.emptry_field_timeout_in_ms"
            cfSql += " from CF_SPEEDWAY_LOW_DUTY_CYCLE ld"
            cfSql += " inner join CF_SPEEDWAY_SETTING ss on ss.id=ld.cf_speedway_setting_id"
            cfSql += " where ss.cf_speedway_id='" & CfSpeedwayID & "'"
            Dim cfDt As DataTable = cfLnq.GetListBySql(cfSql, trans.Trans)
            If cfDt.Rows.Count > 0 Then
                Dim msLnq As New MsSpeedwayReportLinqDB
                Dim msDt As DataTable = msLnq.GetDataList("ms_speedway_setting_id='" & MsSpeedwaySettingID & "'", "", trans.Trans)

                For Each cfDr As DataRow In cfDt.Rows
                    Dim lnq As New MsSpeedwayLowDutyCycleLinqDB
                    lnq.GetDataByPK(msDt.Rows(0)("id"), trans.Trans)

                    lnq.MS_SPEEDWAY_SETTING_ID = MsSpeedwaySettingID
                    lnq.IS_ENABLED = cfDr("is_enabled")
                    lnq.FIELD_PING_INTERVAL_IN_MS = cfDr("field_ping_interval_in_ms")
                    lnq.EMPTRY_FIELD_TIMEOUT_IN_MS = cfDr("emptry_field_timeout_in_ms")

                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK(UserName, trans.Trans)
                    Else
                        ret = lnq.InsertData(UserName, trans.Trans)
                    End If

                    If ret = "False" Then
                        ret = "False|" & lnq.ErrorMessage
                        Exit For
                    End If
                    lnq = Nothing
                Next

                msLnq = Nothing
                msDt.Dispose()
            End If
            cfDt.Dispose()
            cfLnq = Nothing
        Catch ex As Exception
            ret = "False|Exception " & ex.Message & vbNewLine & ex.StackTrace
            LogFile.LogENG.SaveErrLog("SpeedwayENG.SetSpeedwayLowDutyCycle", "Exception : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ret
    End Function
#End Region
#End Region
End Class



