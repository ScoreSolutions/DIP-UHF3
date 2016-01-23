Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.ConnectDB.DIPRFIDSqlDB
Imports LinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TS_LOGIN_HISTORY table LinqDB.
    '[Create by  on January, 15 2015]
    Public Class TsLoginHistoryLinqDB
        Public sub TsLoginHistoryLinqDB()

        End Sub 
        ' TS_LOGIN_HISTORY
        Const _tableName As String = "TS_LOGIN_HISTORY"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATED_BY As String = ""
        Dim _CREATED_DATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATED_BY As  String  = ""
        Dim _UPDATED_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USERNAME As String = ""
        Dim _OFFICER_NAME As String = ""
        Dim _OFFICER_POSITION_NAME As  String  = ""
        Dim _OFFICER_DEPARTMENT_NAME As  String  = ""
        Dim _LOGIN_TIME As DateTime = New DateTime(1,1,1)
        Dim _LOGOUT_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CLIENT_IP As String = ""
        Dim _SESSION_ID As String = ""
        Dim _BROWSER_NAME As String = ""
        Dim _SERVER_URL As String = ""

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATED_BY", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_BY() As String
            Get
                Return _CREATED_BY
            End Get
            Set(ByVal value As String)
               _CREATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATED_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATED_DATE() As DateTime
            Get
                Return _CREATED_DATE
            End Get
            Set(ByVal value As DateTime)
               _CREATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_BY", DbType:="VarChar(100)")>  _
        Public Property UPDATED_BY() As  String 
            Get
                Return _UPDATED_BY
            End Get
            Set(ByVal value As  String )
               _UPDATED_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATED_DATE", DbType:="DateTime")>  _
        Public Property UPDATED_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATED_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATED_DATE = value
            End Set
        End Property 
        <Column(Storage:="_USERNAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
               _USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property OFFICER_NAME() As String
            Get
                Return _OFFICER_NAME
            End Get
            Set(ByVal value As String)
               _OFFICER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_POSITION_NAME", DbType:="VarChar(255)")>  _
        Public Property OFFICER_POSITION_NAME() As  String 
            Get
                Return _OFFICER_POSITION_NAME
            End Get
            Set(ByVal value As  String )
               _OFFICER_POSITION_NAME = value
            End Set
        End Property 
        <Column(Storage:="_OFFICER_DEPARTMENT_NAME", DbType:="VarChar(255)")>  _
        Public Property OFFICER_DEPARTMENT_NAME() As  String 
            Get
                Return _OFFICER_DEPARTMENT_NAME
            End Get
            Set(ByVal value As  String )
               _OFFICER_DEPARTMENT_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LOGIN_TIME", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property LOGIN_TIME() As DateTime
            Get
                Return _LOGIN_TIME
            End Get
            Set(ByVal value As DateTime)
               _LOGIN_TIME = value
            End Set
        End Property 
        <Column(Storage:="_LOGOUT_TIME", DbType:="DateTime")>  _
        Public Property LOGOUT_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _LOGOUT_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _LOGOUT_TIME = value
            End Set
        End Property 
        <Column(Storage:="_CLIENT_IP", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property CLIENT_IP() As String
            Get
                Return _CLIENT_IP
            End Get
            Set(ByVal value As String)
               _CLIENT_IP = value
            End Set
        End Property 
        <Column(Storage:="_SESSION_ID", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SESSION_ID() As String
            Get
                Return _SESSION_ID
            End Get
            Set(ByVal value As String)
               _SESSION_ID = value
            End Set
        End Property 
        <Column(Storage:="_BROWSER_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property BROWSER_NAME() As String
            Get
                Return _BROWSER_NAME
            End Get
            Set(ByVal value As String)
               _BROWSER_NAME = value
            End Set
        End Property 
        <Column(Storage:="_SERVER_URL", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property SERVER_URL() As String
            Get
                Return _SERVER_URL
            End Get
            Set(ByVal value As String)
               _SERVER_URL = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATED_BY = ""
            _CREATED_DATE = New DateTime(1,1,1)
            _UPDATED_BY = ""
            _UPDATED_DATE = New DateTime(1,1,1)
            _USERNAME = ""
            _OFFICER_NAME = ""
            _OFFICER_POSITION_NAME = ""
            _OFFICER_DEPARTMENT_NAME = ""
            _LOGIN_TIME = New DateTime(1,1,1)
            _LOGOUT_TIME = New DateTime(1,1,1)
            _CLIENT_IP = ""
            _SESSION_ID = ""
            _BROWSER_NAME = ""
            _SERVER_URL = ""
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(Sql As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql, trans)
        End Function


        '/// Returns an indication whether the current data is inserted into TS_LOGIN_HISTORY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _Created_By = LoginName
                _Created_date = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TS_LOGIN_HISTORY table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _Updated_By = LoginName
                _Updated_Date = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TS_LOGIN_HISTORY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return (DB.ExecuteNonQuery(Sql, trans) > -1)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TS_LOGIN_HISTORY table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cID As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("ID = " & DB.SetDouble(cID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of TS_LOGIN_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TS_LOGIN_HISTORY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TsLoginHistoryLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TS_LOGIN_HISTORY by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByUSERNAME(cUSERNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TS_LOGIN_HISTORY by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByUSERNAME(cUSERNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_LOGIN_HISTORY by specified LOGIN_TIME key is retrieved successfully.
        '/// <param name=cLOGIN_TIME>The LOGIN_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByLOGIN_TIME(cLOGIN_TIME As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("LOGIN_TIME = " & DB.SetDateTime(cLOGIN_TIME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TS_LOGIN_HISTORY by specified LOGIN_TIME key is retrieved successfully.
        '/// <param name=cLOGIN_TIME>The LOGIN_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByLOGIN_TIME(cLOGIN_TIME As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("LOGIN_TIME = " & DB.SetDateTime(cLOGIN_TIME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_LOGIN_HISTORY by specified CLIENT_IP key is retrieved successfully.
        '/// <param name=cCLIENT_IP>The CLIENT_IP key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByCLIENT_IP(cCLIENT_IP As String, trans As SQLTransaction) As Boolean
            Return doChkData("CLIENT_IP = " & DB.SetString(cCLIENT_IP) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TS_LOGIN_HISTORY by specified CLIENT_IP key is retrieved successfully.
        '/// <param name=cCLIENT_IP>The CLIENT_IP key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByCLIENT_IP(cCLIENT_IP As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("CLIENT_IP = " & DB.SetString(cCLIENT_IP) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TS_LOGIN_HISTORY table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    Dim dt as DataTable = DB.ExecuteTable(SqlInsert, trans, SetParameterData())
                    If dt.Rows.Count = 0 Then
                        _error = DB.ErrorMessage
                        ret = False
                    Else
                        _ID = dt.Rows(0)("ID")
                        _haveData = True
                        ret = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = false
                    _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlInsert
                Catch ex As Exception
                    ret = False
                    _error = MessageResources.MSGEC101 & " Exception :" & ex.ToString() & "### SQL: " & SqlInsert
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002 & "### SQL: " & SqlInsert
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to TS_LOGIN_HISTORY table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> ""
                    Try
                        ret = DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans, SetParameterData())
                        If ret = False Then
                            _error = DB.ErrorMessage
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlUpdate & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC102 & " Exception :" & ex.ToString() & "### SQL: " & SqlUpdate & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003 & "### SQL: " & SqlUpdate & tmpWhere
                End If
            Else
                ret = True
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from TS_LOGIN_HISTORY table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > -1)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlDelete & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC103 & " Exception :" & ex.ToString() & "### SQL: " & SqlDelete & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003 & "### SQL: " & SqlDelete & tmpWhere
                End If
            Else
                ret = True
            End If

            Return ret
        End Function

        Private Function SetParameterData() As SqlParameter()
            Dim cmbParam(14) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_CREATED_BY", SqlDbType.VarChar)
            cmbParam(1).Value = _CREATED_BY

            cmbParam(2) = New SqlParameter("@_CREATED_DATE", SqlDbType.DateTime)
            cmbParam(2).Value = _CREATED_DATE

            cmbParam(3) = New SqlParameter("@_UPDATED_BY", SqlDbType.VarChar)
            If _UPDATED_BY.Trim <> "" Then 
                cmbParam(3).Value = _UPDATED_BY
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_UPDATED_DATE", SqlDbType.DateTime)
            If _UPDATED_DATE.Value.Year > 1 Then 
                cmbParam(4).Value = _UPDATED_DATE.Value
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_USERNAME", SqlDbType.VarChar)
            cmbParam(5).Value = _USERNAME

            cmbParam(6) = New SqlParameter("@_OFFICER_NAME", SqlDbType.VarChar)
            cmbParam(6).Value = _OFFICER_NAME

            cmbParam(7) = New SqlParameter("@_OFFICER_POSITION_NAME", SqlDbType.VarChar)
            If _OFFICER_POSITION_NAME.Trim <> "" Then 
                cmbParam(7).Value = _OFFICER_POSITION_NAME
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_OFFICER_DEPARTMENT_NAME", SqlDbType.VarChar)
            If _OFFICER_DEPARTMENT_NAME.Trim <> "" Then 
                cmbParam(8).Value = _OFFICER_DEPARTMENT_NAME
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_LOGIN_TIME", SqlDbType.DateTime)
            cmbParam(9).Value = _LOGIN_TIME

            cmbParam(10) = New SqlParameter("@_LOGOUT_TIME", SqlDbType.DateTime)
            If _LOGOUT_TIME.Value.Year > 1 Then 
                cmbParam(10).Value = _LOGOUT_TIME.Value
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_CLIENT_IP", SqlDbType.VarChar)
            cmbParam(11).Value = _CLIENT_IP

            cmbParam(12) = New SqlParameter("@_SESSION_ID", SqlDbType.VarChar)
            cmbParam(12).Value = _SESSION_ID

            cmbParam(13) = New SqlParameter("@_BROWSER_NAME", SqlDbType.VarChar)
            cmbParam(13).Value = _BROWSER_NAME

            cmbParam(14) = New SqlParameter("@_SERVER_URL", SqlDbType.VarChar)
            cmbParam(14).Value = _SERVER_URL

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TS_LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " WHERE " & whText
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("officer_name")) = False Then _officer_name = Rdr("officer_name").ToString()
                        If Convert.IsDBNull(Rdr("officer_position_name")) = False Then _officer_position_name = Rdr("officer_position_name").ToString()
                        If Convert.IsDBNull(Rdr("officer_department_name")) = False Then _officer_department_name = Rdr("officer_department_name").ToString()
                        If Convert.IsDBNull(Rdr("login_time")) = False Then _login_time = Convert.ToDateTime(Rdr("login_time"))
                        If Convert.IsDBNull(Rdr("logout_time")) = False Then _logout_time = Convert.ToDateTime(Rdr("logout_time"))
                        If Convert.IsDBNull(Rdr("client_ip")) = False Then _client_ip = Rdr("client_ip").ToString()
                        If Convert.IsDBNull(Rdr("session_id")) = False Then _session_id = Rdr("session_id").ToString()
                        If Convert.IsDBNull(Rdr("browser_name")) = False Then _browser_name = Rdr("browser_name").ToString()
                        If Convert.IsDBNull(Rdr("server_url")) = False Then _server_url = Rdr("server_url").ToString()
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TS_LOGIN_HISTORY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TsLoginHistoryLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("created_by")) = False Then _created_by = Rdr("created_by").ToString()
                        If Convert.IsDBNull(Rdr("created_date")) = False Then _created_date = Convert.ToDateTime(Rdr("created_date"))
                        If Convert.IsDBNull(Rdr("updated_by")) = False Then _updated_by = Rdr("updated_by").ToString()
                        If Convert.IsDBNull(Rdr("updated_date")) = False Then _updated_date = Convert.ToDateTime(Rdr("updated_date"))
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("officer_name")) = False Then _officer_name = Rdr("officer_name").ToString()
                        If Convert.IsDBNull(Rdr("officer_position_name")) = False Then _officer_position_name = Rdr("officer_position_name").ToString()
                        If Convert.IsDBNull(Rdr("officer_department_name")) = False Then _officer_department_name = Rdr("officer_department_name").ToString()
                        If Convert.IsDBNull(Rdr("login_time")) = False Then _login_time = Convert.ToDateTime(Rdr("login_time"))
                        If Convert.IsDBNull(Rdr("logout_time")) = False Then _logout_time = Convert.ToDateTime(Rdr("logout_time"))
                        If Convert.IsDBNull(Rdr("client_ip")) = False Then _client_ip = Rdr("client_ip").ToString()
                        If Convert.IsDBNull(Rdr("session_id")) = False Then _session_id = Rdr("session_id").ToString()
                        If Convert.IsDBNull(Rdr("browser_name")) = False Then _browser_name = Rdr("browser_name").ToString()
                        If Convert.IsDBNull(Rdr("server_url")) = False Then _server_url = Rdr("server_url").ToString()
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function



        ' SQL Statements


        'Get Insert Statement for table TS_LOGIN_HISTORY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, USERNAME, OFFICER_NAME, OFFICER_POSITION_NAME, OFFICER_DEPARTMENT_NAME, LOGIN_TIME, LOGOUT_TIME, CLIENT_IP, SESSION_ID, BROWSER_NAME, SERVER_URL)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATED_BY, INSERTED.CREATED_DATE, INSERTED.UPDATED_BY, INSERTED.UPDATED_DATE, INSERTED.USERNAME, INSERTED.OFFICER_NAME, INSERTED.OFFICER_POSITION_NAME, INSERTED.OFFICER_DEPARTMENT_NAME, INSERTED.LOGIN_TIME, INSERTED.LOGOUT_TIME, INSERTED.CLIENT_IP, INSERTED.SESSION_ID, INSERTED.BROWSER_NAME, INSERTED.SERVER_URL
                Sql += " VALUES("
                sql += "@_CREATED_BY" & ", "
                sql += "@_CREATED_DATE" & ", "
                sql += "@_UPDATED_BY" & ", "
                sql += "@_UPDATED_DATE" & ", "
                sql += "@_USERNAME" & ", "
                sql += "@_OFFICER_NAME" & ", "
                sql += "@_OFFICER_POSITION_NAME" & ", "
                sql += "@_OFFICER_DEPARTMENT_NAME" & ", "
                sql += "@_LOGIN_TIME" & ", "
                sql += "@_LOGOUT_TIME" & ", "
                sql += "@_CLIENT_IP" & ", "
                sql += "@_SESSION_ID" & ", "
                sql += "@_BROWSER_NAME" & ", "
                sql += "@_SERVER_URL"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TS_LOGIN_HISTORY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATED_BY = " & "@_CREATED_BY" & ", "
                Sql += "CREATED_DATE = " & "@_CREATED_DATE" & ", "
                Sql += "UPDATED_BY = " & "@_UPDATED_BY" & ", "
                Sql += "UPDATED_DATE = " & "@_UPDATED_DATE" & ", "
                Sql += "USERNAME = " & "@_USERNAME" & ", "
                Sql += "OFFICER_NAME = " & "@_OFFICER_NAME" & ", "
                Sql += "OFFICER_POSITION_NAME = " & "@_OFFICER_POSITION_NAME" & ", "
                Sql += "OFFICER_DEPARTMENT_NAME = " & "@_OFFICER_DEPARTMENT_NAME" & ", "
                Sql += "LOGIN_TIME = " & "@_LOGIN_TIME" & ", "
                Sql += "LOGOUT_TIME = " & "@_LOGOUT_TIME" & ", "
                Sql += "CLIENT_IP = " & "@_CLIENT_IP" & ", "
                Sql += "SESSION_ID = " & "@_SESSION_ID" & ", "
                Sql += "BROWSER_NAME = " & "@_BROWSER_NAME" & ", "
                Sql += "SERVER_URL = " & "@_SERVER_URL" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TS_LOGIN_HISTORY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TS_LOGIN_HISTORY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATED_BY, CREATED_DATE, UPDATED_BY, UPDATED_DATE, USERNAME, OFFICER_NAME, OFFICER_POSITION_NAME, OFFICER_DEPARTMENT_NAME, LOGIN_TIME, LOGOUT_TIME, CLIENT_IP, SESSION_ID, BROWSER_NAME, SERVER_URL FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
