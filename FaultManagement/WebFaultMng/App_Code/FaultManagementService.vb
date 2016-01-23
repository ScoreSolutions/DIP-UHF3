Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO
Imports Engine.Common
Imports System.Data
Imports LinqDB.ConnectDB

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Public Class FaultManagementService
    Inherits System.Web.Services.WebService

    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '    Return "Hello World"
    'End Function


    <WebMethod()> _
    Public Function GetAlarmByServerName(ByVal ServerName As String) As DataTable
        Dim sql As String = "select * from TB_ALARM_WAITING_CLEAR where ServerName='" & ServerName & "' and FlagAlarm = 'Alarm' order by UpdateDate desc"
        Dim dt As New DataTable
        dt = SqlDB.ExecuteTable(sql)
        dt.TableName = "GetAlarmByServerName"
        Return dt
    End Function

    <WebMethod()> _
    Public Function SendImAlive(ByVal ServerName As String, ByVal ServerIP As String, ByVal MacAddress As String, ByVal cfgIntervalMinute As Integer, ByVal cfgStartTime As String, ByVal cfgEndTime As String, ByVal AliveTime As DateTime) As Boolean
        Dim ret As Boolean = False

        Dim NextAliveTime As DateTime = DateAdd(DateInterval.Minute, cfgIntervalMinute + 3, AliveTime)
        Dim EndTime As New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Split(cfgEndTime, ":")(0), Split(cfgEndTime, ":")(1), 0)

        Dim aLnq As New LinqDB.TABLE.TbIamAliveLinqDB
        aLnq.ChkDataByMACADDRESS(MacAddress, Nothing)

        aLnq.SERVERNAME = ServerName
        aLnq.MACADDRESS = MacAddress
        aLnq.HOSTIP = ServerIP
        aLnq.CFG_MONITOR_TIME_START = cfgStartTime
        aLnq.CFG_MONITOR_TIME_END = cfgEndTime
        aLnq.CFG_INTERVAL = cfgIntervalMinute
        aLnq.ALIVE_TIME = AliveTime
        aLnq.NEXT_ALIVE_TIME = NextAliveTime

        Dim trans As New TransactionDB
        If aLnq.ID > 0 Then
            ret = aLnq.UpdateByPK(ServerName, trans.Trans)
        Else
            ret = aLnq.InsertData(ServerName, trans.Trans)
        End If
        aLnq = Nothing

        If ret = True Then
            trans.CommitTransaction()
        Else
            trans.RollbackTransaction()
        End If
        Return ret
    End Function


    <WebMethod()> _
    Public Function SendCPUInfoToDC(ServerName As String, ServerIP As String, CPUPercentage As Double, ByVal MacAddress As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New LinqDB.TABLE.TbCpuInfoLinqDB
            lnq.ChkDataByMACADDRESS(MacAddress, Nothing)

            If lnq.ID = 0 Then
                lnq.ChkDataBySERVERNAME(ServerName, Nothing)
            End If

            lnq.SENDTIME = DateTime.Now
            lnq.CPUPERCENT = CPUPercentage
            lnq.SERVERIP = ServerIP
            lnq.SERVERNAME = ServerName
            lnq.MACADDRESS = MacAddress

            Dim trans As New TransactionDB
            If lnq.ID > 0 Then
                ret = lnq.UpdateByPK("SendCPUInfoToDC", trans.Trans)
            Else
                
                ret = lnq.InsertData("SendCPUInfoToDC", trans.Trans)
            End If

            If ret = True Then
                trans.CommitTransaction()
                SendCPULog(ServerName, ServerIP, CPUPercentage, MacAddress)
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Catch ex As Exception

        End Try
        Return ret
    End Function
    Private Sub SendCPULog(ServerName As String, ServerIP As String, CPUPercentage As Double, ByVal MacAddress As String)
        Dim ret As Boolean = False
        Try
            Dim lnq As New LinqDB.TABLE.TbCpuLogLinqDB
            Dim trans As New TransactionDB

            lnq.SENDTIME = DateTime.Now
            lnq.CPUPERCENT = CPUPercentage
            lnq.SERVERIP = ServerIP
            lnq.SERVERNAME = ServerName
            lnq.MACADDRESS = MacAddress

            ret = lnq.InsertData("SendCPULog", trans.Trans)

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Catch ex As Exception

        End Try
    End Sub


    <WebMethod()> _
    Public Function SendRAMInfoToDC(ServerName As String, ServerIP As String, RAMPercentage As Double, ByVal MacAddress As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New LinqDB.TABLE.TbRamInfoLinqDB
            lnq.ChkDataByMACADDRESS(MacAddress, Nothing)
            If lnq.ID = 0 Then
                lnq.ChkDataBySERVERNAME(ServerName, Nothing)
            End If
            lnq.SENDTIME = DateTime.Now
            lnq.RAMPERCENT = RAMPercentage
            lnq.SERVERIP = ServerIP
            lnq.SERVERNAME = ServerName
            lnq.MACADDRESS = MacAddress

            Dim trans As New TransactionDB
            If lnq.ID > 0 Then
                ret = lnq.UpdateByPK("SendRAMInfoToDC", trans.Trans)
            Else
                
                ret = lnq.InsertData("SendRAMInfoToDC", trans.Trans)
            End If
            If ret = True Then
                trans.CommitTransaction()
                SendRAMLog(ServerName, ServerIP, RAMPercentage, MacAddress)
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Catch ex As Exception

        End Try
        Return ret
    End Function
    Public Sub SendRAMLog(ServerName As String, ServerIP As String, RAMPercentage As Double, ByVal MacAddress As String)
        Dim ret As Boolean = False
        Try
            Dim lnq As New LinqDB.TABLE.TbRamLogLinqDB
            Dim trans As New TransactionDB
            lnq.SENDTIME = DateTime.Now
            lnq.RAMPERCENT = RAMPercentage
            lnq.SERVERIP = ServerIP
            lnq.SERVERNAME = ServerName
            lnq.MACADDRESS = MacAddress

            ret = lnq.InsertData("SendRAMLog", trans.Trans)

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If

            lnq = Nothing
        Catch ex As Exception

        End Try
    End Sub


    <WebMethod()> _
    Public Function SendDriveInfoToDC(ServerName As String, ServerIP As String, DriveInfo As DataTable, ByVal MacAddress As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            If DriveInfo.Rows.Count > 0 Then
                For Each dr As DataRow In DriveInfo.Rows
                    Dim lnq As New LinqDB.TABLE.TbDriveInfoLinqDB
                    lnq.ChkDataByDRIVELETTER_MACADDRESS(dr("DriveLetter"), MacAddress, trans.Trans)
                    If lnq.ID = 0 Then
                        lnq.ChkDataByDRIVELETTER_SERVERNAME(dr("DriveLetter"), ServerName, trans.Trans)
                    End If
                    lnq.SENDTIME = DateTime.Now
                    lnq.VOLUMNLABEL = dr("VolumnLabel")
                    lnq.FREESPACEGB = Convert.ToDouble(dr("FreeSpaceGB"))
                    lnq.TOTALSIZEGB = Convert.ToDouble(dr("TotalSizeGB"))
                    lnq.PERCENTUSAGE = Convert.ToDouble(dr("PercentUsage"))
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress
                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK("SendDriveInfoToDC", trans.Trans)
                    Else
                        
                        lnq.DRIVELETTER = dr("DriveLetter")
                        ret = lnq.InsertData("SendDriveInfoToDC", trans.Trans)
                    End If

                    If ret = False Then
                        Exit For
                    End If

                    lnq = Nothing
                Next
            End If
            If ret = True Then
                trans.CommitTransaction()
                SendDriveLog(ServerName, ServerIP, DriveInfo, MacAddress)
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception

        End Try
        Return ret
    End Function
    Public Sub SendDriveLog(ServerName As String, ServerIP As String, DriveInfo As DataTable, ByVal MacAddress As String)
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            If DriveInfo.Rows.Count > 0 Then
                For Each dr As DataRow In DriveInfo.Rows
                    Dim lnq As New LinqDB.TABLE.TbDriveLogLinqDB

                    lnq.SENDTIME = DateTime.Now
                    lnq.VOLUMNLABEL = dr("VolumnLabel")
                    lnq.FREESPACEGB = Convert.ToDouble(dr("FreeSpaceGB"))
                    lnq.TOTALSIZEGB = Convert.ToDouble(dr("TotalSizeGB"))
                    lnq.PERCENTUSAGE = Convert.ToDouble(dr("PercentUsage"))
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress
                    lnq.DRIVELETTER = dr("DriveLetter")
                    ret = lnq.InsertData("SendDriveLog", trans.Trans)

                    If ret = False Then
                        Exit For
                    End If

                    lnq = Nothing
                Next
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception

        End Try
    End Sub


    <WebMethod()> _
    Public Function SendServiceInfoToDC(ServerName As String, ServerIP As String, ServiceDT As DataTable, ByVal MacAddress As String) As Boolean
        Dim ret As Boolean = False
        Try
            If ServiceDT.Rows.Count > 0 Then
                For Each dr As DataRow In ServiceDT.Rows
                    Dim trans As New TransactionDB
                    Dim lnq As New LinqDB.TABLE.TbServiceInfoLinqDB

                    lnq.ChkDataByMACADDRESS_SERVICENAME(MacAddress, dr("ServiceName"), Nothing)

                    If lnq.ID = 0 Then
                        lnq.ChkDataBySERVERNAME_SERVICENAME(ServerName, dr("ServiceName"), Nothing)
                    End If

                    lnq.SENDTIME = DateTime.Now
                    lnq.SERVICETYPE = dr("ServiceType")
                    lnq.SERVICESTATUS = dr("ServiceStatus")
                    lnq.SERVICENAME = dr("ServiceName")
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress
                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK("SendServiceInfoToDC", trans.Trans)
                    Else
                        ret = lnq.InsertData("SendServiceInfoToDC", trans.Trans)
                    End If

                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                    lnq = Nothing
                Next

                SendServiceLog(ServerName, ServerIP, ServiceDT, MacAddress)
            End If
        Catch ex As Exception

        End Try
        Return ret
    End Function
    Public Sub SendServiceLog(ServerName As String, ServerIP As String, ServiceDT As DataTable, ByVal MacAddress As String)
        Dim ret As Boolean = False

        Try
            If ServiceDT.Rows.Count > 0 Then
                For Each dr As DataRow In ServiceDT.Rows
                    Dim trans As New TransactionDB
                    Dim lnq As New LinqDB.TABLE.TbServiceLogLinqDB

                    lnq.SENDTIME = DateTime.Now
                    lnq.SERVICETYPE = dr("ServiceType")
                    lnq.SERVICESTATUS = dr("ServiceStatus")
                    lnq.SERVICENAME = dr("ServiceName")
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress
                    ret = lnq.InsertData("SendServiceLog", trans.Trans)

                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                    lnq = Nothing
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub



    <WebMethod()> _
    Public Function SendProcessInfoToDC(ServerName As String, ServerIP As String, ProcessDT As DataTable, ByVal MacAddress As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            If ProcessDT.Rows.Count > 0 Then
                For Each dr As DataRow In ProcessDT.Rows
                    Dim lnq As New LinqDB.TABLE.TbProcessInfoLinqDB
                    lnq.ChkDataByMACADDRESS_WINDOWPROCESSNAME(MacAddress, dr("WindowProcessName"), Nothing)
                    If lnq.ID = 0 Then
                        lnq.ChkDataBySERVERNAME_WINDOWPROCESSNAME(ServerName, dr("WindowProcessName"), Nothing)
                    End If
                    lnq.SENDTIME = DateTime.Now
                    lnq.WINDOWPROCESSNAME = dr("WindowProcessName")
                    lnq.PROCESSALIVE = dr("ProcessAlive")
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress
                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK("SendProcessInfoToDC", trans.Trans)
                    Else
                        ret = lnq.InsertData("SendProcessInfoToDC", trans.Trans)
                    End If
                    If ret = False Then
                        Exit For
                    End If

                    lnq = Nothing
                Next
            End If

            If ret = True Then
                trans.CommitTransaction()
                SendProcessLog(ServerName, ServerIP, ProcessDT, MacAddress)
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception

        End Try
        Return ret
    End Function
    Private Sub SendProcessLog(ServerName As String, ServerIP As String, ProcessDT As DataTable, ByVal MacAddress As String)
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            If ProcessDT.Rows.Count > 0 Then
                For Each dr As DataRow In ProcessDT.Rows
                    Dim lnq As New LinqDB.TABLE.TbProcessLogLinqDB

                    lnq.SENDTIME = DateTime.Now
                    lnq.WINDOWPROCESSNAME = dr("WindowProcessName")
                    lnq.PROCESSALIVE = dr("ProcessAlive")
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress

                    ret = lnq.InsertData("SendProcessLog", trans.Trans)

                    If ret = False Then
                        Exit For
                    End If

                    lnq = Nothing
                Next
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception

        End Try
    End Sub



    <WebMethod()> _
    Public Function SendFileSizeInfoToDC(ServerName As String, ServerIP As String, FileSizeDT As DataTable, ByVal MacAddress As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            If FileSizeDT.Rows.Count > 0 Then
                For Each dr As DataRow In FileSizeDT.Rows
                    Dim lnq As New LinqDB.TABLE.TbFilesizeInfoLinqDB
                    lnq.ChkDataByFILENAME_MACADDRESS(dr("FileName"), MacAddress, trans.Trans)
                    If lnq.ID = 0 Then
                        lnq.ChkDataByFILENAME_SERVERNAME(dr("FileName"), ServerName, trans.Trans)
                    End If
                    lnq.SENDTIME = DateTime.Now

                    lnq.FILENAME = dr("FileName")
                    lnq.FILESIZEGB = Convert.ToDouble(dr("FileSizeGB"))
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress
                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK("SendFileSizeInfoToDC", trans.Trans)
                    Else
                        ret = lnq.InsertData("SendFileSizeInfoToDC", trans.Trans)
                    End If
                    If ret = False Then
                        Exit For
                    End If

                    lnq = Nothing
                Next
            End If

            If ret = True Then
                trans.CommitTransaction()
                SendFileSizeLog(ServerName, ServerIP, FileSizeDT, MacAddress)
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception

        End Try
        Return ret
    End Function
    Private Sub SendFileSizeLog(ServerName As String, ServerIP As String, FileSizeDT As DataTable, ByVal MacAddress As String)
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            If FileSizeDT.Rows.Count > 0 Then
                For Each dr As DataRow In FileSizeDT.Rows
                    Dim lnq As New LinqDB.TABLE.TbFilesizeLogLinqDB

                    lnq.SENDTIME = DateTime.Now
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress
                    lnq.FILENAME = dr("FileName")
                    lnq.FILESIZEGB = Convert.ToDouble(dr("FileSizeGB"))

                    ret = lnq.InsertData("SendFileSizeLog", trans.Trans)

                    If ret = False Then
                        Exit For
                    End If

                    lnq = Nothing
                Next
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception

        End Try
    End Sub



    <WebMethod()> _
    Public Function SendFileLostInfoToDC(ServerName As String, ServerIP As String, FileLostDT As DataTable, ByVal MacAddress As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            If FileLostDT.Rows.Count > 0 Then
                For Each dr As DataRow In FileLostDT.Rows
                    Dim lnq As New LinqDB.TABLE.TbFilelostInfoLinqDB
                    lnq.ChkDataByFILENAME_MACADDRESS(dr("FileName"), MacAddress, trans.Trans)
                    If lnq.ID = 0 Then
                        lnq.ChkDataByFILENAME_SERVERNAME(dr("FileName"), ServerName, trans.Trans)
                    End If
                    lnq.SENDTIME = DateTime.Now

                    lnq.FILENAME = dr("FileName")
                    lnq.FILELOSTSTATUS = dr("FileLostStatus")
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress
                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK("SendFileLostInfoToDC", trans.Trans)
                    Else
                        ret = lnq.InsertData("SendFileLostInfoToDC", trans.Trans)
                    End If
                    If ret = False Then
                        Exit For
                    End If

                    lnq = Nothing
                Next
            End If

            If ret = True Then
                trans.CommitTransaction()
                SendFileLostLog(ServerName, ServerIP, FileLostDT, MacAddress)
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception

        End Try
        Return ret
    End Function

    Private Sub SendFileLostLog(ServerName As String, ServerIP As String, FileLostDT As DataTable, ByVal MacAddress As String)
        Dim ret As Boolean = False
        Try
            Dim trans As New TransactionDB
            If FileLostDT.Rows.Count > 0 Then
                For Each dr As DataRow In FileLostDT.Rows
                    Dim lnq As New LinqDB.TABLE.TbFilelostLogLinqDB

                    lnq.SENDTIME = DateTime.Now
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress
                    lnq.FILENAME = dr("FileName")
                    lnq.FILELOSTSTATUS = dr("FileLostStatus")

                    ret = lnq.InsertData("SendFileLostLog", trans.Trans)

                    If ret = False Then
                        Exit For
                    End If

                    lnq = Nothing
                Next
            End If

            If ret = True Then
                trans.CommitTransaction()
            Else
                trans.RollbackTransaction()
            End If
        Catch ex As Exception

        End Try
    End Sub




    <WebMethod()> _
    Public Function SendWebAppInfoToDC(ServerName As String, ServerIP As String, WebAppDT As DataTable, MacAddress As String) As Boolean
        Dim ret As Boolean = False
        Try

            If WebAppDT.Rows.Count > 0 Then
                For Each dr As DataRow In WebAppDT.Rows
                    Dim trans As New TransactionDB
                    Dim lnq As New LinqDB.TABLE.TbWebAppInfoLinqDB
                    lnq.ChkDataByMACADDRESS_WEBAPPLICATIONNAME(MacAddress, dr("WebApplicationName"), Nothing)
                    If lnq.ID = 0 Then
                        lnq.ChkDataBySERVERNAME_WEBAPPLICATIONNAME(ServerName, dr("WebApplicationName"), Nothing)
                    End If
                    lnq.SENDTIME = DateTime.Now
                    lnq.WEBAPPLICATIONNAME = dr("WebApplicationName")
                    lnq.APPLICATIONSTATUS = dr("ApplicationStatus")
                    lnq.SERVERIP = ServerIP
                    lnq.SERVERNAME = ServerName
                    lnq.MACADDRESS = MacAddress

                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK("SendWebAppInfoToDC", trans.Trans)
                    Else
                        ret = lnq.InsertData("SendWebAppInfoToDC", trans.Trans)
                    End If
                    lnq = Nothing

                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetWindowsServiceCheckList(MacAddress As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim lnq As New LinqDB.TABLE.CfConfigServiceLinqDB
            Dim sql As String = "select ms.WindowServiceName, cf.ActiveStatus "
            sql += " from CF_CONFIG_SERVICE cf"
            sql += " inner join CF_CONFIG_SERVICE_DETAIL cfd on cf.id=cfd.cf_config_service_id"
            sql += " inner join MS_MASTER_SERVICE_CHECKLIST ms on ms.id=cfd.ms_master_service_checklist_id"
            sql += " where ms.ActiveStatus='Y' and cf.ActiveStatus='Y'"
            sql += " and cf.MacAddress='" & MacAddress & "'"
            sql += " order by ms.WindowServiceName"
            ret = lnq.GetListBySql(sql, Nothing) 'lnq.GetDataList("ActiveStatus='Y'", "WindowServiceName", Nothing)
            lnq = Nothing
        Catch ex As Exception

        End Try

        ret.TableName = "GetWindowsServiceCheckList"
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetWindowsProcessCheckList(MacAddress As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select ms.WindowProcessName "
            sql += " from MS_MASTER_PROCESS_CHECKLIST ms "
            sql += " inner join CF_CONFIG_PROCESS_DETAIL pd on pd.ms_master_process_checklist_id=ms.id "
            sql += " inner join CF_CONFIG_PROCESS p on pd.cf_config_process_id=p.id "
            sql += " where p.ActiveStatus='Y' and ms.ActiveStatus='Y'"
            sql += " and p.MacAddress='" & MacAddress & "'"
            sql += " order by ms.WindowProcessName"

            Dim lnq As New LinqDB.TABLE.CfConfigProcessLinqDB
            ret = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing
        Catch ex As Exception

        End Try

        ret.TableName = "GetWindowsProcessCheckList"
        Return ret
    End Function

    '<WebMethod()> _
    'Public Function GetConfigFileSizeCheckList(ServerName As String) As DataTable
    '    Dim ret As New DataTable
    '    Try
    '        Dim lnq As New LinqDB.TABLE.CfConfigFilesizeDetailLinqDB
    '        Dim sql As String = "select fd.FileName, fd.FileSizeMinor, fd.FileSizeMajor, fd.FileSizeCritical"
    '        sql += " from CF_CONFIG_FILESIZE_DETAIL fd"
    '        sql += " inner join CF_CONFIG_FILESIZE f on f.id=fd.cf_config_filesize_id"
    '        sql += " where f.ServerName = '" & ServerName & "' and f.ActiveStatus='Y'"
    '        sql += " order by fd.FileName"
    '        ret = lnq.GetListBySql(sql, Nothing)
    '    Catch ex As Exception

    '    End Try
    '    ret.TableName = "GetConfigFileSizeCheckList"
    '    Return ret
    'End Function


    <WebMethod()> _
    Public Function GetConfigFileSizeList(MacAddress As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select fd.FileName, fd.FileSizeMinor, fd.FileSizeMajor, fd.FileSizeCritical, f.AlarmTimeFrom, f.AlarmTimeTo, f.AllDayEvent"
            sql += " from CF_CONFIG_FILESIZE_DETAIL fd"
            sql += " inner join CF_CONFIG_FILESIZE f on f.id=fd.cf_config_filesize_id"
            sql += " where  f.MacAddress='" & MacAddress & "'"

            Dim CaseDay As Integer = DatePart(DateInterval.Weekday, DateTime.Now)
            Select Case CaseDay
                Case 1
                    sql += " and f.AlarmSun ='Y'"
                Case 2
                    sql += " and f.AlarmMon ='Y'"
                Case 3
                    sql += " and f.AlarmTue ='Y'"
                Case 4
                    sql += " and f.AlarmWed ='Y'"
                Case 5
                    sql += " and f.AlarmThu ='Y'"
                Case 6
                    sql += " and f.AlarmFri ='Y'"
                Case 7
                    sql += " and AlarmSat ='Y'"
            End Select
            sql += " and f.ActiveStatus='Y'"
            sql += " order by fd.FileName"

            Dim lnq As New LinqDB.TABLE.CfConfigFilesizeLinqDB
            ret = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing
        Catch ex As Exception

        End Try
        ret.TableName = "GetConfigFileSizeList"
        Return ret
    End Function

    <WebMethod()> _
    Public Function GetConfigFileLostList(MacAddress As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim sql As String = "select fd.FileName "
            sql += " from CF_CONFIG_FILELOST_DETAIL fd"
            sql += " inner join CF_CONFIG_FILELOST f on f.id=fd.cf_config_filelost_id"
            sql += " where  f.MacAddress='" & MacAddress & "'"

            Dim CaseDay As Integer = DatePart(DateInterval.Weekday, DateTime.Now)
            Select Case CaseDay
                Case 1
                    sql += " and f.AlarmSun ='Y'"
                Case 2
                    sql += " and f.AlarmMon ='Y'"
                Case 3
                    sql += " and f.AlarmTue ='Y'"
                Case 4
                    sql += " and f.AlarmWed ='Y'"
                Case 5
                    sql += " and f.AlarmThu ='Y'"
                Case 6
                    sql += " and f.AlarmFri ='Y'"
                Case 7
                    sql += " and AlarmSat ='Y'"
            End Select
            sql += " and f.ActiveStatus='Y'"
            sql += " order by fd.FileName"

            Dim lnq As New LinqDB.TABLE.CfConfigFilelostLinqDB
            ret = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing
        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetConfigFileSizeList"
        Return ret
    End Function



    <WebMethod()> _
    Public Function GetTEMP_FILE(serverip As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim lnq As New LinqDB.TABLE.TbTempFileLinqDB
            Dim sql As String = "select id,ServerIP,PathFile,FileSizeGB,Status from TB_TEMP_FILE where ServerIP='" & serverip & "'"
            ret = lnq.GetListBySql(sql, Nothing)
        Catch ex As Exception

        End Try

        ret.TableName = "PathFile"

        Return ret
    End Function

    <WebMethod()> _
    Public Function GetLoadTempPath(ServerIP As String) As DataTable
        Dim ret As New DataTable
        Try
            Dim lnq As New LinqDB.TABLE.TbLoadTempPathLinqDB
            ret = lnq.GetDataList("serverip='" & ServerIP & "' and status='N'", "createddate", Nothing)
            lnq = Nothing
        Catch ex As Exception
            ret = New DataTable
        End Try
        ret.TableName = "GetLoadTempPath"
        Return ret
    End Function


    <WebMethod()> _
    Public Function SendTempFile(_dt As DataTable, LoadTempPathID As String) As Boolean
        Dim ret As Boolean = False
        If _dt.Rows.Count > 0 Then
            Try
                For i As Integer = 0 To _dt.Rows.Count - 1
                    Dim trans As New TransactionDB
                    Dim lnq As New LinqDB.TABLE.TbTempFileLinqDB
                    lnq.TB_LOAD_TEMP_PATH_ID = _dt.Rows(i)("LoadTempPathID")
                    lnq.SERVERIP = _dt.Rows(i)("ServerIP").ToString
                    lnq.PATHFILE = _dt.Rows(i)("PathFile").ToString
                    lnq.DISPLAYTYPE = Convert.ToChar(_dt.Rows(i)("DisplayType"))
                    If Convert.IsDBNull(_dt.Rows(i)("FileSizeGB")) = False Then lnq.FILESIZEGB = _dt.Rows(i)("FileSizeGB")

                    ret = lnq.InsertData("SendTempFile", trans.Trans)
                    If ret = True Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                    lnq = Nothing
                Next

                If ret = True Then
                    UpdateLoadTempPathStatus(LoadTempPathID)
                End If
            Catch ex As Exception
                ret = False
            End Try
        End If
        Return ret
    End Function

    Private Function UpdateLoadTempPathStatus(LoadTempPathID As String) As Boolean
        Dim ret As Boolean = False
        Try
            Dim lnq As New LinqDB.TABLE.TbLoadTempPathLinqDB
            lnq.GetDataByPK(LoadTempPathID, Nothing)
            lnq.STATUS = "Y"

            If lnq.ID > 0 Then
                Dim trans As New TransactionDB
                If lnq.UpdateByPK("FaultManagementService.UpdateLoadTempPathStatus", trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            End If
            lnq = Nothing
        Catch ex As Exception

        End Try
        Return ret
    End Function
End Class