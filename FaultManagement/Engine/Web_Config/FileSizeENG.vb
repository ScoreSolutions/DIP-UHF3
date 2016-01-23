Imports System.Web.Security
Imports System.Data
Imports System.Linq
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace Web_Config
    Public Class FileSizeENG

        Public Function GetidMaxFileSize(ByVal wh As String) As String
            Dim dt As New DataTable()
            Dim lnq As New CfConfigFilesizeLinqDB
            Dim trans As New TransactionDB
            Dim sql As String
            Dim id As String

            sql = "select MAX(id) from CF_CONFIG_FILESIZE "
            dt = lnq.GetListBySql(sql, trans.Trans)
            id = dt.Rows(0)(0).ToString


            Return id
        End Function

        Public Function _FileSize(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New CfConfigFilesizeDetailLinqDB
            Dim trans As New TransactionDB
            Dim sql As String

            If wh <> "" Then
                wh = " and " & wh
            End If

            sql = "select CFD.id,cf.ServerIP,cf.ServerName,cf.MacAddress,cf.CheckIntervalMinute ,CFD.cf_config_filesize_id,CFD.FileName ,cfd.FileSizeMinor,cfd.RepeatCheckMinor,CFD.FileSizeMajor,cfd.RepeatCheckMajor,CFD.FileSizeCritical,cfd.RepeatCheckCritical  from CF_CONFIG_FILESIZE_DETAIL CFD inner join CF_CONFIG_FILESIZE CF on CFD .cf_config_filesize_id = CF.id where 1=1"
            sql += wh

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt

        End Function


        Public Function GetgvFileSize(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim lnq As New CfConfigFilesizeDetailLinqDB
            Dim trans As New TransactionDB
            Dim sql As String

            If wh <> "" Then
                wh = " and " & wh
            End If

            'sql = "select id as cfDETAILid,ServerIP ,ServerName ,MacAddress ,CheckIntervalMinute ,RepeateCheckQty ,ActiveStatus  from CF_CONFIG_FILESIZE where 1=1"
            sql = "select CF.id as cfDETAILid,CF.ServerIP ,CF.ServerName ,CF.MacAddress ,CF.CheckIntervalMinute ,CF.ActiveStatus,TR.id as idRes  from CF_CONFIG_FILESIZE  CF join TB_REGISTER TR on CF.ServerIP = TR.ServerIP where 1=1"
            sql += wh

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt

        End Function


        Public Function GetIDcfFile(ByVal wh As String) As String
            Dim id As String
            Dim trans As New TransactionDB
            Dim lnq As New CfConfigFilesizeLinqDB

            Dim sql As String
            sql = "select id,ServerName ,ServerIP,MacAddress from CF_CONFIG_FILESIZE where ServerIP = '" & wh & "'"
            Dim dt As New DataTable
            dt = lnq.GetListBySql(sql, trans.Trans)

            If dt.Rows.Count > 0 Then
                id = dt.Rows(0)(0).ToString()
            Else
                id = 0
            End If

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
            Dim lnq As New CfConfigFilesizeLinqDB
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

        Public Function GetFileSize(ServerIP As String, ServerName As String, MacAddress As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,ServerIP,ServerName,CheckIntervalMinute,ActiveStatus,MacAddress,AlarmSun,AlarmMon,AlarmTue,AlarmWed,AlarmThu,AlarmFri"
            sql += ",AlarmSat,AlarmTimeFrom,AlarmTimeTo,AllDayEvent,LastCheckTime from CF_CONFIG_FILESIZE"
            sql += " where ServerIP ='" & ServerIP & "' or ServerName='" & ServerName & "' or MacAddress='" & MacAddress & "'"
            dt = SqlDB.ExecuteTable(sql)

            Return dt
        End Function

        Public Function GetFileSizeDetail(FileSizeID As String) As DataTable
            Dim dt As New DataTable
            Dim sql As String = "select id,cf_config_filesize_id,fileName,FileSizeMinor,FileSizeMajor,FileSizeCritical,RepeatCheckMinor,"
            sql += " RepeatCheckMajor,RepeatCheckCritical from CF_CONFIG_FILESIZE_DETAIL  where cf_config_filesize_id='" & FileSizeID & "'"
            dt = SqlDB.ExecuteTable(sql)
            Return dt
        End Function

    End Class

End Namespace

