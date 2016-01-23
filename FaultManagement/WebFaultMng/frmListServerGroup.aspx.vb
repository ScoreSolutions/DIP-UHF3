Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Services

Partial Class frmListServerGroup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetgvServerList()
    End Sub

    Private Sub SetgvServerList()

        Dim dt As DataTable
        Dim REng As New OverviewEng
        Dim Group_desc As String = Session("Group_desc")

        dt = REng.GetgvServerList(Group_desc.ToString)

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvServerList.DataSource = dt
            gvServerList.DataBind()

        Else
            gvServerList.DataSource = Nothing
        End If

    End Sub

    Protected Sub gvServerList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvServerList.RowCommand
        If e.CommandName = "Detail" Then

            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            Dim svName As String = gvServerList.Rows(RowIndex).Cells(2).Text
            Session("idRAM") = svName.ToString

            If Not Page.ClientScript.IsClientScriptBlockRegistered("MyScript") Then

                Response.Write("<script language=javascript>window.open('frmPopupServerChart.aspx','_blank','height=600px,width=1000px,scrollbars=1,left=300,top=50');</script>")

            End If

        End If
    End Sub
End Class
