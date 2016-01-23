Imports Engine
Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.IO
Partial Class frmAddProcess
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GetShowProcess()
        End If

    End Sub
    Public Sub GetShowProcess()
        Dim dt As New DataTable
        Dim eng As New ProcessENG

        dt = eng.SetProcess("")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvprocess.DataSource = dt
            gvprocess.DataBind()

        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateProcess() = False Then
            Return
        End If

        Dim lnq As New MsMasterProcessChecklistLinqDB
        Dim trans As New TransactionDB

        If Convert.ToInt64(lblid.Text > 0) Then
            lnq.GetDataByPK(Convert.ToInt64(lblid.Text), trans.Trans)
        End If

        lnq.WINDOWPROCESSNAME = txtWindowProcessName.Text
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
        chkActiveStatus.Checked = True
        txtWindowProcessName.Text = ""
        txtDisplayName.Text = ""
        GetShowProcess()
    End Sub
    Private Function ValidateProcess() As Boolean

        If txtWindowProcessName.Text.Trim() = "" Then

            Return False
        End If
        If txtDisplayName.Text.Trim() = "" Then

            Return False
        End If


        Dim eng As New ProcessENG
        If eng._CheckDuplicateRegister(Convert.ToInt64(lblid.Text), txtWindowProcessName.Text.Trim()) = True Then
            'ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), (Seng.ErrorMessage), True)
            eng = Nothing
            Return False
        End If
        eng = Nothing
        Return True

    End Function


    Protected Sub gvprocess_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvprocess.RowCommand

        If e.CommandName = "EditRow" Then
            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            Dim id As Label = CType(gvprocess.Rows(RowIndex).FindControl("lblid"), Label)
            Dim WindowProcessName As Label = CType(gvprocess.Rows(RowIndex).FindControl("lblWindowProcessName"), Label)
            Dim Description As Label = CType(gvprocess.Rows(RowIndex).FindControl("lblDisplayName"), Label)
            Dim Active As CheckBox = CType(gvprocess.Rows(RowIndex).FindControl("ChkActive"), CheckBox)

            lblid.Text = id.Text
            txtWindowProcessName.Text = WindowProcessName.Text
            txtDisplayName.Text = Description.Text
            chkActiveStatus.Checked = Active.Checked
        End If
        If e.CommandName = "DeleteRow" Then

            Dim confirm_value As String = Request.Form("confirm_value")
            Dim substring As String = confirm_value.Substring(confirm_value.Length - 1, 1)
            If substring = "s" Then

                'Dim lblid As Label
                Dim RowIndex As Integer
                Integer.TryParse(e.CommandArgument.ToString, RowIndex)
                'lblid = CType(gvprocess.Rows(RowIndex).FindControl("lblid"), Label)


                Dim trans As New TransactionDB
                Dim lnq As New MsMasterProcessChecklistLinqDB
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
