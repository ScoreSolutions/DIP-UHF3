Public Class frmCalculateGrowthRatio

    Private Sub frmCalculateGrowthRatio_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If My.Application.CommandLineArgs.Count > 0 Then
            Engine.CalculateGrowthRatioENG.CalculateGrowthRatioMonth()
            Engine.CalculateGrowthRatioENG.CalculateGrowthRatioYear()
        End If

        Application.Exit()
    End Sub
End Class
