Imports System.Data
Imports InfoSoftGlobal
Imports System.IO
Imports System.Xml
Partial Class frmTagRoot
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSearch_ServerClick(sender As Object, e As EventArgs) 'Handles btnSearch.ServerClick
        If txtTag.Text.Trim() = "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('กรุณาระบุเลขที่แฟ้ม');", True)
            Exit Sub
        End If

        SearchLifeCycle()
        'DisplayLineChart()
        SearchForLineGrap()
    End Sub

    'Sub DisplayLineChart()
    '    Try
    '        Ltl1.Text = FusionCharts.RenderChart("FusionCharts/FCF_Line.swf", "Data/Data.xml", "", "chart1", "900", "300", False, False)
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Sub SearchForLineGrap()
        Dim dt As New DataTable
        dt = SetDataLineGrap()
        If txtTag.Text <> "" Then
            dt.DefaultView.RowFilter = " Tag ='" & txtTag.Text.Trim & "'"
        End If

        Dim avg As Double = 0.0
        For i As Integer = 0 To dt.DefaultView.Count - 1
            Try
                avg += CInt(dt.DefaultView(i).Item("value"))
            Catch ex As Exception
            End Try
        Next

        If avg > 0 AndAlso dt.Rows.Count > 0 Then
            avg = avg / dt.DefaultView.Count
        End If

        lblAvgVal.Text = "ค่าเฉลี่ย =" & avg.ToString("##.00")
        If dt.DefaultView.Count > 0 Then
            btnAvg.Visible = True
            For i As Integer = 0 To dt.DefaultView.Count - 1
                Dim name As String = dt.DefaultView(i).Item("name")
                Dim value As String = dt.DefaultView(i).Item("value")
                Chart1.Series(0).Points.AddXY(name, value)
                Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Spline
                Chart1.Series(0).BorderWidth = 3

                'Chart1.ChartAreas(0).AxisX.IsStartedFromZero = True
                'Chart1.Series(0).Color = Drawing.Color.Orange

                Chart1.Series(1).Points.AddXY(name, avg)
                Chart1.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Spline
                Chart1.Series(1).BorderWidth = 3
                Chart1.Series(1).Color = Drawing.Color.Red
            Next
        End If
    End Sub

    Sub SearchLifeCycle()
        Dim dt As New DataTable
        dt = SetDataLifeCycle()
        dt.Columns.Add("seq", GetType(String))
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("seq") = i + 1
        Next
        If txtTag.Text <> "" Then
            dt.DefaultView.RowFilter = " Tag ='" & txtTag.Text.Trim & "'"
        End If

        imgTimeLine.ImageUrl = "images\0.png"
        If dt.DefaultView.Count > 0 Then
            For i As Integer = 0 To dt.DefaultView.Count - 1
                Dim status As String = dt.DefaultView(i)("status")
                Select Case status
                    Case 1
                        imgTimeLine.ImageUrl = "images\1.png"
                    Case 2
                        imgTimeLine.ImageUrl = "images\2.png"
                    Case 3
                        imgTimeLine.ImageUrl = "images\3.png"
                End Select
            Next
        End If
    End Sub

    Function SetDataLifeCycle() As DataTable
        Dim dt As New DataTable
        With dt
            .Columns.Add("Tag", GetType(String))
            .Columns.Add("datetime", GetType(String))
            .Columns.Add("status", GetType(String))
        End With

        Dim dr As DataRow
        dr = dt.NewRow
        dr("Tag") = "0054040001"
        dr("datetime") = "01/01/2014 10:20"
        dr("status") = "1"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Tag") = "0054040001"
        dr("datetime") = "02/01/2014 13:20"
        dr("status") = "2"
        dt.Rows.Add(dr)

        'dr = dt.NewRow
        'dr("Tag") = "54040001"
        'dr("datetime") = "03/01/2014 10:00"
        'dr("status") = "3"
        'dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Tag") = "0054040002"
        dr("datetime") = "01/01/2014 10:20"
        dr("status") = "1"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Tag") = "0054040002"
        dr("datetime") = "04/01/2014 11:55"
        dr("status") = "2"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Tag") = "0054040002"
        dr("datetime") = "05/01/2014 09:10"
        dr("status") = "3"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Tag") = "0054040003"
        dr("datetime") = "02/01/2014 08:30"
        dr("status") = "1"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Tag") = "0054040003"
        dr("datetime") = "03/01/2014 10:24"
        dr("status") = "2"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Tag") = "0054040004"
        dr("datetime") = "10/01/2014 10:40"
        dr("status") = "1"
        dt.Rows.Add(dr)
        Return dt
    End Function


    Protected Function DisplayFunction() As String
        Dim str As String = ""
        If txtTag.Text.Trim <> "" Then
            Dim dt As New DataTable
            dt = SetDataLineGrap()
            If txtTag.Text <> "" Then
                dt.DefaultView.RowFilter = " Tag ='" & txtTag.Text.Trim & "'"
            End If

            For i As Integer = 0 To dt.DefaultView.Count - 1
                str &= "ชื่อเจ้าหน้าที่: " & dt.DefaultView(i)("name") & "   " & "วันที่ยืม: 1" & i & "/11/2014" & "   " & "วันที่คืน: 1" & i + 3 & "/11/2014" & "</br>"
                'str &= i & "zzaaccvv</br>"
            Next
        End If
        Return str
    End Function
    Function SetDataLineGrap() As DataTable
        Dim dt As New DataTable
        With dt
            .Columns.Add("Name", GetType(String))
            .Columns.Add("value", GetType(String))
            .Columns.Add("tag", GetType(String))
        End With

        Dim dr As DataRow
        dr = dt.NewRow
        dr("Name") = "อัครวัฒน์ พุทธจันทร์"
        dr("value") = "50"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "จตุพล มุริจันทร์"
        dr("value") = "10"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "ธีรวุฒิ เสือทะยาน"
        dr("value") = "24"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "ศิระพงศ์ นิธิพรพัฒนชัย"
        dr("value") = "4"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "นงค์นุช บุญมั่งมี"
        dr("value") = "50"
        dr("tag") = "0054040001"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "ศิระพงศ์ นิธิพรพัฒนชัย"
        dr("value") = "40"
        dr("tag") = "0054040002"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "ธีรวุฒิ เสือทะยาน"
        dr("value") = "80"
        dr("tag") = "0054040002"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "นงค์นุช บุญมั่งมี"
        dr("value") = "35"
        dr("tag") = "0054040002"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "จตุพล มุริจันทร์"
        dr("value") = "40"
        dr("tag") = "0054040002"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "อัครวัฒน์ พุทธจันทร์"
        dr("value") = "14"
        dr("tag") = "0054040003"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "นงค์นุช บุญมั่งมี"
        dr("value") = "40"
        dr("tag") = "0054040003"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "ธีรวุฒิ เสือทะยาน"
        dr("value") = "25"
        dr("tag") = "0054040003"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "ศิระพงศ์ นิธิพรพัฒนชัย"
        dr("value") = "5"
        dr("tag") = "0054040004"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "จตุพล มุริจันทร์"
        dr("value") = "18"
        dr("tag") = "0054040004"
        dt.Rows.Add(dr)

        dr = dt.NewRow
        dr("Name") = "ธีรวุฒิ เสือทะยาน"
        dr("value") = "25"
        dr("tag") = "0054040004"
        dt.Rows.Add(dr)
        Return dt
    End Function

End Class
