Imports System.Data

Partial Class frmTagRoot
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_ServerClick(sender As Object, e As EventArgs) Handles btnSearch.ServerClick
        Dim dt As New DataTable
        dt = SetData()
        dt.Columns.Add("seq", GetType(String))
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("seq") = i + 1
        Next
        If txtTag.Text <> "" Then
            dt.DefaultView.RowFilter = " tag='" & txtTag.Text.Trim & "'"
        End If
        gvData.DataSource = dt.DefaultView
        gvData.DataBind()
    End Sub

    Function SetData() As DataTable
        Dim dt As New DataTable
        With dt
            .Columns.Add("gate", GetType(String))
            .Columns.Add("datetime", GetType(String))
            .Columns.Add("tag", GetType(String))
        End With

        Dim dr As DataRow
        dr = dt.NewRow
        dr("gate") = "ประตู 1"
        dr("datetime") = "01/01/2014 10:20"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 2"
        dr("datetime") = "01/01/2014 10:25"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 3"
        dr("datetime") = "01/01/2014 10:30"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 4"
        dr("datetime") = "01/01/2014 10:35"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 5"
        dr("datetime") = "01/01/2014 10:40"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 6"
        dr("datetime") = "01/01/2014 10:45"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 7"
        dr("datetime") = "01/01/2014 10:50"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 8"
        dr("datetime") = "01/01/2014 11:00"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 9"
        dr("datetime") = "01/01/2014 11:20"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 10"
        dr("datetime") = "01/01/2014 11:30"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 3"
        dr("datetime") = "01/01/2014 11:00"
        dr("tag") = "0054040002"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 4"
        dr("datetime") = "01/01/2014 11:20"
        dr("tag") = "0054040002"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 5"
        dr("datetime") = "01/01/2014 11:30"
        dr("tag") = "0054040002"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 6"
        dr("datetime") = "01/01/2014 11:40"
        dr("tag") = "0054040002"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("gate") = "ประตู 7"
        dr("datetime") = "01/01/2014 11:50"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        Return dt
    End Function

End Class
