Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Linq
Imports Engine
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Partial Class frmLogin
    Inherits System.Web.UI.Page

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click

        Dim IEng As New Web_Config.LoginENG
        Dim script As String = "alert('Record exists')"
        Dim trans As New TransactionDB
        Dim lnq As New TbUserLinqDB
        Dim sql As String
        Dim userid As String
        Dim roleid As String
        Dim resid As String
        Dim dt As New DataTable
        Session.Remove("idres1")
        Session.Remove("idres2")
        Session.Remove("idres3")
        Session.Remove("idres4")
        Session.Remove("idres5")
        Session.Remove("idres6")

        If IEng.CheckUserProfile(txtUserName.Text.Trim(), txtPassword.Text.Trim(), Request) Then
            Globals.uData = IEng.GetLoginSession
            'Globals.uData.LOGIN_HISTORY_ID = IEng.SaveWebLoginHistory(IEng.uData, Request


            sql = "Select id, USERNAME from TB_USER where USERNAME = '" & txtUserName.Text & "' "
            dt = lnq.GetListBySql(sql, trans.Trans)
            If dt.Rows.Count > 0 Then

                lblUsername.Text = dt.Rows(0).Item("USERNAME").ToString
                userid = dt.Rows(0).Item("id").ToString
                Session("Username") = lblUsername.Text
                Session("LoginHistoryID") = IEng.GetLoginSession.LOGIN_HISTORY_ID

                If txtUserName.Text = lblUsername.Text Then

                    sql = "Select tb_role_id roleid from TB_USER_ROLE where tb_user_id = '" & userid & "' "
                    dt = lnq.GetListBySql(sql, trans.Trans)
                    If dt.Rows.Count > 0 Then
                        roleid = dt.Rows(0).Item("roleid").ToString

                        sql = "Select tb_responsibility_id resid  from TB_ROLE_RESPONSIBILITY where tb_role_id = '" & roleid & "' "
                        dt = lnq.GetListBySql(sql, trans.Trans)
                        If dt.Rows.Count > 0 Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                resid = dt.Rows(i).Item("resid").ToString
                                If resid = "1" Then
                                    Session("idres1") = resid
                                ElseIf resid = "2" Then
                                    Session("idres2") = resid
                                ElseIf resid = "3" Then
                                    Session("idres3") = resid
                                ElseIf resid = "4" Then
                                    Session("idres4") = resid
                                ElseIf resid = "5" Then
                                    Session("idres5") = resid
                                ElseIf resid = "6" Then
                                    Session("idres6") = resid
                                End If

                            Next

                        End If

                    End If

                End If

            End If

            Response.Redirect("frmOverview.aspx")

        Else
            'ClientScript.RegisterClientScriptBlock(Me.[GetType](), "blah", "DisplayControl();", True)
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "show", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Please,Check your Username or Password !');", True)
        End If

    End Sub
End Class
