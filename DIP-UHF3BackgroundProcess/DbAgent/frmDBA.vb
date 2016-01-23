Imports DbAgent.Org.Mentalis.Files
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading


Public Class frmDBA

    Sub uplog(ByVal argTXT As String)
        'If argTXT.Trim <> "" Then
        '    If txtLog.Text.Length > 20000 Then
        '        WriteLogFile(txtLog)
        '        txtLog.Text = ""
        '    End If
        '    txtLog.Text &= Now & vbTab & argTXT & vbCrLf
        '    txtLog.SelectionStart = Len(txtLog.Text)
        '    txtLog.ScrollToCaret()
        'End If
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        btnStop.Enabled = True
        tlActive.Image = frmMain.imgLst.Images("active")
        statusBar.Text = "Begin Transection..."

        If (Not bw1.IsBusy) And chkInclude1.Checked Then
            bw1.RunWorkerAsync()
        End If

        If (Not bw2.IsBusy) And chkInclude2.Checked Then
            bw2.RunWorkerAsync()
        End If

        If (Not bw3.IsBusy) And chkInclude3.Checked Then
            bw3.RunWorkerAsync()
        End If

        If (Not bw4.IsBusy) And chkInclude4.Checked Then
            bw4.RunWorkerAsync()
        End If

        If (Not bw5.IsBusy) And chkInclude5.Checked Then
            bw5.RunWorkerAsync()
        End If

        If (Not bw6.IsBusy) And chkInclude6.Checked Then
            bw6.RunWorkerAsync()
        End If

        If (Not bw7.IsBusy) And chkInclude7.Checked Then
            bw7.RunWorkerAsync()
        End If

        If (Not bw8.IsBusy) And chkInclude8.Checked Then
            bw8.RunWorkerAsync()
        End If

        If (Not bw9.IsBusy) And chkInclude9.Checked Then
            bw9.RunWorkerAsync()
        End If

        If (Not bw10.IsBusy) And chkInclude10.Checked Then
            bw10.RunWorkerAsync()
        End If

    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Dim ini As New IniReader(INIfName)
        CancelThread()
        ini.Section = "SETTING"
        ini.Write("state", "0")
        btnStart.Enabled = True
        btnStop.Enabled = False
    End Sub

    Private Sub CancelThread()
        If Not bw1.CancellationPending Then
            Try
                bw1.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw2.CancellationPending Then
            Try
                bw2.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw3.CancellationPending Then
            Try
                bw3.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw4.CancellationPending Then
            Try
                bw4.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw5.CancellationPending Then
            Try
                bw5.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw6.CancellationPending Then
            Try
                bw6.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw7.CancellationPending Then
            Try
                bw7.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw8.CancellationPending Then
            Try
                bw8.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw9.CancellationPending Then
            Try
                bw9.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        If Not bw10.CancellationPending Then
            Try
                bw10.CancelAsync()
            Catch ex As Exception

            End Try
        End If

        tlActive.Image = frmMain.imgLst.Images("noActivity")
    End Sub

    Private Sub frmDBA_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CancelThread()
    End Sub

    Private Sub frmDBA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StrconnInnova = GetConnectionString(1)
        StrconnScore = GetConnectionString(2)
        checkAll(True)
        btnStart_Click(sender, e)
        Timer1.Start()
    End Sub

    Private Sub checkAll(Optional ByVal b As Boolean = True)
        chkInclude1.Checked = b
        chkInclude2.Checked = b
        chkInclude3.Checked = b
        chkInclude4.Checked = b
        chkInclude5.Checked = b
        chkInclude6.Checked = b
        chkInclude7.Checked = b
        chkInclude8.Checked = b
        chkInclude9.Checked = b
        chkInclude10.Checked = b
    End Sub

    Private Function isThreadAlive() As Boolean
        Return bw1.IsBusy Or bw2.IsBusy Or bw3.IsBusy Or bw4.IsBusy Or bw5.IsBusy Or bw6.IsBusy Or bw7.IsBusy Or bw8.IsBusy Or bw9.IsBusy Or bw10.IsBusy
    End Function

    '==================
    Private Sub bw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw1.DoWork
        e.Result = Me.backgrounInsertPosition


        'ฝากไว้ให้รันที่นี่ก่อน
        e.Result = Me.backgrounInsertStatus
        e.Result = Me.backgrounUpdateStatus
        e.Result = Me.backgrounInsertFileLocation
        e.Result = Me.backgrounUpdateFileLocation
        e.Result = Me.backgrounInsertFileStore
        e.Result = Me.backgrounUpdateFileStore
    End Sub
    Private Sub bw1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw1.ProgressChanged
        pg1.Value = e.ProgressPercentage
        lblPct1.Text = pg1.Value & "%"
    End Sub
    Private Sub bw1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted
        uplog(e.Result)

        pg1.Value = 0
        lblPct1.Text = pg1.Value & "%"
        bw1.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw2.DoWork
        e.Result = Me.backgrounUpdatePosition
    End Sub
    Private Sub bw2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw2.ProgressChanged
        pg2.Value = e.ProgressPercentage
        lblPct2.Text = pg2.Value & "%"
    End Sub
    Private Sub bw2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw2.RunWorkerCompleted
        uplog(e.Result)

        pg2.Value = 0
        lblPct2.Text = pg2.Value & "%"
        bw2.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw3.DoWork
        e.Result = Me.backgrounInsertDepartment
    End Sub
    Private Sub bw3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw3.ProgressChanged
        pg3.Value = e.ProgressPercentage
        lblPct3.Text = pg3.Value & "%"
    End Sub
    Private Sub bw3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw3.RunWorkerCompleted
        uplog(e.Result)

        pg3.Value = 0
        lblPct3.Text = pg3.Value & "%"
        bw3.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw4_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw4.DoWork
        e.Result = Me.backgrounUpdateDepartment
    End Sub
    Private Sub bw4_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw4.ProgressChanged
        pg4.Value = e.ProgressPercentage
        lblPct4.Text = pg4.Value & "%"
    End Sub
    Private Sub bw4_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw4.RunWorkerCompleted
        uplog(e.Result)

        pg4.Value = 0
        lblPct4.Text = pg4.Value & "%"
        bw4.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw5_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw5.DoWork
        e.Result = Me.backgrounInsertOfficer
    End Sub
    Private Sub bw5_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw5.ProgressChanged
        pg5.Value = e.ProgressPercentage
        lblPct5.Text = pg5.Value & "%"
    End Sub
    Private Sub bw5_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw5.RunWorkerCompleted
        uplog(e.Result)

        pg5.Value = 0
        lblPct5.Text = pg5.Value & "%"
        bw5.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw6_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw6.DoWork
        e.Result = Me.backgrounUpdateOfficer
    End Sub
    Private Sub bw6_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw6.ProgressChanged
        pg6.Value = e.ProgressPercentage
        lblPct6.Text = pg6.Value & "%"
    End Sub
    Private Sub bw6_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw6.RunWorkerCompleted
        uplog(e.Result)

        pg6.Value = 0
        lblPct6.Text = pg6.Value & "%"
        bw6.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw7_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw7.DoWork
        e.Result = Me.backgrounInsertRequisition
    End Sub
    Private Sub bw7_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw7.ProgressChanged
        pg7.Value = e.ProgressPercentage
        lblPct7.Text = pg7.Value & "%"
    End Sub
    Private Sub bw7_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw7.RunWorkerCompleted
        uplog(e.Result)

        pg7.Value = 0
        lblPct7.Text = pg7.Value & "%"
        bw7.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw8_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw8.DoWork
        e.Result = Me.backgrounUpdateRequisition
    End Sub
    Private Sub bw8_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw8.ProgressChanged
        pg8.Value = e.ProgressPercentage
        lblPct8.Text = pg8.Value & "%"
    End Sub
    Private Sub bw8_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw8.RunWorkerCompleted
        uplog(e.Result)

        pg8.Value = 0
        lblPct8.Text = pg8.Value & "%"
        bw8.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw9_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw9.DoWork
        e.Result = Me.backgrounInsertFileBorrowItem
    End Sub
    Private Sub bw9_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw9.ProgressChanged
        pg9.Value = e.ProgressPercentage
        lblPct9.Text = pg9.Value & "%"
    End Sub
    Private Sub bw9_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw9.RunWorkerCompleted
        uplog(e.Result)

        pg9.Value = 0
        lblPct9.Text = pg9.Value & "%"
        bw9.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub bw10_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bw10.DoWork
        e.Result = Me.backgrounUpdateFileBorrowItem
    End Sub
    Private Sub bw10_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bw10.ProgressChanged
        pg10.Value = e.ProgressPercentage
        lblPct10.Text = pg10.Value & "%"
    End Sub
    Private Sub bw10_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw10.RunWorkerCompleted
        uplog(e.Result)

        pg10.Value = 0
        lblPct10.Text = pg10.Value & "%"
        bw10.Dispose()
        If Not isThreadAlive() Then
            statusBar.Text = "Ready"
            tlActive.Image = frmMain.imgLst.Images("noActivity")
        End If
    End Sub
    '==================
    Private Sub chkCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'checkAll(chkCheckAll.Checked)
    End Sub

    Private Sub chkInclude_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInclude1.CheckedChanged, chkInclude2.CheckedChanged, chkInclude3.CheckedChanged, chkInclude4.CheckedChanged, chkInclude5.CheckedChanged, chkInclude6.CheckedChanged, chkInclude7.CheckedChanged, chkInclude8.CheckedChanged, chkInclude9.CheckedChanged, chkInclude10.CheckedChanged
        Dim Obj As CheckBox = sender
        'chkCheckAll.Checked = chkInclude1.Checked And chkInclude3.Checked 'And chkInclude3.Checked

        '------------Update ini--------------
        Dim ini As New IniReader(INIfName)
        ini.Section = "SETTING"
        Dim ObjNo As Integer = Int(Val(Replace(Obj.Name, "chkInclude", "")))
        ini.Write("worker" & ObjNo, Math.Abs(CInt(Obj.Checked)))
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtLog.Text = ""
    End Sub

    Function GetNewId(ByVal TbName As String, ByVal FieldName As String) As Int64
        Dim NewId As Int64
        Dim Conn As New SqlConnection
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Conn.ConnectionString = StrconnScore
        Conn.Open()
        sql = "select isnull(max(" & FieldName & ") + 1,1) as NewId from " & TbName
        da = New SqlDataAdapter(sql, StrconnScore)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            NewId = dt.Rows(0).Item("NewId").ToString
        Else
            NewId = 1
        End If
        Conn.Dispose()
        Return NewId
    End Function

    Function GetIdAPP_NO(ByVal APP_NO As String) As Int64
        Dim NewId As Int64 = 0
        Dim Conn As New SqlConnection
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Conn.ConnectionString = StrconnScore
        Conn.Open()
        sql = "select ID from TB_REQUISTION where rtrim(ltrim(app_no)) = '" & Trim(APP_NO) & "'"
        da = New SqlDataAdapter(sql, StrconnScore)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            NewId = dt.Rows(0).Item("ID").ToString
        End If
        Conn.Dispose()
        Return NewId
    End Function

    Function CheckStatusFile(ByVal APP_NO As String) As Boolean
        Dim ret As Boolean = False
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim sql As String = ""
        sql = "EXEC CHECKFILESTATUS " & APP_NO
        da = New SqlDataAdapter(sql, StrconnScore)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            ret = True
        End If
        Return ret
    End Function

