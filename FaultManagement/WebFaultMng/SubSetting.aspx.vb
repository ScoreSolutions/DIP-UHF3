Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports Engine
Partial Class SubSetting
    Inherits System.Web.UI.Page




    Public Sub gvByServerName()
        Dim dt As New DataTable
        Dim eng As New Web_Config.RAMEng

        dt = eng.gvByServerName("")


        If dt IsNot Nothing Then
            dt.Columns.Add("no", GetType(Long))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("no") = i + 1

            Next

            gvServerNameRAM.DataSource = dt
            gvServerNameRAM.DataBind()
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        gvByServerName()
    End Sub
End Class
