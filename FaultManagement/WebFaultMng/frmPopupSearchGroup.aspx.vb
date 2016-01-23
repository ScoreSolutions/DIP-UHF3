Imports Engine
Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.IO
Imports Globals
Partial Class frmPopupSearchGroup_aspx
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

       
        If Not IsPostBack Then
            getgvGroup()
        End If
    



    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

      
        'No Server
        If gvGroupbyName.Rows.Count > 0 Then
            Session("_group") = lblgroupName.Text
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "window.close();", True)

        End If





    End Sub

    Public Sub getgvGroup()
        Dim eng As New RAMEng
        Dim dt As New DataTable
        dt = eng.SetgvGroup("", "group by group_desc")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

        End If

        gvGroup.DataSource = dt
        gvGroup.DataBind()
    End Sub

    Protected Sub gvGroup_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvGroup.RowCommand
        If e.CommandName = "Group" Then

            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)


            Dim Group As Label = CType(gvGroup.Rows(RowIndex).FindControl("lblGroup"), Label)
            Dim _Group As String = Group.Text
            Dim eng As New RAMEng
            Dim dt As New DataTable

            dt = eng.SetgvGrouByName("group_desc = '" & Group.Text & "'")

            If dt.Rows(0)("ServerIP").ToString <> "" Then
                If dt IsNot Nothing Then
                    dt.Columns.Add("no", GetType(Long))
                    For i As Integer = 0 To dt.Rows.Count - 1
                        dt.Rows(i)("no") = i + 1
                    Next
                End If

                lblNoServer.Text = ""

                gvGroupbyName.DataSource = dt
                gvGroupbyName.DataBind()
            Else
                lblNoServer.Text = "No Server"
                Dim _dt As New DataTable
                gvGroupbyName.DataSource = _dt
                gvGroupbyName.DataBind()

            End If
            lblgroupName.Text = dt.Rows(0)("group_desc").ToString()

        End If

    End Sub

 
    Protected Sub btnSerch_Click(sender As Object, e As EventArgs) Handles btnSerch.Click
      
        Dim eng As New RAMEng
        Dim dt As New DataTable
        dt = eng.SetgvGroup("TG.group_desc like '%" & txtGroup.Text & "%'", "group by group_desc")

        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1
            Next

            gvGroup.DataSource = dt
            gvGroup.DataBind()
        End If
    End Sub

    Protected Sub imgBack_Click(sender As Object, e As ImageClickEventArgs) Handles imgBack.Click
        getgvGroup()
        lblgroupName.Text = ""
        lblNoServer.Text = ""
        Dim _dt As New DataTable
        gvGroupbyName.DataSource = _dt
        gvGroupbyName.DataBind()
    End Sub
    Public Function chkRAM(ByVal id As String) As String
        Dim dt As New DataTable
        Dim eng As New Web_Config.RAMEng
        dt = eng.GetgvRAM("")


        For i As Integer = 0 To dt.Rows.Count - 1
            id += dt.Rows(i)("id").ToString & ","
        Next

        If id <> "" Then
            id = id.Substring(0, id.Length - 1)
        End If

        id = "id not in (" & id & ")"

        Return id
    End Function

    Public Function chkCPU(ByVal id As String) As String
        Dim dt As New DataTable
        Dim eng As New Web_Config.CPUEng
        dt = eng.GetgvCPU("")

        For i As Integer = 0 To dt.Rows.Count - 1
            id += dt.Rows(i)("idRes").ToString & ","
        Next

        If id <> "" Then
            id = id.Substring(0, id.Length - 1)
        End If
        id = "id not in (" & id & ")"
        Return id
    End Function
End Class
