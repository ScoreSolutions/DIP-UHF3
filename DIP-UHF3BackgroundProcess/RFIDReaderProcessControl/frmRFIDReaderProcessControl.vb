Imports Engine.LogFile

Public Class frmRFIDReaderProcessControl

    Const DefaultProcessName As String = "RFIDReaderImportData"
    Private Sub frmRFIDReaderProcessControl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            For Each p As Process In Process.GetProcessesByName(DefaultProcessName)
                p.Kill()
            Next
        Catch ex As Exception
            LogENG.SaveErrLog("RFIDReaderProcessControl.frmRFIDReaderProcessControl_FormClosing", ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmRFIDReaderProcessControl_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
            NotifyIcon1.Text = "RFID Reader Process Control"
        Else
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub frmImportDataFromRFIDReader_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim dt As DataTable = Engine.RFIDReaderENG.GetRFIDReaderList
        If dt.Rows.Count > 0 Then
            For Each p As Process In Process.GetProcessesByName(DefaultProcessName)
                p.Kill()
            Next

            For Each dr As DataRow In dt.Rows
                Try
                    Shell(Application.StartupPath & "\" & DefaultProcessName & ".exe " & dr("ip_address"))

                    lblLog.Text += "Start Mid Range Reader IP " & dr("ip_address") & vbNewLine
                    Application.DoEvents()


                    'Dim copyCmd As String = Application.StartupPath & "\" & DefaultProcessName & ".exe "
                    'Dim args As String = dr("ip_address")
                    'Dim proc As New ProcessStartInfo(copyCmd, args)
                    'Dim pr As Process = Process.Start(proc)
                Catch ex As Exception
                    LogENG.SaveErrLog("RFIDReaderProcessControl.frmImportDataFromRFIDReader_Shown", ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        End If
        dt.Dispose()


        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub
End Class
