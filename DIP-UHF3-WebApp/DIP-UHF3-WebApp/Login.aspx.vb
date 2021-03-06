﻿Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.Data
Imports System.IO

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub Login_Click(Source As Object, E As EventArgs)
        If txtUsername.Value = "" Then
            lblshowvalid.InnerText = "Please enter your username."
            Exit Sub
        End If
        If txtPassword.Value = "" Then
            lblshowvalid.InnerText = "Please enter your password."
            Exit Sub
        End If

        Dim dt As New DataTable
        dt = Engine.GlobalFunction.GetDataLogin(txtUsername.Value, txtPassword.Value)
        If dt.Rows.Count > 0 Then
            Dim lID As Long = Engine.LogFile.WebLogENG.SaveLoginHistory(txtUsername.Value, Request)
            If lID > 0 Then
                Session("fullname") = dt.Rows(0)("fullname") & ""
                Session("username") = dt.Rows(0)("username") & ""
                Session("userid") = dt.Rows(0)("id") & ""
                Session("password") = txtPassword.Value
                Session("LoginHistoryID") = lID
                Session("HostReport") = Engine.GlobalFunction.GetSysConfing("HostReport")

                Response.Redirect("frmPortal.aspx")

            End If
        Else
            lblshowvalid.InnerText = "User not found!"
        End If
    End Sub



End Class
