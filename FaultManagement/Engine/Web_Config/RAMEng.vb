Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Data
Imports System.Linq
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace Web_Config
    Public Class RAMEng
          

        'ฟังค์ชันดึงค่าไอดีในตาราง Config RAM
        Public Function GetIDcfRAM(ByVal wh As String) As String
            Dim id As String
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigRamLinqDB

            Dim sql As String
            sql = "select id,ServerName ,ServerIP,MacAddress  from CF_CONFIG_RAM where ServerIP = '" & wh & "'"
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)

            If dt.Rows.Count > 0 Then
                id = dt.Rows(0)(0).ToString()
            Else
                id = 0
            End If

            Return id
        End Function

        Public Function GetgvRAM(ByRef wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigRamLinqDB

            Dim sql As String

            If wh <> "" Then
                wh = "and " & wh
            End If

            sql = "select TR.id,TR.ServerIP,TR.ServerName,TR.MacAddress,TR.group_id,TG.group_code,TG.group_desc,CR.CheckIntervalMinute"
            sql += ",CR.AlarmMinorValue,CR.RepeatCheckMinor,CR.AlarmMajorValue,CR.RepeatCheckMajor,CR.AlarmCriticalValue,CR.RepeatCheckCritical,CR.ActiveStatus"
            sql += ",CR.id as idcfRAM from TB_REGISTER TR inner join TB_GROUP TG on TR.group_id = TG.id inner join CF_CONFIG_RAM CR "
            sql += "on TR.ServerIP = CR.ServerIP where 1=1 "
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetddlGroup(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbGroupLinqDB
            Dim sql As String
            sql = "select id,group_code ,group_desc from TB_GROUP where id != '0'"

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt
        End Function

        Public Function GetgvByGroup(ByRef wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbGroupLinqDB

            Dim sql As String

            If wh <> "" Then
                wh = "and " & wh
            End If

            sql = "select id,group_code ,group_desc ,active_status  from TB_GROUP where 1=1 " & wh

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()


            Return dt
        End Function


        Public Function gvByGroup(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbGroupLinqDB

            If wh <> "" Then
                wh = "and " + wh
            End If

            Dim sql As String
            sql = "select tg.id as group_id,TG.group_code ,TG.group_desc ,tr.id,TR.ServerName ,TR.ServerIP ,TR.MacAddress from TB_GROUP TG left join TB_REGISTER TR on TG .id = tr.group_id where 1=1 " + wh

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()

            Return dt

        End Function

        Public Function gvByServerName(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB

            If wh <> "" Then
                wh = " and " + wh
            End If

            Dim sql As String
            sql = "select id,ServerIP as  HostIP,ServerName ,MacAddress  from TB_REGISTER where 1=1"
            sql += wh
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function




        Public Function SetgvGroup(ByVal wh As String, ByVal group As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = "select TG.group_desc ,Count(TR.id) as Qty from TB_GROUP TG  "
            sql += "left join TB_REGISTER TR on TG.id = tr.group_id where 1=1 and group_desc != 'nogroup'" + wh + group
            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function


        Public Function SetgvGrouByName(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbRegisterLinqDB
            If wh <> "" Then
                wh = " and " + wh
            End If
            Dim sql As String
            sql = "select TG.id, TG.group_desc,TR.id as Serverid,TR.ServerIP ,TR.MacAddress,TR.ServerName"
            sql += " from TB_GROUP TG left join TB_REGISTER TR on TG.id = tr.group_id where 1=1" + wh
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
            Dim lnq As New CfConfigRamLinqDB
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

        Public Function GetRam(ServerIP As String, ServerName As String, MacAddress As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,ServerIP,ServerName,CheckIntervalMinute,AlarmMinorValue,AlarmMajorValue,AlarmCriticalValue,ActiveStatus"
            sql += ",MacAddress,RepeatCheckMinor,RepeatCheckMajor,RepeatCheckCritical,AlarmSun,AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri"
            sql += ",AlarmSat,AlarmTimeFrom,AlarmTimeTo,AllDayEvent,LastCheckTime from CF_CONFIG_RAM "
            sql += " where ServerIP ='" & ServerIP & "' or ServerName='" & ServerName & "' or MacAddress='" & MacAddress & "'"
            dt = SqlDB.ExecuteTable(sql)

            Return dt
        End Function

    End Class

End Namespace
