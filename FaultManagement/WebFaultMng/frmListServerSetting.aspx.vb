Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Services

Partial Class frmListServerSetting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetgvServerSetting()
    End Sub

    Private Sub SetgvServerSetting()

        Dim dt As DataTable
        Dim Eng As New AlarmEng
        Dim Group_desc As String = Session("Group_desc")

        dt = Eng.GetgvPopupServerSetting(Group_desc.ToString)

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvServerSetting.DataSource = dt
            gvServerSetting.DataBind()

        Else
            gvServerSetting.DataSource = Nothing
        End If

    End Sub

End Class
