Imports LinqDB.TABLE
Imports LinqDB.ConnectDB
Imports System.Data

Partial Class frmSearchPositionFile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            btnStop.Style.Add("display", "none")
        End If
    End Sub

    Protected Sub btnSearch_ServerClick(sender As Object, e As EventArgs)
        ClearPoint()
        ' SetPoint()
        SetPointByData()
        Timer1.Enabled = True
        btnStop.Style.Add("display", "")
        btnSearch.Style.Add("display", "none")
    End Sub

    Private Function GetPoint() As String
        Try
            '54040001  54040002 54040003 54040004
            Dim sql As String
            

            'sql = " select table1.tag_no,table1.ant_id,min(table1.rssi) as rssi from ("
            'sql &= " select top 5  rssi , ant_id ,tag_no from TS_DOC_TRACKING_LOG where left(tag_no,10)='" & txtAppno.Value & "'"
            'sql &= " order by log_time desc) as table1"
            'sql &= " group by table1.tag_no,table1.ant_id"
            'sql &= " order by   min(table1.rssi) asc"
            'Dim dt As DataTable
            'Dim tran As New TransactionDB
            'Dim clsTsDocTrackingLogLinqDB As New TsDocTrackingLogLinqDB
            'With clsTsDocTrackingLogLinqDB
            '    dt = .GetListBySql(sql, Nothing)

            '    If dt.Rows.Count > 0 Then
            '        Return dt.Rows("0")("ant_id") & ""
            '    Else
            '        Return 0
            '    End If
            'End With

        Catch ex As Exception
            Return 0
        End Try


    End Function
    Private Sub SetPoint()
        Dim image = New HtmlImage
        Dim strRandom As String = GetRandom(1, 25)
        '  strRandom = 1
        Select Case strRandom
            Case 1
                image = cell1
                image.Attributes.Add("src", "images/Untitled_01.jpg")
                'image.Attributes.Add("class", "blink")
            Case 2
                image = cell2
                image.Attributes.Add("src", "images/Untitled_02.jpg")
                'image.Attributes.Add("class", "blink")
            Case 3
                image = cell3
                image.Attributes.Add("src", "images/Untitled_03.jpg")
                'image.Attributes.Add("class", "blink")
            Case 4
                image = cell4
                image.Attributes.Add("src", "images/Untitled_04.jpg")
                'image.Attributes.Add("class", "blink")
            Case 5
                image = cell5
                image.Attributes.Add("src", "images/Untitled_05.jpg")
                'image.Attributes.Add("class", "blink")
            Case 6
                image = cell6
                image.Attributes.Add("src", "images/Untitled_06-red.jpg")
                image.Attributes.Add("class", "blink")
                ' image.Attributes.Add("onmouseover", "")
                ' image.Attributes.Add("data-geo", "")
            Case 7
                image = cell7
                image.Attributes.Add("src", "images/Untitled_07-red.jpg")
                image.Attributes.Add("class", "blink")
            Case 8
                image = cell8
                image.Attributes.Add("src", "images/Untitled_08.jpg")
                'image.Attributes.Add("class", "blink")
            Case 9
                image = cell9
                image.Attributes.Add("src", "images/Untitled_09-red.jpg")
                image.Attributes.Add("class", "blink")

            Case 10
                image = cell10
                image.Attributes.Add("src", "images/Untitled_10-red.jpg")
                image.Attributes.Add("class", "blink")

            Case 11
                image = cell11
                image.Attributes.Add("src", "images/Untitled_11-red.jpg")
                image.Attributes.Add("class", "blink")

            Case 12
                image = cell12
                image.Attributes.Add("src", "images/Untitled_12-red.jpg")
                image.Attributes.Add("class", "blink")

            Case 13
                image = cell13
                image.Attributes.Add("src", "images/Untitled_13.jpg")
                ' image.Attributes.Add("class", "blink")
            Case 14
                image = cell14
                image.Attributes.Add("src", "images/Untitled_14-red.jpg")
                image.Attributes.Add("class", "blink")

            Case 15
                image = cell15
                image.Attributes.Add("src", "images/Untitled_15-red.jpg")
                image.Attributes.Add("class", "blink")

            Case 16
                image = cell16
                image.Attributes.Add("src", "images/Untitled_16.jpg")
                ' image.Attributes.Add("class", "blink")
            Case 17
                image = cell17
                image.Attributes.Add("src", "images/Untitled_17.jpg")
                'image.Attributes.Add("class", "blink")
            Case 18
                image = cell18
                image.Attributes.Add("src", "images/Untitled_18.jpg")
                'image.Attributes.Add("class", "blink")
            Case 19
                image = cell19
                image.Attributes.Add("src", "images/Untitled_19.jpg")
                'image.Attributes.Add("class", "blink")
            Case 20
                image = cell20
                image.Attributes.Add("src", "images/Untitled_20.jpg")
                'image.Attributes.Add("class", "blink")
            Case 21
                image = cell21
                image.Attributes.Add("src", "images/Untitled_21-red.jpg")
                image.Attributes.Add("class", "blink")
            Case 22
                image = cell22
                image.Attributes.Add("src", "images/Untitled_22.jpg")
                ' image.Attributes.Add("class", "blink")
            Case 23
                image = cell23
                image.Attributes.Add("src", "images/Untitled_23.jpg")
                'image.Attributes.Add("class", "blink")
            Case 24
                image = cell24
                image.Attributes.Add("src", "images/Untitled_24-red.jpg")
                image.Attributes.Add("class", "blink")
            Case 25
                image = cell25
                image.Attributes.Add("src", "images/Untitled_25-red.jpg")
                image.Attributes.Add("class", "blink")
        End Select



    End Sub

    Private Sub SetPointByData()
        Dim strPoint As String
        Dim image = New HtmlImage
        Dim strRandom As String = GetRandom(1, 11)

        strPoint = GetPoint()
        If strPoint = 0 Then
            strPoint = strRandom
        End If
        If strPoint = 0 Then
            Select Case strRandom
                Case 1
                    image = cell6
                    image.Attributes.Add("src", "images/Untitled_06-red.jpg")
                    image.Attributes.Add("class", "blink")
                    ' image.Attributes.Add("onmouseover", "")
                    ' image.Attributes.Add("data-geo", "")
                Case 2
                    image = cell7
                    image.Attributes.Add("src", "images/Untitled_07-red.jpg")
                    image.Attributes.Add("class", "blink")
                Case 3
                    image = cell9
                    image.Attributes.Add("src", "images/Untitled_09-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 4
                    image = cell10
                    image.Attributes.Add("src", "images/Untitled_10-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 5
                    image = cell11
                    image.Attributes.Add("src", "images/Untitled_11-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 6
                    image = cell12
                    image.Attributes.Add("src", "images/Untitled_12-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 7
                    image = cell14
                    image.Attributes.Add("src", "images/Untitled_14-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 8
                    image = cell15
                    image.Attributes.Add("src", "images/Untitled_15-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 9
                    image = cell21
                    image.Attributes.Add("src", "images/Untitled_21-red.jpg")
                    image.Attributes.Add("class", "blink")
                Case 10
                    image = cell24
                    image.Attributes.Add("src", "images/Untitled_24-red.jpg")
                    image.Attributes.Add("class", "blink")
                Case 11
                    image = cell25
                    image.Attributes.Add("src", "images/Untitled_25-red.jpg")
                    image.Attributes.Add("class", "blink")
            End Select
        Else
            Select Case strPoint
                Case 1
                    image = cell6
                    image.Attributes.Add("src", "images/Untitled_06-red.jpg")
                    image.Attributes.Add("class", "blink")
                    ' image.Attributes.Add("onmouseover", "")
                    ' image.Attributes.Add("data-geo", "")
                Case 2
                    image = cell7
                    image.Attributes.Add("src", "images/Untitled_07-red.jpg")
                    image.Attributes.Add("class", "blink")
                Case 3
                    image = cell9
                    image.Attributes.Add("src", "images/Untitled_09-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 4
                    image = cell10
                    image.Attributes.Add("src", "images/Untitled_10-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 5
                    image = cell11
                    image.Attributes.Add("src", "images/Untitled_11-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 6
                    image = cell12
                    image.Attributes.Add("src", "images/Untitled_12-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 7
                    image = cell14
                    image.Attributes.Add("src", "images/Untitled_14-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 8
                    image = cell15
                    image.Attributes.Add("src", "images/Untitled_15-red.jpg")
                    image.Attributes.Add("class", "blink")

                Case 9
                    image = cell21
                    image.Attributes.Add("src", "images/Untitled_21-red.jpg")
                    image.Attributes.Add("class", "blink")
                Case 10
                    image = cell24
                    image.Attributes.Add("src", "images/Untitled_24-red.jpg")
                    image.Attributes.Add("class", "blink")
                Case 11
                    image = cell25
                    image.Attributes.Add("src", "images/Untitled_25-red.jpg")
                    image.Attributes.Add("class", "blink")
            End Select
        End If




    End Sub
    Private Sub ClearPoint()
        cell1.Attributes.Add("src", "~/images/Untitled_01.jpg")
        cell1.Attributes.Add("class", "")
        cell2.Attributes.Add("src", "~/images/Untitled_02.jpg")
        cell2.Attributes.Add("class", "")
        cell3.Attributes.Add("src", "~/images/Untitled_03.jpg")
        cell3.Attributes.Add("class", "")
        cell4.Attributes.Add("src", "~/images/Untitled_04.jpg")
        cell4.Attributes.Add("class", "")
        cell5.Attributes.Add("src", "~/images/Untitled_05.jpg")
        cell5.Attributes.Add("class", "")
        cell6.Attributes.Add("src", "~/images/Untitled_06.jpg")
        cell6.Attributes.Add("class", "")
        cell7.Attributes.Add("src", "~/images/Untitled_07.jpg")
        cell7.Attributes.Add("class", "")
        cell8.Attributes.Add("src", "~/images/Untitled_08.jpg")
        cell8.Attributes.Add("class", "")
        cell9.Attributes.Add("src", "~/images/Untitled_09.jpg")
        cell9.Attributes.Add("class", "")
        cell10.Attributes.Add("src", "~/images/Untitled_10.jpg")
        cell10.Attributes.Add("class", "")
        cell11.Attributes.Add("src", "~/images/Untitled_11.jpg")
        cell11.Attributes.Add("class", "")
        cell12.Attributes.Add("src", "~/images/Untitled_12.jpg")
        cell12.Attributes.Add("class", "")
        cell13.Attributes.Add("src", "~/images/Untitled_13.jpg")
        cell13.Attributes.Add("class", "")
        cell14.Attributes.Add("src", "~/images/Untitled_14.jpg")
        cell14.Attributes.Add("class", "")
        cell15.Attributes.Add("src", "~/images/Untitled_15.jpg")
        cell15.Attributes.Add("class", "")
        cell16.Attributes.Add("src", "~/images/Untitled_16.jpg")
        cell16.Attributes.Add("class", "")
        cell17.Attributes.Add("src", "~/images/Untitled_17.jpg")
        cell17.Attributes.Add("class", "")
        cell18.Attributes.Add("src", "~/images/Untitled_18.jpg")
        cell18.Attributes.Add("class", "")
        cell19.Attributes.Add("src", "~/images/Untitled_19.jpg")
        cell19.Attributes.Add("class", "")
        cell20.Attributes.Add("src", "~/images/Untitled_20.jpg")
        cell20.Attributes.Add("class", "")
        cell21.Attributes.Add("src", "~/images/Untitled_21.jpg")
        cell21.Attributes.Add("class", "")
        cell22.Attributes.Add("src", "~/images/Untitled_22.jpg")
        cell22.Attributes.Add("class", "")
        cell23.Attributes.Add("src", "~/images/Untitled_23.jpg")
        cell23.Attributes.Add("class", "")
        cell24.Attributes.Add("src", "~/images/Untitled_24.jpg")
        cell24.Attributes.Add("class", "")
        cell25.Attributes.Add("src", "~/images/Untitled_25.jpg")
        cell25.Attributes.Add("class", "")
    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If txtAppno.Value <> "" Then
            btnSearch_ServerClick(Nothing, Nothing)
        End If
        'Timer1
    End Sub

    Protected Sub btnStop_ServerClick(sender As Object, e As EventArgs)
        Timer1.Enabled = False
        btnSearch.Style.Add("display", "")
        btnStop.Style.Add("display", "none")
    End Sub
End Class
