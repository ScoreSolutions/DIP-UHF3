Imports System.Windows.Forms
Public Class frmCopyTextfileFromSpeedway

    Dim CopyIntervalMinute As Integer = 0
    Dim LastCopyTime As DateTime = DateTime.Now
    Dim LocalPath As String = ""

    Dim ini As New IniReader(Application.StartupPath & "\Config.ini")

    Private Sub CopyTextFileFromSpeedway()
        Try
            If LocalPath.Trim = "" Then
                LocalPath = "D:\SpeedwayTextFile\"
            End If
            If IO.Directory.Exists(LocalPath) = False Then
                IO.Directory.CreateDirectory(LocalPath)
            End If

            Engine.SpeedwayENG.CopyTextFileFromSpeedway(LocalPath)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TimerCopyTextFile_Tick(sender As Object, e As EventArgs) Handles TimerCopyTextFile.Tick
        TimerCopyTextFile.Enabled = False
        If DateAdd(DateInterval.Minute, CopyIntervalMinute, LastCopyTime) < DateTime.Now Then
            CopyTextFileFromSpeedway()

            CopyIntervalMinute = ini.ReadString("CopyIntervalMinute")
            LastCopyTime = DateTime.Now
        End If
        TimerCopyTextFile.Enabled = True
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        NotifyIcon1.Visible = False
    End Sub

    Private Sub frmCopyTextfileFromSpeedway_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
            NotifyIcon1.Visible = True
            NotifyIcon1.Text = "Import Textfile From Speedway"
        Else
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub frmCopyTextfileFromSpeedway_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TimerCopyTextFile.Enabled = False
        ini.Section = "PathSetting"
        LocalPath = ini.ReadString("PathTextFile")
        CopyIntervalMinute = ini.ReadString("CopyIntervalMinute")

        CopyTextFileFromSpeedway()
        TimerCopyTextFile.Enabled = True
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TimerImportTextFile_Tick(sender As Object, e As EventArgs) Handles TimerImportTextFile.Tick
        TimerImportTextFile.Enabled = False
        'Dim ini As New IniReader(Application.StartupPath & "\Config.ini")
        'ini.Section = "PathSetting"

        'Dim LocalPath As String = ini.ReadString("PathTextFile")
        'If LocalPath.Trim = "" Then
        '    LocalPath = "D:\SpeedwayTextFile\"
        'End If
        'If IO.Directory.Exists(LocalPath) = False Then
        '    IO.Directory.CreateDirectory(LocalPath)
        'End If

        Engine.SpeedwayENG.ImportTextFileToDB(LocalPath, lblCurrentFile, lblProcess)
        'ini = Nothing

        Dim ProcessPath As String = LocalPath & "ProcessPath\"
        If IO.File.Exists(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt") = True Then
            Try
                IO.File.SetAttributes(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt", IO.FileAttributes.Normal)
                IO.File.Delete(ProcessPath & "SPEEDWAY_PROCESS_FILE.txt")
            Catch ex As Exception

            End Try
        End If

        lblCurrentFile.Text = ""
        lblProcess.Text = "Complete Import Data from Textfile"
        Application.DoEvents()

        For Each d As String In IO.Directory.GetDirectories(LocalPath & "Backup")
            Dim vLastDay As String = d & "\" & DateTime.Now.AddDays(-7).ToString("yyyyMMdd", New Globalization.CultureInfo("th-TH"))
            For Each d2 As String In IO.Directory.GetDirectories(d)
                If d2 < vLastDay Then
                    Try
                        IO.Directory.Delete(d2, True)
                    Catch ex As Exception

                    End Try
                End If
            Next

            If IO.Directory.GetDirectories(d).Length = 0 Then
                Try
                    IO.Directory.Delete(d, True)
                Catch ex As Exception

                End Try
            End If
        Next

        TimerImportTextFile.Enabled = True
    End Sub
End Class