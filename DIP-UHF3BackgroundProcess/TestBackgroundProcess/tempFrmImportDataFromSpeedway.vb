Imports LinqDB.ConnectDB
Public Class tempFrmImportDataFromSpeedway

    Dim connStr As String = "Data Source=10.10.18.86;Initial Catalog=RFID;User ID=sa;Password=1qaz@WSX;"
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Try
            Dim dt As DataTable = GetDataFromLocalhost()
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    Dim lnq As New LinqDB.TABLE.TsFileMoveHistoryLinqDB
                    lnq.GetDataByPK(dr("id"), Nothing)

                    If lnq.ID > 0 Then
                        Try
                            Dim con As New SqlClient.SqlConnection(connStr)
                            con.Open()

                            Dim da As New SqlClient.SqlDataAdapter("select id from TS_FILE_MOVE_HISTORY where id='" & lnq.ID & "'", con)
                            Dim tmpDt As New DataTable
                            da.Fill(tmpDt)
                            If tmpDt.Rows.Count > 0 Then
                                Dim trans As New TransactionDB(SelectDB.DIPRFID)
                                If lnq.DeleteByPK(lnq.ID, trans.Trans) = True Then
                                    trans.CommitTransaction()
                                Else
                                    trans.RollbackTransaction()
                                End If

                                Continue For
                            End If
                            da.Dispose()
                            tmpDt.Dispose()

                            Dim sql As String = " set identity_insert [TS_FILE_MOVE_HISTORY] on; "
                            sql += " insert into TS_FILE_MOVE_HISTORY([id],[created_by],[created_date],[app_no],[move_date],"
                            sql += " [ReaderID],[ant_port_number],[rssi],[location_name],[ms_room_id],"
                            sql += " [tb_officer_id],[officer_name],[ms_desktop_id],[desk_name],[ms_grid_layout_id],"
                            sql += " [grid_row],[grid_col],[is_update_current_location])"
                            sql += " values('" & lnq.ID & "'"
                            sql += ",'" & lnq.CREATED_BY & "'"
                            sql += ",'" & lnq.CREATED_DATE.ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                            sql += ",'" & lnq.APP_NO & "'"
                            sql += ",'" & lnq.MOVE_DATE.ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                            sql += ",'" & lnq.READERID & "'"
                            sql += ",'" & lnq.ANT_PORT_NUMBER & "'"
                            sql += ",'" & lnq.RSSI & "'"
                            sql += ",'" & lnq.LOCATION_NAME & "'"
                            sql += ",'" & lnq.MS_ROOM_ID & "'"
                            sql += ",'" & lnq.TB_OFFICER_ID & "'"
                            sql += ",'" & lnq.OFFICER_NAME & "'"
                            sql += ",'" & lnq.MS_DESKTOP_ID & "'"
                            sql += ",'" & lnq.DESK_NAME & "'"
                            sql += ",'" & lnq.MS_GRID_LAYOUT_ID & "'"
                            sql += ",'" & lnq.GRID_ROW & "'"
                            sql += ",'" & lnq.GRID_COL & "'"
                            sql += ",'" & lnq.IS_UPDATE_CURRENT_LOCATION & "'"
                            sql += ");"
                            sql += " set identity_insert [TS_FILE_MOVE_HISTORY] on;"

                            Dim cmd As New SqlClient.SqlCommand(sql, con)
                            cmd.CommandType = CommandType.Text

                            cmd.ExecuteNonQuery()
                        Catch ex As Exception

                        End Try
                        
                    End If
                    lnq = Nothing
                Next
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try



        Timer1.Enabled = True
    End Sub

    Private Function GetDataFromLocalhost() As DataTable
        Dim dt As DataTable = DIPRFIDSqlDB.ExecuteTable("select id from TS_FILE_MOVE_HISTORY")
        Return dt
    End Function
End Class