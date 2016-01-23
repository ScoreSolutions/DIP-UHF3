
Imports System.Data
Imports LinqDB.TABLE
Imports LinqDB.ConnectDB


Namespace Web_Config
    Public Class CPUEng

        Public Function GetServerName() As DataTable
            Dim dt As New DataTable

            Dim lnq As New LinqDB.TABLE.TbCpuInfoLinqDB
            Dim sql As String = "select ServerName ,ServerIP ,CPUPercent from TB_CPU_INFO "
            dt = lnq.GetListBySql(sql, Nothing)
            'Dim lnq As New LinqDB.TABLE.CfConfigFilesizeDetailLinqDB
            'Dim sql As String = "select fd.FileName, fd.FileSizeMinor, fd.FileSizeMajor, fd.FileSizeCritical"
            'sql += " from CF_CONFIG_FILESIZE_DETAIL fd"
            'sql += " inner join CF_CONFIG_FILESIZE f on f.id=fd.cf_config_filesize_id"
            'sql += " where f.ServerName = '" & ServerName & "' and f.ActiveStatus='Y'"
            'sql += " order by fd.FileName"
            'ret = lnq.GetListBySql(sql, Nothing)

            Return dt
        End Function

        Public Function GetIDcfCPU(ByVal wh As String) As String
            Dim id As String
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigRamLinqDB

            Dim sql As String
            sql = "select id,ServerName ,ServerIP,MacAddress  from CF_CONFIG_CPU where ServerIP = '" & wh & "'"
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)

            If dt.Rows.Count > 0 Then
                id = dt.Rows(0)(0).ToString()
            Else
                id = 0
            End If

            Return id
        End Function
      
        Public Function GetgvCPU(ByRef wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigRamLinqDB

            Dim sql As String

            If wh <> "" Then
                wh = "and " & wh
            End If

            sql = "select TR.id as idRes,TR.ServerIP,TR.ServerName,TR.MacAddress,TR.group_id,TG.group_code,TG.group_desc"
            sql += ",CP.CheckIntervalMinute,CP.AlarmMinorValue,CP.RepeatCheckMinor,CP.AlarmMajorValue,CP.RepeatCheckMajor,CP.AlarmCriticalValue,CP.RepeatCheckCritical,cp.id as idcfCPU,cp.ActiveStatus from TB_REGISTER TR inner join TB_GROUP TG on TR .group_id = TG .id inner join CF_CONFIG_CPU CP"
            sql += " on TR .ServerIP =CP .ServerIP where 1=1 " & wh

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Dim _err As String = ""

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err.Trim()
            End Get
        End Property
        Public Function CheckDuplicateRegister(ByVal id As Long, ByVal ServerIP As String, ByVal ServerName As String, ByVal MacAddress As String) As Boolean

            Dim ret As Boolean = False
            Dim lnq As New CfConfigCpuLinqDB
            Dim trans As New TransactionDB

            ret = lnq.ChkDataByWhere("ServerIP = '" & ServerIP & "' and id <>'" & id & "'", trans.Trans)
            If ret = False Then

                ret = lnq.ChkDataByWhere("ServerName = '" & ServerName & "' and id <>'" & id & "'", trans.Trans)
                If ret = False Then

                    ret = lnq.ChkDataByWhere("MacAddress = '" & MacAddress & "' and id <>'" & id & "'", trans.Trans)
                    If ret = False Then
                        _err = "alert('Mac Address Repeated !');"

                    End If
                Else
                    _err = "alert('Server Name Repeated !');"
                End If
            Else
                _err = "alert('Server IP Repeated !');"

            End If
            trans.CommitTransaction()
            lnq = Nothing

            Return ret


        End Function

        Public Function GetCPU(ServerIP As String, ServerName As String, MacAddress As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,ServerIP,ServerName,CheckIntervalMinute,AlarmMinorValue,AlarmMajorValue,AlarmCriticalValue,ActiveStatus"
            sql += ",MacAddress,RepeatCheckMinor,RepeatCheckMajor,RepeatCheckCritical,AlarmSun,AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri"
            sql += ",AlarmSat,AlarmTimeFrom,AlarmTimeTo,AllDayEvent,LastCheckTime from CF_CONFIG_CPU "
            sql += " where ServerIP ='" & ServerIP & "' or ServerName='" & ServerName & "' or MacAddress='" & MacAddress & "'"
            dt = SqlDB.ExecuteTable(sql)

            Return dt
        End Function

    End Class

End Namespace

