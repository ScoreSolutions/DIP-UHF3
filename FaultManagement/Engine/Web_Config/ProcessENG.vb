Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Data
Imports System.Linq
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace Web_Config

    Public Class ProcessENG
        Public Function SetShowProcess(ByVal wh As String) As DataTable
            Dim dt As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New MsMasterProcessChecklistLinqDB

            Dim sql As String
            sql = "select id,DisplayName ,ActiveStatus,WindowProcessName  from MS_MASTER_PROCESS_CHECKLIST  where ActiveStatus = 'Y'"
            dt = lnq.GetListBySql(sql, trans.Trans)


            Return dt
        End Function
        Public Function SetProcess(ByVal wh As String) As DataTable
            Dim dt As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New MsMasterProcessChecklistLinqDB

            Dim sql As String
            sql = "select id,DisplayName ,ActiveStatus,WindowProcessName,ActiveStatus  from MS_MASTER_PROCESS_CHECKLIST"
            dt = lnq.GetListBySql(sql, trans.Trans)


            Return dt
        End Function


        Public Function SetgvProcess(ByVal wh As String) As DataTable
            Dim dt As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigServiceLinqDB


            If wh <> "" Then
                wh = "and " & wh
            End If

            Dim sql As String

            sql = "select CF.id as idConfig,CF.ServerName,CF.ServerIP,CF.MacAddress,CF.CheckIntervalMinute,"
            sql += " CFd.RepeatCheckQty,CFd.ms_master_process_checklist_id ,MS.DisplayName,CF.ActiveStatus"
            sql += " from CF_CONFIG_PROCESS CF  "
            sql += " inner join CF_CONFIG_PROCESS_DETAIL cfd on cf.id=cfd.cf_config_process_id"
            sql += " inner join MS_MASTER_PROCESS_CHECKLIST MS on CFd.ms_master_process_checklist_id = MS.id "
            sql += " where 1=1 "
            sql += wh
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function _SetgvProcess(ByVal wh As String) As DataTable
            Dim dt As DataTable
            Dim lnq As New CfConfigProcessLinqDB

            If wh <> "" Then
                wh = " and " & wh
            End If

            Dim sql As String
            sql = "SELECT CP.ServerIP,CP.MacAddress,CP.ServerName,CP.CheckIntervalMinute,cpd.RepeatCheckQty,CP.ActiveStatus,TR.id as idRes "
            sql += " FROM CF_CONFIG_PROCESS CP "
            sql += " inner join TB_REGISTER TR on CP.ServerIP =TR.ServerIP "
            sql += " inner join CF_CONFIG_PROCESS_DETAIL cpd on cp.id=cpd.cf_config_process_id"
            sql += " where 1=1"
            sql += wh
            dt = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing

            Return dt
        End Function
        Dim _err As String = ""

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err.Trim()
            End Get
        End Property
        Public Function _CheckDuplicateRegister(ByVal id As Long, ByVal WindowProcessName As String) As Boolean

            Dim ret As Boolean = False
            Dim lnq As New MsMasterProcessChecklistLinqDB
            Dim trans As New TransactionDB

            ret = lnq.ChkDataByWhere("WindowProcessName = '" & WindowProcessName & "' and id <>'" & id & "'", trans.Trans)
            If ret = True Then

                _err = "alert('Process Name Repeated !');"

            End If
            trans.CommitTransaction()
            lnq = Nothing

            Return ret


        End Function

        Public Function GetProcess(ServerIP As String, ServerName As String, MacAddress As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,ServerIP,ServerName,CheckIntervalMinute,ActiveStatus,MacAddress,AlarmSun,AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri"
            sql += ",AlarmSat,AlarmTimeFrom,AlarmTimeTo,AllDayEvent,LastCheckTime from CF_CONFIG_PROCESS"
            sql += " where ServerIP ='" & ServerIP & "' or ServerName='" & ServerName & "' or MacAddress='" & MacAddress & "'"
            dt = SqlDB.ExecuteTable(sql)

            Return dt
        End Function

        Public Function GetProcessDetail(ServiceID As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,cf_config_process_id,ms_master_process_checklist_id,RepeatCheckQty from CF_CONFIG_PROCESS_DETAIL where cf_config_process_id='" & ServiceID & "'"
            dt = SqlDB.ExecuteTable(sql)
            Return dt
        End Function

    End Class

End Namespace

