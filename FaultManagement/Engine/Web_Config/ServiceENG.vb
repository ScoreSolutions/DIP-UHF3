Imports System.Web.Security
Imports System.Data
Imports System.Linq
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace Web_Config

    Public Class ServiceENG
        Public Function GetIDcfService(ByVal wh As String) As String
            Dim id As String
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigRamLinqDB

            Dim sql As String
            sql = "select id,ServerName ,ServerIP,MacAddress  from CF_CONFIG_SERVICE  where ServerIP = '" & wh & "'"
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)

            If dt.Rows.Count > 0 Then
                id = dt.Rows(0)(0).ToString()
            Else
                id = 0
            End If

            Return id
        End Function

        
        Public Function SetShowService(ByVal wh As String) As DataTable
            Dim dt As DataTable
            'Dim trans As New TransactionDB
            Dim lnq As New MsMasterServiceChecklistLinqDB

            Dim sql As String
            sql = "select id,DisplayName ,ActiveStatus,WindowServiceName from MS_MASTER_SERVICE_CHECKLIST where ActiveStatus = 'Y'"
            dt = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing

            Return dt
        End Function

        Public Function Service(ByVal wh As String) As DataTable
            Dim dt As DataTable
            'Dim trans As New TransactionDB
            Dim lnq As New MsMasterServiceChecklistLinqDB

            Dim sql As String
            sql = "select id,DisplayName ,ActiveStatus,WindowServiceName,ActiveStatus from MS_MASTER_SERVICE_CHECKLIST"
            dt = lnq.GetListBySql(sql, Nothing)
            lnq = Nothing

            Return dt
        End Function


        Public Function SetgvService(ByVal wh As String) As DataTable
            Dim dt As DataTable
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigServiceLinqDB

            If wh <> "" Then
                wh = "and " & wh
            End If
            Dim sql As String

            sql = "select CF.id as idConfig ,CF.ServerName ,CF.ServerIP ,CF.MacAddress,CF.CheckIntervalMinute,CF.RepeatCheckQty,CF.ms_service_checklist_id,MS.DisplayName,CF.ActiveStatus"
            sql += " from CF_CONFIG_SERVICE CF inner join  MS_MASTER_SERVICE_CHECKLIST MS on CF .ms_service_checklist_id = MS.id where 1=1 "
            sql += wh
            dt = lnq.GetListBySql(sql, trans.Trans)

            Return dt
        End Function

        Public Function _SetgvService(ByVal wh As String) As DataTable
            Dim dt As DataTable

            Dim lnq As New CfConfigServiceLinqDB

            If wh <> "" Then
                wh = "and " & wh
            End If
            Dim sql As String
            sql = "SELECT CS.ServerIP,CS.MacAddress,CS.ServerName,CS.CheckIntervalMinute,csd.RepeatCheckQty,CS.ActiveStatus,"
            sql += " TR.id as idRes "
            sql += " from CF_CONFIG_SERVICE CS "
            sql += " inner join TB_REGISTER TR on CS.ServerIP = TR.ServerIP "
            sql += " inner join CF_CONFIG_SERVICE_DETAIL csd on cs.id=csd.cf_config_service_id"
            sql += " where 1=1 "
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
        Public Function CheckDuplicateRegister(ByVal id As Long, ByVal ServerIP As String, ByVal ServerName As String, ByVal MacAddress As String) As Boolean

            Dim ret As Boolean = False
            Dim lnq As New CfConfigServiceLinqDB
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


        Public Function _CheckDuplicateRegister(ByVal id As Long, ByVal WindowServiceName As String) As Boolean

            Dim ret As Boolean = False
            Dim lnq As New MsMasterServiceChecklistLinqDB
            Dim trans As New TransactionDB

            ret = lnq.ChkDataByWhere("WindowServiceName = '" & WindowServiceName & "' and id <>'" & id & "'", trans.Trans)
            If ret = True Then

                _err = "alert('Service Name Repeated !');"

            End If
            trans.CommitTransaction()
            lnq = Nothing

            Return ret


        End Function

        Public Function GetService(ServerIP As String, ServerName As String, MacAddress As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,ServerIP,ServerName,CheckIntervalMinute,ActiveStatus,MacAddress,AlarmSun,AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri
            sql += ",AlarmSat,AlarmTimeFrom,AlarmTimeTo,AllDayEvent,LastCheckTime from CF_CONFIG_SERVICE"
            sql += " where ServerIP ='" & ServerIP & "' or ServerName='" & ServerName & "' or MacAddress='" & MacAddress & "'"
            dt = SqlDB.ExecuteTable(sql)

            Return dt
        End Function

        Public Function GetServiceDetail(ServiceID As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,cf_config_service_id,ms_master_service_checklist_id,RepeatCheckQty from CF_CONFIG_SERVICE_DETAIL where cf_config_service_id='" & ServiceID & "'"
            dt = SqlDB.ExecuteTable(sql)
            Return dt
        End Function

    End Class

End Namespace

