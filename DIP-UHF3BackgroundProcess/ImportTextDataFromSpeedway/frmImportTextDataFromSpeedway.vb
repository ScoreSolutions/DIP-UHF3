Public Class frmImportTextDataFromSpeedway

    Private Sub frmImportTextDataFromSpeedway_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Application.CommandLineArgs.Count > 0 Then
            Try
                Dim ini As New IniReader(Application.StartupPath & "\Config.ini")
                ini.Section = "PathSetting"

                Dim LocalPath As String = ini.ReadString("PathTextFile")
                If LocalPath.Trim = "" Then
                    LocalPath = "D:\SpeedwayTextFile\"
                End If
                If IO.Directory.Exists(LocalPath) = False Then
                    IO.Directory.CreateDirectory(LocalPath)
                End If

                Engine.SpeedwayENG.ConvertAndImportTextFileToDB(LocalPath)
                ini = Nothing
            Catch ex As Exception
                Application.Exit()
            End Try
        End If
        Application.Exit()
    End Sub
End Class
