Imports System.Windows.Forms
Imports LinqDB.TABLE
Imports LinqDB.ConnectDB
Imports System.Threading
Imports System.Text
Imports System.Drawing

Public Class FileLocationENG
    'Private Shared Function SaveFileCurrentLocation(UserName As String, TagNo As String, MoveDate As DateTime, ReaderID As String, AntNo As Int16, rssi As Integer, LocationName As String, MsRoomID As Long, GridX As Long, GridY As Long, LayoutID As Long) As String
    '    Dim ret As String = "False"
    '    If (GridX + GridY) > 0 And LayoutID > 0 Then
    '        ret = SaveFileCurrentGrid(UserName, TagNo, MoveDate, ReaderID, AntNo, rssi, LocationName, MsRoomID, LayoutID, GridX, GridY)
    '    Else
    '        Dim trans As New TransactionDB(SelectDB.DIPRFID)
    '        Dim lnq As TsFileCurrentLocationLinqDB = SaveFileCurrentLocation(UserName, TagNo, MoveDate, ReaderID, AntNo, rssi, LocationName, MsRoomID, BorrowerID, BorrowerName, DesktopID, DesktopName, trans)
    '        ret = lnq.HaveData.ToString
    '        If ret = "True" Then
    '            trans.CommitTransaction()
    '        Else
    '            trans.RollbackTransaction()
    '        End If
    '        lnq = Nothing
    '    End If
    '    Return ret
    'End Function

    Private Shared FileCurrentLocationID As Long = 0
    Private Shared Function SaveFileCurrentLocation(UserName As String, TagNo As String, MoveDate As DateTime, ReaderID As String, AntNo As Int16, rssi As Integer, LocationName As String, MsRoomID As Long, tbOfficeID As Long, OfficerName As String, MsDesktopID As Long, DeskName As String, trans As TransactionDB, cDt As DataTable) As String
        Dim ret As String = "False"
        Dim lnq As New TsFileCurrentLocationLinqDB
        Try
            lnq.ChkDataByAPP_NO(TagNo.Trim, trans.Trans)

            lnq.APP_NO = TagNo.Trim
            lnq.MOVE_DATE = MoveDate
            lnq.READERID = ReaderID
            lnq.ANT_PORT_NUMBER = AntNo
            lnq.RSSI = rssi
            lnq.LOCATION_NAME = LocationName
            lnq.MS_ROOM_ID = MsRoomID
            lnq.MS_DESKTOP_ID = MsDesktopID
            lnq.TB_OFFICER_ID = tbOfficeID
            lnq.OFFICER_NAME = OfficerName
            lnq.DESK_NAME = DeskName

            If lnq.ID > 0 Then
                ret = lnq.UpdateByPK(UserName, trans.Trans)
            Else
                ret = lnq.InsertData(UserName, trans.Trans)
            End If

            If ret = "True" Then
                FileCurrentLocationID = lnq.ID

                'ถ้าข้อมูลใหม่เป็น MsRoomID เดิม ก็ไม่ต้อง Insert  ลง History
                cDt.DefaultView.RowFilter = "app_no='" & TagNo & "' and ms_room_id='" & MsRoomID & "'"
                If cDt.DefaultView.Count = 0 Then
                    SpeedwaySaveFileHistory(UserName, TagNo, MoveDate, ReaderID, AntNo, rssi, LocationName, MsRoomID, 0, 0, 0)
                End If
            Else
                ret = "False|" & lnq.ErrorMessage
            End If
        Catch ex As Exception
            ret = "False|Exception FileLocationENG.SaveFileCurrentLocation " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function

    'Public Shared Sub SpeedwayUpdateCurrentLocation()
    '    Try
    '        'LogFile.LogENG.CreateTransLogFile("Start SpeedwayUpdateCurrentLocation")
    '        Dim spDt As DataTable = SpeedwayENG.GetTracingSpeedwayList()
    '        If spDt.Rows.Count > 0 Then
    '            For Each spDr As DataRow In spDt.Rows
    '                ''LogFile.LogENG.CreateTransLogFile("Before Start Thread SpeedwayUpdateCurrentLocation " & spDr("ip_address"))
    '                Dim t As New Thread(Sub() SpeedwayUpdateCurrentLocation(spDr("ReaderID")))
    '                t.Start()


    '                'SpeedwayUpdateCurrentLocation(spDr("ReaderID"))
    '            Next
    '        End If
    '        spDt.Dispose()
    '    Catch ex As Exception
    '        LogFile.LogENG.SaveErrLog("FileLocationENG.SpeedwayUpdateCurrentLocation", ex.Message & vbNewLine & ex.StackTrace)
    '    End Try
    'End Sub


    'Private Shared Sub SpeedwayUpdateCurrentLocation(ReaderID As String)
    '    Try
    '        'LogFile.LogENG.CreateTransLogFile("Thread SpeedwayUpdateCurrentLocation " & ReaderID)
    '        Dim dt As New DataTable
    '        Dim lnq As New TsFileMoveHistoryLinqDB

    '        Dim sql As String = "select max(id) id,max(move_date) move_date,app_no,rssi,count(id) qty,"
    '        sql += " ms_room_id, ReaderID, ant_port_number, location_name"
    '        sql += " from TS_FILE_MOVE_HISTORY"
    '        sql += " where is_update_current_location='N'"
    '        sql += " and ReaderID = '" & ReaderID & "'"
    '        sql += " group by app_no, rssi,ms_room_id, readerid,ant_port_number,location_name"
    '        sql += " order by app_no,max(move_date)"

    '        dt = lnq.GetListBySql(sql, Nothing)
    '        If dt.Rows.Count > 0 Then
    '            For Each dr As DataRow In dt.Rows
    '                lnq.GetDataByPK(dr("id"), Nothing)
    '                If lnq.ID > 0 Then

    '                End If
    '            Next
    '        End If
    '        dt.Dispose()
    '        lnq = Nothing
    '    Catch ex As Exception
    '        LogFile.LogENG.SaveErrLog("FileLocationENG.SpeedwayUpdateCurrentLocation", "ReaderID=" & ReaderID & " " & ex.Message & vbNewLine & ex.StackTrace)
    '    End Try
    'End Sub

    Public Shared Function SpeedwaySaveFileHistory(UserName As String, TagNo As String, MoveDate As DateTime, ReaderID As String, AntNo As Int16, rssi As Integer, LocationName As String, MsRoomID As Long, GridX As Long, GridY As Long, LayoutID As Long) As String
        Dim ret As String = "False"
        Try
            Dim lnq As New TsFileMoveHistoryLinqDB
            lnq.APP_NO = TagNo
            lnq.MOVE_DATE = MoveDate
            lnq.READERID = ReaderID
            lnq.ANT_PORT_NUMBER = AntNo
            lnq.RSSI = rssi
            lnq.LOCATION_NAME = LocationName
            lnq.MS_ROOM_ID = MsRoomID
            lnq.GRID_COL = GridX
            lnq.GRID_ROW = GridY
            lnq.MS_GRID_LAYOUT_ID = LayoutID
            lnq.IS_UPDATE_CURRENT_LOCATION = "Y"
            'lnq.TB_OFFICER_ID = BorrowerID
            'lnq.OFFICER_NAME = BorrowerName
            'lnq.MS_DESKTOP_ID = DesktopID
            'lnq.DESK_NAME = DesktopName

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            ret = lnq.InsertData(UserName, trans.Trans).ToString
            If ret = "False" Then
                'ถ้า Insert ไม่ได้ให้ Retry 5 ครั้งโลด
                If lnq.InsertData(UserName, trans.Trans).ToString = "False" Then
                    If lnq.InsertData(UserName, trans.Trans).ToString = "False" Then
                        If lnq.InsertData(UserName, trans.Trans).ToString = "False" Then
                            If lnq.InsertData(UserName, trans.Trans).ToString = "False" Then
                                trans.RollbackTransaction()
                                ret = ret & "|FileLocationENG.SpeedwaySaveFileHistory " & lnq.ErrorMessage
                            Else
                                trans.CommitTransaction()
                            End If
                        Else
                            trans.CommitTransaction()
                        End If
                    Else
                        trans.CommitTransaction()
                    End If
                Else
                    trans.CommitTransaction()
                End If
            Else
                trans.CommitTransaction()
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = "False|Exception FileLocationENG.SpeedwaySaveFileHistory : " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function

    Public Shared Function MidRangeSaveFileHistory(UserName As String, TagNo As String, MoveDate As DateTime, ReaderID As String, AntNo As Int16, rssi As Double, LocationName As String, MsRoomID As Long) As String
        Dim ret As String = "False"
        Try
            Dim lnq As New TsFileMoveHistoryLinqDB
            lnq.APP_NO = TagNo
            lnq.MOVE_DATE = MoveDate
            lnq.READERID = ReaderID
            lnq.ANT_PORT_NUMBER = AntNo
            lnq.RSSI = rssi
            lnq.LOCATION_NAME = LocationName
            lnq.MS_ROOM_ID = MsRoomID
            lnq.IS_UPDATE_CURRENT_LOCATION = "Y"   'ถ้าตัว Mid Range ไม่ต้องระบุว่าเป็นโต๊ะทำงานของใคร

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            ret = lnq.InsertData(UserName, trans.Trans).ToString
            If ret = "False" Then
                trans.RollbackTransaction()
                ret = ret & "|" & lnq.ErrorMessage
            Else
                ret = SpeedwayENG.MidrangeUpdateCurrentLocation(TagNo, MoveDate, ReaderID, LocationName, MsRoomID, trans)
                If ret = "True" Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = "False|Exception : " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function


    Public Shared Function GetFileBorrowData(TagNo As String, MoveDate As DateTime) As DataTable
        Dim ret As New DataTable
        Try
            Dim vMoveDate As String = MoveDate.ToString("yyyy-MM-dd HH:mm:ss", New Globalization.CultureInfo("en-US"))

            Dim sql As String = "select fi.borrower_id, fi.borrower_name borrowername"
            sql += " from TMP_FILEBORROWITEM fi"
            sql += " where fi.app_no = '" & TagNo & "'"
            sql += " and convert(varchar(19),fi.borrowdate,120) <= '" & vMoveDate & "'"

            Dim lnq As New TmpFileborrowitemLinqDB
            ret = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetOfficerDesktop(OfficerId As Long, msRoomID As Long) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = " select id, desk_name "
            sql += " from ms_desktop"
            sql += " where ms_room_id='" & msRoomID & "'"
            sql += " and tb_officer_id='" & OfficerId & "'"

            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function SaveFileCurrentGrid(UserName As String, TagNo As String, MoveDate As DateTime, ReaderID As String, AntNo As Int16, rssi As Integer, LocationName As String, MsRoomID As Long, MsGridLayoutID As Long, GridCol As Integer, GridRow As Integer) As String
        Dim ret As String = "False"


        'ถ้าเป็นรายการที่มาจาก ReaderID เดิม Ant เดิม LayoutID เดิม GridRow เดิม GridColumn เดิม ก็ไม่ต้อง Update Current Location
        Dim cSql As String = "select fc.app_no, fc.readerid,fc.ant_port_number,fc.ms_room_id," & vbNewLine
        cSql += " isnull(fg.ms_grid_layout_id,0) ms_grid_layout_id," & vbNewLine
        cSql += " isnull(fg.grid_row,0) grid_row, isnull(fg.grid_col,0) grid_col" & vbNewLine
        cSql += " from TS_FILE_CURRENT_LOCATION fc" & vbNewLine
        cSql += " left join TS_FILE_CURRENT_GRID fg on fc.id=fg.ts_file_current_location_id " & vbNewLine
        cSql += " where fc.app_no='" & TagNo & "'" & vbNewLine

        Dim cDt As DataTable = GlobalFunction.GetDatatable(cSql)
        cDt.DefaultView.RowFilter = "app_no='" & TagNo & "' and readerid='" & ReaderID & "' and ant_port_number='" & AntNo & "' and ms_grid_layout_id='" & MsGridLayoutID & "' and grid_row='" & GridRow & "' and grid_col='" & GridCol & "'"

        If cDt.DefaultView.Count = 0 Then
            Try
                Dim BorrowerID As Long = 0
                Dim BorrowerName As String = ""

                Dim DesktopID As Long = 0
                Dim DesktopName As String = ""

                Dim bDt As DataTable = GetFileBorrowData(TagNo, MoveDate)
                If bDt.Rows.Count > 0 Then
                    BorrowerID = bDt.Rows(0)("borrower_id")
                    BorrowerName = bDt.Rows(0)("borrowername")

                    If MsGridLayoutID > 0 Then
                        Dim dDt As DataTable = GetOfficerDesktop(BorrowerID, MsRoomID)
                        If dDt.Rows.Count > 0 Then
                            DesktopID = dDt.Rows(0)("id")
                            DesktopName = dDt.Rows(0)("desk_name")
                        End If
                        dDt.Dispose()
                    End If
                End If
                bDt.Dispose()


                Dim trans As New TransactionDB(SelectDB.DIPRFID)
                ret = SaveFileCurrentLocation(UserName, TagNo, MoveDate, ReaderID, AntNo, rssi, LocationName, MsRoomID, BorrowerID, BorrowerName, DesktopID, DesktopName, trans, cDt)
                If ret = "True" Then
                    Dim lnq As New TsFileCurrentGridLinqDB
                    lnq.ChkDataByMS_GRID_LAYOUT_ID_TS_FILE_CURRENT_LOCATION_ID(MsGridLayoutID, FileCurrentLocationID, trans.Trans)

                    lnq.TS_FILE_CURRENT_LOCATION_ID = FileCurrentLocationID
                    lnq.MS_GRID_LAYOUT_ID = MsGridLayoutID
                    lnq.GRID_COL = GridCol
                    lnq.GRID_ROW = GridRow

                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK(UserName, trans.Trans)
                    Else
                        ret = lnq.InsertData(UserName, trans.Trans)
                    End If
                    lnq = Nothing

                    If ret = "True" Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        LogFile.LogENG.SaveErrLog(UserName, "FileLocationENG.SaveFileCurrentGrid : " & lnq.ErrorMessage)
                        ret = "False|" & lnq.ErrorMessage
                    End If
                Else
                    trans.RollbackTransaction()
                    LogFile.LogENG.SaveErrLog(UserName, "FileLocationENG.SaveFileCurrentGrid : " & ret)
                End If
            Catch ex As Exception
                LogFile.LogENG.SaveErrLog(UserName, "Excetion FileLocationENG.SaveFileCurrentGrid : " & ex.Message & vbNewLine & ex.StackTrace)
                ret = "False|" & "Excetion FileLocationENG.SaveFileCurrentGrid : " & ex.Message & vbNewLine & ex.StackTrace
            End Try
        Else
            ret = True
        End If

        Return ret
    End Function


