Imports System.Data
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.IO

Namespace Web_Config
    Public Class PopupChartEng

        Public Function GetgvProcess(ByRef wh As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New TbProcessInfoLinqDB
            
            Dim sql As String
            sql = "Select MP.WindowProcessName,P.ProcessAlive  "
            sql += " from CF_CONFIG_PROCESS CP "
            sql += " inner join CF_CONFIG_PROCESS_DETAIL cpd on cp.id=cpd.cf_config_process_id"
            sql += " inner join MS_MASTER_PROCESS_CHECKLIST MP on CPd.ms_master_process_checklist_id = MP.id"
            sql += " inner join TB_PROCESS_INFO P on P.ServerIP = CP.ServerIP and P.WindowProcessName = MP.WindowProcessName"
            sql += " where CP.ServerIP = '" & wh & "' "
            sql += " Order by MP.WindowProcessName "
            dt = lnq.GetListBySql(sql, Nothing)

            Return dt
        End Function

        Public Function GetgvService(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim lnq As New TbServiceInfoLinqDB

            Dim sql As String
            sql = "Select MS.WindowServiceName , S.ServiceStatus "
            sql += " from CF_CONFIG_SERVICE CS "
            sql += " inner join CF_CONFIG_SERVICE_DETAIL csd on cs.id=csd.cf_config_service_id"
            sql += " inner join MS_MASTER_SERVICE_CHECKLIST MS on CSd.ms_master_service_checklist_id = MS.id "
            sql += " inner join TB_SERVICE_INFO S on S.ServerIP = CS.ServerIP and S.ServiceName = MS.WindowServiceName"
            sql += " where CS.ServerIP = '" & wh & "' "
            sql += " Order by MS.WindowServiceName  "
            dt = lnq.GetListBySql(sql, Nothing)
            Return dt
        End Function

        Public Function GetgvFileSize(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim lnq As New TbProcessInfoLinqDB

            Dim sql As String
            sql = "Select FD.FileName,Convert(varchar(255),FD.FileSizeMinor)+' GB, " & vbNewLine
            sql += " '+Convert(varchar(255),FD.FileSizeMajor)+' GB, '+Convert(varchar(255),FD.FileSizeCritical)+' GB' as Config ," & vbNewLine
            sql += " Convert(varchar(255),TF.FileSizeGB)+' GB' as Used " & vbNewLine
            sql += " from CF_CONFIG_FILESIZE CF " & vbNewLine
            sql += " inner join CF_CONFIG_FILESIZE_DETAIL FD on CF.id = FD.cf_config_filesize_id " & vbNewLine
            sql += " inner join TB_FILESIZE_INFO TF on TF.ServerIP = CF.ServerIP and TF.FileName = FD.FileName " & vbNewLine
            sql += " where CF.ServerIP = '" & wh & "' " & vbNewLine
            sql += " Order by FD.FileName ASC" & vbNewLine
            dt = lnq.GetListBySql(sql, Nothing)

            Return dt
        End Function

        Public Function GetChart(ByRef IP As String, ByRef DateT As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            Dim sql As String
            sql = (" Select (((all_S-all_N)*100)/all_S) as Work, 100-(((all_S-all_N)*100)/all_S) as Stopped ")
            sql += (" from ")
            sql += (" (Select COUNT(Status) as All_S ")
            sql += (" from TB_PING_LOG P join TB_REGISTER R on P.ServerIP  = R.ServerIP")
            sql += (" where Convert(Varchar(10), P.CreatedDate,111)= '" & DateT & "' and P.ServerIP = '" & IP & "') as A1")
            sql += (" ,(Select COUNT(Status) as All_N")
            sql += (" from TB_PING_LOG P join TB_REGISTER R on P.ServerIP = R.ServerIP")
            sql += (" where P.Status = 'N' and Convert(Varchar(10), P.CreatedDate,111) = '" & DateT & "' and P.ServerIP ='" & IP & "') as A2")
            sql += (" , TB_REGISTER R where R.ServerIP = '" & IP & "' ")
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetRAMChart(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            Dim sql As String
            sql = ("Select  RAM.RAMPercent as Used , ROUND(100 - RAM.RAMPercent,2) as Free ")
            sql += (" from TB_REGISTER as TBR join TB_RAM_INFO as RAM on RAM.ServerName = TBR.ServerName and RAM.ServerIP = TBR.ServerIP  where TBR.ServerIP = '" & wh & "' ")
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetCPUChart(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            Dim sql As String
            sql = ("Select case when CPU.CPUPercent = 0 then '' else case when CPU.CPUPercent <> 0 then CPU.CPUPercent end end as Used, ROUND(100 - CPU.CPUPercent,2) as Free ")
            sql += ("from TB_REGISTER as TBR join TB_CPU_INFO as CPU on CPU.ServerName = TBR.ServerName and CPU.ServerIP = TBR.ServerIP  where TBR.ServerIP = '" & wh & "' ")
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetgvDriveChart(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            Dim sql As String = ""

            sql += " select T2.ServerIP,T2.DriveLetter,str(T2.PercentUsage) + '%' as PercentUse,"
            sql += " isnull((str(T1.AlarmMinorValue)  + '%,' + str(T1.AlarmMajorValue) + '%,' + str(T1.AlarmCriticalValue) + '%' ),'') as Config from ("
            sql += " select cf_config_drive.id,serverip,DriveLetter,AlarmMinorValue,AlarmMajorValue,AlarmCriticalValue "
            sql += " from cf_config_drive left join cf_config_drive_detail on cf_config_drive.id = cf_config_drive_detail.cf_config_drive_id"
            sql += " where  ServerIP='" & wh & "') T1"
            sql += " Left Join"
            sql += " (select ServerIP,DriveLetter,PercentUsage from TB_DRIVE_INFO where ServerIP='" & wh & "') T2 "
            sql += " on T1.ServerIP = T2.ServerIP and T1.DriveLetter = T2.DriveLetter"

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetCPULog(ServerIP As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim sql As String = "select id,Convert(varchar(5),SendTime,108) SendTime,CPUPercent from TB_CPU_LOG "
            sql += " where serverip ='" & ServerIP & "' "
            sql += " and SendTime between DATEADD(HH,-1,getdate()) and getdate()"
            dt = SqlDB.ExecuteTable(sql, trans.Trans)

            Return dt
        End Function

        Public Function GetRAMLog(ServerIP As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim sql As String = "select Convert(varchar(5),SendTime,108) SendTime,RAMPercent from TB_RAM_LOG "
            sql += " where serverip ='" & ServerIP & "' "
            sql += " and SendTime between DATEADD(HH,-1,getdate()) and getdate()"
            dt = SqlDB.ExecuteTable(sql, trans.Trans)

            Return dt
        End Function

    End Class

End Namespace
