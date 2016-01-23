Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.ConnectDB.SQLDB
Imports LinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TS_LOGIN_HISTORY table LinqDB.
    '[Create by  on October, 13 2014]
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
        Dim _CREATEDBY As String = ""
        Dim _CREATEDDATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATEDBY As  String  = ""
        Dim _UPDATEDDATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _USERNAME As String = ""
        Dim _FIRST_NAME As String = ""
        Dim _LAST_NAME As String = ""
        Dim _LOGIN_TIME As DateTime = New DateTime(1,1,1)
        Dim _LOGOUT_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _IP_ADDRESS As String = ""
        Dim _BROWSER As  String  = ""
        Dim _SERVER_URL As  String  = ""

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
        <Column(Storage:="_CREATEDBY", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATEDBY() As String
            Get
                Return _CREATEDBY
            End Get
            Set(ByVal value As String)
               _CREATEDBY = value
            End Set
        End Property 
        <Column(Storage:="_CREATEDDATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATEDDATE() As DateTime
            Get
                Return _CREATEDDATE
            End Get
            Set(ByVal value As DateTime)
               _CREATEDDATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATEDBY", DbType:="VarChar(100)")>  _
        Public Property UPDATEDBY() As  String 
            Get
                Return _UPDATEDBY
            End Get
            Set(ByVal value As  String )
               _UPDATEDBY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATEDDATE", DbType:="DateTime")>  _
        Public Property UPDATEDDATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATEDDATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATEDDATE = value
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
        <Column(Storage:="_FIRST_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property FIRST_NAME() As String
            Get
                Return _FIRST_NAME
            End Get
            Set(ByVal value As String)
               _FIRST_NAME = value
            End Set
        End Property 
        <Column(Storage:="_LAST_NAME", DbType:="VarChar(255) NOT NULL ",CanBeNull:=false)>  _
        Public Property LAST_NAME() As String
            Get
                Return _LAST_NAME
            End Get
            Set(ByVal value As String)
               _LAST_NAME = value
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
        <Column(Storage:="_IP_ADDRESS", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property IP_ADDRESS() As String
            Get
                Return _IP_ADDRESS
            End Get
            Set(ByVal value As String)
               _IP_ADDRESS = value
            End Set
        End Property 
        <Column(Storage:="_BROWSER", DbType:="VarChar(255)")>  _
        Public Property BROWSER() As  String 
            Get
                Return _BROWSER
            End Get
            Set(ByVal value As  String )
               _BROWSER = value
            End Set
        End Property 
        <Column(Storage:="_SERVER_URL", DbType:="VarChar(255)")>  _
        Public Property SERVER_URL() As  String 
            Get
                Return _SERVER_URL
            End Get
            Set(ByVal value As  String )
               _SERVER_URL = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATEDBY = ""
            _CREATEDDATE = New DateTime(1,1,1)
            _UPDATEDBY = ""
            _UPDATEDDATE = New DateTime(1,1,1)
            _USERNAME = ""
            _FIRST_NAME = ""
            _LAST_NAME = ""
            _LOGIN_TIME = New DateTime(1,1,1)
            _LOGOUT_TIME = New DateTime(1,1,1)
            _IP_ADDRESS = ""
            _BROWSER = ""
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
                _ID = DB.GetNextID("ID",tableName, trans)
                _CreatedBy = LoginName
                _CreatedDate = DateTime.Now
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
                _UpdatedBy = LoginName
                _UpdatedDate = DateTime.Now
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
                Return DB.ExecuteNonQuery(Sql, trans)
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

                    ret = (DB.ExecuteNonQuery(SqlInsert, trans) > 0)
                    If ret = False Then
                        _error = DB.ErrorMessage
                    Else
                        _haveData = True
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

                        ret = (DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans) > 0)
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
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlUpdate & tmpWhere
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
                        ret = (DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans) > 0)
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
                ret = False
                _error = MessageResources.MSGEU002 & "### SQL: " & SqlDelete & tmpWhere
            End If

            Return ret
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
                        If Convert.IsDBNull(Rdr("CreatedBy")) = False Then _CreatedBy = Rdr("CreatedBy").ToString()
                        If Convert.IsDBNull(Rdr("CreatedDate")) = False Then _CreatedDate = Convert.ToDateTime(Rdr("CreatedDate"))
                        If Convert.IsDBNull(Rdr("UpdatedBy")) = False Then _UpdatedBy = Rdr("UpdatedBy").ToString()
                        If Convert.IsDBNull(Rdr("UpdatedDate")) = False Then _UpdatedDate = Convert.ToDateTime(Rdr("UpdatedDate"))
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("last_name")) = False Then _last_name = Rdr("last_name").ToString()
                        If Convert.IsDBNull(Rdr("login_time")) = False Then _login_time = Convert.ToDateTime(Rdr("login_time"))
                        If Convert.IsDBNull(Rdr("logout_time")) = False Then _logout_time = Convert.ToDateTime(Rdr("logout_time"))
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("browser")) = False Then _browser = Rdr("browser").ToString()
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
                        If Convert.IsDBNull(Rdr("CreatedBy")) = False Then _CreatedBy = Rdr("CreatedBy").ToString()
                        If Convert.IsDBNull(Rdr("CreatedDate")) = False Then _CreatedDate = Convert.ToDateTime(Rdr("CreatedDate"))
                        If Convert.IsDBNull(Rdr("UpdatedBy")) = False Then _UpdatedBy = Rdr("UpdatedBy").ToString()
                        If Convert.IsDBNull(Rdr("UpdatedDate")) = False Then _UpdatedDate = Convert.ToDateTime(Rdr("UpdatedDate"))
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("first_name")) = False Then _first_name = Rdr("first_name").ToString()
                        If Convert.IsDBNull(Rdr("last_name")) = False Then _last_name = Rdr("last_name").ToString()
                        If Convert.IsDBNull(Rdr("login_time")) = False Then _login_time = Convert.ToDateTime(Rdr("login_time"))
                        If Convert.IsDBNull(Rdr("logout_time")) = False Then _logout_time = Convert.ToDateTime(Rdr("logout_time"))
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
                        If Convert.IsDBNull(Rdr("browser")) = False Then _browser = Rdr("browser").ToString()
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
                Sql += "INSERT INTO " & tableName  & " (ID, CREATEDBY, CREATEDDATE, USERNAME, FIRST_NAME, LAST_NAME, LOGIN_TIME, LOGOUT_TIME, IP_ADDRESS, BROWSER, SERVER_URL)"
                Sql += " VALUES("
                sql += DB.SetDouble(_ID) & ", "
                sql += DB.SetString(_CREATEDBY) & ", "
                sql += DB.SetDateTime(_CREATEDDATE) & ", "
                sql += DB.SetString(_USERNAME) & ", "
                sql += DB.SetString(_FIRST_NAME) & ", "
                sql += DB.SetString(_LAST_NAME) & ", "
                sql += DB.SetDateTime(_LOGIN_TIME) & ", "
                sql += DB.SetDateTime(_LOGOUT_TIME) & ", "
                sql += DB.SetString(_IP_ADDRESS) & ", "
                sql += DB.SetString(_BROWSER) & ", "
                sql += DB.SetString(_SERVER_URL)
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TS_LOGIN_HISTORY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "UPDATEDBY = " & DB.SetString(_UPDATEDBY) & ", "
                Sql += "UPDATEDDATE = " & DB.SetDateTime(_UPDATEDDATE) & ", "
                Sql += "USERNAME = " & DB.SetString(_USERNAME) & ", "
                Sql += "FIRST_NAME = " & DB.SetString(_FIRST_NAME) & ", "
                Sql += "LAST_NAME = " & DB.SetString(_LAST_NAME) & ", "
                Sql += "LOGIN_TIME = " & DB.SetDateTime(_LOGIN_TIME) & ", "
                Sql += "LOGOUT_TIME = " & DB.SetDateTime(_LOGOUT_TIME) & ", "
                Sql += "IP_ADDRESS = " & DB.SetString(_IP_ADDRESS) & ", "
                Sql += "BROWSER = " & DB.SetString(_BROWSER) & ", "
                Sql += "SERVER_URL = " & DB.SetString(_SERVER_URL) + ""
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
                Dim Sql As String = "SELECT ID, CREATEDBY, CREATEDDATE, UPDATEDBY, UPDATEDDATE, USERNAME, FIRST_NAME, LAST_NAME, LOGIN_TIME, LOGOUT_TIME, IP_ADDRESS, BROWSER, SERVER_URL FROM " & tableName
                Return Sql
            End Get
        End Property


    End Class
End Namespace