#Region "Tracing Document"
    Public Shared Sub TracingDocumentData()
        Try
            Dim dt As DataTable
            Dim lnq As New TmpDocTracingLinqDB
            dt = lnq.GetDataList("tracing_status='1'", "tracing_start_time", Nothing)
            TransferTracingFileToSpeedway(dt, lnq, "2", "TagNo")
            dt.Dispose()
            lnq = Nothing
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("FileLocationENG.TracingDocumentData", "Excetion : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Shared Sub ClearTrackingDocumentData(TimeMinute As Int16)
        Try
            Dim ClearStatus As String = "3"
            Dim lnq As New TmpDocTracingLinqDB
            Dim dt As DataTable = lnq.GetDataList("dateadd(minute," & TimeMinute & ",tracing_start_time)<getdate() and tracing_status<>'" & ClearStatus & "'", "tracing_start_time", Nothing)
            TransferTracingFileToSpeedway(dt, lnq, ClearStatus, "")

            dt.Dispose()
            lnq = Nothing
        Catch ex As Exception
            LogFile.LogENG.SaveErrLog("FileLocationENG.ClearTrackingDocumentData", "Excetion : " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Shared Sub TransferTracingFileToSpeedway(dt As DataTable, lnq As TmpDocTracingLinqDB, TracingStatus As String, TextData As String)
        If dt.Rows.Count = 0 Then
            'ถ้าไม่พบข้อมูล
            dt.Dispose()
            lnq = Nothing
            Exit Sub
        End If
        Dim spDt As DataTable = SpeedwayENG.GetTracingSpeedwayList()
        If spDt.Rows.Count = 0 Then
            'ถ้าไม่มี Speedway
            spDt.Dispose()
            dt.Dispose()
            lnq = Nothing
            Exit Sub
        End If

        Dim TracingPath As String = Application.StartupPath & "\Tracing\"
        If IO.Directory.Exists(TracingPath) = False Then
            IO.Directory.CreateDirectory(TracingPath)
        End If

        Dim TempData As String = ""
        Dim TracingFile As String = "TrackNo.txt"
        If TextData.Trim <> "" Then
            For Each dr As DataRow In dt.Rows
                If TempData.Trim = "" Then
                    TempData = dr("tag_no")
                Else
                    TempData += vbNewLine & dr("tag_no")
                End If
            Next
        Else
            TempData = ""
        End If
        IO.File.WriteAllText(TracingPath & TracingFile, TempData)

        Dim ret As String = "False"
        If IO.File.Exists(TracingPath & TracingFile) = True Then
            For Each spDr As DataRow In spDt.Rows
                Dim spIP As String = spDr("ip_address")
                Dim ftpUser As String = spDr("ftp_user")
                Dim ftpPwd As String = LinqDB.ConnectDB.SqlDB.DeCripPwd(spDr("ftp_pwd"))
                Dim ftpPort As Integer = Convert.ToInt32(spDr("ftp_port"))
                Dim ftpPath As String = spDr("ftp_path")

                Dim t As New Thread(Sub() SpeedwayENG.FTPFileTracingToSpeedway("FileLocationENG.TracingDocumentData", spIP, ftpUser, ftpPwd, ftpPort, ftpPath, TracingPath & TracingFile, TracingFile))
                t.Start()
                ret = "True"

                'SpeedwayENG.FTPFileTracingToSpeedway("FileLocationENG.TracingDocumentData", spIP, ftpUser, ftpPwd, ftpPort, ftpPath, TracingPath & TracingFile, TracingFile)
                'ret = "True"

                'If SpeedwayENG.FTPFileTracingToSpeedway("FileLocationENG.TracingDocumentData", spIP, ftpUser, ftpPwd, ftpPort, ftpPath, TracingPath & TracingFile, TracingFile) = "False" Then
                '    ret = "False"
                '    Exit For
                'Else
                '    ret = "True"
                'End If
            Next
        End If
        spDt.Dispose()


        If ret = "True" Then
            For Each dr As DataRow In dt.Rows
                Dim trans As New TransactionDB(SelectDB.DIPRFID)
                lnq.GetDataByPK(dr("id"), trans.Trans)

                lnq.TRACING_STATUS = TracingStatus

                If lnq.UpdateByPK("FileLocationENG.TracingDocumentData", trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Next
        End If


    End Sub

    Public Shared Function GetTagNoByAppNo(AppNo As String) As String
        Dim ret As String = ""
        Try
            Dim sql As String = "select rt.tag_no"
            sql += " from TS_REQUISITION_TAG rt"
            sql += " inner join TB_REQUISTION r on r.id=rt.tb_requisition_id"
            sql += " where r.app_no='" & AppNo & "'"

            Dim dt As DataTable = GlobalFunction.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("tag_no")
            End If
            dt.Dispose()
        Catch ex As Exception
            ret = ""
        End Try
        Return ret
    End Function

    Public Shared Function GetTagListByAppNo(AppNo As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select rt.tag_no"
            sql += " from TS_REQUISITION_TAG rt"
            sql += " inner join TB_REQUISTION r on r.id=rt.tb_requisition_id"
            sql += " where r.app_no='" & AppNo & "'"

            ret = GlobalFunction.GetDatatable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function
#End Region

    Public Shared Function LoadFloorPlanByApp_No(app_no As String, login_username As String) As String
        Try
            'app_no = "0001000002"
            Dim re As Boolean = True

            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            If GlobalFunction.ExecuteNonQuery("delete from TMP_DOC_TRACING where tag_no='" & app_no & "'", trans.Trans) = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            Dim tLnq As New TmpDocTracingLinqDB
            trans = New TransactionDB(SelectDB.DIPRFID)
            Dim tmpDt As DataTable = tLnq.GetDataList("tag_no='" & app_no & "' and tracing_status='1'", "", trans.Trans) '
            If tmpDt.Rows.Count = 0 Then
                tLnq.TAG_NO = app_no
                tLnq.TRACING_STATUS = "1"
                tLnq.TRACING_START_TIME = DateTime.Now
                re = tLnq.InsertData(login_username, trans.Trans)
                If re = False Then
                    trans.RollbackTransaction()
                    Return "[]"
                Else
                    trans.CommitTransaction()
                    Threading.Thread.Sleep(10000)
                End If

            End If
            tmpDt.Dispose()
            tLnq = Nothing
            'Else
            're = True
            'End If
            'Threading.Thread.Sleep(10000)



            If re = True Then
                Dim dtdetail As DataTable
                Dim strSQlDetail As New StringBuilder
                'strSQlDetail.Append(" select T1.*, " & vbNewLine)
                'strSQlDetail.Append(" convert(varchar, dateadd(year,0,fb.borrowdate ),103) + ' ' + left(convert(varchar, fb.borrowdate ,108),5)  as borrowerdate ," & vbNewLine)
                'strSQlDetail.Append(" fb.borrower_name borrowname " & vbNewLine)
                'strSQlDetail.Append(" from [TMP_FILEBORROWITEM] fb" & vbNewLine)
                'strSQlDetail.Append(" left join" & vbNewLine)
                'strSQlDetail.Append(" 	(")
                'strSQlDetail.Append("   select " & vbNewLine)
                'strSQlDetail.Append("   convert(varchar, fcl.move_date,103) + ' ' + left(convert(varchar, fcl.move_date,108),5)  as strmove_date" & vbNewLine)
                'strSQlDetail.Append("   , fcl.app_no" & vbNewLine)
                'strSQlDetail.Append("   ,fcl.officer_name" & vbNewLine)
                'strSQlDetail.Append("   ,location_name" & vbNewLine)
                'strSQlDetail.Append("   ,fp.image_floor_plan" & vbNewLine)
                'strSQlDetail.Append("   ,fp.image_file_ext" & vbNewLine)
                'strSQlDetail.Append("   ,gl.vertical_line" & vbNewLine)
                'strSQlDetail.Append("   ,gl.horizontal_line" & vbNewLine)
                'strSQlDetail.Append("   ,sag.grid_col" & vbNewLine)
                'strSQlDetail.Append("   ,sag.grid_row" & vbNewLine)
                'strSQlDetail.Append("   from ts_file_current_location fcl " & vbNewLine)
                'strSQlDetail.Append("   inner join ms_room r  on fcl.ms_room_id = r.id " & vbNewLine)
                'strSQlDetail.Append("   inner join ms_floor_plan fp on fp.id = r.ms_floor_plan_id_current  " & vbNewLine)
                'strSQlDetail.Append("   inner join ms_grid_layout gl  on r.ms_grid_layout_id_current = gl.id  " & vbNewLine)
                'strSQlDetail.Append("   inner join ts_file_current_grid fcg on fcg.ts_file_current_location_id  =fcl.id and fcg.ms_grid_layout_id=r.ms_grid_layout_id_current " & vbNewLine)
                'strSQlDetail.Append("   inner join MS_SPEEDWAY sp on sp.ReaderID=fcl.ReaderID" & vbNewLine)
                'strSQlDetail.Append("   inner join ms_speedway_ant_grid sag on sag.ms_grid_layout_id=gl.id " & vbNewLine)
                'strSQlDetail.Append("   inner join MS_SPEEDWAY_ANT swa on swa.id=sag.ms_speedway_ant_id and swa.port_number=fcl.ant_port_number and swa.ms_speedway_id=sp.id" & vbNewLine)
                'strSQlDetail.Append(" ) T1 on T1.app_no = fb.app_no " & vbNewLine)
                'strSQlDetail.Append("   where T1.app_no='" & app_no & "'")


                strSQlDetail.Append(" select T1.*, " & vbNewLine)
                strSQlDetail.Append(" convert(varchar, dateadd(year,0,fb.borrowdate ),103) + ' ' + left(convert(varchar, fb.borrowdate ,108),5)  as borrowerdate ," & vbNewLine)
                strSQlDetail.Append(" fb.borrower_name borrowname " & vbNewLine)
                strSQlDetail.Append(" from " & vbNewLine)
                strSQlDetail.Append(" 	(")
                strSQlDetail.Append("   select " & vbNewLine)
                strSQlDetail.Append("   convert(varchar, fcl.move_date,103) + ' ' + left(convert(varchar, fcl.move_date,108),5)  as strmove_date" & vbNewLine)
                strSQlDetail.Append("   , fcl.app_no" & vbNewLine)
                strSQlDetail.Append("   ,fcl.officer_name" & vbNewLine)
                strSQlDetail.Append("   ,location_name" & vbNewLine)
                strSQlDetail.Append("   ,fp.image_floor_plan" & vbNewLine)
                strSQlDetail.Append("   ,fp.image_file_ext" & vbNewLine)
                strSQlDetail.Append("   ,gl.vertical_line" & vbNewLine)
                strSQlDetail.Append("   ,gl.horizontal_line" & vbNewLine)
                strSQlDetail.Append("   ,sag.grid_col" & vbNewLine)
                strSQlDetail.Append("   ,sag.grid_row" & vbNewLine)
                strSQlDetail.Append("   from ts_file_current_location fcl " & vbNewLine)
                strSQlDetail.Append("   inner join ms_room r  on fcl.ms_room_id = r.id " & vbNewLine)
                strSQlDetail.Append("   inner join ms_floor_plan fp on fp.id = r.ms_floor_plan_id_current  " & vbNewLine)
                strSQlDetail.Append("   inner join ms_grid_layout gl  on r.ms_grid_layout_id_current = gl.id  " & vbNewLine)
                strSQlDetail.Append("   inner join ts_file_current_grid fcg on fcg.ts_file_current_location_id  =fcl.id and fcg.ms_grid_layout_id=r.ms_grid_layout_id_current " & vbNewLine)
                strSQlDetail.Append("   inner join MS_SPEEDWAY sp on sp.ReaderID=fcl.ReaderID" & vbNewLine)
                strSQlDetail.Append("   inner join ms_speedway_ant_grid sag on sag.ms_grid_layout_id=gl.id " & vbNewLine)
                strSQlDetail.Append("   inner join MS_SPEEDWAY_ANT swa on swa.id=sag.ms_speedway_ant_id and swa.port_number=fcl.ant_port_number and swa.ms_speedway_id=sp.id" & vbNewLine)
                strSQlDetail.Append(" ) T1  " & vbNewLine)
                strSQlDetail.Append("   left join [TMP_FILEBORROWITEM] fb " & vbNewLine)
                strSQlDetail.Append("   on T1.app_no = fb.app_no " & vbNewLine)
                strSQlDetail.Append("   where T1.app_no='" & app_no & "'")

                dtdetail = DIPRFIDSqlDB.ExecuteTable(strSQlDetail.ToString)
                If dtdetail.Rows.Count <> 0 Then
                    If Convert.IsDBNull(dtdetail.Rows(0)("app_no")) = False Then
                        Dim strimagebase64 As String = ""
                        Dim strimagebasesrc As String = ""
                        Dim imgWidth As Integer = 850
                        Dim imgHeight As Integer = 650

                        If dtdetail.Rows(0)("image_file_ext") & "" <> "" Then
                            'Dim ByteImg() As Byte = dtdetail.Rows(0)("image_floor_plan")
                            'Dim img As Image
                            'Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(ByteImg)
                            'img = Image.FromStream(ms)
                            'If img IsNot Nothing Then
                            '    imgWidth = img.Width
                            '    imgHeight = img.Height
                            'End If

                            strimagebasesrc = "data:image/" & dtdetail.Rows(0)("image_file_ext") & ";base64," & Convert.ToBase64String(dtdetail.Rows(0)("image_floor_plan"))
                        End If

                        Dim strfloorplanpath As String
                        Dim indexstrart As Integer = 1
                        Dim gridfound_index As String = ""
                        Dim gridfound_col As Integer = Val(dtdetail.Rows(0)("grid_col") & "")
                        Dim gridfound_row As Integer = Val(dtdetail.Rows(0)("grid_row") & "")
                        Dim countRows As Integer = Val(dtdetail.Rows(0)("vertical_line") & "")
                        Dim countColums As Integer = Val(dtdetail.Rows(0)("horizontal_line") & "")
                        Dim addstyle As String = " style=""background-color:red"""
                        Dim tmpstyle As String = ""
                        Dim strSQl As New StringBuilder
                        strSQl.Append("<table border=""0"" style="" background: url('" & strimagebasesrc & "');background-size: 100% auto;background-repeat: no-repeat;align-content: center; width:" & imgWidth & "px;height:" & imgHeight & "px"" >")
                        For i As Integer = 1 To countRows
                            strSQl.Append("<tr>")
                            For j As Integer = 1 To countColums
                                dtdetail.DefaultView.RowFilter = "grid_col='" & j & "' and grid_row='" & i & "'"
                                If dtdetail.DefaultView.Count > 0 Then
                                    tmpstyle = addstyle

                                    If gridfound_index = "" Then
                                        gridfound_index = indexstrart
                                    Else
                                        gridfound_index += "," & indexstrart
                                    End If
                                Else
                                    tmpstyle = ""
                                End If
                                dtdetail.DefaultView.RowFilter = ""

                                strSQl.Append("<td id=" & indexstrart & " " & tmpstyle & ">")
                                strSQl.Append("</td>")
                                indexstrart = indexstrart + 1
                            Next
                            strSQl.Append("</tr>")
                        Next
                        strSQl.Append("</table>")

                        Dim dt As New DataTable
                        Dim dr As DataRow
                        dt.Columns.Add("strmove_date")
                        dt.Columns.Add("app_no")
                        dt.Columns.Add("officer_name")
                        dt.Columns.Add("location_name")
                        dt.Columns.Add("showdata")
                        dt.Columns.Add("showfound")
                        dt.Columns.Add("borrowname")
                        dt.Columns.Add("borrowerdate")
                        dr = dt.NewRow
                        dr("strmove_date") = dtdetail.Rows(0)("strmove_date") & ""
                        dr("app_no") = dtdetail.Rows(0)("app_no") & ""
                        dr("officer_name") = dtdetail.Rows(0)("officer_name") & ""
                        dr("location_name") = dtdetail.Rows(0)("location_name") & ""
                        dr("showdata") = strSQl.ToString
                        dr("showfound") = gridfound_index  'Array of index Ex. 1,4,7,3
                        dr("borrowname") = dtdetail.Rows(0)("borrowname") & ""
                        dr("borrowerdate") = dtdetail.Rows(0)("borrowerdate") & ""
                        dt.Rows.Add(dr)

                        Dim strdata As String
                        strdata = ConvertDataTableToJson(dt)

                        Return strdata
                    Else
                        Return "[]"
                    End If
                Else
                    Return "[]"
                End If
            End If

        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    Public Shared Function LoadFloorPlanByApp_No_NotMap(app_no As String, login_username As String) As String
        Try
            'app_no = "0001000002"

            Dim dtdetail As DataTable
            Dim strSQlDetail As New StringBuilder
            strSQlDetail.Append(" select fmh.id,r.room_name location_name, '' description ")
            strSQlDetail.Append(" ,convert(varchar, fmh.move_date,103) + ' ' + left(convert(varchar, fmh.move_date,108),5)  as move_date")
            strSQlDetail.Append(" ,isnull(convert(varchar, dateadd(year,0,fb.borrowdate ),103) + ' ' + left(convert(varchar, fb.borrowdate ,108),5) ,'') as borrowerdate")
            strSQlDetail.Append(" ,isnull(fb.borrower_name,'') borrowname ")
            strSQlDetail.Append(" from [dbo].[TS_FILE_CURRENT_LOCATION] fmh")
            strSQlDetail.Append(" inner join ms_room r on fmh.ms_room_id = r.id")
            strSQlDetail.Append(" left join TMP_FILEBORROWITEM fb on fb.app_no=fmh.app_no")
            strSQlDetail.Append(" where fmh.app_no='" & app_no & "'")

            dtdetail = DIPRFIDSqlDB.ExecuteTable(strSQlDetail.ToString)
            If dtdetail.Rows.Count <> 0 Then
                Dim strdata As String
                strdata = ConvertDataTableToJson(dtdetail)
                Return strdata
            Else
                'ถ้าหาใน TS_FILE_CURRENT_LOCATION แล้วไม่เจอ ให้หาใน TB_FILESTORE
                strSQlDetail.Clear()

                strSQlDetail.Append(" select fs.id, r.room_name location_name, '' description ")
                strSQlDetail.Append(" ,convert(varchar, isnull(fs.updateon,fs.createon),103) + ' ' + left(convert(varchar, isnull(fs.updateon,fs.createon),108),5)  as move_date")
                strSQlDetail.Append(" ,isnull(convert(varchar, dateadd(year,0,fb.borrowdate ),103) + ' ' + left(convert(varchar, fb.borrowdate ,108),5),'')  as borrowerdate")
                strSQlDetail.Append(" ,isnull(fb.borrower_name,'') borrowname ")
                strSQlDetail.Append(" from TB_REQUISTION rq")
                strSQlDetail.Append(" inner join TB_FILESTORE fs on fs.app_no=rq.app_no")
                strSQlDetail.Append(" inner join TB_FILELOCATION fc on fc.id=fs.filelocation")
                strSQlDetail.Append(" inner join MS_ROOM r on r.id=fc.ms_room_id")
                strSQlDetail.Append(" left join TMP_FILEBORROWITEM fb on fb.app_no=rq.app_no")
                strSQlDetail.Append(" where rq.app_no='" & app_no & "'")
                dtdetail = DIPRFIDSqlDB.ExecuteTable(strSQlDetail.ToString)
                If dtdetail.Rows.Count > 0 Then
                    Dim strdata As String
                    strdata = ConvertDataTableToJson(dtdetail)
                    Return strdata
                Else
                    Return "[]"
                End If
            End If
        Catch ex As Exception
            Return "[]"
        End Try
    End Function

    Public Shared Function ConvertDataTableToJson(ByVal dt As DataTable) As String
        Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
        serializer.MaxJsonLength = Int32.MaxValue
        Dim rows As New List(Of Dictionary(Of String, Object))
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next
        Return serializer.Serialize(rows)
    End Function

#Region "Search Amount File By Location"

    Public Shared Function GetSearchFileByFloor(arrFloorID As String) As DataTable
        'arrFloorID format EX. '1,3,10,12'
        Dim ret As New DataTable
        ret.Columns.Add("no")
        ret.Columns.Add("id")
        ret.Columns.Add("floor_name")
        ret.Columns.Add("patent_type_name")
        ret.Columns.Add("amountfile")
        ret.Columns.Add("patent_type_id")

        Try
            For Each FloorID As String In Split(arrFloorID, ",")
                Dim tmpDt As New DataTable

                Select Case FloorID
                    Case "1" 'ชั้น 1
                        tmpDt = GetFileQtyByFloor(FloorID)
                        If tmpDt.Rows.Count > 0 Then
                            ret = MergeQtyData(ret, tmpDt)
                        End If
                    Case "2" 'ชั้น 3
                        tmpDt = GetFileQtyFloor3()
                        If tmpDt.Rows.Count > 0 Then
                            ret = MergeQtyData(ret, tmpDt)
                        End If
                    Case "4" 'ชั้น 6
                        tmpDt = GetFileQtyFloor6NoPCT()
                        If tmpDt.Rows.Count > 0 Then
                            ret = MergeQtyData(ret, tmpDt)
                        End If
                    Case "5" 'ชั้น 10
                        tmpDt = GetFileQtyByFloor(FloorID)
                        If tmpDt.Rows.Count > 0 Then
                            ret = MergeQtyData(ret, tmpDt)
                        End If
                    Case "6" 'ชั้น 12
                        tmpDt = GetFileQtyByFloor(FloorID)
                        If tmpDt.Rows.Count > 0 Then
                            ret = MergeQtyData(ret, tmpDt)
                        End If
                End Select
                tmpDt.Dispose()
            Next
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function



    Private Shared Function GetFileQtyByFloor(MsFloorID As String) As DataTable
        'จำนวนแฟ้มในแต่ละชั้น ใช้สำหรับชั้น 1,3(บางส่วน),10,12
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql += " select  f.id, f.floor_name,pt.patent_type_name,count(rq.app_no) amountfile,rq.patent_type_id " & vbNewLine
            sql += " from [dbo].[TB_REQUISTION] rq" & vbNewLine
            sql += " left join TS_FILE_CURRENT_LOCATION fc on fc.app_no=rq.app_no " & vbNewLine
            sql += " left join MS_ROOM rm on fc.ms_room_id=rm.id" & vbNewLine
            sql += " left join [dbo].[TB_FILELOCATION] fl on rq.filelocation = fl.id " & vbNewLine
            sql += " left join MS_FLOOR f on isnull(rm.ms_floor_id, fl.ms_floor_id)= f.id " & vbNewLine
            sql += " inner join TB_PATENT_TYPE pt on rq.patent_type_id =pt.id" & vbNewLine
            sql += " where f.id = '" & MsFloorID & "' and rq.patent_type_id in (1,3)" & vbNewLine
            sql += " group by  f.id, f.floor_name,pt.patent_type_name,rq.patent_type_id " & vbNewLine

            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Public Shared Function GetFileQtyFloor6NoPCT() As DataTable
        'จำนวนชั้น 6 ไม่รวม PCT
        Dim ret As New DataTable
        Try
            Dim sql As String = ""
            sql += " select  f.id, f.floor_name,pt.patent_type_name,count(rq.app_no) amountfile,rq.patent_type_id" & vbNewLine
            sql += " from [dbo].[TB_REQUISTION] rq" & vbNewLine
            sql += " left join TS_FILE_CURRENT_LOCATION fc on fc.app_no=rq.app_no " & vbNewLine
            sql += " left join MS_ROOM rm on fc.ms_room_id=rm.id" & vbNewLine
            sql += " left join [dbo].[TB_FILELOCATION] fl on rq.filelocation = fl.id " & vbNewLine
            sql += " left join MS_FLOOR f on isnull(rm.ms_floor_id, fl.ms_floor_id)= f.id " & vbNewLine
            sql += " inner join TB_PATENT_TYPE pt on rq.patent_type_id =pt.id" & vbNewLine
            sql += " where isnull(fc.ms_room_id,fl.ms_room_id) = '6' and rq.patent_type_id in (1,3)" & vbNewLine
            sql += " group by f.id,f.floor_name,pt.patent_type_name,rq.patent_type_id " & vbNewLine

            ret = DIPRFIDSqlDB.ExecuteTable(sql)
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Private Shared Function GetFileQtyFloor3() As DataTable
        'จำนวนแฟ้มในแต่ละชั้น 3
        Dim ret As New DataTable
        Try
            Dim FloorID As String = "2"
            Dim sql As String = ""
            sql += " select  " & FloorID & " id,(select floor_name from ms_floor where id=" & FloorID & ") floor_name,pt.patent_type_name,count(rq.app_no) amountfile,rq.patent_type_id"
            sql += " from [dbo].[TB_REQUISTION] rq"
            sql += " left join TS_FILE_CURRENT_LOCATION fc on fc.app_no=rq.app_no "
            sql += " left join MS_ROOM rm on fc.ms_room_id=rm.id"
            sql += " left join [TB_FILELOCATION] fl on rq.filelocation = fl.id "
            sql += " left join MS_FLOOR f on isnull(rm.ms_floor_id, fl.ms_floor_id)= f.id "
            sql += " inner join TB_PATENT_TYPE pt on rq.patent_type_id =pt.id"
            sql += " where isnull(fc.ms_room_id,fl.ms_room_id) is null and rq.patent_type_id in (1,3)"
            sql += " group by  f.id, f.floor_name,pt.patent_type_name,rq.patent_type_id "


            ret = DIPRFIDSqlDB.ExecuteTable(sql)
            If ret.Rows.Count > 0 Then

                Dim TmpDt As DataTable = GetFileQtyByFloor(FloorID)
                For i As Integer = 0 To ret.Rows.Count - 1
                    Dim dr As DataRow = ret.Rows(i)
                    TmpDt.DefaultView.RowFilter = "id='" & dr("id") & "' and patent_type_id='" & dr("patent_type_id") & "'"
                    If TmpDt.DefaultView.Count > 0 Then
                        ret.Rows(i)("amountfile") += Convert.ToInt64(TmpDt.DefaultView(0)("amountfile"))
                    End If
                Next
            End If
        Catch ex As Exception
            ret = New DataTable
        End Try
        Return ret
    End Function

    Private Shared Function MergeQtyData(ret As DataTable, TmpDt As DataTable) As DataTable
        For i As Integer = 0 To TmpDt.Rows.Count - 1
            Dim dr As DataRow = ret.NewRow
            dr("id") = TmpDt.Rows(i)("id")
            dr("floor_name") = TmpDt.Rows(i)("floor_name")
            dr("patent_type_name") = TmpDt.Rows(i)("patent_type_name")
            dr("amountfile") = TmpDt.Rows(i)("amountfile")
            dr("patent_type_id") = TmpDt.Rows(i)("patent_type_id")

            ret.Rows.Add(dr)
        Next
        Return ret
    End Function
#End Region


End Class
