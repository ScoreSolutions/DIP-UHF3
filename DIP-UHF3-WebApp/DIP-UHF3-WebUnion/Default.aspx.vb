﻿
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Response.Redirect("Login.aspx?rnd=" & DateTime.Now.Millisecond)

        Dim ret As Boolean = Engine.LogFile.LogENG.Logout(Session("username"), Session("LoginHistoryID"))
        Session.Abandon()
        Response.Redirect("Login.aspx")
    End Sub
End Class
