Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Net.Mail


Partial Class frmOverview
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        SetgvRegister()
        'SetgvMGroup()

        'SetgvRecent()

    End Sub
    Private Sub SetgvRegister()

        Dim dt As DataTable
        Dim REng As New OverviewEng

        dt = REng.GetgvRegister("")

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvRegister.DataSource = dt
            gvRegister.DataBind()
            Cache("Data") = dt

            If dt.Rows.Count = 0 Then

                'Dim dr As DataRow
                'dr = dt.NewRow
                'dt.Rows.Add(dr)
                'gvRegister.DataSource = dt
                'gvRegister.DataBind()
                'Dim columnCount As Integer = gvRegister.Rows(0).Cells.Count
                'gvRegister.Rows(0).Cells.Clear()
                'gvRegister.Rows(0).Cells.Add(New TableCell)
                'gvRegister.Rows(0).Cells(0).ColumnSpan = columnCount
                'gvRegister.Rows(0).Cells(0).Text = "No Records Found."

            End If

        Else
            gvRegister.DataSource = Nothing
        End If

    End Sub


    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRegister.RowCommand

        If e.CommandName = "Detail" Then


            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            Dim svIP As String = gvRegister.Rows(RowIndex).Cells(2).Text
            Session("ServerIP") = svIP.ToString

            If Not Page.ClientScript.IsClientScriptBlockRegistered("MyScript") Then

                Response.Write("<script language=javascript>window.open('frmPopupServerChart.aspx','_blank','height=660px,width=1300px,scrollbars=1,left=20,top=5');</script>")

            End If

        End If
    End Sub


    'Private Sub SetgvMGroup()

    '    Dim dt As DataTable
    '    Dim REng As New OverviewEng

    '    dt = REng.GetgvMGroup("")

    '    If Not dt Is Nothing Then

    '        dt.Columns.Add("No", GetType(Long))
    '        For i As Integer = 0 To dt.Rows.Count - 1

    '            dt.Rows(i)("No") = i + 1
    '        Next

    '        gvMGroup.DataSource = dt
    '        gvMGroup.DataBind()
    '        Cache("Data") = dt

    '        If dt.Rows.Count = 0 Then

    '            Dim dr As DataRow
    '            dr = dt.NewRow
    '            dt.Rows.Add(dr)
    '            gvMGroup.DataSource = dt
    '            gvMGroup.DataBind()
    '            Dim columnCount As Integer = gvMGroup.Rows(0).Cells.Count
    '            gvMGroup.Rows(0).Cells.Clear()
    '            gvMGroup.Rows(0).Cells.Add(New TableCell)
    '            gvMGroup.Rows(0).Cells(0).ColumnSpan = columnCount
    '            gvMGroup.Rows(0).Cells(0).Text = "No Records Found."

    '        End If

    '    Else
    '        gvMGroup.DataSource = Nothing
    '    End If

    'End Sub


    Private Sub SetgvRecent()

        Dim dt As DataTable
        Dim REng As New OverviewEng

        dt = REng.GetgvRecent("")

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvRecently.DataSource = dt
            gvRecently.DataBind()
            Cache("Data") = dt

            If dt.Rows.Count = 0 Then

                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvRecently.DataSource = dt
                gvRecently.DataBind()
                Dim columnCount As Integer = gvRecently.Rows(0).Cells.Count
                gvRecently.Rows(0).Cells.Clear()
                gvRecently.Rows(0).Cells.Add(New TableCell)
                gvRecently.Rows(0).Cells(0).ColumnSpan = columnCount
                gvRecently.Rows(0).Cells(0).Text = "No Records Found."

            End If

        Else
            gvRecently.DataSource = Nothing
        End If

    End Sub


    'Protected Sub gvMGroup_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvMGroup.RowCommand

    '    If e.CommandName = "Detail" Then

    '        Dim RowIndex As Integer
    '        Integer.TryParse(e.CommandArgument.ToString, RowIndex)
    '        Dim Group_desc As Label = CType(gvMGroup.Rows(RowIndex).FindControl("lblID"), Label)
    '        Session("Group_desc") = Group_desc.Text

    '        Dim dt As DataTable
    '        Dim Eng As New OverviewEng

    '        dt = Eng.GetgvServerList(Group_desc.Text)

    '        If dt.Rows.Count > 0 Then
    '            If Not Page.ClientScript.IsClientScriptBlockRegistered("MyScript") Then

    '                Response.Write("<script language=javascript>window.open('frmListServerGroup.aspx','_blank','height=600px,width=1000px,scrollbars=1,left=300,top=50');</script>")

    '            End If
    '        Else
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Server in Group!');", True)
    '        End If


    '    End If
    'End Sub

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SetgvRegister()
        'SetgvMGroup()
        SetgvRecent()

    End Sub

    Protected Sub gvRecently_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvRecently.PageIndexChanging
        SetgvRecent()
        gvRecently.PageIndex = e.NewPageIndex
        gvRecently.DataSource = CType(Cache("Data"), DataTable)
        gvRecently.DataBind()
    End Sub

    'Protected Sub gvMGroup_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvMGroup.PageIndexChanging
    '    SetgvMGroup()
    '    gvMGroup.PageIndex = e.NewPageIndex
    '    gvMGroup.DataSource = CType(Cache("Data"), DataTable)
    '    gvMGroup.DataBind()
    'End Sub

    Protected Sub gvRegister_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvRegister.PageIndexChanging
        SetgvRegister()
        gvRegister.PageIndex = e.NewPageIndex
        gvRegister.DataSource = CType(Cache("Data"), DataTable)
        gvRegister.DataBind()
    End Sub
End Class
