Imports System.Net.Sockets
Imports System.Net
Imports Engine.LogFile
Imports LinqDB.TABLE
Imports Engine
Public Class frmRFIDReaderImportData

    Private Sub SetDeviceInfo()
        Dim lnq As New MsMidRangeReaderLinqDB
        Try
            lnq.ChkDataByIP_ADDRESS(lblIPAddress.Text, Nothing)
            If lnq.ID > 0 Then
                lblMacAddress.Text = lnq.MAC_ADDRESS
                lblSerialNo.Text = lnq.SERIAL_NO
                lblPortNo.Text = lnq.TCP_PORT_NO
                lblMsRoomID.Text = lnq.MS_ROOM_ID

                If lnq.INSTALL_POSITION.Trim <> "" Then
                    lblLocationName.Text = lnq.INSTALL_POSITION
                Else
                    lblLocationName.Text = GetLocationName()
                End If

                'Dim Location As String = "ชั้น " & dr("floor_name") & " " & dr("room_name")
            End If
            lnq = Nothing
        Catch ex As Exception
            Engine.LogFile.LogENG.SaveErrLog("RFIDReaderImportData.frmRFIDReaderImportData_SetDeviceInfo " & Me.Text, "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function GetLocationName() As String
        Dim ret As String = ""
        Try
            Dim sql As String = "select fl.floor_name, r.room_name "
            sql += " from ms_room r "
            sql += " inner join ms_floor fl on fl.id=r.ms_floor_id"
            sql += " where r.id='" & lblMsRoomID.Text & "'"

            Dim dt As DataTable = Engine.GlobalFunction.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                ret = dt.Rows(0)("floor_name") & " " & dt.Rows(0)("room_name")
            End If
        Catch ex As Exception

        End Try
        
        Return ret
    End Function

    Private Sub frmRFIDReaderImportData_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If My.Application.CommandLineArgs.Count > 0 Then
                lblIPAddress.Text = My.Application.CommandLineArgs(0)
                Me.Text = Me.Text & " : " & lblIPAddress.Text
                Me.Visible = False

                SetDeviceInfo()

                Application.DoEvents()

                If lblIPAddress.Text.Trim <> "" And lblPortNo.Text.Trim <> "" Then
                    Dim t As New System.Threading.Thread(Sub() Start(lblIPAddress.Text, lblPortNo.Text))
                    t.Start()

                    'Start(lblIPAddress.Text, lblPortNo.Text)
                End If
            Else
                Application.Exit()
            End If
        Catch ex As Exception
            LogENG.SaveErrLog(Me.Text & " RFIDReaderImportData.frmRFIDReaderImportData_Shown", "Exception " & ex.Message & vbNewLine & ex.StackTrace)
            Application.Exit()
        End Try
    End Sub


    Dim dt As New DataTable
    Private Sub Start(ip As String, port As Integer)
        dt.Columns.Add("tag_no")
        While (True)
            Try
                Dim client As New TcpClient(ip, port)
                Dim data(1024) As [Byte]
                data = New [Byte](1024) {}
                Dim stream As NetworkStream = client.GetStream()

                Dim responseData As String = String.Empty
                Dim bytes As Int32 = stream.Read(data, 0, data.Length)

                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
                ' Close everything.
                stream.Close()
                client.Close()

                If responseData.Trim <> "" Then
                    For Each tmpData As String In Split(responseData, Chr(13))
                        Dim tmp() As String = Split(tmpData, ",")
                        If tmp.Length = 2 Then
                            'Engine.LogFile.LogENG.CreateLogFile("C:\", "TransLog_MIDRANGE_" & lblSerialNo.Text & ".txt", tmp(0).Replace(Chr(10), ""))


                            Dim TagNo As String = tmp(0).Replace(Chr(10), "").Substring(0, 10)
                            dt.DefaultView.RowFilter = "tag_no='" & TagNo & "'"
                            If dt.DefaultView.Count = 0 Then
                                Dim dr As DataRow = dt.NewRow
                                dr("tag_no") = TagNo
                                dt.Rows.Add(dr)
                            End If
                            dt.DefaultView.RowFilter = ""
                        End If
                    Next
                    'ImportDataToDb(responseData)
                End If
            Catch e As ArgumentNullException
                LogENG.SaveErrLog(Me.Text & " RFIDReaderImportData.Start", "ArgumentNullException " & e.Message & vbNewLine & e.StackTrace)
            Catch e As SocketException
                LogENG.SaveErrLog(Me.Text & " RFIDReaderImportData.Start", "SocketException " & e.Message & vbNewLine & e.StackTrace)
            Catch e As Exception
                LogENG.SaveErrLog(Me.Text & " RFIDReaderImportData.Start", "Exception " & e.Message & vbNewLine & e.StackTrace)
            End Try
        End While
    End Sub

    'Private Sub ImportDataToDb(TagData As String)
    '    Dim UserName As String = Me.Text
    '    Dim MoveDate As DateTime = GlobalFunction.GetDateNowFromDB()
    '    Dim ReaderID As String = lblSerialNo.Text
    '    Dim AntNo As String = 1

    '    Dim LocationName As String = lblLocationName.Text
    '    Dim MsRoomID As Long = lblMsRoomID.Text

    '    For Each tmpData As String In Split(TagData, Chr(13))
    '        Dim tmp() As String = Split(tmpData, ",")
    '        If tmp.Length = 2 Then
    '            Dim TagNo As String = tmp(0).Replace(Chr(10), "").Substring(0, 10)

    '            Try
    '                Dim Rssi As String = "0"
    '                Dim tmpRssi As Integer = 0
    '                tmpRssi = CInt("&H" & tmp(1).ToString)
    '                If tmpRssi.ToString.Length >= 2 Then
    '                    Dim tmp1 As String = tmpRssi.ToString.Substring(0, tmpRssi.ToString.Length - 2)
    '                    Dim tmp2 As String = tmpRssi.ToString.Substring(tmp1.Length)

    '                    Rssi = tmp1 & "." & tmp2
    '                End If

    '                If TagNo.Trim <> "" Then
    '                    If CheckDupIn5s(TagNo.Trim) = False Then
    '                        'ถ้าอ่าน Tag เดียวกันเจอซ้ำภายใน 5 วินาที ก็ไม่ต้อง Insert History ซ้ำอีก
    '                        FileLocationENG.MidRangeSaveFileHistory(Me.Text, TagNo.Trim, MoveDate, ReaderID, AntNo, Rssi, LocationName, MsRoomID)
    '                    End If
    '                End If
    '            Catch ex As Exception

    '            End Try
    '        End If
    '    Next
    'End Sub

    Private Function CheckDupIn5s(TagNo As String) As Boolean
        Dim ret As Boolean = False
        Dim sql As String = "select top 1 id"
        sql += " from TS_FILE_MOVE_HISTORY"
        sql += " where app_no='" & TagNo.Trim & "' "
        sql += " and readerid='" & lblSerialNo.Text & "'"
        sql += " and dateadd(ss,5,move_date)>=getdate()"
        Dim dt As DataTable = GlobalFunction.GetDatatable(sql)
        If dt.Rows.Count > 0 Then
            ret = True
        End If
        Return ret
    End Function

    Private Function CheckCurrentLocation(TagNo As String) As Boolean
        Dim ret As Boolean = False
        Dim lnq As New TsFileCurrentLocationLinqDB
        lnq.ChkDataByAPP_NO(TagNo, Nothing)
        If lnq.ID > 0 Then
            If lnq.READERID = lblSerialNo.Text Then
                ret = True
            End If
        End If
        lnq = Nothing
        Return ret
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        If dt.Rows.Count > 0 Then
            Dim UserName As String = Me.Text
            'Dim MoveDate As DateTime = GlobalFunction.GetDateNowFromDB()
            Dim ReaderID As String = lblSerialNo.Text
            Dim AntNo As String = 1
            Dim LocationName As String = lblLocationName.Text
            Dim MsRoomID As Long = lblMsRoomID.Text

            For i As Integer = dt.Rows.Count - 1 To 0 Step -1
                Dim dr As DataRow = dt.Rows(i)
                Dim TagNo As String = dr("tag_no")

                Try
                    If TagNo.Trim <> "" Then
                        'If CheckCurrentLocation(TagNo.Trim) = False Then
                        '    'ถ้าอ่าน Tag ใน Location นี้แล้ว ก็ไม่ต้อง Insert History ซ้ำอีก
                        '    FileLocationENG.MidRangeSaveFileHistory(Me.Text, TagNo.Trim, DateTime.Now, ReaderID, AntNo, 0, LocationName, MsRoomID)
                        'End If


                        'หา แฟ้มทั้งหมดที่อยู่ในใบยืมเดียวกัน
                        Dim sql As String = " select fb.app_no, f.send_time " & vbNewLine
                        sql += " from TMP_FILEBORROWITEM fb" & vbNewLine
                        sql += " inner join TB_FILEBORROWITEM fi on fi.id=fb.fileborrowitem_id" & vbNewLine
                        sql += " inner join TB_FILEBORROW f on f.id=fi.fileborrow_id " & vbNewLine
                        sql += " where fileborrowitem_id <> 0" & vbNewLine
                        sql += " and fi.fileborrow_id in (select fbi.fileborrow_id " & vbNewLine
                        sql += "                            from TMP_FILEBORROWITEM tf " & vbNewLine
                        sql += "                            inner join TB_FILEBORROWITEM fbi on fbi.id=tf.fileborrowitem_id" & vbNewLine
                        sql += "                            where tf.app_no= '" & TagNo & "')" & vbNewLine

                        Dim tDt As DataTable = GlobalFunction.GetDatatable(sql)
                        If tDt.Rows.Count > 0 Then
                            For Each tDr As DataRow In tDt.Rows
                                If CheckCurrentLocation(tDr("app_no")) = False Then
                                    'ถ้าอ่าน Tag ใน Location นี้แล้ว ก็ไม่ต้อง Insert History ซ้ำอีก

                                    If Convert.IsDBNull(tDr("send_time")) = False Then
                                        'ถ้าเป็นแฟ้มที่รับแล้ว ต้องเช็คว่าเป็น Tag เดียวกันหรือไม่
                                        If tDr("app_no").ToString = TagNo Then
                                            FileLocationENG.MidRangeSaveFileHistory(Me.Text, TagNo, DateTime.Now, ReaderID, AntNo, 0, LocationName, MsRoomID)
                                        End If
                                    Else
                                        'ถ้าเป็นแฟ้มในใบยืมที่ยังไม่รับ ให้ Update Location ทั้งหมด
                                        FileLocationENG.MidRangeSaveFileHistory(Me.Text, tDr("app_no"), DateTime.Now, ReaderID, AntNo, 0, LocationName, MsRoomID)
                                    End If
                                End If
                            Next
                        Else
                            If CheckCurrentLocation(TagNo.Trim) = False Then
                                'ถ้าอ่าน Tag ใน Location นี้แล้ว ก็ไม่ต้อง Insert History ซ้ำอีก
                                FileLocationENG.MidRangeSaveFileHistory(Me.Text, TagNo.Trim, DateTime.Now, ReaderID, AntNo, 0, LocationName, MsRoomID)
                            End If
                        End If
                        tDt.Dispose()
                    End If
                Catch ex As Exception

                End Try
                dt.Rows.RemoveAt(i)
            Next
        End If
        'ImportDataToDb("")
        Timer1.Enabled = True
    End Sub

    Private Function TelnetPort(ByVal PIPAddress As String, ByVal PPort As String) As Boolean
        Dim ret As Boolean = False
        Dim remoteIPAddress As IPAddress
        Dim ep As IPEndPoint
        Dim tnSocket As Socket

        ' Get the IP Address and the Port and create an IPEndpoint (ep)
        Try
            remoteIPAddress = IPAddress.Parse(PIPAddress.Trim)
            ep = New IPEndPoint(remoteIPAddress, CType(PPort.Trim, Integer))
            ' Set the socket up (type etc)
            tnSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Try
                ' Connect
                tnSocket.Connect(ep)
                If tnSocket.Connected = True Then
                    ret = True
                End If

            Catch oEX As SocketException
                ' error
                ' You will need to do error cleanup here e.g killing the socket
                ' and exiting the procedure.

                'FunctionEng.CreateErrorLog("frmNewMain", "TelnetPort", "SocketException :" & oEX.Message & vbNewLine & oEX.StackTrace)

                Return False
            End Try
        Catch ex As Exception
            'FunctionEng.CreateErrorLog("frmNewMain", "TelnetPort", "Exception :" & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try


        ' Cleanup
        remoteIPAddress = Nothing
        ep = Nothing
        tnSocket = Nothing

        Return ret
    End Function


End Class
