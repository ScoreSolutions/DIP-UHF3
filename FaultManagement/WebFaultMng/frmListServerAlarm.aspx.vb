Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Services

Partial Class frmListServerAlarm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetgvAlarmServer()
    End Sub

    Private Sub SetgvAlarmServer()

        Dim dt As DataTable
        Dim Eng As New AlarmEng
        Dim Group_desc As String = Session("Group_desc")

        dt = Eng.GetgvPopupAlarmServer(Group_desc.ToString)

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvAlarmServer.DataSource = dt
            gvAlarmServer.DataBind()

        Else
            gvAlarmServer.DataSource = Nothing
        End If

    End Sub

   
    Protected Sub gvAlarmServer_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAlarmServer.RowCommand
        If e.CommandName = "Detail" Then

            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            Dim svName As String = gvAlarmServer.Rows(RowIndex).Cells(3).Text
            Session("idRAM") = svName.ToString

            If Not Page.ClientScript.IsClientScriptBlockRegistered("MyScript") Then

                Response.Write("<script language=javascript>window.open('frmPopupServerChart.aspx','_blank','height=600px,width=1000px,scrollbars=1,left=300,top=50');</script>")

            End If

        End If
    End Sub
End Class
