Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Data
Imports System.Linq
Imports LinqDB.ConnectDB
Imports LinqDB.TABLE

Namespace Web_Config


    Public Class LoginENG
        Dim _loginpara As New LinqDB.ConnectDB.LoginSession()
        Dim _uData As New LinqDB.TABLE.TbUserLinqDB
        Dim _err As String = ""

        Public ReadOnly Property GetLoginSession() As LoginSession
            Get
                Return _loginpara
            End Get
        End Property

        Public ReadOnly Property uData() As LinqDB.TABLE.TbUserLinqDB
            Get
                Return _uData
            End Get
        End Property

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return _err
            End Get
        End Property

        Public Function CheckUserProfile(ByVal UserName As String, ByVal PassWD As String, req As HttpRequest) As Boolean
            Dim ret As Boolean = False
            Dim trans As New TransactionDB


            If trans.Trans IsNot Nothing Then
                Dim lnq As New TbUserLinqDB

                If lnq.ChkDataByWhere("UserName ='" & UserName & "'", trans.Trans) = True Then
                    If lnq.PASSWORD = LinqDB.ConnectDB.SqlDB.EnCripPwd(PassWD) Then
                        _loginpara.USERNAME = UserName
                        _loginpara.FIRST_NAME = lnq.FIRSTNAME
                        _loginpara.LAST_NAME = lnq.LASTNAME
                        _loginpara.LOGIN_HISTORY_ID = SaveWebLoginHistory(lnq, req)

                        _uData = lnq

                        Dim sess = System.Web.HttpContext.Current.Session
                        sess(LinqDB.ConnectDB.Constant.UserProfileSession) = _loginpara

                        ret = True
                    Else
                        _err = "Invalid Password"
                    End If
                End If
                trans.CommitTransaction()
                lnq = Nothing
            Else
                _err = trans.ErrorMessage
                ret = False
            End If

            Return ret
        End Function


        Public Function SaveWebLoginHistory(uLnq As LinqDB.TABLE.TbUserLinqDB, req As HttpRequest) As Long
            Dim ret As Long = 0
            Dim trans As New TransactionDB

            Try

                Dim lnq As New LinqDB.TABLE.TsLoginHistoryLinqDB()

                lnq.USERNAME = uLnq.USERNAME
                lnq.FIRST_NAME = uLnq.FIRSTNAME
                lnq.LAST_NAME = uLnq.LASTNAME
                lnq.LOGIN_TIME = DateTime.Now

                Dim browser As String = ((" Type:" + req.Browser.Type & " Version:") + req.Browser.Version & " Browser:") + req.Browser.Browser
                lnq.IP_ADDRESS = req.UserHostAddress
                lnq.BROWSER = browser
                lnq.SERVER_URL = req.Url.AbsoluteUri

                Dim re As New Boolean
                re = lnq.InsertData(uLnq.USERNAME, trans.Trans)
                If re = True Then
                    trans.CommitTransaction()
                    ret = lnq.ID
                Else
                    trans.RollbackTransaction()
                    _err = lnq.ErrorMessage
                End If
                lnq = Nothing
            Catch ex As Exception
                trans.RollbackTransaction()
                _err = ex.Message

            End Try

            Return ret

        End Function

        Public Sub Logout(ByVal LoginHistoryID As Long)
            Dim trans As New TransactionDB
            Dim lnq As New LinqDB.TABLE.TsLoginHistoryLinqDB
            lnq.GetDataByPK(LoginHistoryID, trans.Trans)
            lnq.LOGOUT_TIME = DateTime.Now
            lnq.UpdateByPK(lnq.USERNAME, trans.Trans)
            trans.CommitTransaction()
            _loginpara = New LinqDB.ConnectDB.LoginSession


        End Sub
        Public Function Testgv(ByVal wh As String) As DataTable
            Dim dt As New DataTable
            Dim trans As New TransactionDB
            Dim lnq As New TbUserLinqDB

            If wh <> "" Then
                wh = "and" + wh
            End If

            Dim sql As String
            sql = "select id,UserName ,FirstName ,LastName ,nickname  from TB_USER "
            sql += "where 1=1 " & wh

            dt = lnq.GetListBySql(sql, trans.Trans)
            trans.CommitTransaction()
            Return dt
        End Function

      
    End Class
End Namespace



