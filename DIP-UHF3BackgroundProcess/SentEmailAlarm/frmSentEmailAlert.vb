Public Class frmSentEmailAlert

    Private Sub frmSentEmailAlert_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Application.CommandLineArgs.Count > 0 Then
            Try
                Engine.MailAlertENG.SentMailAlert()
            Catch ex As Exception
                Engine.LogFile.LogENG.SaveErrLog("frmSentEmailAlert.frmSentEmailAlarm_Load", ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Engine.MailAlertENG.SentMail("akkarawat@scoresolutions.co.th", "Test Mail go Thai", "RFID UHF3")
    End Sub
End Class
