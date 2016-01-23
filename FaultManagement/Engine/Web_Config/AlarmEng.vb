Imports System.Data
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.IO

Namespace Web_Config
    Public Class AlarmEng

        Public Function GetgvServerSetting(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim lnq As New TbRegisterLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = "Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'CPU' as AlarmType, '' as AlarmName, Convert(varchar(255),C1.CPUPercent)+' %' as Percents ,Convert(varchar(255),AC.AlarmMinorValue)+' %' +' , '+ Convert(varchar(255),AC.AlarmMajorValue)+' %' +' , ' + Convert(varchar(255),AC.AlarmCriticalValue)+' %' as ConfigValue " & vbNewLine
            sql += " ,case when C1.CPUPercent  > AC.AlarmMinorValue and C1.CPUPercent < AC.AlarmMajorValue then 'Over Minor '+CONVERT(Varchar(255),C1.CPUPercent - AC.AlarmMinorValue)+' %'  " & vbNewLine
            sql += " else case when C1.CPUPercent > AC.AlarmMajorValue and C1.CPUPercent < AC.AlarmCriticalValue then 'Over Major '+CONVERT(Varchar(255),C1.CPUPercent - AC.AlarmMajorValue)+' %'" & vbNewLine
            sql += " else case when C1.CPUPercent > AC.AlarmCriticalValue then 'Over Critical '+CONVERT(Varchar(255),C1.CPUPercent - AC.AlarmCriticalValue)+' %' " & vbNewLine
            sql += " end end end as OverPercent" & vbNewLine
            sql += " ,AC.CreatedBy , AC.CreatedDate  " & vbNewLine
            sql += " from TB_REGISTER R1" & vbNewLine
            sql += " inner join TB_CPU_INFO C1 on C1.ServerName = R1.ServerName " & vbNewLine
            sql += " inner join CF_CONFIG_CPU AC on AC.ServerName = R1.ServerName " & vbNewLine
            sql += " where R1.Active_Status = 'Y'" & vbNewLine
            sql += " UNION ALL " & vbNewLine
            sql += " Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'RAM' as AlarmType, '' as AlarmName, Convert(varchar(255),RAM.RAMPercent)+' %' as Percents ,Convert(varchar(255),AR.AlarmMinorValue)+' %' +' , '+ Convert(varchar(255),AR.AlarmMajorValue)+' %' +' , ' + Convert(varchar(255),AR.AlarmCriticalValue)+' %' as ConfigValue " & vbNewLine
            sql += " ,case when RAM.RAMPercent   > AR.AlarmMinorValue and RAM.RAMPercent  < AR.AlarmMajorValue then 'Over Minor '+CONVERT(Varchar(255),RAM.RAMPercent  - AR.AlarmMinorValue)+' %'  " & vbNewLine
            sql += " else case when RAM.RAMPercent  > AR.AlarmMajorValue and RAM.RAMPercent  < AR.AlarmCriticalValue then 'Over Major '+CONVERT(Varchar(255),RAM.RAMPercent  - AR.AlarmMajorValue)+' %'" & vbNewLine
            sql += " else case when RAM.RAMPercent  > AR.AlarmCriticalValue then 'Over Critical '+CONVERT(Varchar(255),RAM.RAMPercent  - AR.AlarmCriticalValue)+' %' " & vbNewLine
            sql += " end end end as OverPercent" & vbNewLine
            sql += " ,AR.CreatedBy , AR.CreatedDate" & vbNewLine
            sql += " from TB_REGISTER R1" & vbNewLine
            sql += " inner join TB_RAM_INFO RAM on RAM.ServerName = R1.ServerName " & vbNewLine
            sql += " inner join CF_CONFIG_RAM AR on AR.ServerName = R1.ServerName" & vbNewLine
            sql += " where R1.Active_Status = 'Y'" & vbNewLine
            sql += "  UNION ALL" & vbNewLine
            sql += " select DISTINCT R1.id,R1.ServerName ,R1.ServerIP ,'Drive' as AlarmType, '' as AlarmName " & vbNewLine
            sql += " , D1.DriveLetter+' = '+CONVERT(varchar(255),D1.PercentUsage)+' %' AS Percents" & vbNewLine
            sql += " ,Convert(varchar(255),AD.AlarmMinorValue)+' %' +' , '+ Convert(varchar(255),AD.AlarmMajorValue)+' %' +' , ' + Convert(varchar(255),AD.AlarmCriticalValue)+' %' as ConfigValue" & vbNewLine
            sql += " ,case when D1.PercentUsage > AD.AlarmMinorValue and D1.PercentUsage < AD.AlarmMajorValue then 'Over Minor '+CONVERT(Varchar(255),D1.PercentUsage - AD.AlarmMinorValue)+' %'  " & vbNewLine
            sql += " else case when D1.PercentUsage > AD.AlarmMajorValue and D1.PercentUsage < AD.AlarmCriticalValue then 'Over Major '+CONVERT(Varchar(255),D1.PercentUsage - AD.AlarmMajorValue)+' %'" & vbNewLine
            sql += " else case when D1.PercentUsage > AD.AlarmCriticalValue then 'Over Critical '+CONVERT(Varchar(255),D1.PercentUsage - AD.AlarmCriticalValue)+' %' " & vbNewLine
            sql += " end end end as OverPercent" & vbNewLine
            sql += " ,AD.CreatedBy , AD.CreatedDate  " & vbNewLine
            sql += " from " & vbNewLine
            sql += " TB_REGISTER R1" & vbNewLine
            sql += " inner join TB_DRIVE_INFO D1 on R1.ServerName = D1.ServerName" & vbNewLine
            sql += " inner join CF_CONFIG_DRIVE CD on R1.ServerName = CD.ServerName " & vbNewLine
            sql += " inner  join CF_CONFIG_DRIVE_DETAIL AD on CD.id = AD.cf_config_drive_id and D1.DriveLetter = AD.DriveLetter  " & vbNewLine
            sql += " where R1.Active_Status = 'Y'" & vbNewLine
            sql += "  UNION ALL " & vbNewLine
            sql += " Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'File' as AlarmType, F.FileName as AlarmName, Convert(varchar(255),F.FileSizeGB)+' GB' as Percents ,Convert(varchar(255),FD.FileSizeMinor)+' GB' +' , '+ Convert(varchar(255),FD.FileSizeMajor)+' GB' +' , ' + Convert(varchar(255),FD.FileSizeCritical)+' GB' as ConfigValue  " & vbNewLine
            sql += "  ,case when F.FileSizeGB > FD.FileSizeMinor and F.FileSizeGB  < FD.FileSizeMajor then 'Over Minor '+CONVERT(Varchar(255),F.FileSizeGB - FD.FileSizeMinor)+' GB'  " & vbNewLine
            sql += " else case when F.FileSizeGB  > FD.FileSizeMajor and F.FileSizeGB  < FD.FileSizeCritical then 'Over Major '+CONVERT(Varchar(255),F.FileSizeGB  - FD.FileSizeMajor)+' GB' " & vbNewLine
            sql += " else case when F.FileSizeGB > FD.FileSizeCritical then 'Over Critical '+CONVERT(Varchar(255),F.FileSizeGB  - FD.FileSizeCritical)+' GB' " & vbNewLine
            sql += "  end end end as OverPercent " & vbNewLine
            sql += " ,FD.CreatedBy , FD.CreatedDate " & vbNewLine
            sql += " from TB_REGISTER R1 " & vbNewLine
            sql += " inner join TB_FILESIZE_INFO F  on F.ServerName = R1.ServerName  " & vbNewLine
            sql += " inner join CF_CONFIG_FILESIZE CF  on CF.ServerName = R1.ServerName and CF.ServerIP = R1.ServerIP " & vbNewLine
            sql += " inner join CF_CONFIG_FILESIZE_DETAIL FD on FD.cf_config_filesize_id = CF.id " & vbNewLine
            sql += " where R1.Active_Status = 'Y' " & vbNewLine
            sql += " UNION ALL " & vbNewLine
            sql += " Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'Process' as AlarmType, MP.WindowProcessName as AlarmName, P.ProcessAlive  as Percents , '' as ConfigValue  " & vbNewLine
            sql += " ,'' as OverPercent " & vbNewLine
            sql += " ,CP.CreatedBy , CP.CreatedDate " & vbNewLine
            sql += "  from TB_REGISTER R1" & vbNewLine
            sql += " inner join TB_PROCESS_INFO P on R1.ServerIP = P.ServerIP and R1.ServerName = P.ServerName " & vbNewLine
            sql += " inner join CF_CONFIG_PROCESS CP on R1.ServerIP = CP.ServerIP and R1.ServerName = CP.ServerName " & vbNewLine
            sql += " inner join CF_CONFIG_PROCESS_DETAIL cpd on cpd.cf_config_process_id=cp.id " & vbNewLine
            sql += " inner join MS_MASTER_PROCESS_CHECKLIST MP on MP.id = cpd.ms_master_process_checklist_id " & vbNewLine
            sql += " where R1.Active_Status = 'Y' " & vbNewLine
            sql += " UNION ALL " & vbNewLine
            sql += " Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'Service' as AlarmType, MS.WindowServiceName as AlarmName, S.ServiceStatus as Percents , '' as ConfigValue " & vbNewLine
            sql += " ,'' as OverPercent " & vbNewLine
            sql += " ,CS.CreatedBy , CS.CreatedDate " & vbNewLine
            sql += " from TB_REGISTER R1 " & vbNewLine
            sql += " inner join TB_SERVICE_INFO S on R1.ServerIP = S.ServerIP and R1.ServerName = S.ServerName " & vbNewLine
            sql += " inner join CF_CONFIG_SERVICE cs on cs.ServerIP=s.ServerIP and cs.ServerName=s.ServerName" & vbNewLine
            sql += " inner join CF_CONFIG_SERVICE_DETAIL csd on cs.id=csd.cf_config_service_id " & vbNewLine
            sql += " inner join MS_MASTER_SERVICE_CHECKLIST MS on MS.id = CSd.ms_master_service_checklist_id  " & vbNewLine
            sql += " where R1.Active_Status = 'Y' and isnull(S.ServiceStatus,'') <> 'Not_Service' " & vbNewLine + wh

            dt = lnq.GetListBySql(sql, Nothing)

            Return dt
        End Function

        Public Function GetgvGroupSetting(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbGroupLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = ("Select Distinct G.group_desc ,'CPU' as AlarmType")
            sql += (" ,Convert(varchar(255),AC.AlarmMinorValue)+' %' +' , '")
            sql += (" + Convert(varchar(255),AC.AlarmMajorValue)+' %' +' , ' ")
            sql += (" + Convert(varchar(255),AC.AlarmCriticalValue)+' %' as ConfigValue")
            sql += (" ,AC.CreatedBy , AC.CreatedDate ")
            sql += (" from TB_GROUP G ")
            sql += (" join TB_REGISTER R on R.group_id = G.id ")
            sql += (" join TB_CPU_INFO CPU on R.ServerName = CPU.ServerName ")
            sql += (" join CF_CONFIG_CPU AC on AC.ServerName = R.ServerName")
            sql += (" where G.group_desc <> 'NoGroup' and R.Active_Status = 'Y'")
            sql += (" UNION ALL")
            sql += (" Select Distinct G.group_desc ,'RAM' as AlarmType")
            sql += (" ,Convert(varchar(255),AR.AlarmMinorValue)+' %' +' , '")
            sql += (" + Convert(varchar(255),AR.AlarmMajorValue)+' %' +' , ' ")
            sql += (" + Convert(varchar(255),AR.AlarmCriticalValue)+' %' as ConfigValue")
            sql += (" ,AR.CreatedBy ,AR.CreatedDate")
            sql += (" from TB_GROUP G ")
            sql += (" join TB_REGISTER R on R.group_id = G.id")
            sql += (" join CF_CONFIG_RAM AR on AR.ServerName = R.ServerName ")
            sql += (" join TB_RAM_INFO RAM on RAM.ServerName = R.ServerName")
            sql += (" where G.group_desc <> 'NoGroup' and R.Active_Status = 'Y' ") + wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetgvAlarmServer(ByRef wh As String) As DataTable

            Dim dt As New DataTable
            Dim lnq As New TbRegisterLinqDB

            Dim sql As String
            sql = " Select id,ServerName,HostIP,SpecificProblem  , AlarmActivity " & vbNewLine
            sql += "  ,Severity ,case when AlarmActivity = 'Process' then AlarmValue " & vbNewLine
            sql += "  else case when AlarmActivity  = 'Service' then AlarmValue" & vbNewLine
            sql += "   else case when AlarmActivity  <> 'Procss' and AlarmActivity  <> 'Service' then  Convert(Varchar(255),AlarmValue )+' %' end end end as Value " & vbNewLine
            sql += "  ,AlarmQty ,FlagAlarm ,(convert(varchar(10),CreatedDate,103) + ' ' + convert(varchar(10),CreatedDate,108) ) CreatedDate ,(convert(varchar(10),UpdatedDate,103) + ' ' + convert(varchar(10),UpdatedDate,108) ) UpdatedDate " & vbNewLine
            sql += "  from TB_ALARM_WAITING_CLEAR" & vbNewLine
            sql += "  where FlagAlarm = 'Alarm' and isnull(AlarmValue,'') <> 'Not_Service' " & vbNewLine + wh
            sql += " Order by UpdatedDate DESC"
            dt = lnq.GetListBySql(sql, Nothing)
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("AlarmActivity").ToString.ToLower <> "port" And dt.Rows(i)("AlarmActivity").ToString.ToLower <> "service" _
                   And dt.Rows(i)("AlarmActivity").ToString.ToLower <> "process" Then
                    dt.Rows(i)("Value") = ""
                End If
            Next
            Return dt
        End Function


        Public Function GetbtnAlarm(ByRef ServerIP As String, ByRef ServerName As String, ByRef Specific_Problem As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            Dim wh As String = ""
            If ServerIP <> "" Then
                wh &= " and HostIP LIKE '%" & ServerIP & "%'"
            End If
            If ServerName <> "" Then
                wh &= " and ServerName LIKE '%" & ServerName & "%'"
            End If
            If Specific_Problem <> "" Then
                wh &= " and SpecificProblem LIKE '%" & Specific_Problem & "%'"
            End If

            Dim sql As String
            sql = " Select id,ServerName,HostIP,SpecificProblem  , AlarmActivity "
            sql += "  ,Severity ,case when AlarmActivity = 'Process' then AlarmValue "
            sql += "  else case when AlarmActivity  = 'Service' then AlarmValue"
            sql += "   else case when AlarmActivity  <> 'Procss' and AlarmActivity  <> 'Service' then  Convert(Varchar(255),AlarmValue )+' %' end end end as Value "
            sql += "  ,AlarmQty ,FlagAlarm ,(convert(varchar(10),CreatedDate,103) + ' ' + convert(varchar(10),CreatedDate,108) ) CreatedDate ,(convert(varchar(10),UpdatedDate,103) + ' ' + convert(varchar(10),UpdatedDate,108) ) UpdatedDate "
            sql += "  from TB_ALARM_WAITING_CLEAR"
            sql += "  where FlagAlarm = 'Alarm' and isnull (AlarmValue,'') <> 'Not_Service' " & wh
            sql += " Order by UpdatedDate DESC"
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            For i As Integer = 0 To dt.Rows.Count - 1
                If dt.Rows(i)("AlarmActivity").ToString.ToLower <> "port" And dt.Rows(i)("AlarmActivity").ToString.ToLower <> "service" _
                   And dt.Rows(i)("AlarmActivity").ToString.ToLower <> "process" Then
                    dt.Rows(i)("Value") = ""
                End If
            Next
            Return dt
        End Function


        Public Function GetbtnSearch(ByRef ServerIP As String, ByRef ServerName As String) As DataTable

            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            Dim sql As String

            sql = ("Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'CPU' as AlarmType, '' as AlarmName, Convert(varchar(255),C1.CPUPercent)+' %' as Percents ,Convert(varchar(255),AC.AlarmMinorValue)+' %' +' , '+ Convert(varchar(255),AC.AlarmMajorValue)+' %' +' , ' + Convert(varchar(255),AC.AlarmCriticalValue)+' %' as ConfigValue ")
            sql += (" ,case when C1.CPUPercent  > AC.AlarmMinorValue and C1.CPUPercent < AC.AlarmMajorValue then 'Over Minor '+CONVERT(Varchar(255),C1.CPUPercent - AC.AlarmMinorValue)+' %'  ")
            sql += (" else case when C1.CPUPercent > AC.AlarmMajorValue and C1.CPUPercent < AC.AlarmCriticalValue then 'Over Major '+CONVERT(Varchar(255),C1.CPUPercent - AC.AlarmMajorValue)+' %'")
            sql += (" else case when C1.CPUPercent > AC.AlarmCriticalValue then 'Over Critical '+CONVERT(Varchar(255),C1.CPUPercent - AC.AlarmCriticalValue)+' %' ")
            sql += (" end end end as OverPercent")
            sql += (" ,AC.CreatedBy , AC.CreatedDate  ")
            sql += (" from TB_REGISTER R1")
            sql += (" join TB_CPU_INFO C1 on C1.ServerName = R1.ServerName ")
            sql += (" join CF_CONFIG_CPU AC on AC.ServerName = R1.ServerName ")
            sql += (" where R1.ServerIP LIKE '%" & ServerIP & "%' and R1.ServerName LIKE '%" & ServerName & "%' and R1.Active_Status = 'Y'")
            sql += (" UNION ALL ")
            sql += (" Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'RAM' as AlarmType, '' as AlarmName, Convert(varchar(255),RAM.RAMPercent)+' %' as Percents ,Convert(varchar(255),AR.AlarmMinorValue)+' %' +' , '+ Convert(varchar(255),AR.AlarmMajorValue)+' %' +' , ' + Convert(varchar(255),AR.AlarmCriticalValue)+' %' as ConfigValue ")
            sql += (" ,case when RAM.RAMPercent   > AR.AlarmMinorValue and RAM.RAMPercent  < AR.AlarmMajorValue then 'Over Minor '+CONVERT(Varchar(255),RAM.RAMPercent  - AR.AlarmMinorValue)+' %'  ")
            sql += (" else case when RAM.RAMPercent  > AR.AlarmMajorValue and RAM.RAMPercent  < AR.AlarmCriticalValue then 'Over Major '+CONVERT(Varchar(255),RAM.RAMPercent  - AR.AlarmMajorValue)+' %'")
            sql += (" else case when RAM.RAMPercent  > AR.AlarmCriticalValue then 'Over Critical '+CONVERT(Varchar(255),RAM.RAMPercent  - AR.AlarmCriticalValue)+' %' ")
            sql += (" end end end as OverPercent")
            sql += (" ,AR.CreatedBy , AR.CreatedDate")
            sql += (" from TB_REGISTER R1")
            sql += (" join TB_RAM_INFO RAM on RAM.ServerName = R1.ServerName ")
            sql += (" join CF_CONFIG_RAM AR on AR.ServerName = R1.ServerName")
            sql += (" where R1.ServerIP LIKE '%" & ServerIP & "%' and R1.ServerName LIKE '%" & ServerName & "%' and R1.Active_Status = 'Y'")
            sql += ("  UNION ALL")
            sql += (" select DISTINCT R1.id,R1.ServerName ,R1.ServerIP ,'Drive' as AlarmType, '' as AlarmName ")
            sql += (" , D1.DriveLetter+' = '+CONVERT(varchar(255),D1.PercentUsage)+' %' AS Percents")
            sql += (" ,Convert(varchar(255),AD.AlarmMinorValue)+' %' +' , '+ Convert(varchar(255),AD.AlarmMajorValue)+' %' +' , ' + Convert(varchar(255),AD.AlarmCriticalValue)+' %' as ConfigValue")
            sql += (" ,case when D1.PercentUsage > AD.AlarmMinorValue and D1.PercentUsage < AD.AlarmMajorValue then 'Over Minor '+CONVERT(Varchar(255),D1.PercentUsage - AD.AlarmMinorValue)+' %'  ")
            sql += (" else case when D1.PercentUsage > AD.AlarmMajorValue and D1.PercentUsage < AD.AlarmCriticalValue then 'Over Major '+CONVERT(Varchar(255),D1.PercentUsage - AD.AlarmMajorValue)+' %'")
            sql += (" else case when D1.PercentUsage > AD.AlarmCriticalValue then 'Over Critical '+CONVERT(Varchar(255),D1.PercentUsage - AD.AlarmCriticalValue)+' %' ")
            sql += (" end end end as OverPercent")
            sql += (" ,AD.CreatedBy , AD.CreatedDate  ")
            sql += (" from ")
            sql += (" TB_REGISTER R1")
            sql += (" join TB_DRIVE_INFO D1 on R1.ServerName = D1.ServerName")
            sql += (" join CF_CONFIG_DRIVE CD on R1.ServerName = CD.ServerName ")
            sql += ("  join CF_CONFIG_DRIVE_DETAIL AD on CD.id = AD.cf_config_drive_id and D1.DriveLetter = AD.DriveLetter  ")
            sql += (" where R1.ServerIP LIKE '%" & ServerIP & "%' and R1.ServerName LIKE '%" & ServerName & "%' and R1.Active_Status = 'Y'")
            sql += ("  UNION ALL ")
            sql += (" Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'File' as AlarmType, F.FileName as AlarmName, Convert(varchar(255),F.FileSizeGB)+' GB' as Percents ,Convert(varchar(255),FD.FileSizeMinor)+' GB' +' , '+ Convert(varchar(255),FD.FileSizeMajor)+' GB' +' , ' + Convert(varchar(255),FD.FileSizeCritical)+' GB' as ConfigValue  ")
            sql += ("  ,case when F.FileSizeGB > FD.FileSizeMinor and F.FileSizeGB  < FD.FileSizeMajor then 'Over Minor '+CONVERT(Varchar(255),F.FileSizeGB - FD.FileSizeMinor)+' GB'  ")
            sql += (" else case when F.FileSizeGB  > FD.FileSizeMajor and F.FileSizeGB  < FD.FileSizeCritical then 'Over Major '+CONVERT(Varchar(255),F.FileSizeGB  - FD.FileSizeMajor)+' GB' ")
            sql += (" else case when F.FileSizeGB > FD.FileSizeCritical then 'Over Critical '+CONVERT(Varchar(255),F.FileSizeGB  - FD.FileSizeCritical)+' GB' ")
            sql += ("  end end end as OverPercent ")
            sql += (" ,FD.CreatedBy , FD.CreatedDate ")
            sql += (" from TB_REGISTER R1 ")
            sql += (" join TB_FILESIZE_INFO F  on F.ServerName = R1.ServerName  ")
            sql += ("  join CF_CONFIG_FILESIZE CF  on CF.ServerName = R1.ServerName and CF.ServerIP = R1.ServerIP ")
            sql += (" join CF_CONFIG_FILESIZE_DETAIL FD on FD.cf_config_filesize_id = CF.id ")
            sql += (" where R1.ServerIP LIKE '%" & ServerIP & "%' and R1.ServerName LIKE '%" & ServerName & "%' and R1.Active_Status = 'Y' ")
            sql += (" UNION ALL ")
            sql += (" Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'Process' as AlarmType, MP.WindowProcessName as AlarmName, P.ProcessAlive  as Percents , '' as ConfigValue  ")
            sql += (" ,'' as OverPercent ")
            sql += ("  ,CP.CreatedBy , CP.CreatedDate ")
            sql += ("  from TB_REGISTER R1")
            sql += (" join TB_PROCESS_INFO P on R1.ServerIP = P.ServerIP and R1.ServerName = P.ServerName ")
            sql += (" join CF_CONFIG_PROCESS CP on R1.ServerIP = CP.ServerIP and R1.ServerName = CP.ServerName ")
            sql += (" join MS_MASTER_PROCESS_CHECKLIST MP on MP.id = CP.ms_process_checklist_id and MP.MacAddress = R1.MacAddress and P.WindowProcessName = MP.WindowProcessName ")
            sql += ("  where R1.ServerIP LIKE '%" & ServerIP & "%' and R1.ServerName LIKE '%" & ServerName & "%' and R1.Active_Status = 'Y' ")
            sql += ("  UNION ALL ")
            sql += ("  Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'Service' as AlarmType, MS.WindowServiceName as AlarmName, S.ServiceStatus as Percents , '' as ConfigValue ")
            sql += ("  ,'' as OverPercent ")
            sql += (" ,CS.CreatedBy , CS.CreatedDate ")
            sql += ("  from TB_REGISTER R1 ")
            sql += ("  join TB_SERVICE_INFO S on R1.ServerIP = S.ServerIP and R1.ServerName = S.ServerName ")
            sql += ("  join CF_CONFIG_SERVICE CS on R1.ServerIP = CS.ServerIP and R1.ServerName = CS.ServerName ")
            sql += ("  join MS_MASTER_SERVICE_CHECKLIST MS on MS.id = CS.ms_service_checklist_id  and MS.MacAddress = R1.MacAddress and S.ServiceName = MS.WindowServiceName ")
            sql += ("  where R1.ServerIP LIKE '%" & ServerIP & "%' and R1.ServerName LIKE '%" & ServerName & "%' and R1.Active_Status = 'Y' and isnull(S.ServiceStatus,'') <> 'Not_Service' ")
            'sql += ("  UNION ALL ")
            'sql += ("  Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'Port' as AlarmType, PL.PortNumber as AlarmName, '' as Percents , '' as ConfigValue ")
            'sql += ("   ,'' as OverPercent ")
            'sql += (" ,ISNULL(CreatedBy ,'') as CreatedBy , ISNULL(CreatedDate ,'') as CreatedDate ")
            'sql += ("  from TB_REGISTER R1 ")
            'sql += (" join TB_CONFIG_PORT_LIST PL on R1.ServerIP = PL.HostIP and R1.ServerName = PL.HostName  ")
            'sql += (" where R1.ServerIP LIKE '%" & ServerIP & "%' and R1.ServerName LIKE '%" & ServerName & "%' R1.Active_Status = 'Y' ")

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function


        Public Function GetgvPopupAlarmServer(ByRef wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            Dim sql As String
            sql = ("Select R.id, R.ServerName,R.ServerIP,SpecificProblem ,Severity")
            sql += (" ,case when AW.AlarmActivity = 'Process' then AW.AlarmValue ")
            sql += (" else case when AW.AlarmActivity = 'Service' then AW.AlarmValue ")
            sql += (" else case when AW.AlarmActivity <> 'Process' and AW.AlarmActivity <> 'Service' then  Convert(Varchar(255),AW.AlarmValue)+' %' end end end as Percents ")
            sql += (" ,AW.FlagAlarm ,AW.CreateDate,AW.UpdateDate")
            sql += (" from ")
            sql += (" TB_REGISTER R join TB_ALARM_WAITING_CLEAR AW on R.ServerName = AW.ServerName ")
            sql += (" join CF_CONFIG_CPU AC on AC.ServerName = R.ServerName ")
            sql += ("  join TB_GROUP G on R.group_id = G.id")
            sql += (" where AW.FlagAlarm <> 'Clear' and G.group_desc = '" & wh & "' and R.Active_Status = 'Y' ")
            sql += (" Order by AW.UpdateDate DESC")
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetgvPopupServerSetting(ByRef wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            Dim sql As String
            sql = ("Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'CPU' as AlarmType, Convert(varchar(255),C1.CPUPercent)+' %' as Percents ,Convert(varchar(255),AC.AlarmMinorValue)+' %' +' , '+ Convert(varchar(255),AC.AlarmMajorValue)+' %' +' , ' + Convert(varchar(255),AC.AlarmCriticalValue)+' %' as ConfigValue ")
            sql += (" ,AC.CreatedBy , AC.CreatedDate  ")
            sql += (" from TB_REGISTER R1")
            sql += (" join TB_CPU_INFO C1 on C1.ServerName = R1.ServerName ")
            sql += (" join CF_CONFIG_CPU AC on AC.ServerName = R1.ServerName ")
            sql += (" join TB_GROUP G on G.id = R1.group_id")
            sql += (" where G.group_desc = '" & wh & "' and R1.Active_Status = 'Y' ")
            sql += (" UNION ALL ")
            sql += (" Select Distinct R1.id,R1.ServerName ,R1.ServerIP ,'RAM' as AlarmType, Convert(varchar(255),RAM.RAMPercent)+' %' as Percents ,Convert(varchar(255),AR.AlarmMinorValue)+' %' +' , '+ Convert(varchar(255),AR.AlarmMajorValue)+' %' +' , ' + Convert(varchar(255),AR.AlarmCriticalValue)+' %' as ConfigValue ")
            sql += (" ,AR.CreatedBy , AR.CreatedDate")
            sql += (" from TB_REGISTER R1")
            sql += (" join TB_RAM_INFO RAM on RAM.ServerName = R1.ServerName ")
            sql += (" join CF_CONFIG_RAM AR on AR.ServerName = R1.ServerName")
            sql += (" join TB_GROUP G on G.id = R1.group_id")
            sql += (" where G.group_desc = '" & wh & "' and R1.Active_Status = 'Y' ")
            sql += ("  UNION ALL")
            sql += (" select DISTINCT R1.id,R1.ServerName ,R1.ServerIP ,'Drive' as AlarmType ")
            sql += (" , D1.DriveLetter+' = '+CONVERT(varchar(255),D1.PercentUsage)+' %' AS Percents")
            sql += (" ,Convert(varchar(255),AD.AlarmMinorValue)+' %' +' , '+ Convert(varchar(255),AD.AlarmMajorValue)+' %' +' , ' + Convert(varchar(255),AD.AlarmCriticalValue)+' %' as ConfigValue")
            sql += (" ,AD.CreatedBy , AD.CreatedDate  ")
            sql += (" from ")
            sql += (" TB_REGISTER R1")
            sql += (" join TB_DRIVE_INFO D1 on R1.ServerName = D1.ServerName")
            sql += (" join CF_CONFIG_DRIVE CD on R1.ServerName = CD.ServerName ")
            sql += ("  join CF_CONFIG_DRIVE_DETAIL AD on CD.id = AD.cf_config_drive_id and D1.DriveLetter = AD.DriveLetter  ")
            sql += (" join TB_GROUP G on G.id = R1.group_id")
            sql += (" where G.group_desc = '" & wh & "' and R1.Active_Status = 'Y' ")
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

    End Class

End Namespace
