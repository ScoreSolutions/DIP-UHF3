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
        If txtUser.Text <> "" Then
            dt.DefaultView.RowFilter = " user like '%" & txtUser.Text.Trim & "%'"
        End If
        gvData.DataSource = dt.DefaultView
        gvData.DataBind()
    End Sub

    Function SetData() As DataTable
        Dim dt As New DataTable
        With dt
            .Columns.Add("user", GetType(String))
            .Columns.Add("devision", GetType(String))
            .Columns.Add("file", GetType(String))
        End With

        Dim dr As DataRow
        dr = dt.NewRow
        dr("user") = "อัครวัฒน์ พุทธจันทร์"
        dr("devision") = "Development"
        dr("file") = "เอกสาร1"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "อัครวัฒน์ พุทธจันทร์"
        dr("devision") = "Development"
        dr("file") = "เอกสาร2"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "อัครวัฒน์ พุทธจันทร์"
        dr("devision") = "Development"
        dr("file") = "เอกสาร3"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "จตุพล มุริจันทร์"
        dr("devision") = "Development"
        dr("file") = "เอกสาร4"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "จตุพล มุริจันทร์"
        dr("devision") = "Development"
        dr("file") = "เอกสาร5"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "จตุพล มุริจันทร์"
        dr("devision") = "Development"
        dr("file") = "เอกสาร6"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "นงค์นุช บุญมั่งมี"
        dr("devision") = "Development"
        dr("file") = "เอกสาร7"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "นงค์นุช บุญมั่งมี"
        dr("devision") = "Development"
        dr("file") = "เอกสาร8"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "ศิรพงศ์ นิธิพรพัฒนชัย"
        dr("devision") = "Development"
        dr("file") = "เอกสาร9"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "ศิรพงศ์ นิธิพรพัฒนชัย"
        dr("devision") = "Development"
        dr("file") = "เอกสาร10"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "ศิรพงศ์ นิธิพรพัฒนชัย"
        dr("devision") = "Development"
        dr("file") = "เอกสาร11"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "ศิรพงศ์ นิธิพรพัฒนชัย"
        dr("devision") = "Development"
        dr("file") = "เอกสาร12"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "ธีรวุฒิ เสือทะยาน"
        dr("devision") = "Development"
        dr("file") = "เอกสาร13"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "ธีรวุฒิ เสือทะยาน"
        dr("devision") = "Development"
        dr("file") = "เอกสาร14"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("user") = "ธีรวุฒิ เสือทะยาน"
        dr("devision") = "Development"
        dr("file") = "เอกสาร15"
        dt.Rows.Add(dr)

        Return dt
    End Function

End Class
