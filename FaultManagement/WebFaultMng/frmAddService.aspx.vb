Imports Engine
Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.IO
Partial Class frmAddService
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GetShowServiec()
        End If

    End Sub

    Public Sub GetShowServiec()
        Dim dt As New DataTable
        Dim Seng As New ServiceENG

        dt = Seng.Service("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvService.DataSource = dt
            gvService.DataBind()

        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateService() = False Then
            Return
        End If

        Dim lnq As New MsMasterServiceChecklistLinqDB
        Dim trans As New TransactionDB

        If Convert.ToInt64(lblid.Text > 0) Then
            lnq.GetDataByPK(Convert.ToInt64(lblid.Text), trans.Trans)
        End If

        lnq.WINDOWSERVICENAME = txtWindowServiceName.Text
        lnq.DISPLAYNAME = txtDisplayName.Text

        If chkActiveStatus.Checked Then
            lnq.ACTIVESTATUS = Convert.ToChar("Y")
        Else
            lnq.ACTIVESTATUS = Convert.ToChar("N")
        End If


        Dim ret As Boolean = False

        If (lnq.ID > 0) Then
            ret = lnq.UpdateByPK(Globals.uData.USERNAME, trans.Trans)
        Else
            ret = lnq.InsertData(Globals.uData.USERNAME, trans.Trans)
        End If


        If ret = True Then
            trans.CommitTransaction()
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Save data Complete');", True)
        Else
            trans.RollbackTransaction()
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Can not Save data Complete !');", True)
        End If

        lnq = Nothing

        Clear()
    End Sub

    Public Sub Clear()
        lblid.Text = "0"
        txtWindowServiceName.Text = ""
        txtDisplayName.Text = ""
        chkActiveStatus.Checked = True
        GetShowServiec()
    End Sub
    Private Function ValidateService() As Boolean

        If txtWindowServiceName.Text.Trim() = "" Then

            Return False
        End If
        If txtDisplayName.Text.Trim() = "" Then

            Return False
        End If
       

        Dim Seng As New ServiceENG
        If Seng._CheckDuplicateRegister(Convert.ToInt64(lblid.Text), txtWindowServiceName.Text.Trim()) = True Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (Seng.ErrorMessage), True)
            Seng = Nothing
            Return False
        End If
        Seng = Nothing
        Return True

    End Function

    Protected Sub gvService_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvService.RowCommand

        If e.CommandName = "EditRow" Then
           Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            Dim id As Label = CType(gvService.Rows(RowIndex).FindControl("lblid"), Label)
            Dim WindowServiceName As Label = CType(gvService.Rows(RowIndex).FindControl("lblWindowServiceName"), Label)
            Dim Description As Label = CType(gvService.Rows(RowIndex).FindControl("lblDisplayName"), Label)
            Dim Active As CheckBox = CType(gvService.Rows(RowIndex).FindControl("ChkActive"), CheckBox)

            lblid.Text = id.Text
            txtWindowServiceName.Text = WindowServiceName.Text
            txtDisplayName.Text = Description.Text
            chkActiveStatus.Checked = Active.Checked
        End If



        If e.CommandName = "DeleteRow" Then

            Dim confirmValue As String = Request.Form("confirm_value")
            Dim substring As String = confirmValue.Substring(confirmValue.Length - 1, 1)
            If substring = "s" Then

                'Dim lblid As Label
                Dim RowIndex As Integer
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)
                'lblid = CType(gvService.Rows(RowIndex).FindControl("lblid"), Label)

                Dim trans As New TransactionDB
                Dim lnq As New MsMasterServiceChecklistLinqDB
                Dim ret As Boolean = False
                ret = lnq.DeleteByPK(RowIndex, trans.Trans)
                If ret = True Then
                    trans.CommitTransaction()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Delete data Complete !');", True)
                Else
                    trans.RollbackTransaction()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('Cannot Delete data !');", True)
                End If
                lnq = Nothing
                Clear()
            End If
        End If
    End Sub
End Class
