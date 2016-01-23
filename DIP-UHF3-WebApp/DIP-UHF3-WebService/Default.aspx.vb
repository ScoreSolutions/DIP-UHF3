Imports Newtonsoft.Json
Imports Engine
Imports System.Data
Imports Engine.LogFile.LogENG

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Response.Write("1234567890ABCDE".Substring(0, 10))


        Dim SerialNo As String = Request("SerialNo")
        Select Case Request("MethodName")
            Case "SpeedwaySetting"

                SaveTransLog("DIP-UHF3-WebService.Default.aspx", Request("MethodName"), Request.Url.ToString)

                Dim xmlData As String = Engine.SpeedwayENG.GetSpeedwaySettingXML("DIP-UHF3-WebService", SerialNo)
                Response.Write(xmlData)
            Case "AntennaConfig"
                SaveTransLog("DIP-UHF3-WebService.Default.aspx", Request("MethodName"), Request.Url.ToString)

                Dim ReadArea As String = Engine.SpeedwayENG.GetSpeedwayGridAreaText("DIP-UHF3-WebService", SerialNo)
                Response.Write(ReadArea)
            Case "FileCurrentGrid"
                Dim TagNo As String = Request("TagNo").ToString.Substring(0, 10)
                Dim MoveDate As DateTime = DateTime.Now
                Dim sDt As DataTable = SpeedwayENG.GetSpeedWayBySerialNo(SerialNo)

                Dim AntNo As String = Request("AntNumber")
                Dim Rssi As String = Request("rssi")
                Dim Location As String = sDt.Rows(0)("floor_name") & " " & sDt.Rows(0)("room_name")
                Dim RoomID As Integer = sDt.Rows(0)("ms_room_id")
                Dim LayoutID As String = Request("LayoutID")
                Dim GridRow As String = Request("GridRow")
                Dim GridCol As String = Request("GridCol")

                Dim ret As Boolean = Engine.FileLocationENG.SaveFileCurrentGrid("DIP-UHF3-WebService", TagNo, MoveDate, sDt.Rows(0)("ReaderID"), AntNo, Rssi, Location, RoomID, LayoutID, GridCol, GridRow)

                SaveTransLog("DIP-UHF3-WebService.Default.aspx", Request("MethodName"), Request.Url.ToString & " ## Result=" & ret.ToString)

                Response.Write(ret)
        End Select
    End Sub
End Class
