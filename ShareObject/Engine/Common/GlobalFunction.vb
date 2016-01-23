Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient
Imports Engine.Common
Imports Engine.LogFile
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE


Public Class GlobalFunction

    Public Shared Function GetConfigDBServerInfo(ConfigName As String) As DbServerInfoENG
        Dim ret As New DbServerInfoENG
        Try
            Dim SysConfig As String = GetSysConfing(ConfigName)
            If SysConfig.Trim <> "" Then
                Dim tmp As String() = Split(SysConfig, "##")
                ret.DbServerIP = tmp(0)
                ret.DbDatabaseName = tmp(1)
                ret.DbUserID = tmp(2)
                ret.DbPassword = LinqDB.ConnectDB.DIPRFIDSqlDB.EnCripPwd(tmp(3))
            End If
        Catch ex As Exception

        End Try

        Return ret
    End Function

    Public Shared Function GetSysConfing(ConfigName As String) As String
        Dim ret As String = ""
        Try
            Dim lnq As New LinqDB.TABLE.CfSysconfigLinqDB
            lnq.ChkDataByCONFIG_NAME(ConfigName, Nothing)

            If lnq.ID > 0 Then
                ret = lnq.CONFIG_VALUE
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = ""
        End Try
        Return ret
    End Function

    Public Shared Function SaveSysconfig(UserName As String, ConfigName As String, ConfigValue As String) As String
        Dim ret As String = ""
        Try
            Dim lnq As New CfSysconfigLinqDB
            lnq.ChkDataByCONFIG_NAME(ConfigName, Nothing)
            If lnq.ID > 0 Then
                lnq.CONFIG_NAME = ConfigValue

                Dim trans As New TransactionDB(SelectDB.DIPRFID)
                If lnq.UpdateByPK(UserName, trans.Trans) = True Then
                    trans.CommitTransaction()
                    ret = "true"
                Else
                    trans.RollbackTransaction()
                    ret = "false|" & lnq.ErrorMessage
                End If
            End If
            lnq = Nothing
        Catch ex As Exception
            ret = "false|Exception " & ex.Message & vbNewLine & ex.StackTrace
        End Try
        Return ret
    End Function

    Public Shared Function GetDataLogin(username As String, password As String) As DataTable
        Try
            Dim EnCripPW As String = Engine.GlobalFunction.GetEncrypt(password)
            Dim dt As DataTable
            Dim strSql As String

            strSql = " select o.id,ti.title_name + '' + o.fname + '  ' + o.lname as fullname ,o.username,"
            strSql &= " rm.ms_floor_id,o.is_change_pwd"
            strSql &= " from tb_officer o"
            strSql &= " inner join tb_title ti on o.title_id = ti.id"
            strSql &= " inner join TB_DEPARTMENT dp on dp.id=o.department_id"
            strSql &= " inner join MS_ROOM rm on rm.id=dp.ms_room_id"
            strSql &= " where username='" & username & "' and password='" & EnCripPW & "'"
            'แสดง Tab เฉพาะ ms_floor_id=4"
            dt = LinqDB.ConnectDB.DIPRFIDSqlDB.ExecuteTable(strSql)
            Return dt
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function
    Public Shared Function GetDatatable(sql As String) As DataTable
        Return DIPRFIDSqlDB.ExecuteTable(sql)
    End Function

    Public Shared Function GetDatatable(sql As String, trans As TransactionDB) As DataTable
        Return DIPRFIDSqlDB.ExecuteTable(sql, trans.Trans)
    End Function

    Public Shared Function ExecuteNonQuery(sql As String, trans As SqlTransaction) As Boolean
        Return DIPRFIDSqlDB.ExecuteNonQuery(sql, trans)
    End Function


    Public Shared Function cStrToDateTime(ByVal StrDate As String, ByVal StrTime As String) As DateTime
        'Convert วันที่จาก yyyy-MM-dd HH:mm:ss เป็น DateTime
        Dim ret As New Date(1, 1, 1)
        Try
            If StrDate.Trim <> "" Then
                Dim vDate() As String = Split(StrDate, "-")
                If StrTime.Trim <> "" Then
                    Dim vTime() As String = Split(StrTime, ":")
                    ret = New Date(vDate(0), vDate(1), vDate(2), vTime(0), vTime(1), vTime(2))
                Else
                    ret = New Date(vDate(0), vDate(1), vDate(2))
                End If
            End If
        Catch ex As Exception
            ret = DateTime.Now
        End Try
        
        Return ret
    End Function

    Public Shared Function cStrToDateTime2(ByVal StrDate As String, ByVal StrTime As String) As DateTime
        'Convert วันที่จาก d/M/yyyy HH:mm:ss เป็น DateTime
        Dim ret As New Date(1, 1, 1)
        If StrDate.Trim <> "" Then
            Dim vDate() As String = Split(StrDate, "/")
            If StrTime.Trim <> "" Then
                Dim vTime() As String = Split(StrTime, ":")
                ret = New Date(vDate(2), vDate(1), vDate(0), vTime(0), vTime(1), vTime(2))
            Else
                ret = New Date(vDate(0), vDate(1), vDate(2))
            End If
        End If
        Return ret
    End Function

    Public Shared Function cStrToDateTime3(ByVal StrDate As String, ByVal StrTime As String) As DateTime
        'Convert วันที่จาก yyyy/MM/dd HH:mm:ss เป็น DateTime
        Dim ret As New Date(1, 1, 1)
        If StrDate.Trim <> "" Then
            Dim vDate() As String = Split(StrDate, "/")
            If StrTime.Trim <> "" Then
                Dim vTime() As String = Split(StrTime, ":")
                ret = New Date(vDate(0), vDate(1), vDate(2), vTime(0), vTime(1), vTime(2))
            Else
                ret = New Date(vDate(0), vDate(1), vDate(2))
            End If
        End If
        Return ret
    End Function

    Public Shared Function GetDateNowFromDB() As DateTime
        Dim ret As DateTime = DateTime.Now
        Try
            Dim sql As String = "select getdate() date_now "
            Dim dt As DataTable = GetDatatable(sql)
            If dt.Rows.Count > 0 Then
                ret = Convert.ToDateTime(dt.Rows(0)("date_now"))
            End If
        Catch ex As Exception
            ret = DateTime.Now
        End Try
        Return ret
    End Function

#Region "Encrypt Decrypt for RFID System"
    Const encryptKey As String = "DiPRfId"
    Private Shared IV() As Byte = {10, 20, 30, 40, 50, 60, 70, 80}
    Public Shared Function GetEncrypt(ByVal text As String) As String
        Dim tdsp As New TripleDESCryptoServiceProvider
        Dim md5csp = New MD5CryptoServiceProvider
        Dim buffer As Byte() = Encoding.ASCII.GetBytes(text)
        tdsp.Key = md5csp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(encryptKey))
        tdsp.IV = IV
        Return Convert.ToBase64String(tdsp.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length))
    End Function
    Public Shared Function GetDecrypt(ByVal text As String) As String
        Dim tdsp As New TripleDESCryptoServiceProvider
        Dim md5csp = New MD5CryptoServiceProvider
        Dim buffer As Byte() = Encoding.ASCII.GetBytes(text)
        buffer = Convert.FromBase64String(text)
        tdsp.Key = md5csp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(encryptKey))
        tdsp.IV = IV
        Return Encoding.ASCII.GetString(tdsp.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))
    End Function

#End Region


End Class


