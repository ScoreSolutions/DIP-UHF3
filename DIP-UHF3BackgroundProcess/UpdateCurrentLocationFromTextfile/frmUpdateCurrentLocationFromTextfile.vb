Imports Engine
Imports System.IO

Public Class frmUpdateCurrentLocationFromTextfile

    Private Sub frmUpdateCurrentLocationFromTextfile_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SetDDL()
    End Sub

    Private Sub SetDDL()
        Try
            Dim sql As String = "select ms_room_id, location_name "
            sql += " from TB_FILELOCATION "
            sql += " where ms_room_id is not null"
            sql += " and readerid is not null"
            sql += " order by id"

            Dim dt As DataTable = GlobalFunction.GetDatatable(sql)
            cbLocation.DisplayMember = "location_name"
            cbLocation.ValueMember = "ms_room_id"
            cbLocation.DataSource = dt

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        fdBrowse.Filter = "Text File|*.txt"
        If fdBrowse.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtTextFile.Text = fdBrowse.FileName
            ToolTip1.SetToolTip(txtTextFile, fdBrowse.FileName)

            If IO.File.Exists(txtTextFile.Text) = True Then
                Dim sr As New StreamReader(txtTextFile.Text)
                Try
                    Dim dt As New DataTable
                    dt.Columns.Add("tag_no")
                    dt.Columns.Add("app_no")
                    While sr.Peek() > -1
                        Dim Tmp() As String = sr.ReadLine.Split(Chr(9))    'Record No/Tag No
                        If Tmp.Length = 2 Then
                            Dim TagNo = Tmp(1)
                            Dim AppNo As String = ""
                            If TagNo.Length > 10 Then
                                If TagNo.StartsWith("3000") = True Then
                                    AppNo = TagNo.Substring(4, 10)
                                End If
                                If TagNo.StartsWith("1800") = True Then
                                    AppNo = TagNo.Substring(4, 10)
                                End If
                            ElseIf TagNo.Length = 10 Then
                                AppNo = TagNo
                            End If

                            If AppNo.Length = 10 Then
                                Dim dr As DataRow = dt.NewRow
                                dr("tag_no") = TagNo
                                dr("app_no") = AppNo
                                dt.Rows.Add(dr)
                            End If
                        End If
                    End While

                    If dt.Rows.Count > 0 Then
                        dgTextData.DataSource = dt
                    End If
                Catch ex As Exception
                Finally
                    sr.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub dgTextData_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgTextData.EditingControlShowing
        Dim txtGridviewEdit As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
        AddHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
    End Sub
    Private Sub txtGridviewEdit_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Test for numeric value or backspace in first column
        'If dtgtaophieunhapxuat.CurrentCell.ColumnIndex = 0 Then
        If IsNumeric(e.KeyChar.ToString()) Or e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = False 'if numeric display
        Else
            e.Handled = True  'if non numeric don't display
        End If
        'End If
    End Sub


    Private Function GetLocationID(ByVal MsRoomID As Long) As Long
        Dim ret As Long = 0
        Dim dt As New DataTable
        Try
            Dim sql As String = "select fc.id "
            sql += " from TB_FILELOCATION fc "
            sql += " where fc.ms_room_id='" & MsRoomID & "'"
            dt = GlobalFunction.GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                ret = Convert.ToInt64(dt.Rows(0)("id"))
            End If
        Catch ex As Exception
            ret = 0
        End Try
        Return ret
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If dgTextData.RowCount = 0 Then
            MessageBox.Show("ไม่พบข้อมูล")
            Exit Sub
        End If

        Dim LocationID As Long = GetLocationID(cbLocation.SelectedValue)
        Dim fInfo As New FileInfo(txtTextFile.Text)
        Dim fName As String = fInfo.Name
        Dim mDate As String = fName.Substring(0, 4) & "-" & fName.Substring(4, 2) & "-" & fName.Substring(6, 2) & " " & fName.Substring(8, 2) & ":" & fName.Substring(10, 2) & ":" & fName.Substring(12, 2)


        For Each gv As DataGridViewRow In dgTextData.Rows
            Dim AppNo As String = gv.Cells("colAppNo").Value
            'Update TB_REQUISITION
            Dim strSQL As String = " UPDATE TB_REQUISTION "
            strSQL += " SET updateby='Update Location',updateon='" & mDate & "',filelocation = " & LocationID
            strSQL &= " WHERE APP_NO ='" & AppNo & "'; " & vbNewLine & vbNewLine

            'Update TS_FILE_CURRENT_LOCATION
            Dim Sql As String = " select id, ms_room_id "
            Sql += " from TS_FILE_CURRENT_LOCATION"
            Sql += " where app_no='" & AppNo & "'"
            Dim Fdt As DataTable = GlobalFunction.GetDatatable(Sql)
            Dim IsInsertHis As Boolean = False
            If Fdt.Rows.Count > 0 Then
                strSQL += " UPDATE TS_FILE_CURRENT_LOCATION" & vbNewLine
                strSQL += " set updated_by='Update Location' , updated_date=getdate() " & vbNewLine
                strSQL += " , move_date='" & mDate & "'" & vbNewLine
                strSQL += " , readerid=0,rssi=0,ant_port_number=1 " & vbNewLine
                strSQL += " , location_name = '" & cbLocation.Text & "'" & vbNewLine
                strSQL += " , ms_room_id = '" & cbLocation.SelectedValue & "'" & vbNewLine
                strSQL += " , tb_officer_id=0, officer_name='', ms_desktop_id=0, desk_name=''" & vbNewLine
                strSQL += " where app_no='" & AppNo & "';" & vbNewLine & vbNewLine

                IsInsertHis = True
            Else
                strSQL += " INSERT INTO TS_FILE_CURRENT_LOCATION(created_by,created_date,app_no" & vbNewLine
                strSQL += " ,move_date,ReaderID,rssi,ant_port_number,location_name,ms_room_id" & vbNewLine
                strSQL += " ,tb_officer_id,officer_name,ms_desktop_id,desk_name)" & vbNewLine
                strSQL += " VALUES('Update Location',getdate(),'" & AppNo & "'," & vbNewLine
                strSQL += " '" & mDate & "',0,0,1,'" & cbLocation.Text & "','" & cbLocation.SelectedValue & "'" & vbNewLine
                strSQL += " ,0,'',0,'');" & vbNewLine & vbNewLine

                IsInsertHis = True
            End If

            If IsInsertHis = True Then
                Sql = "select id, ms_room_id "
                Sql += " from TS_FILE_MOVE_HISTORY "
                Sql += " where app_no='" + AppNo + "'"
                Sql += " order by id desc"
                Dim hDt As DataTable = GlobalFunction.GetDatatable(Sql)
                If hDt.Rows.Count > 0 Then
                    If cbLocation.SelectedValue = Convert.ToInt64(hDt.Rows(0)("ms_room_id")) Then
                        IsInsertHis = False
                    End If
                End If
                hDt.Dispose()

                If IsInsertHis = True Then
                    strSQL += " INSERT INTO TS_FILE_MOVE_HISTORY(created_by,created_date,app_no" & vbNewLine
                    strSQL += " ,move_date,ReaderID,rssi,ant_port_number,location_name,ms_room_id" & vbNewLine
                    strSQL += " ,tb_officer_id,officer_name,ms_desktop_id,desk_name " & vbNewLine
                    strSQL += " ,ms_grid_layout_id, grid_row, grid_col, is_update_current_location)" & vbNewLine
                    strSQL += " VALUES('Update Location',getdate(),'" & AppNo & "'" & vbNewLine
                    strSQL += " ,'" & mDate & "',0,0,1,'" & cbLocation.Text & "','" & cbLocation.SelectedValue & "'" & vbNewLine
                    strSQL += " ,0,'',0,''" & vbNewLine
                    strSQL += " ,0,0,0,'Y');" & vbNewLine & vbNewLine
                End If
            End If

            If strSQL.Trim <> "" Then
                If GlobalFunction.ExecuteNonQuery(strSQL, Nothing) = False Then
                    Engine.LogFile.LogENG.SaveErrLog("frmUpdateCurrentLocationFromTextFile.btnSave_Click", "Error Update Last Location ### " & vbNewLine & "FileName=" & fInfo.FullName & vbNewLine & strSQL)
                    MessageBox.Show("Error Update Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim dt As New DataTable
                    dt.Columns.Add("tag_no")
                    dt.Columns.Add("app_no")

                    dgTextData.DataSource = dt
                    txtTextFile.Text = ""
                    MessageBox.Show("Update Complete")
                End If
            End If
        Next

        
    End Sub

    Private Sub txtTextFile_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTextFile.KeyDown
        e.Handled = True
    End Sub

    Private Sub txtTextFile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTextFile.KeyPress
        e.Handled = True
    End Sub

End Class
