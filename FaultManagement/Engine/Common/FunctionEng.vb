Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.Management

Namespace Common
    Public Class FunctionEng


        Public Shared Function GetSysConfig(ByVal ParaName As String) As String
            Dim ret As Boolean = False
            Dim trans As New TransactionDB
            Dim lnq As New MsSysconfigLinqDB

            ret = lnq.ChkDataByWhere("config_name = '" & ParaName & "'", trans.Trans)
            trans.CommitTransaction()
            Dim r As String = lnq.CONFIG_VALUE
            lnq = Nothing
            If ret = True Then
                Return r
            Else
                Return ""
            End If
        End Function

        


        Public Shared Function GetMACAddress() As String
            Dim mc As New ManagementClass("Win32_NetworkAdapterConfiguration")
            Dim moc As ManagementObjectCollection = mc.GetInstances()
            Dim MACAddress As String = [String].Empty
            For Each mo As ManagementObject In moc
                If MACAddress = [String].Empty Then
                    If CBool(mo("IPEnabled")) = True Then
                        MACAddress = mo("MacAddress").ToString()
                    End If
                End If
                mo.Dispose()
            Next

            MACAddress = MACAddress.Replace(":", "")
            Return MACAddress
        End Function


        'Public Shared Function SaveTransLog(ByVal ClassName As String, ByVal transDesc As String) As Boolean
        '    Dim ret As Boolean = False
        '    Dim lnq As New LogTransCenLinqDB
        '    Dim trans As New CenLinqDB.Common.Utilities.TransactionDB(True)
        '    lnq.LOGIN_HIS_ID = 0
        '    lnq.TRANS_DESC = transDesc
        '    lnq.TRANS_DATE = DateTime.Now

        '    ret = lnq.InsertData(ClassName, trans.Trans)
        '    If ret = True Then
        '        trans.CommitTransaction()
        '    Else
        '        trans.RollbackTransaction()
        '        SaveErrorLog(ClassName, lnq.ErrorMessage)
        '    End If
        '    lnq = Nothing

        '    Return ret
        'End Function
        'Public Shared Function SaveTransLog(ByVal LoginHisID As Long, ByVal ClassName As String, ByVal transDesc As String) As Boolean
        '    Dim ret As Boolean = False
        '    Dim lnq As New LogTransCenLinqDB
        '    Dim trans As New CenLinqDB.Common.Utilities.TransactionDB(True)
        '    lnq.LOGIN_HIS_ID = LoginHisID
        '    lnq.TRANS_DESC = transDesc
        '    lnq.TRANS_DATE = DateTime.Now

        '    ret = lnq.InsertData(ClassName, trans.Trans)
        '    If ret = True Then
        '        trans.CommitTransaction()
        '    Else
        '        trans.RollbackTransaction()
        '        SaveErrorLog(LoginHisID, ClassName, lnq.ErrorMessage)
        '    End If
        '    lnq = Nothing

        '    Return ret
        'End Function

        'Public Shared Function SaveErrorLog(ByVal ClassName As String, ByVal ErrorDesc As String) As Boolean
        '    Dim ret As Boolean = False
        '    Dim lnq As New LogErrorCenLinqDB
        '    Dim trans As New CenLinqDB.Common.Utilities.TransactionDB(True)
        '    lnq.LOGIN_HIS_ID = 0
        '    lnq.ERROR_DESC = ErrorDesc
        '    lnq.ERROR_TIME = DateTime.Now
        '    ret = lnq.InsertData(ClassName, trans.Trans)
        '    If ret = True Then
        '        trans.CommitTransaction()
        '    Else
        '        trans.RollbackTransaction()
        '    End If
        '    lnq = Nothing

        '    Return ret
        'End Function

        'Public Shared Function SaveErrorLog(ByVal LoginHisID As Long, ByVal ClassName As String, ByVal ErrorDesc As String) As Boolean
        '    Dim ret As Boolean = False
        '    Dim lnq As New LogErrorCenLinqDB
        '    Dim trans As New CenLinqDB.Common.Utilities.TransactionDB(True)
        '    lnq.LOGIN_HIS_ID = LoginHisID
        '    lnq.ERROR_DESC = ErrorDesc
        '    lnq.ERROR_TIME = DateTime.Now
        '    ret = lnq.InsertData(ClassName, trans.Trans)
        '    If ret = True Then
        '        trans.CommitTransaction()
        '    Else
        '        trans.RollbackTransaction()
        '    End If
        '    lnq = Nothing

        '    Return ret
        'End Function

        Public Shared Sub CreateLogFile(ByVal TextMsg As String)
            Try
                Dim LogPath As String = System.Windows.Forms.Application.StartupPath & "\Logs\"
                If IO.Directory.Exists(LogPath) = False Then
                    IO.Directory.CreateDirectory(LogPath)
                End If
                Dim FILE_NAME As String = LogPath & DateTime.Now.ToString("yyyyMMddHH") & ".txt"
                Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
                objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & " " & TextMsg & vbNewLine & vbNewLine)
                objWriter.Close()
            Catch ex As Exception

            End Try
            
        End Sub

        Public Shared Sub CreateErrorLog(ClassName As String, FunctionName As String, ByVal TextMsg As String)
            Try
                Dim LogFolder As String = System.Windows.Forms.Application.StartupPath & "\FaultErrorLog"
                If IO.Directory.Exists(LogFolder) = False Then
                    IO.Directory.CreateDirectory(LogFolder)
                End If
                Dim FILE_NAME As String = LogFolder & "\" & DateTime.Now.ToString("yyyyMMddHH") & ".txt"
                Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
                objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & " " & ClassName & "." & FunctionName & vbNewLine & TextMsg & vbNewLine & vbNewLine)
                objWriter.Close()
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Function cStrToDateTime(ByVal StrDate As String, ByVal StrTime As String) As DateTime 'Convert วันที่จาก yyyy-MM-dd HH:mm:ss เป็น DateTime
            Dim ret As New Date(1, 1, 1)
            If StrDate.Trim <> "" Then
                Dim vDate() As String = Split(StrDate, "-")
                If StrTime.Trim <> "" Then
                    Dim vTime() As String = Split(StrTime, ":")
                    ret = New Date(vDate(0), vDate(1), vDate(2), vTime(0), vTime(1), vTime(2))
                Else
                    ret = New Date(vDate(0), vDate(1), vDate(2))
                End If
            End If
            Return ret
        End Function

        Public Shared Function ExecuteDataTable(ByVal sql As String) As DataTable
            Dim dt As New DataTable
            dt = SqlDB.ExecuteTable(sql)
            Return dt
        End Function

        Public Shared Function ExecuteNonQuery(sql As String) As Boolean
            Dim ret As Boolean = False
            Try
                ret = (SqlDB.ExecuteNonQuery(sql) > 0)
            Catch ex As Exception
                ret = False
            End Try
            Return ret
        End Function
        Public Shared Function GetFaultMngUploadPath() As String
            Dim fldPath As String = System.Configuration.ConfigurationSettings.AppSettings("FaultMngUploadPath").ToString
            If System.IO.Directory.Exists(fldPath) = False Then
                System.IO.Directory.CreateDirectory(fldPath)
            End If
            Return fldPath
        End Function
        Public Shared Function GetFaultMngMonitorPath() As String
            Dim fldPath As String = System.Configuration.ConfigurationSettings.AppSettings("FaultMngMonitorPath").ToString
            If System.IO.Directory.Exists(fldPath) = False Then
                System.IO.Directory.CreateDirectory(fldPath)
            End If
            Return fldPath
        End Function
        Public Shared Function GetFaultMngConfigPath() As String
            Dim fldPath As String = System.Configuration.ConfigurationSettings.AppSettings("FaultMngConfigPath").ToString
            If System.IO.Directory.Exists(fldPath) = False Then
                System.IO.Directory.CreateDirectory(fldPath)
            End If
            Return fldPath
        End Function

    End Class
End Namespace

