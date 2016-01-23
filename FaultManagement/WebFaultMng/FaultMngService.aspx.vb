Imports System.Data
Imports Engine.Common
Partial Class FaultMngService
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Request("SN") Is Nothing Then
            Exit Sub
        End If

        Dim SerialNo As String = Request("SN")
        Dim rg As New LinqDB.TABLE.TbRegisterLinqDB
        rg.ChkDataBySERVERNAME(SerialNo, Nothing)

        If rg.ID > 0 Then
            Dim DeviceName As String = SerialNo
            Dim IPAddress As String = rg.SERVERIP
            Dim MacAddress As String = rg.MACADDRESS

            Dim ws As New FaultManagementService
            Select Case Request("MethodName")
                Case "SendImAlive"
                    Dim IntervalMinute As String = Request("InvervalMinute")
                    Dim StartTime As String = Request("StartTime")
                    Dim EndTime As String = Request("EndTime")
                    Dim AliveTime As DateTime

                    Dim aTime() As String = Split(Request("AliveTime"), " ")
                    If aTime.Length = 2 Then
                        AliveTime = FunctionEng.cStrToDateTime(aTime(0), aTime(1))
                    End If

                    Dim ret As Boolean = False
                    ret = ws.SendImAlive(DeviceName, IPAddress, MacAddress, IntervalMinute, StartTime, EndTime, AliveTime)
                    Response.Write(ret)
                Case "SendCPUInfo"
                    Dim CPUPercent As String = Request("CPUPercent")
                    Dim ret As Boolean = ws.SendCPUInfoToDC(DeviceName, IPAddress, CPUPercent, MacAddress)
                    Response.Write(ret)
                Case "SendRAMInfo"
                    Dim RAMPercent As String = Request("RAMPercent")
                    Dim ret As Boolean = ws.SendRAMInfoToDC(DeviceName, IPAddress, RAMPercent, MacAddress)
                    Response.Write(ret)
                Case "SendDriveInfo"
                    Dim DriveFreeSpace As String = Request("DriveFreeSpace")
                    Dim DriveTotalSize As String = Request("DriveTotalSize")
                    Dim DrivePercent As String = Request("DrivePercent")
                    Dim DrivePath As String = Request("DrivePath")

                    Dim DriveInfo As New DataTable
                    DriveInfo.Columns.Add("DriveLetter")
                    DriveInfo.Columns.Add("VolumnLabel")
                    DriveInfo.Columns.Add("FreeSpaceGB", GetType(Double))
                    DriveInfo.Columns.Add("TotalSizeGB", GetType(Double))
                    DriveInfo.Columns.Add("PercentUsage", GetType(Double))

                    Dim dr As DataRow = DriveInfo.NewRow
                    dr("DriveLetter") = DrivePath
                    dr("VolumnLabel") = ""
                    dr("FreeSpaceGB") = DriveFreeSpace
                    dr("TotalSizeGB") = DriveTotalSize
                    dr("PercentUsage") = DrivePercent
                    DriveInfo.Rows.Add(dr)

                    Dim ret As Boolean = ws.SendDriveInfoToDC(DeviceName, IPAddress, DriveInfo, MacAddress)
                    Response.Write(ret)
                Case "SendServiceInfo"
                    Dim ServiceName As String = Request("ServiceName")
                    Dim ServiceStatus As String = Request("ServiceStatus")


                    Dim ServiceDt As New DataTable
                    ServiceDt.Columns.Add("ServiceName")
                    ServiceDt.Columns.Add("ServiceType")
                    ServiceDt.Columns.Add("ServiceStatus")

                    Dim dr As DataRow = ServiceDt.NewRow
                    dr("ServiceName") = ServiceName
                    dr("ServiceType") = ""
                    dr("ServiceStatus") = ServiceStatus
                    ServiceDt.Rows.Add(dr)

                    Dim ret As Boolean = ws.SendServiceInfoToDC(DeviceName, IPAddress, ServiceDt, MacAddress)
                    Response.Write(ret)
                Case "SendProcessInfo"
                    Dim ProcessName As String = Request("PorcessName")
                    Dim ProcessStatus As String = Request("ProcessStatus")

                    Dim ProcessDt As New DataTable
                    ProcessDt.Columns.Add("WindowProcessName")
                    ProcessDt.Columns.Add("ProcessAlive")

                    Dim dr As DataRow = ProcessDt.NewRow
                    dr("WindowProcessName") = ProcessName
                    dr("ProcessAlive") = ProcessStatus
                    ProcessDt.Rows.Add(dr)

                    Dim ret As Boolean = ws.SendProcessInfoToDC(DeviceName, IPAddress, ProcessDt, MacAddress)
                    Response.Write(ret)
            End Select
            ws = Nothing
        Else
            Response.Write("false")
        End If
        rg = Nothing
    End Sub
End Class
