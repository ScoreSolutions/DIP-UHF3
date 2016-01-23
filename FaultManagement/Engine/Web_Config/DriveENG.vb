Imports System.Web.Security
Imports System.Data
Imports System.Linq
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace Web_Config


    Public Class DriveENG


        Public Function ddlDriverName(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New TbDriveInfoLinqDB
            Dim trans As New TransactionDB
            Dim sql As String

            If wh <> "" Then
                wh = " and " + wh
            Else
                wh = ""

            End If

            sql = "select id,ServerName ,ServerIP,DriveLetter ,FreeSpaceGB ,TotalSizeGB ,PercentUsage from TB_DRIVE_INFO  where 1=1"
            sql += wh

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function _GetgvDrive(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New TbDriveInfoLinqDB
            Dim trans As New TransactionDB
            Dim sql As String

            If wh <> "" Then
                wh = " and " & wh
            End If

            sql = "select CD.id,CD.ServerIP,CD.ServerName,CD.MacAddress,CD.CheckIntervalMinute,CD.ActiveStatus,TR.id as idRegis from CF_CONFIG_DRIVE CD join TB_REGISTER TR on CD.ServerIP = TR.ServerIP where 1=1"
            sql += wh

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

        Public Function GetgvDrive(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New TbDriveInfoLinqDB
            Dim trans As New TransactionDB
            Dim sql As String

            If wh <> "" Then
                wh = " and " & wh
            End If

            sql = "select cfDDe.cf_config_drive_id ,cfD .ServerName ,cfD.ServerIP ,cfD.MacAddress,cfD .CheckIntervalMinute"
            sql += ",cfDDe.id as idDriveDetail,cfDDe.DriveLetter,cfDDe.AlarmMinorValue,cfDDe.RepeatCheckMinor,cfDDe.AlarmMajorValue,cfDDe.RepeatCheckMajor,cfDDe.AlarmCriticalValue,cfDDe.RepeatCheckCritical "
            sql += "from CF_CONFIG_DRIVE cfD inner join CF_CONFIG_DRIVE_DETAIL cfDDe on cfDDe .cf_config_drive_id =cfD.id where 1=1 "
            sql += wh

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt

        End Function


        Public Function GetIDcfDrive(ByVal wh As String) As String
            Dim id As String
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigDriveLinqDB

            Dim sql As String
            sql = "select id,ServerName ,ServerIP,MacAddress from CF_CONFIG_DRIVE where ServerIP = '" & wh & "'"
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)

            If dt.Rows.Count > 0 Then
                id = dt.Rows(0)(0).ToString()
            Else
                id = 0
            End If

            Return id
        End Function

        Public Function GetidMaxDrive(ByVal wh As String) As String
            Dim dt As New DataTable()
            Dim lnq As New CfConfigDriveLinqDB
            Dim trans As New TransactionDB
            Dim sql As String
            Dim id As String

            sql = "select MAX(id) from CF_CONFIG_DRIVE "
            dt = lnq.GetListBySql(sql, trans.Trans)
            id = dt.Rows(0)(0).ToString


            Return id
        End Function

        Dim _err As String = ""

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err.Trim()
            End Get
        End Property
        Public Function CheckDuplicateRegister(ByVal id As Long, ByVal ServerIP As String, ByVal ServerName As String, ByVal MacAddress As String) As Boolean

            Dim ret As Boolean = False
            Dim lnq As New CfConfigDriveLinqDB
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

        Public Function GetDrive(ServerIP As String, ServerName As String, MacAddress As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,ServerIP,ServerName,CheckIntervalMinute,ActiveStatus,MacAddress,AlarmSun,AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri"
            sql += ",AlarmSat,AlarmTimeFrom,AlarmTimeTo,AllDayEvent,LastCheckTime from CF_CONFIG_DRIVE"
            sql += " where ServerIP ='" & ServerIP & "' or ServerName='" & ServerName & "' or MacAddress='" & MacAddress & "'"
            dt = SqlDB.ExecuteTable(sql)

            Return dt
        End Function

        Public Function GetDriveDetail(DriveID As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,cf_config_drive_id,DriveLetter,AlarmMinorValue,AlarmMajorValue,AlarmCriticalValue,RepeatCheckMinor,"
            sql += " RepeatCheckMajor,RepeatCheckCritical from CF_CONFIG_DRIVE_DETAIL  where cf_config_drive_id ='" & DriveID & "'"
            dt = SqlDB.ExecuteTable(sql)
            Return dt
        End Function

    End Class

End Namespace

