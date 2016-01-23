Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Drawing
Imports System.Net.Mail

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim ViewReport As String = Session("idres2")
        'Dim ViewOnly As String = Session("idres3")
        If ViewReport Is Nothing Then
            btnExportHistory.Visible = False

        End If

        If Not IsPostBack Then
            SetgvAlarmHistory()
        End If
        gvAlarmH.PageIndex = 0

    End Sub

    Private Sub SetgvAlarmHistory()

        Dim dt As DataTable
        Dim Eng As New HistoryEng

        dt = Eng.GetgvAlarmHistory()

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvAlarmH.DataSource = dt
            gvAlarmH.DataBind()
            GridView1.DataSource = dt
            GridView1.DataBind()
            Cache("Data") = dt

            If dt.Rows.Count > 0 Then
                btnExportHistory.Enabled = True
                Button1.Enabled = True
                Button2.Enabled = True
            Else
                btnExportHistory.Enabled = False
                Button1.Enabled = False
                'Button2.Enabled = False

                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvAlarmH.DataSource = dt
                gvAlarmH.DataBind()
                Dim columnCount As Integer = gvAlarmH.Rows(0).Cells.Count
                gvAlarmH.Rows(0).Cells.Clear()
                gvAlarmH.Rows(0).Cells.Add(New TableCell)
                gvAlarmH.Rows(0).Cells(0).ColumnSpan = columnCount
                gvAlarmH.Rows(0).Cells(0).Text = "No Records Found."

            End If

        Else
            gvAlarmH.DataSource = Nothing
        End If

    End Sub

    Private Sub SetbtnAlarmHistory()

        Dim dt As DataTable
        Dim Eng As New HistoryEng

        dt = Eng.GetbtnAlarmHistory(txtServerName.Text, txtIP.Text, txtSpecProb.Text, drpAlarmT.SelectedValue, drpViewby.SelectedValue.ToString, txtDate.Text, txtToDate.Text, txtTime.Text, txtToTime.Text)

        If Not dt Is Nothing Then

            dt.Columns.Add("No", GetType(Long))
            For i As Integer = 0 To dt.Rows.Count - 1

                dt.Rows(i)("No") = i + 1
            Next

            gvAlarmH.DataSource = dt
            gvAlarmH.DataBind()
            GridView1.DataSource = dt
            GridView1.DataBind()
            Cache("Data") = dt

            If dt.Rows.Count = 0 Then
                Dim dr As DataRow
                dr = dt.NewRow
                dt.Rows.Add(dr)
                gvAlarmH.DataSource = dt
                gvAlarmH.DataBind()
                Dim columnCount As Integer = gvAlarmH.Rows(0).Cells.Count
                gvAlarmH.Rows(0).Cells.Clear()
                gvAlarmH.Rows(0).Cells.Add(New TableCell)
                gvAlarmH.Rows(0).Cells(0).ColumnSpan = columnCount
                gvAlarmH.Rows(0).Cells(0).Text = "No Records Found."

                btnExportHistory.Enabled = False
            End If

        Else
            gvAlarmH.DataSource = Nothing

        End If

    End Sub

    'Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click

    '    SetbtnAlarmHistory()

    '    Dim dt As New DataTable
    '    dt = CType(Cache("Data"), DataTable)
    '    If dt.Rows.Count > 0 Then

    '    Else
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Data found !');", True)

    '    End If


    'End Sub

    Protected Sub gvAlarmH_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvAlarmH.PageIndexChanging
        SetgvAlarmHistory()
        gvAlarmH.PageIndex = e.NewPageIndex
        gvAlarmH.DataSource = CType(Cache("Data"), DataTable)
        gvAlarmH.DataBind()
        SetbtnAlarmHistory()
    End Sub

    Public Sub ClearTextBox(ByVal root As Control)

        ' Control for clear all textboxs
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
        'SetgvAlarmHistory()
        'SetbtnAlarmHistory()
        drpAlarmT.SelectedValue = "Select"
        drpViewby.SelectedValue = "Select"

    End Sub

    Protected Sub ExportHistory(sender As Object, e As EventArgs)
        GridView1.DataSource = CType(Cache("Data"), DataTable)
        Dim dt As DataTable = GridView1.DataSource
        If dt.Rows.Count > 0 Then

            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport" & DateTime.Now & ".xls ")
            Response.Charset = "tis-620"
            Response.ContentType = "application/vnd.ms-excel"
            Dim ms As New System.IO.MemoryStream()
            Dim streamWrite As New System.IO.StreamWriter(ms, Encoding.UTF8)
            Dim htmlWrite As New System.Web.UI.HtmlTextWriter(streamWrite)
            'To Export all pages
            GridView1.AllowPaging = False
            GridView1.DataSource = CType(Cache("Data"), DataTable)

            GridView1.HeaderRow.BackColor = Color.White
            For Each cell As TableCell In GridView1.HeaderRow.Cells
                cell.BackColor = GridView1.HeaderStyle.BackColor
            Next

            For Each row As GridViewRow In GridView1.Rows
                row.BackColor = Color.White
                For Each cell As TableCell In row.Cells
                    If row.RowIndex Mod 2 > 0 Then
                        cell.BackColor = GridView1.AlternatingRowStyle.BackColor
                    Else
                        cell.BackColor = GridView1.RowStyle.BackColor
                    End If
                    cell.CssClass = "textmode"
                Next
            Next

            GridView1.RenderControl(htmlWrite)
            'style to format numbers to string
            Dim style As String = Encoding.UTF8.GetString(ms.ToArray)
            Response.Write(style)
            Response.Output.Write(streamWrite.ToString())
            Response.Flush()
            Response.[End]()

        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Data!');", True)
        End If


    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered
    End Sub


    Protected Sub ImgCalendarF_Click(sender As Object, e As ImageClickEventArgs) Handles ImgCalendarF.Click

        If Calendar1.Visible = True Then
            Calendar1.Visible = False
        Else
            Calendar1.Visible = True
            Calendar2.Visible = False
        End If
        SetgvAlarmHistory()
    End Sub


    Protected Sub ImgCalendarT_Click(sender As Object, e As ImageClickEventArgs) Handles ImgCalendarT.Click

        If Calendar2.Visible = True Then
            Calendar2.Visible = False
        Else
            Calendar2.Visible = True
            Calendar1.Visible = False
        End If
        SetgvAlarmHistory()
    End Sub


    Protected Sub Calendar1_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar1.SelectionChanged

        txtDate.Text = Calendar1.SelectedDate.ToShortDateString()
        Calendar1.Visible = False
        SetgvAlarmHistory()
    End Sub

    Protected Sub Calendar2_SelectionChanged(sender As Object, e As EventArgs) Handles Calendar2.SelectionChanged

        txtToDate.Text = Calendar2.SelectedDate.ToShortDateString()
        Calendar2.Visible = False
        SetgvAlarmHistory()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        SetbtnAlarmHistory()

        Dim dt As New DataTable
        dt = CType(Cache("Data"), DataTable)
        If dt.Rows.Count > 0 Then

        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('No Data found !');", True)

        End If

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SetgvAlarmHistory()
        ClearTextBox(Me)
    End Sub

 
    Protected Sub drpViewby_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpViewby.SelectedIndexChanged
        SetgvAlarmHistory()
    End Sub
End Class
