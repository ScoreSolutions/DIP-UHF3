Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.Windows.Forms
Imports System.Web
Namespace LogFile
    Public Class LogENG

        Public Shared Function Logout(userName As String, LogHistoryID As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Try
                Dim lnq As New TsLoginHistoryLinqDB
                lnq.GetDataByPK(LogHistoryID, trans.Trans)
                lnq.LOGOUT_TIME = DateTime.Now
                If lnq.ID > 0 Then
                    ret = lnq.UpdateByPK(userName, trans.Trans)
                End If
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Catch ex As Exception
                trans.RollbackTransaction()
            End Try

            Return ret
        End Function

        Public Shared Sub CreateErrogLogFile(ByVal TxtLog As String)
            Dim LogFolder As String = Application.StartupPath & "\ErrorLog\" & DateTime.Now.ToString("yyyyMM") & "\"
            If IO.Directory.Exists(LogFolder) = False Then
                IO.Directory.CreateDirectory(LogFolder)
            End If

            Dim FileName As String = "ErrorLog_" & DateTime.Now.ToString("yyyyMMdd_HH") & ".log"
            Dim objWriter As New System.IO.StreamWriter(LogFolder & FileName, True)
            objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & vbNewLine & TxtLog & vbNewLine)
            objWriter.Close()
        End Sub

        Public Shared Sub CreateTransLogFile(ByVal TxtLog As String)
            Dim LogFolder As String = Application.StartupPath & "\TransLog\" & DateTime.Now.ToString("yyyyMM") & "\"
            If IO.Directory.Exists(LogFolder) = False Then
                IO.Directory.CreateDirectory(LogFolder)
            End If

            Dim FileName As String = "TransLog_" & DateTime.Now.ToString("yyyyMMdd_HH") & ".log"
            Dim objWriter As New System.IO.StreamWriter(LogFolder & FileName, True)
            objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & vbNewLine & TxtLog & vbNewLine)
            objWriter.Close()
        End Sub

        Public Shared Sub CreateLogFile(LogFolder As String, FileName As String, ByVal TxtLog As String)
            'Dim  As String = Application.StartupPath & "\TransLog\" & DateTime.Now.ToString("yyyyMM") & "\"
            If IO.Directory.Exists(LogFolder) = False Then
                IO.Directory.CreateDirectory(LogFolder)
            End If

            'Dim FileName As String = "TransLog_" & DateTime.Now.ToString("yyyyMMdd_HH") & ".log"
            Dim objWriter As New System.IO.StreamWriter(LogFolder & "\" & FileName, True)
            objWriter.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") & "   " & TxtLog & vbNewLine)
            objWriter.Close()
        End Sub

        Protected Shared Function SaveUserActivityLog(LogInHistoryID As Long, UserName As String, LogDesc As String, Request As HttpRequest, trans As TransactionDB) As Long
            Dim ret As Long = 0
            Try
                Dim lnq As New TsLogUserActivityLinqDB
                lnq.TS_LOGIN_HISTORY_ID = LogInHistoryID
                lnq.LOG_TIME = DateTime.Now
                lnq.LOG_PAGE_NAME = Request.Url.AbsoluteUri
                lnq.LOG_DESC = LogDesc

                If lnq.InsertData(UserName, trans.Trans) = True Then
                    ret = lnq.ID
                Else
                    ret = 0
                    SaveErrLog(UserName, LogInHistoryID, LogDesc & " " & lnq.ErrorMessage, trans)
                End If
            Catch ex As Exception
                SaveErrLog(UserName, LogInHistoryID, "Exception : " & LogDesc & " " & ex.Message & vbNewLine & ex.StackTrace, trans)
            End Try
            Return ret
        End Function

        Public Shared Function SaveErrLog(ByVal UserName As String, ByVal ErrMessage As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False
            Try
                ret = SaveErrLog(UserName, 0, ErrMessage, trans)
                'If ret = True Then
                '    trans.CommitTransaction()
                'Else
                '    trans.RollbackTransaction()
                'End If
            Catch ex As Exception
                ret = False
                CreateErrogLogFile(ErrMessage)
            End Try

            Return ret
        End Function

        Public Shared Function SaveErrLog(ByVal UserName As String, ByVal ErrMessage As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Try
                ret = SaveErrLog(UserName, ErrMessage, trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Catch ex As Exception
                ret = False
                trans.RollbackTransaction()
                CreateErrogLogFile(ErrMessage)
            End Try

            Return ret
        End Function

        Public Shared Function SaveErrLog(ByVal UserName As String, ByVal LoginHisID As Long, ByVal ErrMessage As String) As Boolean
            Dim ret As Boolean = False
            Dim trans As New TransactionDB(SelectDB.DIPRFID)
            Try
                ret = SaveErrLog(UserName, LoginHisID, ErrMessage, trans)
                If ret = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
            Catch ex As Exception
                ret = False
                trans.RollbackTransaction()
                CreateErrogLogFile(ErrMessage)
            End Try

            Return ret
        End Function

        Public Shared Function SaveErrLog(ByVal UserName As String, ByVal LoginHisID As Long, ByVal ErrMessage As String, ByVal trans As TransactionDB) As Boolean
            Dim ret As Boolean = False
            Try
                Dim lnq As New TsLogErrorActivityLinqDB
                lnq.TS_LOGIN_HISTORY_ID = LoginHisID
                lnq.ERROR_TIME = DateTime.Now
                lnq.ERROR_DESC = ErrMessage
                ret = lnq.InsertData(UserName, trans.Trans)
                If ret = False Then
                    CreateErrogLogFile(ErrMessage)
                End If
                lnq = Nothing
            Catch ex As Exception
                ret = False
                CreateErrogLogFile(ErrMessage)
            End Try

            Return ret
        End Function

        Public Shared Sub SaveTransLog(ClassName As String, FuncationName As String, LogDesc As String)
            Try
                Dim lnq As New TsLogTransLinqDB
                lnq.LOG_TIME = GlobalFunction.GetDateNowFromDB()
                lnq.LOG_DESC = LogDesc

                Dim trans As New TransactionDB(SelectDB.DIPRFID)
                If lnq.InsertData(ClassName & "." & FuncationName, trans.Trans) = True Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                End If
                lnq = Nothing

            Catch ex As Exception
                SaveErrLog(ClassName & "." & FuncationName, "Exception : " & ex.Message & ex.StackTrace)
            End Try
        End Sub
    End Class


End Namespace