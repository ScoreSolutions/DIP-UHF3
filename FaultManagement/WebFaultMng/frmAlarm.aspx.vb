Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Drawing

Partial Class frmAlarm
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ViewReport As String = Session("idres2")
        'Dim ViewOnly As String = Session("idres3")
        If ViewReport Is Nothing Then

            'btnExportGroup.Visible = False
            btnExportServerA.Visible = False
            'btnExportSetting.Visible = False
        End If

        'If Not IsPostBack Then
        'SetgvServerSetting()
        'SetgvGroupSetting()
        SetgvAlarmServer()

        'End If

        gvAlarmServer.PageIndex = 0
        'gvServerSetting.PageIndex = 0

    End Sub


    'Private Sub SetgvServerSetting()

    '    Dim dt As DataTable
    '    Dim Eng As New AlarmEng

    '    dt = Eng.GetgvServerSetting("")

    '    If Not dt Is Nothing Then

    '        dt.Columns.Add("No", GetType(Long))
    '        For i As Integer = 0 To dt.Rows.Count - 1

    '            dt.Rows(i)("No") = i + 1
    '        Next

    '        gvServerSetting.DataSource = dt
    '        gvServerSetting.DataBind()
    '        gvSettingS2.DataSource = dt
    '        gvSettingS2.DataBind()
    '        Cache("Data") = dt

    '        If dt.Rows.Count > 0 Then
    '            btnExportSetting.Enabled = True
    '            btnSearchSetting.Enabled = True
    '        Else
    '            btnExportSetting.Enabled = False
    '            btnSearchSetting.Enabled = False

    '            Dim dr As DataRow
    '            dr = dt.NewRow
    '            dt.Rows.Add(dr)
    '            gvServerSetting.DataSource = dt
    '            gvServerSetting.DataBind()
    '            Dim columnCount As Integer = gvServerSetting.Rows(0).Cells.Count
    '            gvServerSetting.Rows(0).Cells.Clear()
    '            gvServerSetting.Rows(0).Cells.Add(New TableCell)
    '            gvServerSetting.Rows(0).Cells(0).ColumnSpan = columnCount
    '            gvServerSetting.Rows(0).Cells(0).Text = "No Records Found."

    '        End If

    '    Else
    '        gvServerSetting.DataSource = Nothing
    '    End If

    'End Sub

    'Private Sub SetgvGroupSetting()

    '    Dim dt As DataTable
    '    Dim Eng As New AlarmEng

    '    dt = Eng.GetgvGroupSetting("")

    '    If Not dt Is Nothing Then

    '        dt.Columns.Add("No", GetType(Long))
    '        For i As Integer = 0 To dt.Rows.Count - 1

    '            dt.Rows(i)("No") = i + 1
    '        Next

    '        gvGroupSetting.DataSource = dt
    '        gvGroupSetting.DataBind()
    '        gvSettingG2.DataSource = dt
    '        gvSettingG2.DataBind()
    '        Cache("Data") = dt

    '        If dt.Rows.Count > 0 Then
    '            btnExportGroup.Enabled = True
    '        Else
    '            btnExportGroup.Enabled = False

    '            Dim dr As DataRow
    '            dr = dt.NewRow
    '            dt.Rows.Add(dr)
    '            gvGroupSetting.DataSource = dt
    '            gvGroupSetting.DataBind()
    '            Dim columnCount As Integer = gvGroupSetting.Rows(0).Cells.Count
    '            gvGroupSetting.Rows(0).Cells.Clear()
    '            gvGroupSetting.Rows(0).Cells.Add(New TableCell)
    '            gvGroupSetting.Rows(0).Cells(0).ColumnSpan = columnCount
    '            gvGroupSetting.Rows(0).Cells(0).Text = "No Records Found."

    '        End If

    '    Else
    '        gvGroupSetting.DataSource = Nothing
    '    End If



    'End Sub

    'Protected Sub gvGroupSetting_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvGroupSetting.RowCommand

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabSetting", "TabSetting();", True)

    '    If e.CommandName = "Detail" Then

    '        Dim RowIndex As Integer
    '        Integer.TryParse(e.CommandArgument.ToString, RowIndex)
    '        Dim Group_desc As Label = CType(gvGroupSetting.Rows(RowIndex).FindControl("lblID"), Label)
    '        Session("Group_desc") = Group_desc.Text

    '        Dim dt As DataTable
    '        Dim Eng As New OverviewEng

    '        dt = Eng.GetgvServerList(Group_desc.Text)

    '        If dt.Rows.Count > 0 Then
    '            If Not Page.ClientScript.IsClientScriptBlockRegistered("MyScript") Then

    '                Response.Write("<script language=javascript>window.open('frmListServerSetting.aspx','_blank','height=600px,width=1000px,scrollbars=1,left=300,top=50');</script>")

    '            End If
    '        Else
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Server in Group!');", True)
    '        End If
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabSetting", "TabSetting();", True)

    '    End If
    'End Sub

    Private Sub SetgvAlarmServer()

        Dim dt As DataTable
        Dim Eng As New AlarmEng

        dt = Eng.GetgvAlarmServer("")

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvAlarmServer.DataSource = dt
            gvAlarmServer.DataBind()
            gvAlarmS2.DataSource = dt
            gvAlarmS2.DataBind()
            Cache("Data") = dt

            If dt.Rows.Count > 0 Then
                btnExportServerA.Enabled = True
                btnSearch.Enabled = True

            Else
                btnExportServerA.Enabled = False
                btnSearch.Enabled = False

                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvAlarmServer.DataSource = dt
                gvAlarmServer.DataBind()
                Dim columnCount As Integer = gvAlarmServer.Rows(0).Cells.Count
                gvAlarmServer.Rows(0).Cells.Clear()
                gvAlarmServer.Rows(0).Cells.Add(New TableCell)
                gvAlarmServer.Rows(0).Cells(0).ColumnSpan = columnCount
                gvAlarmServer.Rows(0).Cells(0).Text = "No Records Found."

            End If

        Else
            gvAlarmServer.DataSource = Nothing
        End If

    End Sub


    Private Sub SetbtnSearchAlarm()

        Dim dt As DataTable
        Dim Eng As New AlarmEng

        dt = Eng.GetbtnAlarm(txtAServerIP.Text, txtAServerName.Text, txtAProblem.Text)

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvAlarmServer.DataSource = dt
            gvAlarmServer.DataBind()
            gvAlarmS2.DataSource = dt
            gvAlarmS2.DataBind()
            Cache("Data") = dt


            If dt.Rows.Count > 0 Then
                btnExportServerA.Enabled = True
                btnSearch.Enabled = True

            Else
                btnExportServerA.Enabled = False
                btnSearch.Enabled = False

                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvAlarmServer.DataSource = dt
                gvAlarmServer.DataBind()
                Dim columnCount As Integer = gvAlarmServer.Rows(0).Cells.Count
                gvAlarmServer.Rows(0).Cells.Clear()
                gvAlarmServer.Rows(0).Cells.Add(New TableCell)
                gvAlarmServer.Rows(0).Cells(0).ColumnSpan = columnCount
                gvAlarmServer.Rows(0).Cells(0).Text = "No Records Found."

            End If

        Else
            gvAlarmServer.DataSource = Nothing
        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabAlarm", "TabAlarm();", True) 'Script of TabStrip

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles btnSearch.Click
        SetbtnSearchAlarm()
        Dim dt As New DataTable
        dt = CType(Cache("Data"), DataTable)
        If dt.Rows.Count > 0 Then

        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Data found!');", True)

        End If

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabAlarm", "TabAlarm();", True) 'Script of TabStrip

    End Sub

    Protected Sub gvAlarmServer_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvAlarmServer.PageIndexChanging

        SetgvAlarmServer()
        gvAlarmServer.PageIndex = e.NewPageIndex
        gvAlarmServer.DataSource = CType(Cache("Data"), DataTable)
        gvAlarmServer.DataBind()
        SetbtnSearchAlarm()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabAlarm", "TabAlarm();", True) 'Script of TabStrip

    End Sub

    'Protected Sub gvGroupSetting_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvGroupSetting.PageIndexChanging

    '    gvGroupSetting.PageIndex = e.NewPageIndex
    '    gvGroupSetting.DataSource = CType(Cache("Data"), DataTable)
    '    gvGroupSetting.DataBind()
    '    SetgvGroupSetting()
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabSetting", "TabSetting();", True) 'Script of TabStrip

    'End Sub

    'Protected Sub gvServerSetting_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvServerSetting.PageIndexChanging

    '    gvServerSetting.PageIndex = e.NewPageIndex
    '    gvServerSetting.DataSource = CType(Cache("Data"), DataTable)
    '    gvServerSetting.DataBind()
    '    SetbtnSearchSetting()
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabSetting", "TabSetting();", True) 'Script of TabStrip


    'End Sub

    'Private Sub SetbtnSearchSetting()

    '    Dim dt As DataTable
    '    Dim Eng As New AlarmEng

    '    dt = Eng.GetbtnSearch(txtSServerIP.Text, txtSServerName.Text)

    '    If Not dt Is Nothing Then

    '        dt.Columns.Add("No", GetType(Long))
    '        For i As Integer = 0 To dt.Rows.Count - 1

    '            dt.Rows(i)("No") = i + 1
    '        Next

    '        gvServerSetting.DataSource = dt
    '        gvServerSetting.DataBind()
    '        gvSettingS2.DataSource = dt
    '        gvSettingS2.DataBind()
    '        Cache("Data") = dt

    '        If dt.Rows.Count > 0 Then
    '            btnExportSetting.Enabled = True
    '            btnSearchSetting.Enabled = True
    '        Else
    '            btnExportSetting.Enabled = False
    '            btnSearchSetting.Enabled = False

    '            Dim dr As DataRow
    '            dr = dt.NewRow
    '            dt.Rows.Add(dr)
    '            gvServerSetting.DataSource = dt
    '            gvServerSetting.DataBind()
    '            Dim columnCount As Integer = gvServerSetting.Rows(0).Cells.Count
    '            gvServerSetting.Rows(0).Cells.Clear()
    '            gvServerSetting.Rows(0).Cells.Add(New TableCell)
    '            gvServerSetting.Rows(0).Cells(0).ColumnSpan = columnCount
    '            gvServerSetting.Rows(0).Cells(0).Text = "No Records Found."

    '        End If

    '    Else
    '        gvServerSetting.DataSource = Nothing
    '    End If

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabSetting", "TabSetting();", True) 'Script of TabStrip

    'End Sub

    'Protected Sub btnSearchSetting_Click(sender As Object, e As ImageClickEventArgs) Handles btnSearchSetting.Click

    '    SetbtnSearchSetting()
    '    Dim dt As New DataTable
    '    dt = CType(Cache("Data"), DataTable)
    '    If dt.Rows.Count > 0 Then

    '    Else
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Data found !');", True)

    '    End If

    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabSetting", "TabSetting();", True) 'Script of TabStrip

    'End Sub


    'Protected Sub ExportServerSetting(sender As Object, e As EventArgs)

    '    'SetgvServerSetting()
    '    gvSettingS2.DataSource = CType(Cache("Data"), DataTable)
    '    Dim dt As DataTable = gvSettingS2.DataSource
    '    If dt.Rows.Count > 0 Then

    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport" & DateTime.Now & ".xls ")
    '        Response.Charset = "tis-620"
    '        Response.ContentType = "application/vnd.ms-excel"
    '        Dim ms As New System.IO.MemoryStream()
    '        Dim streamWrite As New System.IO.StreamWriter(ms, Encoding.UTF8)
    '        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(streamWrite)
    '        'To Export all pages
    '        gvSettingS2.AllowPaging = False
    '        gvSettingS2.DataSource = CType(Cache("Data"), DataTable)

    '        gvSettingS2.HeaderRow.BackColor = Color.White
    '        For Each cell As TableCell In gvSettingS2.HeaderRow.Cells
    '            cell.BackColor = gvSettingS2.HeaderStyle.BackColor
    '        Next

    '        For Each row As GridViewRow In gvSettingS2.Rows
    '            row.BackColor = Color.White
    '            For Each cell As TableCell In row.Cells
    '                If row.RowIndex Mod 2 = 0 Then
    '                    cell.BackColor = gvSettingS2.AlternatingRowStyle.BackColor
    '                Else
    '                    cell.BackColor = gvSettingS2.RowStyle.BackColor
    '                End If
    '                cell.CssClass = "textmode"
    '            Next
    '        Next

    '        gvSettingS2.RenderControl(htmlWrite)
    '        'style to format numbers to string
    '        Dim style As String = Encoding.UTF8.GetString(ms.ToArray)
    '        Response.Write(style)
    '        Response.Output.Write(streamWrite.ToString())
    '        Response.Flush()
    '        Response.[End]()

    '    Else
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Data!');", True)
    '    End If
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabSetting", "TabSetting();", True) 'Script of TabStrip
    'End Sub

    'Protected Sub ExportGroupSetting(sender As Object, e As EventArgs)

    '    SetgvGroupSetting()
    '    gvSettingG2.DataSource = CType(Cache("Data"), DataTable)
    '    Dim dt As DataTable = gvSettingG2.DataSource
    '    If dt.Rows.Count > 0 Then

    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport" & DateTime.Now & ".xls")
    '        Response.Charset = "tis-620"
    '        Response.ContentType = "application/vnd.ms-excel"

    '        Dim ms As New System.IO.MemoryStream()
    '        Dim streamWrite As New System.IO.StreamWriter(ms, Encoding.UTF8)
    '        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(streamWrite)

    '        'To Export all pages
    '        gvSettingG2.AllowPaging = False
    '        gvSettingG2.DataSource = CType(Cache("Data"), DataTable)

    '        gvSettingG2.HeaderRow.BackColor = Color.White
    '        For Each cell As TableCell In gvSettingG2.HeaderRow.Cells
    '            cell.BackColor = gvSettingG2.HeaderStyle.BackColor
    '        Next

    '        For Each row As GridViewRow In gvSettingG2.Rows
    '            row.BackColor = Color.White
    '            For Each cell As TableCell In row.Cells
    '                If row.RowIndex Mod 2 = 0 Then
    '                    cell.BackColor = gvSettingG2.AlternatingRowStyle.BackColor
    '                Else
    '                    cell.BackColor = gvSettingG2.RowStyle.BackColor
    '                End If
    '                cell.CssClass = "textmode"
    '            Next
    '        Next

    '        gvSettingG2.RenderControl(htmlWrite)
    '        'style to format numbers to string
    '        Dim style As String = Encoding.UTF8.GetString(ms.ToArray)
    '        Response.Write(style)
    '        Response.Output.Write(streamWrite.ToString())
    '        Response.Flush()
    '        Response.[End]()

    '    Else
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Data!');", True)
    '    End If
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabSetting", "TabSetting();", True) 'Script of TabStrip
    'End Sub

    Protected Sub ExportServerAlarm(sender As Object, e As EventArgs)

        'SetgvAlarmServer()
        gvAlarmS2.DataSource = CType(Cache("Data"), DataTable)
        Dim dt As DataTable = gvAlarmS2.DataSource
        If dt.Rows.Count > 0 Then

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport" & DateTime.Now & ".xls")
            Response.Charset = "tis-620"
            Response.ContentType = "application/vnd.ms-excel"

            Dim ms As New System.IO.MemoryStream()
            Dim streamWrite As New System.IO.StreamWriter(ms, Encoding.UTF8)
            Dim htmlWrite As New System.Web.UI.HtmlTextWriter(streamWrite)
           
            'To Export all pages
            gvAlarmS2.AllowPaging = False
            gvAlarmS2.DataSource = CType(Cache("Data"), DataTable)

            gvAlarmS2.HeaderRow.BackColor = Color.White
            For Each cell As TableCell In gvAlarmS2.HeaderRow.Cells
                cell.BackColor = gvAlarmS2.HeaderStyle.BackColor
            Next

            For Each row As GridViewRow In gvAlarmS2.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 = 0 Then
                        cell.BackColor = gvAlarmS2.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = gvAlarmS2.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            gvAlarmS2.RenderControl(htmlWrite)
            'style to format numbers to string
            Dim style As String = Encoding.UTF8.GetString(ms.ToArray)

            Response.Write(style)
            Response.Output.Write(streamWrite.ToString())
            Response.Flush()
            Response.[End]()

        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Data!');", True)
        End If
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabAlarm", "TabAlarm();", True) 'Script of TabStrip
    End Sub

   Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub

    Protected Sub gvAlarmServer_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAlarmServer.RowCommand
        If e.CommandName = "Detail" Then

            Dim RowIndex As Integer
            Integer.TryParse(e.CommandArgument.ToString, RowIndex)
            Dim svIP As String = gvAlarmServer.Rows(RowIndex).Cells(3).Text
            Session("ServerIP") = svIP.ToString

            If Not Page.ClientScript.IsClientScriptBlockRegistered("MyScript") Then

                Response.Write("<script language=javascript>window.open('frmPopupServerChart.aspx','_blank','height=650px,width=1000px,scrollbars=1,left=200,top=15');</script>")

            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "TabAlarm", "TabAlarm();", True) 'Script of TabStrip
        End If

    End Sub


End Class