#Region "ConnectDatabase"

    Public Structure EXESQL
        Dim STATUS As Boolean
        Dim EX As String
    End Structure

    Public Function executeSQL(ByVal sql As String) As EXESQL
        ' Try
        Dim Conn As New SqlConnection(StrconnScore)
        Try
            Conn.Open()
        Catch ex As Exception
            executeSQL.EX = ex.Message
            executeSQL.STATUS = False
        End Try

        If sql.Trim <> "" Then
            Dim cmd As New SqlCommand(sql)
            cmd.Connection = Conn
            Try
                cmd.ExecuteNonQuery()
                executeSQL.STATUS = True
                executeSQL.EX = ""
            Catch ex As Exception
                executeSQL.STATUS = False
                executeSQL.EX = ex.Message
            End Try
        Else
            executeSQL.STATUS = False
            executeSQL.EX = "EMPTY SQL!"
        End If
        Conn.Close()
        Conn.Dispose()
    End Function

    Private Function GetScoreDatatable(sql As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter(sql, StrconnScore)
            da.Fill(dt)
        Catch ex As Exception
            dt = New DataTable
        End Try
        Return dt
    End Function

#End Region

    Private Function backgrounInsertPosition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask1.ForeColor
        lblTask1.ForeColor = Color.Red

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as position_code,position_name from TB_POSITION"
        Dim sqlInnova As String = "exec POSITION"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "position_code", "position_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "position_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New Position."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_POSITION(id,position_code,position_name,createby,createon) values('" & dtTemp.Rows(i).Item("position_code").ToString & "','" & dtTemp.Rows(i).Item("position_code").ToString & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("position_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("position_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        '' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask1.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[New Position.]" & vbTab & vbTab & txtStatus
    End Function

    Private Function backgrounUpdatePosition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask2.ForeColor
        lblTask2.ForeColor = Color.Red

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as position_code,position_name from TB_POSITION"
        Dim sqlInnova As String = "exec POSITION"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "position_code", "position_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw2.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "isnull(position_name_Second,'') <> '' and position_name <> position_name_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update Position."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_POSITION set "
                    sql &= "position_name = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("position_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("position_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id ='" & dtTemp.Rows(i).Item("position_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw2.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        '' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask2.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[Update Position.]" & vbTab & txtStatus
    End Function

    Private Function backgrounInsertDepartment() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask3.ForeColor
        lblTask3.ForeColor = Color.Red

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as department_code,department_name from TB_DEPARTMENT"
        Dim sqlInnova As String = "exec WORKGROUP"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "department_code", "department_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw3.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "department_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New Department."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_DEPARTMENT(id,department_code,department_name,createby,createon) values('" & dtTemp.Rows(i).Item("department_code").ToString & "','" & dtTemp.Rows(i).Item("department_code").ToString & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("department_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("department_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw3.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask3.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[New Department.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateDepartment() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask4.ForeColor
        lblTask4.ForeColor = Color.Red

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as department_code,department_name from TB_DEPARTMENT"
        Dim sqlInnova As String = "exec WORKGROUP"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "department_code", "department_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw4.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "department_code_Second is not null and department_name <> department_name_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update Department."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_DEPARTMENT set "
                    sql &= "department_name = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("department_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("department_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id ='" & dtTemp.Rows(i).Item("department_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw4.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask4.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[Update Department.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertOfficer() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask5.ForeColor
        lblTask5.ForeColor = Color.Red

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as officer_no,title_id,fname,lname,department_id,position_id  from TB_OFFICER"
        Dim sqlInnova As String = "exec OFFICER"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "officer_no", "officer_no")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw5.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "officer_no_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New Officer."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_OFFICER(id,officer_no,fname,lname,department_id,position_id,title_id,email,createby,createon) "
                    sql += " values('" & dtTemp.Rows(i).Item("officer_no").ToString & "','" & dtTemp.Rows(i).Item("officer_no").ToString & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("fname")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("fname").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("lname")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("lname").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("department_id")) Then sql &= "'" & dtTemp.Rows(i).Item("department_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("position_id")) Then sql &= "'" & dtTemp.Rows(i).Item("position_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("title_id")) Then sql &= "'" & dtTemp.Rows(i).Item("title_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("email")) Then sql += "'" & dtTemp.Rows(i).Item("email").ToString & vbNewLine Else sql += "Null," & vbNewLine
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw5.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask5.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[New Officer.]" & vbTab & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateOfficer() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask6.ForeColor
        lblTask6.ForeColor = Color.Red

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as officer_no,title_id,fname,lname,department_id,position_id,email  from TB_OFFICER"
        Dim sqlInnova As String = "exec OFFICER"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "officer_no", "officer_no")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw6.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "officer_no_Second is not null and ((fname <> fname_second) or (lname <> lname_second) or (title_id <> title_id_second) or (department_id <> department_id_second) or (position_id <> position_id_second) or (email <> email_second))"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update Officer."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_OFFICER set fname = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("fname")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("fname").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "lname = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("lname")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("lname").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "department_id = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("department_id")) Then sql &= "'" & dtTemp.Rows(i).Item("department_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "position_id = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("position_id")) Then sql &= "'" & dtTemp.Rows(i).Item("position_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "title_id = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("title_id")) Then sql &= "'" & dtTemp.Rows(i).Item("title_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "email = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("email")) Then sql &= "'" & dtTemp.Rows(i).Item("email").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id = '" & dtTemp.Rows(i).Item("officer_no").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw6.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask6.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[Updeat Officer.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertRequisition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask7.ForeColor
        lblTask7.ForeColor = Color.Red

        Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
        Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
        Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")
        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct app_no from TB_REQUISTION "
        Dim sqlInnova As String = "exec REQUISITION '" & yy1 & "','" & yy2 & "','" & yy3 & "'"
        'Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION"
        'Dim sqlInnova As String = "exec REQUISITION NULL,NULL"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
            Dim cmd As New SqlCommand(sql)
            cmd.Connection = ConnScore
            cmd.CommandTimeout = 10000
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw7.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        If dtInnova.Rows.Count > 0 Then
            txtStatus &= dtInnova.Rows.Count & " New Requisition."
            Dim TotalAdd As Integer = dtInnova.Rows.Count
            Dim cnt As Integer = 0
            Dim NewId As Int64 = 0
            NewId = GetNewId("TB_REQUISTION", "id")

            For i As Integer = 0 To dtInnova.Rows.Count - 1
                Application.DoEvents()
                Try
                    dtScore.DefaultView.RowFilter = "app_no='" & dtInnova.Rows(i)("app_no") & "'"
                    If dtScore.DefaultView.Count = 0 Then
                        Dim CreateBy As String = "null"
                        Dim CreateOn As String = "null"
                        Dim SysSubmitDate As String = "null"
                        Dim FrmSubmitDate As String = "null"
                        Dim ReceiveDate As String = "null"
                        Dim PublicDate As String = "null"
                        Dim AppSubmitDate As String = "null"
                        Dim LeaveDate As String = "null"
                        Dim EjectDate As String = "null"
                        Dim CancelDate As String = "null"
                        Dim RecoverDate As String = "null"
                        Dim FormType As String = "null"
                        Dim AppStatus As String = "null"

                        If Convert.IsDBNull(dtInnova.Rows(i)("createby")) = False Then
                            CreateBy = "'" & dtInnova.Rows(i)("createby") & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("createon")) = False Then
                            CreateOn = "'" & Convert.ToDateTime(dtInnova.Rows(i)("createon")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("sys_submit_date")) = False Then
                            SysSubmitDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("sys_submit_date")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If

                        If Convert.IsDBNull(dtInnova.Rows(i)("FRM_SUBMIT_DATE")) = False Then
                            FrmSubmitDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("FRM_SUBMIT_DATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("RECEIVE_DATE")) = False Then
                            ReceiveDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("RECEIVE_DATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("PUBLICDATE")) = False Then
                            PublicDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("PUBLICDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("APP_SUBMIT_DATE")) = False Then
                            AppSubmitDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("APP_SUBMIT_DATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("LEAVEDATE")) = False Then
                            LeaveDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("LEAVEDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("EJECTDATE")) = False Then
                            EjectDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("EJECTDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("CANCELDATE")) = False Then
                            CancelDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("CANCELDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("RECOVERDATE")) = False Then
                            RecoverDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("RECOVERDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("FORMTYPE")) = False Then
                            FormType = "'" & dtInnova.Rows(i)("FORMTYPE") & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("app_status")) = False Then
                            AppStatus = "'" & dtInnova.Rows(i)("app_status") & "'"
                        End If

                        sql = "insert into TB_REQUISTION(id,app_no,[app_name],patent_type_id,qty,createby,createon,sys_submit_date,"
                        sql += "FRM_SUBMIT_DATE, RECEIVE_DATE,PUBLICDATE,APP_SUBMIT_DATE,LEAVEDATE,EJECTDATE,CANCELDATE,RECOVERDATE,pct,pct_no,formtype,app_status)"
                        sql += " values('" & NewId & "','" & dtInnova.Rows(i).Item("app_no") & "',"
                        If Not IsDBNull(dtInnova.Rows(i).Item("app_name")) Then sql &= "'" & fixData(dtInnova.Rows(i).Item("app_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                        If Not IsDBNull(dtInnova.Rows(i).Item("patent_type_id")) Then sql &= "'" & dtInnova.Rows(i).Item("patent_type_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                        sql &= "1," & CreateBy & "," & CreateOn & "," & SysSubmitDate & "," & FrmSubmitDate & "," & ReceiveDate & "," & PublicDate & ","
                        sql += AppSubmitDate & "," & LeaveDate & "," & EjectDate & "," & CancelDate & "," & RecoverDate & ",'" & fixData(dtInnova.Rows(i).Item("pct").ToString) & "','" & fixData(dtInnova.Rows(i).Item("pctno").ToString) & "'," & FormType & "," & AppStatus & ")"

                        Ret = executeSQL(sql)
                        If Ret.STATUS = True Then
                            sql = "insert into TS_REQUISITION_TAG(created_by,created_date,tb_requisition_id,tag_no)"
                            sql += " values('DbAgent',getdate(),'" & NewId & "','" & dtInnova.Rows(i).Item("app_no") & "')"
                            Ret = executeSQL(sql)
                            If Ret.STATUS = False Then
                                txtStatus &= Ret.EX & vbCrLf
                            End If
                        Else
                            txtStatus &= Ret.EX & vbCrLf
                        End If
                        NewId += 1
                    End If

                    cnt += 1
                    bw7.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If        
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask7.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[New Requisition.]" & vbTab & txtStatus

    End Function

    '    Private Function backgrounInsertRequisition() As String
    '        CheckForIllegalCrossThreadCalls = False
    '        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

    '        Dim tmpc As New Color
    '        tmpc = lblTask7.ForeColor
    '        lblTask7.ForeColor = Color.Red

    '        Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
    '        Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
    '        Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")
    '        Dim txtStatus As String = ""
    '        Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION where app_no like '" & yy1 & "%' or app_no like '" & yy2 & "%' or app_no like '" & yy3 & "%'"
    '        Dim sqlInnova As String = "exec REQUISITION '" & yy1 & "','" & yy2 & "','" & yy3 & "'"
    '        'Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION"
    '        'Dim sqlInnova As String = "exec REQUISITION NULL,NULL"
    '        Dim dtInnova As New DataTable
    '        Dim dtScore As New DataTable
    '        Dim dtCompare As New DataTable
    '        Dim dtTemp As New DataTable
    '        Dim sql As String = ""
    '        Dim da As New SqlDataAdapter
    '        Dim ConnScore As New SqlConnection
    '        Dim Ret As New EXESQL

    '        Try
    '            ConnScore.ConnectionString = StrconnScore
    '            ConnScore.Open()
    '            Dim cmd As New SqlCommand(sql)
    '            cmd.Connection = ConnScore
    '            cmd.CommandTimeout = 10000
    '        Catch ex As Exception
    '            txtStatus &= ex.Message & vbCrLf
    '            ConnScore.Dispose()
    '            Return "Connection Problem."
    '        End Try
    '        'ConnScore.Dispose()

    '        Try
    '            da = New SqlDataAdapter(sqlInnova, StrconnScore)
    '            da.Fill(dtInnova)
    '            da = New SqlDataAdapter(sqlScore, StrconnScore)
    '            da.Fill(dtScore)
    '            dtCompare = LeftJoin(dtInnova, dtScore, "app_no", "app_no")
    '        Catch ex As Exception
    '            txtStatus &= ex.Message & vbCrLf
    '            GoTo FinalDestination
    '        End Try

    '        If bw7.CancellationPending Then
    '            txtStatus &= "Canceled by User"
    '            GoTo FinalDestination
    '        End If

    '        ' *************** Insert ***************
    '        dtCompare.DefaultView.RowFilter = "app_no_Second is null"
    '        If dtCompare.DefaultView.Count > 0 Then
    '            dtTemp = dtCompare.DefaultView.ToTable
    '            txtStatus &= dtTemp.Rows.Count & " New Requisition."
    '            Dim TotalAdd As Integer = dtTemp.Rows.Count
    '            Dim cnt As Integer = 0
    '            Dim NewId As Int64 = 0
    '            NewId = GetNewId("TB_REQUISTION", "id")

    '            For i As Int32 = 0 To dtTemp.Rows.Count - 1
    '                Application.DoEvents()
    '                Try
    '                    Dim SysSubmitDate As String = "null"
    '                    If Convert.IsDBNull(dtTemp.Rows(i)("sys_submit_date")) = False Then
    '                        SysSubmitDate = "'" & Convert.ToDateTime(dtTemp.Rows(i)("sys_submit_date")).ToString("yyyy-MM-dd HH:mm:ss.fff") & "'"
    '                    End If


    '                    sql = "insert into TB_REQUISTION(id,app_no,[app_name],patent_type_id,qty,createby,createon,sys_submit_date) values('" & NewId & "','" & dtTemp.Rows(i).Item("app_no") & "',"
    '                    If Not IsDBNull(dtTemp.Rows(i).Item("app_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("app_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
    '                    If Not IsDBNull(dtTemp.Rows(i).Item("patent_type_id")) Then sql &= "'" & dtTemp.Rows(i).Item("patent_type_id").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
    '                    sql &= "1,'DbAgent',getdate()," & SysSubmitDate & ")"

    '                    Ret = executeSQL(sql)
    '                    If Not Ret.STATUS Then
    '                        txtStatus &= Ret.EX & vbCrLf
    '                    End If

    '                    NewId += 1
    '                    cnt += 1
    '                    bw7.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
    '                    Threading.Thread.Sleep(5)
    '                Catch ex As Exception
    '                    txtStatus &= ex.Message & vbCrLf
    '                End Try
    '            Next
    '        End If
    '        ' **************************************

    'FinalDestination:

    '        If txtStatus = "" Then txtStatus = "Empty"
    '        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

    '        lblTask7.ForeColor = Color.DarkBlue
    '        tmpc = Nothing
    '        Return "[New Requisition.]" & vbTab & txtStatus

    '    End Function
    '    Private Function backgrounUpdateRequisition() As String
    '        CheckForIllegalCrossThreadCalls = False
    '        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

    '        Dim tmpc As New Color
    '        tmpc = lblTask8.ForeColor
    '        lblTask8.ForeColor = Color.Red

    '        Dim txtStatus As String = ""
    '        Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
    '        Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
    '        Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")

    '        Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION where app_no like '" & yy1 & "%' or app_no like '" & yy2 & "%' or app_no like '" & yy3 & "%'"
    '        Dim sqlInnova As String = "exec REQUISITION '" & yy1 & "','" & yy2 & "','" & yy3 & "'"
    '        'Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION"
    '        'Dim sqlInnova As String = "exec REQUISITION NULL,NULL,NULL"
    '        Dim dtInnova As New DataTable
    '        Dim dtScore As New DataTable
    '        Dim dtCompare As New DataTable
    '        Dim dtTemp As New DataTable
    '        Dim sql As String = ""
    '        Dim da As New SqlDataAdapter
    '        Dim ConnScore As New SqlConnection
    '        Dim Ret As New EXESQL

    '        Try
    '            ConnScore.ConnectionString = StrconnScore
    '            ConnScore.Open()
    '        Catch ex As Exception
    '            txtStatus &= ex.Message & vbCrLf
    '            ConnScore.Dispose()
    '            Return "Connection Problem."
    '        End Try
    '        ConnScore.Dispose()

    '        Try
    '            da = New SqlDataAdapter(sqlInnova, StrconnScore)
    '            da.Fill(dtInnova)
    '            da = New SqlDataAdapter(sqlScore, StrconnScore)
    '            da.Fill(dtScore)
    '            dtCompare = LeftJoin(dtInnova, dtScore, "app_no", "app_no")
    '        Catch ex As Exception
    '            txtStatus &= ex.Message & vbCrLf
    '            GoTo FinalDestination
    '        End Try

    '        If bw8.CancellationPending Then
    '            txtStatus &= "Canceled by User"
    '            GoTo FinalDestination
    '        End If

    '        ' *************** Update ***************
    '        dtCompare.DefaultView.RowFilter = "app_no_Second is not null and app_name <> app_name_Second and patent_type_id <> patent_type_id_Second"
    '        If dtCompare.DefaultView.Count > 0 Then
    '            dtTemp = dtCompare.DefaultView.ToTable
    '            txtStatus &= dtTemp.Rows.Count & " Update Requisition."
    '            Dim TotalAdd As Integer = dtTemp.Rows.Count
    '            Dim cnt As Integer = 0
    '            Dim NewId As Int64 = 0

    '            For i As Int32 = 0 To dtTemp.Rows.Count - 1
    '                Application.DoEvents()
    '                Try
    '                    Dim SysSubmitDate As String = Convert.ToDateTime(dtCompare.Rows(i)("sys_submit_date")).ToString("yyyy-MM-dd HH:mm:ss.fff")
    '                    sql = "update TB_REQUISTION set app_name = " & vbNewLine
    '                    If Not IsDBNull(dtTemp.Rows(i).Item("app_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("app_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
    '                    sql &= "patent_type_id = " & vbNewLine
    '                    If Not IsDBNull(dtTemp.Rows(i).Item("patent_type_id")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("patent_type_id").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
    '                    sql &= "updateby = 'DbAgent',updateon = getdate(), "
    '                    sql &= "sys_submit_date='" & SysSubmitDate & "'"
    '                    sql &= " where app_no = '" & dtTemp.Rows(i).Item("app_no") & "'"

    '                    Ret = executeSQL(sql)
    '                    If Not Ret.STATUS Then
    '                        txtStatus &= Ret.EX & vbCrLf
    '                    End If

    '                    NewId += 1
    '                    cnt += 1
    '                    bw8.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
    '                    Threading.Thread.Sleep(5)
    '                Catch ex As Exception
    '                    txtStatus &= ex.Message & vbCrLf
    '                End Try
    '            Next
    '        End If
    '        ' **************************************

    'FinalDestination:

    '        If txtStatus = "" Then txtStatus = "Empty"
    '        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

    '        lblTask8.ForeColor = Color.DarkBlue
    '        tmpc = Nothing
    '        Return "[Update Requisition.]" & vbTab & txtStatus

    '    End Function

    '    Private Function backgrounUpdateRequisition() As String
    '        CheckForIllegalCrossThreadCalls = False
    '        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

    '        Dim tmpc As New Color
    '        tmpc = lblTask8.ForeColor
    '        lblTask8.ForeColor = Color.Red

    '        Dim txtStatus As String = ""
    '        Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
    '        Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
    '        Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")

    '        Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION where app_no like '" & yy1 & "%' or app_no like '" & yy2 & "%' or app_no like '" & yy3 & "%'"
    '        Dim sqlInnova As String = "exec REQUISITION '" & yy1 & "','" & yy2 & "','" & yy3 & "'"
    '        'Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION"
    '        'Dim sqlInnova As String = "exec REQUISITION NULL,NULL,NULL"
    '        Dim dtInnova As New DataTable
    '        Dim dtScore As New DataTable
    '        Dim dtCompare As New DataTable
    '        Dim dtTemp As New DataTable
    '        Dim sql As String = ""
    '        Dim da As New SqlDataAdapter
    '        Dim ConnScore As New SqlConnection
    '        Dim Ret As New EXESQL

    '        Try
    '            ConnScore.ConnectionString = StrconnScore
    '            ConnScore.Open()
    '        Catch ex As Exception
    '            txtStatus &= ex.Message & vbCrLf
    '            ConnScore.Dispose()
    '            Return "Connection Problem."
    '        End Try
    '        ConnScore.Dispose()

    '        Try
    '            da = New SqlDataAdapter(sqlInnova, StrconnScore)
    '            da.Fill(dtInnova)
    '            da = New SqlDataAdapter(sqlScore, StrconnScore)
    '            da.Fill(dtScore)
    '            dtCompare = LeftJoin(dtInnova, dtScore, "app_no", "app_no")
    '        Catch ex As Exception
    '            txtStatus &= ex.Message & vbCrLf
    '            GoTo FinalDestination
    '        End Try

    '        If bw8.CancellationPending Then
    '            txtStatus &= "Canceled by User"
    '            GoTo FinalDestination
    '        End If

    '        ' *************** Update ***************
    '        dtCompare.DefaultView.RowFilter = "app_no_Second is not null and app_name <> app_name_Second and patent_type_id <> patent_type_id_Second"
    '        If dtCompare.DefaultView.Count > 0 Then
    '            dtTemp = dtCompare.DefaultView.ToTable
    '            txtStatus &= dtTemp.Rows.Count & " Update Requisition."
    '            Dim TotalAdd As Integer = dtTemp.Rows.Count
    '            Dim cnt As Integer = 0
    '            Dim NewId As Int64 = 0

    '            For i As Int32 = 0 To dtTemp.Rows.Count - 1
    '                Application.DoEvents()
    '                Try
    '                    Dim SysSubmitDate As String = Convert.ToDateTime(dtCompare.Rows(i)("sys_submit_date")).ToString("yyyy-MM-dd HH:mm:ss.fff")
    '                    sql = "update TB_REQUISTION set app_name = " & vbNewLine
    '                    If Not IsDBNull(dtTemp.Rows(i).Item("app_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("app_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
    '                    sql &= "patent_type_id = " & vbNewLine
    '                    If Not IsDBNull(dtTemp.Rows(i).Item("patent_type_id")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("patent_type_id").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
    '                    sql &= "updateby = 'DbAgent',updateon = getdate(), "
    '                    sql &= "sys_submit_date='" & SysSubmitDate & "'"
    '                    sql &= " where app_no = '" & dtTemp.Rows(i).Item("app_no") & "'"

    '                    Ret = executeSQL(sql)
    '                    If Not Ret.STATUS Then
    '                        txtStatus &= Ret.EX & vbCrLf
    '                    End If

    '                    NewId += 1
    '                    cnt += 1
    '                    bw8.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
    '                    Threading.Thread.Sleep(5)
    '                Catch ex As Exception
    '                    txtStatus &= ex.Message & vbCrLf
    '                End Try
    '            Next
    '        End If
    '        ' **************************************

    'FinalDestination:

    '        If txtStatus = "" Then txtStatus = "Empty"
    '        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

    '        lblTask8.ForeColor = Color.DarkBlue
    '        tmpc = Nothing
    '        Return "[Update Requisition.]" & vbTab & txtStatus

    '    End Function

    Private Function backgrounUpdateRequisition() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask8.ForeColor
        lblTask8.ForeColor = Color.Red

        Dim txtStatus As String = ""
        Dim yy2 As String = Date.Now.Year.ToString.Substring(2, 2)
        Dim yy1 As String = CStr(CInt(yy2) - 1).PadLeft(2, "0")
        Dim yy3 As String = CStr(CInt(yy2) + 1).PadLeft(2, "0")

        Dim sqlScore As String = "select distinct app_no from TB_REQUISTION "
        Dim sqlInnova As String = "exec REQUISITION '" & yy1 & "','" & yy2 & "','" & yy3 & "'"
        'Dim sqlScore As String = "select distinct app_no,[app_name],patent_type_id from TB_REQUISTION"
        'Dim sqlInnova As String = "exec REQUISITION NULL,NULL,NULL"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        'Dim dtCompare As New DataTable
        'Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)

        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw8.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        If dtInnova.Rows.Count > 0 Then
            txtStatus &= dtInnova.Rows.Count & " Update Requisition."
            Dim TotalAdd As Integer = dtInnova.Rows.Count
            Dim cnt As Integer = 0
            'Dim NewId As Int64 = 0

            For i As Int32 = 0 To dtInnova.Rows.Count - 1
                Application.DoEvents()
                Try
                    dtScore.DefaultView.RowFilter = "app_no='" & dtInnova.Rows(i)("app_no") & "'"
                    If dtScore.DefaultView.Count > 0 Then
                        Dim UpdateBy As String = "null"
                        Dim UpdateOn As String = "null"
                        Dim SysSubmitDate As String = "null"
                        Dim FrmSubmitDate As String = "null"
                        Dim ReceiveDate As String = "null"
                        Dim PublicDate As String = "null"
                        Dim AppSubmitDate As String = "null"
                        Dim LeaveDate As String = "null"
                        Dim EjectDate As String = "null"
                        Dim CancelDate As String = "null"
                        Dim RecoverDate As String = "null"
                        Dim FormType As String = "null"
                        Dim AppStatus As String = "null"
                        
                        If Convert.IsDBNull(dtInnova.Rows(i)("updateby")) = False Then
                            UpdateBy = "'" & dtInnova.Rows(i)("updateby") & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("updateon")) = False Then
                            UpdateOn = "'" & Convert.ToDateTime(dtInnova.Rows(i)("updateon")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If

                        If Convert.IsDBNull(dtInnova.Rows(i)("sys_submit_date")) = False Then
                            SysSubmitDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("sys_submit_date")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If

                        If Convert.IsDBNull(dtInnova.Rows(i)("FRM_SUBMIT_DATE")) = False Then
                            FrmSubmitDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("FRM_SUBMIT_DATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("RECEIVE_DATE")) = False Then
                            ReceiveDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("RECEIVE_DATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("PUBLICDATE")) = False Then
                            PublicDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("PUBLICDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("APP_SUBMIT_DATE")) = False Then
                            AppSubmitDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("APP_SUBMIT_DATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("LEAVEDATE")) = False Then
                            LeaveDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("LEAVEDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("EJECTDATE")) = False Then
                            EjectDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("EJECTDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("CANCELDATE")) = False Then
                            CancelDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("CANCELDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("RECOVERDATE")) = False Then
                            RecoverDate = "'" & Convert.ToDateTime(dtInnova.Rows(i)("RECOVERDATE")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("FORMTYPE")) = False Then
                            FormType = "'" & Convert.ToInt64(dtInnova.Rows(i)("FORMTYPE")) & "'"
                        End If
                        If Convert.IsDBNull(dtInnova.Rows(i)("app_status")) = False Then
                            AppStatus = "'" & dtInnova.Rows(i)("app_status") & "'"
                        End If


                        sql = "update TB_REQUISTION set app_name = " & vbNewLine
                        If Not IsDBNull(dtInnova.Rows(i).Item("app_name")) Then sql &= "'" & fixData(dtInnova.Rows(i).Item("app_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                        sql &= "patent_type_id = " & vbNewLine
                        If Not IsDBNull(dtInnova.Rows(i).Item("patent_type_id")) Then sql &= "'" & fixData(dtInnova.Rows(i).Item("patent_type_id").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                        sql &= "updateby = " & UpdateBy
                        sql &= ",updateon = " & UpdateOn
                        sql &= ",sys_submit_date=" & SysSubmitDate
                        sql &= ",FRM_SUBMIT_DATE=" & FrmSubmitDate
                        sql += ",RECEIVE_DATE=" & ReceiveDate
                        sql += ",PUBLICDATE=" & PublicDate
                        sql += ",APP_SUBMIT_DATE=" & AppSubmitDate
                        sql += ",LEAVEDATE=" & LeaveDate
                        sql += ",EJECTDATE=" & EjectDate
                        sql += ",CANCELDATE=" & CancelDate
                        sql += ",RECOVERDATE=" & RecoverDate
                        sql += ",pct= '" & fixData(dtInnova.Rows(i).Item("pct").ToString) & "',pct_no ='" & fixData(dtInnova.Rows(i).Item("pctno").ToString) & "'"
                        sql += ",formtype=" & FormType
                        sql += ",app_status=" & AppStatus
                        sql &= " where app_no = '" & dtInnova.Rows(i).Item("app_no") & "'"

                        Ret = executeSQL(sql)
                        If Not Ret.STATUS Then
                            txtStatus &= Ret.EX & vbCrLf
                        End If
                    End If

                    dtScore.DefaultView.RowFilter = ""
                    cnt += 1
                    bw8.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If


        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask8.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[Update Requisition.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertFileBorrowItem() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask9.ForeColor
        lblTask9.ForeColor = Color.Red
        Dim txtStatus As String = ""
        'Dim sqlScore As String = "select distinct ref_innova_id as ID from TB_RESERVE where datediff(d,reserve_date,getdate()) = 0"
        'Dim sqlInnova As String = "exec FILEBORROWITEM " & fixDate(Date.Now)
        Dim sqlScore As String = "select distinct ref_innova_id as ID from TB_RESERVE"
        Dim sqlInnova As String = "exec FILEBORROWITEM '" & DateTime.Now.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & "'"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "ID", "ID")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw9.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "ID_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New FileBorrowItem."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            Dim NewId As Int64 = 0
            Dim AppNoId As Int64 = 0

            NewId = GetNewId("TB_RESERVE", "id")

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    AppNoId = GetIdAPP_NO(dtTemp.Rows(i).Item("app_no").ToString.Trim)

                    sql = "insert into TB_RESERVE(id,requidition_id,ref_innova_id,reserve_date,member_id,member_name,borrowstatus,reserve_order,reserve_status,createby,createon) values('" & NewId & "','" & AppNoId & "',"
                    If Not IsDBNull(dtTemp.Rows(i).Item("ID")) Then sql &= "'" & dtTemp.Rows(i).Item("ID").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("create_date")) Then sql &= "'" & fixDateTime(dtTemp.Rows(i).Item("create_date").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("member_id")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("member_id").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("member_name")) Then sql &= "'" & dtTemp.Rows(i).Item("member_name").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("borrowstatus")) Then sql &= "'" & dtTemp.Rows(i).Item("borrowstatus").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("reserve_order")) Then sql &= "'" & dtTemp.Rows(i).Item("reserve_order").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    If CheckStatusFile(dtTemp.Rows(i).Item("app_no").ToString.Trim) = True Then
                        sql &= "'N',"
                    Else
                        sql &= "'Y',"
                    End If
                    sql &= "'DbAgent',getdate())"
                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If

                    NewId += 1
                    cnt += 1
                    bw9.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask9.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[New FileBorrowItem.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateFileBorrowItem() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim tmpc As New Color
        tmpc = lblTask10.ForeColor
        lblTask10.ForeColor = Color.Red
        Dim txtStatus As String = ""
        'Dim sqlScore As String = "select distinct ref_innova_id as ID,reserve_date,member_id,member_name,borrowstatus,CONVERT(varchar(8),reserve_date,112) as CreateDate,CONVERT(varchar(8),reserve_date,114) as CreateTime  from TB_RESERVE where datediff(d,reserve_date,getdate()) = 0"
        'Dim sqlInnova As String = "exec FILEBORROWITEM " & fixDate(Date.Now)
        Dim sqlScore As String = "select distinct ref_innova_id as ID,reserve_date,member_id,member_name,borrowstatus,CONVERT(varchar(8),reserve_date,112) as CreateDate,CONVERT(varchar(8),reserve_date,114) as CreateTime from TB_RESERVE"
        Dim sqlInnova As String = "exec FILEBORROWITEM '" & DateTime.Now.ToString("yyyy-MM-dd", New Globalization.CultureInfo("en-US")) & "'"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "ID", "ID")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw10.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "ID_Second is not null and ((trim(borrowstatus) <> trim(borrowstatus_second)) or (trim(member_name) <> trim(member_name_second)) or (member_id <> member_id_second) or (trim(CreateDate) <> trim(CreateDate_second)) or (trim(CreateTime) <> trim(CreateTime_second)))"

        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update FileBorrowItem."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            Dim AppNoId As Int64 = 0

            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    AppNoId = GetIdAPP_NO(dtTemp.Rows(i).Item("app_no").ToString)
                    sql = "update TB_RESERVE set requidition_id = '" & AppNoId & "'," & vbNewLine
                    sql &= "reserve_date = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("create_date")) Then sql &= "'" & fixDateTime(dtTemp.Rows(i).Item("create_date").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "member_id = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("member_id")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("member_id").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "member_name = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("member_name")) Then sql &= "'" & dtTemp.Rows(i).Item("member_name").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "borrowstatus = " & vbNewLine
                    If Not IsDBNull(dtTemp.Rows(i).Item("borrowstatus")) Then sql &= "'" & dtTemp.Rows(i).Item("borrowstatus").ToString & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where ref_innova_id = '" & dtTemp.Rows(i).Item("ID").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If

                    cnt += 1
                    bw10.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        If Not isThreadAlive() Then tlActive.Image = frmMain.imgLst.Images("noActivity")

        lblTask10.ForeColor = Color.DarkBlue
        tmpc = Nothing
        Return "[Update FileBorrowItem.]" & txtStatus

    End Function

    Private Sub CheckExit(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted, bw2.RunWorkerCompleted, bw3.RunWorkerCompleted, bw4.RunWorkerCompleted, bw5.RunWorkerCompleted, bw6.RunWorkerCompleted, bw7.RunWorkerCompleted, bw8.RunWorkerCompleted, bw9.RunWorkerCompleted, bw10.RunWorkerCompleted
        If Not (bw1.IsBusy) And Not (bw2.IsBusy) And Not (bw3.IsBusy) And Not (bw4.IsBusy) And Not (bw5.IsBusy) And Not (bw6.IsBusy) And Not (bw7.IsBusy) And Not (bw8.IsBusy) And Not (bw9.IsBusy) And Not (bw10.IsBusy) Then
            'Application.Exit()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (Not bw1.IsBusy) And chkInclude1.Checked Then
            bw1.RunWorkerAsync()
        End If

        If (Not bw2.IsBusy) And chkInclude2.Checked Then
            bw2.RunWorkerAsync()
        End If

        If (Not bw3.IsBusy) And chkInclude3.Checked Then
            bw3.RunWorkerAsync()
        End If

        If (Not bw4.IsBusy) And chkInclude4.Checked Then
            bw4.RunWorkerAsync()
        End If

        If (Not bw5.IsBusy) And chkInclude5.Checked Then
            bw5.RunWorkerAsync()
        End If

        If (Not bw6.IsBusy) And chkInclude6.Checked Then
            bw6.RunWorkerAsync()
        End If

        If (Not bw7.IsBusy) And chkInclude7.Checked Then
            bw7.RunWorkerAsync()
        End If

        If (Not bw8.IsBusy) And chkInclude8.Checked Then
            bw8.RunWorkerAsync()
        End If

        If (Not bw9.IsBusy) And chkInclude9.Checked Then
            bw9.RunWorkerAsync()
        End If

        If (Not bw10.IsBusy) And chkInclude10.Checked Then
            bw10.RunWorkerAsync()
        End If
    End Sub

    Private Function backgrounInsertStatus() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as status_code,status_name,description from TB_STATUS"
        Dim sqlInnova As String = "exec [STATUS]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "status_code", "status_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "status_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New Status."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_STATUS(id,status_name,description,createby,createon) values('" & dtTemp.Rows(i).Item("status_code").ToString & "','" & dtTemp.Rows(i).Item("status_name").ToString & "','" & dtTemp.Rows(i).Item("description").ToString & "',"
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[New Status.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateStatus() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as status_code,status_name,description from TB_STATUS"
        Dim sqlInnova As String = "exec [STATUS]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "status_code", "status_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "status_code_Second is not null AND status_name <> status_name_Second AND description <> description_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update Status."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_STATUS set "
                    sql &= "status_name = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("status_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("status_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "description = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("description")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("description").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id ='" & dtTemp.Rows(i).Item("status_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[Update Status.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertFileLocation() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as location_code,location_name,description from TB_FILELOCATION"
        Dim sqlInnova As String = "exec [FILELOCATION]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "location_code", "location_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "location_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New FileLocation."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "insert into TB_FILELOCATION(id,location_name,description,createby,createon) values('" & dtTemp.Rows(i).Item("location_code").ToString & "','" & dtTemp.Rows(i).Item("location_name").ToString & "','" & dtTemp.Rows(i).Item("description").ToString & "',"
                    sql &= "'DbAgent',getdate())"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[New FileLocation.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateFileLocation() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as location_code,location_name,description from TB_FILELOCATION"
        Dim sqlInnova As String = "exec [FILELOCATION]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "location_code", "location_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "location_code_Second is not null AND location_name <> location_name_Second AND description <> description_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update FileLocation."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    sql = "update TB_FILELOCATION set "
                    sql &= "location_name = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("location_name")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("location_name").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "description = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("description")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("description").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = 'DbAgent',updateon = getdate() where id ='" & dtTemp.Rows(i).Item("location_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[Update FileLocation.]" & vbTab & txtStatus

    End Function

    Private Function backgrounInsertFileStore() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as filestore_code,app_no,filelocation from TB_FILESTORE"
        Dim sqlInnova As String = "exec [FILESTORE]"
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "filestore_code", "filestore_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Insert ***************
        dtCompare.DefaultView.RowFilter = "filestore_code_Second is null"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " New FileStore"
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    Dim CreateBy As String = "null"
                    Dim CreateOn As String = "null"

                    If Convert.IsDBNull(dtTemp.Rows(i)("createby")) = False Then
                        CreateBy = "'" & dtTemp.Rows(i)("createby") & "'"
                    End If
                    If Convert.IsDBNull(dtTemp.Rows(i)("createon")) = False Then
                        CreateOn = "'" & Convert.ToDateTime(dtTemp.Rows(i)("createon")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                    End If

                    sql = "insert into tb_filestore(id,app_no,filelocation,createby,createon) values('" & dtTemp.Rows(i).Item("filestore_code").ToString & "','" & dtTemp.Rows(i).Item("app_no").ToString & "','" & dtTemp.Rows(i).Item("filelocation").ToString & "',"
                    sql &= CreateBy & "," & CreateOn & ")"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[New FileStore.]" & vbTab & txtStatus

    End Function

    Private Function backgrounUpdateFileStore() As String
        CheckForIllegalCrossThreadCalls = False
        System.Threading.Thread.CurrentThread.Priority = ThreadPriority.BelowNormal

        Dim txtStatus As String = ""
        Dim sqlScore As String = "select distinct id as filestore_code,app_no,filelocation from TB_FILESTORE"
        Dim sqlInnova As String = "exec [FILESTORE]"  'สนใจเฉพาะแฟ้มที่ถูกย้ายไปอยู่ที่ทรัพย์ศรีไทย
        Dim dtInnova As New DataTable
        Dim dtScore As New DataTable
        Dim dtCompare As New DataTable
        Dim dtTemp As New DataTable
        Dim sql As String = ""
        Dim da As New SqlDataAdapter
        Dim ConnScore As New SqlConnection
        Dim Ret As New EXESQL

        Try
            ConnScore.ConnectionString = StrconnScore
            ConnScore.Open()
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            ConnScore.Dispose()
            Return "Connection Problem."
        End Try
        ConnScore.Dispose()

        Try
            da = New SqlDataAdapter(sqlInnova, StrconnScore)
            da.Fill(dtInnova)
            da = New SqlDataAdapter(sqlScore, StrconnScore)
            da.Fill(dtScore)
            dtCompare = LeftJoin(dtInnova, dtScore, "filestore_code", "filestore_code")
        Catch ex As Exception
            txtStatus &= ex.Message & vbCrLf
            GoTo FinalDestination
        End Try

        If bw1.CancellationPending Then
            txtStatus &= "Canceled by User"
            GoTo FinalDestination
        End If

        ' *************** Update ***************
        dtCompare.DefaultView.RowFilter = "filestore_code_Second is not null AND filelocation <> filelocation_Second"
        If dtCompare.DefaultView.Count > 0 Then
            dtTemp = dtCompare.DefaultView.ToTable
            txtStatus &= dtTemp.Rows.Count & " Update FileStore."
            Dim TotalAdd As Integer = dtTemp.Rows.Count
            Dim cnt As Integer = 0
            For i As Int32 = 0 To dtTemp.Rows.Count - 1
                Application.DoEvents()
                Try
                    Dim UpdateBy As String = "null"
                    Dim UpdateOn As String = "null"
                    If Convert.IsDBNull(dtTemp.Rows(i)("updateby")) = False Then
                        UpdateBy = "'" & dtTemp.Rows(i)("updateby") & "'"
                    End If
                    If Convert.IsDBNull(dtTemp.Rows(i)("updateon")) = False Then
                        UpdateOn = "'" & Convert.ToDateTime(dtTemp.Rows(i)("updateby")).ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US")) & "'"
                    End If

                    sql = "update tb_filestore set "
                    sql &= "filelocation = "
                    If Not IsDBNull(dtTemp.Rows(i).Item("filelocation")) Then sql &= "'" & fixData(dtTemp.Rows(i).Item("filelocation").ToString) & "'," & vbNewLine Else sql &= "Null," & vbNewLine
                    sql &= "updateby = " & UpdateBy & ",updateon = " & UpdateOn & " where id ='" & dtTemp.Rows(i).Item("filestore_code").ToString & "'"

                    Ret = executeSQL(sql)
                    If Not Ret.STATUS Then
                        txtStatus &= Ret.EX & vbCrLf
                    End If
                    cnt += 1
                    bw1.ReportProgress(Math.Floor(cnt * 100 / TotalAdd))
                    Threading.Thread.Sleep(5)
                Catch ex As Exception
                    txtStatus &= ex.Message & vbCrLf
                End Try
            Next
        End If
        ' **************************************

FinalDestination:

        If txtStatus = "" Then txtStatus = "Empty"
        Return "[Update FileStore.]" & vbTab & txtStatus

    End Function

End Class