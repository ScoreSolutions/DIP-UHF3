Imports LinqDB.ConnectDB
Imports LinqDB.TABLE
Imports System.Web

Namespace LogFile
    Public Class WebLogENG : Inherits LogENG
        Public Shared Function SaveLoginHistory(UserName As String, Request As HttpRequest) As Long
            Dim ret As Long = 0
            Try
                Dim sql As String = "select  u.fname + ' ' + u.lname officer_name, p.position_name, d.department_name,is_change_pwd"
                sql += " from tb_officer u"
                sql += " inner join tb_position p on p.id=u.position_id"
                sql += " inner join tb_department d on d.id=u.department_id"
                sql += " where u.username = '" & UserName & "'"
                Dim dt As New DataTable
                Dim uLnq As New TbOfficerLinqDB
                dt = uLnq.GetListBySql(sql, Nothing)
                If dt.Rows.Count > 0 Then
                    Dim trans As New TransactionDB(SelectDB.DIPRFID)
                    Dim lnq As New TsLoginHistoryLinqDB
                    lnq.USERNAME = UserName
                    If Convert.IsDBNull(dt.Rows(0)("officer_name")) = False Then lnq.OFFICER_NAME = dt.Rows(0)("officer_name")
                    lnq.OFFICER_POSITION_NAME = dt.Rows(0)("position_name")
                    lnq.OFFICER_DEPARTMENT_NAME = dt.Rows(0)("department_name")
                    lnq.LOGIN_TIME = DateTime.Now
                    lnq.CLIENT_IP = Request.UserHostAddress  'Get Client IP Address
                    lnq.SESSION_ID = HttpContext.Current.Session.SessionID

                    Dim BrowserName As String = " Type:" + Request.Browser.Type + " Version:" + Request.Browser.Version + " Browser:" + Request.Browser.Browser
                    lnq.BROWSER_NAME = BrowserName
                    lnq.SERVER_URL = Request.Url.AbsoluteUri

                    If lnq.InsertData(UserName, trans.Trans) = True Then
                        trans.CommitTransaction()
                        ret = lnq.ID
                    Else
                        trans.RollbackTransaction()
                    End If
                    lnq = Nothing
                Else
                    If uLnq.ErrorMessage.Trim <> "" Then
                        SaveErrLog(UserName, uLnq.ErrorMessage)
                    End If
                End If
                uLnq = Nothing
            Catch ex As Exception
                SaveErrLog(UserName, ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Return ret
        End Function



#Region "Save Log From WebPage"
        Public Overloads Shared Function SaveUserActivityLog(LogInHistoryID As Long, UserName As String, LogDesc As String, Request As HttpRequest) As Long
            Dim ret As Long = 0
            Try
                Dim trans As New TransactionDB(SelectDB.DIPRFID)

                ret = SaveUserActivityLog(LogInHistoryID, UserName, LogDesc, Request, trans)
                If ret > 0 Then
                    trans.CommitTransaction()
                Else
                    trans.RollbackTransaction()
                    ret = 0
                End If
            Catch ex As Exception
                SaveErrLog(UserName, LogInHistoryID, ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Return ret
        End Function

        

        
#End Region

    End Class
End Namespace

