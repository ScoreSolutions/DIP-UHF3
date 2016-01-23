Imports Engine.Web_Config
Imports LinqDB.TABLE
Imports System.Data
Imports LinqDB.ConnectDB
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Script.Services
Imports System.Windows.Forms
Imports System.Web.UI.DataVisualization.Charting
Imports System.Drawing
Imports InfoSoftGlobal

Partial Class frmPopupServerChart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtkeepIP.Text = ""
            txtkeepIP.Text = Session("ServerIP")
            Session.Remove("ServerIP")

            SetDriveChart()
            SetServerChart()
            ShowLabel()
            SetgvProcess()
            SetgvService()
            SetgvFileSize()
            SetCPUChart()
            SetRAMChart()
            SetCPULogChart()
            SetRAMLogChart()
        End If
    End Sub

    Private Sub ShowLabel()

        Dim svIP As String = txtkeepIP.Text
        Dim sql As String = "Select id,ServerIP,ServerName,MacAddress,OS,System_Type as ProjectName "
        sql += " ,(LocationServer +'/'+LocationNo) as Locate_No ,Fname + '  ' + Lname as name ,E_mail from TB_REGISTER  where ServerIP = '" & svIP & "'"
        Dim lnq As New TbRegisterLinqDB
        Dim dt As New DataTable
        Dim tran As New TransactionDB

        'Server Label
        dt = lnq.GetListBySql(sql, tran.Trans)
        If dt.Rows.Count > 0 Then
            lblServerName.Text = dt.Rows(0).Item("servername").ToString
            lblMac.Text = dt.Rows(0).Item("MacAddress").ToString
            lblServerIP.Text = dt.Rows(0).Item("ServerIP").ToString
            lblOS.Text = dt.Rows(0).Item("OS").ToString
            lblProject.Text = dt.Rows(0).Item("ProjectName").ToString
            lblName.Text = dt.Rows(0).Item("Name").ToString
            lblEmail.Text = dt.Rows(0).Item("E_mail").ToString
            lblLocation.Text = dt.Rows(0).Item("Locate_No").ToString
        End If

        'RAM Label
        sql = "Select Convert(varchar(255),RAM.RAMPercent)+'%' as RAM, Convert(varchar(255),AlarmMinorValue)+'%' as Minor"
        sql += " ,Convert(varchar(255),AlarmMajorValue)+'%' as Major ,Convert(varchar(255),AlarmCriticalValue)+'%' as Critical "
        sql += ",Convert(varchar(255),(case when RAM.RAMPercent > AlarmMinorValue and RAM.RAMPercent < AlarmMajorValue Then RAM.RAMPercent - AlarmMinorValue end ))+'%' as OverMin"
        sql += ",Convert(varchar(255),(case when RAM.RAMPercent > AlarmMajorValue and RAM.RAMPercent < AlarmCriticalValue Then RAM.RAMPercent - AlarmMajorValue end ))+'%' as OverMajor"
        sql += ",Convert(varchar(255),(case when RAM.RAMPercent > AlarmCriticalValue then RAM.RAMPercent - AlarmCriticalValue end ))+'%' as OverCritical"
        sql += ",Convert(varchar(255),(case when RAM.RAMPercent < AlarmMinorValue then ' - ' end )) as Normal"
        sql += " from CF_CONFIG_RAM as CR join TB_REGISTER as TBR on CR.ServerName = TBR.ServerName "
        sql += " join TB_RAM_INFO as RAM on RAM.ServerName = TBR.ServerName where TBR.ServerIP = '" & svIP & "'"
        dt = lnq.GetListBySql(sql, tran.Trans)
        If dt.Rows.Count > 0 Then
            lblRAM.Text = dt.Rows(0).Item("RAM").ToString
            lblRMinor.Text = dt.Rows(0).Item("Minor").ToString
            lblRMajor.Text = dt.Rows(0).Item("Major").ToString
            lblRCritical.Text = dt.Rows(0).Item("Critical").ToString
            lblROver.Text = lblRAM.Text

        End If

        'CPU Label
        sql = "Select Convert(varchar(255),CPU.CPUPercent)+'%' as CPU,Convert(varchar(255),AlarmMinorValue)+'%' as Minor"
        sql += ",Convert(varchar(255),AlarmMajorValue)+'%' as Major ,Convert(varchar(255),AlarmCriticalValue)+'%' as Critical"
        sql += ",Convert(varchar(255),(case when CPU.CPUPercent > AlarmMinorValue and CPU.CPUPercent < AlarmMajorValue Then CPU.CPUPercent - AlarmMinorValue end ))+'%' as OverMin"
        sql += ",Convert(varchar(255),(case when CPU.CPUPercent > AlarmMajorValue and CPU.CPUPercent < AlarmCriticalValue Then CPU.CPUPercent - AlarmMajorValue end ))+'%' as OverMajor"
        sql += ",Convert(varchar(255),(case when CPU.CPUPercent > AlarmCriticalValue then CPU.CPUPercent - AlarmCriticalValue end ))+'%' as OverCritical"
        sql += ",Convert(varchar(255),(case when CPU.CPUPercent < AlarmMinorValue then ' - ' end )) as Normal"
        sql += " from CF_CONFIG_CPU as CC "
        sql += " join TB_REGISTER as TBR on CC.ServerName = TBR.ServerName "
        sql += " join TB_CPU_INFO as CPU on CPU.ServerName = TBR.ServerName where TBR.ServerIP = '" & svIP & "'"
        dt = lnq.GetListBySql(sql, tran.Trans)
        If dt.Rows.Count > 0 Then
            lblCPU.Text = dt.Rows(0).Item("CPU").ToString
            lblCMinor.Text = dt.Rows(0).Item("Minor").ToString
            lblCMajor.Text = dt.Rows(0).Item("Major").ToString
            lblCCritical.Text = dt.Rows(0).Item("Critical").ToString
            lblCOver.Text = lblCPU.Text

        End If

    End Sub

    Private Sub SetgvProcess()

        Dim dt As DataTable
        Dim Eng As New PopupChartEng
        Dim SvIP As String = txtkeepIP.Text

        dt = Eng.GetgvProcess(SvIP.ToString)

        If dt.Rows.Count > 0 Then

            gvProcess.DataSource = dt
            gvProcess.DataBind()

        Else
            gvProcess.DataSource = Nothing
        End If

    End Sub


    Private Sub SetgvService()

        Dim dt As DataTable
        Dim Eng As New PopupChartEng
        Dim SvIP As String = txtkeepIP.Text

        dt = Eng.GetgvService(SvIP.ToString)

        If dt.Rows.Count > 0 Then

            gvService.DataSource = dt
            gvService.DataBind()

        Else
            gvService.DataSource = Nothing
        End If

    End Sub


    Private Sub SetgvFileSize()

        Dim dt As DataTable
        Dim Eng As New PopupChartEng
        Dim SvIP As String = txtkeepIP.Text

        dt = Eng.GetgvFileSize(SvIP.ToString)

        If dt.Rows.Count > 0 Then

            gvFileSize.DataSource = dt
            gvFileSize.DataBind()

        Else
            gvFileSize.DataSource = Nothing
        End If

    End Sub


    Private Sub SetServerChart()

        Dim dateT As String = DateTime.Now.ToString("yyyy/MM/dd", New Globalization.CultureInfo("en-US"))
        Dim dt As DataTable
        Dim Eng As New PopupChartEng
        Dim SvIP As String = txtkeepIP.Text
        Dim lblRun As String = ""
        Dim lblStop As String = ""

        dt = Eng.GetChart(SvIP.ToString, dateT)

        If dt.Rows.Count > 0 Then

            lblRun = dt.Rows(0).Item("Work").ToString
            lblStop = dt.Rows(0).Item("Stopped").ToString

            If lblRun = "100" And lblStop <= "0" Then

                ServerChart.Series("Series1").Points.AddXY("Work", lblRun)
                ServerChart.Palette = ChartColorPalette.SeaGreen

            ElseIf lblStop = "100" And lblRun <= "0" Then

                ServerChart.Series("Series1").Points.AddXY("Stopped", lblStop)
                ServerChart.Palette = ChartColorPalette.Excel

            Else
                ServerChart.DataSource = ConvertColumnsAsRows(dt)
                ServerChart.DataBind()
            End If

        Else
            ServerChart.DataSource = Nothing
        End If


    End Sub

    Private Sub SetCPULogChart()
        CPULogChart.Series("Series1").ChartType = SeriesChartType.Line
        Dim dt As New DataTable
        Dim eng As New PopupChartEng
        dt = eng.GetCPULog(txtkeepIP.Text)
        If dt.Rows.Count > 0 Then
            CPULogChart.Series("Series1").XValueMember = "SendTime"
            CPULogChart.Series("Series1").YValueMembers = "CPUPercent"

            CPULogChart.DataSource = dt
            CPULogChart.DataBind()
        End If
    End Sub

    Private Sub SetRAMLogChart()
        RAMLogChart.Series("Series1").ChartType = SeriesChartType.Line
        Dim dt As New DataTable
        Dim eng As New PopupChartEng
        dt = eng.GetRAMLog(txtkeepIP.Text)
        If dt.Rows.Count > 0 Then
            RAMLogChart.Series("Series1").XValueMember = "SendTime"
            RAMLogChart.Series("Series1").YValueMembers = "RAMPercent"

            RAMLogChart.DataSource = dt
            RAMLogChart.DataBind()
        End If
    End Sub

    Private Sub SetCPUChart()

        Dim dt As DataTable
        Dim Eng As New PopupChartEng
        Dim SvIP As String = txtkeepIP.Text
        Dim lblUse As String = ""
        Dim lblFree As String = ""

        dt = Eng.GetCPUChart(SvIP.ToString)

        If dt.Rows.Count > 0 Then

            lblUse = dt.Rows(0).Item("Used").ToString
            lblFree = dt.Rows(0).Item("Free").ToString

            If lblFree = "100" And lblUse <= "0" Then

                CPUChart.Series("Series1").Points.AddXY("Free", lblFree)
                CPUChart.Palette = ChartColorPalette.SeaGreen

            ElseIf lblUse = "100" And lblFree <= "0" Then

                CPUChart.Series("Series1").Points.AddXY("Used", lblUse)
                CPUChart.Palette = ChartColorPalette.Excel

            Else
                CPUChart.DataSource = ConvertColumnsAsRows(dt)
                CPUChart.DataBind()
            End If

        Else
            CPUChart.DataSource = Nothing

            Response.Write("<script language=""javaScript"">alert(""Please,Install Fault Management before !"");</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "window.close();", True)

        End If

    End Sub

    Private Sub SetRAMChart()

        Dim dt As DataTable
        Dim Eng As New PopupChartEng
        Dim SvIP As String = txtkeepIP.Text
        Dim lblUse As String = ""
        Dim lblFree As String = ""

        dt = Eng.GetRAMChart(SvIP.ToString)

        If dt.Rows.Count > 0 Then

            lblUse = dt.Rows(0).Item("Used").ToString
            lblFree = dt.Rows(0).Item("Free").ToString

            If lblUse = "0" Then

                RAMChart.Series("Series1").Points.AddXY("Free", lblFree)
                RAMChart.Palette = ChartColorPalette.SeaGreen

            ElseIf lblUse = "100" Then

                RAMChart.Series("Series1").Points.AddXY("Used", lblUse)
                RAMChart.Palette = ChartColorPalette.Excel

            Else
                RAMChart.DataSource = ConvertColumnsAsRows(dt)
                RAMChart.DataBind()
            End If


        Else
            RAMChart.DataSource = Nothing
        End If

    End Sub

    Public Sub SetDriveChart()

        Dim dt As New DataTable
        Dim tran As New TransactionDB
        Dim sql As String
        Dim lnq As New TbDriveInfoLinqDB
        Dim svIP As String = txtkeepIP.Text
        sql = "Select Distinct DriveLetter, PercentUsage from TB_DRIVE_INFO where ServerIP = '" & svIP & "' "
        dt = lnq.GetListBySql(sql, tran.Trans)
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows.Count - 1 >= i Then
                Label1.Text = dt.Rows(i).Item("DriveLetter").ToString
                Label2.Text = dt.Rows(i).Item("PercentUsage").ToString
            End If

            DriveChart.Series("Series1").Points.AddXY(Label1.Text, Label2.Text)


        Next


        Dim Eng As New PopupChartEng

        dt = Eng.GetgvDriveChart(svIP.ToString)
        gvDriveSeverity.DataSource = dt
        gvDriveSeverity.DataBind()

    End Sub

    Public Function ConvertColumnsAsRows(ByVal dt As DataTable) As DataTable
        Dim dtnew As New DataTable()
        'Convert all the rows to columns
        For i As Integer = 0 To dt.Rows.Count
            dtnew.Columns.Add(Convert.ToString(i))
        Next
        Dim dr As DataRow
        ' Convert All the Columns to Rows
        For j As Integer = 0 To dt.Columns.Count - 1
            dr = dtnew.NewRow()
            dr(0) = dt.Columns(j).ToString()
            For k As Integer = 1 To dt.Rows.Count
                dr(k) = dt.Rows(k - 1)(j)
            Next
            dtnew.Rows.Add(dr)
        Next
        Return dtnew
    End Function

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ShowLabel()
        SetgvProcess()
        SetgvService()
        SetgvFileSize()
        SetServerChart()
        SetCPUChart()
        SetRAMChart()
        SetDriveChart()
        SetCPULogChart()
        SetRAMLogChart()
    End Sub
End Class
